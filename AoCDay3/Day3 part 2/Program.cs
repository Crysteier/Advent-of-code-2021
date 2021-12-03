string path = "D:\\VS Projects\\Advent-of-code-2021\\AoCDay3\\Day3\\data.txt";
string[] lines = File.ReadAllLines(path);
string oxygen = string.Empty;
string co2scrubber = string.Empty;
string[] test = { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
int count_one = 0, count_zero = 0;
List<string> memorizedNumber = new List<string>();

void RemoveNumbers(char leadNumber, int index)
{
    memorizedNumber.RemoveAll(number => number[index] == leadNumber);
}

void FillNumbers()
{
    memorizedNumber = new List<string>();
    for (int i = 0;i < lines.Length; i++)
    {
        memorizedNumber.Add(lines[i]);
    }
}

string FindOxygenRating()
{
    FillNumbers();
    int index = 0;
    do
    {
        foreach (string line in memorizedNumber)
        {
            if (line[index].Equals('0'))
            {
                count_zero++;
            }
            else
            {
                count_one++;
            }
        }
        
        if (count_one >= count_zero)
        {
            RemoveNumbers('0', index);
        }
        else
        {
            RemoveNumbers('1', index);
        }
        count_one = 0;
        count_zero = 0;
        index++;
        
    } while (memorizedNumber.Count != 1 && index < lines[0].Length);

    return memorizedNumber[0];
}

string FindCO2Rating()
{
    FillNumbers();
    int index = 0;
    do
    {
        foreach (string line in memorizedNumber)
        {
            if (line[index].Equals('0'))
            {
                count_zero++;
            }
            else
            {
                count_one++;
            }
        }

        if (count_zero <= count_one)
        {
            RemoveNumbers('1', index);
        }
        else
        {
            RemoveNumbers('0', index);
        }
        count_one = 0;
        count_zero = 0;
        index++;
        
    } while (memorizedNumber.Count != 1 && index < lines[0].Length);
    Console.WriteLine($"co2 rating: {memorizedNumber[0]}");
    return memorizedNumber[0];
}

oxygen = FindOxygenRating();
co2scrubber = FindCO2Rating();
Console.WriteLine($"Results: " +
    $"\noxygen: {Convert.ToInt64(oxygen, 2)}" +
    $"\nco2 scrubber: {Convert.ToInt64(co2scrubber, 2)}" +
    $"\nmultiplyed: {Convert.ToInt64(co2scrubber, 2) * Convert.ToInt64(oxygen, 2)}");
