namespace Schroders.S4
{
    partial class S3_Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            webViewS3 = new Microsoft.Web.WebView2.WinForms.WebView2();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)webViewS3).BeginInit();
            SuspendLayout();
            // 
            // webViewS3
            // 
            webViewS3.CreationProperties = null;
            webViewS3.DefaultBackgroundColor = Color.White;
            webViewS3.Location = new Point(10, 83);
            webViewS3.Name = "webViewS3";
            webViewS3.Size = new Size(1290, 748);
            webViewS3.TabIndex = 0;
            webViewS3.ZoomFactor = 1D;
            // 
            // button1
            // 
            button1.Location = new Point(1293, 24);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // S3_Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1416, 843);
            Controls.Add(button1);
            Controls.Add(webViewS3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "S3_Home";
            Text = "You are moving to S4!";
            Load += S3_Home_Load;
            ((System.ComponentModel.ISupportInitialize)webViewS3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewS3;
        private Button button1;
    }
}