using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace SimpleGame.Ui.Popups
{
    public class PopupManager : MonoBehaviour, IPopupManager
    {
        [SerializeField, Required] private RectTransform _popupContainer;
        [SerializeField, Required] private TextMeshProUGUI _text;

        [Header("Text properties")] 
        [SerializeField] private int _headerSize = 48;
        [SerializeField] private int _descriptionSize = 32;
        [SerializeField] private int _priceSize = 32;

        [Header("Text colors")]
        [SerializeField] private Color _headerColor = Color.white;
        [SerializeField] private Color _descriptionColor = Color.white;
        [SerializeField] private Color _priceColor = Color.white;

        public void OpenPopup(PopupData popupData, int price)
        {
            _popupContainer.gameObject.SetActive(true);
            
            _text.text = $"<size={_headerSize}><color=#{ColorUtility.ToHtmlStringRGB(_headerColor)}>{popupData.Title}</color></size>\n" +
                         $"<size={_descriptionSize}><color=#{ColorUtility.ToHtmlStringRGB(_descriptionColor)}>{popupData.Description}</color></size>\n\n" +
                         $"<size={_priceSize}><color=#{ColorUtility.ToHtmlStringRGB(_priceColor)}>Price: {price}</color></size>";
        }

        public void ClosePopup()
        {
            _popupContainer.gameObject.SetActive(false);
        }
    }
}