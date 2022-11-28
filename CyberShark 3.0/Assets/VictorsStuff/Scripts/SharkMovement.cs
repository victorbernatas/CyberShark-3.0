// GENERATED AUTOMATICALLY FROM 'Assets/VictorsStuff/SharkMovement.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @SharkMovement : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @SharkMovement()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SharkMovement"",
    ""maps"": [
        {
            ""name"": ""Shark"",
            ""id"": ""4e57b30a-9adf-45fe-8e53-7cf881f2e5cd"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""86452fb7-fa04-436d-aabc-d8c2157dac02"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""08265848-e649-45de-a075-96e82be73c60"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c4dbe094-4847-42ba-91c7-428fe584181d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6e224c83-8368-4a31-bf31-b81f43e32d6b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""86636fab-fc49-4e27-92a8-4a0e924ae25e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""36940dd2-b163-4b3f-9065-fe758a0df211"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9892986b-d78d-4d37-a176-6c7ea062cbb4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Shark
        m_Shark = asset.FindActionMap("Shark", throwIfNotFound: true);
        m_Shark_Movement = m_Shark.FindAction("Movement", throwIfNotFound: true);
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

    // Shark
    private readonly InputActionMap m_Shark;
    private ISharkActions m_SharkActionsCallbackInterface;
    private readonly InputAction m_Shark_Movement;
    public struct SharkActions
    {
        private @SharkMovement m_Wrapper;
        public SharkActions(@SharkMovement wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Shark_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Shark; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SharkActions set) { return set.Get(); }
        public void SetCallbacks(ISharkActions instance)
        {
            if (m_Wrapper.m_SharkActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_SharkActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_SharkActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_SharkActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_SharkActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public SharkActions @Shark => new SharkActions(this);
    public interface ISharkActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
}
