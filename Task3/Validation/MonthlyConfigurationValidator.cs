using System;

namespace Task3.Validation
{
    public class MonthlyConfigurationValidator
    {
        public static void Validate(MonthlyConfiguration? configuration)
        {
            if (configuration == null) throw new ArgumentNullException("Argument can't be null");
            if (configuration.IsDayOfMonth)
                ValidateDayOfMonthConfiguration(configuration);
            else
                ValidateNonDayOfMonthConfiguration(configuration);
        }

        private static void ValidateDayOfMonthConfiguration(MonthlyConfiguration configuration)
        {
            if (configuration.NumberOfMonths < 1 || configuration.NumberOfMonths > 10)
                throw new ArgumentException("NumberOfMonths should be an integer between 1 and 10.");

            if (configuration.DayOfMonth < 1 || configuration.DayOfMonth > 31)
                throw new ArgumentException("DayOfMonth should be an integer between 1 and 31.");

            if (configuration.Position != default(Position))
                throw new ArgumentException("Position should not be set when IsDayOfMonth is true.");

            if (configuration.Day != default(Day))
                throw new ArgumentException("Day should not be set when IsDayOfMonth is true.");
        }

        private static void ValidateNonDayOfMonthConfiguration(MonthlyConfiguration configuration)
        {
            if (configuration.DayOfMonth != default(int))
                throw new ArgumentException("DayOfMonth should not be set when IsDayOfMonth is false.");

            if (configuration.Position == default(Position))
                throw new ArgumentException("Position should be set when IsDayOfMonth is false.");

            if (configuration.Day == default(Day))
                throw new ArgumentException("Day should be set when IsDayOfMonth is false.");

            if (configuration.NumberOfMonths < 1 || configuration.NumberOfMonths > 10)
                throw new ArgumentException("NumberOfMonths should be an integer between 1 and 10.");
            
        }
    }
}
