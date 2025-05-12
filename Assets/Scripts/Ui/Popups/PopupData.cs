using UnityEngine;

namespace SimpleGame.Ui.Popups
{
    [CreateAssetMenu(menuName = "PopupData", fileName = "PopupData", order = 0)]
    public class PopupData : ScriptableObject
    {
        public string Title;
        [TextArea] public string Description;
    }
}