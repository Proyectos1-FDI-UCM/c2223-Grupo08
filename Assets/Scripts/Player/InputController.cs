using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private bool _isGrounded = true;    //Indica si a caido al suelo
    private bool _isJumping = false;    //Indica si esta en la accion de saltar

    [SerializeField]
    private float _jumpTime = 0.5f;   //Valor inicial del contador 
    private float _jumpTimeCounter = 0f;    //Contador para el tiempo en el aire

    // Update is called once per frame
    void Update()
    {
        //Da un impulso inicia e inicializa el contador en el aire
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) {
            _isJumping = true;
            _jumpTimeCounter = _jumpTime;
            SendMessage("Jump");
        }
        //Aumenta el salto hasta cierto tiempo
        else if (Input.GetKey(KeyCode.Space) && _isJumping) {
            if (_jumpTimeCounter > 0)
            {
                SendMessage("Jump");
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }
        // en caso de levantar la tecla, impide volver a conseguir el impulso
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _isJumping = false;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            SendMessage("MoveRight",_isGrounded);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            SendMessage("MoveLeft",_isGrounded);
        }

        if (Input.GetKey(KeyCode.X))
        {
            SendMessage("resetSize");
        }
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
