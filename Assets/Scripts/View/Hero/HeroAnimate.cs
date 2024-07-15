using UnityEngine;

namespace View.Hero
{
    public class HeroAnimate : MonoBehaviour
    {
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Run = Animator.StringToHash("Run");
        
        [SerializeField] private Animator _animator;
        
        public void PlayIdle()
        {
            if (_animator)
                _animator.SetTrigger(Idle);
        }

        public void PlayRun()
        {
            if (_animator) 
                _animator.SetTrigger(Run);
        }
    }
}