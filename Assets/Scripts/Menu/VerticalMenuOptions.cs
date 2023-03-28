using System.Collections.Generic;
using Buttons;
using TMPro;
using UnityEngine;

namespace Menu
{
    public class VerticalMenuOptions : MenuManager
    {
        [SerializeField] private TMP_Text _descriptionText;
        
        private List<VerticalOptionMenuButton> _buttonList = new List<VerticalOptionMenuButton>();

        private void Awake()
        {
            //list
            foreach (MenuButton button in ButtonList)
            {
                _buttonList.Add(button.GetComponent<VerticalOptionMenuButton>());
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
            
            SetSelected();
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
