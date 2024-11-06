using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAnalyticsDashboard
{
    public class Model
    {
        public string? Month { get; set; }
        public double Value { get; set; }
    }

    public class SalesTargetData
    {
        public string? Category { get; set; }
        public double Value { get; set; }
    }

    public class CategorySalesData
    {
        public string? Category { get; set; }
        public double Value { get; set; }
    }

    public class SalesData
    {
        public string? Date { get; set; }
        public double Value { get; set; }
    }

    public class RegionalSalesData
    {
        public string? Region { get; set; }
        public double Value { get; set; }
    }

    public class ResponseTimeData
    {
        public string? Day { get; set; }
        public double Time { get; set; }
    }

    public class ChartData
    {
        public string? Category { get; set; }
        public string? Region { get; set; }
        public string? Stage { get; set; }
        public string? Month { get; set; }
        public double Value { get; set; }
    }

    public class FeedbackTrendData
    {
        public string? Month { get; set; }
        public double Rating { get; set; }
    }

    public class ChipItem
    {
        public string? Text { get; set; }
    }

    public class ProductData
    {
        public string? Name { get; set; }
        public double Revenue { get; set; }
        public double Growth { get; set; }
        public double Rating { get; set; }
        public List<ProductAttributeData>? Attributes { get; set; }
        public string? Image { get; set; }
    }

    public class ProductAttributeData
    {
        public string? Attribute { get; set; }
        public double Rating { get; set; }
    }

    public class SalesTrendData
    {
        public string? Period { get; set; }
        public double Sales { get; set; }
    }

    public class TeamAchievement
    {
        public string? Title { get; set; }
        public string? TeamMember { get; set; }
        public string? Description { get; set; }
        public AchievementType Type { get; set; }
        public DateTime Date { get; set; }
    }

    public class TeamPerformance
    {
        public string? Member { get; set; }
        public int Count { get; set; }
    }

    public enum AchievementType
    {
        Project,
        Award,
        Innovation,
        Training
    }
}
