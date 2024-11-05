using Syncfusion.Maui.Toolkit.Carousel;
using Syncfusion.Maui.Toolkit.EffectsView;
using Syncfusion.Maui.Toolkit.TextInputLayout;

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

    private void SfTextInputLayout_Focused(object sender, FocusEventArgs e)
    {
        if(sender is SfTextInputLayout textInputLayout)
        {
            textInputLayout.Hint = string.Empty;
        }
    }

    private void SfTextInputLayout_UnFocused(object sender, FocusEventArgs e)
    {
        if (sender is SfTextInputLayout textInputLayout)
        {
            if(textInputLayout.Content is Entry entry && string.IsNullOrEmpty(entry.Text))
            {
                textInputLayout.Hint = "Search by name or role";
            }
            
        }
    }
}