using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource _audio;

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

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }

    private void AudioDoorOpen()
    {
        _audio.PlayOneShot(_audioDoorOpen);
    }
    private void AudioDoorClosed()
    {
        _audio.PlayOneShot(_audioDoorClosed);
    }
    private void AudioButton()
    {
        _audio.PlayOneShot(_audioButton);
    }
    private void AudioPlatform()
    {
        _audio.PlayOneShot(_audioPlatform);
    }
    private void AudioRock()
    {
        _audio.PlayOneShot(_audioRock);
    }
    private void AudioMechanicalSaw()
    {
        _audio.PlayOneShot(_audioMechanicalSaw);
    }
    private void AudioMusicMenu()
    {
        _audio.PlayOneShot(_audioMusicMenu);
    }
    private void AudioMenuBotton()
    {
        _audio.PlayOneShot(_audioMenuButton);
    }
    private void AudioWalk()
    {
        _audio.PlayOneShot(_audioWalk);
    }
    private void AudioJump()
    {
        _audio.PlayOneShot(_audioJump);
    }
    private void AudioDeath()
    {
        _audio.PlayOneShot(_audioDeath);
    }
}
