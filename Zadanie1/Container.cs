using System.Security.AccessControl;

namespace Zadanie1;

public abstract class Container
{
    public Container(double cargoMass, double height, double ownWeight,
                            double depth, double maxLoadCapacity, string containerType)
        {
            CargoWeight = cargoMass;
            Height = height;
            SelfWeight = ownWeight;
            Depth = depth;
            MaxLoadCapacity = maxLoadCapacity;
            SerialNumber = SerialNumberGenerator.Generate(containerType);
        }
    
    public double CargoWeight { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; } // in cm
    public double SelfWeight { get; set; }
    public double MaxLoadCapacity { get; set; }
    public string SerialNumber { get; set; }

    public abstract void Load(double mass);
    public abstract void Unload();
}