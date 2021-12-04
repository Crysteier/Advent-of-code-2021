using Day4;
using static System.Console;

string path = "D:\\VS Projects\\Advent-of-code-2021\\AoCDay4\\Day4\\test.txt";
string input = File.ReadLines(path).First();
string[] splittedInput = input.Split(',');
int[] decimalInput = new int[splittedInput.Length];
string[] lines = File.ReadAllLines(path).Skip(2).ToArray();
int[] numberMatrix = new int[5];
List<int[]> intMatrix = new List<int[]>();
List<BingoMatrix> bingoMatrices = new List<BingoMatrix>();

int[] StringLineToIntAndArray(string line)
{
    string[] prepareLine = line.Split(' ');
    List<string> numbersLine = new List<string>();
    foreach (string s in prepareLine)
    {
        numbersLine.Add(s);
    }
    for (int i = 0; i < numbersLine.Count; i++)
    {
        if (numbersLine[i].Equals(String.Empty))
        {
            numbersLine.RemoveAt(i);
        }
    }
    string[] finalLine = numbersLine.ToArray();
    int[] ints = Array.ConvertAll(finalLine, s => int.TryParse(s, out var x) ? x : -1);
    
    return ints;
}

for(int i=0; i<lines.Length; i++)
{

    if (lines[i].Equals(string.Empty))
    {
        BingoMatrix bingoMatrix = new BingoMatrix(intMatrix);
        bingoMatrices.Add(bingoMatrix);
        intMatrix = new List<int[]>();
        continue;
    }
    numberMatrix = StringLineToIntAndArray(lines[i]);
    intMatrix.Add(numberMatrix);
    if (i == lines.Length - 1)
    {
        BingoMatrix bingoMatrix = new BingoMatrix(intMatrix);
        bingoMatrices.Add(bingoMatrix);
        intMatrix = new List<int[]>();
        continue;
    }
}

decimalInput = StringLineToIntAndArray(string.Join(" ",splittedInput));
bool end = false;
for(int i = 0; i < decimalInput.Length; i++)
{
    Console.WriteLine($"Current number in the lot: {decimalInput[i]}");
    foreach(BingoMatrix matrix in bingoMatrices)
    {
        matrix.Checknumber(decimalInput[i]);
        //matrix.PrintMatrix();
        //matrix.PrintMatrixMap();
        matrix.CheckMapRowColumn();
        if (matrix.BINGO)
        {
            matrix.SumOfUnmarkedNumbers(decimalInput[i]);
            end = true;
        }
    }
    if (end) { break; }
    //Console.WriteLine("Press key for next iteration");
    //Console.ReadKey();
    //Console.Clear();
}
