using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 3;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _lifeSpan = 5;

    public Bullet(int damage, float speed, float lifeSpan)
    {
        _damage = damage;
        _speed = speed;
        _lifeSpan = lifeSpan;
    }

    public void Shoot(Vector3 origin, Vector2 direction)
    {
        transform.position = origin;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Vector2 dir = direction.normalized;

        rb.velocity = dir * _speed;
    }

    void Start()
    {
        Destroy(gameObject, _lifeSpan);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Se siamo sicuri che il collider si trova sullo stesso GameObject che ha LifeController
        // questo approccio e' ottimo
        if (collision.collider.TryGetComponent<LifeController>(out LifeController life))
        {
            life.AddHp(-_damage);
        }
        // Se invece il collider potrebbe essere su uno dei child del GameObject che ha LifeController
        // potremmo usare quest'altro approccio per cercare ANCHE nei parent
        //LifeController life = collision.collider.GetComponentInParent<LifeController>();
        //if (life != null)
        //{
        //    life.AddHp(-_damage);
        //}
        Destroy(gameObject); // <- si distrugge quando collide con qualcosa
    }
}
