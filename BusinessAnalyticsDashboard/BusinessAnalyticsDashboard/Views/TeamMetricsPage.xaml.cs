using Syncfusion.Maui.Toolkit.Carousel;
using Syncfusion.Maui.Toolkit.EffectsView;

namespace BusinessAnalyticsDashboard;

public partial class TeamMetricsPage : ContentView
{
    private readonly TeamMetricsViewModel _viewModel;

    public TeamMetricsPage()
	{
		InitializeComponent();
        _viewModel = new TeamMetricsViewModel();
        BindingContext = _viewModel;
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        _viewModel.SearchText = e.NewTextValue;
    }

    private void OnAchievementClicked(object sender, TappedEventArgs e)
    {
        if (sender is SfEffectsView effectsView &&
            effectsView.BindingContext is TeamAchievement achievement)
        {
            _viewModel.HandleAchievementClick(achievement);
            effectsView.ScaleFactor = 1;
        }
    }

}