using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class VerticalSubMenuOption : MenuManager
    {
        private void Awake()
        {
            MenuAsset.MenuImagesList = GetComponentsInChildren<Image>().ToList();
            MenuAsset.MenuTextList = GetComponentsInChildren<TMP_Text>().ToList();
        }

        protected override void Start()
        {
            base.Start();
            AppearTime = 0.1f;
            DisappearTime = 0.1f;
        }
    }
}