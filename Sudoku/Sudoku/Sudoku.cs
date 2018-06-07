using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class Sudoku
    {
        Random rnd = new Random();
        int[,] arr;

        public Sudoku()
        {

        }

        public void Fill_array(Button[,] btn, Color b)
        {
            arr = new int[9, 9];
            for (int k = 0; k < 9; k++)
            {
                for (int j = 0; j < 9; j++)
                {
                    arr[k, j] = (k * 3 + k / 3 + j) % 9 + 1;
                    btn[k, j].BackColor = b;
                }
            }
            int q = rnd.Next(1, 3);
            switch (q)
            {
                case 1:
                    ArrayT(arr);
                    break;
                case 2:
                    ChangeRows(arr);
                    break;
                case 3:
                    ChangeColumns(arr);
                    break;
                case 4:
                    ArrayT(arr);
                    ChangeRows(arr);
                    break;
                case 5:
                    ArrayT(arr);
                    ChangeColumns(arr);
                    break;
                case 6:
                    ChangeRows(arr);
                    ChangeColumns(arr);
                    break;
            }

            for (int k = 0; k < 9; k += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    int a = rnd.Next(2, 5);
                    for (int i = 0; i < a; i++)
                    {
                        int m = rnd.Next(0 + j, 2 + j);
                        int n = rnd.Next(0 + k, 2 + k);
                        btn[m, n].Text = Convert.ToString(arr[m, n]);
                        btn[m, n].Enabled = false;
                    }
                }
            }
        }

        public void Correct(Button[,] btn, Color b)
        {
            bool result = true;
            for (int k = 0; k < 9; k++)
            {
                for (int j = 0; j < 9; j++)
                {
                    btn[k, j].BackColor = b;
                }
            }

            int m = 0, n = 0;
            while (m < 9)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (m == i)
                    {
                        for (int j = 1; j < 9; j++)
                        {
                            if (n == j)
                            {
                                break;
                            }
                            else
                            {
                                if (btn[m, n].Text == btn[i, j].Text && btn[m, n].Text != "" && btn[i, j].Text != "")
                                {
                                    btn[m, n].BackColor = Color.Red;
                                    btn[i, j].BackColor = Color.Red;
                                    result = false;
                                }
                            }
                        }
                    }

                    if (n == i)
                    {
                        for (int j = 1; j < 9; j++)
                        {
                            if (m == j)
                            {
                                break;
                            }
                            else
                            {
                                if (btn[m, n].Text == btn[j, i].Text && btn[m, n].Text != "" && btn[j, i].Text != "")
                                {
                                    btn[m, n].BackColor = Color.Red;
                                    btn[j, i].BackColor = Color.Red;
                                    result = false;
                                }
                            }
                        }
                    }
                }
                n++;
                if (n == 9)
                {
                    m++;
                    n = 0;
                }
            }

            int kolvo = 0;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (btn[x, y].Text != "")
                        kolvo++;
                }
            }

            if (kolvo == 81 && result)
            {
                MessageBox.Show("You won!!!");
            }
        }

        private void ArrayT(int[,] arr)
        {
            int[,] mass = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    mass[i, j] = arr[j, i];
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    arr[i, j] = mass[i, j];
                }
            }
        }

        private void ChangeRows(int[,] arr)
        {
            int[] x = new int[9];
            int[] y = new int[9];
            int row1 = rnd.Next(0, 8);
            int row2 = row1;
            int r;

            for (int i = 0; i < 9; i++)
            {
                x[i] = arr[row1, i];
            }

            if (row1==0 | row1==1 | row1==2)
            {
                r = rnd.Next(0, 1) + 1;
                if (row1 == 2)
                    row1 = row1 - r;
            }

            if (row1 == 3 | row1 == 4 | row1 == 5)
            {
                r = rnd.Next(0, 1) + 1;
                if (row1 == 5) 
                    row1 = row1 - r;
            }

            if (row1 == 6 | row1 == 7 | row1 == 8)
            {
                r = rnd.Next(0, 1) + 1;
                if (row1 == 8)
                    row1 = row1 - r;
            }

            for (int k = 0; k < 9; k++)
            {
                y[k] = arr[row1, k];
            }

            for (int j = 0; j < 9; j++)
            {
                arr[row1, j] = x[j];
                arr[row2, j] = y[j];
            }
        }

        private void ChangeColumns(int[,] arr)
        {
            int[] x = new int[9];
            int[] y = new int[9];
            int col1 = rnd.Next(0, 8);
            int col2 = col1;
            int r;

            for (int i = 0; i < 9; i++)
            {
                x[i] = arr[i, col1];
            }

            if (col1 == 0 | col1 == 1 | col1 == 2)
            {
                r = rnd.Next(0, 1) + 1;
                if (col1 == 2)
                    col1 = col1 - r;
            }

            if (col1 == 3 | col1 == 4 | col1 == 5)
            {
                r = rnd.Next(0, 1) + 1;
                if (col1 == 5)
                   col1 = col1 - r;
            }

            if (col1 == 6 | col1 == 7 | col1 == 8)
            {
                r = rnd.Next(0, 1) + 1;
                if (col1 == 8)
                    col1 = col1 - r;
            }

            for (int k = 0; k < 9; k++)
            {
                y[k] = arr[col1, k];
            }

            for (int j = 0; j < 9; j++)
            {
                arr[j,col1] = x[j];
                arr[j,col2] = y[j];
            }
        }

    }
}
