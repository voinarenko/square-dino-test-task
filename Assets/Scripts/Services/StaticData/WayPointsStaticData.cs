using System.Collections.Generic;
using UnityEngine;

namespace Services.StaticData
{
    [CreateAssetMenu(fileName = "WayPointsData", menuName = "Static/WayPoints/WayPointsData")]
    public class WayPointsStaticData : ScriptableObject
    {
        public List<GameObject> WayPoints;
    }
}