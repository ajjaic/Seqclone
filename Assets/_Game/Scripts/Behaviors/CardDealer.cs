using UnityEngine;
using Xyaneon.Games.Cards.StandardPlayingCards;

namespace Sequence.Player
{
    public class CardDealer : MonoBehaviour, IGameControllerReceiver
    {
        private StandardPlayingCardDeck _deck;
        private GameController _gameController;

        // messages
        private void Start() => GameSignals.REQUIRE_GAME_CONTROLLER.TriggerEvent(this);

        // public messages
        public void OnGameControllerReceived(GameController gameController)
        {
            _gameController = gameController;
        }
        
        public void DealCards()
        {
            var numberOfCardsPerPlayer = _gameController.PlayersToCardCount[_gameController.PlayerCount]; // How many cards should we give each player? Depends on number of players in the game
            _deck = new StandardPlayingCardDeck(); // Create a new deck and shuffle.
            _deck.Shuffle();
            
            // Deal the right number of cards to each player
            foreach (var player in _gameController.Players)
            {
                var playerHand = _deck.Draw(numberOfCardsPerPlayer);
                player.CardHandController.SetCardsInHand(playerHand);
            }
        }
    }
}