using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings", order = 0)]
public class GameSettings : ScriptableObject
{
    public int gridEndInUnits = 95;

    [Tooltip("Offset within each grid in both X and Y axis")]
    public int gridOffset = 5;

    [Tooltip("How many cells on a side?")] public int gridSize = 10;

    public int gridStartInUnits = 5;
}