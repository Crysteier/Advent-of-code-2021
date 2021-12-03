string path = "D:\\VS Projects\\Advent-of-code-2021\\AoCDay3\\Day3\\data.txt";
string[] lines = File.ReadAllLines(path);
string gamma = string.Empty;
string epsilon = string.Empty;
int count_one = 0, count_zero = 0;

//getting the most frequent number in a collumn an concating it to gamma string
for(int i =0; i < lines[0].Length; i++)
{
    for(int j = 0; j < lines.Length; j++)
    {
        if(lines[j][i].Equals('0'))
        {
            count_zero++;
        }
        else
        {
            count_one++;
        }
    }
    if(count_zero > count_one)
    {
        gamma = gamma+'0';
    }
    else
    {
        gamma = gamma + '1';
    }
    count_one = 0;
    count_zero = 0;
}

Console.WriteLine(gamma);
//switching the ones to zero from gamma
for(int i = 0; i < gamma.Length; i++)
{
    if (gamma[i].Equals('0'))
    {
        epsilon = epsilon+'1';
    }
    else
    {
        epsilon = epsilon + '0';
    }
}

Console.WriteLine(epsilon);
//multiplying the decimal value of gamma and epsilon to get the power consuption
Console.WriteLine(Convert.ToInt64(gamma,2)* Convert.ToInt64(epsilon, 2));
