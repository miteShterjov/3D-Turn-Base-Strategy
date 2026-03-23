using System;
using Grid;
using PlayableUnits;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class UnitActionSystem : MonoBehaviour
    {
        public static UnitActionSystem Instance { get; private set; }
        public event EventHandler OnSelectedUnitChanged;
        
        [ Header( "Selected Unit Config" )]
        [SerializeField] private Unit selectedUnit;
        [SerializeField] private LayerMask unitLayerMask;

        private Camera _camera;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.Log("More then one UnitActionSystem in scene! " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (TryHandleUnitSelection()) return;
                GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorldPosition.GetPosition());

                if (selectedUnit.GetMoveAction().IsValidActionGridPosition(mouseGridPosition))
                {
                    selectedUnit.GetMoveAction().Move(mouseGridPosition);
                }

            }

            if (Mouse.current.rightButton.wasPressedThisFrame) selectedUnit.GetSpinAction().Spin();
        }
        
        public Unit GetSelectedUnit() => selectedUnit;

        private bool TryHandleUnitSelection()
        {
            Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (!Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask)) return false;
            if (!raycastHit.transform.TryGetComponent(out Unit unit)) return false;
            SetSelectedUnit(unit);
            return true;
        }

        private void SetSelectedUnit(Unit unit)
        {
            if (selectedUnit == unit) return;
            
            selectedUnit = unit;
            OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
