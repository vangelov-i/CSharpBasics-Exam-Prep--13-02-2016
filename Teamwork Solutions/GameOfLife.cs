namespace GameOfLife
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int n = int.Parse(Console.ReadLine());

            int[] board = new int[11];
            int[] nextBoard = new int[10];

            for (int i = 0; i < n; i++)
            {
                int row = int.Parse(Console.ReadLine());
                int column = int.Parse(Console.ReadLine());
                int mask = 1;
                board[row] = board[row] | (mask << column);
                nextBoard[row] = nextBoard[row] | (mask << column);
            }

            

            Console.WriteLine();

            for (int row = 0; row < board.Length - 1 ; row++)
            {
                for (int position = 0; position < 10; position++)
                {
                    int mask = 1;
                    int upCell = 0;
                    int leftUpCell = 0;
                    int rightUpCell = 0;

                    if (row > 0)
                    {
                        upCell = board[row - 1] & (mask << position);
                        upCell = upCell >> position;

                        leftUpCell = board[row - 1] & (mask << position + 1);
                        leftUpCell = leftUpCell >> position + 1;

                        rightUpCell = board[row - 1] & (mask << position - 1);
                        rightUpCell = rightUpCell >> position - 1;
                    }

                    int leftCell = board[row] & (mask << position + 1);
                    leftCell = leftCell >> position + 1;

                    int zeroBit = mask << position - 1;
                    int rightCell = board[row] & (mask << position - 1);
                    rightCell = rightCell >> position - 1;

                    int rightDownCell = board[row + 1] & (mask << position - 1);
                    rightDownCell = rightDownCell >> position - 1;

                    int downCell = board[row + 1] & (mask << position);
                    downCell = downCell >> position;

                    int leftDownCell = board[row + 1] & (mask << position + 1);
                    leftDownCell = leftDownCell >> position + 1;

                    int aliveNeighbours = 
                        leftCell + leftUpCell + upCell + 
                        rightUpCell + rightCell + 
                        rightDownCell + downCell + leftDownCell;
                    int currentCell = board[row] & (mask << position);
                    currentCell = currentCell >> position;

                    if (currentCell == 0)
                    {
                        if (aliveNeighbours == 3)
                        {
                            nextBoard[row] = nextBoard[row] | (mask << position);
                        }
                    }
                    else
                    {
                        if (aliveNeighbours < 2 || aliveNeighbours > 3)
                        {
                            nextBoard[row] = nextBoard[row] ^ (mask << position);
                        }
                    }
                }
            }

            foreach (var i in nextBoard)
            {
                Console.WriteLine(Convert.ToString(i, 2).PadLeft(10, '0'));
            }
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }
    }
}