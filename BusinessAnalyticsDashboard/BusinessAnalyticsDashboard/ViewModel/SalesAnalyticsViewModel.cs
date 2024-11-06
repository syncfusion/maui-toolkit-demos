using System.Windows.Input;

namespace BusinessAnalyticsDashboard
{
    public class SalesAnalyticsViewModel : BindableObject
    {
        private bool _isLoading;
        private bool _isRefreshing;
        private int _selectedPeriodIndex;
        private List<CategorySalesData>? _categorySales;
        private List<SalesData>? _currentPeriodSales;
        private List<SalesData>? _previousPeriodSales;
        private List<RegionalSalesData>? _regionalSales;
        private List<ProductPerformanceData>? _productPerformance;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public int SelectedPeriodIndex
        {
            get => _selectedPeriodIndex;
            set
            {
                if (_selectedPeriodIndex != value)
                {
                    _selectedPeriodIndex = value;
                    OnPropertyChanged();
                    UpdateChartData();
                }
            }
        }

        public List<CategorySalesData>? CategorySales
        {
            get => _categorySales;
            set
            {
                _categorySales = value;
                OnPropertyChanged();
            }
        }

        public List<SalesData>? CurrentPeriodSales
        {
            get => _currentPeriodSales;
            set
            {
                _currentPeriodSales = value;
                OnPropertyChanged();
            }
        }

        public List<SalesData>? PreviousPeriodSales
        {
            get => _previousPeriodSales;
            set
            {
                _previousPeriodSales = value;
                OnPropertyChanged();
            }
        }

        public List<RegionalSalesData>? RegionalSales
        {
            get => _regionalSales;
            set
            {
                _regionalSales = value;
                OnPropertyChanged();
            }
        }

        public List<ProductPerformanceData>? ProductPerformance
        {
            get => _productPerformance;
            set
            {
                _productPerformance = value;
                OnPropertyChanged();
                UpdateProductPerformanceData();
            }
        }

        public ICommand RefreshCommand { get; }

        public SalesAnalyticsViewModel()
        {
            RefreshCommand = new Command(async () => await RefreshData());
            IsLoading = true;
            LoadInitialData();
        }

