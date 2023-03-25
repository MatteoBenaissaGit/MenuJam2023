using System;
using System.Collections.Generic;
using Buttons;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class MainMenuVerticalController : MenuManager
    {
        //serialized fields
        [Space(10), Header("Vertical Menu"), SerializeField]
        private Image _logo; 
        [SerializeField] 
        private RectTransform _selectLine;
        [SerializeField] 
        private float _selectLineHeightChange;
        [Header("Text"), SerializeField] 
        private Color _baseColor;
        [SerializeField] 
        private Color _selectedColor;
        [Header("Enter"), SerializeField] 
        private Image _enterImage;
        [SerializeField] 
        private TMP_Text _enterText;

        //privates
        private List<MenuVerticalButtonTextController> _verticalButtonsTextList = new List<MenuVerticalButtonTextController>();
        private Vector3 _selectLineBasePosition;

        private void Awake()
        {
            //list
            foreach (MenuButton button in ButtonList)
            {
                _verticalButtonsTextList.Add(button.GetComponent<MenuVerticalButtonTextController>());
            }
        }

        protected override void Start()
        {
            base.Start();
            
            IsActive = true;
            _selectLineBasePosition = _selectLine.anchoredPosition;
            SetSelected();
        }

        protected override void Update()
        {
            base.Update();

            if (IsActive)
            {
                HandleSelection(InputManager.Instance.Inputs.Up,InputManager.Instance.Inputs.Down);
            }
        }

        protected override void SetSelected()
        {
            //text
            //_verticalButtonsTextList.ForEach(x => x.Text.color = _baseColor);
            foreach (var button in _verticalButtonsTextList)
            {
                button.Text.color = _baseColor;
            }
            _verticalButtonsTextList[SelectionIndex].Text.color = _selectedColor;
        
            //line
            float height = _selectLineBasePosition.y - _selectLineHeightChange * SelectionIndex;
            _selectLine.anchoredPosition = new Vector3(_selectLineBasePosition.x, height, _selectLineBasePosition.z);
        }
    
        public override void ShowMenu()
        {
            base.ShowMenu();
            SetActiveEnter();
            _logo.DOFade(1, AppearTime * 2);
            
            //all menus manager
            AllMenusManager.Instance.CurrentMenu = this;
        }

        public override void HideMenu()
        {
            print("hide");
            base.HideMenu();
            _logo.DOFade(0, DisappearTime * 2).OnComplete(SetActiveEnter);
        }

        private void SetActiveEnter()
        {
            bool active = _enterImage.gameObject.activeInHierarchy == false;
            _enterImage.gameObject.SetActive(active);
            _enterText.gameObject.SetActive(active);
        }
    }
}
