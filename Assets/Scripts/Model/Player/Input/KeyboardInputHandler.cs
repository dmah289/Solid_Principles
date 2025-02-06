using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using Interface.Animation;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Input
{
    public class KeyboardInputHandler : MonoBehaviour, IPlayerInputHandler
    {
        // Field
        [SerializeField] private Vector2 _direction;
        
        // Properties
        public Vector2 Direction { get => _direction; }
        
        // Events
        public event Action<PlayerState> OnInteractEvent;

        public void GetInput()
        {
            GetMovementInput();
            GetInteractInput();
        }

        private void GetInteractInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                OnInteractEvent?.Invoke(PlayerState.Slashing);
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.L))
            {
                OnInteractEvent?.Invoke(PlayerState.LyingDown);
            }
        }

        private void GetMovementInput()
        {
            float x = UnityEngine.Input.GetAxisRaw("Horizontal");
            float y = UnityEngine.Input.GetAxisRaw("Vertical");
            _direction = new Vector2(x, y).normalized;
        }
    }
}