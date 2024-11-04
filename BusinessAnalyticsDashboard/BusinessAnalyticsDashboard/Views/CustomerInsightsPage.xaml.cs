namespace BusinessAnalyticsDashboard;

public partial class CustomerInsightsPage : ContentView
{
	public CustomerInsightsPage()
	{
		InitializeComponent();
        BindingContext = new CustomerInsightsViewModel();
    }

}