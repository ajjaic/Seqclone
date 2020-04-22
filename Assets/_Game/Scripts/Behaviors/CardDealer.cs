using UnityEngine;
using Xyaneon.Games.Cards.StandardPlayingCards;

namespace Sequence.Player
{
    public class CardDealer : MonoBehaviour, IGameControllerReceiver
    {
        private StandardPlayingCardDeck _deck;
        private GameController _gameController;
        private CardHandController[] _players;

        // API
        public void OnGameControllerReceived(GameController gameController)
        {
            _gameController = gameController;
        }

        // methods
        private void Start()
        {
            GameSignals.REQUIRE_GAME_CONTROLLER.TriggerEvent(this);
            _deck = new StandardPlayingCardDeck();
            _deck.Shuffle();
        }

        public void DealCards()
        {
            var numberOfCardsPerPlayer = _gameController.playersToCardCount[_gameController.PlayerCount];
            foreach (var player in _gameController.Players)
            {
                var playerHand = _deck.Draw(numberOfCardsPerPlayer);
                player.CardHandController.SetCardsInHand(playerHand);
            }
        }
    }
}