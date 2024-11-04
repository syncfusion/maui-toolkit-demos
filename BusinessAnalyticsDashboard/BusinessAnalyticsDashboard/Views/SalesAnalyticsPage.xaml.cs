namespace BusinessAnalyticsDashboard;

public partial class SalesAnalyticsPage : ContentView
{
	public SalesAnalyticsPage()
	{
		InitializeComponent();
        BindingContext = new SalesAnalyticsViewModel();
    }
}