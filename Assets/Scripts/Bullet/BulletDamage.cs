﻿using Enemy;
using Logic;
using System;
using UnityEngine;

namespace Bullet
{
    public class BulletDamage : MonoBehaviour
    {
        public event Action<bool> Hit;

        public int Damage { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Constants.EnemyTag))
            {
                if (other.TryGetComponent<EnemyHealth>(out var health))
                    health.TakeDamage(Damage);
            }
            Hit?.Invoke(true);
        }

    }
}