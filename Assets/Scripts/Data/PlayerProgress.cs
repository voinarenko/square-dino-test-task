using Logic;
using System;
using UnityEngine;

namespace Data
{
    public class PlayerProgress
    {
        public event Action GameStarted;
        public event Action PlatformCleared;

        public WayPoints WayPoints { get; set; } = new();
        public int CurrentPlatform { get; set; } = 0;

        private PointerInputListener _pointerListener;
        private bool _firstRun = true;

        public void SetInputListener(PointerInputListener pointerListener)
        {
            _pointerListener = pointerListener;
            _pointerListener.Clicked += OnClicked;
        }

        private void OnClicked()
        {
            if (_firstRun)
            {
                _firstRun = false;
                GameStarted?.Invoke();
            }
            
        }
    }
}