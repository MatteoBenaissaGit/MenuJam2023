//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Inputs/MenuInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MenuInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MenuInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MenuInputs"",
    ""maps"": [
        {
            ""name"": ""Selection"",
            ""id"": ""a984bc30-cf19-4e10-9203-de2c26070f2c"",
            ""actions"": [
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""ab97f9c1-fcbb-4467-baca-c184322ae68c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""7c0b0e3a-0724-4fd5-bfbe-8348bcedd8d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""9f50e816-87de-42a9-8cc8-d20bf8953e66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""1bf3a5ce-3b9c-4139-a92d-c763c168db5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""f2c3fc59-f635-461d-91b6-af505ac081e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GoBack"",
                    ""type"": ""Button"",
                    ""id"": ""3cee824b-d72a-4bf2-9ab5-e72b3fd115aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8694c034-2845-458e-87e8-77b88c6119f9"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67fc3511-6ae2-47f3-a140-fdeae47c3c86"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9838e774-e27f-4482-8f73-9784c7bc495e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a4663a4-7bf2-4508-b418-e59f9a7d1eab"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f79d45bc-e4e2-428c-b0b5-0dfc391606ea"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56a1956d-28b9-4e15-9b68-e3b7c43366c9"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Selection
        m_Selection = asset.FindActionMap("Selection", throwIfNotFound: true);
        m_Selection_Down = m_Selection.FindAction("Down", throwIfNotFound: true);
        m_Selection_Up = m_Selection.FindAction("Up", throwIfNotFound: true);
        m_Selection_Left = m_Selection.FindAction("Left", throwIfNotFound: true);
        m_Selection_Right = m_Selection.FindAction("Right", throwIfNotFound: true);
        m_Selection_Select = m_Selection.FindAction("Select", throwIfNotFound: true);
        m_Selection_GoBack = m_Selection.FindAction("GoBack", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Selection
    private readonly InputActionMap m_Selection;
    private ISelectionActions m_SelectionActionsCallbackInterface;
    private readonly InputAction m_Selection_Down;
    private readonly InputAction m_Selection_Up;
    private readonly InputAction m_Selection_Left;
    private readonly InputAction m_Selection_Right;
    private readonly InputAction m_Selection_Select;
    private readonly InputAction m_Selection_GoBack;
    public struct SelectionActions
    {
        private @MenuInputs m_Wrapper;
        public SelectionActions(@MenuInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Down => m_Wrapper.m_Selection_Down;
        public InputAction @Up => m_Wrapper.m_Selection_Up;
        public InputAction @Left => m_Wrapper.m_Selection_Left;
        public InputAction @Right => m_Wrapper.m_Selection_Right;
        public InputAction @Select => m_Wrapper.m_Selection_Select;
        public InputAction @GoBack => m_Wrapper.m_Selection_GoBack;
        public InputActionMap Get() { return m_Wrapper.m_Selection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectionActions set) { return set.Get(); }
        public void SetCallbacks(ISelectionActions instance)
        {
            if (m_Wrapper.m_SelectionActionsCallbackInterface != null)
            {
                @Down.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnDown;
                @Up.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnUp;
                @Left.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnRight;
                @Select.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnSelect;
                @GoBack.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnGoBack;
                @GoBack.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnGoBack;
                @GoBack.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnGoBack;
            }
            m_Wrapper.m_SelectionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @GoBack.started += instance.OnGoBack;
                @GoBack.performed += instance.OnGoBack;
                @GoBack.canceled += instance.OnGoBack;
            }
        }
    }
    public SelectionActions @Selection => new SelectionActions(this);
    public interface ISelectionActions
    {
        void OnDown(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnGoBack(InputAction.CallbackContext context);
    }
}
