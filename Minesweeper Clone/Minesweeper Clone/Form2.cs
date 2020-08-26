using MineSweeperClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper_Clone
{
    public partial class Form2 : Form
    {
        public string GameDifficulty { get; set; }
        private GameBoard MineSweeperBoard { get; set; }
        private Button[,] ButtonArray;
        public int BUTTONSIZE { get; set; }
        public Stopwatch GameTimer { get; set; }
        public int MinesLeft { get; set; }
        public int ClearedSpaces { get; set; }

        public Form2(string Difficulty)
        {
            GameDifficulty = Difficulty;
            MineSweeperBoard = new GameBoard(Difficulty);
            ButtonArray = new Button[MineSweeperBoard.Size, MineSweeperBoard.Size];
            BUTTONSIZE = 21;
            GameTimer = new Stopwatch();
            MinesLeft = MineSweeperBoard.NumMines;

            this.Size = new Size(300, 300);

            InitializeComponent();
            lbl_mines.Text = MinesLeft.ToString();
            CreateButtonArray();
            MineSweeperBoard.SetMinesAndLabels();
        }

        //Updates GameBoard with most recent Player Moves
        private void RefreshBoard(GameBoard minesweeper)
        {
            int Size = minesweeper.Size;
            ClearedSpaces = 0;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cell CurrentCell = minesweeper.Grid[i, j];
                    Button ThisButton = ButtonArray[i, j];
                    ThisButton.BackgroundImage = null;

                    //Set Images and Labels for Buttons
                    if (CurrentCell.Visited && CurrentCell.Armed)
                    {
                        ThisButton.BackgroundImage = new Bitmap(@"C:\Repos\csharp\Tutorials\Minesweeper Clone\Minesweeper Clone\media\fire.png");
                        ThisButton.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else if (CurrentCell.Flagged)
                    {
                        ThisButton.BackgroundImage = new Bitmap(@"C:\Repos\csharp\Tutorials\Minesweeper Clone\Minesweeper Clone\media\flag.png");
                        ThisButton.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else if (CurrentCell.Visited && CurrentCell.ArmedNeighbors == 0)
                    {
                        ThisButton.Text = "";
                        ThisButton.BackColor = Color.DarkGray;
                        ClearedSpaces++;
                    }
                    else if (CurrentCell.Visited && CurrentCell.ArmedNeighbors > 0)
                    {
                        ThisButton.Text = CurrentCell.ArmedNeighbors.ToString();
                        ThisButton.Font = new Font(ThisButton.Font.Name, ThisButton.Font.Size, FontStyle.Bold);
                        ClearedSpaces++;

                        if (CurrentCell.ArmedNeighbors == 1)
                            ThisButton.ForeColor = Color.Blue;
                        else if (CurrentCell.ArmedNeighbors == 2)
                            ThisButton.ForeColor = Color.Green;
                        else if (CurrentCell.ArmedNeighbors == 3)
                            ThisButton.ForeColor = Color.Red;
                        else if (CurrentCell.ArmedNeighbors == 4)
                            ThisButton.ForeColor = Color.Navy;
                        else if (CurrentCell.ArmedNeighbors == 5)
                            ThisButton.ForeColor = Color.Maroon;
                    }
                }
            }
        }

        //Creates GameBoard GUI
        private void CreateButtonArray()
        {
            for (int i = 0; i < MineSweeperBoard.Size; i++)
            {
                for (int j = 0; j < MineSweeperBoard.Size; j++)
                {
                    //Button Creation
                    ButtonArray[i, j] = new Button();
                    ButtonArray[i, j].Height = BUTTONSIZE;
                    ButtonArray[i, j].Width = BUTTONSIZE;
                    ButtonArray[i, j].MouseDown += Grid_Button_MouseDown;
                    ButtonArray[i, j].BackgroundImage = null;
                    //Button Placement
                    pnl_gameboard.Controls.Add(ButtonArray[i, j]);
                    ButtonArray[i, j].Location = new Point(i * BUTTONSIZE, j * BUTTONSIZE);
                    ButtonArray[i, j].Tag = new Point(i, j);
                }
            }
        }

        //Bind Mouse Clicks
        private void Grid_Button_MouseDown(object sender, MouseEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            Point ButtonLocation = (Point)ClickedButton.Tag;
            int x = ButtonLocation.X;
            int y = ButtonLocation.Y;
            Cell ThisCell = MineSweeperBoard.Grid[x, y];
            StartTimer();

            //Left Mouse Button Click
            if (e.Button == MouseButtons.Left)
            {
                if (ThisCell.Visited == false && ThisCell.Flagged == false)
                {
                    MineCheck(MineSweeperBoard.MinePresent(x, y));
                    MineSweeperBoard.VisitBlocksWithNoLiveNeighbors(x, y);
                    ThisCell.Visited = true;
                }
            }

            //Right Mouse Button Click
            if (e.Button == MouseButtons.Right)
            {
                if (ThisCell.Flagged == false && ThisCell.Visited == false)
                {
                    ThisCell.Flagged = true;
                    MinesLeft--;
                    lbl_mines.Text = MinesLeft.ToString();
                }
                else if (ThisCell.Flagged)
                {
                    ThisCell.Flagged = false;
                    MinesLeft++;
                    lbl_mines.Text = MinesLeft.ToString();
                }
            }

            //Double Mouse Button Click
            if (((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right) &&
((Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left))
            {
                if (ThisCell.Visited == true)
                    MineCheck(MineSweeperBoard.ClearSimilarLiveNeighbors(x, y));
            }
            RefreshBoard(MineSweeperBoard);
            CheckWin(MineSweeperBoard);
        }

        public void MineCheck(bool minePresent)
        {
            if (minePresent == true)
            {
                MessageBox.Show("You hit a mine");
                GameTimer.Stop();
                RevealBoardAtTheEnd(MineSweeperBoard);
                RefreshBoard(MineSweeperBoard);
            }
        }

        private void CheckWin(GameBoard currentGame)
        {
            if (currentGame.WinCheck() == true)
            {
                var endTime = GameTimer.Elapsed;
                GameTimer.Stop();
                MessageBox.Show("You've Cleared the Minefield!");
                lbl_timer.Text = endTime.ToString("ss");
            }
        }

        private void StartTimer()
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                GameTimer.Start();
            }
        }

        private void RevealBoardAtTheEnd(GameBoard minesweeper)
        {
            int Size = minesweeper.Size;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cell CurrentCell = minesweeper.Grid[i, j];
                    if (CurrentCell.Armed)
                        CurrentCell.Visited = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan duration = GameTimer.Elapsed;
            lbl_timer.Text = duration.ToString("ss");
        }

        //Closes current window and creates a new game of the same difficulty
        private void btn_reset_Click(object sender, EventArgs e)
        {
            var currentDifficulty = MineSweeperBoard.Difficulty;
            Form2 MineSweeperGUI = new Form2(currentDifficulty);
            this.Dispose();
            MineSweeperGUI.Show();
        }
    }
}
