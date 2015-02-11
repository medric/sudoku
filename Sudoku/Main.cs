using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sudoku.Activity;
using Sudoku.Utils;
using System.Diagnostics;


namespace Sudoku
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
		}

		private void Btn_Generate_Click(object sender, EventArgs e)
		{

            var watch = Stopwatch.StartNew();
            long elapsedMs = 0;

            SudokuGenerator generator = new SudokuGenerator();
            generator.GenerateGrid();

            //La grille est générée

            int[,] grid;

            grid = new int[9, 9];
 
            //Affiche la grille
            PopulateSudokuDataGridView(generator.Grid.Grid);
            FormatSudokuDataGridView();  
        }

        private void FormatSudokuDataGridView()
        {
            //Suppression de l'auto-sélection sur la première cellule
            sudokuDataGridView.CurrentCell = null;

            //Ajout des borders pour délimiter les sous-tableaux (3 x 3)
            sudokuDataGridView.Rows[2].DividerHeight = 3;
            sudokuDataGridView.Rows[5].DividerHeight = 3;
            sudokuDataGridView.Columns[2].DividerWidth = 3;
            sudokuDataGridView.Columns[5].DividerWidth = 3;
        }

        private void PopulateSudokuDataGridView(int[,] grid)
        {   
            string[] row = new string[9];

            //Efface la grille avant de la remplir
            sudokuDataGridView.Rows.Clear();

            for (int i = 0; i < 9; i++)
            {
                Array.Clear(row, 0, 9);

                for (int j = 0; j < 9; j++)
                {
                    row[j] = grid[j, i].ToString();
                }

                sudokuDataGridView.Rows.Add(row); 
            }
        }
	}
}
