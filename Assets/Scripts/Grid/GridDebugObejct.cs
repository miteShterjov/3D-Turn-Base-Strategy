using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Grid
{
    public class GridDebugObject : MonoBehaviour
    {
        [Header("Debug Settings")]
        [SerializeField] private TextMeshPro gridPositionText;
        // [SerializeField] private Color gizmoColor = Color.yellow;
        
        private GridObject _gridObject;

        private void Update()
        {
            gridPositionText.text = _gridObject.ToString();
        }

        public void SetGridObject(GridObject gridObject) => this._gridObject = gridObject;
        
        // private void OnDrawGizmos()
        // {
        //     Gizmos.color = gizmoColor;
        //     Gizmos.DrawWireCube(transform.position, new Vector3(2f, 0.05f, 2f));
        // }
    }
}
