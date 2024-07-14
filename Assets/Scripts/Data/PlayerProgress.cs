﻿using System;

namespace Data
{
    public class PlayerProgress
    {
        public event Action<int> EnemiesChanged; 
        
        public WayPoints WayPoints { get; set; } = new();
        public int CurrentPlatform { get; set; }

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
    }
}