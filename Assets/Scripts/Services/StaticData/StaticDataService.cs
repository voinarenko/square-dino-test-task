using UnityEngine;

namespace Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataHeroPath = "StaticData/Hero/HeroData";
        private const string StaticDataWayPointsPath = "StaticData/WayPoints/WayPointsData";
        private const string StaticDataGamePath = "StaticData/Game/GameData";

        private HeroStaticData _hero;
        private WayPointsStaticData _wayPoints;
        private GameStaticData _game;

        public void Load()
        {
            _hero = Resources.Load<HeroStaticData>(StaticDataHeroPath);
            _wayPoints = Resources.Load<WayPointsStaticData>(StaticDataWayPointsPath);
            _game = Resources.Load<GameStaticData>(StaticDataGamePath);
        }

        public HeroStaticData ForHero() => 
            _hero;
        
        public WayPointsStaticData ForWayPoints() => 
            _wayPoints;
        
        public GameStaticData ForGame() => 
            _game;
    }
}