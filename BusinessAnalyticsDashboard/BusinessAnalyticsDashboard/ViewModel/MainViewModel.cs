using Syncfusion.Maui.Toolkit.NavigationDrawer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BusinessAnalyticsDashboard
{
    public class MainViewModel : BindableObject
    {
        private string _currentPage = "Overview";
        private View? _currentPageContent;
        private readonly SfNavigationDrawer _navigationDrawer;

        public string CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public View? CurrentPageContent
        {
            get => _currentPageContent;
            set
            {
                _currentPageContent = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateCommand { get; }

        public MainViewModel(SfNavigationDrawer navigationDrawer)
        {
            _navigationDrawer = navigationDrawer;
            NavigateCommand = new Command<string>(Navigate);
            // Initialize with Dashboard view
            CurrentPageContent = new DashboardPage();
        }

        private void Navigate(string page)
        {
            CurrentPage = page;
            CurrentPageContent = page switch
            {
                "Overview" => new DashboardPage(),
                "Sales Analytics" => new SalesAnalyticsPage(),
                "Customer Insights" => new CustomerInsightsPage(),
                "Product Performance" => new ProductPerformancePage(),
                "Team Metrics" => new TeamMetricsPage(),
                "Settings" => new SettingsPage(),
                _ => new DashboardPage()
            };

            // Close the drawer after navigation
            _navigationDrawer.IsOpen = false;
        }
    }
}
