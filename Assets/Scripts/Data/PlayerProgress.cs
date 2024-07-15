using System;
using UnityEngine;

namespace Data
{
    public class PlayerProgress
    {
        public event Action<int> EnemiesChanged; 
        
        public WayPoints WayPoints { get; set; } = new();

        public int CurrentPlatform
        {
            get => _currentPlatform;
            set
            {
                _currentPlatform = value;
                Debug.Log($"Current platform: {_currentPlatform}");
            }
        }

        public int EnemiesLeft
        {
            get => _enemiesLeft;
            set
            {
                if (_enemiesLeft != value)
                {
                    _enemiesLeft = value;
                    EnemiesChanged?.Invoke(_enemiesLeft);
                }
            }
        }

        private int _enemiesLeft;
        private int _currentPlatform;
    }
}