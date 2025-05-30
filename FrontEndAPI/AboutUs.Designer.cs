namespace FrontEndAPI
{
    partial class AboutUsForm
    {
        private System.ComponentModel.IContainer components = null;

        // Dispose method to clean up resources
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Form's InitializeComponent method to define controls and layout


        private void InitializeComponent()
        {
            label1 = new Label();
            buttonClose = new Button();
            menuStrip = new MenuStrip();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold);
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(208, 57);
            label1.TabIndex = 0;
            label1.Text = "About Us\r\nApp Name: DailyDots\r\nAuthor: Maryam Rahmeen";
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(199, 130);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 1;
            buttonClose.Text = "Ok";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // menuStrip
            // 
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(284, 24);
            menuStrip.TabIndex = 0;
            // 
            // AboutUsForm
            // 
            ClientSize = new Size(284, 161);
            Controls.Add(menuStrip);
            Controls.Add(buttonClose);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "AboutUsForm";
            Text = "About Us";
            Load += AboutUsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        // Form controls
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.MenuStrip menuStrip;
        private ToolStripMenuItem fullScreenMenuItem;
    }
}
