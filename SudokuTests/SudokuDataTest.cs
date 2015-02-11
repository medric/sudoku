using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku.Model;

namespace SudokuTests
{
	[TestClass]
	public class SudokuDataTest
	{
		[TestMethod]
		public void TestPositionCheck()
		{
			SudokuData grid = new SudokuData();

			grid.Grid[0, 0] = 1;

			int x = 1;
			int y = 0;

			Assert.IsTrue(grid.CheckColumn(x, 1));
			Assert.IsFalse(grid.CheckRow(y, 1));
			Assert.IsFalse(grid.CheckSquare(x, y, 1));
			Assert.IsFalse(grid.CheckPosition(x, y, 1));

			x = 8;
			y = 8;

			Assert.IsTrue(grid.CheckColumn(x, 1));
			Assert.IsTrue(grid.CheckRow(y, 1));
			Assert.IsTrue(grid.CheckSquare(x, y, 1));
			Assert.IsTrue(grid.CheckPosition(x, y, 1));

			x = 0;
			y = 0;

			Assert.IsTrue(grid.CheckPosition(x, y));
		}
	}
}
