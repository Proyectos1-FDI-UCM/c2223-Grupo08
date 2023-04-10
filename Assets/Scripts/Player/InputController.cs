using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    private bool _isGrounded = true;    //Indica si a caido al suelo
    private bool _isJumping = false;    //Indica si esta en la accion de saltar

    [SerializeField]
    private float _jumpTime = 0.3f;   //Valor inicial del contador 
    private float _jumpTimeCounter = 0f;    //Contador para el tiempo en el aire

    [SerializeField]
    private float _frameTime = 0.1f;
    private float _frameTimeCounter = 0;



    // Update is called once per frame
    void Update()
    {
        //Da un impulso inicia e inicializa el contador en el aire
        if (Input.GetKeyDown(ConfigScript.ButtonsCodes[(int)Buttons.Jump]) && _isGrounded) {
            _isJumping = true;
            _jumpTimeCounter = _jumpTime;
            SendMessage("Jump");
            _frameTimeCounter = _frameTime;
        }
        //Aumenta el salto hasta cierto tiempo
        else if (Input.GetKey(ConfigScript.ButtonsCodes[(int)Buttons.Jump]) && _isJumping) {
            if (_frameTimeCounter < 0) {
                if (_jumpTimeCounter > 0)
                {
                    SendMessage("Jump");
                    _jumpTimeCounter -= _frameTime;
                    _frameTimeCounter += _frameTime;
                }
                else
                {
                    _isJumping = false;
                }
            }
            else
            {
                _frameTimeCounter -= Time.deltaTime;
            }
        }
        // en caso de levantar la tecla, impide volver a conseguir el impulso
        else if (Input.GetKeyUp(ConfigScript.ButtonsCodes[(int)Buttons.Jump]))
        {
            _isJumping = false;
        }

        if(Input.GetKey(ConfigScript.ButtonsCodes[(int)Buttons.Right]))
        {
            SendMessage("MoveRight");
        }
        else if(Input.GetKey(ConfigScript.ButtonsCodes[(int)Buttons.Left]))
        {
            SendMessage("MoveLeft");
        }
        else if (Input.GetKeyUp(ConfigScript.ButtonsCodes[(int)Buttons.Left])|| Input.GetKeyUp(ConfigScript.ButtonsCodes[(int)Buttons.Right]))
        {
            SendMessage("StopMoving");
        }

        if (Input.GetKey(ConfigScript.ButtonsCodes[(int)Buttons.Drop]))
        {
            SendMessage("resetSize");
        }

        if (Input.GetKey(ConfigScript.ButtonsCodes[(int)Buttons.Reset]))
        {
            StartCoroutine(GameManager.Instance.ResetRoom());
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.isPaused)
        {
            MenusManager.PauseGame();
        }
    }

    public void StopJumping()
    {
        _isJumping = false;
    }

    private void Grounded()
    {
        _isGrounded = true;
    }

    private void NotGrounded()
    {
        _isGrounded = false;
    }
}
