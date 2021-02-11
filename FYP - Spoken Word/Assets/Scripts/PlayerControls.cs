// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""DefaultGameplay"",
            ""id"": ""6270878f-2cc4-4d27-a655-130737dea229"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f2ff97f6-a215-44ba-8212-cb9e7aa52525"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""d576e32b-1f6d-409d-8b08-f2e344821caa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7fa6ec27-a3fe-4efe-9aec-b8cbff42282a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""02b09287-07ad-4615-9c14-38d3f9cc750e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c85f276f-91be-4660-a795-b9a5c300342a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39712be9-d4b8-49fd-8e8d-4f748013607b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""24abfc7d-414b-4c4f-81bc-ee6c071b57db"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""afa0ab32-8c87-452f-87fe-073b345d3332"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2b3ea039-92e0-419a-87ed-71c097b08e27"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""96b89976-e137-4495-bd1d-addfec120263"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""db620e9d-8f56-4d99-9ed5-b17bd50d095f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""afb70e8d-eb9d-49f0-9a3a-277817c336d2"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2240400e-74d7-4ee9-8cca-ec48a3369f5d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""RingToss"",
            ""id"": ""c15d2805-b0e1-4917-84fe-46f277667afa"",
            ""actions"": [
                {
                    ""name"": ""ThrowRing"",
                    ""type"": ""Button"",
                    ""id"": ""85f39895-d295-4521-8ac9-fe8d5b2e0cf5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aa64b2ee-03f5-4eec-8dd6-a9a6089a2394"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ThrowRing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // DefaultGameplay
        m_DefaultGameplay = asset.FindActionMap("DefaultGameplay", throwIfNotFound: true);
        m_DefaultGameplay_Move = m_DefaultGameplay.FindAction("Move", throwIfNotFound: true);
        m_DefaultGameplay_Interact = m_DefaultGameplay.FindAction("Interact", throwIfNotFound: true);
        m_DefaultGameplay_Look = m_DefaultGameplay.FindAction("Look", throwIfNotFound: true);
        // RingToss
        m_RingToss = asset.FindActionMap("RingToss", throwIfNotFound: true);
        m_RingToss_ThrowRing = m_RingToss.FindAction("ThrowRing", throwIfNotFound: true);
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

    // DefaultGameplay
    private readonly InputActionMap m_DefaultGameplay;
    private IDefaultGameplayActions m_DefaultGameplayActionsCallbackInterface;
    private readonly InputAction m_DefaultGameplay_Move;
    private readonly InputAction m_DefaultGameplay_Interact;
    private readonly InputAction m_DefaultGameplay_Look;
    public struct DefaultGameplayActions
    {
        private @PlayerControls m_Wrapper;
        public DefaultGameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_DefaultGameplay_Move;
        public InputAction @Interact => m_Wrapper.m_DefaultGameplay_Interact;
        public InputAction @Look => m_Wrapper.m_DefaultGameplay_Look;
        public InputActionMap Get() { return m_Wrapper.m_DefaultGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultGameplayActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultGameplayActions instance)
        {
            if (m_Wrapper.m_DefaultGameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnMove;
                @Interact.started -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnInteract;
                @Look.started -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_DefaultGameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public DefaultGameplayActions @DefaultGameplay => new DefaultGameplayActions(this);

    // RingToss
    private readonly InputActionMap m_RingToss;
    private IRingTossActions m_RingTossActionsCallbackInterface;
    private readonly InputAction m_RingToss_ThrowRing;
    public struct RingTossActions
    {
        private @PlayerControls m_Wrapper;
        public RingTossActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ThrowRing => m_Wrapper.m_RingToss_ThrowRing;
        public InputActionMap Get() { return m_Wrapper.m_RingToss; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RingTossActions set) { return set.Get(); }
        public void SetCallbacks(IRingTossActions instance)
        {
            if (m_Wrapper.m_RingTossActionsCallbackInterface != null)
            {
                @ThrowRing.started -= m_Wrapper.m_RingTossActionsCallbackInterface.OnThrowRing;
                @ThrowRing.performed -= m_Wrapper.m_RingTossActionsCallbackInterface.OnThrowRing;
                @ThrowRing.canceled -= m_Wrapper.m_RingTossActionsCallbackInterface.OnThrowRing;
            }
            m_Wrapper.m_RingTossActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ThrowRing.started += instance.OnThrowRing;
                @ThrowRing.performed += instance.OnThrowRing;
                @ThrowRing.canceled += instance.OnThrowRing;
            }
        }
    }
    public RingTossActions @RingToss => new RingTossActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IDefaultGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
    public interface IRingTossActions
    {
        void OnThrowRing(InputAction.CallbackContext context);
    }
}
