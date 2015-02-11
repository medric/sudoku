using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Activity;

namespace SudokuTests
{
	[TestClass]
	public class SudokuGeneratorTest
	{
		[TestMethod]
		public void TestPositionMovement()
		{
			SudokuGenerator generator = new SudokuGenerator();
			
			generator.InitPosition(0, 0);

			generator.NextPosition();

			Assert.IsTrue(generator.x == 1);
			Assert.IsTrue(generator.y == 0);

			generator.PreviousPosition();

			Assert.IsTrue(generator.x == 0);
			Assert.IsTrue(generator.y == 0);

			generator.PreviousPosition();

			Assert.IsTrue(generator.x == 8);
			Assert.IsTrue(generator.y == 8);

			generator.NextPosition();

			Assert.IsTrue(generator.x == 0);
			Assert.IsTrue(generator.y == 0);

			for(int i = 0; i < 8; i++)
			{
				generator.NextPosition();
			}

			Assert.IsTrue(generator.x == 8);
			Assert.IsTrue(generator.y == 0);

			generator.NextPosition();

			Assert.IsTrue(generator.x == 8);
			Assert.IsTrue(generator.y == 1);

			generator.PreviousPosition();

			Assert.IsTrue(generator.x == 8);
			Assert.IsTrue(generator.y == 0);

			for (int i = 0; i < 8*9; i++)
			{
				generator.NextPosition();
			}

			Assert.IsTrue(generator.x == 8);
			Assert.IsTrue(generator.y == 8);

			generator.InitPosition(0, 8);
			generator.dX = -1;

			generator.NextPosition();

			Assert.IsTrue(generator.x == 8);
			Assert.IsTrue(generator.y == 0);

		}

		[TestMethod]
		public void TestIsBlockingNumber()
		{
			SudokuGenerator generator = new SudokuGenerator();
			generator.InitBlockingNumbers();
			generator.InitPosition(0, 0);

			generator.Grid.Grid[0, 0] = 1;
			generator.NextPosition();

			Assert.IsTrue(generator.IsBlockingNumber(1));
			Assert.IsTrue(generator.blockingNumbers[1, 0].Contains(1));
		}

		[TestMethod]
		public void TestGenerateNumber()
		{
			SudokuGenerator generator = new SudokuGenerator();
			generator.InitBlockingNumbers();
			generator.InitPosition(0, 0);

			generator.Grid.Grid[0, 0] = 1;
			generator.NextPosition();
			generator.GenerateNumber(false);

			Console.WriteLine("[1, 0]=" + generator.Grid.Grid[1, 0]);

			Assert.IsTrue(generator.Grid.CheckPosition(1, 0));
		}

		[TestMethod]
		public void TestSudokuGeneration()
		{
			SudokuGenerator generator = new SudokuGenerator();
			generator.GenerateGrid();

			for(int x = 0; x < 9; x ++)
			{
				for(int y = 0; y < 9; y ++)
				{
					Assert.IsTrue(generator.Grid.CheckPosition(x, y));
				}
			}
		}
	}
}
