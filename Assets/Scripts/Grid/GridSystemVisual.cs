using System;
using System.Collections.Generic;
using Managers;
using PlayableUnits;
using UnityEngine;

namespace Grid
{
    public class GridSystemVisual : MonoBehaviour
    {
        public static GridSystemVisual Instance { get; private set; }
        
        [SerializeField] private Transform gridSystemVisualSinglePrefab;
        
        private GridSystemVisualSingle[,] _gridSystemVisualSingleArray;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There's more than one GridSystemVisual! " + transform + " - " + Instance);
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            _gridSystemVisualSingleArray = new GridSystemVisualSingle[LevelGrid.Instance.GetWidth(), LevelGrid.Instance.GetHeight()];
            for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
            {
                for (int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
                {
                    Transform gridSystemVisualSingleTransform = Instantiate(
                        gridSystemVisualSinglePrefab, 
                        LevelGrid.Instance.GetWorldPosition(new GridPosition(x, z)), 
                        Quaternion.identity
                        );
                    
                    _gridSystemVisualSingleArray[x, z] = gridSystemVisualSingleTransform.GetComponent<GridSystemVisualSingle>();
                }
            }
        }

        private void Update()
        {
            UpdateGridVisual();
        }

        public void HideAllGridPositions()
        {
            for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
            {
                for (int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
                {
                    _gridSystemVisualSingleArray[x, z].Hide();
                }
            }
        }

        public void ShowGridPositionList(List<GridPosition> gridPosition)
        {
            foreach (GridPosition gridPositionItem in gridPosition)
            {
                _gridSystemVisualSingleArray[gridPositionItem.X, gridPositionItem.Z].Show();
            }
        }

        private void UpdateGridVisual()
        {
            Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
            
            HideAllGridPositions();
            ShowGridPositionList(selectedUnit.GetMoveAction().GetValidActionGridPositionList());
        }
    }
}
