using Cysharp.Threading.Tasks;
using Factory;
using Logic;
using Services;
using Services.Progress;
using Services.StaticData;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            RegisterServices();
        }

        public void Enter() =>
            _sceneLoader.Load(Constants.Initial, EnterInitProgress).Forget();

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            RegisterStaticData();
            _services.RegisterSingle<IProgressService>(new ProgressService(_stateMachine));
            _services.RegisterSingle<IGameFactory>(new GameFactory(
                    _services.Single<IStaticDataService>(), 
                    _services.Single<IProgressService>()));
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);
        }
        
        private void EnterInitProgress() =>
            _stateMachine.Enter<InitProgressState>();
    }
}