namespace AlarmList
{
   partial class AlarmListPanelControl
   {
      /// <summary> 
      /// 設計工具所需的變數。
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// 清除任何使用中的資源。
      /// </summary>
      /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region 元件設計工具產生的程式碼

      /// <summary> 
      /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
      ///
      /// </summary>
      private void InitializeComponent()
      {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmListPanelControl));
			this.alarmListDataGridView = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.editAlarmToolStrip = new System.Windows.Forms.ToolStrip();
			this.label1 = new System.Windows.Forms.Label();
			this.newAlarmToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.removeAlarmToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.alarmListDataGridView)).BeginInit();
			this.editAlarmToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// alarmListDataGridView
			// 
			this.alarmListDataGridView.AllowUserToAddRows = false;
			this.alarmListDataGridView.AllowUserToDeleteRows = false;
			this.alarmListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.alarmListDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.alarmListDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(221)))));
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.alarmListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.alarmListDataGridView.ColumnHeadersHeight = 45;
			this.alarmListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.alarmListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.alarmListDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
			this.alarmListDataGridView.Location = new System.Drawing.Point(0, 39);
			this.alarmListDataGridView.MultiSelect = false;
			this.alarmListDataGridView.Name = "alarmListDataGridView";
			this.alarmListDataGridView.RowHeadersVisible = false;
			this.alarmListDataGridView.RowHeadersWidth = 25;
			this.alarmListDataGridView.RowTemplate.Height = 24;
			this.alarmListDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.alarmListDataGridView.Size = new System.Drawing.Size(1109, 804);
			this.alarmListDataGridView.TabIndex = 0;
			this.alarmListDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.alarmListDataGridView_CellValueChanged);
			this.alarmListDataGridView.Sorted += new System.EventHandler(this.alarmListDataGridView_Sorted);
			this.alarmListDataGridView.RowHeightChanged += new System.Windows.Forms.DataGridViewRowEventHandler(this.alarmListDataGridView_RowHeightChanged);
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column1.HeaderText = "Code";
			this.Column1.Name = "Column1";
			this.Column1.Width = 80;
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column2.HeaderText = "Level";
			this.Column2.Name = "Column2";
			this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column2.Width = 40;
			// 
			// Column3
			// 
			this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column3.HeaderText = "Type";
			this.Column3.Name = "Column3";
			this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column3.Width = 40;
			// 
			// Column4
			// 
			this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column4.HeaderText = "Reset";
			this.Column4.Name = "Column4";
			this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column4.Width = 40;
			// 
			// Column5
			// 
			this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column5.HeaderText = "Retry";
			this.Column5.Name = "Column5";
			this.Column5.Width = 40;
			// 
			// Column6
			// 
			this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column6.HeaderText = "Skip";
			this.Column6.Name = "Column6";
			this.Column6.Width = 40;
			// 
			// Column7
			// 
			this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Column7.HeaderText = "Continue";
			this.Column7.Name = "Column7";
			this.Column7.Width = 65;
			// 
			// Column8
			// 
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Column8.DefaultCellStyle = dataGridViewCellStyle2;
			this.Column8.HeaderText = "Message";
			this.Column8.MinimumWidth = 50;
			this.Column8.Name = "Column8";
			this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column8.Width = 400;
			// 
			// Column9
			// 
			this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Column9.DefaultCellStyle = dataGridViewCellStyle3;
			this.Column9.HeaderText = "Troubleshooting";
			this.Column9.MinimumWidth = 50;
			this.Column9.Name = "Column9";
			this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// editAlarmToolStrip
			// 
			this.editAlarmToolStrip.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.editAlarmToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.editAlarmToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAlarmToolStripButton,
            this.removeAlarmToolStripButton,
            this.saveToolStripButton});
			this.editAlarmToolStrip.Location = new System.Drawing.Point(0, 0);
			this.editAlarmToolStrip.Name = "editAlarmToolStrip";
			this.editAlarmToolStrip.Size = new System.Drawing.Size(1109, 39);
			this.editAlarmToolStrip.Stretch = true;
			this.editAlarmToolStrip.TabIndex = 3;
			this.editAlarmToolStrip.Text = "toolStrip1";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.BackColor = System.Drawing.Color.Gold;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(877, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(229, 32);
			this.label1.TabIndex = 4;
			this.label1.Text = "New paragraph: Shift + Enter";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// newAlarmToolStripButton
			// 
			this.newAlarmToolStripButton.Image = global::AlarmList.Properties.Resources.netvibes;
			this.newAlarmToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.newAlarmToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newAlarmToolStripButton.Name = "newAlarmToolStripButton";
			this.newAlarmToolStripButton.Size = new System.Drawing.Size(102, 36);
			this.newAlarmToolStripButton.Text = "New Alarm";
			this.newAlarmToolStripButton.Click += new System.EventHandler(this.newAlarmToolStripButton_Click);
			// 
			// removeAlarmToolStripButton
			// 
			this.removeAlarmToolStripButton.Image = global::AlarmList.Properties.Resources.x_32x32;
			this.removeAlarmToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.removeAlarmToolStripButton.Name = "removeAlarmToolStripButton";
			this.removeAlarmToolStripButton.Size = new System.Drawing.Size(132, 36);
			this.removeAlarmToolStripButton.Text = "Remove Alarm";
			this.removeAlarmToolStripButton.Click += new System.EventHandler(this.removeAlarmToolStripButton_Click);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.Enabled = false;
			this.saveToolStripButton.Image = global::AlarmList.Properties.Resources.save_32x32;
			this.saveToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(74, 36);
			this.saveToolStripButton.Text = "Save";
			this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// AlarmListPanelControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.editAlarmToolStrip);
			this.Controls.Add(this.alarmListDataGridView);
			this.Name = "AlarmListPanelControl";
			this.Size = new System.Drawing.Size(1109, 843);
			this.Tag = "Alarm List";
			this.Load += new System.EventHandler(this.AlarmListPanelControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.alarmListDataGridView)).EndInit();
			this.editAlarmToolStrip.ResumeLayout(false);
			this.editAlarmToolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.DataGridView alarmListDataGridView;
      private System.Windows.Forms.ToolStrip editAlarmToolStrip;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
      private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
      private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
      private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
      private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
      private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
      private System.Windows.Forms.ToolStripButton newAlarmToolStripButton;
      private System.Windows.Forms.ToolStripButton removeAlarmToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
   }
}
