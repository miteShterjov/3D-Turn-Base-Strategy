using UnityEngine;
using UnityEngine.InputSystem;
using Debug = System.Diagnostics.Debug;

namespace Managers
{
    public class MouseWorldPosition : MonoBehaviour
    {
        private static MouseWorldPosition _instance;
    
        [Header("Raycast Settings")]
        [SerializeField] private LayerMask mousePlaneLayerMask;
    
        private static Camera _camera;

        private void Awake()
        {
            _instance = this;
            _camera = Camera.main;
        }

        private void Start()
        {
            Debug.Assert(_camera, "Camera.main != null");

        }

        public static Vector3 GetPosition()
        {
            Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _instance.mousePlaneLayerMask);
            return raycastHit.point;
        }
    }
}
