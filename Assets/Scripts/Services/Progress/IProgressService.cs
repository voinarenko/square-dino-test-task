using Data;
using Logic;
using System;
using UnityEngine;
using View.Hero;

namespace Services.Progress
{
    public interface IProgressService : IService
    {
        event Action GameStarted;
        event Action<int, Transform> PlatformChanged;
        event Action PlatformCleared;
        PlayerProgress Progress { get; set; }
        bool FirstRun { get; set; }
        void SetInputListener(PointerInputListener pointerListener);
        void SetHero(HeroMove move, HeroShoot shoot);
        void Subscribe();
        void Unsubscribe();
    }
}