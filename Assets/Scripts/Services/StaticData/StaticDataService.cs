using UnityEngine;

namespace Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataHeroPath = "StaticData/Hero/HeroData";
        private const string StaticDataWayPointsPath = "StaticData/WayPoints/WayPointsData";

        private HeroStaticData _hero;
        private WayPointsStaticData _wayPoints;

        public void Load()
        {
            _hero = Resources.Load<HeroStaticData>(StaticDataHeroPath);
            _wayPoints = Resources.Load<WayPointsStaticData>(StaticDataWayPointsPath);
        }

        public HeroStaticData ForHero() => 
            _hero;
        
        public WayPointsStaticData ForWayPoints() => 
            _wayPoints;
    }
}