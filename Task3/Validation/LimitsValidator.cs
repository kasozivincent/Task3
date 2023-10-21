using System;

namespace Task3.Validation;

public class LimitsValidator
{
    public static void Validate(Limits limits)
    {
        if (limits == null) throw new ArgumentNullException("Argument can't be null");
        if (limits.StartDate > limits.EndDate)
            throw new ArgumentException("Start date must be earlier or equal to end date");
    }
}
