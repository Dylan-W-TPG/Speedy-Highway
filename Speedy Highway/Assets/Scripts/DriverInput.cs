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
                    ""name"": ""Steering"",
                    ""type"": ""Value"",
                    ""id"": ""d0c6accd-64ad-420c-80a6-966cc0baaefb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""2565148b-31c6-4550-a3a9-9257ff1388ce"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1c56d326-0bc5-486c-ba9c-40fc2e4282d3"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""816b4f85-ed07-40d9-93b8-fe169acc1dec"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5b48f1f5-d335-4ebc-82b8-d6c976c9ad4c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""06f4324b-dd68-4a75-895d-3447b59b00e3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Driving
        m_Driving = asset.FindActionMap("Driving", throwIfNotFound: true);
        m_Driving_Steering = m_Driving.FindAction("Steering", throwIfNotFound: true);
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
    private readonly InputAction m_Driving_Steering;
    public struct DrivingActions
    {
        private @DriverInput m_Wrapper;
        public DrivingActions(@DriverInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Steering => m_Wrapper.m_Driving_Steering;
        public InputActionMap Get() { return m_Wrapper.m_Driving; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DrivingActions set) { return set.Get(); }
        public void AddCallbacks(IDrivingActions instance)
        {
            if (instance == null || m_Wrapper.m_DrivingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DrivingActionsCallbackInterfaces.Add(instance);
            @Steering.started += instance.OnSteering;
            @Steering.performed += instance.OnSteering;
            @Steering.canceled += instance.OnSteering;
        }

        private void UnregisterCallbacks(IDrivingActions instance)
        {
            @Steering.started -= instance.OnSteering;
            @Steering.performed -= instance.OnSteering;
            @Steering.canceled -= instance.OnSteering;
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
        void OnSteering(InputAction.CallbackContext context);
    }
}
