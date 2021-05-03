using System;

namespace TicketManager.Extensions
{
    public static class EqualsExtensions
    {
        public static bool NotEquals<T>(this T value, T comparison)
        {
            return !value.Equals(comparison);
        }
    }
}
