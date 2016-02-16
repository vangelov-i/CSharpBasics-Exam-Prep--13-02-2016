using System;

public class BitsOfLife
{
    public static void Main(string[] args)
    {
        int[,] table = new int[11, 11];
        int[,] nextTable = new int[10, 10];

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());
            column = 9 - column;

            table[row, column] = 1;
            nextTable[row, column] = 1;
        }

        for (int row = 0; row < 10; row++)
        {
            for (int position = 9; position >= 0; position--)
            {
                int upLeftCell = 0;
                int upCell = 0;
                int upRightCell = 0;
                int rightCell = 0;
                int downRightCell = 0;

                if (row != 0)
                {
                    upLeftCell = table[row - 1, position + 1];

                    upCell = table[row - 1, position];

                    if (position > 0)
                    {
                        upRightCell = table[row - 1, position - 1];
                    }
                }

                if (position != 0)
                {
                    rightCell = table[row, position - 1];
                    downRightCell = table[row + 1, position - 1];
                }

                int leftCell = table[row, position + 1];
                int downCell = table[row + 1, position];
                int downLeftCell = table[row + 1, position + 1];

                int aliveNeighbours =
                    leftCell + upLeftCell + downLeftCell +
                    rightCell + upRightCell + downRightCell +
                    downCell + upCell;

                int currentCell = table[row, position];

                if (currentCell == 0 && aliveNeighbours == 3)
                {
                    nextTable[row, position] = 1;
                }
                else if (currentCell != 0)
                {
                    if (aliveNeighbours < 2 || aliveNeighbours > 3)
                    {
                        nextTable[row, position] = 0;
                    }
                }
            }
        }

        for (int row = 0; row < nextTable.GetLength(0); row++)
        {
            for (int column = 0; column < nextTable.GetLength(1); column++)
            {
                Console.Write(nextTable[row, column]);
            }
            Console.WriteLine();
        }
    }
}