using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Day4
{
    internal class BingoMatrix
    {
        public List<int[]> Matrix { get; set; }
        public List<int[]> MatrixMap { get; set; }
        public bool BINGO { get; set; }
        public int Index { get;set; }

        public BingoMatrix(List<int[]> matrix)
        {
            Matrix = matrix;
            MatrixMap=new List<int[]>();
            FillMap();
            BINGO=false;
            
        }

        private void FillMap() 
        {
         
            for (int i = 0; i < 5; i++)
            {
                int[] zeroes = { 0, 0, 0, 0, 0 };
                MatrixMap.Add(zeroes);

            }
        }
        public void PrintMatrixMap()
        {
            foreach (var i in MatrixMap)
            {
                i.ToList().ForEach(j => Write(format:"{0,3}",arg0:j.ToString()));

                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void PrintMatrix()
        {
            foreach (var number in Matrix)
            {
                number.ToList().ForEach((j) => Write(format:"{0,3}",arg0: j.ToString() + ' '));
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Checknumber(int number)
        {
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if(number == Matrix[i][j])
                    {
                        //Console.WriteLine($"I AM EQUAL {number} with {Matrix[i][j]}");
                        MatrixMap[i][j] = 1;
                        //Console.WriteLine($"writing at {i} {j}");
                    }
                }
            }
        }

        public void CheckMapRowColumn()
        {
            int[] bingoSequence = { 1, 1, 1, 1, 1 };
            for(int i = 0; i< 5; i++)
            {
                int[] row = new int[5];
                for(int j =0;j < 5; j++)
                {
                    row[j] = MatrixMap[i][j];
                }
                bool isBingo = Enumerable.SequenceEqual(bingoSequence, row);
                if (isBingo)
                {
                    Console.WriteLine("FUCK YEAH HERE IS BINGO MY BOI");
                    BINGO=true;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                int[] row = new int[5];
                for (int j = 0; j < 5; j++)
                {
                    row[j] = MatrixMap[j][i];
                }
                bool isBingo = Enumerable.SequenceEqual(bingoSequence, row);
                if (isBingo)
                {
                    Console.WriteLine("FUCK YEAH HERE IS BINGO MY BOI");
                    BINGO = true;
                }
            }
        }

        public int SumOfUnmarkedNumbers(int winningNumber)
        {
            int sum = 0;
            for(int i=0; i< 5; i++)
            {
                for(int j=0; j< 5; j++)
                {
                    if(MatrixMap[i][j] == 0)
                    {
                        sum += Matrix[i][j];
                    }
                }
            }
            Console.WriteLine($"Well the sum is: {sum*winningNumber}");
            return sum;
        }
    }
}
