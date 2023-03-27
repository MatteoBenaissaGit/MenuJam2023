using System;
using Menu;
using UnityEngine;

public class AllMenusManager : MonoBehaviour
{
    #region Singleton
    
    public static AllMenusManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    #endregion

    public MenuManager CurrentMenu;
    public bool IsAccountMenuShown = false, IsLittleBarShown = true;
}