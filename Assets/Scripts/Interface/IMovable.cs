using UnityEngine;

namespace Interface
{
    public interface IMovable
    {
        float Speed { get; }
        void Move(Vector2 direction);
    }
}