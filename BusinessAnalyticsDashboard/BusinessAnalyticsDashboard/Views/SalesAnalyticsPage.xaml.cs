using Syncfusion.Maui.Toolkit.Charts;

namespace BusinessAnalyticsDashboard;

public partial class SalesAnalyticsPage : ContentView
{
	public SalesAnalyticsPage()
	{
		InitializeComponent();
        BindingContext = new SalesAnalyticsViewModel();
    }

    private void SfChart_SizeChanged(object sender, EventArgs e)
    {
        if (sender is View chart)
        {
            chart.HeightRequest = Math.Max(chart.Width - 200, 200);
        }
    }
}