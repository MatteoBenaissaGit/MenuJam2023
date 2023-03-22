using TMPro;
using UnityEngine;

namespace Buttons
{
    public abstract class MenuTextButton : MenuButton
    {
        [HideInInspector] public TMP_Text Text;

        protected virtual void Awake()
        {
            Text = GetComponent<TMP_Text>();
            if (Text == null)
            {
                Debug.LogError($"No TMP_Text in {gameObject.name}");
            }
        }
    }
}