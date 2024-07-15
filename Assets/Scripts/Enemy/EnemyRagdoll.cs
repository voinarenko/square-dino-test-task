using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyRagdoll : MonoBehaviour
    {
        [SerializeField] private List<Rigidbody> _rigidbodies;
        [SerializeField] private Collider _collider;
        [SerializeField] private EnemyAnimate _animate;
        [SerializeField] private NavMeshAgent _agent;

        public void SetRagdoll(bool value)
        {
            _agent.enabled =!value;
            _animate.SetActive(!value);
            _collider.enabled = !value;
            foreach (var body in _rigidbodies)
                body.isKinematic = !value;
        }
    }
}