using UnityEngine;
using Utils;

namespace Sequence.Tokens
{
    [ExecuteInEditMode]
    public class EditModeTokenGridPlacement: MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;
        
        private void Update()
        {
            var currentPos = transform.position;
            
            float xPos = Grids2DSquare.GetGridPosClamp(
                currentPos.x, gameSettings.gridSize, 
                gameSettings.gridOffset, gameSettings.GetAxisMin(), gameSettings.GetAxisMax());
            
            float zPos = Grids2DSquare.GetGridPosClamp(
                currentPos.z, gameSettings.gridSize, 
                gameSettings.gridOffset, gameSettings.GetAxisMin(), gameSettings.GetAxisMax());
            
            transform.position = new Vector3(xPos, currentPos.y, zPos);
        }
    }
}