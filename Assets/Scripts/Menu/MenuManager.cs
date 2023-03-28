using System.Collections.Generic;
using Buttons;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Menu
{
    public abstract class MenuManager : MonoBehaviour
    {
        [Header("Menu Manager"), SerializeField] public MenuAsset MenuAsset;
        [SerializeField] protected float AppearTime = 0.25f;
        [SerializeField] protected float DisappearTime = 0.25f;
        [SerializeField] protected List<MenuButton> ButtonList;
        [SerializeField] protected bool IsActiveAtStart;
        [SerializeField] protected MenuManager MenuToGoBack;
        [SerializeField] protected CinemachineVirtualCamera CameraToSet;
    
        [ReadOnly, SerializeField] protected int SelectionIndex;
        [ReadOnly, SerializeField] public bool HasPressed;
        [ReadOnly, SerializeField] public bool IsActive;
        [ReadOnly, SerializeField] public bool IsShown;
        private bool _hasPressedEscapeAtStart;

        protected virtual void Start()
        {
            switch (IsActiveAtStart)
            {
                case true:
                    ShowMenu();
                    AllMenusManager.Instance.CurrentMenu = this;
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
                CheckPressed();
            }
        }

        protected void CheckPressed()
        {
            if (HasPressed)
            {
                if (InputManager.Instance.Inputs is { 
                        Down: false, 
                        Up: false, 
                        Right: false, 
                        Left: false, 
                        Select: false, 
                        DownMenu: false,
                        Social: false
                    })
                {
                    HasPressed = false;
                }
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
                if (MenuToGoBack != null)
                {
                    MenuToGoBack.ShowMenu();
                }
                _hasPressedEscapeAtStart = true;
            }
        }

        public virtual void ShowMenu()
        {
            IsActive = true;

            //escape
            _hasPressedEscapeAtStart = InputManager.Instance.Inputs.GoBack;
            
            //shown
            if (IsShown)
            {
                return;
            }
            IsShown = true;

            //set fade to 0
            MenuAsset.MenuImagesList.ForEach(x => x.DOKill());
            MenuAsset.MenuTextList.ForEach(x => x.DOKill());
        
            //fade to 1
            MenuAsset.MenuImagesList.ForEach(x => x.DOFade(1,AppearTime * Random.Range(0.5f,2f)));
            MenuAsset.MenuTextList.ForEach(x => x.DOFade(1,AppearTime * Random.Range(0.5f,2f)));
            
            //audio
            SoundManager.Instance.PlaySound(SoundManager.Instance.ChangeMenu);
            
            //Cam
            if (CameraToSet != null)
            {
                CamerasManager.Instance.SetCamera(CameraToSet);
            }
        }

        public virtual void HideMenu()
        {
            IsShown = false;
            IsActive = false;
            
            //complete
            MenuAsset.MenuImagesList.ForEach(x => x.DOKill());
            MenuAsset.MenuTextList.ForEach(x => x.DOKill());

            //fade to 0
            MenuAsset.MenuImagesList.ForEach(x => x.DOFade(0,DisappearTime * Random.Range(0.5f,2f)));
            MenuAsset.MenuTextList.ForEach(x => x.DOFade(0,DisappearTime * Random.Range(0.5f,2f)));
        }

        private void NextButton()
        {
            if (SelectionIndex < ButtonList.Count - 1)
            {
                HasPressed = true;
                SelectionIndex++;
                SoundManager.Instance.PlaySound(SoundManager.Instance.Move);
            }
        }
    
        private void PreviousButton()
        {
            if (SelectionIndex > 0)
            {
                HasPressed = true;
                SelectionIndex--;
                SoundManager.Instance.PlaySound(SoundManager.Instance.Move);
            }
        }
    
        protected void HandleSelection(bool previous, bool next)
        {
            //active guard
            if (IsActive == false)
            {
                return;
            }
            
            //pressed guard
            CheckPressed();
            if (HasPressed)
            {
                return;
            }

            //selection
            int selection = SelectionIndex;
            if (previous)
            {
                PreviousButton();
            }
            if (next)
            {
                NextButton();
            }
            if (selection != SelectionIndex)
            {
                SetSelected();
                ButtonList[SelectionIndex].SelectButton();
            }
            
            //select
            if (InputManager.Instance.Inputs.Select && IsActive)
            {
                HasPressed = true;
                ButtonList[SelectionIndex].PressButton();
            }
        }

        protected virtual void SetSelected()
        {
        
        }
    }
}