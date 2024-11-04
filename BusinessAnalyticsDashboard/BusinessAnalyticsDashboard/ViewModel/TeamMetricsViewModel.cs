using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAnalyticsDashboard
{
    public class TeamMetricsViewModel : BindableObject
    {
        #region Private Fields
        private string? _searchText;
        private ObservableCollection<TeamAchievement>? _teamAchievements;
        private ObservableCollection<TeamAchievement>? _allAchievements;
        private ObservableCollection<TeamPerformance>? _tasksCompleted;
        private ObservableCollection<TeamPerformance>? _tasksInProgress;
        private int _totalMembers;
        private int _activeTasks;
        private double _completionRate;
        #endregion

        #region Public Properties
        public string? SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterAchievements();
            }
        }

        public ObservableCollection<TeamAchievement>? TeamAchievements
        {
            get => _teamAchievements;
            set
            {
                _teamAchievements = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TeamPerformance>? TasksCompleted
        {
            get => _tasksCompleted;
            set
            {
                _tasksCompleted = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TeamPerformance>? TasksInProgress
        {
            get => _tasksInProgress;
            set
            {
                _tasksInProgress = value;
                OnPropertyChanged();
            }
        }

        public int TotalMembers
        {
            get => _totalMembers;
            set
            {
                _totalMembers = value;
                OnPropertyChanged();
            }
        }

        public int ActiveTasks
        {
            get => _activeTasks;
            set
            {
                _activeTasks = value;
                OnPropertyChanged();
            }
        }

        public double CompletionRate
        {
            get => _completionRate;
            set
            {
                _completionRate = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public TeamMetricsViewModel()
        {
            InitializeData();
            CalculateStats();
        }
        #endregion

        #region Methods
        private void InitializeData()
        {
            // Initialize Achievements
            _allAchievements = new ObservableCollection<TeamAchievement>
            {
                new TeamAchievement
                {
                    Title = "Project Milestone Achieved",
                    TeamMember = "John Smith",
                    Description = "Successfully completed Phase 1 ahead of schedule",
                    Type = AchievementType.Project,
                    Date = DateTime.Now.AddDays(-2)
                },
                new TeamAchievement
                {
                    Title = "Client Satisfaction Award",
                    TeamMember = "Sarah Johnson",
                    Description = "Received outstanding feedback for customer support",
                    Type = AchievementType.Award,
                    Date = DateTime.Now.AddDays(-5)
                },
                new TeamAchievement
                {
                    Title = "Innovation Recognition",
                    TeamMember = "Mike Brown",
                    Description = "Implemented new automation system",
                    Type = AchievementType.Innovation,
                    Date = DateTime.Now.AddDays(-7)
                },
                new TeamAchievement
                {
                    Title = "Training Completion",
                    TeamMember = "Lisa Chen",
                    Description = "Completed advanced certification",
                    Type = AchievementType.Training,
                    Date = DateTime.Now.AddDays(-10)
                }
            };

            TeamAchievements = new ObservableCollection<TeamAchievement>(_allAchievements);

            // Initialize Performance Data
            TasksCompleted = new ObservableCollection<TeamPerformance>
            {
                new TeamPerformance { Member = "John", Count = 45 },
                new TeamPerformance { Member = "Sarah", Count = 38 },
                new TeamPerformance { Member = "Mike", Count = 42 },
                new TeamPerformance { Member = "Lisa", Count = 35 },
                new TeamPerformance { Member = "David", Count = 40 }
            };

            TasksInProgress = new ObservableCollection<TeamPerformance>
            {
                new TeamPerformance { Member = "John", Count = 12 },
                new TeamPerformance { Member = "Sarah", Count = 15 },
                new TeamPerformance { Member = "Mike", Count = 8 },
                new TeamPerformance { Member = "Lisa", Count = 10 },
                new TeamPerformance { Member = "David", Count = 11 }
            };
        }

        private void CalculateStats()
        {
            if(TasksCompleted is null)
                return;
            if(TasksInProgress is null) return;
            TotalMembers = TasksCompleted.Count;
            ActiveTasks = TasksInProgress.Sum(t => t.Count);

            int totalTasks = TasksCompleted.Sum(t => t.Count) + ActiveTasks;
            int completedTasks = TasksCompleted.Sum(t => t.Count);
            CompletionRate = totalTasks > 0 ? Math.Round((double)completedTasks / totalTasks * 100, 1) : 0;
        }

        private void FilterAchievements()
        {
            if (_allAchievements is null)
                return;
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                TeamAchievements = new ObservableCollection<TeamAchievement>(_allAchievements);
                return;
            }

            var filteredAchievements = _allAchievements
                .Where(a =>
                    a.Title!.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    a.TeamMember!.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    a.Description!.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            TeamAchievements = new ObservableCollection<TeamAchievement>(filteredAchievements);
        }

        public void HandleAchievementClick(TeamAchievement achievement)
        {
            Page? page = (IPlatformApplication.Current?.Application as Application)?.Windows[0].Page;
            // Show achievement details or perform actions
            if (page is not null)
            {
                page.DisplayAlert(
                    achievement.Title,
                    $"Team Member: {achievement.TeamMember}\n" +
                    $"Date: {achievement.Date:MMM dd, yyyy}\n\n" +
                    achievement.Description,
                    "Close"
                );
            }
        }

        public void RefreshData()
        {
            InitializeData();
            CalculateStats();
            FilterAchievements();
        }
        #endregion
    }
}
