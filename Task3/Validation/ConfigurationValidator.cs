using System;

namespace Task3.Validation;

public class ConfigurationValidator
{
    public static void Validate(Configuration configuration)
    {
        if (configuration == null) 
            throw new ArgumentNullException("Argument can't be null");
        
        if (configuration.Type == AppointmentType.Once)
        {
            if (configuration.Occurs != null)
                throw new ArgumentException("Occurs must be null when appointment occurs once.");

            if (configuration.OccursOnceAt == default(DateTime))
                throw new ArgumentException("OccursOnceAt must be set to a valid date when Type is Once.");
        }
        else
        {
            if (configuration.OccursOnceAt != default(DateTime))
                throw new ArgumentException("OccursOnceAt must be undefined when Type is Recurring.");

            if (configuration.Occurs == null)
                throw new ArgumentException("Occurs must be set when Type is Recurring.");
        }
    }
}