        private async void LoadInitialData()
        {
            try
            {
                await Task.Delay(2000); // Simulate initial loading
                LoadData();
            }
            catch (Exception ex)
            {
                await HandleError(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task RefreshData()
        {
            if (IsRefreshing)
                return;

            try
            {
                IsRefreshing = true;
                await Task.Delay(1500); // Simulate network delay
                LoadData();
            }
            catch (Exception ex)
            {
                await HandleError(ex);
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private void LoadData()
        {
            // Load Category Sales Data
            CategorySales = new List<CategorySalesData>
            {
                new CategorySalesData { Category = "Electronics", Value = 4.5 },
                new CategorySalesData { Category = "Clothing", Value = 3.2 },
                new CategorySalesData { Category = "Books", Value = 1.5 },
                new CategorySalesData { Category = "Home", Value = 2.8 },
                new CategorySalesData { Category = "Sports", Value = 2.2 }
            };

            // Load Current Period Sales Data
            CurrentPeriodSales = new List<SalesData>
            {
                new SalesData { Date = "Mon", Value = 1.2 },
                new SalesData { Date = "Tue", Value = 1.5 },
                new SalesData { Date = "Wed", Value = 1.5 },
                new SalesData { Date = "Thu", Value = 1.35 },
                new SalesData { Date = "Fri", Value = 1.6 },
                new SalesData { Date = "Sat", Value = 1.8 },
                new SalesData { Date = "Sun", Value = 1.55 }
            };

            // Load Previous Period Sales Data
            PreviousPeriodSales = new List<SalesData>
            {
                new SalesData { Date = "Mon", Value = 1.1 },
                new SalesData { Date = "Tue", Value = 1.3 },
                new SalesData { Date = "Wed", Value = 1.4 },
                new SalesData { Date = "Thu", Value = 1.25 },
                new SalesData { Date = "Fri", Value = 1.5 },
                new SalesData { Date = "Sat", Value = 1.7 },
                new SalesData { Date = "Sun", Value = 1.45 }
            };

            // Load Regional Sales Data
            RegionalSales = new List<RegionalSalesData>
            {
                new RegionalSalesData { Region = "North", Value = 2.85 },
                new RegionalSalesData { Region = "South", Value = 2.45 },
                new RegionalSalesData { Region = "East", Value = 2.65 },
                new RegionalSalesData { Region = "West", Value = 2.55 }
            };

            // Load Product Performance Data
            // Updated Product Performance Data with more detailed information
            ProductPerformance = new List<ProductPerformanceData>
            {
                new ProductPerformanceData
                {
                    Product = "Laptop Pro",
                    Revenue = 4.5,
                    UnitsSold = 150,
                    GrowthRate = 12.5,
                    Rating = 4.5
                },
                new ProductPerformanceData
                {
                    Product = "SmartPhone X",
                    Revenue = 3.8,
                    UnitsSold = 200,
                    GrowthRate = 15.2,
                    Rating = 4.3
                },
                new ProductPerformanceData
                {
                    Product = "Tablet Air",
                    Revenue = 5.2,
                    UnitsSold = 180,
                    GrowthRate = 8.7,
                    Rating = 4.7
                },
                new ProductPerformanceData
                {
                    Product = "Smart Watch",
                    Revenue = 3.2,
                    UnitsSold = 250,
                    GrowthRate = 18.3,
                    Rating = 4.2
                },
                new ProductPerformanceData
                {
                    Product = "Wireless Buds",
                    Revenue = 4.8,
                    UnitsSold = 300,
                    GrowthRate = 22.1,
                    Rating = 4.6
                }
            };
        }

        private async void UpdateChartData()
        {
            IsLoading = true;
            try
            {
                // Simulate data loading for different time periods
                await Task.Delay(1000);

                // Apply different data modifications based on selected period
                var random = new Random();
                var modifier = (SelectedPeriodIndex + 1) * 0.1;

                // Update each dataset with the modifier
                CategorySales = CategorySales?.Select(x => new CategorySalesData
                {
                    Category = x.Category,
                    Value = x.Value * (1 + modifier + random.NextDouble() * 0.1)
                }).ToList();

                CurrentPeriodSales = CurrentPeriodSales?.Select(x => new SalesData
                {
                    Date = x.Date,
                    Value = x.Value * (1 + modifier + random.NextDouble() * 0.1)
                }).ToList();

                PreviousPeriodSales = PreviousPeriodSales?.Select(x => new SalesData
                {
                    Date = x.Date,
                    Value = x.Value * (1 + modifier + random.NextDouble() * 0.1)
                }).ToList();

                RegionalSales = RegionalSales?.Select(x => new RegionalSalesData
                {
                    Region = x.Region,
                    Value = x.Value * (1 + modifier + random.NextDouble() * 0.1)
                }).ToList();

                ProductPerformance = ProductPerformance?.Select(x => new ProductPerformanceData
                {
                    Product = x.Product,
                    Revenue = x.Revenue * (1 + modifier + random.NextDouble() * 0.1)
                }).ToList();
            }
            catch (Exception ex)
            {
                await HandleError(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void UpdateProductPerformanceData()
        {
            if (ProductPerformance is null) return;
            var random = new Random();
            foreach (var product in ProductPerformance)
            {
                // Simulate realistic changes in product performance
                product.Revenue *= (1 + (random.NextDouble() * 0.2 - 0.1)); // ±10% change
                product.UnitsSold += random.Next(-20, 21); // ±20 units
                product.GrowthRate += (random.NextDouble() * 4 - 2); // ±2% change
                product.Rating = Math.Min(5.0, Math.Max(1.0, product.Rating + (random.NextDouble() * 0.4 - 0.2))); // ±0.2 rating
            }
        }


        private async Task HandleError(Exception ex)
        {
            // Log the error (implement proper logging)
            System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            Page? page = (IPlatformApplication.Current?.Application as Application)?.Windows[0].Page;
            // Show error message to user
            if (page is not null)
            {
                await page.DisplayAlert(
                    "Error",
                    "Failed to load sales data. Please try again.",
                    "OK"
                );
            }
        }
    }

    public class ProductPerformanceData
    {
        public string? Product { get; set; }
        public double Revenue { get; set; }
        public int UnitsSold { get; set; }
        public double GrowthRate { get; set; }
        public double Rating { get; set; }

        // Calculated properties for additional insights
        public double AverageRevenuePerUnit => Revenue / UnitsSold;
        public string PerformanceCategory
        {
            get
            {
                if (GrowthRate >= 15) return "High Growth";
                if (GrowthRate >= 5) return "Moderate Growth";
                if (GrowthRate >= 0) return "Stable";
                return "Declining";
            }
        }
    }

}
