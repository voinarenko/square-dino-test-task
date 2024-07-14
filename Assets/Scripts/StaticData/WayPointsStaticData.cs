using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "WayPointsData", menuName = "Static/WayPoints")]
    public class WayPointsStaticData : ScriptableObject
    {
        public List<GameObject> WayPoints;
    }
}