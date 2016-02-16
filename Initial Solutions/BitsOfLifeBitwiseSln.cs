using System;

public class BitsOfLife
{
    public static void Main(string[] args)
    {
        int[] table = new int[11];
        int[] nextTable = new int[10];

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            table[row] = table[row] | (1 << column);
        }

        for (int row = 0; row < 10; row++)
        {
            nextTable[row] = table[row];

            for (int position = 0; position < 10; position++)
            {
                int upLeftCell = 0;
                int upCell = 0;
                int upRightCell = 0;

                if (row != 0)
                {
                    upLeftCell = table[row - 1] & (1 << (position + 1));
                    upLeftCell = upLeftCell >> (position + 1);

                    upCell = table[row - 1] & (1 << position);
                    upCell = upCell >> position;

                    upRightCell = table[row - 1] & (1 << position - 1);
                    upRightCell = upRightCell >> (position - 1);
                }

                int leftCell = table[row] & (1 << position + 1);
                leftCell = leftCell >> (position + 1);

                int rightCell = table[row] & (1 << position - 1);
                rightCell = rightCell >> (position - 1);

                int downRightCell = table[row + 1] & (1 << position - 1);
                downRightCell = downRightCell >> (position - 1);

                int downCell = table[row + 1] & (1 << position);
                downCell = downCell >> position;

                int downLeftCell = table[row + 1] & (1 << position + 1);
                downLeftCell = downLeftCell >> (position + 1);

                int aliveNeighbours = leftCell + upLeftCell + upCell + upRightCell + rightCell + downRightCell
                                      + downCell + downLeftCell;

                int currentCell = table[row] & (1 << position);

                if (currentCell == 0 && aliveNeighbours == 3)
                {
                    nextTable[row] = nextTable[row] | (1 << position);
                }
                else if (currentCell != 0)
                {
                    if (aliveNeighbours < 2 || aliveNeighbours > 3)
                    {
                        nextTable[row] = nextTable[row] & ~(1 << position);
                    }
                }
            }
        }

        foreach (int number in nextTable)
        {
            Console.WriteLine(Convert.ToString(number, 2).PadLeft(10, '0'));
        }
    }
}