using Assets.Scripts.Additions;
using System;
using UnityEngine;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Bar))]
    public sealed class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Bar _bar;
        [SerializeField]
        private Health _health;

        private void Awake()
        {
            if (_bar == null)
                throw new NullReferenceException("Bar component not found!");

            if (_health == null)
                throw new NullReferenceException("Health component not found!");
        }

        private void OnEnable()
        {
            _health.OnDamageTaked.AddListener(() => OnHealthChanged());
            _health.OnHeal.AddListener(() => OnHealthChanged());
        }

        private void OnDisable()
        {
            _health.OnDamageTaked.RemoveListener(() => OnHealthChanged());
            _health.OnHeal.RemoveListener(() => OnHealthChanged());
        }

        private void OnHealthChanged() => _bar.SetValue(_health.CurrentHealth / _health.MaxHealth);
    }

}
