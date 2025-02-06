using System;
using Manager;
using UnityEngine;

namespace Interface
{
    public interface IAudioEmitter<TState> where TState : Enum
    {
        AudioSource AudioSource { get; }
        void PlaySfx(TState state);
    }
}