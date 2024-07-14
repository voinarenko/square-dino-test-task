namespace Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        HeroStaticData ForHero();
        WayPointsStaticData ForWayPoints();
        GameStaticData ForGame();
    }
}