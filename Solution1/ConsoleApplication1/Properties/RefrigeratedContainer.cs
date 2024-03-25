using System;

namespace ConsoleApplication1.Properties;

public class RefrigeratedContainer : Container
    {
        public string ProductType { get; private set; }
        public double Temperature { get; private set; }
        public double RequiredMinTemperature { get; set; }

        public RefrigeratedContainer(double cargoweight, double maximumLoad, string serialNumber, string productType, double temperature, double requiredMinTemperature) 
            : base(cargoweight, maximumLoad, serialNumber)
        {
            ProductType = productType;
            Temperature = temperature;
            RequiredMinTemperature = requiredMinTemperature;
        }

        public override void Load(double cargoweight)
        {
            if (Cargoweight + cargoweight > MaximumLoad)
            {
                throw new OverfillException($"Cannot load beyond designated capacity for container {SerialNumber}.");
            }

            // Przed załadowaniem upewnij się, że temperatura jest odpowiednia dla produktu
            if (Temperature < RequiredMinTemperature)
            {
                throw new InvalidOperationException($"The temperature of {Temperature}°C is too low for {ProductType}, requires at least {RequiredMinTemperature}°C.");
            }

            Cargoweight += cargoweight;
        }

        public void SetProduct(string productType, double requiredMinTemperature)
        {
            if (!string.IsNullOrEmpty(ProductType))
            {
                throw new InvalidOperationException("Container already has a product type set. Unload the container before changing the product type.");
            }

            ProductType = productType;
            RequiredMinTemperature = requiredMinTemperature;
        }

        public void AdjustTemperature(double temperature)
        {
            if (temperature < RequiredMinTemperature)
            {
                throw new InvalidOperationException($"Cannot set the temperature to {temperature}°C, which is below the required minimum of {RequiredMinTemperature}°C for {ProductType}.");
            }

            Temperature = temperature;
        }

        // Możesz dodać dodatkową logikę specyficzną dla kontenerów chłodniczych, np. opróżnianie kontenera
        public override void Unload()
        {
            base.Unload();
            ProductType = string.Empty;
        }
    }

