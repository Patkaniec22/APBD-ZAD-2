namespace Zadanie1;
using System;



public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set; }
    private double currentCargoMass;

    public GasContainer(double cargoMass, double height, double ownWeight,
        double depth, double maxLoadCapacity, double pressure)
        : base(cargoMass, height, ownWeight, depth, maxLoadCapacity, "G")
    {
        Pressure = pressure;
    }

    public override void Load(double mass)
    {
        if (mass > MaxLoadCapacity)
        {
            NotifyHazard(SerialNumber, $"Attempted to overload gas container. Allowed: {MaxLoadCapacity} kg, Attempted: {mass} kg");
            throw new OverfillException($"Exceeded allowed gas load. Allowed: {MaxLoadCapacity} kg, Attempted: {mass} kg");
        }

        currentCargoMass = mass;
        Console.WriteLine($"Loaded {mass} kg into GasContainer [{SerialNumber}]");
    }

    public override void Unload()
    {
        double remainingMass = currentCargoMass * 0.05;
        Console.WriteLine($"Unloaded {currentCargoMass - remainingMass} kg from GasContainer [{SerialNumber}]. Remaining mass: {remainingMass} kg");
        currentCargoMass = remainingMass;
    }

    public void NotifyHazard(string containerSerial, string message)
    {
        Console.WriteLine($"[Hazard Notification] Container: {containerSerial}, Message: {message}");
    }

    public override string ToString()
    {
        return $"GasContainer [{SerialNumber}] - Pressure: {Pressure} atm, Current Load: {currentCargoMass}/{MaxLoadCapacity} kg";
    }
}