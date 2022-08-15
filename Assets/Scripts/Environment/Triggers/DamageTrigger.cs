using Assets.Scripts.Entities.Player;
using System;
using UnityEngine;

namespace Assets.Scripts.Environment.Triggers
{
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class DamageTrigger : MonoBehaviour
    {
        [Header("Main")]
        [SerializeField]
        private float _damage;

        private void Awake()
        {
            if (_damage < 0)
                throw new Exception("Damage must be greater than 0!");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.SendMessage(nameof(Player.Health.TakeDamage), _damage);
            }
        }
    }
}