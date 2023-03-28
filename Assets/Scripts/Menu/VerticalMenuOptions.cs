using System.Collections.Generic;
using Buttons;
using TMPro;
using UnityEngine;

namespace Menu
{
    public class VerticalMenuOptions : MenuManager
    {
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private List<GameObject> _gameObjetsToDeactivate = new List<GameObject>();
        [SerializeField] private List<VerticalSubMenuOption> _subMenus = new List<VerticalSubMenuOption>();
        
        private List<VerticalOptionMenuButton> _buttonList = new List<VerticalOptionMenuButton>();

        private void Awake()
        {
            //list
            _buttonList.Clear();
            foreach (MenuButton button in ButtonList)
            {
                _buttonList.Add(button.GetComponent<VerticalOptionMenuButton>());
            }

            foreach (VerticalSubMenuOption subMenu in _subMenus)
            {
                subMenu.MenuAsset.MenuImagesList.ForEach(x => MenuAsset.MenuImagesList.Add(x));
                subMenu.MenuAsset.MenuTextList.ForEach(x => MenuAsset.MenuTextList.Add(x));
            }
        }
        
        protected override void Update()
        {
            base.Update();
            if (IsActive)
            {
                HandleSelection(InputManager.Instance.Inputs.Up,InputManager.Instance.Inputs.Down);
            }
        }

        public override void ShowMenu()
        {
            base.ShowMenu();
            
            AllMenusManager.Instance.CurrentMenu = this;
            
            _gameObjetsToDeactivate.ForEach(x => x.SetActive(false));
            
            SetSelected();
        }

        public override void HideMenu()
        {
            base.HideMenu();            
            _gameObjetsToDeactivate.ForEach(x => x.SetActive(true));
        }

        protected override void SetSelected()
        {
            base.SetSelected();
            _buttonList.ForEach(x => x.UnselectButton());
            
            _buttonList[SelectionIndex].SelectButton();
            _descriptionText.text = _buttonList[SelectionIndex].Description;
        }
    }
}
