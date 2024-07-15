using Infrastructure.States;
using Logic;
using Services;

namespace Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(LoadingCurtain loadingCurtain) =>
            StateMachine = new GameStateMachine(new SceneLoader(), loadingCurtain, AllServices.Container);
    }
}