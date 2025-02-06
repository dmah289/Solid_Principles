using System;

namespace Interface.Animation
{
    public interface IInteractableAnimation<TState> : IAnimatable where TState : Enum
    {
        TState CurrentState { get; }
        void AnimateInteraction(TState activeState);
    }
}