using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : AbstractGun
{
    [SerializeField] protected Bullet _bulletPrefab;

    protected override void Shoot()
    {
        Bullet b = Instantiate(_bulletPrefab);
        if (_playerMover == null || !_playerMover.enabled)
        {
            b.Shoot(_spawnPoint.position, new Vector2(_spawnPoint.right.x, _spawnPoint.right.y));
        }
        else
        {
            b.Shoot(_spawnPoint.position, _playerMover.LastDirection);
        }
    }
}
