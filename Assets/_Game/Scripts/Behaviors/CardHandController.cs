using System.Collections.Generic;
using UnityEngine;
using Xyaneon.Games.Cards.StandardPlayingCards;

namespace Sequence.Player
{
    public class CardHandController : MonoBehaviour, IGameControllerReceiver
    {
        private IEnumerable<StandardPlayingCard> _cardsInHand;
        private GameController _gameController;
        [SerializeField] private Transform playerHand;

        public void OnGameControllerReceived(GameController gameController)
        {
            _gameController = gameController;
        }

        // messages
        private void Start()
        {
            GameSignals.REQUIRE_GAME_CONTROLLER.TriggerEvent(this);
        }

        // methods
        private void DisplayCards()
        {
            foreach (Transform cardObj in playerHand)
                Destroy(cardObj.gameObject);

            var cardOffset = Vector3.zero;
            foreach (var card in _cardsInHand)
            {
                var cardObj = _gameController.cardMap.GetCard(card.Suit, card.Rank);
                var instantiatedCard = Instantiate(cardObj, playerHand);
                instantiatedCard.transform.position += cardOffset;
                cardOffset.x += .4f;
            }
        }

        // API
        public void SetCardsInHand(IEnumerable<StandardPlayingCard> cardsInHand)
        {
            _cardsInHand = cardsInHand;
            DisplayCards();
        }
    }
}