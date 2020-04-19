using UnityEngine;
using UnityEngine.Assertions;

namespace Utils
{
    public static class UtilityMethods 
    {
        /// <summary>
        ///   <para>Takes a value and returns the closest value based on the multiple. If there is an offset, add that offset as well</para>
        /// </summary>
        /// <param name="val">The value to floor</param>
        /// <param name="multiple">A multiple of this will be used to floor val</param>
        /// <param name="offset">Add this offset to the final floored value</param>
        /// <returns>
        ///   <para>The value lower than or equal val</para>
        /// </returns>
        public static float FloorByMultiple(float val, int multiple, int offset)
        {
            Debug.Assert(offset < multiple, "offset < stepSize");
            return (Mathf.Floor(val / multiple) * multiple) + offset;
        }

        /// <summary>
        ///   <para>Same as FloorByMultiple but clamp the resulting floored value</para>
        /// </summary>
        /// <param name="val">The value to floor</param>
        /// <param name="multiple">A multiple of this will be used to floor val</param>
        /// <param name="offset">Add this offset to the final floored value</param>
        /// <param name="valMin">The minimum floored value</param>
        /// <param name="valMax">The maximum floored value</param>
        /// <returns>
        ///   <para>The value lower than or equal val</para>
        /// </returns>
        public static float FloorByMultipleClamp(float val, int multiple, int offset, int valMin, int valMax)
        {
            var flooredValue = FloorByMultiple(val, multiple, offset);
            return Mathf.Clamp(flooredValue, valMin, valMax);
        }

        /// <summary>
        ///   <para>Same as FloorByMultiple but clamp the resulting floored value</para>
        /// </summary>
        /// <param name="pointToFloor">The point to floor</param>
        /// <param name="gridSideCellCount">Number of cells in the side of the square grid</param>
        /// <param name="offset">Offset to add both X and Y axis</param>
        /// <param name="minGridExtent">The first point on the grid in units in X and Y axis</param>
        /// <param name="maxGridExtent">The last point on the grid in units in X and Y axis</param>
        /// <returns>
        ///   <para>The vector that snaps to the closed grid point</para>
        /// </returns>
        public static Vector2 Floored2DGridPointClamp(Vector2 pointToFloor, int gridSideCellCount, int offset, int minGridExtent, int maxGridExtent)
        {
            var xPos = FloorByMultipleClamp(pointToFloor.x, gridSideCellCount, offset, minGridExtent, maxGridExtent);
            var yPos = FloorByMultipleClamp(pointToFloor.y, gridSideCellCount, offset, minGridExtent, maxGridExtent);
            
            return new Vector2(xPos, yPos);
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