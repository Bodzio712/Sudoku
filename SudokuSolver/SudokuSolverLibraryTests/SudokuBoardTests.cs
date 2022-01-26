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
            new byte?[] { 4,5,6,7,8,9,1,2,3 },
            new byte?[] { 7,8,9,1,2,3,4,5,6 },
            new byte?[] { 2,3,4,5,6,7,8,9,1 },
            new byte?[] { 5,6,7,8,9,1,2,3,4 },
            new byte?[] { 8,9,1,2,3,4,5,6,7 },
            new byte?[] { 3,4,5,6,7,8,9,1,2 },
            new byte?[] { 6,7,8,9,1,2,3,4,5 },
            new byte?[] { 9,1,2,3,4,5,6,7,8 }
        };

        byte?[][] testPiece = new byte?[3][] {
            new byte?[] { 9,1,2 },
            new byte?[] { 3,4,5 },
            new byte?[] { 6,7,8 }
        };

        [TestMethod()]
        public void GetElementTest()
        {
            SudokuBoard board = new SudokuBoard(testBoard);

            if (board.GetElement(0, 1) != testBoard[1][0])
                Assert.Fail("Nieprawidłowa wartość pobrana po koordynatach");

            if (board.GetElement(27) != 2)
                Assert.Fail("Nieprawidłowa wartość pobrana po kolejności element nr 27");

            if (board.GetElement(25) != 5)
                Assert.Fail("Nieprawidłowa wartość pobrana po kolejności element nr 25");

            if (board.GetElement(71) != 5)
                Assert.Fail("Nieprawidłowa wartość pobrana po kolejności element nr 71");
        }

        [TestMethod()]
        public void GetPieceTest()
        {
            SudokuBoard board = new SudokuBoard(testBoard);
            SudokuBoardPiece refPiece = new SudokuBoardPiece(testPiece);

            var piece = board.GetPiece(6, 7);

            for (byte i = 0; i < 9; i++)
            {
                if (refPiece.GetElement(i) != piece.GetElement(i))
                {
                    Assert.Fail("GetPiece returned failed");
                }
            }
        }

        [TestMethod()]
        public void IsPresentTest()
        {
            SudokuBoard board = new SudokuBoard(testBoard);
            board.SetElement(null, 6, 3);

            if (board.IsPresent(8, 6, 3))
                Assert.Fail("Fałszywie obecna liczba");
        }

        [TestMethod()]
        public void FindNotPresentValuesTest()
        {
            SudokuBoard board = new SudokuBoard(testBoard);
            board.SetElement(null, 7, 3);
            board.SetElement(null, 7, 2);
            board.SetElement(null, 3, 3);
            board.SetElement(null, 6, 5);

            var noPresentValues = board.FindNotPresentValues(34);

            byte[] refValues = { 5, 9 };

            if (!Enumerable.SequenceEqual<byte>(refValues, noPresentValues))
                Assert.Fail("Can't find correct not present values");
        }

        [TestMethod()]
        public void SetElementTest()
        {
            SudokuBoard board = new SudokuBoard(testBoard);
            board.SetElement(null, 5, 7);

            if (board.GetElement(5, 7) != null)
                Assert.Fail("Przypisano niewłaściwą wartość");
        }

        [TestMethod()]
        public void IsInHorizontalLineTest()
        {
            SudokuBoard board = new SudokuBoard(testBoard);
            board.SetElement(null, 5, 7);

            if (board.IsInHorizontalLine(2, 7))
                Assert.Fail("False true");
        }

        [TestMethod()]
        public void IsInVerticalLineTest()
        {
            SudokuBoard board = new SudokuBoard(testBoard);
            board.SetElement(null, 5, 7);

            if (board.IsInVerticalLine(2, 5))
                Assert.Fail("False true");
        }
    }
}