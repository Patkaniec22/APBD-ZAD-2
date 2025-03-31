namespace Zadanie1;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; private set; }
    public double Temperature { get; private set; }
    private double currentCargoMass;

    private static readonly Dictionary<string, double> ProductTemperatureMap = new Dictionary<string, double>
    {
        {"Bananas", 13.3},
        {"Chocolate", 18.0},
        {"Fish", 2},
        {"Meat", -15.0},
        {"Ice Cream", -18.0},
        {"Frozen pizza", -30.0},
        {"Cheese", 7.2},
        {"Sausages", 5.0},
        {"Butter" , 20.5 },
        {"Eggs", 19.0},

    };

    public RefrigeratedContainer(double cargoMass, double height, double ownWeight,
        double depth, double maxLoadCapacity, string productType, double temperature)
        : base(cargoMass, height, ownWeight, depth, maxLoadCapacity, "C")
    {
        if (!ProductTemperatureMap.ContainsKey(productType))
            throw new ArgumentException($"Unsupported product type: {productType}");

        if (temperature < ProductTemperatureMap[productType])
            throw new ArgumentException($"Temperature too low for product {productType}. Minimum allowed: {ProductTemperatureMap[productType]}°C");

        ProductType = productType;
        Temperature = temperature;
    }

    public override void Load(double mass)
    {
        if (mass > MaxLoadCapacity)
            throw new OverfillException($"Exceeded allowed refrigerated load. Allowed: {MaxLoadCapacity} kg, Attempted: {mass} kg");

        currentCargoMass = mass;
        Console.WriteLine($"Loaded {mass} kg of {ProductType} into RefrigeratedContainer [{SerialNumber}] at {Temperature}°C");
    }

    public override void Unload()
    {
        Console.WriteLine($"Unloaded {currentCargoMass} kg of {ProductType} from RefrigeratedContainer [{SerialNumber}]");
        currentCargoMass = 0;
    }

    public override string ToString()
    {
        return $"RefrigeratedContainer [{SerialNumber}] - Product: {ProductType}, Temperature: {Temperature}°C, Current Load: {currentCargoMass}/{MaxLoadCapacity} kg";
    }
}