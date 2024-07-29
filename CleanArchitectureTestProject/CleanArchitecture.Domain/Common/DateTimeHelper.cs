using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    public static class DateTimeHelper
    {
        public static DateOnly ReturnTodayDate = DateOnly.Parse(DateTime.UtcNow.ToShortDateString());

        public static TimeOnly ReturnCurrentTime = TimeOnly.Parse(DateTime.UtcNow.ToShortTimeString());
    }
}
