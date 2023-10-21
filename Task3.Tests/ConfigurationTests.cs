using System;
using Task3.Validation;

namespace Task3.Tests;

[TestFixture]
public class ConfigurationTests
{
    [Test]
    public void Validate_OnceTypeWithValidDate_NoExceptionThrown()
    {
        var configuration = new Configuration
        {
            Type = AppointmentType.Once,
            OccursOnceAt = DateTime.Now,
            Occurs = null
        };

        Assert.That(() => ConfigurationValidator.Validate(configuration), Throws.Nothing);
    }

    [Test]
    public void Validate_OnceTypeWithNullOccurs_ExceptionThrown()
    {
        var configuration = new Configuration
        {
            Type = AppointmentType.Once,
            OccursOnceAt = DateTime.Now,
            Occurs = Frequency.Daily
        };

        Assert.That(() => ConfigurationValidator.Validate(configuration), Throws.ArgumentException
            .With.Message.EqualTo("Occurs must be null when appointment occurs once."));
    }

    [Test]
    public void Validate_OnceTypeWithNullOccursOnceAt_ExceptionThrown()
    {
        var configuration = new Configuration
        {
            Type = AppointmentType.Once,
            OccursOnceAt = default
        };

        Assert.That(() => ConfigurationValidator.Validate(configuration), Throws.ArgumentException
            .With.Message.EqualTo("OccursOnceAt must be set to a valid date when Type is Once."));
    }

    [Test]
    public void Validate_RecurringTypeWithNullOccurs_ExceptionThrown()
    {
        var configuration = new Configuration
        {
            Type = AppointmentType.Recurring,
            Occurs = null
        };

        Assert.That(() => ConfigurationValidator.Validate(configuration), Throws.ArgumentException
            .With.Message.EqualTo("Occurs must be set when Type is Recurring."));
    }

    [Test]
    public void Validate_RecurringTypeWithOccursOnceAt_ExceptionThrown()
    {
        var configuration = new Configuration
        {
            Type = AppointmentType.Recurring,
            OccursOnceAt = DateTime.Now
        };

        Assert.That(() => ConfigurationValidator.Validate(configuration), Throws.ArgumentException
            .With.Message.EqualTo("OccursOnceAt must be undefined when Type is Recurring."));
    }
}