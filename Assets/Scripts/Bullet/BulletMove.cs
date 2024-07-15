using UnityEngine;

namespace Bullet
{
    public class BulletMove : MonoBehaviour
    {
        public float Speed { get; set; }
        public Vector3 Target { get; set; }

        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 _dir;
        private bool _moving;

        private void OnEnable() =>
            Run();

        private void FixedUpdate()
        {
            if (_moving)
                Move();
        }

        public void Run()
        {
            _moving = true;
            _dir = (Target - transform.position).normalized;
        }

        private void Move() =>
            _rigidbody.MovePosition(transform.position + _dir * (Speed * Time.fixedDeltaTime));

    }
}