using System;
using Task3;
using Task3.Validation;

namespace Tests;

[TestFixture]
public class LimitsValidationTests
{
    [Test]
    public void Validate_LimitsType_WithLowerStartDate_ThrowsNothing()
    {
        var appointmentLimits = new Limits
        {
            StartDate = new DateOnly(2020, 1, 1),
            EndDate = new DateOnly(2020, 2, 1)
        };
        Assert.That(() => LimitsValidator.Validate(appointmentLimits), Throws.Nothing);
    }

    [Test]
    public void Validate_LimitsType_WithEqualDates_ThrowsNothing()
    {
        var appointmentLimits = new Limits
        {
            StartDate = new DateOnly(2020, 1, 1),
            EndDate = new DateOnly(2020, 1, 1)
        };
        Assert.That(() => LimitsValidator.Validate(appointmentLimits), Throws.Nothing);
    }

    [Test]
    public void Validate_LimitsType_WithLowerEndDate_ThrowsException()
    {
        var appointmentLimits = new Limits
        {
            StartDate = new DateOnly(2020, 1, 1),
            EndDate = new DateOnly(2019, 12, 31)
        };

        Assert.That(() => LimitsValidator.Validate(appointmentLimits), Throws.ArgumentException.With
            .Message.EqualTo("Start date must be earlier or equal to end date"));
    }

}