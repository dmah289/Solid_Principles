using System;
using System.Collections;
using Interface;
using Interface.Animation;
using Manager;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IMovableAnimation<PlayerState>, IInteractableAnimation<PlayerState>
{
    public Animator animator { get; private set; }

    [SerializeField] private PlayerState _currentState;
    public PlayerState CurrentState { get => _currentState; }
    
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        UpdateCurrentState(PlayerState.Idle);
    }
    
    private bool IsCurrentState(PlayerState state)
    {
        return (_currentState & state) == state;
    }
    
    private void UpdateCurrentState(PlayerState newState)
    {
        if (!IsCurrentState(newState))
        {
            _currentState = newState;
            UpdateAnimatorParams();
        }
    }
    
    private void UpdateAnimatorParams()
    {
        foreach (PlayerState state in Enum.GetValues(typeof(PlayerState)))
        {
            animator.SetBool(state.ToString(), IsCurrentState(state));
        }
    }

    public void AnimateMovement(Vector2 direction)
    {
        SetMovementState(direction);
        SetDirection(direction);
    }
    
    private void SetMovementState(Vector2 direction)
    {
        if (direction.magnitude > 0.1f)
        {
            UpdateCurrentState(PlayerState.Moving);
        }
        else
        {
            if (_currentState.IsMovementState())
            {
                UpdateCurrentState(PlayerState.Idle);
            }
        }
    }
    
    private void SetDirection(Vector2 direction)
    {
        if (_currentState.IsMovementState())
        {
            animator.SetFloat("X", direction.x);
            animator.SetFloat("Y", direction.y);
        }
    }
    
    public void AnimateInteraction(PlayerState state)
    {
        if (_currentState.IsIdle())
        {
            StartCoroutine(PerformInteraction(state));
        }
    }
    
    private IEnumerator PerformInteraction(PlayerState state)
    {
        UpdateCurrentState(state);

        AnimatorStateInfo infor = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(1 * (infor.length / animator.speed));
        
        UpdateCurrentState(PlayerState.Idle);
    }
}