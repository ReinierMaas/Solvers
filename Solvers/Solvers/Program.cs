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
            List<string[]> sudokus9X9 = new List<string[]>();
            using (System.IO.StreamReader file = new System.IO.StreamReader("Data\\sudoku9x9.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    sudokus9X9.Add(line.Split());
                }
                file.Close();
            }
            List<string[]> sudokus16X16 = new List<string[]>();
            using (System.IO.StreamReader file = new System.IO.StreamReader("Data\\sudoku16x16.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    sudokus16X16.Add(line.Split());
                }
                file.Close();
            }
            List<string[]> sudokus25X25 = new List<string[]>();
            using (System.IO.StreamReader file = new System.IO.StreamReader("Data\\sudoku25x25.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    sudokus25X25.Add(line.Split());
                }
                file.Close();
            }

            long elapsedTime = 0;
            int count = 0;
//            foreach (string[] s in sudokus9X9)
//            {
//                Sudoku sudoku = new Sudoku();
//                Sudoku.Board board = sudoku.Read(9, s[0]);

//                Console.Write(board);
//                stopwatch.Restart();
//                sudoku.SolveBinaryHeap(board);
//                elapsedTime += stopwatch.ElapsedMilliseconds;
//                count++;
//#if DEBUG
//                if (s.Length == 2)
//                {
//                    Sudoku.Board answer = sudoku.Read(9, s[1]);
//                    Debug.Assert(board == answer); // Check if answer is correct
//                }
//#endif
//                Console.Write(board);
//            }
            foreach (string[] s in sudokus16X16)
            {
                Sudoku sudoku = new Sudoku();
                Sudoku.Board board = sudoku.Read(16, s[0]);

                Console.Write(board);
                stopwatch.Restart();
                //sudoku.SolveBinaryHeap(board);
                //elapsedTime += stopwatch.ElapsedMilliseconds;
                //count++;
#if DEBUG
                if (s.Length == 2)
                {
                    Sudoku.Board answer = sudoku.Read(16, s[1]);
                    Debug.Assert(board == answer); // Check if answer is correct
                }
#endif
                //Console.Write(board);
            }
            foreach (string[] s in sudokus25X25)
            {
                Sudoku sudoku = new Sudoku();
                Sudoku.Board board = sudoku.Read(25, s[0]);

                Console.Write(board);
                //stopwatch.Restart();
                //sudoku.SolveBinaryHeap(board);
                //elapsedTime += stopwatch.ElapsedMilliseconds;
                //count++;
#if DEBUG
                if (s.Length == 2)
                {
                    Sudoku.Board answer = sudoku.Read(25, s[1]);
                    Debug.Assert(board == answer); // Check if answer is correct
                }
#endif
                //Console.Write(board);
            }
            //Console.WriteLine($"Time: {elapsedTime} ms for {count} sudokus, average {elapsedTime / count} ms");
            Console.ReadKey();
        }
    }
}
