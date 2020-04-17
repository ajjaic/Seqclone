using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

[ExecuteInEditMode]
public class Token : MonoBehaviour
{
    private void Update()
    {
        float xPos = Grids2DSquare.GetGridPosClamp(transform.position.x, 10, 5, 5, 95);
        float zPos = Grids2DSquare.GetGridPosClamp(transform.position.z, 10, 5, 5, 95);
        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }
}
