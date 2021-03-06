// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""cf8a94ea-2559-4877-a7ea-c10a5d5013b2"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f7b2c9a5-4eb5-4a6d-9091-162e39de4b4a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""29fee0fe-64ae-4076-9b1f-8bc674010b4e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""SlowFall"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4747e39f-1bf6-417b-bcc1-a55d0a3cb63b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.2,pressPoint=0.1)""
                },
                {
                    ""name"": ""SlowFallRelease"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0bc2e009-2fb2-4b13-8995-913e8de85b8e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""GrappleButtonDown"",
                    ""type"": ""PassThrough"",
                    ""id"": ""98680f87-1ba8-465c-afb4-a1f57f256b17"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.1,pressPoint=0.1)""
                },
                {
                    ""name"": ""GrappleButtonUp"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d11879b4-4285-495d-abe2-c6b4d1f6da9a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""37c8ea41-f0a5-474e-abac-ec8d5542b2fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9f6c5b04-2d77-4e57-8b26-ae20e8ef9006"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""GroundSmash"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ba0e2bb8-1b16-4c93-b3ce-b491b44d1e09"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""1fac5bcf-1ab2-46bf-9e05-5695362ca861"",
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
                    ""id"": ""ec04af7a-6ce5-4cd8-923c-85c30bb8f652"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1e72ca61-ee9d-429d-b78d-76961f74ae01"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9d8ef6b2-67c9-4a19-bdac-6c12e362d2b3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5c13db7f-42ba-4b73-9217-2c642a418586"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""97c41525-9d55-4144-b3d7-a82e1ca87190"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dcf225df-9ec9-4a02-9ad0-f1d77026a316"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9943efbb-37a6-4a84-8b46-3e9b1d45b7f5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ca840dc5-1a35-4943-a05d-e983176f7b62"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e1981f5f-24e2-4d48-b7a7-bc6cacb738ce"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8c92cade-47e8-435c-b516-7fc6ccbb4719"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bfa6d46-1e41-4fd6-a05b-db8188be04e6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""830c2bfd-a602-4d24-ae35-c9f214224f37"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlowFall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f8d083b-7e08-4520-9513-3413a568e39e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlowFall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b741269-397c-4704-b93c-85c89e1b99a6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlowFallRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26e2c351-3f3e-4dec-9cfb-fa1ff65b91b2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlowFallRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""613a95fe-938c-40c0-b68c-bfea1bb2fed3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrappleButtonDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35b8d405-e72a-4d98-8f5c-e0044b571936"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrappleButtonDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""562cc22a-19a1-4a69-9153-1d409f348222"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrappleButtonDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27697b2d-2307-4c4e-9356-58d2d1cd460f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrappleButtonUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24718bde-a096-4906-9429-e9e52cb46692"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrappleButtonUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96fa7d5c-b065-42e7-a109-2212b20ebbc1"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrappleButtonUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""570a8b92-eea4-4ec7-a2c7-f5dcb2c40e9c"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8748bd94-a646-491f-9a95-ad2909bfb533"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bffaa52a-0bf3-4008-b7a4-eda1d4829b43"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0587dbb2-7f84-41bd-9a3c-8b9383b47ccd"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b24f2ff2-5eff-4094-8719-236b6d862ebe"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GroundSmash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db424624-7810-4de1-afad-0b45a175df88"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GroundSmash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialogue"",
            ""id"": ""34427871-7c65-4a0f-bad0-39844bfd1e19"",
            ""actions"": [
                {
                    ""name"": ""Continue"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7c00a2e4-bc6b-4c66-9a4a-4c95375934eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""af304a14-8c2a-48ce-a0f7-c1599e8d2350"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Continue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_SlowFall = m_Player.FindAction("SlowFall", throwIfNotFound: true);
        m_Player_SlowFallRelease = m_Player.FindAction("SlowFallRelease", throwIfNotFound: true);
        m_Player_GrappleButtonDown = m_Player.FindAction("GrappleButtonDown", throwIfNotFound: true);
        m_Player_GrappleButtonUp = m_Player.FindAction("GrappleButtonUp", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_GroundSmash = m_Player.FindAction("GroundSmash", throwIfNotFound: true);
        // Dialogue
        m_Dialogue = asset.FindActionMap("Dialogue", throwIfNotFound: true);
        m_Dialogue_Continue = m_Dialogue.FindAction("Continue", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_SlowFall;
    private readonly InputAction m_Player_SlowFallRelease;
    private readonly InputAction m_Player_GrappleButtonDown;
    private readonly InputAction m_Player_GrappleButtonUp;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_GroundSmash;
    public struct PlayerActions
    {
        private @Controls m_Wrapper;
        public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @SlowFall => m_Wrapper.m_Player_SlowFall;
        public InputAction @SlowFallRelease => m_Wrapper.m_Player_SlowFallRelease;
        public InputAction @GrappleButtonDown => m_Wrapper.m_Player_GrappleButtonDown;
        public InputAction @GrappleButtonUp => m_Wrapper.m_Player_GrappleButtonUp;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @GroundSmash => m_Wrapper.m_Player_GroundSmash;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @SlowFall.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowFall;
                @SlowFall.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowFall;
                @SlowFall.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowFall;
                @SlowFallRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowFallRelease;
                @SlowFallRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowFallRelease;
                @SlowFallRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSlowFallRelease;
                @GrappleButtonDown.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrappleButtonDown;
                @GrappleButtonDown.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrappleButtonDown;
                @GrappleButtonDown.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrappleButtonDown;
                @GrappleButtonUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrappleButtonUp;
                @GrappleButtonUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrappleButtonUp;
                @GrappleButtonUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrappleButtonUp;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @GroundSmash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGroundSmash;
                @GroundSmash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGroundSmash;
                @GroundSmash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGroundSmash;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @SlowFall.started += instance.OnSlowFall;
                @SlowFall.performed += instance.OnSlowFall;
                @SlowFall.canceled += instance.OnSlowFall;
                @SlowFallRelease.started += instance.OnSlowFallRelease;
                @SlowFallRelease.performed += instance.OnSlowFallRelease;
                @SlowFallRelease.canceled += instance.OnSlowFallRelease;
                @GrappleButtonDown.started += instance.OnGrappleButtonDown;
                @GrappleButtonDown.performed += instance.OnGrappleButtonDown;
                @GrappleButtonDown.canceled += instance.OnGrappleButtonDown;
                @GrappleButtonUp.started += instance.OnGrappleButtonUp;
                @GrappleButtonUp.performed += instance.OnGrappleButtonUp;
                @GrappleButtonUp.canceled += instance.OnGrappleButtonUp;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @GroundSmash.started += instance.OnGroundSmash;
                @GroundSmash.performed += instance.OnGroundSmash;
                @GroundSmash.canceled += instance.OnGroundSmash;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Dialogue
    private readonly InputActionMap m_Dialogue;
    private IDialogueActions m_DialogueActionsCallbackInterface;
    private readonly InputAction m_Dialogue_Continue;
    public struct DialogueActions
    {
        private @Controls m_Wrapper;
        public DialogueActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Continue => m_Wrapper.m_Dialogue_Continue;
        public InputActionMap Get() { return m_Wrapper.m_Dialogue; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogueActions set) { return set.Get(); }
        public void SetCallbacks(IDialogueActions instance)
        {
            if (m_Wrapper.m_DialogueActionsCallbackInterface != null)
            {
                @Continue.started -= m_Wrapper.m_DialogueActionsCallbackInterface.OnContinue;
                @Continue.performed -= m_Wrapper.m_DialogueActionsCallbackInterface.OnContinue;
                @Continue.canceled -= m_Wrapper.m_DialogueActionsCallbackInterface.OnContinue;
            }
            m_Wrapper.m_DialogueActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Continue.started += instance.OnContinue;
                @Continue.performed += instance.OnContinue;
                @Continue.canceled += instance.OnContinue;
            }
        }
    }
    public DialogueActions @Dialogue => new DialogueActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSlowFall(InputAction.CallbackContext context);
        void OnSlowFallRelease(InputAction.CallbackContext context);
        void OnGrappleButtonDown(InputAction.CallbackContext context);
        void OnGrappleButtonUp(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnGroundSmash(InputAction.CallbackContext context);
    }
    public interface IDialogueActions
    {
        void OnContinue(InputAction.CallbackContext context);
    }
}
