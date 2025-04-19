namespace SimpleGame.Ui.Popups
{
    public interface IPopupManager
    {
        public void OpenPopup(PopupData popupData, int price);
        public void ClosePopup();
    }
}