using Factory;
using UnityEngine;
using View.Bullet;

namespace View.Hero
{
    public class HeroShoot : MonoBehaviour
    {
        public bool Enabled { get; set; }

        [SerializeField] private Transform _shootPoint;
        
        private IGameFactory _factory;
        private Camera _camera;
        
        public void Construct(IGameFactory factory) => 
            _factory = factory;
        
        private void Awake()
        {
            Enabled = true;
            _camera = Camera.main;
        }

        public void Fire()
        {
            if (!Enabled) 
                return;
            
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, 1000))
            {
                var bullet = _factory.GetBullet(_shootPoint, hit.point);
                bullet.Destroyed += OnBulletDestroy;
                bullet.TryGetComponent<BulletMove>(out var move);
                move.Run();
            }
        }

        private void OnBulletDestroy(BulletDestroy bullet)
        {
            bullet.Destroyed -= OnBulletDestroy;
            _factory.PutBullet(bullet);
            bullet.gameObject.SetActive(false);
        }
    }
}