﻿using System.Collections.Generic;
using Buttons;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Menu
{
    public abstract class MenuManager : MonoBehaviour
    {
        [Header("Menu Manager"), SerializeField] protected MenuAsset MenuAsset;
        [SerializeField] protected float AppearTime = 0.25f;
        [SerializeField] protected float DisappearTime = 0.25f;
        [SerializeField] protected List<MenuButton> ButtonList;
        [SerializeField] protected bool IsActiveAtStart;
        [SerializeField] protected MenuManager MenuToGoBack;
    
        [ReadOnly, SerializeField] protected int SelectionIndex;
        [ReadOnly, SerializeField] public bool HasPressed;
        [ReadOnly, SerializeField] protected bool IsActive;
        private bool _hasPressedEscapeAtStart;

        protected virtual void Start()
        {
            switch (IsActiveAtStart)
            {
                case true:
                    ShowMenu();
                    break;
                case false:
                    HideMenu();
                    break;
            }
            //complete
            MenuAsset.MenuImagesList.ForEach(x => x.DOComplete());
            MenuAsset.MenuTextList.ForEach(x => x.DOComplete());
        }

        protected virtual void Update()
        {
            if (IsActive)
            {
                HandleGoBack();
            }
        }

        private void HandleGoBack()
        {
            if (InputManager.Instance.Inputs.GoBack == false)
            {
                _hasPressedEscapeAtStart = false;
            }

            if (InputManager.Instance.Inputs.GoBack && _hasPressedEscapeAtStart == false && MenuToGoBack != null)
            {
                HideMenu();
                MenuToGoBack.ShowMenu();
                _hasPressedEscapeAtStart = true;
            }
        }

        public virtual void ShowMenu()
        {
            //escape
            _hasPressedEscapeAtStart = InputManager.Instance.Inputs.GoBack;

            //set fade to 0
            MenuAsset.MenuImagesList.ForEach(x => x.DOFade(0,0));
            MenuAsset.MenuImagesList.ForEach(x => x.DOComplete());
            MenuAsset.MenuTextList.ForEach(x => x.DOFade(0,0));
            MenuAsset.MenuTextList.ForEach(x => x.DOComplete());
        
            //fade to 1
            MenuAsset.MenuImagesList.ForEach(x => x.DOFade(1,AppearTime * Random.Range(0.5f,2f)));
            MenuAsset.MenuTextList.ForEach(x => x.DOFade(1,AppearTime * Random.Range(0.5f,2f)));
            IsActive = true;
        }

        public virtual void HideMenu()
        {
            //complete
            MenuAsset.MenuImagesList.ForEach(x => x.DOComplete());
            MenuAsset.MenuTextList.ForEach(x => x.DOComplete());

            //fade to 0
            MenuAsset.MenuImagesList.ForEach(x => x.DOFade(0,DisappearTime * Random.Range(0.5f,2f)));
            MenuAsset.MenuTextList.ForEach(x => x.DOFade(0,DisappearTime * Random.Range(0.5f,2f)));
            IsActive = false;
        }

        private void NextButton()
        {
            if (SelectionIndex < ButtonList.Count - 1)
            {
                HasPressed = true;
                SelectionIndex++;
            }
        }
    
        private void PreviousButton()
        {
            if (SelectionIndex > 0)
            {
                HasPressed = true;
                SelectionIndex--;
            }
        }
    
        protected void HandleSelection(bool previous, bool next)
        {
            if (IsActive == false)
            {
                return;
            }
        
            Input input = InputManager.Instance.Inputs;
        
            if (HasPressed)
            {
                if (input is { Down: false, Up: false, Right: false, Left: false, Select: false })
                {
                    HasPressed = false;
                }
                return;
            }

            int selection = SelectionIndex;
            
            if (previous)
            {
                PreviousButton();
            }
            if (next)
            {
                NextButton();
            }
        
            if (input.Select)
            {
                HasPressed = true;
                ButtonList[SelectionIndex].Select();
            }

            if (selection != SelectionIndex)
            {
                SetSelected();
            }
        }

        protected virtual void SetSelected()
        {
        
        }
    }
}