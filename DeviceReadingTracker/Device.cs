using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceReadingTracker;

public class Device
{
    public string Id { get; }
    public string Name { get; }
    public bool IsOnline { get; set; }

    public List<Reading> Readings { get; } = new();

    public Device(string id, string name)
    {
        Id = id;
        Name = name;
        IsOnline = true;
    }

    public void AddReading(double value)
    {
        if (!double.IsFinite(value) || value < 0 || value > 100)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "Reading must be a finite number between 0 and 100."
            );
        }

        ReadingStatus status = GetReadingStatus(value);

        Reading reading = new Reading(
            value,
            status
        );

        Readings.Add(reading);
    }

    public ReadingStatus GetReadingStatus(double value)
    {
        if (value >= 40 && value <= 80)
        {
            return ReadingStatus.Pass;
        }

        return ReadingStatus.Review;
    }

    public double GetAverageReading()
    {
        if (Readings.Count == 0)
        {
            return 0;
        }

        return Readings.Average(
            reading => reading.Value
        );
    }
}