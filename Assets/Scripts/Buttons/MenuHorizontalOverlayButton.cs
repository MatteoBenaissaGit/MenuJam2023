using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public class MenuHorizontalOverlayButton : MenuButton
    {
        [SerializeField] public Overlay Overlay;
        [SerializeField] private float _sizeMultiplier = 1.05f;

        private Vector3 _baseScale;
        

        private void Start()
        {
            Overlay.Fade(0, 0f);
            _baseScale = transform.localScale;
        }

        public void SetSelected()
        {
            Overlay.Fade(1, 0.5f);
            transform.DOComplete();
            transform.DOScale(_baseScale * _sizeMultiplier, 0.5f);
        }

        public void SetUnselected()
        {
            Overlay.Fade(0, 0.25f);
            transform.DOComplete();
            transform.DOScale(_baseScale, 0.25f);
        }
    }

    [Serializable]
    public struct Overlay
    {
        public Image OverlayImage;
        public Image OverlayEnter;
        public TMP_Text OverlayText;
        public bool ChangeColor;
        public Color SelectedColor;
        public Color BaseColor;

        public void Fade(float value, float time)
        {
            if (OverlayImage != null)
            {
                OverlayImage.DOComplete();
                OverlayImage.DOFade(value, time);
            }

            if (OverlayEnter != null)
            {
                OverlayEnter.DOComplete();
                OverlayEnter.DOFade(value, time);
            }

            if (OverlayText != null)
            {
                if (ChangeColor == false)
                {
                    OverlayText.DOComplete();
                    OverlayText.DOFade(value, time);
                }
                else
                {
                    OverlayText.color = value == 0 ? BaseColor : SelectedColor;
                }
            }
        }
    }
}
