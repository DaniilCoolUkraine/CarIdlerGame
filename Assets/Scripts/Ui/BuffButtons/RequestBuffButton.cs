using SimpleEventBus.SimpleEventBus.Runtime;
using SimpleGame.Events;
using SimpleGame.Managers;
using SimpleGame.Ui.Popups;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SimpleGame.Ui.BuffButtons
{
    public class RequestBuffButton <T, K> : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
        where T : IEvent, new() where K : PriceChanged
    {
        [SerializeField, Required] private Button _button;
        [SerializeField, Required] private Image _icon;
        [SerializeField, Required] private PopupData _hoveredPopupData;
        
        [SerializeField] private Color _inactiveColor;
        
        [Zenject.Inject] private ScoreManager _scoreManager;
        [Zenject.Inject] private IPopupManager _popupManager;
        
        private int _price;
        private bool _isFirstEvent = true;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);

            GlobalEvents.AddListener<ScoreChangedEvent>(OnScoreChanged);
            GlobalEvents.AddListener<K>(OnPriceChanged);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);

            GlobalEvents.RemoveListener<ScoreChangedEvent>(OnScoreChanged);
            GlobalEvents.RemoveListener<K>(OnPriceChanged);
        }

        private void OnButtonClick()
        {
            GlobalEvents.Publish<T>(new T());
        }
        
        private void OnScoreChanged(ScoreChangedEvent ev)
        {
            if (_isFirstEvent)
            {
                _isFirstEvent = false;
                return;
            }

            var canAfford = _scoreManager.CanAfford(_price);
            _button.interactable = canAfford;
            _icon.color = canAfford ? Color.white : _inactiveColor;
        }

        private void OnPriceChanged(K ev)
        {
            _price = ev.Price;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _popupManager.OpenPopup(_hoveredPopupData, _price);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _popupManager.ClosePopup();
        }
    }
}