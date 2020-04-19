using UnityEngine;
using Utils;
using Debug = System.Diagnostics.Debug;

namespace Sequence.Tokens
{
    public class TokenSelectAndPlaceOnBoard : MonoBehaviour, IGameSettingsReceiver
    {
        private const float DistanceFromCamera = 40f;
        private const float HeightAboveBoard = 1.5f;
        private GameSettings _gameSettings;
        private LayerMask _layerToPlaceToken;

        // public messages
        public void OnGameSettingsReceived(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        // messages
        private void Start()
        {
            _layerToPlaceToken = LayerMask.GetMask("SequenceBoard"); // Set the board's layer.
            GameSignals.REQUIRE_GAME_SETTINGS_EVENT.TriggerEvent(this); // Tell the game controller that you need the game settings
        }

        private void OnMouseDrag()
        {
            MoveWithMousePos();
        }

        // methods
        private void MoveWithMousePos()
        {
            Debug.Assert(Camera.main != null, "Camera.main != null");

            /*
             * If the cursor is on top of the board, make it is so token is only a certain height above board. Otherwise, let token be
             * rendered at point of cursor; certain units away from camera.
             */
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _layerToPlaceToken))
            {
                var pointToConvertToSnapPoint = new Vector2(hit.point.x, hit.point.z);

                var snapPoint = UtilityMethods.Floored2DGridPointClamp(pointToConvertToSnapPoint,
                    _gameSettings.gridSize,
                    _gameSettings.gridOffset,
                    _gameSettings.gridStartInUnits,
                    _gameSettings.gridEndInUnits
                );

                transform.position = new Vector3(snapPoint.x, HeightAboveBoard, snapPoint.y);
            }
            else
            {
                transform.position = UtilityMethods.GetMousePosInFrontOfVisibleCamera(Camera.main, DistanceFromCamera);
            }
        }
    }
}