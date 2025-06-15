using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] public LifeController _lifeController {  get; private set; }
    [SerializeField] protected TopDownMover2D _mover {get; set;}
    [SerializeField] protected GameObject _player;

    [SerializeField] protected Collider2D _collider;

    [SerializeField] protected int dmg;

    protected Vector2 direction;
    protected Vector2 position;

    public virtual void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player == null) Debug.Log("Manca il player!");

        _collider = GetComponent<Collider2D>();
        if (_collider == null) Debug.Log("Manca il collider!");

        _mover = GetComponent<TopDownMover2D>();
        if (_mover == null) Debug.Log("Manca il Mover!");

        _lifeController = GetComponent<LifeController>();
        if (_lifeController == null) Debug.Log("Mancano gli hp!");
    }

    public virtual void FixedUpdate()
    {
        Move();
    }

    public abstract void Attack();

    public abstract void Move();
}
