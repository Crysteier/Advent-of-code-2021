string path = @"C:\Repos\AoCDay7\Day7\data.txt";
int[] lines = File.ReadAllText(path).Split(',').Select(it => int.Parse(it)).ToArray();
//LINQ code, converts lines to dictionary and increases the count if key already exists, so cool, thanks Juraj and Mato
var map = lines.GroupBy(it => it).ToDictionary(it => it.Key, v => v.Count());

int max = lines.Max();
int fuelConsumed = 0;
int lowestFuelConsumed = int.MaxValue;

for(int i = 0; i <= max; i++)
{
    fuelConsumed = 0;
    foreach(var pos in lines)
    {
        int distance = Math.Abs(i - pos);
        for (int j = 1; j <= distance; j++)
        {
            fuelConsumed += j;
        }
    }
    if(fuelConsumed < lowestFuelConsumed)
    {
        lowestFuelConsumed = fuelConsumed;
    }
}
Console.WriteLine($"Fuel consumed: {lowestFuelConsumed}");
