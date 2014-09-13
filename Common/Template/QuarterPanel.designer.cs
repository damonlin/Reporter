namespace Common.Template
{
    partial class QuarterPanel
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            this.Hide();
            /*
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
             * */
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuarterPanel));
            this.SuspendLayout();
            // 
            // QuarterPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuarterPanel";
            this.ShowInTaskbar = false;
            this.SizeChanged += new System.EventHandler(this.QuarterPanel_SizeChanged);
            this.Move += new System.EventHandler(this.QuarterPanel_Move);
            this.ResumeLayout(false);

        }

        #endregion
    }
}