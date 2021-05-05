// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/TouchControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControl"",
    ""maps"": [
        {
            ""name"": ""Touches"",
            ""id"": ""fb1e1fce-9835-49ca-8e29-a5750ad9075b"",
            ""actions"": [
                {
                    ""name"": ""Touchaction"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d8ed1b3b-1dfb-4ad1-9548-a964355b5cc5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PressOn"",
                    ""type"": ""PassThrough"",
                    ""id"": ""93cfc9ef-1528-478d-9229-adecc3da9060"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Touchpos"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ae3e7a82-721f-436d-9c4d-7b82bee3aea0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6336f448-1589-44c4-a024-dab44c562cf8"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Touchaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31bb6a0e-cc03-4117-b82e-50dea6f6bbd1"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""PressOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""060a639d-9e80-4191-b559-36f4b9c2bdab"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Touchpos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Touches
        m_Touches = asset.FindActionMap("Touches", throwIfNotFound: true);
        m_Touches_Touchaction = m_Touches.FindAction("Touchaction", throwIfNotFound: true);
        m_Touches_PressOn = m_Touches.FindAction("PressOn", throwIfNotFound: true);
        m_Touches_Touchpos = m_Touches.FindAction("Touchpos", throwIfNotFound: true);
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

    // Touches
    private readonly InputActionMap m_Touches;
    private ITouchesActions m_TouchesActionsCallbackInterface;
    private readonly InputAction m_Touches_Touchaction;
    private readonly InputAction m_Touches_PressOn;
    private readonly InputAction m_Touches_Touchpos;
    public struct TouchesActions
    {
        private @TouchControl m_Wrapper;
        public TouchesActions(@TouchControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touchaction => m_Wrapper.m_Touches_Touchaction;
        public InputAction @PressOn => m_Wrapper.m_Touches_PressOn;
        public InputAction @Touchpos => m_Wrapper.m_Touches_Touchpos;
        public InputActionMap Get() { return m_Wrapper.m_Touches; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchesActions set) { return set.Get(); }
        public void SetCallbacks(ITouchesActions instance)
        {
            if (m_Wrapper.m_TouchesActionsCallbackInterface != null)
            {
                @Touchaction.started -= m_Wrapper.m_TouchesActionsCallbackInterface.OnTouchaction;
                @Touchaction.performed -= m_Wrapper.m_TouchesActionsCallbackInterface.OnTouchaction;
                @Touchaction.canceled -= m_Wrapper.m_TouchesActionsCallbackInterface.OnTouchaction;
                @PressOn.started -= m_Wrapper.m_TouchesActionsCallbackInterface.OnPressOn;
                @PressOn.performed -= m_Wrapper.m_TouchesActionsCallbackInterface.OnPressOn;
                @PressOn.canceled -= m_Wrapper.m_TouchesActionsCallbackInterface.OnPressOn;
                @Touchpos.started -= m_Wrapper.m_TouchesActionsCallbackInterface.OnTouchpos;
                @Touchpos.performed -= m_Wrapper.m_TouchesActionsCallbackInterface.OnTouchpos;
                @Touchpos.canceled -= m_Wrapper.m_TouchesActionsCallbackInterface.OnTouchpos;
            }
            m_Wrapper.m_TouchesActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touchaction.started += instance.OnTouchaction;
                @Touchaction.performed += instance.OnTouchaction;
                @Touchaction.canceled += instance.OnTouchaction;
                @PressOn.started += instance.OnPressOn;
                @PressOn.performed += instance.OnPressOn;
                @PressOn.canceled += instance.OnPressOn;
                @Touchpos.started += instance.OnTouchpos;
                @Touchpos.performed += instance.OnTouchpos;
                @Touchpos.canceled += instance.OnTouchpos;
            }
        }
    }
    public TouchesActions @Touches => new TouchesActions(this);
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    public interface ITouchesActions
    {
        void OnTouchaction(InputAction.CallbackContext context);
        void OnPressOn(InputAction.CallbackContext context);
        void OnTouchpos(InputAction.CallbackContext context);
    }
}
