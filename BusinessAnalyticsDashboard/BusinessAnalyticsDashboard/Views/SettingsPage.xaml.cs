namespace BusinessAnalyticsDashboard;

public partial class SettingsPage : ContentView
{
	public SettingsPage()
	{
		InitializeComponent();
        BindingContext = new SettingsViewModel();
    }
}