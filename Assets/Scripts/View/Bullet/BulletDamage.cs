using Logic;
using System;
using UnityEngine;
using View.Enemy;

namespace View.Bullet
{
    public class BulletDamage : MonoBehaviour
    {
        public event Action<bool> Hit;

        public int Damage { get; set; }

        private bool _collided;

        private void OnEnable() =>
            _collided = false;

        private void OnTriggerEnter(Collider other)
        {
            if (_collided)
                return;

            _collided = true;
            if (other.CompareTag(Constants.EnemyTag))
            {
                if (other.TryGetComponent<EnemyHealth>(out var health))
                    health.TakeDamage(Damage);
            }
            Hit?.Invoke(true);
        }

    }
}