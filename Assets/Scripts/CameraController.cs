using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float rotateSpeed = 90f;
        [SerializeField] private float zoomSpeed = 8f;
        [SerializeField] private float minZoomY = 5f;
        [SerializeField] private float maxZoomY = 20f;
        [SerializeField] private float minZoomZ = -20f;
        [SerializeField] private float maxZoomZ = -5f;
        [SerializeField] private CinemachineCamera virtualCamera;

        private CinemachineFollow _follow;

        private void Awake()
        {
            _follow = virtualCamera.GetComponent<CinemachineFollow>();
            if (_follow == null) Debug.LogError("CinemachineFollow extension not found on " + virtualCamera);
        }

        private void Update()
        {
            Vector3 movement = Vector3.zero;

            if (Keyboard.current != null)
            {
                if (Keyboard.current.wKey.isPressed) movement.z += 1f;
                if (Keyboard.current.sKey.isPressed) movement.z -= 1f;
                if (Keyboard.current.dKey.isPressed) movement.x += 1f;
                if (Keyboard.current.aKey.isPressed) movement.x -= 1f;

                if (Keyboard.current.qKey.isPressed)
                {
                    transform.Rotate(0f, -rotateSpeed * Time.deltaTime, 0f);
                }

                if (Keyboard.current.eKey.isPressed)
                {
                    transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
                }
            }

            movement = movement.normalized;
            transform.Translate(movement * (moveSpeed * Time.deltaTime), Space.Self);

            if (_follow != null && Mouse.current != null)
            {
                float scroll = Mouse.current.scroll.ReadValue().y;
                if (scroll != 0f)
                {
                    Vector3 offset = _follow.FollowOffset;
                    float zoomDelta = scroll * zoomSpeed * Time.deltaTime;

                    offset.y = Mathf.Clamp(offset.y - zoomDelta, minZoomY, maxZoomY);
                    offset.z = Mathf.Clamp(offset.z + zoomDelta, minZoomZ, maxZoomZ);

                    _follow.FollowOffset = offset;
                }
            }
        }
    }
}
