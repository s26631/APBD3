using System;
using ConsoleApplication1.Properties;
using Container = ConsoleApplication1.Properties.Container;

namespace ConsoleApplication1;

internal class Program
            {
                public static void Main(string[] args)
                {
                    
                    var ship = new ContainerShip(20, 5, 10000);

                    var container1 = new Container(1000, 5000, "KON-L-1");
                    var container2 = new LiquidContainer(500, 1000, "KON-LIQ-1", true);
                    var container3 = new GasContainer(300, 800, "KON-G-1", 5.0);

                    ship.AddContainer(container1);
                    ship.AddContainer(container2);
                    ship.AddContainer(container3);

                    ship.PrintShipInfo();
                    
                    // Usuń kontener o numerze seryjnym "KON-LIQ-1"
                    bool removed = ship.RemoveContainer("KON-LIQ-1");
                    if (removed)
                    {
                        Console.WriteLine("Kontener 'KON-LIQ-1' został usunięty.");
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono kontenera do usunięcia.");
                    }

                    // informacje o statku po usunięciu kontenera
                    ship.PrintShipInfo();
                    
                    // nowy kontener
                    var replacementContainer = new RefrigeratedContainer(400, 1500, "KON-REF-NEW", "Owoce", 5.0, 2.0); // Dodatkowe parametry dla kontenera chłodniczego

                    // Zastąp istniejący kontener na statku nowym kontenerem
                    ship.ReplaceContainer("KON-G-1", replacementContainer);

                    // informacje o statku po zastąpieniu kontenera
                    ship.PrintShipInfo();
                    
                    
                    // drugi kontenerowiec
                    var ship2 = new ContainerShip(25, 10, 20000);

                    // Transferuj kontener "KON-REF-NEW" z pierwszego statku do drugiego
                    ship.TransferContainer(ship2, "KON-REF-NEW");

                    // informacje o obu statkach po transferze kontenera
                    Console.WriteLine("Informacje o pierwszym statku po transferze:");
                    ship.PrintShipInfo();

                    Console.WriteLine("\nInformacje o drugim statku po transferze:");
                    ship2.PrintShipInfo();

                    
                }
            }

    
