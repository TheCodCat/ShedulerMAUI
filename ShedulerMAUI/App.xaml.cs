namespace ShedulerMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());

            window.Width = 400;
            window.Height= 500;

            window.MaximumWidth = 400;
            window.MaximumHeight = 500;

            window.MinimumWidth = 400;
            window.MinimumHeight = 500;

            return window;
        }
    }
}