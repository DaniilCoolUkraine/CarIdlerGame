using SimpleEventBus.SimpleEventBus.Runtime;
using SimpleGame.Events;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace SimpleGame.Ui
{
    public class ScoreUi : MonoBehaviour
    {
        [SerializeField, Required] private TextMeshProUGUI _scoreText;

        private void OnEnable()
        {
            GlobalEvents.AddListener<ScoreChangedEvent>(OnScoreChanged);
        }

        private void OnDisable()
        {
            GlobalEvents.RemoveListener<ScoreChangedEvent>(OnScoreChanged);
        }

        private void OnScoreChanged(ScoreChangedEvent ev)
        {
            _scoreText.text = ev.Score.ToString();
        }
    }
}
