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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCWizardForm));
            this.m_backButton = new System.Windows.Forms.Button();
            this.m_nextButton = new System.Windows.Forms.Button();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.m_finishButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // m_backButton
            // 
            this.m_backButton.AccessibleDescription = null;
            this.m_backButton.AccessibleName = null;
            resources.ApplyResources(this.m_backButton, "m_backButton");
            this.m_backButton.BackgroundImage = null;
            this.m_backButton.Name = "m_backButton";
            this.m_backButton.UseVisualStyleBackColor = true;
            this.m_backButton.Click += new System.EventHandler(this.OnClickBack);
            // 
            // m_nextButton
            // 
            this.m_nextButton.AccessibleDescription = null;
            this.m_nextButton.AccessibleName = null;
            resources.ApplyResources(this.m_nextButton, "m_nextButton");
            this.m_nextButton.BackgroundImage = null;
            this.m_nextButton.Name = "m_nextButton";
            this.m_nextButton.UseVisualStyleBackColor = true;
            this.m_nextButton.Click += new System.EventHandler(this.OnClickNext);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.AccessibleDescription = null;
            this.m_cancelButton.AccessibleName = null;
            resources.ApplyResources(this.m_cancelButton, "m_cancelButton");
            this.m_cancelButton.BackgroundImage = null;
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            this.m_cancelButton.Click += new System.EventHandler(this.OnClickCancel);
            // 
            // m_finishButton
            // 
            this.m_finishButton.AccessibleDescription = null;
            this.m_finishButton.AccessibleName = null;
            resources.ApplyResources(this.m_finishButton, "m_finishButton");
            this.m_finishButton.BackgroundImage = null;
            this.m_finishButton.Name = "m_finishButton";
            this.m_finishButton.UseVisualStyleBackColor = true;
            this.m_finishButton.Click += new System.EventHandler(this.OnClickFinish);
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackgroundImage = null;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // CCWizardForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_finishButton);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_nextButton);
            this.Controls.Add(this.m_backButton);
            this.Font = null;
            this.Name = "CCWizardForm";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button m_backButton;
        protected System.Windows.Forms.Button m_nextButton;
        protected System.Windows.Forms.Button m_cancelButton;
        protected System.Windows.Forms.Button m_finishButton;
        private System.Windows.Forms.Panel panel1;
    }
}
