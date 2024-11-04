
namespace BusinessAnalyticsDashboard
{
    public partial class MainPage : ContentPage
    {

        private MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainViewModel(navigationDrawer);
            BindingContext = _viewModel;
        }

        private void OnMenuButtonClicked(object sender, EventArgs e)
        {
            navigationDrawer.ToggleDrawer();
        }

    }

}
