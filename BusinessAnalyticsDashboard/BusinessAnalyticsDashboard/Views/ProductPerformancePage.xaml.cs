namespace BusinessAnalyticsDashboard;

public partial class ProductPerformancePage : ContentView
{
	public ProductPerformancePage()
	{
		InitializeComponent();
        BindingContext = new ProductPerformanceViewModel();
    }
    private void OnTimePeriodChanged(object sender, Syncfusion.Maui.Toolkit.SegmentedControl.SelectionChangedEventArgs e)
    {
        if (BindingContext is ProductPerformanceViewModel viewModel && e.NewIndex is not null)
        {
            viewModel.SelectedTimePeriodIndex = (int)e.NewIndex;
        }
    }

    private void SfChart_SizeChanged(object sender, EventArgs e)
    {
        if (sender is View chart)
        {
            chart.HeightRequest = Math.Max(chart.Width - 200, 200);
        }
    }

}