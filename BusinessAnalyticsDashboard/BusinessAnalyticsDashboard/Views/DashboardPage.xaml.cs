namespace BusinessAnalyticsDashboard;

public partial class DashboardPage : ContentView
{
	public DashboardPage()
	{
		InitializeComponent();
        BindingContext = new DashboardViewModel();
    }

    private void SfChart_SizeChanged(object sender, EventArgs e)
    {
        if (sender is View chart)
        {
            chart.HeightRequest = Math.Max(chart.Width - 200, 200);
        }
    }
}