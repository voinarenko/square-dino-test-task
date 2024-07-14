using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "Static/Hero")]
    public class HeroStaticData : ScriptableObject
    {
        public float MoveSpeed;
        public float RotateSpeed;
        public float ShootDelay;
        public GameObject Prefab;
    }
}