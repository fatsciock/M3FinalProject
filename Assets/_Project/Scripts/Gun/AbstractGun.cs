using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGun : MonoBehaviour
{
    [SerializeField] protected Transform _spawnPoint;
    [SerializeField] protected TopDownMover2D _playerMover;

    [SerializeField] protected float _shotInterval = 0.5f;

    [SerializeField] protected int _bulletDamage = 1;
    [SerializeField] protected float _bulletSpeed = 5f;
    [SerializeField] protected float _bulletLifeSpan = 5;

    protected float _lastShotTime = 0;

    private void Awake()
    {
        _spawnPoint = transform.parent.Find("FirePoint");
        _playerMover = GetComponentInParent<TopDownMover2D>();

        if(_spawnPoint == null)
        {
            Debug.Log($"SpawnPoint nullo");
        }
    }

    private void Update()
    {
        if (!CanShoot()) return;

        Shoot();
        _lastShotTime = Time.time;
    }

    protected abstract void Shoot();

    public virtual void LevelUp()
    {
        _bulletDamage += 1;
        _shotInterval *= 0.9f;
    }

    public virtual bool CanShoot()
    {
        return Time.time - _lastShotTime >= _shotInterval;
    }
}
 