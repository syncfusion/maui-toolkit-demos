namespace BusinessAnalyticsDashboard
{
    public class CustomerInsightsViewModel : BindableObject
    {
        #region Private Fields
        private List<ChipItem>? _filterOptions;
        private ChipItem? _selectedFilter;
        private List<ChartData>? _ageDistribution;
        private List<ChartData>? _geographicDistribution;
        private List<ChartData>? _customerJourney;
        private List<ChartData>? _purchaseFrequency;
        private List<ChartData>? _customerSatisfaction;
        private List<FeedbackTrendData>? _feedbackTrends;

        // Original data storage for reset purposes
        private readonly List<ChartData>? _originalAgeDistribution;
        private readonly List<ChartData>? _originalGeographicDistribution;
        private readonly List<ChartData>? _originalCustomerJourney;
        private readonly List<ChartData>? _originalPurchaseFrequency;
        private readonly List<ChartData>? _originalCustomerSatisfaction;
        private readonly List<FeedbackTrendData>? _originalFeedbackTrends;
        #endregion

        #region Public Properties
        public List<ChipItem>? FilterOptions
        {
            get => _filterOptions;
            set
            {
                _filterOptions = value;
                OnPropertyChanged();
            }
        }

        public ChipItem? SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                if (_selectedFilter != value)
                {
                    _selectedFilter = value;
                    OnPropertyChanged();
                    if (_selectedFilter != null)
                    {
                        UpdateDataBasedOnFilter(_selectedFilter.Text);
                    }
                }
            }
        }

        public List<ChartData>? AgeDistribution
        {
            get => _ageDistribution;
            set
            {
                _ageDistribution = value;
                OnPropertyChanged();
            }
        }

        public List<ChartData>? GeographicDistribution
        {
            get => _geographicDistribution;
            set
            {
                _geographicDistribution = value;
                OnPropertyChanged();
            }
        }

        public List<ChartData>? CustomerJourney
        {
            get => _customerJourney;
            set
            {
                _customerJourney = value;
                OnPropertyChanged();
            }
        }

        public List<ChartData>? PurchaseFrequency
        {
            get => _purchaseFrequency;
            set
            {
                _purchaseFrequency = value;
                OnPropertyChanged();
            }
        }

        public List<ChartData>? CustomerSatisfaction
        {
            get => _customerSatisfaction;
            set
            {
                _customerSatisfaction = value;
                OnPropertyChanged();
            }
        }

        public List<FeedbackTrendData>? FeedbackTrends
        {
            get => _feedbackTrends;
            set
            {
                _feedbackTrends = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public CustomerInsightsViewModel()
        {
            InitializeData();
            if (AgeDistribution == null) return;
            if (GeographicDistribution == null) return;
            if (CustomerJourney == null) return;
            if (CustomerSatisfaction == null) return;
            if (PurchaseFrequency == null) return;
            if (FeedbackTrends == null) return;

            // Store original data for reset
            _originalAgeDistribution = new List<ChartData>(AgeDistribution);
            _originalGeographicDistribution = new List<ChartData>(GeographicDistribution);
            _originalCustomerJourney = new List<ChartData>(CustomerJourney);
            _originalPurchaseFrequency = new List<ChartData>(PurchaseFrequency);
            _originalCustomerSatisfaction = new List<ChartData>(CustomerSatisfaction);
            _originalFeedbackTrends = new List<FeedbackTrendData>(FeedbackTrends);

            InitializeFilterOptions();



        }
        #endregion

        #region Private Methods
        private void InitializeFilterOptions()
        {
            FilterOptions = new List<ChipItem>
            {
                new ChipItem { Text = "All" },
                new ChipItem { Text = "Premium" },
                new ChipItem { Text = "Standard" },
                new ChipItem { Text = "Basic" }
            };

            // Set default selected filter
            SelectedFilter = FilterOptions[0];
        }

        private void InitializeData()
        {
            // Age Distribution Data
            AgeDistribution = new List<ChartData>
            {
                new ChartData { Category = "18-24", Value = 15 },
                new ChartData { Category = "25-34", Value = 30 },
                new ChartData { Category = "35-44", Value = 25 },
                new ChartData { Category = "45-54", Value = 20 },
                new ChartData { Category = "55+", Value = 10 }
            };

            // Geographic Distribution Data
            GeographicDistribution = new List<ChartData>
            {
                new ChartData { Region = "North", Value = 2500 },
                new ChartData { Region = "South", Value = 3000 },
                new ChartData { Region = "East", Value = 2800 },
                new ChartData { Region = "West", Value = 3200 }
            };

            // Customer Journey Data
            CustomerJourney = new List<ChartData>
            {
                new ChartData { Stage = "Leads", Value = 1000 },
                new ChartData { Stage = "Prospects", Value = 750 },
                new ChartData { Stage = "Qualified", Value = 500 },
                new ChartData { Stage = "Customers", Value = 250 }
            };

            // Purchase Frequency Data
            PurchaseFrequency = new List<ChartData>
            {
                new ChartData { Month = "Jan", Value = 150 },
                new ChartData { Month = "Feb", Value = 180 },
                new ChartData { Month = "Mar", Value = 160 },
                new ChartData { Month = "Apr", Value = 200 },
                new ChartData { Month = "May", Value = 220 },
                new ChartData { Month = "Jun", Value = 190 }
            };

            // Customer Satisfaction Data
            CustomerSatisfaction = new List<ChartData>
            {
                new ChartData { Category = "Very Satisfied", Value = 45 },
                new ChartData { Category = "Satisfied", Value = 25 },
                new ChartData { Category = "Neutral", Value = 15 },
                new ChartData { Category = "Dissatisfied", Value = 10 },
                new ChartData { Category = "Very Dissatisfied", Value = 5 }
            };

            // Feedback Trends Data
            FeedbackTrends = new List<FeedbackTrendData>
            {
                new FeedbackTrendData { Month = "Jan", Rating = 4.2 },
                new FeedbackTrendData { Month = "Feb", Rating = 4.3 },
                new FeedbackTrendData { Month = "Mar", Rating = 4.1 },
                new FeedbackTrendData { Month = "Apr", Rating = 4.4 },
                new FeedbackTrendData { Month = "May", Rating = 4.5 },
                new FeedbackTrendData { Month = "Jun", Rating = 4.6 }
            };
        }

        private void UpdateDataBasedOnFilter(string? filter)
        {
            if (_originalAgeDistribution == null) return;
            if (_originalGeographicDistribution == null) return;
            if (_originalCustomerSatisfaction == null) return;
            if (_originalCustomerJourney == null) return;
            if (_originalPurchaseFrequency == null) return;
            if (_originalFeedbackTrends == null) return;
            if (filter == "All")
            {
                // Reset to original data
                AgeDistribution = new List<ChartData>(_originalAgeDistribution);
                GeographicDistribution = new List<ChartData>(_originalGeographicDistribution);
                CustomerJourney = new List<ChartData>(_originalCustomerJourney);
                PurchaseFrequency = new List<ChartData>(_originalPurchaseFrequency);
                CustomerSatisfaction = new List<ChartData>(_originalCustomerSatisfaction);
                FeedbackTrends = new List<FeedbackTrendData>(_originalFeedbackTrends);
                return;
            }

            var random = new Random();
            double modifier = filter switch
            {
                "Premium" => 1.2,
                "Standard" => 1.0,
                "Basic" => 0.8,
                _ => 1.0
            };

            // Update all datasets with the modifier
            UpdateDatasets(modifier, random);
        }

        private void UpdateDatasets(double modifier, Random random)
        {
            // Update Age Distribution
            AgeDistribution = _originalAgeDistribution?.Select(x => new ChartData
            {
                Category = x.Category,
                Value = Math.Round(x.Value * modifier * (0.9 + random.NextDouble() * 0.2))
            }).ToList();

            // Update Geographic Distribution
            GeographicDistribution = _originalGeographicDistribution?.Select(x => new ChartData
            {
                Region = x.Region,
                Value = Math.Round(x.Value * modifier * (0.9 + random.NextDouble() * 0.2))
            }).ToList();

            // Update Customer Journey
            CustomerJourney = _originalCustomerJourney?.Select(x => new ChartData
            {
                Stage = x.Stage,
                Value = Math.Round(x.Value * modifier * (0.9 + random.NextDouble() * 0.2))
            }).ToList();

            // Update Purchase Frequency
            PurchaseFrequency = _originalPurchaseFrequency?.Select(x => new ChartData
            {
                Month = x.Month,
                Value = Math.Round(x.Value * modifier * (0.9 + random.NextDouble() * 0.2))
            }).ToList();

            // Update Customer Satisfaction
            CustomerSatisfaction = _originalCustomerSatisfaction?.Select(x => new ChartData
            {
                Category = x.Category,
                Value = Math.Round(x.Value * modifier * (0.9 + random.NextDouble() * 0.2))
            }).ToList();

            // Update Feedback Trends
            FeedbackTrends = _originalFeedbackTrends?.Select(x => new FeedbackTrendData
            {
                Month = x.Month,
                Rating = Math.Min(5, x.Rating * modifier * (0.95 + random.NextDouble() * 0.1))
            }).ToList();
        }
        #endregion
    }
}
