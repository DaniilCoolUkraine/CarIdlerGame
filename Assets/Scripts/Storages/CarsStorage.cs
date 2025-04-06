using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SimpleGame.Storages
{
    [CreateAssetMenu(fileName = "CarsStorage", menuName = "Storage/CarsStorage")]
    public class CarsStorage : ScriptableObject
    {
        [PreviewField] public List<GameObject> Cars;
    }
}