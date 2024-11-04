using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BusinessAnalyticsDashboard
{
    public class SettingsViewModel : BindableObject
    {
        // Profile Settings
        private string? _userName;
        private string? _userEmail;
        private string? _userRole;

        // Display Settings
        private bool _showDataLabels;
        private bool _enableAnimations;
        private bool _darkMode;

        // Notification Settings
        private bool _emailNotifications;
        private bool _performanceAlerts;
        private bool _weeklyReports;

        // Data Settings
        private int _defaultTimePeriod;
        private int _autoRefreshInterval;

        public string? UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string? UserEmail
        {
            get => _userEmail;
            set
            {
                _userEmail = value;
                OnPropertyChanged();
            }
        }

        public string? UserRole
        {
            get => _userRole;
            set
            {
                _userRole = value;
                OnPropertyChanged();
            }
        }

        public bool ShowDataLabels
        {
            get => _showDataLabels;
            set
            {
                _showDataLabels = value;
                OnPropertyChanged();
            }
        }

        public bool EnableAnimations
        {
            get => _enableAnimations;
            set
            {
                _enableAnimations = value;
                OnPropertyChanged();
            }
        }

        public bool DarkMode
        {
            get => _darkMode;
            set
            {
                _darkMode = value;
                OnPropertyChanged();
                UpdateTheme();
            }
        }

        public bool EmailNotifications
        {
            get => _emailNotifications;
            set
            {
                _emailNotifications = value;
                OnPropertyChanged();
            }
        }

        public bool PerformanceAlerts
        {
            get => _performanceAlerts;
            set
            {
                _performanceAlerts = value;
                OnPropertyChanged();
            }
        }

        public bool WeeklyReports
        {
            get => _weeklyReports;
            set
            {
                _weeklyReports = value;
                OnPropertyChanged();
            }
        }

        public int DefaultTimePeriod
        {
            get => _defaultTimePeriod;
            set
            {
                _defaultTimePeriod = value;
                OnPropertyChanged();
            }
        }

        public int AutoRefreshInterval
        {
            get => _autoRefreshInterval;
            set
            {
                _autoRefreshInterval = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public SettingsViewModel()
        {
            LoadSettings();
            SaveCommand = new Command(SaveSettings);
        }

        private void LoadSettings()
        {
            // Load settings from preferences or default values
            UserName = Preferences.Get("UserName", "John Doe");
            UserEmail = Preferences.Get("UserEmail", "john.doe@example.com");
            UserRole = Preferences.Get("UserRole", "Administrator");
            ShowDataLabels = Preferences.Get("ShowDataLabels", true);
            EnableAnimations = Preferences.Get("EnableAnimations", true);
            DarkMode = Preferences.Get("DarkMode", false);
            EmailNotifications = Preferences.Get("EmailNotifications", true);
            PerformanceAlerts = Preferences.Get("PerformanceAlerts", true);
            WeeklyReports = Preferences.Get("WeeklyReports", true);
            DefaultTimePeriod = Preferences.Get("DefaultTimePeriod", 1);
            AutoRefreshInterval = Preferences.Get("AutoRefreshInterval", 1);
        }

        private void SaveSettings()
        {
            // Save settings to preferences
            Preferences.Set("UserName", UserName);
            Preferences.Set("UserEmail", UserEmail);
            Preferences.Set("UserRole", UserRole);
            Preferences.Set("ShowDataLabels", ShowDataLabels);
            Preferences.Set("EnableAnimations", EnableAnimations);
            Preferences.Set("DarkMode", DarkMode);
            Preferences.Set("EmailNotifications", EmailNotifications);
            Preferences.Set("PerformanceAlerts", PerformanceAlerts);
            Preferences.Set("WeeklyReports", WeeklyReports);
            Preferences.Set("DefaultTimePeriod", DefaultTimePeriod);
            Preferences.Set("AutoRefreshInterval", AutoRefreshInterval);

            Page? page = (IPlatformApplication.Current?.Application as Application)?.Windows[0].Page;
            if (page != null)
            {
                // Show success message
                page.DisplayAlert("Success", "Settings saved successfully", "OK");
            }
        }

        private void UpdateTheme()
        {
            // Implement theme switching logic here
            // You would typically update your app's resources/theme
            if (Application.Current != null)
            {
                ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
                if (mergedDictionaries != null)
                {
                    // Update theme resources based on dark mode setting
                }
            }
        }
    }
}
