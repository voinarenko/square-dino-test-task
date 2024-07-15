using UnityEngine;

namespace Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;

        private void Awake() =>
            _health.Dead += OnDeath;

        private void OnDeath()
        {
            _health.Dead -= OnDeath;
            Destroy(gameObject);
        }
    }
}