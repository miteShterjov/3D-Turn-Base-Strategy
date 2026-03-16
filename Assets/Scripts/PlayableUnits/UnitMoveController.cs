using UnityEngine;

namespace PlayableUnits
{
    public class UnitMoveController : MonoBehaviour
    {
        [Header("Move Settings")]
        [SerializeField] private float moveSpeed = 4f;
        [SerializeField] private float enoughDistance = 0.1f;
        
        private Vector3 _targetPosition;
        private Animator _animator;
        
        private static readonly int MoveAnimParam = Animator.StringToHash("isWalking");

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _targetPosition = transform.position;
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _targetPosition) > enoughDistance)
            {
                float rotateSpeed = 15f;
                Vector3 moveDirection = (_targetPosition - transform.position).normalized;
                transform.position += moveDirection * (moveSpeed * Time.deltaTime);
                transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
                _animator.SetBool(MoveAnimParam, true);
            } 
            else _animator.SetBool(MoveAnimParam, false);
        }

        public void Move(Vector3 moveDirection) => this._targetPosition = moveDirection;
    }
}