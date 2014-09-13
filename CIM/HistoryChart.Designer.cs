namespace HistoryChart
{
    partial class HistoryChartPanel
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numberStartHour = new System.Windows.Forms.NumericUpDown();
            this.numberEndHour = new System.Windows.Forms.NumericUpDown();
            this.numberStartMin = new System.Windows.Forms.NumericUpDown();
            this.numberEndMin = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnLast5Page = new System.Windows.Forms.Button();
            this.btnLast25 = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnNext5Page = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPaint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkScientific = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnScaleLarge = new System.Windows.Forms.Button();
            this.btnScaleSmall = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_Chart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberStartHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberEndHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberStartMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberEndMin)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.63833F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.36167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.m_Chart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1268, 649);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // m_Chart
            // 
            chartArea7.AxisX.Interval = 1D;
            chartArea7.AxisX.LabelAutoFitMaxFontSize = 7;
            chartArea7.AxisX.LabelStyle.Format = "HH:mm:ss";
            chartArea7.AxisX.LabelStyle.Interval = 1D;
            chartArea7.AxisY.Interval = 100D;
            chartArea7.AxisY.LabelStyle.Format = "0.00E+00";
            chartArea7.AxisY.LabelStyle.Interval = 100D;
            chartArea7.AxisY.LineColor = System.Drawing.Color.DarkRed;
            chartArea7.AxisY.Maximum = 1200D;
            chartArea7.AxisY.Minimum = 0D;
            chartArea7.CursorY.IsUserEnabled = true;
            chartArea7.CursorY.IsUserSelectionEnabled = true;
            chartArea7.Name = "Default";
            chartArea7.Position.Auto = false;
            chartArea7.Position.Height = 94F;
            chartArea7.Position.Width = 100F;
            chartArea7.Position.Y = 3F;
            this.m_Chart.ChartAreas.Add(chartArea7);
            this.m_Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend13.Name = "Legend1";
            legend14.Name = "Legend2";
            this.m_Chart.Legends.Add(legend13);
            this.m_Chart.Legends.Add(legend14);
            this.m_Chart.Location = new System.Drawing.Point(410, 3);
            this.m_Chart.Name = "m_Chart";
            series19.ChartArea = "Default";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series19.Legend = "Legend1";
            series19.Name = "LVG";
            series20.ChartArea = "Default";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series20.Legend = "Legend2";
            series20.LegendText = "HVG";
            series20.Name = "HVG";
            series21.ChartArea = "Default";
            series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series21.Legend = "Legend1";
            series21.Name = "Pumping";
            series21.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.m_Chart.Series.Add(series19);
            this.m_Chart.Series.Add(series20);
            this.m_Chart.Series.Add(series21);
            this.m_Chart.Size = new System.Drawing.Size(834, 643);
            this.m_Chart.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 643);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Condition";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.451796F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.451796F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.198488F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.76527F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.646302F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.05788F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.37942F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(395, 622);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 151);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(374, 210);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.03448F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.96552F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel3.Controls.Add(this.dateTimePickerEnd, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.numberStartHour, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.numberEndHour, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.numberStartMin, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.numberEndMin, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePickerStart, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(389, 52);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CalendarFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.Location = new System.Drawing.Point(78, 29);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(160, 37);
            this.dateTimePickerEnd.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "End";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numberStartHour
            // 
            this.numberStartHour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberStartHour.Location = new System.Drawing.Point(244, 3);
            this.numberStartHour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numberStartHour.Name = "numberStartHour";
            this.numberStartHour.Size = new System.Drawing.Size(67, 37);
            this.numberStartHour.TabIndex = 4;
            this.numberStartHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numberEndHour
            // 
            this.numberEndHour.Location = new System.Drawing.Point(244, 29);
            this.numberEndHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numberEndHour.Name = "numberEndHour";
            this.numberEndHour.Size = new System.Drawing.Size(67, 37);
            this.numberEndHour.TabIndex = 5;
            this.numberEndHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numberStartMin
            // 
            this.numberStartMin.Location = new System.Drawing.Point(317, 3);
            this.numberStartMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numberStartMin.Name = "numberStartMin";
            this.numberStartMin.Size = new System.Drawing.Size(57, 37);
            this.numberStartMin.TabIndex = 6;
            this.numberStartMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numberEndMin
            // 
            this.numberEndMin.Location = new System.Drawing.Point(317, 29);
            this.numberEndMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numberEndMin.Name = "numberEndMin";
            this.numberEndMin.Size = new System.Drawing.Size(57, 37);
            this.numberEndMin.TabIndex = 7;
            this.numberEndMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CalendarFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerStart.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Location = new System.Drawing.Point(78, 3);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(160, 37);
            this.dateTimePickerStart.TabIndex = 8;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.50562F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.49438F));
            this.tableLayoutPanel4.Controls.Add(this.comboBox1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnFilter, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 119);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(389, 26);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(268, 37);
            this.comboBox1.TabIndex = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFilter.Location = new System.Drawing.Point(277, 3);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(109, 20);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 414);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 53);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "移動";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnFirstPage);
            this.flowLayoutPanel1.Controls.Add(this.btnLast5Page);
            this.flowLayoutPanel1.Controls.Add(this.btnLast25);
            this.flowLayoutPanel1.Controls.Add(this.btnNextPage);
            this.flowLayoutPanel1.Controls.Add(this.btnNext5Page);
            this.flowLayoutPanel1.Controls.Add(this.btnLastPage);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(383, 23);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Location = new System.Drawing.Point(3, 3);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(70, 36);
            this.btnFirstPage.TabIndex = 0;
            this.btnFirstPage.Text = "|<";
            this.toolTip1.SetToolTip(this.btnFirstPage, "第一頁");
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // btnLast5Page
            // 
            this.btnLast5Page.Location = new System.Drawing.Point(79, 3);
            this.btnLast5Page.Name = "btnLast5Page";
            this.btnLast5Page.Size = new System.Drawing.Size(70, 36);
            this.btnLast5Page.TabIndex = 1;
            this.btnLast5Page.Text = "<<";
            this.toolTip1.SetToolTip(this.btnLast5Page, "上五頁");
            this.btnLast5Page.UseVisualStyleBackColor = true;
            this.btnLast5Page.Click += new System.EventHandler(this.btnLast5Page_Click);
            // 
            // btnLast25
            // 
            this.btnLast25.Location = new System.Drawing.Point(155, 3);
            this.btnLast25.Name = "btnLast25";
            this.btnLast25.Size = new System.Drawing.Size(70, 36);
            this.btnLast25.TabIndex = 2;
            this.btnLast25.Text = "<";
            this.toolTip1.SetToolTip(this.btnLast25, "上一頁");
            this.btnLast25.UseVisualStyleBackColor = true;
            this.btnLast25.Click += new System.EventHandler(this.btnPrevioustPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(231, 3);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(70, 36);
            this.btnNextPage.TabIndex = 3;
            this.btnNextPage.Text = ">";
            this.toolTip1.SetToolTip(this.btnNextPage, "下一頁");
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnNext5Page
            // 
            this.btnNext5Page.Location = new System.Drawing.Point(307, 3);
            this.btnNext5Page.Name = "btnNext5Page";
            this.btnNext5Page.Size = new System.Drawing.Size(70, 36);
            this.btnNext5Page.TabIndex = 4;
            this.btnNext5Page.Text = ">>";
            this.toolTip1.SetToolTip(this.btnNext5Page, "下五頁");
            this.btnNext5Page.UseVisualStyleBackColor = true;
            this.btnNext5Page.Click += new System.EventHandler(this.btnNext5Page_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Location = new System.Drawing.Point(3, 45);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(70, 36);
            this.btnLastPage.TabIndex = 5;
            this.btnLastPage.Text = ">|";
            this.toolTip1.SetToolTip(this.btnLastPage, "最後一頁");
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 473);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 68);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scaling";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 547);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(389, 72);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnPaint);
            this.flowLayoutPanel3.Controls.Add(this.btnSave);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 33);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(383, 36);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // btnPaint
            // 
            this.btnPaint.Location = new System.Drawing.Point(3, 3);
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.Size = new System.Drawing.Size(116, 47);
            this.btnPaint.TabIndex = 2;
            this.btnPaint.Text = "Paint";
            this.btnPaint.UseVisualStyleBackColor = true;
            this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(125, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 47);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkScientific);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 61);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(389, 52);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            // 
            // chkScientific
            // 
            this.chkScientific.AutoSize = true;
            this.chkScientific.Checked = true;
            this.chkScientific.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScientific.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkScientific.Location = new System.Drawing.Point(3, 33);
            this.chkScientific.Name = "chkScientific";
            this.chkScientific.Size = new System.Drawing.Size(383, 16);
            this.chkScientific.TabIndex = 3;
            this.chkScientific.Text = "Scientific Notation(科學符號)";
            this.chkScientific.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.btnScaleSmall, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnScaleLarge, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox6, 2, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 27);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(383, 38);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // btnScaleLarge
            // 
            this.btnScaleLarge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnScaleLarge.Location = new System.Drawing.Point(3, 3);
            this.btnScaleLarge.Name = "btnScaleLarge";
            this.btnScaleLarge.Size = new System.Drawing.Size(89, 32);
            this.btnScaleLarge.TabIndex = 9;
            this.btnScaleLarge.Text = "+";
            this.btnScaleLarge.UseVisualStyleBackColor = true;
            this.btnScaleLarge.Click += new System.EventHandler(this.btnScaleLarge_Click);
            // 
            // btnScaleSmall
            // 
            this.btnScaleSmall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnScaleSmall.Location = new System.Drawing.Point(98, 3);
            this.btnScaleSmall.Name = "btnScaleSmall";
            this.btnScaleSmall.Size = new System.Drawing.Size(89, 32);
            this.btnScaleSmall.TabIndex = 10;
            this.btnScaleSmall.Text = "-";
            this.btnScaleSmall.UseVisualStyleBackColor = true;
            this.btnScaleSmall.Click += new System.EventHandler(this.btnScaleSmall_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel6);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(193, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(187, 32);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Y Axis";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.txtMax, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.txtMin, 1, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(181, 12);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 6);
            this.label3.TabIndex = 0;
            this.label3.Text = "Max";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(93, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 6);
            this.label4.TabIndex = 1;
            this.label4.Text = "Min";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMax
            // 
            this.txtMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMax.Location = new System.Drawing.Point(3, 9);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(84, 21);
            this.txtMax.TabIndex = 2;
            this.txtMax.Text = "1200";
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMax_KeyPress);
            // 
            // txtMin
            // 
            this.txtMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMin.Location = new System.Drawing.Point(93, 9);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(85, 21);
            this.txtMin.TabIndex = 3;
            this.txtMin.Text = "0";
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMin_KeyPress);
            // 
            // HistoryChartPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HistoryChartPanel";
            this.Size = new System.Drawing.Size(1268, 649);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_Chart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberStartHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberEndHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberStartMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberEndMin)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numberStartHour;
        private System.Windows.Forms.NumericUpDown numberEndHour;
        private System.Windows.Forms.NumericUpDown numberStartMin;
        private System.Windows.Forms.NumericUpDown numberEndMin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnLast5Page;
        private System.Windows.Forms.Button btnLast25;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnNext5Page;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataVisualization.Charting.Chart m_Chart;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnPaint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkScientific;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnScaleSmall;
        private System.Windows.Forms.Button btnScaleLarge;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.TextBox txtMin;


    }
}
