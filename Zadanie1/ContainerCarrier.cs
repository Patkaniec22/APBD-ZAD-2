namespace Zadanie1;

public class ContainerCarrier
{
    public List<Container> Containers = new List<Container>();
    public int MaxSpeed { get; set; } // knots/wezly
    public int MaxContainers { get; set; }
    public int MaxTotalGrossWeight { get; set; } // in tons /w tonach; 1t = 1k kg
}