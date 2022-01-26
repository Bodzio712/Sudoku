using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolverLibrary;
using SudokuSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Tests
{
    [TestClass()]
    public class SolverTests
    {
        byte?[][] testBoard = new byte?[9][] {
            new byte?[] { 1,2,3,4,5,6,7,8,9 },
            new byte?[] { 4,5,6,7,8,9,1,2,3 },
            new byte?[] { 7,8,9,1,2,3,4,5,6 },
            new byte?[] { 2,3,4,5,6,7,8,9,1 },
            new byte?[] { 5,6,7,8,9,1,2,3,4 },
            new byte?[] { 8,9,1,2,3,4,5,6,7 },
            new byte?[] { 3,4,5,6,7,8,9,1,2 },
            new byte?[] { 6,7,8,9,1,2,3,4,5 },
            new byte?[] { 9,1,2,3,4,5,6,7,8 }
        };

        [TestMethod()]
        public void PlaceEveryPossibleTest()
        {
            SudokuBoard board = new SudokuBoard(testBoard);
            board.SetElement(null, 2);
            board.SetElement(null, 8);
            board.SetElement(null, 21);
            board.SetElement(null, 54);
            board.SetElement(null, 55);
            board.SetElement(null, 56);

            Solver solver = new Solver(board);
            solver.PlaceEveryPossible();

            for (byte i = 0; i < 81; i++)
            {
                if (board.GetElement(i) != testBoard[i / 9][i % 9].Value)
                    Assert.Fail("Boards not the same");
            }
        }

        [TestMethod()]
        public void ResolveTest()
        {
            SudokuBoard board = new SudokuBoard(testBoard);
            board.SetElement(null, 45);
            board.SetElement(null, 46);
            board.SetElement(null, 47);
            board.SetElement(null, 48);
            board.SetElement(null, 49);
            board.SetElement(null, 50);
            board.SetElement(null, 51);
            board.SetElement(null, 52);
            board.SetElement(null, 53);
            board.SetElement(null, 54);
            board.SetElement(null, 6);
            board.SetElement(null, 15);
            board.SetElement(null, 24);
            board.SetElement(null, 33);
            board.SetElement(null, 42);
            board.SetElement(null, 60);
            board.SetElement(null, 69);

            Solver solver = new Solver(board);
            if (!solver.Resolve())
                Assert.Fail("Resolver in infinite loop");

            for(byte i = 0; i < 81; i++)
            {
                if (board.GetElement(i) != testBoard[i / 9][i % 9].Value)
                    Assert.Fail("Boards not the same");
            }
        }
    }
}