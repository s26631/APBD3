using System;

namespace ConsoleApplication1.Properties;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(double cargoweight, double maximumLoad, string serialNumber, bool isHazardous) : base(cargoweight, maximumLoad, serialNumber)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double cargoweight)
    {
        double maxLoad = IsHazardous ? MaximumLoad * 0.5 : MaximumLoad * 0.9;
        if (Cargoweight + cargoweight > maxLoad)
        {
            throw new OverfillException("Cannot load beyond designated capacity.");
        }
        Cargoweight += cargoweight;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"Warning: Hazardous condition in container {SerialNumber}.");
    }
}