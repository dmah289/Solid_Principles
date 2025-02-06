using System;
using Interface;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;
    public float Speed { get => _speed; }

    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    public void Move(Vector2 direction)
    {
        _rb2d.linearVelocity = direction * _speed;
    }

    private void Update()
    {
        if (_rb2d.linearVelocity == Vector2.zero)
        {
            _rb2d.linearVelocity = new Vector2(0.000005f, 0.000005f);
        }
    }
}
