namespace Common.Wizard
{
    partial class CCWizardForm
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
            this.m_backButton = new System.Windows.Forms.Button();
            this.m_nextButton = new System.Windows.Forms.Button();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.m_finishButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_backButton
            // 
            this.m_backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_backButton.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.m_backButton.Location = new System.Drawing.Point(1309, 3);
            this.m_backButton.Name = "m_backButton";
            this.m_backButton.Size = new System.Drawing.Size(133, 32);
            this.m_backButton.TabIndex = 0;
            this.m_backButton.Text = "< &上一頁";
            this.m_backButton.UseVisualStyleBackColor = true;
            this.m_backButton.Click += new System.EventHandler(this.OnClickBack);
            // 
            // m_nextButton
            // 
            this.m_nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_nextButton.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.m_nextButton.Location = new System.Drawing.Point(1448, 3);
            this.m_nextButton.Name = "m_nextButton";
            this.m_nextButton.Size = new System.Drawing.Size(133, 32);
            this.m_nextButton.TabIndex = 1;
            this.m_nextButton.Text = "&下一頁 >";
            this.m_nextButton.UseVisualStyleBackColor = true;
            this.m_nextButton.Click += new System.EventHandler(this.OnClickNext);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cancelButton.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.m_cancelButton.Location = new System.Drawing.Point(1170, 3);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(133, 32);
            this.m_cancelButton.TabIndex = 2;
            this.m_cancelButton.Text = "取消";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            this.m_cancelButton.Visible = false;
            this.m_cancelButton.Click += new System.EventHandler(this.OnClickCancel);
            // 
            // m_finishButton
            // 
            this.m_finishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_finishButton.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.m_finishButton.Location = new System.Drawing.Point(1587, 3);
            this.m_finishButton.Name = "m_finishButton";
            this.m_finishButton.Size = new System.Drawing.Size(133, 32);
            this.m_finishButton.TabIndex = 3;
            this.m_finishButton.Text = "&列印";
            this.m_finishButton.UseVisualStyleBackColor = true;
            this.m_finishButton.Click += new System.EventHandler(this.OnClickFinish);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1723, 908);
            this.panel1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.81328F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.186722F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1729, 964);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.m_finishButton);
            this.flowLayoutPanel1.Controls.Add(this.m_nextButton);
            this.flowLayoutPanel1.Controls.Add(this.m_backButton);
            this.flowLayoutPanel1.Controls.Add(this.m_cancelButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 917);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1723, 44);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // CCWizardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("PMingLiU", 9F);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "CCWizardForm";
            this.Size = new System.Drawing.Size(1729, 964);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button m_backButton;
        protected System.Windows.Forms.Button m_nextButton;
        protected System.Windows.Forms.Button m_cancelButton;
        protected System.Windows.Forms.Button m_finishButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
