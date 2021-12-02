string path = "D:\\VS Projects\\Advent-of-code-2021\\AoCDay2\\Day2\\data.txt";
string[] lines = File.ReadAllLines(path);
string[] movements = { "forward", "up", "down" };
string[] test = { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };

int pos_horizontal =0, depth = 0, aim = 0;

foreach (string line in lines)
{
    var dataLine = line.Split(' ');
    
    switch (dataLine[0])
    {
        case "forward":
            pos_horizontal += Int32.Parse(dataLine[1]);
            depth += Int32.Parse(dataLine[1]) * aim;
            break;
        case "up":
            aim -= Int32.Parse(dataLine[1]);
            break;
        case "down":
            aim += Int32.Parse(dataLine[1]);
            break;
        default:
            Console.WriteLine("Nothing");
            break;
    }
    Console.WriteLine($"depth: {depth} | horizontal {pos_horizontal}");
}

Console.WriteLine(pos_horizontal*depth);