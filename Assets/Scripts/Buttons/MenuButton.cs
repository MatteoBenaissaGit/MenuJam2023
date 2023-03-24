using DG.Tweening;
using Menu;
using UnityEngine;
using UnityEngine.Events;

namespace Buttons
{
    public class MenuButton : MonoBehaviour
    {
        [SerializeField] protected MenuManager MenuOwner;
        [SerializeField] protected MenuManager MenuToLoad;

        public UnityEvent OnSelect = new UnityEvent();

        public virtual void Select()
        {
            OnSelect.Invoke();
            if (MenuToLoad != null)
            {
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
    }
}