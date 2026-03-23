using Grid;
using PlayableUnits.UnitActions;
using UnityEngine;

namespace PlayableUnits
{
    public class Unit : MonoBehaviour
    {
        private GridPosition _gridPosition;
        private UnitMoveAction _unitMoveAction;
        private UnitSpinAction _unitSpinAction;
        
        private void Awake()
        {
            _unitMoveAction = GetComponent<UnitMoveAction>();
            _unitSpinAction = GetComponent<UnitSpinAction>();
        }

        private void Start()
        {
            _gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            LevelGrid.Instance.AddUnitAtGridPosition(_gridPosition, this);
        }

        private void Update()
        {
            GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            if (newGridPosition != _gridPosition)
            {
                // Unit changed Grid Position
                LevelGrid.Instance.UnitMovedGridPosition(this, _gridPosition, newGridPosition);
                _gridPosition = newGridPosition;
            }
        }

        public UnitMoveAction GetMoveAction() => _unitMoveAction;
        public UnitSpinAction GetSpinAction() => _unitSpinAction;
        
        public GridPosition GetGridPosition() => _gridPosition;
    }
}