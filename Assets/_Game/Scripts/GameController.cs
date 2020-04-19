using System;
using UnityEngine;

namespace Sequence
{
    public class GameController : MonoBehaviour
    {
        // TODO: Load this from disk
        [SerializeField] private GameSettings gameSettings;

        // messages
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
            receiver.OnGameSettingsReceived(gameSettings);
        }
    }
}