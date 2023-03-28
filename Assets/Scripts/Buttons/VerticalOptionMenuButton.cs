using DG.Tweening;
using Menu;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Buttons
{
    public class VerticalOptionMenuButton : MenuButton
    {
        [Header("Option Button"), SerializeField] public VerticalSubMenuOption SubMenu;
        [SerializeField] private Image _overlay;
        [SerializeField, TextArea] public string Description;  
            
        public override void SelectButton()
        {
            base.SelectButton();
            SetButton(true);
        }

        public void UnselectButton()
        {
            SetButton(false);
        }

        private void SetButton(bool isActive)
        {
            _overlay.DOKill();
            _overlay.DOFade(isActive ? 1 : 0, 0.1f);
            if (SubMenu != null)
            {
                switch (isActive)
                {
                    case true:
                        SubMenu.ShowMenu();
                        break;
                    case false:
                        SubMenu.HideMenu();
                        break;
                }
            }
        }
    }
}