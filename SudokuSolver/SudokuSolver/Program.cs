using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SudokuSolverLibrary;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            SudokuBoard board = LoadBoard(@"input");
            Solver solver = new Solver(board);
            solver.Resolve();
            SaveBoard("output", solver.GetBoard());
        }

        private static SudokuBoard LoadBoard(string inputFile)
        {
            byte?[][] emptyBoard = new byte?[9][] {
                new byte?[] { null,null,null,null,null,null,null,null,null },
                new byte?[] { null,null,null,null,null,null,null,null,null },
                new byte?[] { null,null,null,null,null,null,null,null,null },
                new byte?[] { null,null,null,null,null,null,null,null,null },
                new byte?[] { null,null,null,null,null,null,null,null,null },
                new byte?[] { null,null,null,null,null,null,null,null,null },
                new byte?[] { null,null,null,null,null,null,null,null,null },
                new byte?[] { null,null,null,null,null,null,null,null,null },
                new byte?[] { null,null,null,null,null,null,null,null,null },
            };

            SudokuBoard board = new SudokuBoard(emptyBoard);

            string[] lines = File.ReadAllLines(inputFile);
            char value;

            for (byte i = 0; i < 9; i++)
            {
                for (byte j = 0; j < 9; j++)
                {
                    if ((value = lines[i][j]) != '?')
                        board.SetElement(Convert.ToByte(value.ToString()), i, j);
                }
            }

            return board;
        }

        private static void SaveBoard (string outpuFile, SudokuBoard board)
        {
            using (StreamWriter writer = new StreamWriter(outpuFile))
            {
                StringBuilder builder = new StringBuilder();
                for (byte i = 0; i < 9; i++)
                {
                    for (byte j = 0; j < 9; j++)
                    {
                        builder.Append(board.GetElement(i, j));
                    }
                    writer.WriteLine(builder.ToString());
                    builder.Clear();
                }
            }
        }
    }
}
