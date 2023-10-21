using System;
using System.ComponentModel.DataAnnotations;
using Task3.Validation;

namespace Task3.Tests;

[TestFixture]
public class DailyFrequencyValidatorTests
{
    [Test]
    public void Validate_OccursOnceDaily_ValidFrequency()
    {
        var frequency = new DailyFrequency
        {
            OccursOnceDaily = true,
            OccursDailyAt = new TimeOnly(9, 0, 0)
        };

        Assert.That(() => DailyFrequencyValidator.Validate(frequency), Throws.Nothing);
    }


    [Test]
    public void Validate_OccursDaily_ValidFrequency()
    {
        var frequency = new DailyFrequency
        {
            OccursOnceDaily = false,
            OccursDailyAt = default,
            StartTime = new TimeOnly(9, 0, 0),
            EndTime = new TimeOnly(10, 0, 0),
            DailyRepeatInterval = 3,
            Segment = TimeSegment.Hours
        };

        Assert.That(() => DailyFrequencyValidator.Validate(frequency), Throws.Nothing);
    }


    [Test]
    public void Validate_DailyFrequencyWith_InvalidTime_ThrowsException()
    {
        var frequency = new DailyFrequency
        {
            OccursOnceDaily = true,
            OccursDailyAt = default,
            StartTime = new TimeOnly(9, 0, 0),
            EndTime = new TimeOnly(10, 0, 0),
            DailyRepeatInterval = 1,
            Segment = TimeSegment.None
        };

        Assert.That(() => DailyFrequencyValidator.Validate(frequency), Throws.ArgumentException
            .With.Message.EqualTo("When OccursOnceDaily is true, OccursDailyAt should be set."));
    }

    [Test]
    public void Validate_DailyFrequencyWith_ValidOccuesOnceDaily_OccursDailyAt_ThrowsNothing()
    {
        var frequency = new DailyFrequency
        {
            OccursOnceDaily = false,
            OccursDailyAt = default,
            StartTime = new TimeOnly(9, 0, 0),
            EndTime = new TimeOnly(10, 0, 0),
            DailyRepeatInterval = 3,
            Segment = TimeSegment.Hours
        };
        Assert.That(() => DailyFrequencyValidator.Validate(frequency), Throws.Nothing);
    }

    [Test]
    public void Validate_DailyFrequencyWith_InvalidDailyRepeatInterval()
    {
        var frequency = new DailyFrequency
        {
            OccursOnceDaily = false,
            OccursDailyAt = new TimeOnly(9, 0, 0),
            StartTime = default,
            EndTime = new TimeOnly(10, 0, 0),
            DailyRepeatInterval = 7,
            Segment = TimeSegment.None
        };
        Assert.That(() => DailyFrequencyValidator.Validate(frequency), Throws.ArgumentException
            .With.Message.EqualTo("When OccursOnceDaily is false, OccursDailyAt should be undefined."));
    }
}
