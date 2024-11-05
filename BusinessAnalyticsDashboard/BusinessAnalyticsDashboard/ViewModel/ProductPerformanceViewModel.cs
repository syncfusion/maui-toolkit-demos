using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAnalyticsDashboard
{
    public class ProductPerformanceViewModel : BindableObject
    {
        #region Private Fields
        private int _selectedTimePeriodIndex;
        private List<string>? _timePeriods;
        private int _selectedProductIndex;
        private List<ProductData>? _topProducts;
        private List<ProductAttributeData>? _selectedProductAttributes;
        private List<SalesTrendData>? _salesTrend;
        private Dictionary<int, List<SalesTrendData>> _periodSalesCache;
        #endregion

        #region Public Properties
        public List<string>? TimePeriods
        {
            get => _timePeriods;
            set
            {
                _timePeriods = value;
                OnPropertyChanged();
            }
        }

        public int SelectedTimePeriodIndex
        {
            get => _selectedTimePeriodIndex;
            set
            {
                if (_selectedTimePeriodIndex != value)
                {
                    _selectedTimePeriodIndex = value;
                    OnPropertyChanged();
                    UpdateDataForTimePeriod();
                }
            }
        }

        public int SelectedProductIndex
        {
            get => _selectedProductIndex;
            set
            {
                if (_selectedProductIndex != value)
                {
                    _selectedProductIndex = value;
                    OnPropertyChanged();
                    UpdateSelectedProductData();
                }
            }
        }

        public List<ProductData>? TopProducts
        {
            get => _topProducts;
            set
            {
                _topProducts = value;
                OnPropertyChanged();
            }
        }

        public List<ProductAttributeData>? SelectedProductAttributes
        {
            get => _selectedProductAttributes;
            set
            {
                _selectedProductAttributes = value;
                OnPropertyChanged();
            }
        }

        public List<SalesTrendData>? SalesTrend
        {
            get => _salesTrend;
            set
            {
                _salesTrend = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public ProductPerformanceViewModel()
        {
            InitializeTimePeriods();
            _periodSalesCache = new Dictionary<int, List<SalesTrendData>>();
            InitializeData();
        }
        #endregion

        #region Private Methods

        private void InitializeTimePeriods()
        {
            TimePeriods = new List<string>
        {
            "Day",
            "Week",
            "Month",
            "Year"
        };
        }

        private void InitializeData()
        {
            // Initialize Top Products
            TopProducts = new List<ProductData>
            {
                new ProductData
                {
                    Image = "mac.png",
                    Name = "MacBook Pro Notebook Z0GP-0002",
                    Revenue = 1250000,
                    Growth = 15.5,
                    Rating = 4.8,
                    Attributes = new List<ProductAttributeData>
                    {
                        new ProductAttributeData { Attribute = "Quality", Rating = 4.8, },
                        new ProductAttributeData { Attribute = "Price", Rating = 4.2 },
                        new ProductAttributeData { Attribute = "Features", Rating = 4.9 },
                        new ProductAttributeData { Attribute = "Design", Rating = 4.7 },
                        new ProductAttributeData { Attribute = "Support", Rating = 4.5 }
                    }
                },
                new ProductData
                {
                    Image = "watch.png",
                    Name = "Apple Watch fk88, 1.78 inch HD, Blue ",
                    Revenue = 980000,
                    Growth = 12.3,
                    Rating = 4.7,
                    Attributes = new List<ProductAttributeData>
                    {
                        new ProductAttributeData { Attribute = "Quality", Rating = 4.9, },
                        new ProductAttributeData { Attribute = "Price", Rating = 4.0 },
                        new ProductAttributeData { Attribute = "Features", Rating = 4.8 },
                        new ProductAttributeData { Attribute = "Design", Rating = 4.9 },
                        new ProductAttributeData { Attribute = "Support", Rating = 4.6 }
                    }
                },
                new ProductData
                {
                    Image = "iphone.png",
                    Name = "iPhone 13 Pro Max 256GB Storage,White",
                    Revenue = 450000,
                    Growth = 18.7,
                    Rating = 4.6,
                    Attributes = new List<ProductAttributeData>
                    {
                        new ProductAttributeData { Attribute = "Quality", Rating = 4.6 },
                        new ProductAttributeData { Attribute = "Price", Rating = 4.3 },
                        new ProductAttributeData { Attribute = "Features", Rating = 4.7 },
                        new ProductAttributeData { Attribute = "Design", Rating = 4.8 },
                        new ProductAttributeData { Attribute = "Support", Rating = 4.4 }
                    }
                },
                new ProductData
                {
                    Image = "earbuds.png",
                    Name = "Apple AirPods (2nd Generation) ",
                    Revenue = 820000,
                    Growth = 14.2,
                    Rating = 4.5,
                    Attributes = new List<ProductAttributeData>
                    {
                        new ProductAttributeData { Attribute = "Quality", Rating = 4.7 },
                        new ProductAttributeData { Attribute = "Price", Rating = 4.4 },
                        new ProductAttributeData { Attribute = "Features", Rating = 4.6 },
                        new ProductAttributeData { Attribute = "Design", Rating = 4.8 },
                        new ProductAttributeData { Attribute = "Support", Rating = 4.5 }
                    }
                },
                new ProductData
                {
                    Image = "tab.png",
                    Name = "Apple iPad Air 10.9\" 256GB in Starlight",
                    Revenue = 680000,
                    Growth = 16.8,
                    Rating = 4.4,
                    Attributes = new List<ProductAttributeData>
                    {
                        new ProductAttributeData { Attribute = "Quality", Rating = 4.5 },
                        new ProductAttributeData { Attribute = "Price", Rating = 4.1 },
                        new ProductAttributeData { Attribute = "Features", Rating = 4.8 },
                        new ProductAttributeData { Attribute = "Design", Rating = 4.6 },
                        new ProductAttributeData { Attribute = "Support", Rating = 4.3 }
                    }
                }
            };

            // Set initial selected product attributes
            UpdateSelectedProductData();

            // Initialize Sales Trend for default time period
            UpdateDataForTimePeriod();
        }

        private void UpdateSelectedProductData()
        {
            if (TopProducts != null && TopProducts.Count > SelectedProductIndex)
            {
                SelectedProductAttributes = TopProducts[SelectedProductIndex].Attributes;
                UpdateDataForTimePeriod(); // Refresh sales data for selected product
            }
        }

        private void UpdateDataForTimePeriod()
        {
            // Check if data is cached
            if (_periodSalesCache.ContainsKey(SelectedTimePeriodIndex))
            {
                SalesTrend = _periodSalesCache[SelectedTimePeriodIndex];
                return;
            }

            if(TimePeriods is null) return;
            var periods = TimePeriods[SelectedTimePeriodIndex] switch
            {
                "Day" => new[] { "12AM", "4AM", "8AM", "12PM", "4PM", "8PM" },
                "Week" => new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" },
                "Month" => new[] { "Week 1", "Week 2", "Week 3", "Week 4" },
                "Year" => new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" },
                _ => new[] { "12AM", "4AM", "8AM", "12PM", "4PM", "8PM" }
            };

            var random = new Random();
            if(TopProducts is null) return ;
            var baseValue = TopProducts[SelectedProductIndex].Revenue / (periods.Length * 2);
            var variance = baseValue * 0.3; // 30% variance

            var trendData = periods.Select(p => new SalesTrendData
            {
                Period = p,
                Sales = baseValue + random.NextDouble() * variance - (variance / 2)
            }).ToList();

            // Cache the generated data
            _periodSalesCache[SelectedTimePeriodIndex] = trendData;
            SalesTrend = trendData;
        }
        #endregion
    }    
}
