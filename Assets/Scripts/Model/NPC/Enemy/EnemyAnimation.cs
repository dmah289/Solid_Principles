using System;
using Interface.Animation;
using UnityEngine;

namespace Model.NPC
{
    public class EnemyAnimation : MonoBehaviour, IInteractableAnimation<NPCState>
    {
        public Animator animator { get; private set; }
        public NPCState CurrentState { get; private set; }

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void AnimateInteraction(NPCState activeState)
        {
            CurrentState = activeState;
            foreach (NPCState state in Enum.GetValues(typeof(NPCState)))
            {
                animator.SetBool(state.ToString(), state == CurrentState);
            }
        }
    }
}