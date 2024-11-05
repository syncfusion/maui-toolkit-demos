namespace BusinessAnalyticsDashboard;

public partial class CustomerInsightsPage : ContentView
{
	public CustomerInsightsPage()
	{
		InitializeComponent();
        BindingContext = new CustomerInsightsViewModel();
    }

    private void SfChart_SizeChanged(object sender, EventArgs e)
    {
        if (sender is View chart)
        {
            chart.HeightRequest = Math.Max(chart.Width - 200, 200);
        }
    }
}