//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Vendor/Support/Scripts/InputSystem/InputActions.inputactions
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

namespace Support.Input
{
    public partial class @PcInputActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PcInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""2471b5dc-20bd-4f4b-9a21-5fd38380cc8f"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""610a67ab-a472-4c6e-baf4-1debf2146c37"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Button"",
                    ""id"": ""da35d0aa-d4b9-4e64-a706-54e4421ca6dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3a8d06a2-7ece-4f80-9412-5e7b0687965b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""b6f6dec6-c63d-4577-a7c4-fb808ff5b775"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""KeyboardAD"",
                    ""id"": ""162176ab-0b89-43b3-8274-f4d629e39d6c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5548be75-f2bb-42ae-a81c-331946080bcf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9699180f-5418-45cb-840f-77930466769d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyboardWS"",
                    ""id"": ""e152a397-c046-408b-99fb-1bfa2dcbfeb5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6cdb7188-b835-4043-a2a1-b1c4679654c7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""04bdde9a-6ca2-4d7d-8399-b46b74a0c8c3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""602f4b85-d651-4041-93a0-7062295a69ed"",
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
                    ""id"": ""79e02754-62ae-41bf-9f79-b4cf42a0f47a"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Rotation"",
            ""id"": ""38cd8e04-5d9b-4f5b-a261-b7449ffdcaee"",
            ""actions"": [
                {
                    ""name"": ""Delta"",
                    ""type"": ""Value"",
                    ""id"": ""00298790-1c17-46cb-8f03-e3d61df8d9ef"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b08c4401-15af-4814-98c9-effb2509e259"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""id"": ""d785f6e7-82af-4409-b858-a37d0354667b"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""856cc0ae-6d69-43cd-8c8e-a398de056d38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""045759c4-9199-4dc0-b406-64b42dd5ed2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PreviousWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""690dd25f-0cd3-402b-8859-74e159647a47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MeleeWeaponSwitch"",
                    ""type"": ""Button"",
                    ""id"": ""66896a55-a477-495a-a2a1-04533a7d971b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""67991f23-c28c-464a-b9f4-23e5bd5a1024"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6dfa5513-9d9a-4078-be8d-ef5139ffece6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6372a4fc-be13-4324-af7f-d30c47e86ae5"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e50d539a-ccd5-404d-a031-3daee8676d8a"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MeleeWeaponSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d574a5da-e13f-4208-a372-31cce24e15d4"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MeleeWeaponSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interaction"",
            ""id"": ""def2e98e-74c5-4418-a1c3-0dda2df61963"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""04764597-38e2-4d9c-9d8d-f8e20bf4d69b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b6142db3-ec2c-4d4f-a44a-e615cf6c0408"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Utilities"",
            ""id"": ""a6b655b6-f79b-4804-b2ff-b7dbaf062ad3"",
            ""actions"": [
                {
                    ""name"": ""Console"",
                    ""type"": ""Button"",
                    ""id"": ""0fe13d0f-a7bc-4609-9750-008b089f6816"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1f10a46e-a443-4120-8281-ff04f20fd837"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Console"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Movement
            m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
            m_Movement_Horizontal = m_Movement.FindAction("Horizontal", throwIfNotFound: true);
            m_Movement_Vertical = m_Movement.FindAction("Vertical", throwIfNotFound: true);
            m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
            m_Movement_Crouch = m_Movement.FindAction("Crouch", throwIfNotFound: true);
            // Rotation
            m_Rotation = asset.FindActionMap("Rotation", throwIfNotFound: true);
            m_Rotation_Delta = m_Rotation.FindAction("Delta", throwIfNotFound: true);
            // Combat
            m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
            m_Combat_Attack = m_Combat.FindAction("Attack", throwIfNotFound: true);
            m_Combat_NextWeapon = m_Combat.FindAction("NextWeapon", throwIfNotFound: true);
            m_Combat_PreviousWeapon = m_Combat.FindAction("PreviousWeapon", throwIfNotFound: true);
            m_Combat_MeleeWeaponSwitch = m_Combat.FindAction("MeleeWeaponSwitch", throwIfNotFound: true);
            // Interaction
            m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
            m_Interaction_Interact = m_Interaction.FindAction("Interact", throwIfNotFound: true);
            // Utilities
            m_Utilities = asset.FindActionMap("Utilities", throwIfNotFound: true);
            m_Utilities_Console = m_Utilities.FindAction("Console", throwIfNotFound: true);
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

        // Movement
        private readonly InputActionMap m_Movement;
        private IMovementActions m_MovementActionsCallbackInterface;
        private readonly InputAction m_Movement_Horizontal;
        private readonly InputAction m_Movement_Vertical;
        private readonly InputAction m_Movement_Jump;
        private readonly InputAction m_Movement_Crouch;
        public struct MovementActions
        {
            private @PcInputActions m_Wrapper;
            public MovementActions(@PcInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Horizontal => m_Wrapper.m_Movement_Horizontal;
            public InputAction @Vertical => m_Wrapper.m_Movement_Vertical;
            public InputAction @Jump => m_Wrapper.m_Movement_Jump;
            public InputAction @Crouch => m_Wrapper.m_Movement_Crouch;
            public InputActionMap Get() { return m_Wrapper.m_Movement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
            public void SetCallbacks(IMovementActions instance)
            {
                if (m_Wrapper.m_MovementActionsCallbackInterface != null)
                {
                    @Horizontal.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnHorizontal;
                    @Horizontal.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnHorizontal;
                    @Horizontal.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnHorizontal;
                    @Vertical.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnVertical;
                    @Vertical.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnVertical;
                    @Vertical.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnVertical;
                    @Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                    @Crouch.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnCrouch;
                    @Crouch.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnCrouch;
                    @Crouch.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnCrouch;
                }
                m_Wrapper.m_MovementActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Horizontal.started += instance.OnHorizontal;
                    @Horizontal.performed += instance.OnHorizontal;
                    @Horizontal.canceled += instance.OnHorizontal;
                    @Vertical.started += instance.OnVertical;
                    @Vertical.performed += instance.OnVertical;
                    @Vertical.canceled += instance.OnVertical;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Crouch.started += instance.OnCrouch;
                    @Crouch.performed += instance.OnCrouch;
                    @Crouch.canceled += instance.OnCrouch;
                }
            }
        }
        public MovementActions @Movement => new MovementActions(this);

        // Rotation
        private readonly InputActionMap m_Rotation;
        private IRotationActions m_RotationActionsCallbackInterface;
        private readonly InputAction m_Rotation_Delta;
        public struct RotationActions
        {
            private @PcInputActions m_Wrapper;
            public RotationActions(@PcInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Delta => m_Wrapper.m_Rotation_Delta;
            public InputActionMap Get() { return m_Wrapper.m_Rotation; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(RotationActions set) { return set.Get(); }
            public void SetCallbacks(IRotationActions instance)
            {
                if (m_Wrapper.m_RotationActionsCallbackInterface != null)
                {
                    @Delta.started -= m_Wrapper.m_RotationActionsCallbackInterface.OnDelta;
                    @Delta.performed -= m_Wrapper.m_RotationActionsCallbackInterface.OnDelta;
                    @Delta.canceled -= m_Wrapper.m_RotationActionsCallbackInterface.OnDelta;
                }
                m_Wrapper.m_RotationActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Delta.started += instance.OnDelta;
                    @Delta.performed += instance.OnDelta;
                    @Delta.canceled += instance.OnDelta;
                }
            }
        }
        public RotationActions @Rotation => new RotationActions(this);

        // Combat
        private readonly InputActionMap m_Combat;
        private ICombatActions m_CombatActionsCallbackInterface;
        private readonly InputAction m_Combat_Attack;
        private readonly InputAction m_Combat_NextWeapon;
        private readonly InputAction m_Combat_PreviousWeapon;
        private readonly InputAction m_Combat_MeleeWeaponSwitch;
        public struct CombatActions
        {
            private @PcInputActions m_Wrapper;
            public CombatActions(@PcInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Attack => m_Wrapper.m_Combat_Attack;
            public InputAction @NextWeapon => m_Wrapper.m_Combat_NextWeapon;
            public InputAction @PreviousWeapon => m_Wrapper.m_Combat_PreviousWeapon;
            public InputAction @MeleeWeaponSwitch => m_Wrapper.m_Combat_MeleeWeaponSwitch;
            public InputActionMap Get() { return m_Wrapper.m_Combat; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
            public void SetCallbacks(ICombatActions instance)
            {
                if (m_Wrapper.m_CombatActionsCallbackInterface != null)
                {
                    @Attack.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnAttack;
                    @NextWeapon.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnNextWeapon;
                    @NextWeapon.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnNextWeapon;
                    @NextWeapon.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnNextWeapon;
                    @PreviousWeapon.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnPreviousWeapon;
                    @PreviousWeapon.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnPreviousWeapon;
                    @PreviousWeapon.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnPreviousWeapon;
                    @MeleeWeaponSwitch.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnMeleeWeaponSwitch;
                    @MeleeWeaponSwitch.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnMeleeWeaponSwitch;
                    @MeleeWeaponSwitch.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnMeleeWeaponSwitch;
                }
                m_Wrapper.m_CombatActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                    @NextWeapon.started += instance.OnNextWeapon;
                    @NextWeapon.performed += instance.OnNextWeapon;
                    @NextWeapon.canceled += instance.OnNextWeapon;
                    @PreviousWeapon.started += instance.OnPreviousWeapon;
                    @PreviousWeapon.performed += instance.OnPreviousWeapon;
                    @PreviousWeapon.canceled += instance.OnPreviousWeapon;
                    @MeleeWeaponSwitch.started += instance.OnMeleeWeaponSwitch;
                    @MeleeWeaponSwitch.performed += instance.OnMeleeWeaponSwitch;
                    @MeleeWeaponSwitch.canceled += instance.OnMeleeWeaponSwitch;
                }
            }
        }
        public CombatActions @Combat => new CombatActions(this);

        // Interaction
        private readonly InputActionMap m_Interaction;
        private IInteractionActions m_InteractionActionsCallbackInterface;
        private readonly InputAction m_Interaction_Interact;
        public struct InteractionActions
        {
            private @PcInputActions m_Wrapper;
            public InteractionActions(@PcInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Interact => m_Wrapper.m_Interaction_Interact;
            public InputActionMap Get() { return m_Wrapper.m_Interaction; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InteractionActions set) { return set.Get(); }
            public void SetCallbacks(IInteractionActions instance)
            {
                if (m_Wrapper.m_InteractionActionsCallbackInterface != null)
                {
                    @Interact.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                }
                m_Wrapper.m_InteractionActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                }
            }
        }
        public InteractionActions @Interaction => new InteractionActions(this);

        // Utilities
        private readonly InputActionMap m_Utilities;
        private IUtilitiesActions m_UtilitiesActionsCallbackInterface;
        private readonly InputAction m_Utilities_Console;
        public struct UtilitiesActions
        {
            private @PcInputActions m_Wrapper;
            public UtilitiesActions(@PcInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Console => m_Wrapper.m_Utilities_Console;
            public InputActionMap Get() { return m_Wrapper.m_Utilities; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UtilitiesActions set) { return set.Get(); }
            public void SetCallbacks(IUtilitiesActions instance)
            {
                if (m_Wrapper.m_UtilitiesActionsCallbackInterface != null)
                {
                    @Console.started -= m_Wrapper.m_UtilitiesActionsCallbackInterface.OnConsole;
                    @Console.performed -= m_Wrapper.m_UtilitiesActionsCallbackInterface.OnConsole;
                    @Console.canceled -= m_Wrapper.m_UtilitiesActionsCallbackInterface.OnConsole;
                }
                m_Wrapper.m_UtilitiesActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Console.started += instance.OnConsole;
                    @Console.performed += instance.OnConsole;
                    @Console.canceled += instance.OnConsole;
                }
            }
        }
        public UtilitiesActions @Utilities => new UtilitiesActions(this);
        public interface IMovementActions
        {
            void OnHorizontal(InputAction.CallbackContext context);
            void OnVertical(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnCrouch(InputAction.CallbackContext context);
        }
        public interface IRotationActions
        {
            void OnDelta(InputAction.CallbackContext context);
        }
        public interface ICombatActions
        {
            void OnAttack(InputAction.CallbackContext context);
            void OnNextWeapon(InputAction.CallbackContext context);
            void OnPreviousWeapon(InputAction.CallbackContext context);
            void OnMeleeWeaponSwitch(InputAction.CallbackContext context);
        }
        public interface IInteractionActions
        {
            void OnInteract(InputAction.CallbackContext context);
        }
        public interface IUtilitiesActions
        {
            void OnConsole(InputAction.CallbackContext context);
        }
    }
}
