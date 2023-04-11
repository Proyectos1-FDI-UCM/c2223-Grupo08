using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    #region properties
    /// <summary>
    /// Referencia al animador
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// Referencia al RigidBody2D
    /// </summary>
    private Rigidbody2D _rigidbody2D;

    /// <summary>
    /// Indica en que direccion esta mirando
    /// </summary>
    private bool faceRight = true;
    #endregion

    #region methods

    /// <summary>
    /// Indica al animador que el jugador esta en el suelo
    /// </summary>
    private void Grounded()
    {
        _animator.SetBool("isGrounded", true);
    }

    /// <summary>
    /// Indica al animador que el jugador no esta en el suelo
    /// </summary>
    private void NotGrounded()
    {
        _animator.SetBool("isGrounded", false);
    }

    /// <summary>
    /// Indica al animador que el jugador esta muerto o no
    /// </summary>
    /// <param name="b">Si esta muerto o no</param>
    private void IsDeath(bool b)
    {
        _animator.SetBool("IsDeath", b);
    }

    /// <summary>
    /// Indica al animador si esta cargando la partida
    /// </summary>
    //Nombrar mejor esto
    public void LoadScene()
    {
        _animator.SetBool("LoadScene", true);
    }

    /// <summary>
    /// Animacion de pasar a la siguiente sala
    /// </summary>
    /// <param name="target">Punto de destino que el jugador tiene que ir</param>
    /// <param name="cameraTarget">Punto al que tiene que ir la camara</param>
    /// <param name="door">La puerta que realiza la animacion</param>
    /// <returns></returns>
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
    #endregion
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _animator.SetFloat("velocityX", GetComponent<Rigidbody2D>().velocity.x);
        _animator.SetFloat("velocityY", GetComponent<Rigidbody2D>().velocity.y);
        if (GetComponent<Rigidbody2D>().velocity.x < -0.01f && faceRight)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale; 
            faceRight = false;
        }
        else if (GetComponent<Rigidbody2D>().velocity.x > 0.01f && !faceRight)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale; 
            faceRight = true;
        }
    }

}
