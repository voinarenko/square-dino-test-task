using UnityEngine;

namespace Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameBootstrapper _prefab;

        private void Awake()
        {
            var bootstrapper = FindAnyObjectByType<GameBootstrapper>();

            if (bootstrapper == null) 
                Instantiate(_prefab);
        }
    }
}