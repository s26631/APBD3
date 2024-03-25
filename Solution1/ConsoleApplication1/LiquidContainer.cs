namespace ConsoleApp1;

public class LiquidContainer : Container
{
    public LiquidContainer(double cargoweight) : base(cargoweight)
    {
        Cargoweight = cargoweight;
    }

    public override void Load(double cargoweight)
    {
        
    }


}