using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CreditsController : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private RawImage _rawImage;
    
    [SerializeField, ReadOnly] private bool _isActive;
    private bool _isPressed;
    private Color _color;
    [SerializeField, ReadOnly] private float _colorAlpha;

    private void Start()
    {
        _color = new Color() {r = 255, g =255, b =255, a = _colorAlpha};
    }

    private void Update()
    {
        _color = new Color() {r = 255, g =255, b =255, a = _colorAlpha};
        _rawImage.color = _color;
        
        if (_isActive)
        {
            CheckEnter();
            if (_colorAlpha < 1)
            {
                _colorAlpha += Time.deltaTime;
            }
        }
        else if (_colorAlpha > 0)
        {
            _colorAlpha -= Time.deltaTime;
        }
    }

    public void PlayCredits()
    {
        _isActive = true;
        _isPressed = true;
        
        _videoPlayer.Play();
        AllMenusManager.Instance.CurrentMenu.IsActive = false;
        
        SoundManager.Instance.PlayMusic(SoundManager.Instance.Credits);
    }

    private void CheckEnter()
    {
        if (InputManager.Instance.Inputs.Select == false)
        {
            _isPressed = false;
        }
        
        if (_isPressed == false && InputManager.Instance.Inputs.Select)
        {
            _videoPlayer.Stop();
            _isActive = false;
            AllMenusManager.Instance.CurrentMenu.IsActive = true;
            
            SoundManager.Instance.PlayMusic(SoundManager.Instance.Music);
        }
    }
}
