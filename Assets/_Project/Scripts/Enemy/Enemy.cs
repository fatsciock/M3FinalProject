using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
    [SerializeField] private float _force;
    [SerializeField] private float _maxDistance;

    public override void Move()
    {
        if (_player != null)
        {            
            direction = _player.transform.position - transform.position;
            if (direction.magnitude < _maxDistance)
            {
                _mover.UpdateDirection(direction);
            }
        }
    }

    public override void Attack()
    {
        _player.GetComponentInChildren<LifeController>().AddHp(-dmg);
        Vector2 _pushDir = ( _player.transform.position - transform.position ).normalized;
        _player.GetComponent<Rigidbody2D>().AddForce(_pushDir * _force, ForceMode2D.Impulse);
        Destroy(gameObject);
    }  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();            
        }
    }
}
