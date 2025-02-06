using System;
using UnityEngine;

namespace Interface.Animation
{
    public interface IMovableAnimation<TState> : IAnimatable where TState : Enum
    {
        TState CurrentState { get; }
        void AnimateMovement(Vector2 direction);
    }
}