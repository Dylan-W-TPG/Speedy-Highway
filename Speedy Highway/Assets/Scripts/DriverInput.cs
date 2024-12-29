//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/DriverInput.inputactions
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

public partial class @DriverInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @DriverInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DriverInput"",
    ""maps"": [
        {
            ""name"": ""Driving"",
            ""id"": ""50a7e5f1-e623-4a25-84cb-a9eff4977c25"",
            ""actions"": [
                {
                    ""name"": ""SteerLeft"",
                    ""type"": ""Button"",
                    ""id"": ""d0c6accd-64ad-420c-80a6-966cc0baaefb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SteerRight"",
                    ""type"": ""Button"",
                    ""id"": ""9670deba-1d47-4e54-8668-53802091a842"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SteerTouch"",
                    ""type"": ""Button"",
                    ""id"": ""de39a444-c716-48eb-8794-92fe24f977cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2ea58cf7-5551-4245-89de-14a0d89663bc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c0f1dea0-bd1e-4bd6-898f-27bf8aca1680"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SteerLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4ec4b62-8b7e-44e9-a748-e812cd5f1213"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SteerLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c046d22-18d3-410f-98e6-910af0718898"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SteerRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""874f99ee-727f-4616-8cad-6df9b662f89a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SteerRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffc20a0d-ea94-4f04-817c-7e838d4cd689"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SteerTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c90fde7-95a8-4126-99ac-d453536f6e66"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Driving
        m_Driving = asset.FindActionMap("Driving", throwIfNotFound: true);
        m_Driving_SteerLeft = m_Driving.FindAction("SteerLeft", throwIfNotFound: true);
        m_Driving_SteerRight = m_Driving.FindAction("SteerRight", throwIfNotFound: true);
        m_Driving_SteerTouch = m_Driving.FindAction("SteerTouch", throwIfNotFound: true);
        m_Driving_TouchPosition = m_Driving.FindAction("TouchPosition", throwIfNotFound: true);
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

    // Driving
    private readonly InputActionMap m_Driving;
    private List<IDrivingActions> m_DrivingActionsCallbackInterfaces = new List<IDrivingActions>();
    private readonly InputAction m_Driving_SteerLeft;
    private readonly InputAction m_Driving_SteerRight;
    private readonly InputAction m_Driving_SteerTouch;
    private readonly InputAction m_Driving_TouchPosition;
    public struct DrivingActions
    {
        private @DriverInput m_Wrapper;
        public DrivingActions(@DriverInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @SteerLeft => m_Wrapper.m_Driving_SteerLeft;
        public InputAction @SteerRight => m_Wrapper.m_Driving_SteerRight;
        public InputAction @SteerTouch => m_Wrapper.m_Driving_SteerTouch;
        public InputAction @TouchPosition => m_Wrapper.m_Driving_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_Driving; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DrivingActions set) { return set.Get(); }
        public void AddCallbacks(IDrivingActions instance)
        {
            if (instance == null || m_Wrapper.m_DrivingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DrivingActionsCallbackInterfaces.Add(instance);
            @SteerLeft.started += instance.OnSteerLeft;
            @SteerLeft.performed += instance.OnSteerLeft;
            @SteerLeft.canceled += instance.OnSteerLeft;
            @SteerRight.started += instance.OnSteerRight;
            @SteerRight.performed += instance.OnSteerRight;
            @SteerRight.canceled += instance.OnSteerRight;
            @SteerTouch.started += instance.OnSteerTouch;
            @SteerTouch.performed += instance.OnSteerTouch;
            @SteerTouch.canceled += instance.OnSteerTouch;
            @TouchPosition.started += instance.OnTouchPosition;
            @TouchPosition.performed += instance.OnTouchPosition;
            @TouchPosition.canceled += instance.OnTouchPosition;
        }

        private void UnregisterCallbacks(IDrivingActions instance)
        {
            @SteerLeft.started -= instance.OnSteerLeft;
            @SteerLeft.performed -= instance.OnSteerLeft;
            @SteerLeft.canceled -= instance.OnSteerLeft;
            @SteerRight.started -= instance.OnSteerRight;
            @SteerRight.performed -= instance.OnSteerRight;
            @SteerRight.canceled -= instance.OnSteerRight;
            @SteerTouch.started -= instance.OnSteerTouch;
            @SteerTouch.performed -= instance.OnSteerTouch;
            @SteerTouch.canceled -= instance.OnSteerTouch;
            @TouchPosition.started -= instance.OnTouchPosition;
            @TouchPosition.performed -= instance.OnTouchPosition;
            @TouchPosition.canceled -= instance.OnTouchPosition;
        }

        public void RemoveCallbacks(IDrivingActions instance)
        {
            if (m_Wrapper.m_DrivingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDrivingActions instance)
        {
            foreach (var item in m_Wrapper.m_DrivingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DrivingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DrivingActions @Driving => new DrivingActions(this);
    public interface IDrivingActions
    {
        void OnSteerLeft(InputAction.CallbackContext context);
        void OnSteerRight(InputAction.CallbackContext context);
        void OnSteerTouch(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}
