using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Validation;

public class DailyFrequencyValidator
{
    public static void Validate(DailyFrequency? frequency)
    {
        if (frequency == null)
            throw new ArgumentNullException("Argument can't be null");

        if (frequency.OccursOnceDaily)
        {
            if (frequency.StartTime != default || 
                frequency.EndTime != default || 
                frequency.DailyRepeatInterval != 0 || 
                frequency.Segment != TimeSegment.None)
                throw new ArgumentException("When OccursOnceDaily is true, StartTime, EndTime, DailyRepeatInterval, and Segment should be undefined.");

            if (frequency.OccursDailyAt == default)
                throw new ArgumentException("When OccursOnceDaily is true, OccursDailyAt should be set.");
        }
        else
        {
            if (frequency.OccursDailyAt != default)
                throw new ArgumentException("When OccursOnceDaily is false, OccursDailyAt should be undefined.");

            if (frequency.StartTime == default || 
                frequency.EndTime == default || 
                frequency.DailyRepeatInterval < 1 || 
                frequency.DailyRepeatInterval > 5 || 
                frequency.Segment == TimeSegment.None)
                throw new ArgumentException("When OccursOnceDaily is false, StartTime, EndTime, DailyRepeatInterval, and Segment should be set correctly.");
        }
    }
}
