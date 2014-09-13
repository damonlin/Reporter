namespace Common.Template
{
   partial class InfoPanelTemplate
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoPanelTemplate));
          this.SuspendLayout();
          // 
          // InfoPanelTemplate
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.SystemColors.Window;
          this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.Name = "InfoPanelTemplate";
          this.DragDrop += new System.Windows.Forms.DragEventHandler(this.InfoPanelTemplate_DragDrop);
          this.DragEnter += new System.Windows.Forms.DragEventHandler(this.InfoPanelTemplate_DragEnter);
          this.ResumeLayout(false);

      }

      #endregion
   }
}
