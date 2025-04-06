using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace SimpleGame.Storages
{
    [CreateAssetMenu(fileName = "SplinesStorage", menuName = "Storage/SplinesStorage")]
    public class SplinesStorage : ScriptableObject
    {
        public List<SplineContainer> Splines;
    }
}