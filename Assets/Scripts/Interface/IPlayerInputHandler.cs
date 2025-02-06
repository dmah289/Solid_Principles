using System;
using Interface.Animation;
using UnityEngine;

namespace Interface
{
    public interface IPlayerInputHandler
    {
        Vector2 Direction { get; }
        event Action<PlayerState> OnInteractEvent;
        
        void GetInput();
    }
}