using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region SINGLETON

    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [Header("Sources")]
    [SerializeField] private AudioSource _musicSource, _effectSource, _dialogSource;

    [Header("Clips")] 
    [SerializeField] public AudioClip Music;
    [SerializeField] public AudioClip Credits;
    [SerializeField] public AudioClip Select;
    [SerializeField] public AudioClip Move;
    [SerializeField] public AudioClip ChangeMenu;
    

    public void PlayMusic(AudioClip clip)
    {
        _musicSource.Stop();
        _musicSource.PlayOneShot(clip);
    }
    
    public void PlaySound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }
    
    public void PlayDialog(AudioClip clip)
    {
        _dialogSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void ToggleEffects()
    {
        _effectSource.mute = _effectSource.mute == false;
    }
    
    public void ToggleMusic()
    {
        _musicSource.mute = _musicSource.mute == false;
    }
    
    public void ToggleSource()
    {
        _dialogSource.mute = _dialogSource.mute == false;
    }
}
