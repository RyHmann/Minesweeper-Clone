namespace Minesweeper_Clone
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pnl_gameboard = new System.Windows.Forms.Panel();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.lbl_mines = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnl_gameboard
            // 
            this.pnl_gameboard.Location = new System.Drawing.Point(12, 55);
            this.pnl_gameboard.Name = "pnl_gameboard";
            this.pnl_gameboard.Size = new System.Drawing.Size(462, 462);
            this.pnl_gameboard.TabIndex = 0;
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_timer.Font = new System.Drawing.Font("Lucida Console", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_timer.ForeColor = System.Drawing.Color.Red;
            this.lbl_timer.Location = new System.Drawing.Point(395, 10);
            this.lbl_timer.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_timer.Size = new System.Drawing.Size(60, 35);
            this.lbl_timer.TabIndex = 1;
            this.lbl_timer.Text = "00";
            // 
            // lbl_mines
            // 
            this.lbl_mines.AutoSize = true;
            this.lbl_mines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_mines.Font = new System.Drawing.Font("Lucida Console", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_mines.ForeColor = System.Drawing.Color.Red;
            this.lbl_mines.Location = new System.Drawing.Point(10, 10);
            this.lbl_mines.Margin = new System.Windows.Forms.Padding(3);
            this.lbl_mines.Name = "lbl_mines";
            this.lbl_mines.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_mines.Size = new System.Drawing.Size(80, 35);
            this.lbl_mines.TabIndex = 2;
            this.lbl_mines.Text = "000";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_reset
            // 
            this.btn_reset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_reset.BackgroundImage")));
            this.btn_reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_reset.Location = new System.Drawing.Point(195, 10);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 40);
            this.btn_reset.TabIndex = 3;
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 592);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.lbl_mines);
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.pnl_gameboard);
            this.Name = "Form2";
            this.Text = "Minesweeper Clone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_gameboard;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Label lbl_mines;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_reset;
    }
}