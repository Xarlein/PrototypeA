using System;
using UnityEngine;

namespace Assets.Scripts.Additions
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Movement : MonoBehaviour
    {
        [Header("Parametrs")]
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _jumpPower;
        [SerializeField]
        private MovementAxis _axis;
        [SerializeField]
        private MovementMode _direction;

        [Header("Components")]
        [SerializeField]
        private Rigidbody2D _rigidbody;

        public void Jump()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            if (_speed <= 0)
                throw new Exception("The speed of movement cannot be less than or equal to 0!");

            Vector2 velocity = Vector2.zero;

            if (_axis == MovementAxis.AxisX)
            {
                velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            }

            if (_axis == MovementAxis.AxisXY)
            {
                velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            }

            velocity.Normalize();
            
            _rigidbody.MovePosition(_rigidbody.position + velocity * _speed * Time.fixedDeltaTime);
        }
    }

    public enum MovementAxis
    {
        AxisX,
        AxisXY
    }

    public enum MovementMode
    {
        JumpOnly,
        WalkOnly,
        WalkAndJump
    }
}
