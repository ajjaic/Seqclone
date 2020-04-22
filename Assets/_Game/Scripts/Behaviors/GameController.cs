using System.Collections.Generic;
using Sequence.Player;
using UnityEngine;

namespace Sequence
{
    public class GameController : MonoBehaviour
    {
        public readonly Dictionary<int, int> playersToCardCount = new Dictionary<int, int>
        {
            {1, 7}, {2, 7}, {3, 6}, {4, 6}, {6, 5}, {8, 4}, {9, 4}, {10, 3}, {12, 3} // TODO: remove {1, 7}
        };

        public CardSuitNRankToPrefab cardMap;
        [SerializeField] private Transform playersParent;

        public Queue<PlayerData> Players { get; set; }
        public int PlayerCount { get; set; }

        // messages
        private void Start()
        {
            PlayerCount = playersParent.childCount;
            Players = new Queue<PlayerData>(PlayerCount);
            foreach (Transform child in playersParent)
            {
                var newPlayer = new PlayerData(child.GetComponent<CardDealer>(), child.GetComponent<CardHandController>());
                Players.Enqueue(newPlayer);
            }

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

        private void OnStartGame(object sender)
        {
            var currentDealer = Players.Dequeue();
            Players.Enqueue(currentDealer);
            currentDealer.CardDealer.DealCards();
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

        public PlayerData(CardDealer d, CardHandController h)
        {
            CardDealer = d;
            CardHandController = h;
        }
    }
}