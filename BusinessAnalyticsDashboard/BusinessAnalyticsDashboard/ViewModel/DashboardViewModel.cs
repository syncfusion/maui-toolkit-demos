using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAnalyticsDashboard
{
    public class DashboardViewModel : BindableObject
    {
        private List<Model>? _revenueData;
        private List<SalesTargetData>? _salesTargetData;
        private double _salesTargetProgress;

        public List<Model>? RevenueData
        {
            get => _revenueData;
            set
            {
                _revenueData = value;
                OnPropertyChanged();
            }
        }

        public List<SalesTargetData>? SalesTargetData
        {
            get => _salesTargetData;
            set
            {
                _salesTargetData = value;
                OnPropertyChanged();
            }
        }

        public double SalesTargetProgress
        {
            get => _salesTargetProgress;
            set
            {
                _salesTargetProgress = value;
                OnPropertyChanged();
            }
        }

        public DashboardViewModel()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            // Sample revenue data
            RevenueData = new List<Model>
            {
                new Model { Month = "Jan", Value = 1.8 },
                new Model { Month = "Feb", Value = 1.9 },
                new Model { Month = "Mar", Value = 1.85 },
                new Model { Month = "Apr", Value = 1.95 },
                new Model { Month = "May", Value = 2.2 },
                new Model { Month = "Jun", Value = 2.45 }
            };

            // Sample sales target progress
            SalesTargetProgress = 82.5;

            // Sales target data for doughnut chart
            SalesTargetData = new List<SalesTargetData>
            {
                new SalesTargetData { Category = "Achieved", Value = SalesTargetProgress },
            };
        }
    }
}
