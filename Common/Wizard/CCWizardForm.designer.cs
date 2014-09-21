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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_backButton
            // 
            this.m_backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_backButton.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.m_backButton.Location = new System.Drawing.Point(3, 79);
            this.m_backButton.Name = "m_backButton";
            this.m_backButton.Size = new System.Drawing.Size(245, 70);
            this.m_backButton.TabIndex = 0;
            this.m_backButton.Text = "< &上一頁";
            this.m_backButton.UseVisualStyleBackColor = true;
            this.m_backButton.Click += new System.EventHandler(this.OnClickBack);
            // 
            // m_nextButton
            // 
            this.m_nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_nextButton.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.m_nextButton.Location = new System.Drawing.Point(3, 155);
            this.m_nextButton.Name = "m_nextButton";
            this.m_nextButton.Size = new System.Drawing.Size(245, 70);
            this.m_nextButton.TabIndex = 1;
            this.m_nextButton.Text = "&下一頁 >";
            this.m_nextButton.UseVisualStyleBackColor = true;
            this.m_nextButton.Click += new System.EventHandler(this.OnClickNext);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cancelButton.Font = new System.Drawing.Font("PMingLiU", 12F);
            this.m_cancelButton.Location = new System.Drawing.Point(3, 231);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(245, 70);
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
            this.m_finishButton.Location = new System.Drawing.Point(3, 3);
            this.m_finishButton.Name = "m_finishButton";
            this.m_finishButton.Size = new System.Drawing.Size(245, 70);
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
            this.panel1.Size = new System.Drawing.Size(1469, 958);
            this.panel1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 254F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.81328F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1729, 964);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Gray;
            this.flowLayoutPanel2.Controls.Add(this.m_finishButton);
            this.flowLayoutPanel2.Controls.Add(this.m_backButton);
            this.flowLayoutPanel2.Controls.Add(this.m_nextButton);
            this.flowLayoutPanel2.Controls.Add(this.m_cancelButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1478, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(248, 958);
            this.flowLayoutPanel2.TabIndex = 6;
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
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button m_backButton;
        protected System.Windows.Forms.Button m_nextButton;
        protected System.Windows.Forms.Button m_cancelButton;
        protected System.Windows.Forms.Button m_finishButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}
