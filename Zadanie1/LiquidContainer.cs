namespace Zadanie1;
using System;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardousCargo { get; private set; }
    private double currentCargoMass;

    public LiquidContainer(double cargoMass, double height, double ownWeight,
        double depth, double maxLoadCapacity, bool isHazardousCargo)
        : base(cargoMass, height, ownWeight, depth, maxLoadCapacity, "L")
    {
        IsHazardousCargo = isHazardousCargo;
    }

    public override void Load(double mass)
    {
        double maxAllowedMass = IsHazardousCargo ? MaxLoadCapacity * 0.5 : MaxLoadCapacity * 0.9;

        if (mass > maxAllowedMass)
        {
            NotifyHazard(SerialNumber, $"Attempted to overload container with hazardous={IsHazardousCargo}. Allowed: {maxAllowedMass} kg, Attempted: {mass} kg");
            throw new OverfillException($"Exceeded allowed load. Allowed: {maxAllowedMass} kg, Attempted: {mass} kg");
        }

        currentCargoMass = mass;
        Console.WriteLine($"Loaded {mass} kg into LiquidContainer [{SerialNumber}]");
    }

    public override void Unload()
    {
        Console.WriteLine($"Unloaded {currentCargoMass} kg from LiquidContainer [{SerialNumber}]");
        currentCargoMass = 0;
    }

    public void NotifyHazard(string containerSerial, string message)
    {
        Console.WriteLine($"[Hazard Notification] Container: {containerSerial}, Message: {message}");
    }

    public override string ToString()
    {
        return $"LiquidContainer [{SerialNumber}] - Hazardous: {IsHazardousCargo}, Current Load: {currentCargoMass}/{MaxLoadCapacity} kg";
    }
}
