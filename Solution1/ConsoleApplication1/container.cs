using ConsoleApp1.exceptios;
using ConsoleApp1.interfaces;

namespace ConsoleApp1;

public class Container : IContainer
{
    public double Cargoweight { get; set; }

    public Container(double cargoweight)
    {
        Cargoweight = cargoweight;
    }

    public void Unload()
    {
        throw new NotImplementedException();
    }

    public virtual void Load(double cargoweight)
    {
        throw new OverfillException();
    }
}