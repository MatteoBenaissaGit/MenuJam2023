using Unity.VisualScripting;
using UnityEngine;

namespace Menu
{
    public class MenuMessageSingle : MenuManager
    {
        [SerializeField] protected MenuManager MenuToLoad;

        protected override void Start()
        {
            base.Start();
            HasPressed = true;
        }

        protected override void Update()
        {
            if (IsActive == false)
            {
                return;
            }
            
            base.Update();
            if (HasPressed)
            {
                if (InputManager.Instance.Inputs is { Down: false, Up: false, Right: false, Left: false, Select: false })
                {
                    HasPressed = false;
                }
                return;
            }
            
            if ((InputManager.Instance.Inputs.GoBack || InputManager.Instance.Inputs.Select))
            {
                Select();
            }
        }
        
        private void Select()
        {
            if (MenuToLoad != null)
            {
                HideMenu();
                MenuToLoad.ShowMenu();
                MenuToLoad.HasPressed = true;
            }
        }
    }
}