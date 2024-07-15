using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtain;

        private void Awake() =>
            DontDestroyOnLoad(this);

        public void Show()
        {
            gameObject.SetActive(true);
            _curtain.alpha = 1;
        }

        public async UniTaskVoid Hide()
        {
            while (_curtain.alpha > 0)
            {
                _curtain.alpha -= 0.03f;
                await UniTask.WaitForSeconds(0.03f);
            }
            
            gameObject.SetActive(false);
        }
    }
}