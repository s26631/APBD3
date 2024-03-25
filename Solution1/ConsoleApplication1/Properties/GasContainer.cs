using System;

namespace ConsoleApplication1.Properties;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }

    public GasContainer(double cargoweight, double maximumLoad, string serialNumber, double pressure) : base(cargoweight, maximumLoad, serialNumber)
    {
        Pressure = pressure;
    }


    public override void Load(double cargoweight)
    {
        // Przy założeniu, że istnieje właściwość MaximumLoad
        if (Cargoweight + cargoweight > MaximumLoad)
        {
            throw new OverfillException("Cannot load beyond designated capacity.");
        }
        Cargoweight += cargoweight;
    }

    public override void Unload()
    {
        // Pozostaw 5% ładunku w kontenerze
        Cargoweight = MaximumLoad * 0.05;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Hazardous situation with gas container. Serial Number: {SerialNumber}");
    }
}
