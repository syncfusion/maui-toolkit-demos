using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAnalyticsDashboard
{
    public class SelectedColorConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return Color.FromArgb("#E0E0E0");
            return (bool)value ? Color.FromArgb("#512BD4") : Color.FromArgb("#E0E0E0");
        }

        public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedBackgroundConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return Colors.Transparent;
            return (bool)value ? Color.FromArgb("#512BD4").WithAlpha(0.1f) : Colors.Transparent;
        }

        public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectedTextColorConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            if(value == null)
                return Colors.Gray;
            return (bool)value ? Color.FromArgb("#512BD4") : Colors.Gray;
        }

        public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AchievementTypeColorConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return Colors.Gray;
            return (AchievementType)value switch
            {
                AchievementType.Project => Color.FromArgb("#FFFAEB"),
                AchievementType.Award => Color.FromArgb("#ECFDF3"),
                AchievementType.Innovation => Color.FromArgb("#FEF3F2"),
                AchievementType.Training => Color.FromArgb("#F9F5FF"),
                _ => Colors.Gray
            };
        }

        public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AchievementIconConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return "default_icon.png";
            return (AchievementType)value switch
            {
                AchievementType.Project => "project.png",
                AchievementType.Award => "award.png",
                AchievementType.Innovation => "innovation.png",
                AchievementType.Training => "project.png",
                _ => "default_icon.png"
            };
        }

        public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AchievementIconBackgroundConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return Colors.Gray.WithAlpha(0.2f);
            return (AchievementType)value switch
            {
                AchievementType.Project => Color.FromArgb("#F79009"),
                AchievementType.Award => Color.FromArgb("#079455"),
                AchievementType.Innovation => Color.FromArgb("#D92D20"),
                AchievementType.Training => Color.FromArgb("#7F56D9"),
                _ => Colors.Gray.WithAlpha(0.2f)
            };
        }

        public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AchievementStrokeConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return Colors.Gray.WithAlpha(0.2f);
            return (AchievementType)value switch
            {
                AchievementType.Project => Color.FromArgb("#FEDF89"),
                AchievementType.Award => Color.FromArgb("#ABEFC6"),
                AchievementType.Innovation => Color.FromArgb("#FECDCA"),
                AchievementType.Training => Color.FromArgb("#7F56D9"),
                _ => Colors.Gray.WithAlpha(0.2f)
            };
        }

        public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AchievementRippleColorConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return Colors.White.WithAlpha(0.3f);
            return (AchievementType)value switch
            {
                AchievementType.Project => Colors.White.WithAlpha(0.3f),
                AchievementType.Award => Colors.White.WithAlpha(0.3f),
                AchievementType.Innovation => Colors.White.WithAlpha(0.3f),
                AchievementType.Training => Colors.White.WithAlpha(0.3f),
                _ => Colors.White.WithAlpha(0.3f)
            };
        }

        public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AchievementHighlightColorConverter : IValueConverter
    {
        public object Convert(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return Colors.White.WithAlpha(0.1f);
            return (AchievementType)value switch
            {
                AchievementType.Project => Colors.White.WithAlpha(0.1f),
                AchievementType.Award => Colors.White.WithAlpha(0.1f),
                AchievementType.Innovation => Colors.White.WithAlpha(0.1f),
                AchievementType.Training => Colors.White.WithAlpha(0.1f),
                _ => Colors.White.WithAlpha(0.1f)
            };
        }

        public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
