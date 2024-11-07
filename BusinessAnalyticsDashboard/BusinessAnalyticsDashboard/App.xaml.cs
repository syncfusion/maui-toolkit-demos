namespace BusinessAnalyticsDashboard
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            this.UserAppTheme = AppTheme.Light;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage());
        }
    }
}