using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine(board.PrettyPrint);
                break;
                sudoku.Solve(board);
                Console.WriteLine(board.PrettyPrint);
            }
            Console.Read();
        }
    }
}
