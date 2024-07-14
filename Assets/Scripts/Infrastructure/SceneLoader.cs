using Cysharp.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class SceneLoader
    {
        public async UniTask Load(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
                onLoaded?.Invoke();
            else
            {
                var waitNextScene = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);

                while (!waitNextScene!.isDone) 
                    await UniTask.NextFrame();

                onLoaded?.Invoke();
            }
        }
    }
}