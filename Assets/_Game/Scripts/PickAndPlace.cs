using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Sequence.Tokens
{
    public class PickAndPlace : MonoBehaviour
    {
        private Transform _boardPosColliderTransform;
        
        private void OnMouseDrag()
        {
            Cursor.visible = false;
            var newPos = new Vector3(Input.GetAxis("Mouse X") * Time.deltaTime * 50f, 0f, Input.GetAxis("Mouse Y") * Time.deltaTime * 50f);
            transform.position += newPos;
        }

        private void OnMouseUp()
        {
            Cursor.visible = true;
            if (_boardPosColliderTransform)
            {
                transform.position = _boardPosColliderTransform.position;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            transform.position = other.transform.position;
            _boardPosColliderTransform = other.transform;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == _boardPosColliderTransform.gameObject)
                _boardPosColliderTransform = null;
        }
    }
}
