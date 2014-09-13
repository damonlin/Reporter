namespace Common.Template
{
   partial class NavigationPanelTemplate
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
          this.components = new System.ComponentModel.Container();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigationPanelTemplate));
          this.navigationLabel = new System.Windows.Forms.Label();
          this.subNavigationPanel = new System.Windows.Forms.Panel();
          this.splitContainer1 = new System.Windows.Forms.SplitContainer();
          this.panel1 = new System.Windows.Forms.Panel();
          this.imageList1 = new System.Windows.Forms.ImageList(this.components);
          this.splitContainer1.Panel1.SuspendLayout();
          this.splitContainer1.Panel2.SuspendLayout();
          this.splitContainer1.SuspendLayout();
          this.SuspendLayout();
          // 
          // navigationLabel
          // 
          resources.ApplyResources(this.navigationLabel, "navigationLabel");
          this.navigationLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
          this.navigationLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.navigationLabel.ForeColor = System.Drawing.Color.White;
          this.navigationLabel.Name = "navigationLabel";
          // 
          // subNavigationPanel
          // 
          resources.ApplyResources(this.subNavigationPanel, "subNavigationPanel");
          this.subNavigationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.subNavigationPanel.Name = "subNavigationPanel";
          // 
          // splitContainer1
          // 
          resources.ApplyResources(this.splitContainer1, "splitContainer1");
          this.splitContainer1.Name = "splitContainer1";
          // 
          // splitContainer1.Panel1
          // 
          this.splitContainer1.Panel1.Controls.Add(this.panel1);
          // 
          // splitContainer1.Panel2
          // 
          this.splitContainer1.Panel2.Controls.Add(this.subNavigationPanel);
          this.splitContainer1.Panel2.Controls.Add(this.navigationLabel);
          // 
          // panel1
          // 
          this.panel1.BackColor = System.Drawing.SystemColors.Window;
          this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this.panel1, "panel1");
          this.panel1.Name = "panel1";
          // 
          // imageList1
          // 
          this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
          this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
          this.imageList1.Images.SetKeyName(0, "false");
          this.imageList1.Images.SetKeyName(1, "true");
          // 
          // NavigationPanelTemplate
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
          this.Controls.Add(this.splitContainer1);
          this.Name = "NavigationPanelTemplate";
          this.Tag = "";
          this.splitContainer1.Panel1.ResumeLayout(false);
          this.splitContainer1.Panel2.ResumeLayout(false);
          this.splitContainer1.ResumeLayout(false);
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label navigationLabel;
       private System.Windows.Forms.Panel subNavigationPanel;
       private System.Windows.Forms.SplitContainer splitContainer1;
       private System.Windows.Forms.Panel panel1;
       private System.Windows.Forms.ImageList imageList1;
   }
}
