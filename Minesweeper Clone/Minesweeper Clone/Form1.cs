using MineSweeperClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper_Clone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            string gameDifficulty = "";
            if (rbtn_easy.Checked)
                gameDifficulty = "Easy";
            if (rbtn_medium.Checked)
                gameDifficulty = "Medium";
            if (rbtn_hard.Checked)
                gameDifficulty = "Hard";

            Form2 MineSweeperGUI = new Form2(gameDifficulty);
            MineSweeperGUI.Show();
        }
    }
}
