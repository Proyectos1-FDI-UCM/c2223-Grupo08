using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    #region
    [SerializeField] private Transform _transform; // la componente transform del otro portal
    private GameObject _gameObject; // último objeto teletransportado
    private float _cooldown = 0.3f;
    private static float _contador;
    #endregion
    private void Update()
    {
        if (_contador > 0)
        {
            _contador -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (_contador <= 0)
        {
            if( collision.gameObject.transform.parent.gameObject != null)
            {
                collision.gameObject.transform.parent.transform.position = _transform.position;
            }
            else
            {
                collision.gameObject.transform.position = _transform.position;
            }
            _contador = _cooldown;
        }
    }
}
