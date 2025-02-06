using System;
using Interface;
using Interface.Animation;
using Manager;
using Model.Player;
using Player.Input;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    // Input
    private IPlayerInputHandler _playerInput;
    
    // Movement
    private IMovable _playerMovement;
    
    // Animation
    private IMovableAnimation<PlayerState> _playerMovableAnimation;
    private IInteractableAnimation<PlayerState> _playerInteractableAnimation;
    
    // Interaction
    private PlayerInteraction _playerInteraction;
    
    // Sfx
    private PlayerSoundSfx _playerSoundSfx;

    private void Awake()
    {
        _playerInput = GetComponent<IPlayerInputHandler>();
        _playerMovement = GetComponent<IMovable>();
        _playerMovableAnimation = GetComponent<IMovableAnimation<PlayerState>>();
        _playerInteractableAnimation = GetComponent<IInteractableAnimation<PlayerState>>();
        _playerInteraction = GetComponent<PlayerInteraction>();
        _playerSoundSfx = GetComponent<PlayerSoundSfx>();

        DetectTypeInput();
    }

    private void DetectTypeInput()
    {
        if (_playerInput is MobileInputHandler) 
            GameManager.Instance.typeInput = TypeInput.Mobile;
        else if(_playerInput is KeyboardInputHandler) 
            GameManager.Instance.typeInput = TypeInput.Keyboard;
    }

    private void OnEnable()
    {
        _playerInput.OnInteractEvent += _playerInteractableAnimation.AnimateInteraction;
    }

    private void OnDisable()
    {
        _playerInput.OnInteractEvent -= _playerInteractableAnimation.AnimateInteraction;
    }

    private void Update()
    {
        _playerInput.GetInput();
        _playerMovableAnimation.AnimateMovement(_playerInput.Direction);
        
        if (_playerInteractableAnimation.CurrentState.IsSoundEmittable())
        {
            _playerSoundSfx.PlaySfx(_playerInteractableAnimation.CurrentState);
        }
    }

    private void FixedUpdate()
    {
        _playerMovement.Move(_playerInput.Direction);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _playerInteraction.TriggerInteractedObject(other);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (_playerInteractableAnimation.CurrentState == PlayerState.Slashing)
        {
            _playerInteraction.SlashObject(other);
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        _playerInteraction.ExitInteractedObject(other);
    }
}
