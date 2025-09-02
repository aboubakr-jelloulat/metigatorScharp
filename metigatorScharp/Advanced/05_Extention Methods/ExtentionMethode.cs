using System;

namespace Advanced._05_Extention_Methods
{
    /// <summary>
    /// Contains extension methods for the DateTime type.
    /// Extension methods allow adding new functionality to existing types
    /// without modifying their original definition.
    /// </summary>
    internal static class ExtentionMethode
    {
        /// <summary>
        /// Checks if the given DateTime value falls on a weekend (Saturday or Sunday).
        /// </summary>
        /// <param name="value">The DateTime instance to check.</param>
        /// <returns>True if the date is Saturday or Sunday, otherwise false.</returns>
        public static bool IsWeekEnd(this DateTime value)
        {
            return value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Checks if the given DateTime value falls on a weekday (Monday to Friday).
        /// </summary>
        /// <param name="value">The DateTime instance to check.</param>
        /// <returns>True if the date is a weekday, otherwise false.</returns>
        public static bool IsWeekDay(this DateTime value)
        {
            return !IsWeekEnd(value);
        }
    }
}

