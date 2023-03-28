using DG.Tweening;

namespace Buttons
{
    public class MenuVerticalButtonTextController : MenuTextButton
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public override void PressButton()
        {
            base.PressButton();

            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveX(transform.position.x - 3f, 0.05f).SetEase(Ease.Linear));
            sequence.Append(transform.DOMoveX(transform.position.x, 0.05f).SetEase(Ease.OutCubic));
            sequence.Play();
        }
    }
}
