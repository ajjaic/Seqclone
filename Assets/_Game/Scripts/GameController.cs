using System;
using UnityEngine;

namespace Sequence
{
    public class GameController : MonoBehaviour
    {
        private GameSettings _gameSettings;

        // messages
        private void Awake()
        {
            _gameSettings = Resources.Load<GameSettings>("GameSettings");
        }

        private void OnEnable()
        {
            GameSignals.REQUIRE_GAME_SETTINGS_EVENT.EventInstance += OnRequireGameSettings;
        }
        
        private void OnDisable()
        {
            GameSignals.REQUIRE_GAME_SETTINGS_EVENT.EventInstance -= OnRequireGameSettings;
        }
        
        private void OnRequireGameSettings(IGameSettingsReceiver receiver)
        {
            receiver.OnGameSettingsReceived(_gameSettings);
        }
    }
}