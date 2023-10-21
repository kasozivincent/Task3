using System;

namespace Task3;


public enum Day 
{
    WeekDay,
    WeekendDay
}
public enum WeekendDay
{
    Saturday, Sunday
}
public enum WeekDay
{
    Monday, Tuesday, Wednesday, Thursday,
    Friday
}
public enum AppointmentType
{
    Once,
    Recurring
}
public enum Frequency
{
    Daily,
    Monthly
}
public class Configuration 
{
    public AppointmentType Type {get; set; }
    public DateTime OccursOnceAt {get; set; }
    public Frequency? Occurs {get; set; }
    public bool Enabled {get; set; }
}
public class Limits
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
public enum TimeSegment
{
    None,
    Hours,
    Minutes,
    Seconds
}
public class DailyFrequency
{
    public bool OccursOnceDaily { get; set; }
    public TimeOnly OccursDailyAt { get; set; }
    public int DailyRepeatInterval { get; set; }
    public TimeSegment Segment { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}

public enum Position
{
    First, Second,
    Third, Fourth,
    Last
}

public class MonthlyConfiguration
{
    public bool IsDayOfMonth { get; set; }
    public int DayOfMonth { get; set; }
    public Position Position { get; set; }
    public Day Day { get; set; }
    public int NumberOfMonths { get; set; }
}

public class Appointment
{
    public DateOnly CurrentDate {get; set; }
    public Configuration Configuration {get; set; }
    public DailyFrequency? DailyFrequency {get; set; }
    public MonthlyConfiguration? MonthlyConfiguration { get; set; }
    public Limits Limits { get; set; }
}