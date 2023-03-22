using System.Collections.Generic;
using Buttons;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class SubHorizontalMenuController : MenuManager
    {
        //serialized fields
        [Space(10), Header("Horizontal Menu"), SerializeField]
        private Transform _logoTransform;

        //privates
        private List<MenuHorizontalCardButton> _horizontalCardsButtonList = new List<MenuHorizontalCardButton>();
        private Vector3 _baseLogoPosition;

        private void Awake()
        {
            _baseLogoPosition = _logoTransform.position;
            
            //list
            foreach (MenuButton button in ButtonList)
            {
                _horizontalCardsButtonList.Add(button.GetComponent<MenuHorizontalCardButton>());
            }
        }

        protected override void Update()
        {
            base.Update();
            HandleSelection(InputManager.Instance.Inputs.Left,InputManager.Instance.Inputs.Right);
        }

        public override void ShowMenu()
        {
            base.ShowMenu();
        
            _logoTransform.DOComplete();
            _logoTransform.GetComponent<Image>().DOFade(1, AppearTime);
            _logoTransform.position = _baseLogoPosition;
            
            SetSelected();
        }

        public override void HideMenu()
        {
            base.HideMenu();
        
            _logoTransform.DOComplete();
            _logoTransform.GetComponent<Image>().DOFade(0, DisappearTime);
            _logoTransform.DOMoveX(_baseLogoPosition.x - 10, 1f);
        }

        protected override void SetSelected()
        {
            base.SetSelected();
            _horizontalCardsButtonList.ForEach(x => x.SetUnselected());
            _horizontalCardsButtonList[SelectionIndex].SetSelected();
        }
    }
}