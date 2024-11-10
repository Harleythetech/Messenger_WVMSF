namespace Messenger
{
    partial class Messenger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Messenger));
            Browssenger = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)Browssenger).BeginInit();
            SuspendLayout();
            // 
            // Browssenger
            // 
            Browssenger.AllowExternalDrop = false;
            Browssenger.BackColor = Color.FromArgb(64, 64, 64);
            Browssenger.BackgroundImageLayout = ImageLayout.Zoom;
            Browssenger.CreationProperties = null;
            Browssenger.DefaultBackgroundColor = Color.SteelBlue;
            Browssenger.Dock = DockStyle.Fill;
            Browssenger.Location = new Point(0, 0);
            Browssenger.Name = "Browssenger";
            Browssenger.Size = new Size(1008, 729);
            Browssenger.TabIndex = 0;
            Browssenger.ZoomFactor = 1D;
            // 
            // Messenger
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(36, 36, 36);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1008, 729);
            Controls.Add(Browssenger);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1024, 718);
            Name = "Messenger";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Messenger";
            ((System.ComponentModel.ISupportInitialize)Browssenger).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public Microsoft.Web.WebView2.WinForms.WebView2 Browssenger;
    }
}