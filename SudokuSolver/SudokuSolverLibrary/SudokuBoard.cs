using System;
using System.Collections.Generic;

namespace SudokuSolverLibrary
{
    public class SudokuBoard
    {
        private SudokuBoardPiece[][] board = new SudokuBoardPiece[3][] {
            new SudokuBoardPiece[] { new SudokuBoardPiece(), new SudokuBoardPiece(), new SudokuBoardPiece() },
            new SudokuBoardPiece[] { new SudokuBoardPiece(), new SudokuBoardPiece(), new SudokuBoardPiece() },
            new SudokuBoardPiece[] { new SudokuBoardPiece(), new SudokuBoardPiece(), new SudokuBoardPiece() }
        };

        public SudokuBoard()
        {
        }

        public SudokuBoard(byte?[][] board)
        {
            if (board.Length != 9 || board[0].Length != 9)
                throw new ArgumentException("Board size must be 9x9");

            for(byte x = 0; x < 9; x ++)
            {
                for(byte y = 0; y < 9; y++)
                {
                    this.board[x / 3][y / 3].SetElement(board[y][x], Convert.ToByte(x % 3), Convert.ToByte(y % 3));
                }
            }
        }

        public byte GetElement(byte x, byte y)
        {
            if (x > 8 || y > 8)
                throw new ArgumentException("X and Y coordinates must be in range 0 to 2");

            return this.board[x / 3][y / 3].GetElement(Convert.ToByte(x % 3), Convert.ToByte(y % 3)).Value;
        }

        public byte GetElement(byte n)
        {
            if (n > 80)
                throw new ArgumentException("N must be in range 0 to 80");

            return this.board[n / 9 /3][n / 9 % 3].GetElement(Convert.ToByte(n / 9 % 3), Convert.ToByte(n % 3)).Value;
        }

        private byte[] GetHorizontalLineValues(byte line)
        {
            List<byte> elements = new List<byte>();
            byte? currentElement;

            if (line > 8)
                throw new ArgumentException("Line number must be lower than 9");

            for (byte i = 0; i < 9; i++)
            {
                if ((currentElement = GetElement(i, line)) != null)
                    elements.Add(currentElement.Value);
            }

            elements.Sort();
            return elements.ToArray();
        }

        private byte[] GetVerticalLineValues(byte line)
        {
            List<byte> elements = new List<byte>();
            byte? currentElement;

            if (line > 8)
                throw new ArgumentException("Line number must be lower than 9");

            for (byte i = 0; i < 9; i++)
            {
                if ((currentElement = GetElement(line, i)) != null)
                    elements.Add(currentElement.Value);
            }

            elements.Sort();
            return elements.ToArray();
        }

        public bool IsInHorizontalLine(byte value, byte line)
        {
            if (value < 1 || value > 9)
                throw new ArgumentException("Value must be in range 1 to 9 or NULL");

            if (line > 8)
                throw new ArgumentException("Line number must be lower than 9");

            var elements = this.GetHorizontalLineValues(line);

            foreach (var i in elements)
            {
                if (i == value)
                    return true;
                if (i > value)
                    return false;
            }

            return false;
        }

        public bool IsInVerticalLine(byte value, byte line)
        {
            if (value < 1 || value > 9)
                throw new ArgumentException("Value must be in range 1 to 9 or NULL");

            if (line > 8)
                throw new ArgumentException("Line number must be lower than 9");

            var elements = this.GetVerticalLineValues(line);

            foreach (var i in elements)
            {
                if (i == value)
                    return true;
                if (i > value)
                    return false;
            }

            return false;
        }
    }

    public class SudokuBoardPiece
    {
        private Nullable<byte>[][] board;

        public SudokuBoardPiece()
        {
            board = new byte?[3][] { new byte?[3], new byte?[3] , new byte?[3] };
        }

        public SudokuBoardPiece(byte?[][] board)
        {
            this.board = board;
        }

        public void SetElement(byte? value, byte x, byte y)
        {
            if (value.HasValue && (value < 1 || value > 9))
                throw new ArgumentException("Value must be in range 1 to 9 or NULL");

            if (x > 2 || y > 2)
                throw new ArgumentException("X and Y coordinates must be in range 0 to 2");

            this.board[y][x] = value;
        }

        public byte? GetElement(byte x, byte y)
        {
            if (x > 2 || y > 2)
                throw new ArgumentException("X and Y coordinates must be in range 0 to 2");

            return this.board[y][x];
        }

        public byte? GetElement(byte n)
        {
            if (n > 8)
                throw new ArgumentException("N must be in range 0 to 8");

            return this.board[n / 3][n % 3];
        }

        public byte[] GetListOfUsedElements()
        {
            List<byte> elements = new List<byte>();
            byte? currentElement;

            for (byte i = 0; i < 9; i++)
            {
                if ((currentElement = GetElement(i)) != null)
                    elements.Add(currentElement.Value);
            }

            elements.Sort();
            return elements.ToArray();
        }

        public bool IsInPiece(byte value)
        {
            var elements = this.GetListOfUsedElements();

            foreach (var i in elements)
            {
                if (i == value)
                    return true;
                if (i > value)
                    return false;
            }

            return false;
        }
    }

}
