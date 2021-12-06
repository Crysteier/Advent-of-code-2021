string path = @"D:\VS Projects\Advent-of-code-2021\AoCDay6\Day6 puzzle 1\data.txt";
string[] lines = File.ReadAllLines(path);
string[] test = { "3", "4", "3", "1", "2" };
string[] input = lines[0].Split(',');
ulong[] ages = new ulong[9];

foreach (string dayTimer in input)
{
    int timer = Int32.Parse(dayTimer);
    ages[timer] += 1;
}
//for puzzle 2 only the finishing number had to be changed from 80 to 256
for (int i = 0; i < 256; i++)
{
    ulong spawned = ages[0];
    for (int j = 0; j < ages.Length - 1; j++)
    {
        ages[j] = ages[j + 1];
    }
    ages[8] = spawned;
    ages[6] += spawned;
}

ulong result = 0;
for (int i = 0; i < ages.Length; i++)
{
    result += (ulong)ages[i];
}

Console.WriteLine($"\nThere are {result:N0} fishes ");
