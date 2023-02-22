using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetFloat("velocityX", GetComponent<Rigidbody2D>().velocity.x);
        _animator.SetFloat("velocityY", GetComponent<Rigidbody2D>().velocity.y);
        if (GetComponent<Rigidbody2D>().velocity.x < -0.5f)
        {
            _spriteRenderer.flipX = true;
        }
        else if (GetComponent<Rigidbody2D>().velocity.x > 0.5f)
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void Grounded()
    {
        _animator.SetBool("isGrounded", true);
    }

    private void NotGrounded()
    {
        _animator.SetBool("isGrounded", false);
    }
}
