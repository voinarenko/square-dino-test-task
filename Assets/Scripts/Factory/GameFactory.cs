using Infrastructure.States;
using Services.Progress;
using Services.StaticData;
using UnityEngine;

namespace Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IProgressService _progressService;
        private readonly GameStateMachine _stateMachine;

        public GameFactory(IStaticDataService staticDataService, IProgressService progressService, GameStateMachine stateMachine)
        {
            _staticDataService = staticDataService;
            _progressService = progressService;
            _stateMachine = stateMachine;
        }

        public void CreateWaypoints()
        {
            var data = _staticDataService.ForWayPoints();
            foreach (var wayPoint in data.WayPoints) 
                _progressService.Progress.WayPoints.WayPointsLeft.Add(Object.Instantiate(wayPoint).transform);
        }
        
        public void CreateHero()
        {
            var data = _staticDataService.ForHero();
            var points = _progressService.Progress.WayPoints.WayPointsLeft;
            var obj = Object.Instantiate(data.Prefab, points[0].transform.position, Quaternion.identity);
        }
    }
}