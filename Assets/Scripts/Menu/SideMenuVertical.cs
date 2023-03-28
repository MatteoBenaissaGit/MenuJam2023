using System.Collections;
using System.Collections.Generic;
using Buttons;
using DG.Tweening;
using Menu;
using UnityEngine;
using UnityEngine.UI;

public class SideMenuVertical : MenuManager
{
    [Header("Side Menu Vertical"), SerializeField]
    private Transform _sideMenu;

    [SerializeField] private Image _blackBackground;

    private Vector3 _basePosition;
    private List<MenuOverlayButton> _buttonList = new List<MenuOverlayButton>();

    protected override void Start()
    {
        base.Start();
        _basePosition = _sideMenu.position;

        //list
        foreach (MenuButton button in ButtonList)
        {
            _buttonList.Add(button.GetComponent<MenuOverlayButton>());
        }
    }

    protected override void Update()
    {
        base.Update();

        if (HasPressed)
        {
            CheckPressed();
            return;
        }

        if ((InputManager.Instance.Inputs.Social || InputManager.Instance.Inputs.GoBack) && IsActive)
        {
            HideMenu();
            AllMenusManager.Instance.CurrentMenu.HasPressed = true;
            AllMenusManager.Instance.CurrentMenu.IsActive = true;
        }
        else if (InputManager.Instance.Inputs.Social && IsActive == false && AllMenusManager.Instance.CurrentMenu.HasPressed == false && AllMenusManager.Instance.CurrentMenu.IsActive)
        {
            ShowMenu();
            AllMenusManager.Instance.CurrentMenu.IsActive = false;
        }
        
        if (IsActive)
        {
            HandleSelection(InputManager.Instance.Inputs.Up, InputManager.Instance.Inputs.Down);
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

        _sideMenu.position = _basePosition + new Vector3(10, 0, 0);
        _sideMenu.DOMove(_basePosition, 0.5f);
        _blackBackground.DOFade(0.7f, 0.5f);

        MenuToGoBack = AllMenusManager.Instance.CurrentMenu;

        AllMenusManager.Instance.IsAccountMenuShown = true;

        SetSelected();
    }

    public override void HideMenu()
    {
        base.HideMenu();

        Vector3 position = _basePosition + new Vector3(10, 0, 0);
        _sideMenu.DOComplete();
        _sideMenu.DOMove(position, 0.5f);

        _blackBackground.DOFade(0f, 0.5f);
        
        AllMenusManager.Instance.IsAccountMenuShown = false;
    }

    protected override void SetSelected()
    {
        base.SetSelected();
        _buttonList.ForEach(x => x.SetUnselected());
        _buttonList[SelectionIndex].SetSelected();
    }
}