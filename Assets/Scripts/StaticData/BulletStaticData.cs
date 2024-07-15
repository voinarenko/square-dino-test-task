using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "Static/Bullet")]
    public class BulletStaticData : ScriptableObject
    {
        public float Speed;
        public int Damage;
        public GameObject Prefab;
    }
}