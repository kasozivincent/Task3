using System;

namespace Task3.Validation;

public class AppointmentValidator
{
    public static void Validate(Appointment appointment)
    {
        if (appointment == null) 
            throw new ArgumentNullException("Argument can't be null");
        
        if(appointment.Configuration.Type == AppointmentType.Once)
        {
            if (appointment.DailyFrequency != null)
                throw new ArgumentException("When the appointment occurs once, daily frequency is undefined");
            if(appointment.MonthlyConfiguration != null)
                throw new ArgumentException("When the appointment occurs once, there is no for monthly configuration");
        }
        else
        {
            DailyFrequencyValidator.Validate(appointment.DailyFrequency);
            MonthlyConfigurationValidator.Validate(appointment.MonthlyConfiguration);
        }
        ConfigurationValidator.Validate(appointment.Configuration);
        LimitsValidator.Validate(appointment.Limits);
    }
}
