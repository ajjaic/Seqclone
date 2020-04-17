using UnityEngine;

namespace Utils
{
    public static class Grids2DSquare 
    {
        public static float GetGridPos(float currentAxisPos, int gridSize, int offset)
        {
            float newAxisPos = (Mathf.Floor(currentAxisPos / gridSize) * gridSize) + 5;
            return newAxisPos;
        }

        public static float GetGridPosClamp(float currentAxisPos, int gridSize, int offset, int currentAxisMin, int currentAxisMax)
        {
            float newAxisPos = GetGridPos(currentAxisPos, gridSize, offset);
            float clampedNewAxisPos = Mathf.Clamp(newAxisPos, currentAxisMin, currentAxisMax);
            return clampedNewAxisPos;
        }
    }
}