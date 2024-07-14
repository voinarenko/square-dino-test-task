using Services;

namespace Factory
{
    public interface IGameFactory : IService
    {
        void CreateHero();
        void CreateWaypoints();
        void CleanUp();
        void CreateInputListener();
    }
}