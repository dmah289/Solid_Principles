using System;
using System.Collections;
using Interface;
using Interface.Animation;
using Manager;
using UnityEngine;

namespace Model.NPC
{
    public class EnemyController : NPC
    {
        // Components
        private IInteractableAnimation<NPCState> _animation;
        private IInteracted _interacted;
        
        // Properties
        public IInteracted Interacted { get => _interacted; }

        protected override void Awake()
        {
            base.Awake();
            _animation = GetComponent<IInteractableAnimation<NPCState>>();
            _interacted = GetComponent<IInteracted>();
        }

        public override void Interact()
        {
            base.Interact();
            _animation.AnimateInteraction(NPCState.GetDamage);
        }

        public void GetHit()
        {
            if (_interacted is EnemyInteraction enemyInteraction)
            {
                if (!enemyInteraction.IsInteracting)
                {
                    enemyInteraction.GetInteracted(gameObject);
                    PlaySfx(_animation.CurrentState);
                }
            }
        }

        protected override AudioClip GetAudioClip() =>
            AudioManager.Instance.NpcAudioClips[(int)NpcAudio.Enemy];

        public override void ExitInteraction()
        {
            base.ExitInteraction();
            _interacted.ExitInteraction();
            _animation.AnimateInteraction(NPCState.Idle);
        }
    }
}