namespace Zadanie1;

public static class SerialNumberGenerator
{
  private static Dictionary<string, int> counters = new Dictionary<string, int>();

  public static string Generate(string containerType)
  {
    if (!counters.ContainsKey(containerType))
      counters[containerType] = 1;

    return $"KON-{containerType}-{counters[containerType]++}";
  }
}
