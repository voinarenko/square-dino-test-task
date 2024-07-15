using StaticData;

namespace Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        HeroStaticData ForHero();
        WayPointsStaticData ForWayPoints();
        GameStaticData ForGame();
        PlatformStaticData ForPlatform(int id);
        EnemyStaticData ForEnemy();
        BulletStaticData ForBullet();
    }
}