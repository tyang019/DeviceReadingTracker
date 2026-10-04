using DeviceReadingTracker;

internal class Program
{
    private static void Main(string[] args)
    {
        Device device = new Device(
    "DEV-001",
    "Training Sensor"   
);

        bool running = true;

        while (running)
        {
            ShowMenu(device);

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddReading(device);
                    break;

                case "2":
                    ViewReadings(device);
                    break;

                case "3":
                    ViewSummary(device);
                    break;

                case "4":
                    ToggleDeviceStatus(device);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Device Tracker closed.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Choose 1 through 5.");
                    break;
            }

            Console.WriteLine();
        }


        static void ShowMenu(Device device)
        {
            Console.WriteLine("================================");
            Console.WriteLine("     DEVICE READING TRACKER");
            Console.WriteLine("================================");
            Console.WriteLine($"Device: {device.Name}");
            Console.WriteLine($"Status: {(device.IsOnline ? "ONLINE" : "OFFLINE")}");
            Console.WriteLine();

            Console.WriteLine("1. Add reading");
            Console.WriteLine("2. View readings");
            Console.WriteLine("3. View summary");
            Console.WriteLine("4. Toggle device status");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
        }


        static void AddReading(Device device)
        {
            try
            {
                Console.Write("Enter a reading from 0 to 100: ");

                string input = Console.ReadLine() ?? "";

                double reading = double.Parse(input);

                device.AddReading(reading);

                Console.WriteLine($"Reading {reading:F1} added successfully.");
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Invalid input. Enter a numeric value."
                );
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Invalid reading: {ex.Message}");
            }
        }


        static void ViewReadings(Device device)
        {
            if (device.Readings.Count == 0)
            {
                Console.WriteLine(
                    "No readings have been recorded."
                );

                return;
            }

            Console.WriteLine("Recorded Readings:");

            for (int i = 0; i < device.Readings.Count; i++)
            {
                Reading reading = device.Readings[i];

                Console.WriteLine(
                    $"{i + 1}. " +
                    $"{reading.Value:F1} - " +
                    $"{reading.Status} - " +
                    $"{reading.Timestamp:g}"
                );
            }
        }


        static void ViewSummary(Device device)
        {
            Console.WriteLine("Device Summary");
            Console.WriteLine($"ID: {device.Id}");
            Console.WriteLine($"Name: {device.Name}");
            Console.WriteLine(
                $"Status: {(device.IsOnline ? "ONLINE" : "OFFLINE")}"
            );

            Console.WriteLine(
                $"Reading Count: {device.Readings.Count}"
            );

            if (device.Readings.Count == 0)
            {
                Console.WriteLine("Average: No readings available.");
                return;
            }

            double average = device.GetAverageReading();

            Console.WriteLine($"Average: {average:F2}");
        }


        static void ToggleDeviceStatus(Device device)
        {
            device.IsOnline = !device.IsOnline;

            string status =
                device.IsOnline ? "ONLINE" : "OFFLINE";

            Console.WriteLine($"Device is now {status}.");
        }
    }
}