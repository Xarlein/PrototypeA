using Assets.Scripts.Entities.Player;
using System;
using UnityEngine;

namespace Assets.Scripts.Environment.Triggers
{
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class HealTrigger : MonoBehaviour
    {
        [Header("Main")]
        [SerializeField]
        private float _heal;

        private void Awake()
        {
            if (_heal < 0)
                throw new Exception("Heal must be greater than 0!");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.SendMessage(nameof(Player.Health.Heal), _heal);
            }
        }
    }
}