using System;
using Task3.Validation;

namespace Task3.Tests;

[TestFixture]
public class AppointmentTests
{
    [Test]
    public void OnceAppointmentWithValidPropsThrowsNothing()
    {
        var appointment = new Appointment
        {
            CurrentDate = new DateOnly(2023, 10, 21),
            Configuration = new Configuration
            {
                Type = AppointmentType.Once,
                OccursOnceAt = DateTime.Now,
                Occurs = null,
                Enabled = true
            },

            Limits = new Limits
            {
                StartDate = new DateOnly(2020, 4, 1),
                EndDate = new DateOnly(2020, 5, 1),
            },

            DailyFrequency = null,
            MonthlyConfiguration = null
        };
        Assert.That(() => AppointmentValidator.Validate(appointment), Throws.Nothing);
    }

    [Test]
    public void OnceAppointmentWithInvalidLimitsThrowsException()
    {
        var appointment = new Appointment
        {
            CurrentDate = new DateOnly(2023, 10, 21),
            Configuration = new Configuration
            {
                Type = AppointmentType.Once,
                OccursOnceAt = DateTime.Now,
                Occurs = null,
                Enabled = true
            },

            Limits = new Limits
            {
                StartDate = new DateOnly(2022, 4, 1),
                EndDate = new DateOnly(2020, 5, 1),
            },
            DailyFrequency = null,
            MonthlyConfiguration = null
        };
        Assert.That(() => AppointmentValidator.Validate(appointment), Throws.ArgumentException.With
            .Message.EqualTo("Start date must be earlier or equal to end date"));
    }

    [Test]
    public void OnceAppointmentWithInvalidConfigurationThrowsException()
    {
        var appointment = new Appointment
        {
            CurrentDate = new DateOnly(2023, 10, 21),
            Configuration = new Configuration
            {
                Type = AppointmentType.Once,
                OccursOnceAt = DateTime.Now,
                Occurs = Frequency.Daily,
                Enabled = true
            },

            Limits = new Limits
            {
                StartDate = new DateOnly(2020, 4, 1),
                EndDate = new DateOnly(2020, 5, 1),
            },

            DailyFrequency = null,
            MonthlyConfiguration = null
        };
        Assert.That(() => AppointmentValidator.Validate(appointment), Throws.ArgumentException.With
            .Message.EqualTo("Occurs must be null when appointment occurs once."));
    }

    [Test]
    public void AppointmentWithInValidDailyFrequencyThrowsException()
    {
        var appointment = new Appointment
        {
            CurrentDate = new DateOnly(2023, 10, 21),
            Configuration = new Configuration
            {
                Type = AppointmentType.Once,
                OccursOnceAt = DateTime.Now,
                Occurs = null,
                Enabled = true
            },

            Limits = new Limits
            {
                StartDate = new DateOnly(2020, 4, 1),
                EndDate = new DateOnly(2020, 5, 1),
            },

            DailyFrequency = new DailyFrequency
            {
                OccursOnceDaily = true,
                OccursDailyAt = new TimeOnly(2, 0, 0)
            },
            MonthlyConfiguration = null
        };
        Assert.That(() => AppointmentValidator.Validate(appointment), Throws.ArgumentException.With
            .Message.EqualTo("When the appointment occurs once, daily frequency is undefined"));
    }

    [Test]
    public void AppointmentWithInvalidMonthlyConfigurationThrowsException()
    {
        var appointment = new Appointment
        {
            CurrentDate = new DateOnly(2023, 10, 21),
            Configuration = new Configuration
            {
                Type = AppointmentType.Once,
                OccursOnceAt = DateTime.Now,
                Occurs = null,
                Enabled = true
            },

            Limits = new Limits
            {
                StartDate = new DateOnly(2020, 4, 1),
                EndDate = new DateOnly(2020, 5, 1),
            },

            DailyFrequency = null,
            MonthlyConfiguration = new MonthlyConfiguration
            {
                IsDayOfMonth = true,
                DayOfMonth = 8
            }
        };
        Assert.That(() => AppointmentValidator.Validate(appointment), Throws.ArgumentException.With
            .Message.EqualTo("When the appointment occurs once, there is no for monthly configuration"));
    }


}
