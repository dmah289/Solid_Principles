using System;

namespace Interface.Animation
{
    [Flags]
    public enum PlayerState
    {
        Idle = 1 << 0,
        Moving = 1 << 1,
        Slashing = 1 << 2,
        LyingDown = 1 << 3
    }
    
    public static class PlayerStateExtensions
    {
        public static bool IsIdle(this PlayerState state)
        {
            return (state & PlayerState.Idle) == PlayerState.Idle;
        }
        
        public static bool IsMovementState(this PlayerState state)
        {
            return state == PlayerState.Moving;
        }

        public static bool IsSoundEmittable(this PlayerState state)
        {
            return (state & (PlayerState.Slashing | PlayerState.Moving)) != 0;
        }
    }
}