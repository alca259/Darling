namespace Darling;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnStopVote = new System.Windows.Forms.Button();
            this.BtnStartVote = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LogTxtBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.themeGroupBox2 = new System.Windows.Forms.GroupBox();
            this.switchFireTorch = new Alca259.UIControls.UserControls.SwitchCheckBox();
            this.switchVoteUp = new Alca259.UIControls.UserControls.SwitchCheckBox();
            this.themeLabel4 = new Alca259.UIControls.UserControls.ThemeLabel();
            this.themeLabel5 = new Alca259.UIControls.UserControls.ThemeLabel();
            this.themeHorizontalSeparator2 = new Alca259.UIControls.UserControls.ThemeHorizontalSeparator();
            this.themeGroupBox1 = new System.Windows.Forms.GroupBox();
            this.themeHorizontalSeparator1 = new Alca259.UIControls.UserControls.ThemeHorizontalSeparator();
            this.switchMoney = new Alca259.UIControls.UserControls.SwitchCheckBox();
            this.switchFood = new Alca259.UIControls.UserControls.SwitchCheckBox();
            this.switchDiamonds = new Alca259.UIControls.UserControls.SwitchCheckBox();
            this.themeLabel2 = new Alca259.UIControls.UserControls.ThemeLabel();
            this.themeLabel1 = new Alca259.UIControls.UserControls.ThemeLabel();
            this.themeLabel3 = new Alca259.UIControls.UserControls.ThemeLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.themeGroupBox2.SuspendLayout();
            this.themeGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.BtnStart.FlatAppearance.BorderSize = 0;
            this.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStart.Location = new System.Drawing.Point(16, 28);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(82, 23);
            this.BtnStart.TabIndex = 6;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.BtnStop.Enabled = false;
            this.BtnStop.FlatAppearance.BorderSize = 0;
            this.BtnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStop.Location = new System.Drawing.Point(133, 28);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(103, 23);
            this.BtnStop.TabIndex = 7;
            this.BtnStop.Text = "Stop (Ctrl+F7)";
            this.BtnStop.UseVisualStyleBackColor = false;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // BtnStopVote
            // 
            this.BtnStopVote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStopVote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.BtnStopVote.Enabled = false;
            this.BtnStopVote.FlatAppearance.BorderSize = 0;
            this.BtnStopVote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStopVote.Location = new System.Drawing.Point(123, 29);
            this.BtnStopVote.Name = "BtnStopVote";
            this.BtnStopVote.Size = new System.Drawing.Size(113, 23);
            this.BtnStopVote.TabIndex = 9;
            this.BtnStopVote.Text = "Stop (Ctrl+F7)";
            this.BtnStopVote.UseVisualStyleBackColor = false;
            this.BtnStopVote.Click += new System.EventHandler(this.BtnStopVote_Click);
            // 
            // BtnStartVote
            // 
            this.BtnStartVote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.BtnStartVote.FlatAppearance.BorderSize = 0;
            this.BtnStartVote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStartVote.Location = new System.Drawing.Point(16, 29);
            this.BtnStartVote.Name = "BtnStartVote";
            this.BtnStartVote.Size = new System.Drawing.Size(82, 23);
            this.BtnStartVote.TabIndex = 8;
            this.BtnStartVote.Text = "Start";
            this.BtnStartVote.UseVisualStyleBackColor = false;
            this.BtnStartVote.Click += new System.EventHandler(this.BtnStartVote_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LogTxtBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(908, 652);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // LogTxtBox
            // 
            this.LogTxtBox.BackColor = System.Drawing.Color.Black;
            this.LogTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTxtBox.ForeColor = System.Drawing.Color.White;
            this.LogTxtBox.Location = new System.Drawing.Point(3, 243);
            this.LogTxtBox.MaxLength = 0;
            this.LogTxtBox.Multiline = true;
            this.LogTxtBox.Name = "LogTxtBox";
            this.LogTxtBox.ReadOnly = true;
            this.LogTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTxtBox.Size = new System.Drawing.Size(902, 406);
            this.LogTxtBox.TabIndex = 8;
            this.LogTxtBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.themeGroupBox2);
            this.panel2.Controls.Add(this.themeGroupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(902, 234);
            this.panel2.TabIndex = 9;
            // 
            // themeGroupBox2
            // 
            this.themeGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.themeGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.themeGroupBox2.Controls.Add(this.switchFireTorch);
            this.themeGroupBox2.Controls.Add(this.switchVoteUp);
            this.themeGroupBox2.Controls.Add(this.themeLabel4);
            this.themeGroupBox2.Controls.Add(this.themeLabel5);
            this.themeGroupBox2.Controls.Add(this.themeHorizontalSeparator2);
            this.themeGroupBox2.Controls.Add(this.BtnStopVote);
            this.themeGroupBox2.Controls.Add(this.BtnStartVote);
            this.themeGroupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.themeGroupBox2.Location = new System.Drawing.Point(612, 27);
            this.themeGroupBox2.Name = "themeGroupBox2";
            this.themeGroupBox2.Size = new System.Drawing.Size(251, 129);
            this.themeGroupBox2.TabIndex = 11;
            this.themeGroupBox2.TabStop = false;
            this.themeGroupBox2.Text = "Auto vote";
            // 
            // switchFireTorch
            // 
            this.switchFireTorch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.switchFireTorch.AutoSize = true;
            this.switchFireTorch.Checked = true;
            this.switchFireTorch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.switchFireTorch.Location = new System.Drawing.Point(204, 75);
            this.switchFireTorch.MinimumSize = new System.Drawing.Size(32, 16);
            this.switchFireTorch.Name = "switchFireTorch";
            this.switchFireTorch.OffBackColor = System.Drawing.Color.Gray;
            this.switchFireTorch.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.switchFireTorch.OnBackColor = System.Drawing.Color.Orange;
            this.switchFireTorch.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.switchFireTorch.Size = new System.Drawing.Size(32, 16);
            this.switchFireTorch.TabIndex = 12;
            this.switchFireTorch.UseVisualStyleBackColor = true;
            // 
            // switchVoteUp
            // 
            this.switchVoteUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.switchVoteUp.AutoSize = true;
            this.switchVoteUp.Checked = true;
            this.switchVoteUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.switchVoteUp.Location = new System.Drawing.Point(204, 101);
            this.switchVoteUp.MinimumSize = new System.Drawing.Size(32, 16);
            this.switchVoteUp.Name = "switchVoteUp";
            this.switchVoteUp.OffBackColor = System.Drawing.Color.Gray;
            this.switchVoteUp.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.switchVoteUp.OnBackColor = System.Drawing.Color.DarkOrchid;
            this.switchVoteUp.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.switchVoteUp.Size = new System.Drawing.Size(32, 16);
            this.switchVoteUp.TabIndex = 14;
            this.switchVoteUp.UseVisualStyleBackColor = true;
            // 
            // themeLabel4
            // 
            this.themeLabel4.AutoSize = true;
            this.themeLabel4.ForeColor = System.Drawing.Color.Gainsboro;
            this.themeLabel4.Location = new System.Drawing.Point(16, 102);
            this.themeLabel4.Name = "themeLabel4";
            this.themeLabel4.Size = new System.Drawing.Size(47, 15);
            this.themeLabel4.TabIndex = 13;
            this.themeLabel4.Text = "Vote up";
            // 
            // themeLabel5
            // 
            this.themeLabel5.AutoSize = true;
            this.themeLabel5.ForeColor = System.Drawing.Color.Gainsboro;
            this.themeLabel5.Location = new System.Drawing.Point(16, 75);
            this.themeLabel5.Name = "themeLabel5";
            this.themeLabel5.Size = new System.Drawing.Size(57, 15);
            this.themeLabel5.TabIndex = 11;
            this.themeLabel5.Text = "Fire torch";
            // 
            // themeHorizontalSeparator2
            // 
            this.themeHorizontalSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.themeHorizontalSeparator2.ForeColor = System.Drawing.Color.DimGray;
            this.themeHorizontalSeparator2.Location = new System.Drawing.Point(15, 55);
            this.themeHorizontalSeparator2.Margin = new System.Windows.Forms.Padding(0);
            this.themeHorizontalSeparator2.Name = "themeHorizontalSeparator2";
            this.themeHorizontalSeparator2.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.themeHorizontalSeparator2.SeparatorSize = 2;
            this.themeHorizontalSeparator2.Size = new System.Drawing.Size(220, 16);
            this.themeHorizontalSeparator2.TabIndex = 10;
            // 
            // themeGroupBox1
            // 
            this.themeGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.themeGroupBox1.Controls.Add(this.themeHorizontalSeparator1);
            this.themeGroupBox1.Controls.Add(this.BtnStop);
            this.themeGroupBox1.Controls.Add(this.BtnStart);
            this.themeGroupBox1.Controls.Add(this.switchMoney);
            this.themeGroupBox1.Controls.Add(this.switchFood);
            this.themeGroupBox1.Controls.Add(this.switchDiamonds);
            this.themeGroupBox1.Controls.Add(this.themeLabel2);
            this.themeGroupBox1.Controls.Add(this.themeLabel1);
            this.themeGroupBox1.Controls.Add(this.themeLabel3);
            this.themeGroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.themeGroupBox1.Location = new System.Drawing.Point(36, 27);
            this.themeGroupBox1.Name = "themeGroupBox1";
            this.themeGroupBox1.Size = new System.Drawing.Size(251, 172);
            this.themeGroupBox1.TabIndex = 10;
            this.themeGroupBox1.TabStop = false;
            this.themeGroupBox1.Text = "Auto collect";
            // 
            // themeHorizontalSeparator1
            // 
            this.themeHorizontalSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.themeHorizontalSeparator1.ForeColor = System.Drawing.Color.DimGray;
            this.themeHorizontalSeparator1.Location = new System.Drawing.Point(16, 55);
            this.themeHorizontalSeparator1.Margin = new System.Windows.Forms.Padding(0);
            this.themeHorizontalSeparator1.Name = "themeHorizontalSeparator1";
            this.themeHorizontalSeparator1.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.themeHorizontalSeparator1.SeparatorSize = 2;
            this.themeHorizontalSeparator1.Size = new System.Drawing.Size(220, 16);
            this.themeHorizontalSeparator1.TabIndex = 8;
            // 
            // switchMoney
            // 
            this.switchMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.switchMoney.AutoSize = true;
            this.switchMoney.Checked = true;
            this.switchMoney.CheckState = System.Windows.Forms.CheckState.Checked;
            this.switchMoney.Location = new System.Drawing.Point(204, 75);
            this.switchMoney.MinimumSize = new System.Drawing.Size(32, 16);
            this.switchMoney.Name = "switchMoney";
            this.switchMoney.OffBackColor = System.Drawing.Color.Gray;
            this.switchMoney.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.switchMoney.OnBackColor = System.Drawing.Color.Gold;
            this.switchMoney.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.switchMoney.Size = new System.Drawing.Size(32, 16);
            this.switchMoney.TabIndex = 1;
            this.switchMoney.UseVisualStyleBackColor = true;
            // 
            // switchFood
            // 
            this.switchFood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.switchFood.AutoSize = true;
            this.switchFood.Checked = true;
            this.switchFood.CheckState = System.Windows.Forms.CheckState.Checked;
            this.switchFood.Location = new System.Drawing.Point(204, 128);
            this.switchFood.MinimumSize = new System.Drawing.Size(32, 16);
            this.switchFood.Name = "switchFood";
            this.switchFood.OffBackColor = System.Drawing.Color.Gray;
            this.switchFood.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.switchFood.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.switchFood.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.switchFood.Size = new System.Drawing.Size(32, 16);
            this.switchFood.TabIndex = 5;
            this.switchFood.UseVisualStyleBackColor = true;
            // 
            // switchDiamonds
            // 
            this.switchDiamonds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.switchDiamonds.AutoSize = true;
            this.switchDiamonds.Checked = true;
            this.switchDiamonds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.switchDiamonds.Location = new System.Drawing.Point(204, 101);
            this.switchDiamonds.MinimumSize = new System.Drawing.Size(32, 16);
            this.switchDiamonds.Name = "switchDiamonds";
            this.switchDiamonds.OffBackColor = System.Drawing.Color.Gray;
            this.switchDiamonds.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.switchDiamonds.OnBackColor = System.Drawing.Color.SkyBlue;
            this.switchDiamonds.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.switchDiamonds.Size = new System.Drawing.Size(32, 16);
            this.switchDiamonds.TabIndex = 3;
            this.switchDiamonds.UseVisualStyleBackColor = true;
            // 
            // themeLabel2
            // 
            this.themeLabel2.AutoSize = true;
            this.themeLabel2.ForeColor = System.Drawing.Color.Gainsboro;
            this.themeLabel2.Location = new System.Drawing.Point(16, 102);
            this.themeLabel2.Name = "themeLabel2";
            this.themeLabel2.Size = new System.Drawing.Size(85, 15);
            this.themeLabel2.TabIndex = 2;
            this.themeLabel2.Text = "Pick diamonds";
            // 
            // themeLabel1
            // 
            this.themeLabel1.AutoSize = true;
            this.themeLabel1.ForeColor = System.Drawing.Color.Gainsboro;
            this.themeLabel1.Location = new System.Drawing.Point(16, 75);
            this.themeLabel1.Name = "themeLabel1";
            this.themeLabel1.Size = new System.Drawing.Size(69, 15);
            this.themeLabel1.TabIndex = 0;
            this.themeLabel1.Text = "Pick money";
            // 
            // themeLabel3
            // 
            this.themeLabel3.AutoSize = true;
            this.themeLabel3.ForeColor = System.Drawing.Color.Gainsboro;
            this.themeLabel3.Location = new System.Drawing.Point(16, 128);
            this.themeLabel3.Name = "themeLabel3";
            this.themeLabel3.Size = new System.Drawing.Size(57, 15);
            this.themeLabel3.TabIndex = 4;
            this.themeLabel3.Text = "Pick food";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 680);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(910, 680);
            this.MinimumSize = new System.Drawing.Size(400, 320);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.themeGroupBox2.ResumeLayout(false);
            this.themeGroupBox2.PerformLayout();
            this.themeGroupBox1.ResumeLayout(false);
            this.themeGroupBox1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion
    private Button BtnStart;
    private Button BtnStop;
    private Button BtnStopVote;
    private Button BtnStartVote;
    private TableLayoutPanel tableLayoutPanel1;
    private TextBox LogTxtBox;
    private Panel panel2;
    private Alca259.UIControls.UserControls.SwitchCheckBox switchMoney;
    private Alca259.UIControls.UserControls.ThemeLabel themeLabel1;
    private Alca259.UIControls.UserControls.SwitchCheckBox switchFood;
    private Alca259.UIControls.UserControls.ThemeLabel themeLabel3;
    private Alca259.UIControls.UserControls.SwitchCheckBox switchDiamonds;
    private Alca259.UIControls.UserControls.ThemeLabel themeLabel2;
    private GroupBox themeGroupBox1;
    private GroupBox themeGroupBox2;
    private Alca259.UIControls.UserControls.ThemeHorizontalSeparator themeHorizontalSeparator1;
    private Alca259.UIControls.UserControls.ThemeHorizontalSeparator themeHorizontalSeparator2;
    private Alca259.UIControls.UserControls.SwitchCheckBox switchFireTorch;
    private Alca259.UIControls.UserControls.SwitchCheckBox switchVoteUp;
    private Alca259.UIControls.UserControls.ThemeLabel themeLabel4;
    private Alca259.UIControls.UserControls.ThemeLabel themeLabel5;
}
