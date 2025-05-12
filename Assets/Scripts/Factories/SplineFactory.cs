using SimpleGame.Storages;
using UnityEngine;
using UnityEngine.Splines;

namespace SimpleGame.Factories
{
    public class SplineFactory
    {
        private Transform _spawnPoint;
        private SplinesStorage _splinesStorage;

        public SplineFactory(Transform spawnPoint, SplinesStorage splinesStorage)
        {
            _spawnPoint = spawnPoint;
            _splinesStorage = splinesStorage;
        }

        public SplineContainer CreateSpline()
        { 
            var spline = Object.Instantiate(_splinesStorage.Splines[Random.Range(0, _splinesStorage.Splines.Count)], _spawnPoint);
            // spline.transform.localScale = Vector3.one * Random.Range(0.9f, 1.2f);
            return spline;
        }
    }
}