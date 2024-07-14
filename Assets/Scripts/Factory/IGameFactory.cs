using Services;

namespace Factory
{
    public interface IGameFactory : IService
    {
        void CreateHero();
    }
}