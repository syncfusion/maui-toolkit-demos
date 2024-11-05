namespace BusinessAnalyticsDashboard;

public partial class CustomerInsightsPage : ContentView
{    
	public CustomerInsightsPage()
	{
		InitializeComponent();
        BindingContext = new CustomerInsightsViewModel();
    }
#if WINDOWS || MACCATALYST
   
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if(width != -1)
        {
            UpdateTabHeaderPadding(width);
        }
    }

    private void UpdateTabHeaderPadding(double width)
    {
        double totalTabWidth = 0;
        foreach (var tabItem in tabView.Items)
        {
            if (tabItem is Syncfusion.Maui.Toolkit.TabView.SfTabItem tabItemView)
            {
                totalTabWidth += tabItemView.Measure(double.PositiveInfinity, double.PositiveInfinity).Width;
            }
        }
        double remainingSpace = ((width - totalTabWidth));

        double padding = (remainingSpace / 2);

        tabView.TabHeaderPadding = new Thickness(padding, 0, 0, 0);
    }
#endif
}