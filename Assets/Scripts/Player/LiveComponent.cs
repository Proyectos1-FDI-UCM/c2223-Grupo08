using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveComponent : MonoBehaviour
{
    #region properties
    /// <summary>
    /// Referencia al PlayerAnimator
    /// </summary>
    private PlayerAnimator _playerAnimator;

    /// <summary>
    /// Referencia al PlayerManager
    /// </summary>
    private PlayerManager _playerManager;

    /// <summary>
    /// Referencia al AudioSource
    /// </summary>
    private AudioSource _audioSource;

    /// <summary>
    /// Referencia al AudioSource
    /// </summary>
    private AudioClip _deathAudio;
    #endregion

    private void Start()
    {
        _playerAnimator= GetComponent<PlayerAnimator>();
        _playerManager = PlayerManager.Instance;
        _audioSource = GetComponent<AudioSource>();
        _deathAudio = GameManager.Instance.GetSoundClip(Audios.Death);
    }

    /// <summary>
    /// Mata al jugador
    /// </summary>
    public void Death ()
    {
        _audioSource.clip = _deathAudio;
        _audioSource.loop = false;
        _audioSource.Play();
        _playerManager.SetAlive(false);
        _playerManager.EnableInputs(false);
        _playerAnimator.IsDeath(true);
        Invoke("PlayDeath", 1);
    }

    /// <summary>
    /// Reinicia la sala
    /// </summary>
    // Mirar si se puede quitar la corutina
    private void PlayDeath()
    {
        GameManager.Instance.FadeOut();
    }
}
