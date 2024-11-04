namespace BusinessAnalyticsDashboard;

public partial class DashboardPage : ContentView
{
	public DashboardPage()
	{
		InitializeComponent();
        BindingContext = new DashboardViewModel();
    }
}