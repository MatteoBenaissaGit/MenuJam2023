namespace Menu
{
    public class VerticalSubMenuOption : MenuManager
    {
        protected override void Start()
        {
            base.Start();
            AppearTime = 0.1f;
            DisappearTime = 0.1f;
        }
    }
}