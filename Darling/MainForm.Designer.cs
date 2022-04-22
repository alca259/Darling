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
            this.BtnPickAll = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnPickDiamonds = new System.Windows.Forms.Button();
            this.BtnOpenMap = new System.Windows.Forms.Button();
            this.BtnCompletePath = new System.Windows.Forms.Button();
            this.BtnNextIsland = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnOpenMapAndNext = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnStop = new System.Windows.Forms.Button();
            this.LogTxtBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnPickAll
            // 
            this.BtnPickAll.Location = new System.Drawing.Point(6, 22);
            this.BtnPickAll.Name = "BtnPickAll";
            this.BtnPickAll.Size = new System.Drawing.Size(75, 23);
            this.BtnPickAll.TabIndex = 0;
            this.BtnPickAll.Text = "Pick All";
            this.BtnPickAll.UseVisualStyleBackColor = true;
            this.BtnPickAll.Click += new System.EventHandler(this.BtnPickAll_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(6, 22);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(156, 23);
            this.BtnStart.TabIndex = 6;
            this.BtnStart.Text = "Start Timer";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnPickDiamonds
            // 
            this.BtnPickDiamonds.Location = new System.Drawing.Point(6, 51);
            this.BtnPickDiamonds.Name = "BtnPickDiamonds";
            this.BtnPickDiamonds.Size = new System.Drawing.Size(75, 23);
            this.BtnPickDiamonds.TabIndex = 1;
            this.BtnPickDiamonds.Text = "Diamonds";
            this.BtnPickDiamonds.UseVisualStyleBackColor = true;
            this.BtnPickDiamonds.Click += new System.EventHandler(this.BtnPickDiamonds_Click);
            // 
            // BtnOpenMap
            // 
            this.BtnOpenMap.Location = new System.Drawing.Point(6, 80);
            this.BtnOpenMap.Name = "BtnOpenMap";
            this.BtnOpenMap.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenMap.TabIndex = 2;
            this.BtnOpenMap.Text = "Open Map";
            this.BtnOpenMap.UseVisualStyleBackColor = true;
            this.BtnOpenMap.Click += new System.EventHandler(this.BtnOpenMap_Click);
            // 
            // BtnCompletePath
            // 
            this.BtnCompletePath.Location = new System.Drawing.Point(87, 22);
            this.BtnCompletePath.Name = "BtnCompletePath";
            this.BtnCompletePath.Size = new System.Drawing.Size(75, 52);
            this.BtnCompletePath.TabIndex = 4;
            this.BtnCompletePath.Text = "Complete Path";
            this.BtnCompletePath.UseVisualStyleBackColor = true;
            this.BtnCompletePath.Click += new System.EventHandler(this.BtnCompletePath_Click);
            // 
            // BtnNextIsland
            // 
            this.BtnNextIsland.Location = new System.Drawing.Point(6, 109);
            this.BtnNextIsland.Name = "BtnNextIsland";
            this.BtnNextIsland.Size = new System.Drawing.Size(75, 23);
            this.BtnNextIsland.TabIndex = 3;
            this.BtnNextIsland.Text = "Next Island";
            this.BtnNextIsland.UseVisualStyleBackColor = true;
            this.BtnNextIsland.Click += new System.EventHandler(this.BtnNextIsland_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnOpenMapAndNext);
            this.groupBox1.Controls.Add(this.BtnPickAll);
            this.groupBox1.Controls.Add(this.BtnCompletePath);
            this.groupBox1.Controls.Add(this.BtnNextIsland);
            this.groupBox1.Controls.Add(this.BtnPickDiamonds);
            this.groupBox1.Controls.Add(this.BtnOpenMap);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 144);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Debug section";
            // 
            // BtnOpenMapAndNext
            // 
            this.BtnOpenMapAndNext.Location = new System.Drawing.Point(87, 80);
            this.BtnOpenMapAndNext.Name = "BtnOpenMapAndNext";
            this.BtnOpenMapAndNext.Size = new System.Drawing.Size(75, 52);
            this.BtnOpenMapAndNext.TabIndex = 5;
            this.BtnOpenMapAndNext.Text = "Open Map And Next";
            this.BtnOpenMapAndNext.UseVisualStyleBackColor = true;
            this.BtnOpenMapAndNext.Click += new System.EventHandler(this.BtnOpenMapAndNext_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnStop);
            this.groupBox2.Controls.Add(this.BtnStart);
            this.groupBox2.Location = new System.Drawing.Point(204, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 144);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timer";
            // 
            // BtnStop
            // 
            this.BtnStop.Enabled = false;
            this.BtnStop.Location = new System.Drawing.Point(6, 51);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(156, 23);
            this.BtnStop.TabIndex = 7;
            this.BtnStop.Text = "Stop Timer";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // LogTxtBox
            // 
            this.LogTxtBox.BackColor = System.Drawing.Color.Black;
            this.LogTxtBox.ForeColor = System.Drawing.Color.White;
            this.LogTxtBox.Location = new System.Drawing.Point(12, 162);
            this.LogTxtBox.MaxLength = 0;
            this.LogTxtBox.Multiline = true;
            this.LogTxtBox.Name = "LogTxtBox";
            this.LogTxtBox.ReadOnly = true;
            this.LogTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTxtBox.Size = new System.Drawing.Size(360, 107);
            this.LogTxtBox.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.LogTxtBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 320);
            this.MinimumSize = new System.Drawing.Size(400, 320);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Button BtnPickAll;
    private Button BtnStart;
    private Button BtnPickDiamonds;
    private Button BtnOpenMap;
    private Button BtnCompletePath;
    private Button BtnNextIsland;
    private GroupBox groupBox1;
    private Button BtnOpenMapAndNext;
    private GroupBox groupBox2;
    private Button BtnStop;
    private TextBox LogTxtBox;
}
