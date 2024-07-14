using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
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
    }
}