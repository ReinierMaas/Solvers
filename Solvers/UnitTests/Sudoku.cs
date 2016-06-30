using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Sudoku
    {
        [TestMethod]
        public void Sudoku9X9BinaryHeap()
        {
            foreach (string s in Solvers.Sudoku.sudokuInput9)
            {
                Solvers.Sudoku sudoku = new Solvers.Sudoku();
                Solvers.Sudoku.Board board = sudoku.Read(9, s);
                Assert.IsTrue(sudoku.SolveBinaryHeap(board));
            }
        }

        /// <summary>
        /// Takes up to a minute to execute
        /// </summary>
        [TestMethod]
        public void Sudoku9X9BruteForce()
        {
            foreach (string s in Solvers.Sudoku.sudokuInput9)
            {
                Solvers.Sudoku sudoku = new Solvers.Sudoku();
                Solvers.Sudoku.Board board = sudoku.Read(9, s);
                Assert.IsTrue(sudoku.SolveBruteForce(board));
            }
        }

        /// <summary>
        /// Takes up to a minute to execute
        /// Compares output of bruteforce to binaryheap
        /// </summary>
        [TestMethod]
        public void Sudoku9X9Compare()
        {
            foreach (string s in Solvers.Sudoku.sudokuInput9)
            {
                Solvers.Sudoku sudoku = new Solvers.Sudoku();
                Solvers.Sudoku.Board boardBinaryHeap = sudoku.Read(9, s);
                Solvers.Sudoku.Board boardBruteForce = sudoku.Read(9, s);
                Assert.IsTrue(sudoku.SolveBinaryHeap(boardBinaryHeap));
                Assert.IsTrue(sudoku.SolveBruteForce(boardBruteForce));
                Assert.AreEqual(boardBruteForce, boardBinaryHeap);
            }
        }
    }
}
