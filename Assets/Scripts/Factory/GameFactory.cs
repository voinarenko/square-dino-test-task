using Cinemachine;
using Logic;
using Services.Progress;
using Services.StaticData;
using StaticData;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using View.Bullet;
using View.Enemy;
using View.Hero;

namespace Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IProgressService _progressService;
        private readonly Queue<BulletDestroy> _bullets = new();

        public GameFactory(IStaticDataService staticDataService, IProgressService progressService)
        {
            _staticDataService = staticDataService;
            _progressService = progressService;
            _progressService.PlatformChanged += CreateEnemies;
        }

        public void CreateInputListener()
        {
            var data = _staticDataService.ForGame();
            var obj = Object.Instantiate(data.InputListenerPrefab);
            obj.TryGetComponent<PointerInputListener>(out var listener);
            _progressService.SetInputListener(listener);
        }

        public void CreateWaypoints()
        {
            var data = _staticDataService.ForWayPoints();
            foreach (var wayPoint in data.WayPoints)
                _progressService.Progress.WayPoints.Left.Add(Object.Instantiate(wayPoint).transform);
        }

        public void CreateHero()
        {
            var data = _staticDataService.ForHero();
            var points = _progressService.Progress.WayPoints;
            var obj = Object.Instantiate(data.Prefab, points.Left[0].transform.position, Quaternion.identity);
            obj.TryGetComponent<HeroMove>(out var move);
            move.Construct(_progressService);
            obj.TryGetComponent<HeroShoot>(out var shoot);
            shoot.Construct(this);
            _progressService.SetHero(move, shoot);
            obj.TryGetComponent<NavMeshAgent>(out var agent);
            agent.speed = data.MoveSpeed;
            agent.angularSpeed = data.RotateSpeed;
            FollowCamera(obj.transform);
        }

        public BulletDestroy GetBullet(Transform from, Vector3 to)
        {
            if (_bullets.Count > 0)
            {
                var bullet = _bullets.Dequeue();
                var data = _staticDataService.ForBullet();
                bullet.transform.position = from.position;
                bullet.transform.rotation = from.rotation;
                bullet.TryGetComponent<BulletMove>(out var move);
                move.Speed = data.Speed;
                move.Target = to;
                bullet.gameObject.SetActive(true);
                return bullet;
            }
            else
            {
                var obj = CreateBullet(from, to);
                obj.TryGetComponent<BulletDestroy>(out var bullet);
                return bullet;
            }
        }
        
        public void PutBullet(BulletDestroy bullet) =>
            _bullets.Enqueue(bullet);
        
        public void CleanUp()
        {
            var spawnedObjects = Object.FindObjectsByType<SpawnedItem>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            foreach (var spawnedObject in spawnedObjects) 
                Object.Destroy(spawnedObject.gameObject);
            _progressService.Progress.WayPoints.Left.Clear();
            _progressService.FirstRun = true;
            _progressService.Unsubscribe();
        }

        private GameObject CreateBullet(Transform from, Vector3 to)
        {
            var data = _staticDataService.ForBullet();
            var obj = Object.Instantiate(data.Prefab, from.position, Quaternion.identity);
            obj.TryGetComponent<BulletMove>(out var move);
            move.Speed = data.Speed;
            move.Target = to;
            obj.TryGetComponent<BulletDamage>(out var damage);
            damage.Damage = data.Damage;
            return obj;
        }
        
        private void CreateEnemies(int platformId, Transform hero)
        {
            var data = _staticDataService.ForEnemy();
            var points = CreateSpawnPoints(platformId);
            foreach (var point in points) 
                CreateEnemy(hero, data, point);
            _progressService.Progress.EnemiesLeft = points.Count;
        }

        private void CreateEnemy(Transform hero, EnemyStaticData data, GameObject point)
        {
            var obj = Object.Instantiate(data.Prefab, point.transform.position, Quaternion.identity);
            obj.TryGetComponent<EnemyHealth>(out var health);
            health.MaxHealth = data.Health;
            health.ResetHealth();
            obj.TryGetComponent<EnemyDeath>(out var death);
            death.Construct(_progressService.Progress);
            obj.TryGetComponent<EnemyRagdoll>(out var ragdoll);
            ragdoll.SetRagdoll(false);
            obj.transform.LookAt(hero.position);
        }

        private List<GameObject> CreateSpawnPoints(int platformId)
        {
            var data = _staticDataService.ForPlatform(platformId);
            return data.SpawnPoints.Select(Object.Instantiate).ToList();
        }

        private static void FollowCamera(Transform hero)
        {
            var obj = GameObject.FindWithTag(Constants.VirtualCameraTag);
            obj.TryGetComponent<CinemachineVirtualCamera>(out var camera);
            camera.Follow = hero;
            camera.LookAt = hero;
        }
    }
}