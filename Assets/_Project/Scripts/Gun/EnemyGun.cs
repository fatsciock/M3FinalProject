using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : AbstractGun
{
    private Transform _playerTrasform;
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] private float _rangeOfShoot = 10f;
    private float _distanceFromPlayer = 0f;

    private void Start()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("Player");
        if (_player != null)
        {
            _playerTrasform = _player.transform;
        }
        else
        { 
            Destroy(gameObject);
        }
    }

    protected override void Shoot()
    {
        _distanceFromPlayer = Vector2.Distance(_playerTrasform.position, transform.position);
        if (_distanceFromPlayer <= _rangeOfShoot)
        {
           Vector2 direction = (_playerTrasform.position - transform.position).normalized;
           Fire(direction);
        }
    }

    private void Fire(Vector2 direction)
    {
        Bullet b = Instantiate(_bulletPrefab);
        b.Shoot(_spawnPoint.position, direction);
    }
}
