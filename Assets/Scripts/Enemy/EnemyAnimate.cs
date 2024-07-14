using UnityEngine;

namespace Enemy
{
    public class EnemyAnimate : MonoBehaviour
    {
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Run = Animator.StringToHash("Run");
        
        [SerializeField] private Animator _animator;
        
        public void PlayIdle() => 
            _animator.SetTrigger(Idle);
        
        public void PlayRun() => 
            _animator.SetTrigger(Run);
    }
}