using System;
using UnityEngine;
using UnityEngine.UI;

namespace View.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private Image _healthImage;
        public event Action Changed;
        public event Action Dead;

        public int MaxHealth { get; set; }

        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                if (_currentHealth == value)
                    return;
                _currentHealth = value;
                Changed?.Invoke();
                if (_currentHealth <= 0)
                    Dead?.Invoke();
            }
        }

        private int _currentHealth;
        
        private void Awake() => 
            Changed += OnHealthChanged;
        
        private void OnDestroy() => 
            Changed -= OnHealthChanged;
        
        public void ResetHealth() => 
            CurrentHealth = MaxHealth;
        
        public void TakeDamage(int amount) =>
            CurrentHealth -= amount;
        
        private void OnHealthChanged() => 
            _healthImage.fillAmount = (float)CurrentHealth / MaxHealth;
    }
}