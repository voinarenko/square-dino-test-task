using Bullet;
using Services;
using UnityEngine;

namespace Factory
{
    public interface IGameFactory : IService
    {
        void CreateHero();
        void CreateWaypoints();
        void CleanUp();
        void CreateInputListener();
        BulletDestroy GetBullet(Transform from, Vector3 to);
        void PutBullet(BulletDestroy bullet);
    }
}