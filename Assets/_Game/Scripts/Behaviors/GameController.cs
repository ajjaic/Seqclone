using System.Collections.Generic;
using Sequence.Player;
using UnityEngine;

namespace Sequence
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Transform playersParent;
        public readonly Dictionary<int, int> PlayersToCardCount = new Dictionary<int, int>
        {
            {1, 7}, {2, 7}, {3, 6}, {4, 6}, {6, 5}, {8, 4}, {9, 4}, {10, 3}, {12, 3} // TODO: remove {1, 7}
        };

        public CardSuitNRankToPrefab cardMap;

        public Queue<PlayerData> Players { get; set; }
        public int PlayerCount { get; set; }

        // messages
        private void Start()
        {
            PlayerCount = playersParent.childCount;
            Players = new Queue<PlayerData>(PlayerCount);
            
            GetPlayers();
            OnStartGame(this);
        }
        
        private void OnEnable()
        {
            GameSignals.REQUIRE_GAME_CONTROLLER.Subscribe(OnRequireGameController);
            GameSignals.START_GAME.Subscribe(OnStartGame);
        }

        private void OnDisable()
        {
            GameSignals.REQUIRE_GAME_CONTROLLER.Unsubscribe(OnRequireGameController);
            GameSignals.START_GAME.Unsubscribe(OnStartGame);
        }


        private void GetPlayers()
        {
            // Get all the players in the game
            foreach (Transform child in playersParent)
            {
                var newPlayer = new PlayerData(child.GetComponent<CardDealer>(), child.GetComponent<CardHandController>(), child.GetComponent<SelfHider>());
                Players.Enqueue(newPlayer);
            }
        }

        private void OnStartGame(object sender)
        {
            // Choose the player that will be dealer for this round. Dealer plays last.
            var currentDealer = Players.Dequeue();
            Players.Enqueue(currentDealer);
            currentDealer.CardDealer.DealCards();
            
            // Show the dealer. Hide the rest of the players
            var dealerIndexInHierarchy= currentDealer.CardDealer.transform.GetSiblingIndex();
            playersParent.GetComponent<PlayerSwitcher>().ShowPlayer(dealerIndexInHierarchy);
        }

        private void OnRequireGameController(IGameControllerReceiver receiver)
        {
            receiver.OnGameControllerReceived(this);
        }
    }

    public struct PlayerData
    {
        public CardDealer CardDealer;
        public CardHandController CardHandController;
        public SelfHider SelfHider;

        public PlayerData(CardDealer d, CardHandController h, SelfHider hider)
        {
            CardDealer = d;
            CardHandController = h;
            SelfHider = hider;
        }
    }
}