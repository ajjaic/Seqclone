using System;
using UnityEngine;

namespace Sequence.Tokens
{
    public class PickAndPlace : MonoBehaviour
    {
        private Transform _boardPosColliderTransform;

        private void Update()
        {
            
            var newPos = new Vector3(Input.GetAxis("Mouse X") * Time.deltaTime * 50f, 0f, Input.GetAxis("Mouse Y") * Time.deltaTime * 50f);
            transform.position += newPos;
        }

        public void OnMouseDown()
        {
            Cursor.visible = false;
            enabled = true;
        }

        public void OnMouseUp()
        {
            Cursor.visible = true;
            if (_boardPosColliderTransform) transform.position = _boardPosColliderTransform.position;
            enabled = false;
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