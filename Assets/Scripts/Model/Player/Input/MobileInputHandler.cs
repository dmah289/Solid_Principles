using System;
using Interface;
using Interface.Animation;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class MobileInputHandler : MonoBehaviour, IPlayerInputHandler
    {
        [SerializeField] private Vector2 _direction;
        public Vector2 Direction { get => _direction; }
        public event Action<PlayerState> OnInteractEvent;

        [SerializeField] private InputActionReference moveActionToUse;
        
        public void GetInput()
        {
            GetMovementInput();
        }

        public void Slash()
        {
            OnInteractEvent?.Invoke(PlayerState.Slashing);
        }

        public void LieDown()
        {
            OnInteractEvent?.Invoke(PlayerState.LyingDown);
        }
        
        private void GetMovementInput()
        {
            _direction = moveActionToUse.action.ReadValue<Vector2>();
        }
    }
}