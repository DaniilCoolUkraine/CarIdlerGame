using SimpleGame.Storages;
using UnityEngine;
using UnityEngine.Splines;

namespace SimpleGame.Factories
{
    public class CarFactory
    {
        private Transform _spawnPoint;

        private SplineAnimate _carPrefab;
        private CarsStorage _carsStorage;

        public CarFactory(Transform spawnPoint, CarsStorage carsStorage, SplineAnimate carPrefab)
        {
            _spawnPoint = spawnPoint;
            _carsStorage = carsStorage;
            _carPrefab = carPrefab;
        }

        public SplineAnimate CreateCar(SplineContainer container)
        {
            var car = Object.Instantiate(_carPrefab, _spawnPoint);
            var model = Object.Instantiate(_carsStorage.Cars[Random.Range(0, _carsStorage.Cars.Count)], car.transform);

            car.Container = container;

            return car;
        }
    }
}