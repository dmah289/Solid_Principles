using System;
using Interface;
using Interface.Animation;
using Manager;
using UnityEngine;

namespace Model.NPC
{
    public abstract class NPC : MonoBehaviour, IAudioEmitter<NPCState>
    {
        // Components
        protected AudioSource _audioSource;
        public AudioSource AudioSource => _audioSource;
        
        // Events
        public event Action<NPC> OnInteractNpc;
        public event Action OnExitInteractionNpc;

        protected virtual void Awake()
        {
            _audioSource = GetComponentInChildren<AudioSource>();
        }
        
        public virtual void Interact()
        {
            OnInteractNpc?.Invoke(this);
            PlaySfx();
        }

        public void PlaySfx(NPCState state = default)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(GetAudioClip());
            }
        }

        protected abstract AudioClip GetAudioClip();

        public virtual void ExitInteraction()
        {
            OnExitInteractionNpc?.Invoke();
        }
    }
}