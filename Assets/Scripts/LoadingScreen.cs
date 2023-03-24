using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Menu;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _icon;
    [SerializeField] private float _timer;

    private bool _isLoaded;

    private void Update()
    {
        _timer -= Time.deltaTime;
        
        _icon.transform.Rotate(0,0,1);

        if (_timer < 0 && _isLoaded == false)
        {
            _background.DOFade(0, 1f);
            _icon.DOFade(0, 1f);
            AllMenusManager.Instance.CurrentMenu.IsActive = true;
            _isLoaded = true;
            SoundManager.Instance.PlayMusic(SoundManager.Instance.Music);
        }
        else if (AllMenusManager.Instance.CurrentMenu != null && _isLoaded == false)
        {
            AllMenusManager.Instance.CurrentMenu.IsActive = false;
        }
    }
}
