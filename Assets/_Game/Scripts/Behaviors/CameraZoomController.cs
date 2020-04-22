using UnityEngine;

namespace Sequence.Player
{
    public class CameraZoomController : MonoBehaviour
    {
        private bool _followMouse;
        private Camera _mainCam;
        private Camera _playerZoomCam;

        // messages
        private void Start()
        {
            _mainCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            _playerZoomCam = transform.GetComponentInChildren<Camera>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Zoom"))
            {
                Cursor.visible = false;
                var ray = _mainCam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMask.GetMask("SequenceBoard")))
                {
                    print(hit.collider.name);
                    var zoomTransform = _playerZoomCam.transform;
                    zoomTransform.position = new Vector3(hit.point.x, zoomTransform.position.y, hit.point.z);
                    _mainCam.enabled = false;
                    _playerZoomCam.enabled = true;
                    _followMouse = true;
                }
            }

            if (Input.GetButtonUp("Zoom"))
            {
                Cursor.visible = true;
                _mainCam.enabled = true;
                _playerZoomCam.enabled = false;
                _followMouse = false;
            }

            if (_followMouse) TrackZoom();
        }

        // methods
        private void TrackZoom()
        {
            // TODO: X and Y Speed need to be different
            var newPos = new Vector3(Input.GetAxis("Mouse X") * Time.deltaTime * 15f, 0f, Input.GetAxis("Mouse Y") * Time.deltaTime * 15f);
            _playerZoomCam.transform.position += newPos;
        }
    }
}