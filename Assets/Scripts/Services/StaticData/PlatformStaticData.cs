using System.Collections.Generic;
using UnityEngine;

namespace Services.StaticData
{
    [CreateAssetMenu(fileName = "PlatformData", menuName = "Static/Platforms")]
    public class PlatformStaticData : ScriptableObject
    {
        public int Id { get; set; }
        public List<GameObject> SpawnPoints { get; set; }
    }
}