using SimpleEventBus.SimpleEventBus.Runtime;
using SimpleGame.Events;
using SimpleGame.Factories;
using SimpleGame.Storages;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Splines;
using SplineFactory = SimpleGame.Factories.SplineFactory;

namespace SimpleGame.Managers
{
    public class CarsManager : MonoBehaviour
    {
        [SerializeField, Required] private CarsStorage _carsStorage;
        [SerializeField, Required] private SplinesStorage _splinesStorage;

        [SerializeField, Required] private SplineAnimate _carPrefab;
        [SerializeField] private Transform _splinesParent;

        private CarFactory _carFactory;
        private SplineFactory _splineFactory;

        private void OnEnable()
        {
            _carFactory = new CarFactory(transform, _carsStorage, _carPrefab);
            _splineFactory = new SplineFactory(_splinesParent, _splinesStorage);
            
            _splinesParent ??= transform;
            
            GlobalEvents.AddListener<SpawnCarEvent>(OnCarRequested);
        }

        private void OnDisable()
        {
            GlobalEvents.RemoveListener<SpawnCarEvent>(OnCarRequested);
        }

        private void OnCarRequested(SpawnCarEvent obj)
        {
            var spline = _splineFactory.CreateSpline();
            var car = _carFactory.CreateCar(spline);
            car.Play();
        }
    }
}