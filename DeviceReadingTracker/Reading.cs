namespace DeviceReadingTracker;

public class Reading
{
    public double Value { get; }
    public ReadingStatus Status { get; }
    public DateTime Timestamp { get; }

    public Reading(
        double value,
        ReadingStatus status)
    {
        Value = value;
        Status = status;
        Timestamp = DateTime.Now;
    }
}