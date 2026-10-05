using DeviceReadingTracker;

namespace DeviceTracker.Tests;

public class DeviceTests
{
    [Fact]
    public void AddReading_ValidReading_AddsReading()
    {
        // Arrange
        Device device = new Device(
            "DEV-001",
            "Training Sensor"
        );

        // Act
        device.AddReading(65);

        // Assert
        Assert.Single(device.Readings);
        Assert.Equal(65, device.Readings[0].Value);
    }

    [Fact]
    public void AddReading_InvalidReading_ThrowsException()
    {
        // Arrange
        Device device = new Device(
            "DEV-001",
            "Training Sensor"
        );

        // Act and Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => device.AddReading(150)
        );
    }

    [Fact]
    public void GetReadingStatus_ValueWithinRange_ReturnsPass()
    {
        // Arrange
        Device device = new Device(
            "DEV-001",
            "Training Sensor"
        );

        // Act
        ReadingStatus status =
            device.GetReadingStatus(60);

        // Assert
        Assert.Equal(
            ReadingStatus.Pass,
            status
        );
    }

    [Fact]
    public void GetReadingStatus_ValueOutsideRange_ReturnsReview()
    {
        // Arrange
        Device device = new Device(
            "DEV-001",
            "Training Sensor"
        );

        // Act
        ReadingStatus status =
            device.GetReadingStatus(95);

        // Assert
        Assert.Equal(
            ReadingStatus.Review,
            status
        );
    }

    [Fact]
    public void GetAverageReading_WithReadings_ReturnsAverage()
    {
        // Arrange
        Device device = new Device(
            "DEV-001",
            "Training Sensor"
        );

        device.AddReading(50);
        device.AddReading(70);

        // Act
        double average =
            device.GetAverageReading();

        // Assert
        Assert.Equal(60, average);
    }
    [Fact]
    public void AddReading_NaN_ThrowsException()
    {
        // Arrange
        Device device = new Device(
            "DEV-001",
            "Training Sensor"
        );

        // Act and Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => device.AddReading(double.NaN)
        );

        Assert.Empty(device.Readings);
    }
}