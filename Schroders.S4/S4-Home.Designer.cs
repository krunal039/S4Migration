namespace Schroders.S4
{
    partial class S4_Home
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
            webViewS4 = new Microsoft.Web.WebView2.WinForms.WebView2();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webViewS4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // webViewS4
            // 
            webViewS4.CreationProperties = null;
            webViewS4.DefaultBackgroundColor = Color.White;
            webViewS4.Location = new Point(3, 12);
            webViewS4.Name = "webViewS4";
            webViewS4.Size = new Size(1410, 828);
            webViewS4.TabIndex = 0;
            webViewS4.ZoomFactor = 1D;
            // 
            // webView21
            // 
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(613, 0);
            webView21.Name = "webView21";
            webView21.Size = new Size(94, 29);
            webView21.TabIndex = 1;
            webView21.ZoomFactor = 1D;
            // 
            // S4_Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1416, 843);
            Controls.Add(webView21);
            Controls.Add(webViewS4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "S4_Home";
            Text = "Congratulations You moved to S4";
            Load += S4_Home_Load;
            ((System.ComponentModel.ISupportInitialize)webViewS4).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewS4;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}