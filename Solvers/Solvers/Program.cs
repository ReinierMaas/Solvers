using System;
using System.Diagnostics;

namespace Solvers
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            long elapsedTime = 0;
            int count = 0;
            foreach (string s in Sudoku.sudokuInput9)
            {
                Sudoku sudoku = new Sudoku();
                Sudoku.Board board = sudoku.Read(9, s);
                Console.Write(board);
                stopwatch.Restart();
                sudoku.SolveBinaryHeap(board);
                elapsedTime += stopwatch.ElapsedMilliseconds;
                count++;
                Console.Write(board);
            }
            Console.WriteLine($"Time: {elapsedTime} ms for {count} sudokus, average {elapsedTime / count} ms");
            Console.ReadKey();
        }
    }
}
