using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolverLibrary;

namespace SudokuSolverLibrary.Tests
{
    [TestClass()]
    public class SudokuSolverLibraryBoardPieceUnitTest
    {
        [TestMethod()]
        public void GetElementTest()
        {
            SudokuBoardPiece boardPiece = new SudokuBoardPiece();
            boardPiece.SetElement(6, 2, 1);

            if(boardPiece.GetElement(2, 1) != 6)
                Assert.Fail("Zwrócono nieprawidłową niepustą wartość");

            if (boardPiece.GetElement(1, 1) != null)
                Assert.Fail("Zwrócono wartość w miejscu oczekiwanego NULLa");
        }
    }
}
