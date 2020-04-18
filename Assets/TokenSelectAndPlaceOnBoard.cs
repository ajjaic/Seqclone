using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class TokenSelectAndPlaceOnBoard : MonoBehaviour
{
    // messages
    private void OnMouseDrag()
    {
        MoveWithMousePos();
    }

    // methods
    private void MoveWithMousePos()
    {
        var newTokenPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20));
        transform.position = newTokenPos;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMask.GetMask("SequenceBoard")))
        {
            // transform.position = new Vector3(hit.point.x, 1.5f, hit.point.z);
            var newXPos = Grids2DSquare.GetGridPosClamp(hit.point.x, 10, 5, 5, 95);
            var newZPos = Grids2DSquare.GetGridPosClamp(hit.point.z, 10, 5, 5, 95);
            transform.position = new Vector3(newXPos, 1.5f, newZPos);
        }
    }
}
