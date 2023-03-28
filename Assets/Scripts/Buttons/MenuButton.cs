using System;
using DG.Tweening;
using Menu;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Buttons
{
    public class MenuButton : MonoBehaviour
    {
        [SerializeField] protected MenuManager MenuOwner;
        [SerializeField] protected MenuManager MenuToLoad;

        public UnityEvent OnPressed = new UnityEvent();
        public UnityEvent OnSelected = new UnityEvent();
        public UnityEvent OnNewMenuLoad = new UnityEvent();

        public virtual void PressButton()
        {
            OnPressed.Invoke();
            if (MenuToLoad != null)
            {
                OnNewMenuLoad.Invoke();
                
                if (MenuOwner != null)
                {
                    MenuOwner.HideMenu();
                }
                
                MenuToLoad.ShowMenu();
                MenuToLoad.HasPressed = true;
            }
            else
            {
                transform.DOPunchPosition(new Vector3(2, 0, 0), 0.3f);
            }
            SoundManager.Instance.PlaySound(SoundManager.Instance.Select);
        }
        
        public virtual void SelectButton()
        {
            OnSelected.Invoke();
        }
    }
}