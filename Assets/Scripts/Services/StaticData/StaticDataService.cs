using UnityEngine;

namespace Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataHeroPath = "StaticData/Hero/HeroData";

        private HeroStaticData _hero;

        public void Load()
        {
            _hero = Resources.Load<HeroStaticData>(StaticDataHeroPath);
        }

        public HeroStaticData ForHero() => 
            _hero;
    }
}