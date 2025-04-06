using SimpleEventBus.SimpleEventBus.Runtime;
using SimpleGame.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleGame.Ui.BuffButtons
{
    public class RequestBuffButton <T, K> : MonoBehaviour where T : IEvent, new() where K : PriceChanged
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _priceText;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
            
            GlobalEvents.AddListener<SpawnCarEvent>(OnCarSpawned);
            GlobalEvents.AddListener<K>(OnPriceChanged);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
            
            GlobalEvents.RemoveListener<SpawnCarEvent>(OnCarSpawned);
            GlobalEvents.RemoveListener<K>(OnPriceChanged);
        }

        private void OnButtonClick()
        {
            GlobalEvents.Publish<T>(new T());
        }
        
        private void OnCarSpawned(SpawnCarEvent ev)
        {
            _button.interactable = true;
        }
        
        private void OnPriceChanged(K ev)
        {
            _priceText.text = ev.Price.ToString();
        }
    }
}