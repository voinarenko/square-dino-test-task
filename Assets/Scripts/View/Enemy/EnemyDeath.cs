using Data;
using UnityEngine;

namespace View.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private EnemyRagdoll _ragdoll;
        private PlayerProgress _progress;

        public void Construct(PlayerProgress progress) => 
            _progress = progress;
        
        private void Awake() =>
            _health.Dead += OnDeath;

        private void OnDeath()
        {
            _health.Dead -= OnDeath;
            _progress.EnemiesLeft--;
            _ragdoll.SetRagdoll(true);
        }
    }
}