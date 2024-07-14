﻿using Cysharp.Threading.Tasks;
using Factory;
using Logic;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(
            GameStateMachine stateMachine,
            SceneLoader sceneLoader,
            LoadingCurtain loadingCurtain,
            IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded).Forget();
        }

        public void Exit()
        {

        }

        private void OnLoaded()
        {
            _loadingCurtain.Hide().Forget();
            _gameFactory.CreateInputListener();
            _gameFactory.CreateWaypoints();
            _gameFactory.CreateHero();
            _stateMachine.Enter<GameLoopState>();
        }
    }
}