using Data;
using UnityEngine;

namespace Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;
        private PlayerProgress _progress;

        public void Construct(PlayerProgress progress) => 
            _progress = progress;
        
        private void Awake() =>
            _health.Dead += OnDeath;

        private void OnDeath()
        {
            _health.Dead -= OnDeath;
            _progress.EnemiesLeft--;
            Destroy(gameObject);
        }
    }
}