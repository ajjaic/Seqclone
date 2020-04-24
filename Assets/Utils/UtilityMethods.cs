using UnityEngine;

namespace Utils
{
    public static class UtilityMethods 
    {
        /* 
         * Takes a value "val" and floors it the closest multiple of "stepMultiple" that is lower than or equal to "val". Finally, the
         * offset is added to the result
         * Params:
         *     val          - The value to floor
         *     stepMultiple - A multiple of this will be used to floor "val"
         *     offset       - Add this offset to the final floored value
         * Returns the value lower than or equal to "val"
         */
        public static float FloorByMultiple(float val, int stepMultiple, int offset)
        {
            Debug.Assert(offset < stepMultiple, "offset < stepSize");
            return (Mathf.Floor(val / stepMultiple) * stepMultiple) + offset;
        }

        /* Same as "FloorByMultiple" but clamp the resulting floored value
         * Params:
         *     val          - The value to floor
         *     stepMultiple - A multiple of this will be used to floor "val"
         *     offset       - Add this offset to the final floored value
         *     valMin       - The minimum floored value
         *     valMax       - The maximum floored value
         * Returns the value lower than or equal to "val" but greater than "valMin" and lower than "valMax"
         */  
        public static float FloorByMultipleClamp(float val, int stepMultiple, int offset, int valMin, int valMax)
        {
            var flooredValue = FloorByMultiple(val, stepMultiple, offset);
            return Mathf.Clamp(flooredValue, valMin, valMax);
        }
        
        /*
         * Same as "FloorByMultiple" and "FloorByMultipleClamp" but in 2 dimensions
         * Params:
         *     pointToFloor      - The point to floor
         *     gridSideCellCount - Number of cells in the side of the square grid
         *     offset            - Offset to add both X and Y axis
         * Returns the vector that snaps to the closed grid point</para>
         */
        public static Vector2 Floored2DGridPoint(Vector2 pointToFloor, int gridSideCellCount, int offset)
        {
            var xPos = FloorByMultiple(pointToFloor.x, gridSideCellCount, offset);
            var yPos = FloorByMultiple(pointToFloor.y, gridSideCellCount, offset);
            
            return new Vector2(xPos, yPos);
        }

        /* 
         * Same as "FloorByMultiple" and "FloorByMultipleClamp" but in 2 dimensions
         * Params:
         *     pointToFloor      - The point to floor
         *     gridSideCellCount - Number of cells in the side of the square grid
         *     offset            - Offset to add both X and Y axis
         *     minGridExtent     - The lowest point on the grid in X and Y axis
         *     maxGridExtent     - The highest point on the grid in X and Y axis
         * Returns the vector that snaps to the closed grid point and lies within the grid
         */
        public static Vector2 Floored2DGridPointClamp(Vector2 pointToFloor, int gridSideCellCount, int offset, int minGridExtent, int maxGridExtent)
        {
            var flooredPoint = Floored2DGridPoint(pointToFloor, gridSideCellCount, offset);
            flooredPoint.x = Mathf.Clamp(flooredPoint.x, minGridExtent, maxGridExtent);
            flooredPoint.y = Mathf.Clamp(flooredPoint.y, minGridExtent, maxGridExtent);

            return flooredPoint;
        }
        
        /*
         * Takes the screen space position of the mouse and returns a world space point. The world space point will be in front of the camera.
         * Params:
         *     cam      - This camera will be the reference point from which the world space point will be computed
         *     distance - The distance from the camera to the world space point
         * Returns the world space point in front of the camera
         */
        public static Vector3 GetMousePosInFrontOfCam(Camera cam, float distance)
        {
            var screenPosWithZDist = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            var newPos = cam.ScreenToWorldPoint(screenPosWithZDist);
            return newPos;
        }

        /*
         * Moves the game object by tracking the motion of the mouse in the XZ plane. The mouse axis must be name "Mouse X" and "Mouse Y"
         * in the Input tab of Project Settings.
         * Params:
         *     gameObjectPos - The Transform to move by tracking mouse movement
         *     speedInXAxis  - How much of the mouse's movement in the X-axis are we taking into account
         *     speedInZAxis  - How much of the mouse's movement in the Z-axis are we taking into account
         */
        public static void MoveGameObjectByTrackingMouseInXZPlane(Transform gameObjectPos, float speedInXAxis, float speedInZAxis)
        {
            var newGameObjectPos = new Vector3(Input.GetAxis("Mouse X") * Time.deltaTime * speedInXAxis, 0f, Input.GetAxis("Mouse Y") * Time.deltaTime * speedInZAxis);
            gameObjectPos.position += newGameObjectPos;
        }
    }
}