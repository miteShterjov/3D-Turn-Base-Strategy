using System.Collections.Generic;
using PlayableUnits;

namespace Grid
{
    public class GridObject
    {

        private GridSystem _gridSystem;
        private GridPosition _gridPosition;
        private List<Unit> _unitList;

        public GridObject(GridSystem gridSystem, GridPosition gridPosition)
        {
            this._gridSystem = gridSystem;
            this._gridPosition = gridPosition;
            _unitList = new List<Unit>();
        }

        public override string ToString()
        {
            string unitString = "";
            foreach (Unit unit in _unitList)
            {
                unitString += unit.name + "\n";
            }

            return _gridPosition.ToString() + "\n" + unitString;
        }

        public void AddUnit(Unit unit) => _unitList.Add(unit);
        
        public void RemoveUnit(Unit unit) => _unitList.Remove(unit);
        
        public List<Unit> GetUnitList() => _unitList;
        
        public bool HasAnyUnits() => _unitList.Count > 0;
    }
}