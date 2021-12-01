int counter = 0;
string path = "D:\\VS Projects\\Advent-of-code-2021\\AoCDay1\\Day1\\data.txt";
string[] lines = File.ReadAllLines(path);
for(int i = 1; i < lines.Length; i++)
{
    if(Int32.Parse(lines[i-1])< Int32.Parse(lines[i]))
    {
        counter++;
    }
}
Console.WriteLine(counter);
Console.WriteLine("");

int[] test = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

int previous, next;
counter = 0;
for(int i=0; i < lines.Length-3; i++)
{
    previous = Int32.Parse(lines[i]) + Int32.Parse(lines[i+1]) + Int32.Parse(lines[i+2]);
    next = Int32.Parse(lines[i+1]) + Int32.Parse(lines[i +2]) + Int32.Parse(lines[i + 3]);
    
    if (previous < next)
    {
        counter++;
    }
}
Console.WriteLine(counter);