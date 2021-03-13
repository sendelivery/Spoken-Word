// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControls.inputactions'

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
            ""name"": ""Pause"",
            ""id"": ""6f2f680f-fb5b-4e6a-8b56-80b45a112f9f"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""4bc9d3e4-c8b8-4ebe-8076-447e3fac775e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Options"",
                    ""type"": ""Button"",
                    ""id"": ""5d006c97-349c-4ed9-b3ad-bad39d9b0f87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""eb523c2f-62f8-4da9-9340-9190c966e38d"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0fe79c2-af92-4a6c-8473-cb6b4238c1da"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68f1c6c0-2eaa-4524-9c92-ad34cf8d5c7e"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f26216d8-7ed0-4257-872b-bcc3140cdd1e"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Options"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4253c24-a997-4c80-aef1-65790e22b57d"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Options"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
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
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7fa6ec27-a3fe-4efe-9aec-b8cbff42282a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""01c2362b-2364-4f8b-a671-3d214a8f34cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""1ce3f8d4-1123-4527-8de1-1e0e48d96bfc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TriggerRun"",
                    ""type"": ""Button"",
                    ""id"": ""3b4225d8-8f0a-42d2-b0eb-99e5bc98de7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom Hold"",
                    ""type"": ""Button"",
                    ""id"": ""fbafe1e7-859c-44c0-8a62-44b4dbf61161"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom Tap"",
                    ""type"": ""Button"",
                    ""id"": ""6cc571bf-5ce2-45a1-91b9-53a19dd471d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
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
                    ""id"": ""0ab9807d-c6f4-4441-aa0c-977dbff98d72"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9b582a3-c490-4dd4-839a-9f00f78764b9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.1,y=0.1)"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d470d44c-6287-487d-90c7-ad0edda92075"",
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
                    ""id"": ""f485484b-4c94-4415-a3d0-eefd37b77814"",
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
                    ""id"": ""8bb15b6c-983f-4f3d-937c-a1cc952d5325"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""TriggerRun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04899b65-97f9-4008-9f6d-71b09839814b"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Hold(duration=0.1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""TriggerRun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef0b2002-b0cf-4dc1-80ad-2655d84dd64f"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Hold(pressPoint=0.9)"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Zoom Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bc3d111-9526-4bc4-a0fb-e13008c1f4ca"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Tap(duration=5)"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Zoom Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63c4b147-db1b-4c46-aa92-85402a21af03"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Zoom Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Minigame"",
            ""id"": ""6d24293b-7f02-4449-bce4-989cb147d5e3"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""e508d9e8-0820-4cfd-9fc7-5b8d13e00255"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b99fa5d5-d33f-47de-93d2-bee97ca4d5dc"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04facd1b-4110-4911-87c8-a25fe96af1a4"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Back"",
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
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""85f39895-d295-4521-8ac9-fe8d5b2e0cf5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""71e3c783-62cc-4a8a-af39-7fd8132ac8be"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aa64b2ee-03f5-4eec-8dd6-a9a6089a2394"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""DPad"",
                    ""id"": ""9b855de8-82b8-433e-99f6-2ad1f878c08d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d3204ab2-3e7e-473d-baf6-eb68c6207c78"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""43201599-f715-41e3-9118-ac6255597830"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""96f6410f-eb87-47b5-a1aa-9f44f8a3961b"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""829981b6-f94e-483b-995a-a837bfd81905"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""3bdf0eb6-7c06-4846-b2cd-7996e42b74a3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1975ae03-4770-4525-9858-bad3df1a6df8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""64b8a260-9ab2-4586-ba8b-2a5ec01412c9"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e6fd455c-ebd5-4b9d-88c9-9767a138b778"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""546cda41-e37f-41c7-9148-9b578ef74d8d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""TiltShrine"",
            ""id"": ""41f8a46f-ab78-4abf-8c46-f19f33aaa17a"",
            ""actions"": [
                {
                    ""name"": ""Tilt"",
                    ""type"": ""PassThrough"",
                    ""id"": ""75b3fdf2-dddb-433f-acea-a5a6a5f42eea"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""44bb39a4-4aa0-4c68-bc26-d5fe2593fd67"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Test"",
                    ""type"": ""Button"",
                    ""id"": ""c1cba77e-aef4-43f9-8117-48331778bc4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fce37e95-48cf-4572-be54-012b8af7e9ce"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Tilt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c7d649a-3126-46b1-ba63-2a1e5541d64b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.1,y=0.1)"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Tilt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54c1ed27-898b-418d-8247-ec8e30ea028d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e5cb832f-33bd-479b-83c8-f368dcc63c79"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""21f50eb4-c29e-4106-bf47-848cbf3d5ca9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ed687a7e-86f6-402f-b94c-60e5edbd3d03"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6f6cf7d0-2526-473a-9782-f7b29ab8837a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0ecbf4d0-0047-4e4c-b102-3e6ddf4d92cd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""628aa063-eb96-46ea-996c-60d41769c2c1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Test"",
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
        // Pause
        m_Pause = asset.FindActionMap("Pause", throwIfNotFound: true);
        m_Pause_Pause = m_Pause.FindAction("Pause", throwIfNotFound: true);
        m_Pause_Options = m_Pause.FindAction("Options", throwIfNotFound: true);
        // DefaultGameplay
        m_DefaultGameplay = asset.FindActionMap("DefaultGameplay", throwIfNotFound: true);
        m_DefaultGameplay_Move = m_DefaultGameplay.FindAction("Move", throwIfNotFound: true);
        m_DefaultGameplay_Look = m_DefaultGameplay.FindAction("Look", throwIfNotFound: true);
        m_DefaultGameplay_Jump = m_DefaultGameplay.FindAction("Jump", throwIfNotFound: true);
        m_DefaultGameplay_Interact = m_DefaultGameplay.FindAction("Interact", throwIfNotFound: true);
        m_DefaultGameplay_TriggerRun = m_DefaultGameplay.FindAction("TriggerRun", throwIfNotFound: true);
        m_DefaultGameplay_ZoomHold = m_DefaultGameplay.FindAction("Zoom Hold", throwIfNotFound: true);
        m_DefaultGameplay_ZoomTap = m_DefaultGameplay.FindAction("Zoom Tap", throwIfNotFound: true);
        // Minigame
        m_Minigame = asset.FindActionMap("Minigame", throwIfNotFound: true);
        m_Minigame_Back = m_Minigame.FindAction("Back", throwIfNotFound: true);
        // RingToss
        m_RingToss = asset.FindActionMap("RingToss", throwIfNotFound: true);
        m_RingToss_Fire = m_RingToss.FindAction("Fire", throwIfNotFound: true);
        m_RingToss_Navigate = m_RingToss.FindAction("Navigate", throwIfNotFound: true);
        // TiltShrine
        m_TiltShrine = asset.FindActionMap("TiltShrine", throwIfNotFound: true);
        m_TiltShrine_Tilt = m_TiltShrine.FindAction("Tilt", throwIfNotFound: true);
        m_TiltShrine_Rotate = m_TiltShrine.FindAction("Rotate", throwIfNotFound: true);
        m_TiltShrine_Test = m_TiltShrine.FindAction("Test", throwIfNotFound: true);
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

    // Pause
    private readonly InputActionMap m_Pause;
    private IPauseActions m_PauseActionsCallbackInterface;
    private readonly InputAction m_Pause_Pause;
    private readonly InputAction m_Pause_Options;
    public struct PauseActions
    {
        private @PlayerControls m_Wrapper;
        public PauseActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Pause_Pause;
        public InputAction @Options => m_Wrapper.m_Pause_Options;
        public InputActionMap Get() { return m_Wrapper.m_Pause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseActions set) { return set.Get(); }
        public void SetCallbacks(IPauseActions instance)
        {
            if (m_Wrapper.m_PauseActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_PauseActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PauseActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PauseActionsCallbackInterface.OnPause;
                @Options.started -= m_Wrapper.m_PauseActionsCallbackInterface.OnOptions;
                @Options.performed -= m_Wrapper.m_PauseActionsCallbackInterface.OnOptions;
                @Options.canceled -= m_Wrapper.m_PauseActionsCallbackInterface.OnOptions;
            }
            m_Wrapper.m_PauseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Options.started += instance.OnOptions;
                @Options.performed += instance.OnOptions;
                @Options.canceled += instance.OnOptions;
            }
        }
    }
    public PauseActions @Pause => new PauseActions(this);

    // DefaultGameplay
    private readonly InputActionMap m_DefaultGameplay;
    private IDefaultGameplayActions m_DefaultGameplayActionsCallbackInterface;
    private readonly InputAction m_DefaultGameplay_Move;
    private readonly InputAction m_DefaultGameplay_Look;
    private readonly InputAction m_DefaultGameplay_Jump;
    private readonly InputAction m_DefaultGameplay_Interact;
    private readonly InputAction m_DefaultGameplay_TriggerRun;
    private readonly InputAction m_DefaultGameplay_ZoomHold;
    private readonly InputAction m_DefaultGameplay_ZoomTap;
    public struct DefaultGameplayActions
    {
        private @PlayerControls m_Wrapper;
        public DefaultGameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_DefaultGameplay_Move;
        public InputAction @Look => m_Wrapper.m_DefaultGameplay_Look;
        public InputAction @Jump => m_Wrapper.m_DefaultGameplay_Jump;
        public InputAction @Interact => m_Wrapper.m_DefaultGameplay_Interact;
        public InputAction @TriggerRun => m_Wrapper.m_DefaultGameplay_TriggerRun;
        public InputAction @ZoomHold => m_Wrapper.m_DefaultGameplay_ZoomHold;
        public InputAction @ZoomTap => m_Wrapper.m_DefaultGameplay_ZoomTap;
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
                @Look.started -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnLook;
                @Jump.started -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnInteract;
                @TriggerRun.started -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnTriggerRun;
                @TriggerRun.performed -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnTriggerRun;
                @TriggerRun.canceled -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnTriggerRun;
                @ZoomHold.started -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnZoomHold;
                @ZoomHold.performed -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnZoomHold;
                @ZoomHold.canceled -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnZoomHold;
                @ZoomTap.started -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnZoomTap;
                @ZoomTap.performed -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnZoomTap;
                @ZoomTap.canceled -= m_Wrapper.m_DefaultGameplayActionsCallbackInterface.OnZoomTap;
            }
            m_Wrapper.m_DefaultGameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @TriggerRun.started += instance.OnTriggerRun;
                @TriggerRun.performed += instance.OnTriggerRun;
                @TriggerRun.canceled += instance.OnTriggerRun;
                @ZoomHold.started += instance.OnZoomHold;
                @ZoomHold.performed += instance.OnZoomHold;
                @ZoomHold.canceled += instance.OnZoomHold;
                @ZoomTap.started += instance.OnZoomTap;
                @ZoomTap.performed += instance.OnZoomTap;
                @ZoomTap.canceled += instance.OnZoomTap;
            }
        }
    }
    public DefaultGameplayActions @DefaultGameplay => new DefaultGameplayActions(this);

    // Minigame
    private readonly InputActionMap m_Minigame;
    private IMinigameActions m_MinigameActionsCallbackInterface;
    private readonly InputAction m_Minigame_Back;
    public struct MinigameActions
    {
        private @PlayerControls m_Wrapper;
        public MinigameActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_Minigame_Back;
        public InputActionMap Get() { return m_Wrapper.m_Minigame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MinigameActions set) { return set.Get(); }
        public void SetCallbacks(IMinigameActions instance)
        {
            if (m_Wrapper.m_MinigameActionsCallbackInterface != null)
            {
                @Back.started -= m_Wrapper.m_MinigameActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MinigameActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MinigameActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MinigameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public MinigameActions @Minigame => new MinigameActions(this);

    // RingToss
    private readonly InputActionMap m_RingToss;
    private IRingTossActions m_RingTossActionsCallbackInterface;
    private readonly InputAction m_RingToss_Fire;
    private readonly InputAction m_RingToss_Navigate;
    public struct RingTossActions
    {
        private @PlayerControls m_Wrapper;
        public RingTossActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_RingToss_Fire;
        public InputAction @Navigate => m_Wrapper.m_RingToss_Navigate;
        public InputActionMap Get() { return m_Wrapper.m_RingToss; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RingTossActions set) { return set.Get(); }
        public void SetCallbacks(IRingTossActions instance)
        {
            if (m_Wrapper.m_RingTossActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_RingTossActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_RingTossActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_RingTossActionsCallbackInterface.OnFire;
                @Navigate.started -= m_Wrapper.m_RingTossActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_RingTossActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_RingTossActionsCallbackInterface.OnNavigate;
            }
            m_Wrapper.m_RingTossActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
            }
        }
    }
    public RingTossActions @RingToss => new RingTossActions(this);

    // TiltShrine
    private readonly InputActionMap m_TiltShrine;
    private ITiltShrineActions m_TiltShrineActionsCallbackInterface;
    private readonly InputAction m_TiltShrine_Tilt;
    private readonly InputAction m_TiltShrine_Rotate;
    private readonly InputAction m_TiltShrine_Test;
    public struct TiltShrineActions
    {
        private @PlayerControls m_Wrapper;
        public TiltShrineActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tilt => m_Wrapper.m_TiltShrine_Tilt;
        public InputAction @Rotate => m_Wrapper.m_TiltShrine_Rotate;
        public InputAction @Test => m_Wrapper.m_TiltShrine_Test;
        public InputActionMap Get() { return m_Wrapper.m_TiltShrine; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TiltShrineActions set) { return set.Get(); }
        public void SetCallbacks(ITiltShrineActions instance)
        {
            if (m_Wrapper.m_TiltShrineActionsCallbackInterface != null)
            {
                @Tilt.started -= m_Wrapper.m_TiltShrineActionsCallbackInterface.OnTilt;
                @Tilt.performed -= m_Wrapper.m_TiltShrineActionsCallbackInterface.OnTilt;
                @Tilt.canceled -= m_Wrapper.m_TiltShrineActionsCallbackInterface.OnTilt;
                @Rotate.started -= m_Wrapper.m_TiltShrineActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_TiltShrineActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_TiltShrineActionsCallbackInterface.OnRotate;
                @Test.started -= m_Wrapper.m_TiltShrineActionsCallbackInterface.OnTest;
                @Test.performed -= m_Wrapper.m_TiltShrineActionsCallbackInterface.OnTest;
                @Test.canceled -= m_Wrapper.m_TiltShrineActionsCallbackInterface.OnTest;
            }
            m_Wrapper.m_TiltShrineActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tilt.started += instance.OnTilt;
                @Tilt.performed += instance.OnTilt;
                @Tilt.canceled += instance.OnTilt;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Test.started += instance.OnTest;
                @Test.performed += instance.OnTest;
                @Test.canceled += instance.OnTest;
            }
        }
    }
    public TiltShrineActions @TiltShrine => new TiltShrineActions(this);
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
    public interface IPauseActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnOptions(InputAction.CallbackContext context);
    }
    public interface IDefaultGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnTriggerRun(InputAction.CallbackContext context);
        void OnZoomHold(InputAction.CallbackContext context);
        void OnZoomTap(InputAction.CallbackContext context);
    }
    public interface IMinigameActions
    {
        void OnBack(InputAction.CallbackContext context);
    }
    public interface IRingTossActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
    }
    public interface ITiltShrineActions
    {
        void OnTilt(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnTest(InputAction.CallbackContext context);
    }
}
