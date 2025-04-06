using SimpleEventBus.SimpleEventBus.Runtime;
using SimpleGame.Events;
using UnityEngine;

namespace SimpleGame.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public int Score
        {
            get => _score;
            set
            {
                if (_score == value)
                    return;
                
                _score = value;
                GlobalEvents.Publish(new ScoreChangedEvent
                {
                    Score = _score
                });
            }
        }
        private int _score;

        private int _scoreMultiplier = 1;
        
        private void Start()
        {
            Score = 10;
        }

        private void OnEnable()
        {
            GlobalEvents.AddListener<GatesPassedEvent>(OnGatesPassed);
            GlobalEvents.AddListener<UpgradeIncomeEvent>(OnUpgradeIncome);
        }

        private void OnDisable()
        {
            GlobalEvents.RemoveListener<GatesPassedEvent>(OnGatesPassed);
            GlobalEvents.RemoveListener<UpgradeIncomeEvent>(OnUpgradeIncome);
        }

        public bool CanAfford(int score)
        {
            return _score >= score;
        }

        public void SubtractScore(int score)
        {
            Score -= score;
        }

        private void OnGatesPassed(GatesPassedEvent ev)
        {
            Score += _scoreMultiplier;
        }
        
        private void OnUpgradeIncome(UpgradeIncomeEvent ev)
        {
            _scoreMultiplier++;
        }
    }
}