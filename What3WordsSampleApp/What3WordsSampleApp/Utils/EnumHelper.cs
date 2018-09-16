using System;
using System.Collections.Generic;
using System.Linq;

namespace What3WordsSampleApp.Utils
{
    public static class EnumHelper
    {
        public static IEnumerable<T> GetEnumAsEnumarable<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
