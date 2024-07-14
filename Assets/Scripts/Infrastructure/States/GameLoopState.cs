using Factory;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly IGameFactory _factory;

        public GameLoopState(IGameFactory factory) =>
            _factory = factory;

        public void Enter()
        {
        }

        public void Exit()
        {
            // _factory.CleanUpSpawners();
        }
    }
}