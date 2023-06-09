﻿using System;
using System.Collections.Generic;
using Buttons;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class DownBarMenu : MenuManager
    {
        [Header("DownBar"), SerializeField] private List<Image> _imagesToFadeOut;
        [SerializeField] private List<TMP_Text> _textsToFadeOut;
        [SerializeField] private Transform _bigBar;
        [SerializeField] private Transform _littleBar;
        [SerializeField] private Image _blackBackground;

        //privates
        private List<MenuOverlayButton> _horizontalButtonList = new List<MenuOverlayButton>();
        private Vector3 _baseBigScale;
        private Vector3 _baseLittleScale;
        private bool _reshowEnter;
        private bool _newMenuIsLoaded;
        
        private void Awake()
        {
            //list
            foreach (MenuButton button in ButtonList)
            {
                _horizontalButtonList.Add(button.GetComponent<MenuOverlayButton>());
            }
            _baseBigScale = _bigBar.transform.localScale;
            _baseLittleScale = _littleBar.transform.localScale;
        }

        protected override void Start()
        {
            base.Start();
            //complete
            MenuAsset.MenuImagesList.ForEach(x => x.DOComplete());
            MenuAsset.MenuTextList.ForEach(x => x.DOComplete());

            //fade to 0
            MenuAsset.MenuImagesList.ForEach(x => x.DOFade(0,DisappearTime));
            MenuAsset.MenuTextList.ForEach(x => x.DOFade(0,DisappearTime));
            
            //button events
            ButtonList.ForEach(x => x.OnNewMenuLoad.AddListener(SetNewMenuLoad));
        }

        protected override void Update()
        {
            base.Update();

            if (HasPressed)
            {
                CheckPressed();
                return;
            }

            if (InputManager.Instance.Inputs.DownMenu && HasPressed == false && 
                AllMenusManager.Instance.IsLittleBarShown && AllMenusManager.Instance.IsAccountMenuShown == false) 
            {
                if (IsActive)
                {
                    HideMenu();
                    AllMenusManager.Instance.CurrentMenu.HasPressed = true;
                    AllMenusManager.Instance.CurrentMenu.IsActive = true;
                }
                else
                {
                    ShowMenu();
                    AllMenusManager.Instance.CurrentMenu.IsActive = false;
                }
                HasPressed = true;
            }

            if (IsActive)
            {
                HandleSelection(InputManager.Instance.Inputs.Left,InputManager.Instance.Inputs.Right);
            }
        }

        public override void ShowMenu()
        {
            base.ShowMenu();

            if (AllMenusManager.Instance.CurrentMenu != null)
            {
                AllMenusManager.Instance.CurrentMenu.IsActive = false;
            }
            
            HasPressed = true;
            
            //scale menu
            _bigBar.DOComplete();
            _bigBar.transform.localScale *= 0.5f;
            _bigBar.DOScale(_baseBigScale, 0.5f);
            _littleBar.DOComplete();
            _littleBar.transform.localScale = _baseLittleScale;
            _littleBar.DOScale(_baseLittleScale * 2f, 0.5f);
            
            //fade
            _imagesToFadeOut.ForEach(x => x.DOComplete());
            _imagesToFadeOut.ForEach(x => x.DOFade(0,0.5f));
            _textsToFadeOut.ForEach(x => x.DOComplete());
            _textsToFadeOut.ForEach(x => x.DOFade(0,0.5f));
            _blackBackground.DOFade(0.6f, 0.5f);
            
            SetSelected();
        }

        public override void HideMenu()
        {
            base.HideMenu();

            if (AllMenusManager.Instance.CurrentMenu != null && _newMenuIsLoaded == false)
            {
                AllMenusManager.Instance.CurrentMenu.IsActive = true;
            }
            else
            {
                AllMenusManager.Instance.CurrentMenu.HideMenu();
                SetLittleMenu(false);
                _newMenuIsLoaded = false;
            }
            
            //scale menu
            _bigBar.DOComplete();
            _bigBar.transform.localScale = _baseBigScale;
            _bigBar.DOScale(_baseBigScale * 0.5f, 0.5f);
            _littleBar.DOComplete();
            _littleBar.transform.localScale = _baseLittleScale * 2f;
            _littleBar.DOScale(_baseLittleScale, 0.5f);
            
            //fade
            _imagesToFadeOut.ForEach(x => x.DOComplete());
            _imagesToFadeOut.ForEach(x => x.DOFade(1,0.5f));
            _textsToFadeOut.ForEach(x => x.DOComplete());
            _textsToFadeOut.ForEach(x => x.DOFade(1,0.5f));
            _blackBackground.DOFade(0f, 0.5f);
        }

        protected override void SetSelected()
        {
            base.SetSelected();
            _horizontalButtonList.ForEach(x => x.SetUnselected());
            _horizontalButtonList[SelectionIndex].SetSelected();
        }

        private void SetNewMenuLoad()
        {
            Debug.Log("Set new menu load");
            _newMenuIsLoaded = true;
        }

        public void SetLittleMenu(bool isActive)
        {
            _littleBar.gameObject.SetActive(isActive);
            AllMenusManager.Instance.IsLittleBarShown = isActive;
        }
    }
}