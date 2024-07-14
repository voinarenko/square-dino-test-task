using StaticData;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataHeroPath = "StaticData/Hero/HeroData";
        private const string StaticDataWayPointsPath = "StaticData/WayPoints/WayPointsData";
        private const string StaticDataGamePath = "StaticData/Game/GameData";
        private const string StaticDataPlatformsPath = "StaticData/Platforms";
        private const string StaticDataEnemyPath = "StaticData/Enemy/EnemyData";

        private HeroStaticData _hero;
        private WayPointsStaticData _wayPoints;
        private GameStaticData _game;
        private Dictionary<int, PlatformStaticData> _platforms;
        private EnemyStaticData _enemy;

        public void Load()
        {
            _hero = Resources.Load<HeroStaticData>(StaticDataHeroPath);
            _wayPoints = Resources.Load<WayPointsStaticData>(StaticDataWayPointsPath);
            _game = Resources.Load<GameStaticData>(StaticDataGamePath);
            _platforms = Resources
                .LoadAll<PlatformStaticData>(StaticDataPlatformsPath)
                .ToDictionary(x => x.Id, x => x);
            _enemy = Resources.Load<EnemyStaticData>(StaticDataEnemyPath);
        }

        public HeroStaticData ForHero() => 
            _hero;
        
        public WayPointsStaticData ForWayPoints() => 
            _wayPoints;
        
        public GameStaticData ForGame() => 
            _game;
        
        public PlatformStaticData ForPlatform(int id) => 
            _platforms[id];

        public EnemyStaticData ForEnemy() =>
            _enemy;
    }
}