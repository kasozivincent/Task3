using System;
using Task3.Validation;

namespace Task3;

public class Scheduler
{
    public static AppointmentDetails CalculateNextDate(Appointment appointment)
    {
        AppointmentValidator.Validate(appointment);
        throw new Exception();

    }
}
