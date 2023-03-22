using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Singleton

    public static InputManager Instance;

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

    private MenuInputs _menuInputs;
    public Input Inputs;

    private void Start()
    {
        _menuInputs = new MenuInputs();
        _menuInputs.Enable();
    }

    private void Update()
    {
        Inputs.Up = _menuInputs.Selection.Up.IsPressed();
        Inputs.Down = _menuInputs.Selection.Down.IsPressed();
        Inputs.Left = _menuInputs.Selection.Left.IsPressed();
        Inputs.Right = _menuInputs.Selection.Right.IsPressed();
        Inputs.Select = _menuInputs.Selection.Select.IsPressed();
        Inputs.GoBack = _menuInputs.Selection.GoBack.IsPressed();
        Inputs.DownMenu = _menuInputs.Selection.DownMenu.IsPressed();
    }
}

[Serializable]
public struct Input
{
    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;
    public bool Select;
    public bool GoBack;
    public bool DownMenu;
}