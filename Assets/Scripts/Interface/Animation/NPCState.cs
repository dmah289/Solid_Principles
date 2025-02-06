using System;

namespace Interface.Animation
{
    [Flags]
    public enum NPCState
    {
        Idle = 1 << 0,
        GetDamage = 1 << 1
    }
}