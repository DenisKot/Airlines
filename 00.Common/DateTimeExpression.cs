namespace _00.Common
{
    using System;

    public static class DateTimeExpression
    {
        public static string ToDayMonthYear(this DateTime? dateTime)
        {
            return dateTime != null
                ? dateTime.Value.ToString("dd.MM.yyyy H:mm")
                : string.Empty;
        }
    }
}
