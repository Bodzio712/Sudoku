using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SudokuSolverLibrary;

namespace SudokuSolver
{
    public class Solver
    {
        private SudokuBoard board;

        private const byte MAX_INTERATIONS_NUMER = 81;

        public Solver(byte?[][] board)
        {
            this.board = new SudokuBoard(board);
        }

        public Solver(SudokuBoard board)
        {
            this.board = board;
        }

        public SudokuBoard GetBoard()
        {
            return board;
        }

        public bool PlaceEveryPossible()
        {
            bool anyChangers = false; 
            for (byte i = 0; i < 81; i++)
            {
                var notPresentValues = board.FindNotPresentValues(i);
                if (notPresentValues.Length == 1 && board.GetElement(i) == null)
                {
                    board.SetElement(notPresentValues[0], i);
                    anyChangers = true;
                }
            }
            return anyChangers;
        }

        public bool Resolve()
        {
            for (byte i = 0; i < MAX_INTERATIONS_NUMER; i++)
            {
                if (!PlaceEveryPossible())
                    return true;
            }
            return false;
        }
    }
}
