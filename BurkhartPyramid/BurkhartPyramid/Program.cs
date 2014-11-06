using System;

namespace BurkhartPyramid
{
    /*The "Burkhart Pyramid" is defined as a pyramid of numbers, that is built upside down.  
     * At the base of the triangle, it contains a number.  In this example we’ll use 1.  To construct levels beyond the base,
     * add the number below and to the left with the number below and to the right. If the number is not present, assume it a 0.  
     * These pyramids can be built with any number of levels, and any number at the base, so those must be configurable in your program.  
     * Levels should be centered with the base as below.   For example, if I pass in a 1 for the base and 6 levels the pyramid 
     * would look like this:
     */
    class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                Console.Clear();

                int rows = 0;
                var baseNumber = 0;

                var baseNumberIsValid = false;
                var rowsIsValid = false;

                Console.WriteLine("Enter the Base Number: ");
                var inputBaseNumber = String.Empty;
                while (!baseNumberIsValid)
                {
                    inputBaseNumber = Console.ReadLine();
                    if (int.TryParse(inputBaseNumber, out baseNumber))
                    {
                        if (baseNumber <= 0)
                        {
                            Console.WriteLine("Base Number must be greater than zero.");
                        }
                        else 
                        {
                            baseNumberIsValid = true;                        
                        }
                    }
                    else 
                    {
                        Console.WriteLine("Not cool, enter the Base Number");
                    }
                }

                Console.WriteLine("Enter the number of rows: ");
                var inputRows = String.Empty;
                while (!rowsIsValid) 
                {
                    inputRows = Console.ReadLine();
                    if (int.TryParse(inputRows, out rows))
                    {
                        if (rows <= 0)
                        {
                            Console.WriteLine("Number of rows must be greater than zero.");
                        }
                        else
                        {
                            rowsIsValid = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not cool, enter the number of rows: ");
                    }
                }

                var board = Calculate(baseNumber, rows);
                PrintBoard(board);
                Console.Write("Press any key to continue...");
                Console.ReadLine();
            }

        }

        public static int[,] Calculate(int baseNumber, int levels)
        {
            var rows = levels;
            int columns = (2 * rows) - 1;

            var board = new int[rows,columns];

            // first row    
            var row = levels-1;
            var center = (columns + 1) / 2;                           // 1. get center column
            for (var i = 0; i < columns - 1; i++)                     // 2. set all to zero, except center... set that to baseNumber
            {
                if (i+1 == center){
                    board[row,i]=baseNumber;
                    break;
                }
            }

            // second through nth row
            for (var k = 0; k < levels-1; k++) {
                row = levels - (2 + k);
                for (var column = 0; column < columns; column++)
                {
                    var leftColumn = (column == 0 ? 0 : column - 1);
                    var rightColumn = (column == columns - 1 ? 0 : column + 1);
                    board[row, column] = board[row + 1, leftColumn] + board[row + 1, rightColumn];
                }
            }

            return board;
        }

        public static void PrintBoard(int[,] board)
        {
            int width = board.GetLength(1);
            int height = board.GetLength(0);

            // each row
            for (var i = 0; i < height; i++) 
            {
                // each column
                for (var k = 0; k < width; k++) 
                {
                    var val = board[i, k];
                    if (val > 0)
                    {
                        Console.Write(val);
                    }
                    else 
                    {
                        Console.Write(" ");
                    }
                    
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
