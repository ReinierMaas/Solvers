using System;

namespace Solvers
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string s in Sudoku.sudokuInput9)
            {
                Sudoku sudoku = new Sudoku();
                Sudoku.Board board = sudoku.Read(9, s);
                Console.Write(board);
                sudoku.SolveBinaryHeap(board);
                Console.Write(board);
            }
            Console.ReadKey();
        }
    }
}
