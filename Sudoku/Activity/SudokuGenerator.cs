using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Model;
using Sudoku.Utils;
using System.Diagnostics;

namespace Sudoku.Activity
{
	public class SudokuGenerator
	{
        private SudokuData grid;
        public List<int>[,] blockingNumbers;
        public int x, y, dX, stepCount;

        public SudokuData Grid
        {
            get { return grid; }
            set { grid = value; }
        }

        public SudokuGenerator()
		{
			grid = new SudokuData();
		}

        public void GenerateGrid()
        {
            // Initialisation de la grille des nombres bloquants
			InitBlockingNumbers();

            // Initialisation du parcours de la grille
			InitPosition(0, 0);

			// Générer le premier nombre
			stepCount = 0;
			while (grid.Grid[x, y] == 0)
			{
				GenerateNumber(true);
				stepCount++;
			}
        }

		public void InitBlockingNumbers()
		{
			blockingNumbers = new List<int>[9, 9];

			for (int x = 0; x < 9; x++)
			{
				for (int y = 0; y < 9; y++)
				{
					blockingNumbers[x, y] = new List<int>();
				}
			}
		}

		public void InitPosition()
		{
			dX = 1;
			x = Tools.Random(0, 8);
			y = Tools.Random(0, 8);
		}

		public void InitPosition(int x, int y)
		{
			dX = 1;
			this.x = x;
			this.y = y;
		}

        public void GenerateNumber(bool continueEnabled)
		{
            int value;

            // Si on est pas arrivé à la première case déjà remplie
            if(grid.Grid[x, y] == 0)
            {
                // On choisi la valeur
                do
                {
                    value = Tools.Random(1, 9);
                }
                while(blockingNumbers[x, y].Count != 9 && IsBlockingNumber(value));

                // Situation bloquante
                if(blockingNumbers[x, y].Count == 9)
                {
                    // On vide la liste des nombres bloquants
                    blockingNumbers[x, y].RemoveRange(0, 9);

                    grid.Grid[x, y] = 0;

                    // On revient en arrière
                    PreviousPosition();

                    // Dans la case précédente, on ajoute dans la liste des nombres bloquant le nombre précédemment choisi
                    blockingNumbers[x, y].Add(grid.Grid[x, y]);

					grid.Grid[x, y] = 0;
                }
                else
                {
                    // On a trouvé un nombre qui fonctionne
                    grid.Grid[x, y] = value;

                    // On avance d'une position
                    NextPosition();
                }
            }
		}

        public void NextPosition()
        {
            // Aller à la position suivante pour x
            x += dX;

            // Si sortie de grille, inverser le sens et incrémenter x à nouveau
            if(x == -1 || x == 9)
            {
                dX *= -1;
                x += dX;

                // Passer à la ligne suivante
                y++;

                // Si y atteint son max (9), remettre à 0 
                if(y == 9)
                {
                    y = 0;

					if (x == 0)
					{
						x = 8;
					}
					else if(x == 8)
					{
						x = 0;
					}

					dX *= -1;
                }
            }
        }

        public void PreviousPosition()
        {
            // Aller à la position précédente pour x
            x -= dX;

            // Si sortie de grille, modifier le sens et décrémenter x à nouveau
            if (x == -1 || x == 9)
            {
                dX *= -1;
                x -= dX;

                // Passer à la ligne précédente
                y--;

                // Si y dépasse 0, repositionner la valeur à 8 pour continuer la boucle de déplacement (circulaire) 
                if (y == -1)
                {
                    y = 8;

					if (x == 0)
					{
						x = 8;
					}
					else if (x == 8)
					{
						x = 0;
					}

					dX *= -1;
                }
            }
        }

        public bool IsBlockingNumber(int value)
        {
            // Déjà dans la liste des nombres bloquants
            if(blockingNumbers[x, y].Contains(value))
            {
                return true;
            }
            // Ne fonctionne pas dans la grille
            else if(!grid.CheckPosition(x, y, value))
            {
                blockingNumbers[x, y].Add(value);
                return true;
            }
            // Fonctionne (nombre non-bloquant)
            else
            {
                return false;
            }
        }

		public void trace()
		{
			string trace = "";
			for (y = 0; y < 9; y++)
			{
				for (x = 0; x < 9; x++)
				{
					trace += grid.Grid[x, y] + " ";
				}

				trace += "\n";
			}

			Console.Write(trace);
		}
	}
}
