using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1.Properties;

public class ContainerShip
    {
        public List<Container> Containers { get; private set; }
        public double MaxSpeed { get; private set; }
        public int MaxContainerCount { get; private set; }
        public double MaxWeight { get; private set; }

        public ContainerShip(double maxSpeed, int maxContainerCount, double maxWeight)
        {
            MaxSpeed = maxSpeed;
            MaxContainerCount = maxContainerCount;
            MaxWeight = maxWeight;
            Containers = new List<Container>();
        }

        public void AddContainer(Container container)
        {
            if (Containers.Count >= MaxContainerCount || CurrentWeight() + container.Cargoweight > MaxWeight)
            {
                throw new InvalidOperationException("Cannot add more containers. Maximum capacity reached.");
            }

            Containers.Add(container);
        }

        public void AddContainers(List<Container> newContainers)
        {
            foreach (var container in newContainers)
            {
                AddContainer(container);
            }
        }

        public bool RemoveContainer(string serialNumber)
        {
            var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container != null)
            {
                Containers.Remove(container);
                return true;
            }

            return false;
        }

        public void ReplaceContainer(string serialNumber, Container newContainer)
        {
            var index = Containers.FindIndex(c => c.SerialNumber == serialNumber);
            if (index != -1)
            {
                Containers[index] = newContainer;
            }
            else
            {
                throw new InvalidOperationException("Container with the given serial number does not exist.");
            }
        }

        public void TransferContainer(ContainerShip destinationShip, string serialNumber)
        {
            var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container != null)
            {
                RemoveContainer(serialNumber);
                destinationShip.AddContainer(container);
            }
            else
            {
                throw new InvalidOperationException("Container with the given serial number does not exist.");
            }
        }

        public void PrintShipInfo()
        {
            Console.WriteLine($"Ship Info: MaxSpeed={MaxSpeed}, MaxContainerCount={MaxContainerCount}, MaxWeight={MaxWeight}");
            Console.WriteLine("Containers on board:");
            foreach (var container in Containers)
            {
                Console.WriteLine($"SerialNumber: {container.SerialNumber}, Cargoweight: {container.Cargoweight}");
            }
        }

        private double CurrentWeight()
        {
            return Containers.Sum(c => c.Cargoweight);
        }
    }
