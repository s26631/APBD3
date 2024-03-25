using System;
using System.ComponentModel;

namespace ConsoleApplication1.Properties
{
    public class Container : IContainer
    {
        public double Cargoweight { get; set; }
        public double MaximumLoad { get; set; } 
        public string SerialNumber { get; set; }

        public Container(double cargoweight, double maximumLoad, string serialNumber)
        {
            Cargoweight = cargoweight;
            MaximumLoad = maximumLoad;
            SerialNumber = serialNumber;
        }
        
        public virtual void Unload()
        {
            throw new NotImplementedException();
        }

        public virtual void Load(double cargoweight)
        {
            if (Cargoweight + cargoweight > MaximumLoad)
            {
                throw new OverfillException();
            }
        }
    }

}





