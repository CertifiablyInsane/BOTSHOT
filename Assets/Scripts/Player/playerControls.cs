// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/playerControls.inputactions'

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
    ""name"": ""playerControls"",
    ""maps"": [
        {
            ""name"": ""Generic"",
            ""id"": ""0860a52e-7aa9-4d03-8b33-87958fc7afbf"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""62c7c22a-5f0b-48c8-8c61-09d7c7bddd31"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""look"",
                    ""type"": ""Value"",
                    ""id"": ""6ff4aed2-981b-4069-92b1-5336c6abca4d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""480c8911-137b-4249-9400-2b006ce4e0c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""fire"",
                    ""type"": ""Button"",
                    ""id"": ""974a683b-3c6d-4589-9b29-aa087ce69df0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""altfire"",
                    ""type"": ""Button"",
                    ""id"": ""a024048e-20de-49ba-b1b3-f530d436cd08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""weapon1"",
                    ""type"": ""Button"",
                    ""id"": ""aa12c5b1-e5bb-4c7d-b09b-29a1f9d45722"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""weapon2"",
                    ""type"": ""Button"",
                    ""id"": ""00639259-4457-4dca-ab9f-25808bd1e57c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""weapon3"",
                    ""type"": ""Button"",
                    ""id"": ""a51eb913-b4f4-45d9-b980-c9fe451056ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""weapon4"",
                    ""type"": ""Button"",
                    ""id"": ""7c44230e-89e3-4686-9e40-5e0fb49f2f05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""weapon5"",
                    ""type"": ""Button"",
                    ""id"": ""4a317d32-f45d-4281-b492-218e107a819e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""weapon6"",
                    ""type"": ""Button"",
                    ""id"": ""89d1355b-b6ef-4d97-8148-5ebbdb80baf4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""weapon7"",
                    ""type"": ""Button"",
                    ""id"": ""c0d31983-cb9c-4171-8e57-07c79417ded6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c3bed3ea-860f-4d72-8547-89ff17a0db3c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bcac1c86-c47f-494c-a757-97e807d6549c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6451f21b-c4cf-4c33-9cc2-b28f3b2106fe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""56f03bae-cb9e-4c9a-aec9-2009e215d6f8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cbd8e214-f2f8-4a7f-8288-eda76ac023c1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d28246e2-a937-470e-9560-5c14aee851ee"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c3d5b8c-4c45-40ac-86fe-e6c4f7c65052"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd4c3644-c5f4-4684-b0d9-c44ea717aa0e"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""weapon1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a309cd23-49ce-4087-9f27-92f8fdd674e7"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""weapon2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb62abc1-10df-4b2a-9e4a-2a9284eae4db"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""weapon3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3a5d6e0-f0b3-4041-9fcf-15d000b50c2e"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""weapon4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee56102e-88e0-4c80-9193-6559324abad3"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""weapon5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6abeb30-407a-4698-b2f4-7b3e90f836dc"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""weapon6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b559b32d-644c-4bee-a7b0-4ddc685085bb"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""weapon7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47676cf8-373e-4383-9506-ef1c694d84c5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""altfire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62326e5f-ec56-42f6-9983-012e00f9cf2e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Generic
        m_Generic = asset.FindActionMap("Generic", throwIfNotFound: true);
        m_Generic_move = m_Generic.FindAction("move", throwIfNotFound: true);
        m_Generic_look = m_Generic.FindAction("look", throwIfNotFound: true);
        m_Generic_jump = m_Generic.FindAction("jump", throwIfNotFound: true);
        m_Generic_fire = m_Generic.FindAction("fire", throwIfNotFound: true);
        m_Generic_altfire = m_Generic.FindAction("altfire", throwIfNotFound: true);
        m_Generic_weapon1 = m_Generic.FindAction("weapon1", throwIfNotFound: true);
        m_Generic_weapon2 = m_Generic.FindAction("weapon2", throwIfNotFound: true);
        m_Generic_weapon3 = m_Generic.FindAction("weapon3", throwIfNotFound: true);
        m_Generic_weapon4 = m_Generic.FindAction("weapon4", throwIfNotFound: true);
        m_Generic_weapon5 = m_Generic.FindAction("weapon5", throwIfNotFound: true);
        m_Generic_weapon6 = m_Generic.FindAction("weapon6", throwIfNotFound: true);
        m_Generic_weapon7 = m_Generic.FindAction("weapon7", throwIfNotFound: true);
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

    // Generic
    private readonly InputActionMap m_Generic;
    private IGenericActions m_GenericActionsCallbackInterface;
    private readonly InputAction m_Generic_move;
    private readonly InputAction m_Generic_look;
    private readonly InputAction m_Generic_jump;
    private readonly InputAction m_Generic_fire;
    private readonly InputAction m_Generic_altfire;
    private readonly InputAction m_Generic_weapon1;
    private readonly InputAction m_Generic_weapon2;
    private readonly InputAction m_Generic_weapon3;
    private readonly InputAction m_Generic_weapon4;
    private readonly InputAction m_Generic_weapon5;
    private readonly InputAction m_Generic_weapon6;
    private readonly InputAction m_Generic_weapon7;
    public struct GenericActions
    {
        private @PlayerControls m_Wrapper;
        public GenericActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_Generic_move;
        public InputAction @look => m_Wrapper.m_Generic_look;
        public InputAction @jump => m_Wrapper.m_Generic_jump;
        public InputAction @fire => m_Wrapper.m_Generic_fire;
        public InputAction @altfire => m_Wrapper.m_Generic_altfire;
        public InputAction @weapon1 => m_Wrapper.m_Generic_weapon1;
        public InputAction @weapon2 => m_Wrapper.m_Generic_weapon2;
        public InputAction @weapon3 => m_Wrapper.m_Generic_weapon3;
        public InputAction @weapon4 => m_Wrapper.m_Generic_weapon4;
        public InputAction @weapon5 => m_Wrapper.m_Generic_weapon5;
        public InputAction @weapon6 => m_Wrapper.m_Generic_weapon6;
        public InputAction @weapon7 => m_Wrapper.m_Generic_weapon7;
        public InputActionMap Get() { return m_Wrapper.m_Generic; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GenericActions set) { return set.Get(); }
        public void SetCallbacks(IGenericActions instance)
        {
            if (m_Wrapper.m_GenericActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnMove;
                @look.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnLook;
                @look.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnLook;
                @look.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnLook;
                @jump.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnJump;
                @fire.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnFire;
                @fire.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnFire;
                @fire.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnFire;
                @altfire.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnAltfire;
                @altfire.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnAltfire;
                @altfire.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnAltfire;
                @weapon1.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon1;
                @weapon1.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon1;
                @weapon1.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon1;
                @weapon2.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon2;
                @weapon2.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon2;
                @weapon2.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon2;
                @weapon3.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon3;
                @weapon3.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon3;
                @weapon3.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon3;
                @weapon4.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon4;
                @weapon4.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon4;
                @weapon4.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon4;
                @weapon5.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon5;
                @weapon5.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon5;
                @weapon5.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon5;
                @weapon6.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon6;
                @weapon6.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon6;
                @weapon6.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon6;
                @weapon7.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon7;
                @weapon7.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon7;
                @weapon7.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnWeapon7;
            }
            m_Wrapper.m_GenericActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
                @look.started += instance.OnLook;
                @look.performed += instance.OnLook;
                @look.canceled += instance.OnLook;
                @jump.started += instance.OnJump;
                @jump.performed += instance.OnJump;
                @jump.canceled += instance.OnJump;
                @fire.started += instance.OnFire;
                @fire.performed += instance.OnFire;
                @fire.canceled += instance.OnFire;
                @altfire.started += instance.OnAltfire;
                @altfire.performed += instance.OnAltfire;
                @altfire.canceled += instance.OnAltfire;
                @weapon1.started += instance.OnWeapon1;
                @weapon1.performed += instance.OnWeapon1;
                @weapon1.canceled += instance.OnWeapon1;
                @weapon2.started += instance.OnWeapon2;
                @weapon2.performed += instance.OnWeapon2;
                @weapon2.canceled += instance.OnWeapon2;
                @weapon3.started += instance.OnWeapon3;
                @weapon3.performed += instance.OnWeapon3;
                @weapon3.canceled += instance.OnWeapon3;
                @weapon4.started += instance.OnWeapon4;
                @weapon4.performed += instance.OnWeapon4;
                @weapon4.canceled += instance.OnWeapon4;
                @weapon5.started += instance.OnWeapon5;
                @weapon5.performed += instance.OnWeapon5;
                @weapon5.canceled += instance.OnWeapon5;
                @weapon6.started += instance.OnWeapon6;
                @weapon6.performed += instance.OnWeapon6;
                @weapon6.canceled += instance.OnWeapon6;
                @weapon7.started += instance.OnWeapon7;
                @weapon7.performed += instance.OnWeapon7;
                @weapon7.canceled += instance.OnWeapon7;
            }
        }
    }
    public GenericActions @Generic => new GenericActions(this);
    public interface IGenericActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnAltfire(InputAction.CallbackContext context);
        void OnWeapon1(InputAction.CallbackContext context);
        void OnWeapon2(InputAction.CallbackContext context);
        void OnWeapon3(InputAction.CallbackContext context);
        void OnWeapon4(InputAction.CallbackContext context);
        void OnWeapon5(InputAction.CallbackContext context);
        void OnWeapon6(InputAction.CallbackContext context);
        void OnWeapon7(InputAction.CallbackContext context);
    }
}
