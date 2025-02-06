using System;
using Framework;
using Model;
using UnityEngine;

namespace Manager
{
    public class AudioManager : Singleton<AudioManager>
    {
        private AudioSource _backgroundAudioSource;
        
        public AudioClip[] PlayerAudioClips;
        public AudioClip[] NpcAudioClips;

        protected override void Awake()
        {
            base.Awake();
            _backgroundAudioSource = GetComponent<AudioSource>();
            _backgroundAudioSource.Play();
        }
    }
}