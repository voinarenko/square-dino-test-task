using System;
using UnityEngine;

namespace Bullet
{
    public class BulletDestroy : MonoBehaviour
    {
        public event Action<BulletDestroy> Destroyed;
        
        [SerializeField] private BulletDamage _damage;

        private void Awake() =>
            _damage.Hit += OnHit;

        private void OnHit(bool obj) =>
            Destroyed?.Invoke(this);
    }
}