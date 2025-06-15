using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMover2D : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private Rigidbody2D _rb;
    private Vector2 _direction;
    private Vector2 _lastDirection = Vector2.down;

    public Vector2 LastDirection => _lastDirection;

    public void UpdateDirection(Vector2 direction)
    {
        _direction = direction.normalized;

        if (_direction == Vector2.zero) return; // Don't update last direction if no movement
        _lastDirection = direction;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (_direction != Vector2.zero)
        {
            _rb.MovePosition( _rb.position + _direction * (_speed * Time.deltaTime) );
        }
    }
}
