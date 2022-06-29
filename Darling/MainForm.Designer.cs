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
            this.BtnPickAll = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnPickDiamonds = new System.Windows.Forms.Button();
            this.BtnOpenMap = new System.Windows.Forms.Button();
            this.BtnCompletePath = new System.Windows.Forms.Button();
            this.BtnNextIsland = new System.Windows.Forms.Button();
            this.gbDebugSection = new System.Windows.Forms.GroupBox();
            this.BtnOpenMapAndNext = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnStopVote = new System.Windows.Forms.Button();
            this.BtnStartVote = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LogTxtBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sliderNextVoteIsland = new Darling.Controls.Slider();
            this.sliderAfterEnterIsland = new Darling.Controls.Slider();
            this.sliderEnterIsland = new Darling.Controls.Slider();
            this.sliderNextIsland = new Darling.Controls.Slider();
            this.sliderPopupWait = new Darling.Controls.Slider();
            this.sliderFindButton = new Darling.Controls.Slider();
            this.sliderIslandStay = new Darling.Controls.Slider();
            this.sliderMemoryGameBetweenScenes = new Darling.Controls.Slider();
            this.sliderWaitBetweenActions = new Darling.Controls.Slider();
            this.sliderDiamondsWait = new Darling.Controls.Slider();
            this.sliderWindowToTop = new Darling.Controls.Slider();
            this.sliderMouseClick = new Darling.Controls.Slider();
            this.sliderFindProcess = new Darling.Controls.Slider();
            this.sliderThresholdMapIsland = new Darling.Controls.Slider();
            this.sliderThresholdButton = new Darling.Controls.Slider();
            this.gbDebugSection.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnPickAll
            // 
            this.BtnPickAll.Location = new System.Drawing.Point(9, 22);
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
            this.BtnStart.Size = new System.Drawing.Size(82, 23);
            this.BtnStart.TabIndex = 6;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnPickDiamonds
            // 
            this.BtnPickDiamonds.Location = new System.Drawing.Point(90, 22);
            this.BtnPickDiamonds.Name = "BtnPickDiamonds";
            this.BtnPickDiamonds.Size = new System.Drawing.Size(75, 23);
            this.BtnPickDiamonds.TabIndex = 1;
            this.BtnPickDiamonds.Text = "Diamonds";
            this.BtnPickDiamonds.UseVisualStyleBackColor = true;
            this.BtnPickDiamonds.Click += new System.EventHandler(this.BtnPickDiamonds_Click);
            // 
            // BtnOpenMap
            // 
            this.BtnOpenMap.Location = new System.Drawing.Point(171, 22);
            this.BtnOpenMap.Name = "BtnOpenMap";
            this.BtnOpenMap.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenMap.TabIndex = 2;
            this.BtnOpenMap.Text = "Open Map";
            this.BtnOpenMap.UseVisualStyleBackColor = true;
            this.BtnOpenMap.Click += new System.EventHandler(this.BtnOpenMap_Click);
            // 
            // BtnCompletePath
            // 
            this.BtnCompletePath.Location = new System.Drawing.Point(429, 22);
            this.BtnCompletePath.Name = "BtnCompletePath";
            this.BtnCompletePath.Size = new System.Drawing.Size(95, 23);
            this.BtnCompletePath.TabIndex = 4;
            this.BtnCompletePath.Text = "Complete Path";
            this.BtnCompletePath.UseVisualStyleBackColor = true;
            this.BtnCompletePath.Click += new System.EventHandler(this.BtnCompletePath_Click);
            // 
            // BtnNextIsland
            // 
            this.BtnNextIsland.Location = new System.Drawing.Point(252, 22);
            this.BtnNextIsland.Name = "BtnNextIsland";
            this.BtnNextIsland.Size = new System.Drawing.Size(75, 23);
            this.BtnNextIsland.TabIndex = 3;
            this.BtnNextIsland.Text = "Next Island";
            this.BtnNextIsland.UseVisualStyleBackColor = true;
            this.BtnNextIsland.Click += new System.EventHandler(this.BtnNextIsland_Click);
            // 
            // gbDebugSection
            // 
            this.gbDebugSection.Controls.Add(this.BtnOpenMapAndNext);
            this.gbDebugSection.Controls.Add(this.BtnPickAll);
            this.gbDebugSection.Controls.Add(this.BtnCompletePath);
            this.gbDebugSection.Controls.Add(this.BtnNextIsland);
            this.gbDebugSection.Controls.Add(this.BtnPickDiamonds);
            this.gbDebugSection.Controls.Add(this.BtnOpenMap);
            this.gbDebugSection.Location = new System.Drawing.Point(364, 9);
            this.gbDebugSection.Name = "gbDebugSection";
            this.gbDebugSection.Size = new System.Drawing.Size(530, 54);
            this.gbDebugSection.TabIndex = 6;
            this.gbDebugSection.TabStop = false;
            this.gbDebugSection.Text = "Debug section";
            this.gbDebugSection.Visible = false;
            // 
            // BtnOpenMapAndNext
            // 
            this.BtnOpenMapAndNext.Location = new System.Drawing.Point(333, 22);
            this.BtnOpenMapAndNext.Name = "BtnOpenMapAndNext";
            this.BtnOpenMapAndNext.Size = new System.Drawing.Size(90, 23);
            this.BtnOpenMapAndNext.TabIndex = 5;
            this.BtnOpenMapAndNext.Text = "Map and Next";
            this.BtnOpenMapAndNext.UseVisualStyleBackColor = true;
            this.BtnOpenMapAndNext.Click += new System.EventHandler(this.BtnOpenMapAndNext_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnStop);
            this.groupBox2.Controls.Add(this.BtnStart);
            this.groupBox2.Location = new System.Drawing.Point(9, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 54);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto collect";
            // 
            // BtnStop
            // 
            this.BtnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStop.Enabled = false;
            this.BtnStop.Location = new System.Drawing.Point(93, 22);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(69, 23);
            this.BtnStop.TabIndex = 7;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // BtnStopVote
            // 
            this.BtnStopVote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStopVote.Enabled = false;
            this.BtnStopVote.Location = new System.Drawing.Point(100, 22);
            this.BtnStopVote.Name = "BtnStopVote";
            this.BtnStopVote.Size = new System.Drawing.Size(69, 23);
            this.BtnStopVote.TabIndex = 9;
            this.BtnStopVote.Text = "Stop";
            this.BtnStopVote.UseVisualStyleBackColor = true;
            this.BtnStopVote.Click += new System.EventHandler(this.BtnStopVote_Click);
            // 
            // BtnStartVote
            // 
            this.BtnStartVote.Location = new System.Drawing.Point(6, 22);
            this.BtnStartVote.Name = "BtnStartVote";
            this.BtnStartVote.Size = new System.Drawing.Size(82, 23);
            this.BtnStartVote.TabIndex = 8;
            this.BtnStartVote.Text = "Start";
            this.BtnStartVote.UseVisualStyleBackColor = true;
            this.BtnStartVote.Click += new System.EventHandler(this.BtnStartVote_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnStopVote);
            this.groupBox1.Controls.Add(this.BtnStartVote);
            this.groupBox1.Location = new System.Drawing.Point(183, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 54);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto vote";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.gbDebugSection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 69);
            this.panel1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LogTxtBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(908, 641);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // LogTxtBox
            // 
            this.LogTxtBox.BackColor = System.Drawing.Color.Black;
            this.LogTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTxtBox.ForeColor = System.Drawing.Color.White;
            this.LogTxtBox.Location = new System.Drawing.Point(3, 524);
            this.LogTxtBox.MaxLength = 0;
            this.LogTxtBox.Multiline = true;
            this.LogTxtBox.Name = "LogTxtBox";
            this.LogTxtBox.ReadOnly = true;
            this.LogTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTxtBox.Size = new System.Drawing.Size(902, 114);
            this.LogTxtBox.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sliderNextVoteIsland);
            this.panel2.Controls.Add(this.sliderAfterEnterIsland);
            this.panel2.Controls.Add(this.sliderEnterIsland);
            this.panel2.Controls.Add(this.sliderNextIsland);
            this.panel2.Controls.Add(this.sliderPopupWait);
            this.panel2.Controls.Add(this.sliderFindButton);
            this.panel2.Controls.Add(this.sliderIslandStay);
            this.panel2.Controls.Add(this.sliderMemoryGameBetweenScenes);
            this.panel2.Controls.Add(this.sliderWaitBetweenActions);
            this.panel2.Controls.Add(this.sliderDiamondsWait);
            this.panel2.Controls.Add(this.sliderWindowToTop);
            this.panel2.Controls.Add(this.sliderMouseClick);
            this.panel2.Controls.Add(this.sliderFindProcess);
            this.panel2.Controls.Add(this.sliderThresholdMapIsland);
            this.panel2.Controls.Add(this.sliderThresholdButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(902, 440);
            this.panel2.TabIndex = 9;
            // 
            // sliderNextVoteIsland
            // 
            this.sliderNextVoteIsland.CurrentValue = 5;
            this.sliderNextVoteIsland.IsEnabled = true;
            this.sliderNextVoteIsland.LabelToShow = "Delay next vote island (sec)";
            this.sliderNextVoteIsland.Location = new System.Drawing.Point(623, 184);
            this.sliderNextVoteIsland.MaxValue = 10;
            this.sliderNextVoteIsland.MinValue = 5;
            this.sliderNextVoteIsland.Multiplier = 1000;
            this.sliderNextVoteIsland.Name = "sliderNextVoteIsland";
            this.sliderNextVoteIsland.Size = new System.Drawing.Size(254, 70);
            this.sliderNextVoteIsland.Steps = 1;
            this.sliderNextVoteIsland.TabIndex = 29;
            // 
            // sliderAfterEnterIsland
            // 
            this.sliderAfterEnterIsland.CurrentValue = 10;
            this.sliderAfterEnterIsland.IsEnabled = true;
            this.sliderAfterEnterIsland.LabelToShow = "Delay after enter island (sec/10)";
            this.sliderAfterEnterIsland.Location = new System.Drawing.Point(623, 98);
            this.sliderAfterEnterIsland.MaxValue = 50;
            this.sliderAfterEnterIsland.MinValue = 10;
            this.sliderAfterEnterIsland.Multiplier = 100;
            this.sliderAfterEnterIsland.Name = "sliderAfterEnterIsland";
            this.sliderAfterEnterIsland.Size = new System.Drawing.Size(254, 70);
            this.sliderAfterEnterIsland.Steps = 1;
            this.sliderAfterEnterIsland.TabIndex = 28;
            // 
            // sliderEnterIsland
            // 
            this.sliderEnterIsland.CurrentValue = 8;
            this.sliderEnterIsland.IsEnabled = true;
            this.sliderEnterIsland.LabelToShow = "Delay enter island (sec/10)";
            this.sliderEnterIsland.Location = new System.Drawing.Point(623, 12);
            this.sliderEnterIsland.MaxValue = 20;
            this.sliderEnterIsland.MinValue = 8;
            this.sliderEnterIsland.Multiplier = 100;
            this.sliderEnterIsland.Name = "sliderEnterIsland";
            this.sliderEnterIsland.Size = new System.Drawing.Size(254, 70);
            this.sliderEnterIsland.Steps = 1;
            this.sliderEnterIsland.TabIndex = 27;
            // 
            // sliderNextIsland
            // 
            this.sliderNextIsland.CurrentValue = 8;
            this.sliderNextIsland.IsEnabled = true;
            this.sliderNextIsland.LabelToShow = "Delay next island (sec/10)";
            this.sliderNextIsland.Location = new System.Drawing.Point(319, 356);
            this.sliderNextIsland.MaxValue = 20;
            this.sliderNextIsland.MinValue = 8;
            this.sliderNextIsland.Multiplier = 100;
            this.sliderNextIsland.Name = "sliderNextIsland";
            this.sliderNextIsland.Size = new System.Drawing.Size(254, 70);
            this.sliderNextIsland.Steps = 1;
            this.sliderNextIsland.TabIndex = 26;
            // 
            // sliderPopupWait
            // 
            this.sliderPopupWait.CurrentValue = 3;
            this.sliderPopupWait.IsEnabled = true;
            this.sliderPopupWait.LabelToShow = "Delay popup wait (sec/10)";
            this.sliderPopupWait.Location = new System.Drawing.Point(16, 356);
            this.sliderPopupWait.MaxValue = 30;
            this.sliderPopupWait.MinValue = 3;
            this.sliderPopupWait.Multiplier = 100;
            this.sliderPopupWait.Name = "sliderPopupWait";
            this.sliderPopupWait.Size = new System.Drawing.Size(252, 70);
            this.sliderPopupWait.Steps = 1;
            this.sliderPopupWait.TabIndex = 25;
            // 
            // sliderFindButton
            // 
            this.sliderFindButton.CurrentValue = 3;
            this.sliderFindButton.IsEnabled = true;
            this.sliderFindButton.LabelToShow = "Delay find button (sec/10)";
            this.sliderFindButton.Location = new System.Drawing.Point(319, 270);
            this.sliderFindButton.MaxValue = 10;
            this.sliderFindButton.MinValue = 3;
            this.sliderFindButton.Multiplier = 100;
            this.sliderFindButton.Name = "sliderFindButton";
            this.sliderFindButton.Size = new System.Drawing.Size(254, 70);
            this.sliderFindButton.Steps = 1;
            this.sliderFindButton.TabIndex = 24;
            // 
            // sliderIslandStay
            // 
            this.sliderIslandStay.CurrentValue = 1;
            this.sliderIslandStay.IsEnabled = true;
            this.sliderIslandStay.LabelToShow = "Delay island stay (sec)";
            this.sliderIslandStay.Location = new System.Drawing.Point(17, 270);
            this.sliderIslandStay.MaxValue = 60;
            this.sliderIslandStay.MinValue = 1;
            this.sliderIslandStay.Multiplier = 1000;
            this.sliderIslandStay.Name = "sliderIslandStay";
            this.sliderIslandStay.Size = new System.Drawing.Size(252, 70);
            this.sliderIslandStay.Steps = 5;
            this.sliderIslandStay.TabIndex = 23;
            // 
            // sliderMemoryGameBetweenScenes
            // 
            this.sliderMemoryGameBetweenScenes.CurrentValue = 10;
            this.sliderMemoryGameBetweenScenes.Enabled = false;
            this.sliderMemoryGameBetweenScenes.IsEnabled = true;
            this.sliderMemoryGameBetweenScenes.LabelToShow = "Memory game between (sec/10)";
            this.sliderMemoryGameBetweenScenes.Location = new System.Drawing.Point(319, 184);
            this.sliderMemoryGameBetweenScenes.MaxValue = 50;
            this.sliderMemoryGameBetweenScenes.MinValue = 10;
            this.sliderMemoryGameBetweenScenes.Multiplier = 100;
            this.sliderMemoryGameBetweenScenes.Name = "sliderMemoryGameBetweenScenes";
            this.sliderMemoryGameBetweenScenes.Size = new System.Drawing.Size(254, 70);
            this.sliderMemoryGameBetweenScenes.Steps = 1;
            this.sliderMemoryGameBetweenScenes.TabIndex = 22;
            // 
            // sliderWaitBetweenActions
            // 
            this.sliderWaitBetweenActions.CurrentValue = 3;
            this.sliderWaitBetweenActions.IsEnabled = true;
            this.sliderWaitBetweenActions.LabelToShow = "Delay default wait (sec/10)";
            this.sliderWaitBetweenActions.Location = new System.Drawing.Point(17, 184);
            this.sliderWaitBetweenActions.MaxValue = 10;
            this.sliderWaitBetweenActions.MinValue = 3;
            this.sliderWaitBetweenActions.Multiplier = 100;
            this.sliderWaitBetweenActions.Name = "sliderWaitBetweenActions";
            this.sliderWaitBetweenActions.Size = new System.Drawing.Size(252, 70);
            this.sliderWaitBetweenActions.Steps = 1;
            this.sliderWaitBetweenActions.TabIndex = 21;
            // 
            // sliderDiamondsWait
            // 
            this.sliderDiamondsWait.CurrentValue = 3;
            this.sliderDiamondsWait.IsEnabled = true;
            this.sliderDiamondsWait.LabelToShow = "Delay diamonds wait (sec/10) ";
            this.sliderDiamondsWait.Location = new System.Drawing.Point(319, 98);
            this.sliderDiamondsWait.MaxValue = 100;
            this.sliderDiamondsWait.MinValue = 3;
            this.sliderDiamondsWait.Multiplier = 100;
            this.sliderDiamondsWait.Name = "sliderDiamondsWait";
            this.sliderDiamondsWait.Size = new System.Drawing.Size(254, 70);
            this.sliderDiamondsWait.Steps = 7;
            this.sliderDiamondsWait.TabIndex = 20;
            // 
            // sliderWindowToTop
            // 
            this.sliderWindowToTop.CurrentValue = 2;
            this.sliderWindowToTop.IsEnabled = true;
            this.sliderWindowToTop.LabelToShow = "Delay window to top (sec/10)";
            this.sliderWindowToTop.Location = new System.Drawing.Point(17, 98);
            this.sliderWindowToTop.MaxValue = 10;
            this.sliderWindowToTop.MinValue = 2;
            this.sliderWindowToTop.Multiplier = 100;
            this.sliderWindowToTop.Name = "sliderWindowToTop";
            this.sliderWindowToTop.Size = new System.Drawing.Size(252, 70);
            this.sliderWindowToTop.Steps = 1;
            this.sliderWindowToTop.TabIndex = 19;
            // 
            // sliderMouseClick
            // 
            this.sliderMouseClick.CurrentValue = 3;
            this.sliderMouseClick.IsEnabled = true;
            this.sliderMouseClick.LabelToShow = "Delay mouse click (sec/10)";
            this.sliderMouseClick.Location = new System.Drawing.Point(319, 12);
            this.sliderMouseClick.MaxValue = 10;
            this.sliderMouseClick.MinValue = 3;
            this.sliderMouseClick.Multiplier = 100;
            this.sliderMouseClick.Name = "sliderMouseClick";
            this.sliderMouseClick.Size = new System.Drawing.Size(254, 70);
            this.sliderMouseClick.Steps = 1;
            this.sliderMouseClick.TabIndex = 18;
            // 
            // sliderFindProcess
            // 
            this.sliderFindProcess.CurrentValue = 3;
            this.sliderFindProcess.IsEnabled = true;
            this.sliderFindProcess.LabelToShow = "Delay find process (sec/10)";
            this.sliderFindProcess.Location = new System.Drawing.Point(17, 12);
            this.sliderFindProcess.MaxValue = 10;
            this.sliderFindProcess.MinValue = 3;
            this.sliderFindProcess.Multiplier = 100;
            this.sliderFindProcess.Name = "sliderFindProcess";
            this.sliderFindProcess.Size = new System.Drawing.Size(252, 70);
            this.sliderFindProcess.Steps = 1;
            this.sliderFindProcess.TabIndex = 17;
            // 
            // sliderThresholdMapIsland
            // 
            this.sliderThresholdMapIsland.CurrentValue = 1;
            this.sliderThresholdMapIsland.IsEnabled = true;
            this.sliderThresholdMapIsland.LabelToShow = "Threshold map island text";
            this.sliderThresholdMapIsland.Location = new System.Drawing.Point(623, 356);
            this.sliderThresholdMapIsland.MaxValue = 99;
            this.sliderThresholdMapIsland.MinValue = 1;
            this.sliderThresholdMapIsland.Multiplier = 1;
            this.sliderThresholdMapIsland.Name = "sliderThresholdMapIsland";
            this.sliderThresholdMapIsland.Size = new System.Drawing.Size(254, 70);
            this.sliderThresholdMapIsland.Steps = 5;
            this.sliderThresholdMapIsland.TabIndex = 16;
            // 
            // sliderThresholdButton
            // 
            this.sliderThresholdButton.CurrentValue = 1;
            this.sliderThresholdButton.IsEnabled = true;
            this.sliderThresholdButton.LabelToShow = "Threshold buttons";
            this.sliderThresholdButton.Location = new System.Drawing.Point(623, 270);
            this.sliderThresholdButton.MaxValue = 99;
            this.sliderThresholdButton.MinValue = 1;
            this.sliderThresholdButton.Multiplier = 1;
            this.sliderThresholdButton.Name = "sliderThresholdButton";
            this.sliderThresholdButton.Size = new System.Drawing.Size(254, 70);
            this.sliderThresholdButton.Steps = 5;
            this.sliderThresholdButton.TabIndex = 15;
            this.sliderThresholdButton.Load += new System.EventHandler(this.slider1_Load);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 641);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 320);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.gbDebugSection.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private Button BtnPickAll;
    private Button BtnStart;
    private Button BtnPickDiamonds;
    private Button BtnOpenMap;
    private Button BtnCompletePath;
    private Button BtnNextIsland;
    private GroupBox gbDebugSection;
    private Button BtnOpenMapAndNext;
    private GroupBox groupBox2;
    private Button BtnStop;
    private Button BtnStopVote;
    private Button BtnStartVote;
    private GroupBox groupBox1;
    private Panel panel1;
    private TableLayoutPanel tableLayoutPanel1;
    private TextBox LogTxtBox;
    private Panel panel2;
    private Controls.Slider sliderThresholdButton;
    private Controls.Slider sliderThresholdMapIsland;
    private Controls.Slider sliderNextIsland;
    private Controls.Slider sliderPopupWait;
    private Controls.Slider sliderFindButton;
    private Controls.Slider sliderIslandStay;
    private Controls.Slider sliderMemoryGameBetweenScenes;
    private Controls.Slider sliderWaitBetweenActions;
    private Controls.Slider sliderDiamondsWait;
    private Controls.Slider sliderWindowToTop;
    private Controls.Slider sliderMouseClick;
    private Controls.Slider sliderFindProcess;
    private Controls.Slider sliderNextVoteIsland;
    private Controls.Slider sliderAfterEnterIsland;
    private Controls.Slider sliderEnterIsland;
}
