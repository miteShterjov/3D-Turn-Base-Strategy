using UnityEngine;
using UnityEngine.InputSystem;

namespace Unit
{
    public class UnitMoveController : MonoBehaviour
    {
        [Header("Move Settings")]
        [SerializeField] private float moveSpeed = 4f;
        [SerializeField] private float enoughDistance = 0.1f;
        
        private Vector3 _moveDirection;

        private void Update()
        {
            if (Vector3.Distance(transform.position, _moveDirection) > enoughDistance)
            {
                Vector3 moveDirection = (_moveDirection - transform.position).normalized;
                transform.position += moveDirection * (moveSpeed * Time.deltaTime);
            }
            
            if (Mouse.current.leftButton.wasPressedThisFrame) Move(MouseWorldPosition.GetPosition());
        }

        private void Move(Vector3 moveDirection) => this._moveDirection = moveDirection;
    }
}