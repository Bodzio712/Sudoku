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
    public class SudokuBoardPieceTests
    {
        byte?[][] RAW_TEST_BOARD = new byte?[3][] {
            new byte?[] { 1,2,null },
            new byte?[] { null,null,6 },
            new byte?[] { 7,null,9 }
        };

        [TestMethod()]
        public void GetElementTest()
        {
            SudokuBoardPiece testBoard = new SudokuBoardPiece(RAW_TEST_BOARD);

            if (testBoard.GetElement(2, 1) != Convert.ToByte(6))
                Assert.Fail("Zwrócono nieprawidłową niepustą wartość dla wskazania po koordynatach");

            if (testBoard.GetElement(5) != Convert.ToByte(6))
                Assert.Fail("Zwrócono nieprawidłową niepustą wartość dla wskazania po kolejności");

            if (testBoard.GetElement(2, 0) != null)
                Assert.Fail("Zwrócono wartość w miejscu oczekiwanego NULLa");
        }

        [TestMethod()]
        public void GetListOfUsedElementsTest()
        {
            SudokuBoardPiece boardPiece = new SudokuBoardPiece(RAW_TEST_BOARD);

            byte[] correctValues = new byte[] { 1, 2, 6, 7, 9 };

            if (!Enumerable.SequenceEqual<byte>(correctValues, boardPiece.GetListOfUsedElements()))
                Assert.Fail("Pobrana lista elementów nie jest prawidłowa");
        }

        [TestMethod()]
        public void IsInPieceTest()
        {
            SudokuBoardPiece boardPiece = new SudokuBoardPiece(RAW_TEST_BOARD);

            if (!boardPiece.IsInPiece(9))
                Assert.Fail("Nie zuważono skrarnie dużej wartości");

            if (boardPiece.IsInPiece(3))
                Assert.Fail("Fałszywie zauważono wartość");
        }

        [TestMethod()]
        public void SetElementTest()
        {
            SudokuBoardPiece boardPiece = new SudokuBoardPiece(RAW_TEST_BOARD);
            boardPiece.SetElement(6, 2, 1);

            for (byte i = 0; i < 3; i++)
            {
                for (byte j = 0; j < 3; j++)
                {
                    if (boardPiece.GetElement(i, j) != RAW_TEST_BOARD[j][i])
                        Assert.Fail("Different value");
                }
            }
        }
    }
}