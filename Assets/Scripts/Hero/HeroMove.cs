using Logic;
using Services.Progress;
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

        private IProgressService _progressService;

        public void Construct(IProgressService progressService)
        {
            _progressService = progressService;
            _progressService.GameStarted += Run;
            _progressService.PlatformCleared += Continue;
        }

        private void Run()
        {
            _progressService.GameStarted -= Run;
            _progressService.Progress.WayPoints.Left.Remove(_progressService.Progress.WayPoints.Left[0]);
            Continue();
        }

        private void Continue()
        {
            _progressService.Progress.WayPoints.Left[0].TryGetComponent<WayPointTrigger>(out var trigger);
            trigger.Reached += OnReached;
            MoveToDestination(_progressService.Progress.WayPoints.Left[0].position);
            _animate.PlayRun();
        }
        
        private void MoveToDestination(Vector3 destination) =>
            _agent.SetDestination(destination);

        private void OnReached(WayPointTrigger trigger)
        {
            trigger.Reached -= OnReached;
            _progressService.Progress.WayPoints.Left.Remove(trigger.transform);
            _animate.PlayIdle();
            Arrived?.Invoke();
        }
    }
}