using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form4 : Form
    {
        Sudoku sd;
        Button[,] btn;
        Color b;
        int kol;
        Button but;

        public Form4()
        {
            InitializeComponent();
            b = btn1_1.BackColor;
            Fill1();
            kol = 0;
            sd.Fill_array(btn,b);
            but = btn1_1;
        }

        public Form4(Form form1)
        {
            InitializeComponent();
            b = btn1_1.BackColor;
            Fill1();
            sd.Fill_array(btn, b);
        }

        public void Fill1()
        {
            sd = new Sudoku();
            btn = new Button[9, 9];
            btn[0, 0] = btn1_1;
            btn[0, 1] = btn2_1;
            btn[0, 2] = btn3_1;
            btn[0, 3] = btn1_2;
            btn[0, 4] = btn2_2;
            btn[0, 5] = btn3_2;
            btn[0, 6] = btn1_3;
            btn[0, 7] = btn2_3;
            btn[0, 8] = btn3_3;

            btn[1, 0] = btn4_1;
            btn[1, 1] = btn5_1;
            btn[1, 2] = btn6_1;
            btn[1, 3] = btn4_2;
            btn[1, 4] = btn5_2;
            btn[1, 5] = btn6_2;
            btn[1, 6] = btn4_3;
            btn[1, 7] = btn5_3;
            btn[1, 8] = btn6_3;

            btn[2, 0] = btn7_1;
            btn[2, 1] = btn8_1;
            btn[2, 2] = btn9_1;
            btn[2, 3] = btn7_2;
            btn[2, 4] = btn8_2;
            btn[2, 5] = btn9_2;
            btn[2, 6] = btn7_3;
            btn[2, 7] = btn8_3;
            btn[2, 8] = btn9_3;

            btn[3, 0] = btn1_4;
            btn[3, 1] = btn2_4;
            btn[3, 2] = btn3_4;
            btn[3, 3] = btn1_5;
            btn[3, 4] = btn2_5;
            btn[3, 5] = btn3_5;
            btn[3, 6] = btn1_6;
            btn[3, 7] = btn2_6;
            btn[3, 8] = btn3_6;

            btn[4, 0] = btn4_4;
            btn[4, 1] = btn5_4;
            btn[4, 2] = btn6_4;
            btn[4, 3] = btn4_5;
            btn[4, 4] = btn5_5;
            btn[4, 5] = btn6_5;
            btn[4, 6] = btn4_6;
            btn[4, 7] = btn5_6;
            btn[4, 8] = btn6_6;

            btn[5, 0] = btn7_4;
            btn[5, 1] = btn8_4;
            btn[5, 2] = btn9_4;
            btn[5, 3] = btn7_5;
            btn[5, 4] = btn8_5;
            btn[5, 5] = btn9_5;
            btn[5, 6] = btn7_6;
            btn[5, 7] = btn8_6;
            btn[5, 8] = btn9_6;

            btn[6, 0] = btn1_7;
            btn[6, 1] = btn2_7;
            btn[6, 2] = btn3_7;
            btn[6, 3] = btn1_8;
            btn[6, 4] = btn2_8;
            btn[6, 5] = btn3_8;
            btn[6, 6] = btn1_9;
            btn[6, 7] = btn2_9;
            btn[6, 8] = btn3_9;

            btn[7, 0] = btn4_7;
            btn[7, 1] = btn5_7;
            btn[7, 2] = btn6_7;
            btn[7, 3] = btn4_8;
            btn[7, 4] = btn5_8;
            btn[7, 5] = btn6_8;
            btn[7, 6] = btn4_9;
            btn[7, 7] = btn5_9;
            btn[7, 8] = btn6_9;

            btn[8, 0] = btn7_7;
            btn[8, 1] = btn8_7;
            btn[8, 2] = btn9_7;
            btn[8, 3] = btn7_8;
            btn[8, 4] = btn8_8;
            btn[8, 5] = btn9_8;
            btn[8, 6] = btn7_9;
            btn[8, 7] = btn8_9;
            btn[8, 8] = btn9_9;
           
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button senderB = (Button)sender;
            if (but != senderB)
            {
                kol = 0;
                but = senderB;
            }
            if (senderB.Text != "" && senderB.Text != "9") 
            {
                kol = Convert.ToInt16(senderB.Text);
            }
            kol++;
            senderB.Text = Convert.ToString(kol);
            Fill1();
            sd = new Sudoku();
            sd.Correct(btn, b);
            if (kol == 9)
            {
                kol = 0;
            }
        }
    }
}
