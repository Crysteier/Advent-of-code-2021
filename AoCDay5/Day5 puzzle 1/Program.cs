using System.Text.RegularExpressions;
using static System.Console;

string path = "D:\\VS Projects\\Advent-of-code-2021\\AoCDay5\\Day5 puzzle 1\\data.txt";
string[] input = File.ReadAllLines(path);
List<string[]> coords = new List<string[]>();
List<List<string>> map = new List<List<string>>();
List< Tuple<int, int, int, int> > coordinates = new List< Tuple<int, int,int, int> >();
int[,] mapko = new int[1000,1000];

for(int i = 0; i < 1000; i++)
{
    for(int j = 0; j < 1000; j++)
    {
        mapko[i,j] = 0;
    }
}

void PrintMap()
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            Write("{0,2}",mapko[i, j]);
        }
        Console.WriteLine();
    }
}

void CheckMap()
{
    int count = 0;
    for (int i = 0; i < 1000; i++)
    {
        for (int j = 0; j < 1000; j++)
        {
            if(mapko[i,j] >= 2)
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
    for(; x1 <= x2; x1++)
    {
        mapko[x1, y] += 1;
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
        mapko[x, y1] += 1;
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
    coordinates.Add(new Tuple<int, int, int, int>(x1, y1, x2, y2));
    Console.WriteLine(String.Join(' ',coordinata));
    if (x1 == x2)
    {
        WriteByX(x1, y1, y2);
    }
    if (y1 == y2)
    {
        WriteByY(y1, x1, x2);
    }
    Console.WriteLine(x1+x2);
}
//PrintMap();
CheckMap();
//coordinates.ForEach(coord => global::System.Console.WriteLine(coord));