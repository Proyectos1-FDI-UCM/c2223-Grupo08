using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Audios { MusicMenu, DoorOpen, DoorClosed, Button, Platform, Rock, MechanicalSaw, MenuButton, Walk, Jump, Death, Box , Lava, PickBall, LeaveBall, Save};

public class AudioController : MonoBehaviour
{
    #region references
    [SerializeField] private AudioClip _audioDoorOpen;
    [SerializeField] private AudioClip _audioDoorClosed;
    [SerializeField] private AudioClip _audioButton;
    [SerializeField] private AudioClip _audioPlatform;
    [SerializeField] private AudioClip _audioRock;
    [SerializeField] private AudioClip _audioMechanicalSaw;

    [SerializeField] private AudioClip _audioMusicMenu;
    [SerializeField] private AudioClip _audioMenuButton;

    [SerializeField] private AudioClip _audioWalk;
    [SerializeField] private AudioClip _audioJump;
    [SerializeField] private AudioClip _audioDeath;
    [SerializeField] private AudioClip _audioBox;
    [SerializeField] private AudioClip _audioLava;
    [SerializeField] private AudioClip _audioPickBall;
    [SerializeField] private AudioClip _audioLeaveBall;
    [SerializeField] private AudioClip _audioSave;
    #endregion

    #region 
    /// <summary>
    /// Refetencia al AudioSource
    /// </summary>
    private AudioSource _audioSource;
    private Dictionary<Audios, AudioClip> _audios;
    #endregion
    #region methods
    /// <summary>
    /// Reproduce un sonido por el canal general
    /// </summary>
    /// <param name="audio">El nombre del sonido</param>
    /// <param name="loop">Si esta en bucle o no</param>
    public void PlaySound(Audios audio, bool loop = false)
    {
        _audioSource.clip = _audios[audio];
        _audioSource.loop = loop;
        _audioSource.Play();
    }

    /// <summary>
    /// Para el sonido
    /// </summary>
    /// <param name="audio"></param>
    /// <param name="loop"></param>
    public void StopSound(Audios audio)
    {
        _audioSource.Stop();
    }

    /// <summary>
    /// Pausa el sonido
    /// </summary>
    public void PauseSound()
    {
        _audioSource.Pause();
    }

    /// <summary>
    /// Devuelve el sonido del diccionario de sonidos
    /// </summary>
    /// <param name="audio">El sonido a recibir</param>
    /// <returns>El sonido del diccionario</returns>
    public AudioClip GetSoundClip(Audios audio)
    {
        return _audios[audio];
    }
    #endregion
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audios = new Dictionary<Audios, AudioClip>{
            { Audios.MusicMenu, _audioMusicMenu},
            { Audios.MenuButton, _audioMenuButton},
            { Audios.DoorOpen, _audioDoorOpen},
            { Audios.DoorClosed, _audioDoorClosed},
            { Audios.Button, _audioButton},
            { Audios.Platform, _audioPlatform},
            { Audios.Rock, _audioRock},
            { Audios.MechanicalSaw, _audioMechanicalSaw},
            { Audios.Jump, _audioJump},
            { Audios.Death, _audioDeath},
            { Audios.Walk, _audioWalk},
            { Audios.Box, _audioBox },
            { Audios.Lava, _audioLava },
            { Audios.PickBall, _audioPickBall },
            { Audios.LeaveBall, _audioLeaveBall },
            { Audios.Save, _audioSave },
        };
    }
}
