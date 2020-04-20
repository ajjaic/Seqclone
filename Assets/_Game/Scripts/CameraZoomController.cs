using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Sequence.Player
{
    public class CameraZoomController : MonoBehaviour
    {
        private Camera _playerZoomCam;
        private Camera _mainCam;
        private bool _followMouse;

        // messages
        private void Start()
        {
            _mainCam =  GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            _playerZoomCam = transform.GetComponentInChildren<Camera>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Zoom"))
            {
                var ray = _mainCam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    var playerTransform = transform;
                    playerTransform.localPosition = new Vector3(hit.point.x, playerTransform.localPosition.y, hit.point.z);
                    _mainCam.enabled = false;
                    _playerZoomCam.enabled = true;
                    _followMouse = true;
                }
            }

            if (Input.GetButtonUp("Zoom"))
            {
                _mainCam.enabled = true;
                _playerZoomCam.enabled = false;
                _followMouse = false;
            }

            if (_followMouse)
            {
                TrackZoom();
            }
        }

        // methods
        private void TrackZoom()
        {
            // TODO: X and Y Speed need to be different
            var newPos = new Vector3(Input.GetAxis("Mouse X") * Time.deltaTime * 15f, 0f, Input.GetAxis("Mouse Y") * Time.deltaTime * 15f);
            transform.localPosition += newPos;
        }
    }
}
