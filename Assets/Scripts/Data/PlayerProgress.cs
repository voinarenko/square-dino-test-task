using Hero;
using Logic;
using System;

namespace Data
{
    public class PlayerProgress
    {
        public event Action GameStarted;
        public event Action PlatformCleared;

        public WayPoints WayPoints { get; set; } = new();
        private int _currentPlatform;

        private PointerInputListener _pointerListener;
        private HeroMove _heroMove;
        private bool _firstRun = true;

        public void SetInputListener(PointerInputListener pointerListener)
        {
            _pointerListener = pointerListener;
            _pointerListener.Clicked += OnClicked;
        }

        public void SetHeroMove(HeroMove move)
        {
            _heroMove = move;
            _heroMove.Arrived += OnArrived;
        }

        private void OnClicked()
        {
            if (_firstRun)
            {
                _firstRun = false;
                GameStarted?.Invoke();
                _pointerListener.gameObject.SetActive(false);
            }
        }

        private void OnArrived()
        {
            //_currentPlatform++;
            if (WayPoints.Left.Count > 0) PlatformCleared?.Invoke();
        }
    }
}