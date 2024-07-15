using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "PlatformData", menuName = "Static/Platforms")]
    public class PlatformStaticData : ScriptableObject
    {
        public int Id;
        public List<GameObject> SpawnPoints;
    }
}