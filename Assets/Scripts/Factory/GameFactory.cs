using Cinemachine;
using Hero;
using Infrastructure.States;
using Logic;
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

        public GameFactory(IStaticDataService staticDataService, IProgressService progressService,
            GameStateMachine stateMachine)
        {
            _staticDataService = staticDataService;
            _progressService = progressService;
            _stateMachine = stateMachine;
        }

        public void CreateInputListener()
        {
            var data = _staticDataService.ForGame();
            var obj = Object.Instantiate(data.InputListenerPrefab);
            obj.TryGetComponent<PointerInputListener>(out var listener);
            _progressService.Progress.SetInputListener(listener);
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
            move.Construct(_progressService.Progress);
            _progressService.Progress.SetHeroMove(move);
            FollowCamera(obj.transform);
        }

        public void CleanUp()
        {
            _progressService.Progress.WayPoints.Left.Clear();
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