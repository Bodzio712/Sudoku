using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolverLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverLibrary.Tests
{
    [TestClass()]
    public class SudokuBoardTests
    {
        byte?[][] testBoard = new byte?[9][] {
            new byte?[] { 1,2,3,4,5,6,7,8,9 },
            new byte?[] { 2,3,4,5,6,7,8,9,1 },
            new byte?[] { 3,4,5,6,7,8,9,1,2 },
            new byte?[] { 4,5,6,7,8,9,1,2,3 },
            new byte?[] { 5,6,7,8,9,1,2,3,4 },
            new byte?[] { 6,7,8,9,1,2,3,4,5 },
            new byte?[] { 7,8,9,1,2,3,4,5,6 },
            new byte?[] { 8,9,1,2,3,4,5,6,7 },
            new byte?[] { 9,1,2,3,4,5,6,7,8 }
        };

        [TestMethod()]
        public void GetElementTest()
        {
            SudokuBoard board = new SudokuBoard(testBoard);

            if (board.GetElement(0, 0) != 1)
                Assert.Fail("Nieprawidłowa wartość pobrana po koordynatach");

            if (board.GetElement(27) != 4)
                Assert.Fail("Nieprawidłowa wartość pobrana po kolejności");

            if (board.GetElement(25) != 1)
                Assert.Fail("Nieprawidłowa wartość pobrana po kolejności");
        }
    }
}