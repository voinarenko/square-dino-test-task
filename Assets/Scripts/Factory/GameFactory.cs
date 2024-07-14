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

        public void CreateHero()
        {
            var hero = _staticDataService.ForHero();
            var obj = Object.Instantiate(hero.Prefab);
        }
    }
}