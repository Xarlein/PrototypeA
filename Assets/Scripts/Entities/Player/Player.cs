using Assets.Scripts.Additions;
using UnityEngine;

namespace Assets.Scripts.Entities.Player
{   
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(Movement))]
    public sealed class Player : MonoBehaviour
    {
        [SerializeField]
        private Health _health;
        [SerializeField]
        private Movement _movement;

        public Health Health { get => _health; private set => _health = value; }
        public Movement Movement { get => _movement; private set => _movement = value; }

        private void FixedUpdate()
        {
            _movement.Move();
        }

    }
}