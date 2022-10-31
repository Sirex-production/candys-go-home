using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Support.Input
{
    public sealed class PcInputService : ITickable
    {
        private readonly PcInputActions _pcInputActions;
        
        private readonly InputAction _console;
        private readonly InputAction _movementHorizontal;
        private readonly InputAction _movementVertical;
        private readonly InputAction _jump;
        private readonly InputAction _crouch;
        private readonly InputAction _deltaRotation;
        private readonly InputAction _interact;
        private readonly InputAction _attack;
        private readonly InputAction _nextWeapon;
        private readonly InputAction _previousWeapon;
        private readonly InputAction _meleeWeapon;

        private bool _isEnabled = false;
        
        public event Action OnConsoleInputReceived;
        public event Action<Vector2> OnMoveInput;
        public event Action OnJumpInput;
        public event Action OnCrouchInput;
        public event Action<Vector2> OnDeltaRotationInput;
        public event Action OnInteractInput;
        public event Action OnAttackInput;
        /// <summary>
        /// bool identifies whether next weapon was selected. true - next weapon. false - previous weapon
        /// </summary>
        public event Action<bool> OnWeaponSwitch;
        public event Action OnMeleeWeaponSwitch;

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                if(_isEnabled)
                    _pcInputActions.Enable();
                else
                    _pcInputActions.Disable();
            }
        }

        public PcInputService()
        {
            _pcInputActions = new PcInputActions();
            IsEnabled = true;

            _console = _pcInputActions.Utilities.Console;
            _movementHorizontal = _pcInputActions.Movement.Horizontal;
            _movementVertical = _pcInputActions.Movement.Vertical;
            _jump = _pcInputActions.Movement.Jump;
            _crouch = _pcInputActions.Movement.Crouch;
            _deltaRotation = _pcInputActions.Rotation.Delta;
            _interact = _pcInputActions.Interaction.Interact;
            _attack = _pcInputActions.Combat.Attack;
            _nextWeapon = _pcInputActions.Combat.NextWeapon;
            _previousWeapon = _pcInputActions.Combat.PreviousWeapon;
            _meleeWeapon = _pcInputActions.Combat.MeleeWeaponSwitch;
        }

        public void Tick()
        {
            ReceiveUtilitiesInput();
            ReceiveMovementInput();
            ReceiveRotationInput();
            ReceiveInteractionInput();
            ReceiveCombatInput();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ReceiveUtilitiesInput()
        {
            if(_console.WasPerformedThisFrame())
                OnConsoleInputReceived?.Invoke();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ReceiveMovementInput()
        {
            float horizontalInput = _movementHorizontal.ReadValue<float>();
            float verticalInput = _movementVertical.ReadValue<float>();

            OnMoveInput?.Invoke(new Vector2(horizontalInput, verticalInput));
            
            if(_jump.WasPerformedThisFrame()) 
                OnJumpInput?.Invoke();
            
            if(_crouch.WasPerformedThisFrame())
                OnCrouchInput?.Invoke();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ReceiveRotationInput()
        {
            var deltaRotation = _deltaRotation.ReadValue<Vector2>();
            OnDeltaRotationInput?.Invoke(deltaRotation);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ReceiveInteractionInput()
        {
            if(_interact.WasPerformedThisFrame())
                OnInteractInput?.Invoke();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ReceiveCombatInput()
        {
            if(_attack.IsPressed())
                OnAttackInput?.Invoke();
            
            if(_nextWeapon.WasPerformedThisFrame())
                OnWeaponSwitch?.Invoke(true);
            
            if(_previousWeapon.WasPerformedThisFrame())
                OnWeaponSwitch?.Invoke(false);
            
            if(_meleeWeapon.WasPerformedThisFrame())
                OnMeleeWeaponSwitch?.Invoke();
        }
    }
}