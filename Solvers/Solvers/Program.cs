using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Solvers
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            List<string[]> sudokus = new List<string[]>();
            // Read the file and display it line by line.
            using (System.IO.StreamReader file = new System.IO.StreamReader("Data\\sudoku9x9.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    sudokus.Add(line.Split());
                }
                file.Close();
            }

            long elapsedTime = 0;
            int count = 0;
            foreach (string[] s in sudokus)
            {
                Sudoku sudoku = new Sudoku();
                Sudoku.Board board = sudoku.Read(9, s[0]);

                Console.Write(board);
                stopwatch.Restart();
                sudoku.SolveBinaryHeap(board);
                elapsedTime += stopwatch.ElapsedMilliseconds;
                count++;
#if DEBUG
                if (s.Length == 2)
                {
                    Sudoku.Board answer = sudoku.Read(9, s[1]);
                    Debug.Assert(board == answer); // Check if answer is correct
                }
#endif
                Console.Write(board);
            }
            Console.WriteLine($"Time: {elapsedTime} ms for {count} sudokus, average {elapsedTime / count} ms");
            Console.ReadKey();
        }
    }
}
