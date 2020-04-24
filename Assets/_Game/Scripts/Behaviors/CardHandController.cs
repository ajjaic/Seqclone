using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Xyaneon.Games.Cards.StandardPlayingCards;

namespace Sequence.Player
{
    public class CardHandController : MonoBehaviour, IGameControllerReceiver
    {
        private List<CardController> _cardsInHand;
        private GameController _gameController;
        private PlayedCardController _playedCardController;
        private readonly float _distanceBetweenCards = 0.4f; // TODO: should be in gamecontroller?;
        [SerializeField] private Transform playerHand;


        // messages
        private void Start()
        {
            _cardsInHand = new List<CardController>();
            GameSignals.REQUIRE_GAME_CONTROLLER.TriggerEvent(this);
            _playedCardController = GetComponent<PlayedCardController>();
        }

        private CardController CreateCard(StandardPlayingCard card)
        {
            // Create the card. Tell it its Rank and Suit. Also tell it who to contact if the player decides to play it.
            var cardPrefab = _gameController.cardMap.GetCard(card.Suit, card.Rank);
            var instantiatedCard = Instantiate(cardPrefab, playerHand);
            var cardControllerComponent = instantiatedCard.GetComponent<CardController>();
            cardControllerComponent.SetStandardPlayingCard(card);
            cardControllerComponent.SetCardHandController(this);
            return cardControllerComponent;
        }
        
        private void CreateCardsInHand(IEnumerable<StandardPlayingCard> cardsInHand)
        {
            foreach (StandardPlayingCard card in cardsInHand)
            {
                CardController instantiatedCard = CreateCard(card);
                _cardsInHand.Add(instantiatedCard);
            }
        }
        
        private void CardIsPlayed(CardController cardController)
        {
            var isRemoved = _cardsInHand.Remove(cardController);
            if (isRemoved)
            {
                _playedCardController.CardIsPlayed(cardController);
                UpdateCardPositions();
            }
        }

        private void UpdateCardPositions()
        {
            // Place each card adjacent to each other
            var cardOffset = Vector3.zero;
            foreach (var cardController in _cardsInHand)
            {
                cardController.transform.position = playerHand.position + cardOffset;
                cardOffset.x += _distanceBetweenCards;
            }
        }

        // public messages
        public void SetCardsInHand(IEnumerable<StandardPlayingCard> cardsInHand)
        {
            // Create the cards in hand and display them
            CreateCardsInHand(cardsInHand);
            UpdateCardPositions();
        }

        public void OnCardClicked(CardController cardController)
        {
            CardIsPlayed(cardController);
        }
        
        public void OnGameControllerReceived(GameController gameController) => _gameController = gameController;
    }
}