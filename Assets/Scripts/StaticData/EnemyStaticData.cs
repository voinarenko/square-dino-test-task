using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Static/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public int Health;
        public GameObject Prefab;
    }
}