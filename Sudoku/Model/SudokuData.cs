using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Model
{
	public class SudokuData
	{
		private int[,] grid;

		public int[,] Grid
		{
			get { return grid; }
			set { grid = value; }
		}
		
		public SudokuData()
		{
			grid = new int[9, 9];

			for(int x = 0; x < 9; x++)
			{
				for(int y = 0; y < 9; y++)
				{
					grid[x, y] = 0;
				}
			}
		}

		public bool CheckRow(int y, int value)
		{
			for(int x = 0; x < 9; x++)
			{
				if(grid[x, y] == value)
				{
					return false;
				}
			}

			return true;
		}

		public bool CheckRow(int x, int y, int value)
		{
			for (int t = 0; t < 9; t++)
			{
				if (t != x && grid[t, y] == value)
				{
					return false;
				}
			}

			return true;
		}

		public bool CheckColumn(int x, int value)
		{
			for (int y = 0; y < 9; y++)
			{
				if (grid[x, y] == value)
				{
					return false;
				}
			}

			return true;
		}

		public bool CheckColumn(int x, int y, int value)
		{
			for (int t = 0; t < 9; t++)
			{
				if (t != y && grid[x, t] == value)
				{
					return false;
				}
			}

			return true;
		}

		public bool CheckSquare(int x, int y, int value)
		{
			return CheckSquare(x, y, value, false);
		}
		
		public bool CheckSquare(int x, int y, int value, bool exclude)
		{
            int squareX = (int)Math.Floor(((double)x) / 3) * 3;
            int squareY = (int)Math.Floor(((double)y) / 3) * 3;

			for(int testX = 0; testX < 3; testX ++)
			{
				for(int testY = 0; testY < 3; testY ++)
				{
                    if (grid[squareX + testX, squareY + testY] == value)
                    {
                        return false;
                    }
				}
			}

			return true;
		}

		public bool CheckPosition(int x, int y)
		{
			int value = grid[x, y];
			return value != 0 && CheckRow(x, y, value) && CheckColumn(x, y, value) && CheckSquare(x, y, value, true);
		}

		public bool CheckPosition(int x, int y, int value)
		{
			return CheckRow(y, value) && CheckColumn(x, value) && CheckSquare(x, y, value);
		}
	}
}
