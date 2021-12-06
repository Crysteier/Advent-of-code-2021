using System.Text.RegularExpressions;
using static System.Console;

string path = "D:\\VS Projects\\Advent-of-code-2021\\AoCDay5\\Day5 puzzle 1\\data.txt";
string[] input = File.ReadAllLines(path);
List<string[]> coords = new List<string[]>();

int[,] map = new int[10000, 10000];

for (int i = 0; i < 10000; i++)
{
    for (int j = 0; j < 10000; j++)
    {
        map[i, j] = 0;
    }
}

void PrintTestMap()
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            Write("{0,2}", map[i, j]);
        }
        Console.WriteLine();
    }
}

void CheckMap()
{
    int count = 0;
    for (int i = 0; i < 10000; i++)
    {
        for (int j = 0; j < 10000; j++)
        {
            if (map[i, j] >= 2)
            {
                count++;
            }
        }
    }
    Console.WriteLine($"There  is : {count} danger zones");
}

void WriteByX(int y, int x1, int x2)
{
    if (x1 > x2)
    {
        (x1, x2) = (x2, x1);
    }
    for (; x1 <= x2; x1++)
    {
        map[x1, y] += 1;
    }
}

void WriteByY(int x, int y1, int y2)
{
    if (y1 > y2)
    {
        (y1, y2) = (y2, y1);
    }
    for (; y1 <= y2; y1++)
    {
        map[x, y1] += 1;
    }
}

void WriteDiagonal(int x1, int x2, int y1, int y2)
{
    if (x1 > x2)
    {
        if (y1 > y2)
        {
            for (; x1 >= x2; x1--, y1--)
            {
                map[x1, y1] += 1;
            }
        }
        else
        {
            for (; x1 >= x2; x1--, y1++)
            {
                map[x1, y1] += 1;
            }
        }
    }
    else
    {
        if (y1 > y2)
        {
            for (; x1 <= x2; x1++, y1--)
            {
                map[x1, y1] += 1;
            }
        }
        else
        {
            for (; x1 <= x2; x1++, y1++)
            {
                map[x1, y1] += 1;
            }
        }
    }
}

foreach (string line in input)
{
    coords.Add(Regex.Split(line, @",|->"));
}

foreach (string[] coordinata in coords)
{
    int x1 = Int32.Parse(coordinata[0]);
    int y1 = Int32.Parse(coordinata[1]);
    int x2 = Int32.Parse(coordinata[2]);
    int y2 = Int32.Parse(coordinata[3]);

    if (x1 == x2)
    {
        WriteByX(x1, y1, y2);
    }
    else if (y1 == y2)
    {
        WriteByY(y1, x1, x2);
    }
    else
    {
        WriteDiagonal(x1, x2, y1, y2);
    }
}
//PrintMap();
CheckMap();
