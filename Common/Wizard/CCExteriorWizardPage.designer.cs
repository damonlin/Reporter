namespace Common.Wizard
{
    partial class CCExteriorWizardPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCExteriorWizardPage));
            this.m_headerPanel = new System.Windows.Forms.Panel();
            this.m_titleLabel = new System.Windows.Forms.Label();
            this.m_headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_headerPanel
            // 
            this.m_headerPanel.BackColor = System.Drawing.Color.White;
            this.m_headerPanel.BackgroundImage = global::Common.Properties.Resources.Contrel_Logo2;
            resources.ApplyResources(this.m_headerPanel, "m_headerPanel");
            this.m_headerPanel.Controls.Add(this.m_titleLabel);
            this.m_headerPanel.Name = "m_headerPanel";
            // 
            // m_titleLabel
            // 
            this.m_titleLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.m_titleLabel, "m_titleLabel");
            this.m_titleLabel.Name = "m_titleLabel";
            // 
            // CCExteriorWizardPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_headerPanel);
            this.Name = "CCExteriorWizardPage";
            this.m_headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_headerPanel;
        protected System.Windows.Forms.Label m_titleLabel;


    }
}
