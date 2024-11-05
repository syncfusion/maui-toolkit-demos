using System.Collections.ObjectModel;

namespace BusinessAnalyticsDashboard;

public partial class ChartColorResources : ResourceDictionary
{
	public ChartColorResources()
	{
		InitializeComponent();
	}
}

public class ChartColorModel : ObservableCollection<Brush>
{

}