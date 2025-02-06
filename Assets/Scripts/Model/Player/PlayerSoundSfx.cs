using System;
using System.Collections;
using System.Collections.Generic;
using Framework;
using Interface;
using Interface.Animation;
using Manager;
using UnityEngine;

namespace Model.Player
{
    public class PlayerSoundSfx : MonoBehaviour, IAudioEmitter<PlayerState>
    {
        private AudioSource _audioSource;
        public AudioSource AudioSource { get => _audioSource; }

        [SerializeField] private bool isSfxPlaying;

        private void Awake()
        {
            _audioSource = GetComponentInChildren<AudioSource>();
        }

        public void PlaySfx(PlayerState state)
        {
            if (!_audioSource.isPlaying && !isSfxPlaying)
            {
                StartCoroutine(PlaySfxCoroutine(state));
            }
        }

        private IEnumerator PlaySfxCoroutine(PlayerState state)
        {
            isSfxPlaying = true;
            _audioSource.PlayOneShot(GetClipByState(state));
            yield return Helper.GetWait(GetDurationByState(state));
            isSfxPlaying = false;
        }

        private float GetDurationByState(PlayerState state) => state switch
        {
            PlayerState.Slashing => KeySave.slashDuration,
            _ => 0
        };

        public AudioClip GetClipByState(PlayerState state)
            => state switch
        {
            PlayerState.Moving => AudioManager.Instance.PlayerAudioClips[(int)PlayerAudio.Moving],
            PlayerState.Slashing => AudioManager.Instance.PlayerAudioClips[(int)PlayerAudio.Slashing],
            _ => null
        };
    }
}