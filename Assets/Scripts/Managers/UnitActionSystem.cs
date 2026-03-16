using PlayableUnits;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class UnitActionSystem : MonoBehaviour
    {
        [ Header( "Selected Unit Config" )]
        [SerializeField] private UnitMoveController selectedUnit;
        [SerializeField] private LayerMask unitLayerMask;
        private Camera _camera;


        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (TryHandleUnitSelection()) return;

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                selectedUnit.Move(MouseWorldPosition.GetPosition());
            }
        }

        private bool TryHandleUnitSelection()
        {
            Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (!Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask)) return false;
            if (!raycastHit.transform.TryGetComponent(out UnitMoveController unit)) return false;
            selectedUnit = unit;
            return true;
        }

    }
}
