namespace Common
{
    partial class Debug
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
            //base.Dispose(disposing);
            base.Hide();
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.DDEMsg = new System.Windows.Forms.Button();
            this.ConnectZS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DDEMsg
            // 
            this.DDEMsg.Location = new System.Drawing.Point(248, 219);
            this.DDEMsg.Name = "DDEMsg";
            this.DDEMsg.Size = new System.Drawing.Size(75, 23);
            this.DDEMsg.TabIndex = 1;
            this.DDEMsg.Text = "Debug DDE";
            this.DDEMsg.UseVisualStyleBackColor = true;
            this.DDEMsg.Click += new System.EventHandler(this.DDEMsg_Click);
            // 
            // ConnectZS
            // 
            this.ConnectZS.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.ConnectZS.Location = new System.Drawing.Point(150, 219);
            this.ConnectZS.Name = "ConnectZS";
            this.ConnectZS.Size = new System.Drawing.Size(75, 23);
            this.ConnectZS.TabIndex = 2;
            this.ConnectZS.Text = "Connect ZS";
            this.ConnectZS.UseVisualStyleBackColor = true;
            this.ConnectZS.Click += new System.EventHandler(this.ConnectZS_Click);
            // 
            // Debug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 268);
            this.Controls.Add(this.ConnectZS);
            this.Controls.Add(this.DDEMsg);
            this.Name = "Debug";
            this.Text = "Debug";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DDEMsg;
        private System.Windows.Forms.Button ConnectZS;

    }
}