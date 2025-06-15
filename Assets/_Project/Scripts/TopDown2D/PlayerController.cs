using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private TopDownMover2D _mover;
    private Animator _anim;

    private const float _movementThreshold = 0.1f;

    void Start()
    {
        _mover = GetComponent<TopDownMover2D>();
        _anim = GetComponentInChildren<Animator>();

        if (_anim != null)
        {
            _anim.SetFloat("lastHDir", 0f);
            _anim.SetFloat("lastVDir", -1f);
        }
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(h, v);
        _mover.UpdateDirection(dir);

        if (_anim != null && (h != 0 || v != 0))
        {
            _anim.SetFloat("hDir", h);
            _anim.SetFloat("vDir", v);

            bool isMoving = dir.magnitude > _movementThreshold;
            _anim.SetBool("isMoving", isMoving);

            if (isMoving)
            {
                float roundedH = Mathf.Round(dir.x);

                _anim.SetFloat("lastHDir", h);
                _anim.SetFloat("lastVDir", v);
            }
        }
    }
}
