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

    /// <summary>
    /// Indica si esta en la animacion de siguiente sala
    /// </summary>
    private bool inNextRoomAnim = false;

    private NextRoomAnimData _nextRoomAnimData;
    #endregion

    #region methods

    /// <summary>
    /// Indica al animador que el jugador esta en el suelo
    /// </summary>
    /// <param name="b">Si esta en el suelo o no</param>
    public void Grounded(bool b)
    {
        _animator.SetBool("isGrounded", b);
    }

    /// <summary>
    /// Indica al animador que el jugador esta muerto o no
    /// </summary>
    /// <param name="b">Si esta muerto o no</param>
    public void IsDeath(bool b)
    {
        _animator.SetBool("IsDeath", b);
    }

    /// <summary>
    /// Indica al animador si esta cargando la partida
    /// </summary>
    public void PlayLoadSceneAnimation()
    {
        _animator.SetBool("LoadScene", true);
    }

    /// <summary>
    /// Activa la animacion de pasar a la siguiente sala
    /// </summary>
    /// <param name="target">Punto de destino que el jugador tiene que ir</param>
    /// <param name="cameraTarget">Punto al que tiene que ir la camara</param>
    /// <param name="door">La puerta que realiza la animacion</param>
    public void playNextRoomAnim(Vector2 target, Vector2 cameraTarget, DoorComponent door)
    {
        _nextRoomAnimData = new NextRoomAnimData(target, cameraTarget, door);
        Camera.main.GetComponent<CameraMovement>().MoveCamera(_nextRoomAnimData.cameraTarget);
        inNextRoomAnim = true;
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
        if (inNextRoomAnim)
        {
            Vector2 direction = Vector2.Lerp(transform.position, _nextRoomAnimData.target, Time.deltaTime);
            if (Vector2.Distance(transform.position, _nextRoomAnimData.target) > 2f || Vector2.Distance(transform.position, _nextRoomAnimData.target) < -2f)
            {
                _rigidbody2D.MovePosition(direction);
            }
            else {
                _nextRoomAnimData.door.CloseDoor();
                PlayerManager.Instance.EnableInputs(true);
                PlayerManager.Instance.StopSounds();
                inNextRoomAnim = false;
            }
        }
    }
}

/// <summary>
/// Datos necesarios de la animacion de pasar sala
/// </summary>
struct NextRoomAnimData
{
    /// <summary>
    /// Punto de destino que el jugador tiene que ir
    /// </summary>
    public Vector2 target;

    /// <summary>
    /// Punto al que tiene que ir la camara
    /// </summary>
    public Vector2 cameraTarget;

    /// <summary>
    /// La puerta que realiza la animacion
    /// </summary>
    public DoorComponent door;

    public NextRoomAnimData(Vector2 target, Vector2 cameraTarget, DoorComponent door)
    {
        this.target = target;
        this.cameraTarget = cameraTarget;
        this.door = door;
    }
}
