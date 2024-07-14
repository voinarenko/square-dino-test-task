using UnityEngine;

namespace Services.StaticData
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Static/Game")]
    public class GameStaticData : ScriptableObject
    {
        public GameObject InputListenerPrefab;
    }
}