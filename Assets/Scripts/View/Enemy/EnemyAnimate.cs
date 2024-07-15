using UnityEngine;

namespace View.Enemy
{
    public class EnemyAnimate : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        public void SetActive(bool value) => 
            _animator.enabled = value;
    }
}