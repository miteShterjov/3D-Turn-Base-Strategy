using System;
using PlayableUnits;
using UnityEngine;

namespace Managers
{
    public class UnitSelectedVisual : MonoBehaviour
    {
        [Header("Selected Unit Config")]
        [SerializeField] private Unit unit;
    
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
            UpdateVisuals();
        }
    
        private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs empty) => UpdateVisuals();

        private void UpdateVisuals() => _meshRenderer.enabled = UnitActionSystem.Instance.GetSelectedUnit() == unit;
    }
}
