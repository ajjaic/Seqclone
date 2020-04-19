using UnityEngine;

namespace Utils
{
    public static class UtilityMethods 
    {
        /// <summary>
        ///   <para>Takes a value <paramref name="val"/> and floors it the closest multiple of <paramref name="stepMultiple"/> that is lower than or equal to <paramref name="val"/></para>
        ///   <para>Finally, the offset is added to the result</para>
        /// </summary>
        /// <param name="val">The value to floor</param>
        /// <param name="stepMultiple">A multiple of this will be used to floor <paramref name="val"/></param>
        /// <param name="offset">Add this offset to the final floored value</param>
        /// <returns>
        ///   <para>The value lower than or equal to <paramref name="val"/></para>
        /// </returns>
        public static float FloorByMultiple(float val, int stepMultiple, int offset)
        {
            Debug.Assert(offset < stepMultiple, "offset < stepSize");
            return (Mathf.Floor(val / stepMultiple) * stepMultiple) + offset;
        }

        /// <summary>
        ///   <para>Same as <see cref="FloorByMultiple"/> but clamp the resulting floored value</para>
        /// </summary>
        /// <param name="val">The value to floor</param>
        /// <param name="stepMultiple">A multiple of this will be used to floor <paramref name="val"/></param>
        /// <param name="offset">Add this offset to the final floored value</param>
        /// <param name="valMin">The minimum floored value</param>
        /// <param name="valMax">The maximum floored value</param>
        /// <returns>
        ///   <para>The value lower than or equal to <paramref name="val"/> but greater than <paramref name="valMin"/> and lower than <paramref name="valMax"/></para>
        /// </returns>
        public static float FloorByMultipleClamp(float val, int stepMultiple, int offset, int valMin, int valMax)
        {
            var flooredValue = FloorByMultiple(val, stepMultiple, offset);
            return Mathf.Clamp(flooredValue, valMin, valMax);
        }
        
        /// <summary>
        ///   <para>Same as <see cref="FloorByMultiple"/> and <see cref="FloorByMultipleClamp"/> but in 2 dimensions</para>
        /// </summary>
        /// <param name="pointToFloor">The point to floor</param>
        /// <param name="gridSideCellCount">Number of cells in the side of the square grid</param>
        /// <param name="offset">Offset to add both X and Y axis</param>
        /// <returns>
        ///   <para>The vector that snaps to the closed grid point</para>
        /// </returns>
        public static Vector2 Floored2DGridPoint(Vector2 pointToFloor, int gridSideCellCount, int offset)
        {
            var xPos = FloorByMultiple(pointToFloor.x, gridSideCellCount, offset);
            var yPos = FloorByMultiple(pointToFloor.y, gridSideCellCount, offset);
            
            return new Vector2(xPos, yPos);
        }

        /// <summary>
        ///   <para>Same as <see cref="FloorByMultiple"/> and <see cref="FloorByMultipleClamp"/> but in 2 dimensions</para>
        /// </summary>
        /// <param name="pointToFloor">The point to floor</param>
        /// <param name="gridSideCellCount">Number of cells in the side of the square grid</param>
        /// <param name="offset">Offset to add both X and Y axis</param>
        /// <param name="minGridExtent">The lowest point on the grid in X and Y axis</param>
        /// <param name="maxGridExtent">The highest point on the grid in X and Y axis</param>
        /// <returns>
        ///   <para>The vector that snaps to the closed grid point and lies within the grid</para>
        /// </returns>
        public static Vector2 Floored2DGridPointClamp(Vector2 pointToFloor, int gridSideCellCount, int offset, int minGridExtent, int maxGridExtent)
        {
            var flooredPoint = Floored2DGridPoint(pointToFloor, gridSideCellCount, offset);
            flooredPoint.x = Mathf.Clamp(flooredPoint.x, minGridExtent, maxGridExtent);
            flooredPoint.y = Mathf.Clamp(flooredPoint.y, minGridExtent, maxGridExtent);

            return flooredPoint;
        }
        
        /// <summary>
        ///   <para>Takes the screen space position of the mouse and returns a world space point. The world space point will be in front of the camera.</para>
        /// </summary>
        /// <param name="visibleCam">This camera will be the reference point from which the world space point will be computed</param>
        /// <param name="distance">The distance from the camera to the world space point</param>
        /// <returns>
        ///   <para>The world space point in front of the camera</para>
        /// </returns>
        public static Vector3 GetMousePosInFrontOfVisibleCamera(Camera visibleCam, float distance)
        {
            var screenPosWithZDist = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            var newPos = visibleCam.ScreenToWorldPoint(screenPosWithZDist);
            return newPos;
        }
    }
}