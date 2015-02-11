using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Utils
{
    public static class Tools
    {
		private static Random randomNumber = new Random();

        public static int Random(int min, int max)
        {
            return randomNumber.Next(min, max + 1);
        }
    }
}
