using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings", order = 0)]
public class GameSettings : ScriptableObject
{
    [Tooltip("Offset within each grid in both X and Y axis")]
    public int gridOffset = 5;

    [Tooltip("Midpoint of board in X and Y axis")]
    public int gridPlaneCenter = 50;

    public int gridSize = 10;

    public int GetAxisMin()
    {
        return gridOffset;
    }

    public int GetAxisMax()
    {
        return gridPlaneCenter * 2 - gridOffset;
    }
}