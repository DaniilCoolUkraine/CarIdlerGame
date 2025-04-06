using System;
using SimpleEventBus.SimpleEventBus.Runtime;
using SimpleGame.Events;
using UnityEngine;

namespace SimpleGame.Managers
{
    public class PriceManager : MonoBehaviour
    {
        [SerializeField] private int _startCarPrice = 10;
        [SerializeField] private int _startSpeedPrice = 1;
        [SerializeField] private int _startIncomePrice = 1;
        
        [SerializeField] private float _carPriceScaler;
        [SerializeField] private float _speedPriceScaler;
        [SerializeField] private float _incomePriceScaler;

        [Zenject.Inject] private ScoreManager _scoreManager;

        public int CurrentCarPrice
        {
            get => _currentCarPrice;
            set
            {
                if (_currentCarPrice == value)
                    return;
                
                _currentCarPrice = value;
                GlobalEvents.Publish(new CarPriceChanged(value));
            }
        }
        private int _currentCarPrice;
        
        public int CurrentSpeedPrice
        {
            get => _currentSpeedPrice;
            set
            {
                if (_currentSpeedPrice == value)
                    return;
                
                _currentSpeedPrice = value;
                GlobalEvents.Publish(new SpeedPriceChanged(value));
            }
        }
        private int _currentSpeedPrice;
        
        public int CurrentIncomePrice
        {
            get => _currentIncomePrice;
            set
            {
                if (_currentIncomePrice == value)
                    return;
                
                _currentIncomePrice = value;
                GlobalEvents.Publish(new IncomePriceChanged(value));
            }
        }
        private int _currentIncomePrice;
        
        private void OnEnable()
        {
            GlobalEvents.AddListener<CarRequestedEvent>(OnCarRequested);
            GlobalEvents.AddListener<SpeedRequestedEvent>(OnSpeedRequested);
            GlobalEvents.AddListener<IncomeRequestedEvent>(OnIncomeRequested);
        }

        private void Start()
        {
            CurrentCarPrice = _startCarPrice;
            CurrentSpeedPrice = _startSpeedPrice;
            CurrentIncomePrice = _startIncomePrice;
        }

        private void OnDisable()
        {
            GlobalEvents.RemoveListener<CarRequestedEvent>(OnCarRequested);
        }

        private void OnCarRequested(CarRequestedEvent ev)
        {
            if (_scoreManager.CanAfford(CurrentCarPrice))
            {
                _scoreManager.SubtractScore(CurrentCarPrice);
                CurrentCarPrice += Mathf.Max(1, Mathf.RoundToInt(CurrentCarPrice * _carPriceScaler));

                GlobalEvents.Publish(new SpawnCarEvent());
            }
        }
        
        private void OnSpeedRequested(SpeedRequestedEvent ev)
        {
            if (_scoreManager.CanAfford(CurrentSpeedPrice))
            {
                _scoreManager.SubtractScore(CurrentSpeedPrice);
                CurrentSpeedPrice += Mathf.Max(1, Mathf.RoundToInt(CurrentSpeedPrice * _speedPriceScaler));
                
                GlobalEvents.Publish(new UpgradeSpeedEvent());
            }
        }
        
        private void OnIncomeRequested(IncomeRequestedEvent ev)
        {
            if (_scoreManager.CanAfford(CurrentIncomePrice))
            {
                _scoreManager.SubtractScore(CurrentIncomePrice);
                CurrentIncomePrice += Mathf.Max(1, Mathf.RoundToInt(CurrentIncomePrice * _incomePriceScaler));

                GlobalEvents.Publish(new UpgradeIncomeEvent());
            }
        }
    }
}