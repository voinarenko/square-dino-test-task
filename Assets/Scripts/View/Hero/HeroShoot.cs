using Factory;
using UnityEngine;
using UnityEngine.InputSystem;
using View.Bullet;

namespace View.Hero
{
    public class HeroShoot : MonoBehaviour
    {
        public bool Enabled { get; set; }

        [SerializeField] private Transform _shootPoint;
        
        private IGameFactory _factory;
        private Camera _camera;
        private PlayerInputActions _inputActions;

        public void Construct(IGameFactory factory) => 
            _factory = factory;
        
        private void OnEnable()
        {
            _inputActions.Gameplay.Enable();
            _inputActions.Gameplay.Shoot.performed += OnShoot;
        }
        
        private void Awake()
        {
            _inputActions = new PlayerInputActions();
            _camera = Camera.main;
        }

        private void OnDisable()
        {
            _inputActions.Gameplay.Shoot.performed -= OnShoot;
            _inputActions.Gameplay.Disable();
        }

        private void Fire()
        {
            if (!Enabled) 
                return;
            
            var touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            var ray = _camera.ScreenPointToRay(touchPosition);
            if (Physics.Raycast(ray, out var hit, 1000))
            {
                var bullet = _factory.GetBullet(_shootPoint, hit.point);
                bullet.Destroyed += OnBulletDestroy;
                bullet.TryGetComponent<BulletMove>(out var move);
                move.Run();
            }
        }

        private void OnShoot(InputAction.CallbackContext context) =>
            Fire();

        private void OnBulletDestroy(BulletDestroy bullet)
        {
            bullet.Destroyed -= OnBulletDestroy;
            _factory.PutBullet(bullet);
            bullet.gameObject.SetActive(false);
        }
    }
}