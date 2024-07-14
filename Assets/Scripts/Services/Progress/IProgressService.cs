using Data;
using Hero;
using Logic;
using System;
using UnityEngine;

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
        void SetHeroMove(HeroMove move);
        void Subscribe();
    }
}