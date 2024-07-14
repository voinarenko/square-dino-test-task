using System;
using UnityEngine;

namespace Logic
{
    public class WayPointTrigger : MonoBehaviour
    {
        public event Action<WayPointTrigger> Reached;
        private bool _collided;
        
        private void Awake() => 
            _collided = false;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Constants.PlayerTag)) 
                return;
            if (_collided) 
                return;
            _collided = true;
            Reached?.Invoke(this);
        }
    }
}