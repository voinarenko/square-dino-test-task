using Data;
using Logic;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class HeroMove : MonoBehaviour
    {
        public event Action Arrived;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private HeroAnimate _animate;

        private PlayerProgress _progress;

        public void Construct(PlayerProgress progress)
        {
            _progress = progress;
            _progress.GameStarted += Run;
            _progress.PlatformCleared += Continue;
        }

        private void Run()
        {
            _progress.GameStarted -= Run;
            _progress.WayPoints.Left.Remove(_progress.WayPoints.Left[0]);
            Continue();
        }

        private void Continue()
        {
            _progress.WayPoints.Left[0].TryGetComponent<WayPointTrigger>(out var trigger);
            trigger.Reached += OnReached;
            MoveToDestination(_progress.WayPoints.Left[0].position);
            _animate.PlayRun();
        }
        
        private void MoveToDestination(Vector3 destination) =>
            _agent.SetDestination(destination);

        private void OnReached(WayPointTrigger trigger)
        {
            trigger.Reached -= OnReached;
            _progress.WayPoints.Left.Remove(trigger.transform);
            _animate.PlayIdle();
            Arrived?.Invoke();
        }
    }
}