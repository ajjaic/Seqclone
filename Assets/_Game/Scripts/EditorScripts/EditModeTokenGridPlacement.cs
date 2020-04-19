using UnityEngine;
using Utils;

namespace Sequence.Tokens
{
    [ExecuteInEditMode]
    public class EditModeTokenGridPlacement : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;

        private void Update()
        {
            var currentPos = transform.position;
            var pointToConvertToSnapPoint = new Vector2(currentPos.x, currentPos.z);

            var snapPoint = UtilityMethods.Floored2DGridPointClamp(pointToConvertToSnapPoint,
                gameSettings.gridSize,
                gameSettings.gridOffset,
                gameSettings.gridStartInUnits,
                gameSettings.gridEndInUnits);

            transform.position = new Vector3(snapPoint.x, currentPos.y, snapPoint.y);
        }
    }
}