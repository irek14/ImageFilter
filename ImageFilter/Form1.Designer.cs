﻿namespace ImageFilter
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTable = new System.Windows.Forms.TableLayoutPanel();
            this.Image = new System.Windows.Forms.PictureBox();
            this.ChartTable = new System.Windows.Forms.TableLayoutPanel();
            this.BChartPanel = new System.Windows.Forms.Panel();
            this.BLabel = new System.Windows.Forms.Label();
            this.BChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GChartPanel = new System.Windows.Forms.Panel();
            this.GLabel = new System.Windows.Forms.Label();
            this.GChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RChartPanel = new System.Windows.Forms.Panel();
            this.RChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RLabel = new System.Windows.Forms.Label();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MyFunctionPicture = new System.Windows.Forms.PictureBox();
            this.FilterGroupBox = new System.Windows.Forms.GroupBox();
            this.ContrastSecondDelta = new System.Windows.Forms.NumericUpDown();
            this.ContrastFirstDelta = new System.Windows.Forms.NumericUpDown();
            this.GammaCoefficient = new System.Windows.Forms.NumericUpDown();
            this.BrigthnessDelta = new System.Windows.Forms.NumericUpDown();
            this.MyFunctionRadio = new System.Windows.Forms.RadioButton();
            this.GammaRadio = new System.Windows.Forms.RadioButton();
            this.ContrastRadio = new System.Windows.Forms.RadioButton();
            this.BrightnessRadio = new System.Windows.Forms.RadioButton();
            this.NegationRadio = new System.Windows.Forms.RadioButton();
            this.NoFilterRadio = new System.Windows.Forms.RadioButton();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.DeletePolygonButton = new System.Windows.Forms.Button();
            this.CircleBrushButton = new System.Windows.Forms.Button();
            this.AddPolygonButton = new System.Windows.Forms.Button();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            this.ChartTable.SuspendLayout();
            this.BChartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BChart)).BeginInit();
            this.GChartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GChart)).BeginInit();
            this.RChartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RChart)).BeginInit();
            this.MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyFunctionPicture)).BeginInit();
            this.FilterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastSecondDelta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastFirstDelta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GammaCoefficient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrigthnessDelta)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTable
            // 
            this.MainTable.ColumnCount = 3;
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainTable.Controls.Add(this.Image, 0, 0);
            this.MainTable.Controls.Add(this.ChartTable, 2, 0);
            this.MainTable.Controls.Add(this.MenuPanel, 1, 0);
            this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTable.Location = new System.Drawing.Point(0, 24);
            this.MainTable.Name = "MainTable";
            this.MainTable.RowCount = 1;
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 737F));
            this.MainTable.Size = new System.Drawing.Size(1184, 737);
            this.MainTable.TabIndex = 0;
            // 
            // Image
            // 
            this.Image.BackColor = System.Drawing.Color.White;
            this.Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Image.Location = new System.Drawing.Point(3, 3);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(467, 731);
            this.Image.TabIndex = 0;
            this.Image.TabStop = false;
            this.Image.Paint += new System.Windows.Forms.PaintEventHandler(this.Image_Paint);
            this.Image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Image_MouseDown);
            this.Image.MouseLeave += new System.EventHandler(this.Image_MouseLeave);
            this.Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Image_MouseMove);
            this.Image.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Image_MouseUp);
            // 
            // ChartTable
            // 
            this.ChartTable.ColumnCount = 1;
            this.ChartTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ChartTable.Controls.Add(this.BChartPanel, 0, 2);
            this.ChartTable.Controls.Add(this.GChartPanel, 0, 1);
            this.ChartTable.Controls.Add(this.RChartPanel, 0, 0);
            this.ChartTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartTable.Location = new System.Drawing.Point(831, 3);
            this.ChartTable.Name = "ChartTable";
            this.ChartTable.RowCount = 3;
            this.ChartTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ChartTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ChartTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ChartTable.Size = new System.Drawing.Size(350, 731);
            this.ChartTable.TabIndex = 1;
            this.ChartTable.Paint += new System.Windows.Forms.PaintEventHandler(this.ChartTable_Paint);
            // 
            // BChartPanel
            // 
            this.BChartPanel.Controls.Add(this.BLabel);
            this.BChartPanel.Controls.Add(this.BChart);
            this.BChartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BChartPanel.Location = new System.Drawing.Point(3, 489);
            this.BChartPanel.Name = "BChartPanel";
            this.BChartPanel.Size = new System.Drawing.Size(344, 239);
            this.BChartPanel.TabIndex = 2;
            // 
            // BLabel
            // 
            this.BLabel.AutoSize = true;
            this.BLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BLabel.Location = new System.Drawing.Point(3, 0);
            this.BLabel.Name = "BLabel";
            this.BLabel.Size = new System.Drawing.Size(23, 17);
            this.BLabel.TabIndex = 3;
            this.BLabel.Text = "B:";
            // 
            // BChart
            // 
            chartArea1.Name = "ChartArea1";
            this.BChart.ChartAreas.Add(chartArea1);
            this.BChart.Location = new System.Drawing.Point(0, 32);
            this.BChart.Name = "BChart";
            this.BChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.BChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Blue};
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.BChart.Series.Add(series1);
            this.BChart.Size = new System.Drawing.Size(314, 210);
            this.BChart.TabIndex = 1;
            this.BChart.Text = "chart1";
            // 
            // GChartPanel
            // 
            this.GChartPanel.Controls.Add(this.GLabel);
            this.GChartPanel.Controls.Add(this.GChart);
            this.GChartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GChartPanel.Location = new System.Drawing.Point(3, 246);
            this.GChartPanel.Name = "GChartPanel";
            this.GChartPanel.Size = new System.Drawing.Size(344, 237);
            this.GChartPanel.TabIndex = 1;
            // 
            // GLabel
            // 
            this.GLabel.AutoSize = true;
            this.GLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GLabel.Location = new System.Drawing.Point(3, 0);
            this.GLabel.Name = "GLabel";
            this.GLabel.Size = new System.Drawing.Size(25, 17);
            this.GLabel.TabIndex = 3;
            this.GLabel.Text = "G:";
            // 
            // GChart
            // 
            chartArea2.Name = "ChartArea1";
            this.GChart.ChartAreas.Add(chartArea2);
            this.GChart.Location = new System.Drawing.Point(0, 27);
            this.GChart.Name = "GChart";
            this.GChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.GChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))))};
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.GChart.Series.Add(series2);
            this.GChart.Size = new System.Drawing.Size(314, 210);
            this.GChart.TabIndex = 1;
            this.GChart.Text = "chart1";
            // 
            // RChartPanel
            // 
            this.RChartPanel.Controls.Add(this.RChart);
            this.RChartPanel.Controls.Add(this.RLabel);
            this.RChartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RChartPanel.Location = new System.Drawing.Point(3, 3);
            this.RChartPanel.Name = "RChartPanel";
            this.RChartPanel.Size = new System.Drawing.Size(344, 237);
            this.RChartPanel.TabIndex = 0;
            // 
            // RChart
            // 
            chartArea3.Name = "ChartArea1";
            this.RChart.ChartAreas.Add(chartArea3);
            this.RChart.Location = new System.Drawing.Point(0, 27);
            this.RChart.Name = "RChart";
            this.RChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.RChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))};
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.RChart.Series.Add(series3);
            this.RChart.Size = new System.Drawing.Size(314, 210);
            this.RChart.TabIndex = 0;
            this.RChart.Text = "chart1";
            // 
            // RLabel
            // 
            this.RLabel.AutoSize = true;
            this.RLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RLabel.Location = new System.Drawing.Point(3, 1);
            this.RLabel.Name = "RLabel";
            this.RLabel.Size = new System.Drawing.Size(24, 17);
            this.RLabel.TabIndex = 2;
            this.RLabel.Text = "R:";
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.label3);
            this.MenuPanel.Controls.Add(this.label2);
            this.MenuPanel.Controls.Add(this.label1);
            this.MenuPanel.Controls.Add(this.MyFunctionPicture);
            this.MenuPanel.Controls.Add(this.FilterGroupBox);
            this.MenuPanel.Controls.Add(this.SubmitButton);
            this.MenuPanel.Controls.Add(this.DeletePolygonButton);
            this.MenuPanel.Controls.Add(this.CircleBrushButton);
            this.MenuPanel.Controls.Add(this.AddPolygonButton);
            this.MenuPanel.Controls.Add(this.ModeLabel);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuPanel.Location = new System.Drawing.Point(476, 3);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(349, 731);
            this.MenuPanel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(23, 718);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(303, 718);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "255";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 461);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "255";
            // 
            // MyFunctionPicture
            // 
            this.MyFunctionPicture.BackColor = System.Drawing.Color.White;
            this.MyFunctionPicture.Location = new System.Drawing.Point(3, 452);
            this.MyFunctionPicture.Name = "MyFunctionPicture";
            this.MyFunctionPicture.Size = new System.Drawing.Size(343, 276);
            this.MyFunctionPicture.TabIndex = 6;
            this.MyFunctionPicture.TabStop = false;
            this.MyFunctionPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.MyFunctionPicture_Paint);
            this.MyFunctionPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyFunctionPicture_MouseDown);
            this.MyFunctionPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyFunctionPicture_MouseMove);
            this.MyFunctionPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MyFunctionPicture_MouseUp);
            // 
            // FilterGroupBox
            // 
            this.FilterGroupBox.Controls.Add(this.ContrastSecondDelta);
            this.FilterGroupBox.Controls.Add(this.ContrastFirstDelta);
            this.FilterGroupBox.Controls.Add(this.GammaCoefficient);
            this.FilterGroupBox.Controls.Add(this.BrigthnessDelta);
            this.FilterGroupBox.Controls.Add(this.MyFunctionRadio);
            this.FilterGroupBox.Controls.Add(this.GammaRadio);
            this.FilterGroupBox.Controls.Add(this.ContrastRadio);
            this.FilterGroupBox.Controls.Add(this.BrightnessRadio);
            this.FilterGroupBox.Controls.Add(this.NegationRadio);
            this.FilterGroupBox.Controls.Add(this.NoFilterRadio);
            this.FilterGroupBox.Location = new System.Drawing.Point(63, 217);
            this.FilterGroupBox.Name = "FilterGroupBox";
            this.FilterGroupBox.Size = new System.Drawing.Size(230, 216);
            this.FilterGroupBox.TabIndex = 5;
            this.FilterGroupBox.TabStop = false;
            this.FilterGroupBox.Text = "Filtry";
            this.FilterGroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ContrastSecondDelta
            // 
            this.ContrastSecondDelta.Location = new System.Drawing.Point(176, 121);
            this.ContrastSecondDelta.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ContrastSecondDelta.Name = "ContrastSecondDelta";
            this.ContrastSecondDelta.Size = new System.Drawing.Size(54, 20);
            this.ContrastSecondDelta.TabIndex = 9;
            this.ContrastSecondDelta.Value = new decimal(new int[] {
            225,
            0,
            0,
            0});
            // 
            // ContrastFirstDelta
            // 
            this.ContrastFirstDelta.Location = new System.Drawing.Point(116, 121);
            this.ContrastFirstDelta.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ContrastFirstDelta.Name = "ContrastFirstDelta";
            this.ContrastFirstDelta.Size = new System.Drawing.Size(54, 20);
            this.ContrastFirstDelta.TabIndex = 8;
            this.ContrastFirstDelta.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // GammaCoefficient
            // 
            this.GammaCoefficient.DecimalPlaces = 1;
            this.GammaCoefficient.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.GammaCoefficient.Location = new System.Drawing.Point(148, 98);
            this.GammaCoefficient.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.GammaCoefficient.Name = "GammaCoefficient";
            this.GammaCoefficient.Size = new System.Drawing.Size(54, 20);
            this.GammaCoefficient.TabIndex = 7;
            this.GammaCoefficient.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            // 
            // BrigthnessDelta
            // 
            this.BrigthnessDelta.Location = new System.Drawing.Point(148, 75);
            this.BrigthnessDelta.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BrigthnessDelta.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            -2147483648});
            this.BrigthnessDelta.Name = "BrigthnessDelta";
            this.BrigthnessDelta.Size = new System.Drawing.Size(54, 20);
            this.BrigthnessDelta.TabIndex = 6;
            this.BrigthnessDelta.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // MyFunctionRadio
            // 
            this.MyFunctionRadio.AutoSize = true;
            this.MyFunctionRadio.Location = new System.Drawing.Point(7, 144);
            this.MyFunctionRadio.Name = "MyFunctionRadio";
            this.MyFunctionRadio.Size = new System.Drawing.Size(101, 17);
            this.MyFunctionRadio.TabIndex = 5;
            this.MyFunctionRadio.Text = "Własna funkcja";
            this.MyFunctionRadio.UseVisualStyleBackColor = true;
            // 
            // GammaRadio
            // 
            this.GammaRadio.AutoSize = true;
            this.GammaRadio.Location = new System.Drawing.Point(6, 98);
            this.GammaRadio.Name = "GammaRadio";
            this.GammaRadio.Size = new System.Drawing.Size(104, 17);
            this.GammaRadio.TabIndex = 4;
            this.GammaRadio.Text = "Korekcja gamma";
            this.GammaRadio.UseVisualStyleBackColor = true;
            // 
            // ContrastRadio
            // 
            this.ContrastRadio.AutoSize = true;
            this.ContrastRadio.Location = new System.Drawing.Point(6, 121);
            this.ContrastRadio.Name = "ContrastRadio";
            this.ContrastRadio.Size = new System.Drawing.Size(64, 17);
            this.ContrastRadio.TabIndex = 3;
            this.ContrastRadio.Text = "Kontrast";
            this.ContrastRadio.UseVisualStyleBackColor = true;
            // 
            // BrightnessRadio
            // 
            this.BrightnessRadio.AutoSize = true;
            this.BrightnessRadio.Location = new System.Drawing.Point(6, 75);
            this.BrightnessRadio.Name = "BrightnessRadio";
            this.BrightnessRadio.Size = new System.Drawing.Size(101, 17);
            this.BrightnessRadio.TabIndex = 2;
            this.BrightnessRadio.Text = "Zmiana jasności";
            this.BrightnessRadio.UseVisualStyleBackColor = true;
            // 
            // NegationRadio
            // 
            this.NegationRadio.AutoSize = true;
            this.NegationRadio.Location = new System.Drawing.Point(6, 52);
            this.NegationRadio.Name = "NegationRadio";
            this.NegationRadio.Size = new System.Drawing.Size(65, 17);
            this.NegationRadio.TabIndex = 1;
            this.NegationRadio.Text = "Negacja";
            this.NegationRadio.UseVisualStyleBackColor = true;
            // 
            // NoFilterRadio
            // 
            this.NoFilterRadio.AutoSize = true;
            this.NoFilterRadio.Checked = true;
            this.NoFilterRadio.Location = new System.Drawing.Point(6, 29);
            this.NoFilterRadio.Name = "NoFilterRadio";
            this.NoFilterRadio.Size = new System.Drawing.Size(69, 17);
            this.NoFilterRadio.TabIndex = 0;
            this.NoFilterRadio.TabStop = true;
            this.NoFilterRadio.Text = "Brak filtra";
            this.NoFilterRadio.UseVisualStyleBackColor = true;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(75, 129);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(167, 27);
            this.SubmitButton.TabIndex = 4;
            this.SubmitButton.Text = "Zastosuj";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // DeletePolygonButton
            // 
            this.DeletePolygonButton.Location = new System.Drawing.Point(75, 96);
            this.DeletePolygonButton.Name = "DeletePolygonButton";
            this.DeletePolygonButton.Size = new System.Drawing.Size(167, 27);
            this.DeletePolygonButton.TabIndex = 3;
            this.DeletePolygonButton.Text = "Usuń wielokąt";
            this.DeletePolygonButton.UseVisualStyleBackColor = true;
            this.DeletePolygonButton.Click += new System.EventHandler(this.DeletePolygonButton_Click);
            // 
            // CircleBrushButton
            // 
            this.CircleBrushButton.Location = new System.Drawing.Point(75, 63);
            this.CircleBrushButton.Name = "CircleBrushButton";
            this.CircleBrushButton.Size = new System.Drawing.Size(167, 27);
            this.CircleBrushButton.TabIndex = 2;
            this.CircleBrushButton.Text = "Pędzel kołowy";
            this.CircleBrushButton.UseVisualStyleBackColor = true;
            this.CircleBrushButton.Click += new System.EventHandler(this.CircleBrushButton_Click);
            // 
            // AddPolygonButton
            // 
            this.AddPolygonButton.Location = new System.Drawing.Point(75, 30);
            this.AddPolygonButton.Name = "AddPolygonButton";
            this.AddPolygonButton.Size = new System.Drawing.Size(167, 27);
            this.AddPolygonButton.TabIndex = 1;
            this.AddPolygonButton.Text = "Dodaj wielokąt";
            this.AddPolygonButton.UseVisualStyleBackColor = true;
            this.AddPolygonButton.Click += new System.EventHandler(this.AddPolygonButton_Click);
            // 
            // ModeLabel
            // 
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ModeLabel.Location = new System.Drawing.Point(107, 6);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(114, 15);
            this.ModeLabel.TabIndex = 0;
            this.ModeLabel.Text = "Tryb: Pędzel kołowy";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.createToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1184, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.MainTable);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.Text = "Image Filter";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MainTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            this.ChartTable.ResumeLayout(false);
            this.BChartPanel.ResumeLayout(false);
            this.BChartPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BChart)).EndInit();
            this.GChartPanel.ResumeLayout(false);
            this.GChartPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GChart)).EndInit();
            this.RChartPanel.ResumeLayout(false);
            this.RChartPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RChart)).EndInit();
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyFunctionPicture)).EndInit();
            this.FilterGroupBox.ResumeLayout(false);
            this.FilterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastSecondDelta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastFirstDelta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GammaCoefficient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrigthnessDelta)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTable;
        private System.Windows.Forms.PictureBox Image;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel ChartTable;
        private System.Windows.Forms.Panel BChartPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart BChart;
        private System.Windows.Forms.Panel GChartPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart GChart;
        private System.Windows.Forms.Panel RChartPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart RChart;
        private System.Windows.Forms.Label BLabel;
        private System.Windows.Forms.Label GLabel;
        private System.Windows.Forms.Label RLabel;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button CircleBrushButton;
        private System.Windows.Forms.Button AddPolygonButton;
        private System.Windows.Forms.Label ModeLabel;
        private System.Windows.Forms.Button DeletePolygonButton;
        private System.Windows.Forms.GroupBox FilterGroupBox;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.RadioButton MyFunctionRadio;
        private System.Windows.Forms.RadioButton GammaRadio;
        private System.Windows.Forms.RadioButton ContrastRadio;
        private System.Windows.Forms.RadioButton BrightnessRadio;
        private System.Windows.Forms.RadioButton NegationRadio;
        private System.Windows.Forms.RadioButton NoFilterRadio;
        private System.Windows.Forms.NumericUpDown BrigthnessDelta;
        public System.Windows.Forms.NumericUpDown GammaCoefficient;
        private System.Windows.Forms.NumericUpDown ContrastSecondDelta;
        private System.Windows.Forms.NumericUpDown ContrastFirstDelta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox MyFunctionPicture;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
    }
}

