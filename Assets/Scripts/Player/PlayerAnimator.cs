using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
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

    private void IsDeath(bool b)
    {
        _animator.SetBool("IsDeath", b);
    }
    public IEnumerator nextRoomAnim(Vector2 target, Vector2 cameraTarget, DoorComponent door)
    {
        Vector2 direction = Vector2.Lerp(transform.position, target, Time.deltaTime);
        Camera.main.GetComponent<CameraMovement>().MoveCamera(cameraTarget);
        while (Vector2.Distance(transform.position, target) > 2f || Vector2.Distance(transform.position, target) < -2f)
        {
            _rigidbody2D.MovePosition(direction);
            direction = Vector2.Lerp(transform.position, target, Time.deltaTime);
            yield return null;
        }
        door.CloseDoor();
        PlayerManager.Instance.EnableInputs(true);
        
    }
}
