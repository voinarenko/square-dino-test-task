using Data;
using Logic;
using Services.Progress;

namespace Infrastructure.States
{
    public class InitProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IProgressService _progressService;

        public InitProgressState(
            GameStateMachine stateMachine, 
            IProgressService progressService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
        }

        public void Enter()
        {
            _progressService.Progress = new PlayerProgress();
            _progressService.Subscribe();
            _stateMachine.Enter<LoadLevelState, string>(Constants.Main);
        }

        public void Exit()
        {

        }
    }
}