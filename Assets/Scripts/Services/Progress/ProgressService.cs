using Data;
using Infrastructure.States;
using Logic;
using System;
using UnityEngine;
using View.Hero;

namespace Services.Progress
{
    public class ProgressService : IProgressService
    {
        public event Action GameStarted;
        public event Action<int, Transform> PlatformChanged;
        public event Action PlatformCleared;
        public PlayerProgress Progress { get; set; }
        public bool FirstRun { get; set; } = true;

        private readonly GameStateMachine _stateMachine;

        private PointerInputListener _pointerListener;
        private HeroMove _heroMove;
        private HeroShoot _heroShoot;

        public ProgressService(GameStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        public void Subscribe() =>
            Progress.EnemiesChanged += OnEnemiesChanged;

        public void Unsubscribe()
        {
            Progress.EnemiesChanged -= OnEnemiesChanged;
            _pointerListener.Clicked -= OnClicked;
            _heroMove.Arrived -= OnArrived;
        }
        
        public void SetInputListener(PointerInputListener pointerListener)
        {
            _pointerListener = pointerListener;
            _pointerListener.Clicked += OnClicked;
        }

        public void SetHero(HeroMove move, HeroShoot shoot)
        {
            _heroMove = move;
            _heroMove.Arrived += OnArrived;
            _heroShoot = shoot;
        }

        private void OnClicked()
        {
            if (!FirstRun) 
                return;
            
            FirstRun = false;
            GameStarted?.Invoke();
            _pointerListener.gameObject.SetActive(false);
            _pointerListener.HideMessage();
        }

        private void OnArrived()
        {
            Progress.CurrentPlatform++;
            if (Progress.WayPoints.Left.Count > 0)
                PlatformChanged?.Invoke(Progress.CurrentPlatform, _heroMove.transform);
            else
                _stateMachine.Enter<InitProgressState>();
        }

        private void OnEnemiesChanged(int enemies)
        {
            if (enemies > 0) 
                return;
            PlatformCleared?.Invoke();
        }
    }
}