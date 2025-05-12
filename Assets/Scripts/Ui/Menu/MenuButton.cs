using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleGame.Ui.Menu
{
    public class MenuButton : MonoBehaviour
    {
        [SerializeField, Required] private Button _button;
        [SerializeField, Required] private CanvasGroup _menuGroup;
        
        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _menuGroup.gameObject.SetActive(!_menuGroup.gameObject.activeSelf);
        }
    }
}