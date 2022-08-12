using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Additions
{
    public class Health : MonoBehaviour
    {
        private const float minHealth = 0;

        [Header("Parametrs")]
        [SerializeField]
        private float _maxHealth = 100f;
        [SerializeField]
        private float _healingRatePerSecond = 0.1f;
        [SerializeField]
        private float _currentHealth;
        [SerializeField]
        private bool canHealAuto = true;

        [Header("Events")]
        public UnityEvent OnDamageTaked;
        public UnityEvent OnHeal;
        public UnityEvent OnDead;

        public float MaxHealth { get => _maxHealth; private set => _maxHealth = value; }
        public float HealingRatePerSecond { get => _healingRatePerSecond; private set => _healingRatePerSecond = value; }
        public float CurrentHealth { get => _currentHealth; private set => _currentHealth = value; }
        public bool CanHealAuto { get => canHealAuto; private set => canHealAuto = value; }

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        private void OnEnable()
        {
            OnDamageTaked.AddListener(() => StartCoroutine(nameof(AutoHeal)));
        }

        private void OnDisable()
        {
            OnDamageTaked?.RemoveAllListeners();
            OnHeal?.RemoveAllListeners();
            OnDead?.RemoveAllListeners();
        }

        public void Heal(float health)
        {

            if (health < 0)
                throw new Exception("The health value should not be less than 0!");

            _currentHealth = Mathf.Clamp(health + _currentHealth, minHealth, _maxHealth);

            if (_currentHealth < _maxHealth)
                OnHeal?.Invoke();
        }

        public void TakeDamage(float damage)
        {

            if (damage < 0)
                throw new Exception("The damage value should not be less than 0!");

            _currentHealth = Mathf.Clamp(_currentHealth - damage, minHealth, _maxHealth);

            OnDamageTaked?.Invoke();

            if (_currentHealth == 0)
                OnDead?.Invoke();
        }

        private IEnumerator AutoHeal()
        {

            while (_currentHealth < _maxHealth && canHealAuto)
            {
                Heal(_healingRatePerSecond);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
