namespace FrontEndAPI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private ToolStripMenuItem buttonOpenAboutUs;
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            logInToolStripMenuItem1 = new ToolStripMenuItem();
            signUpToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip2 = new ContextMenuStrip(components);
            contextMenuStrip3 = new ContextMenuStrip(components);
            logInToolStripMenuItem = new ToolStripMenuItem();
            signOutToolStripMenuItem = new ToolStripMenuItem();
            Ok = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            contextMenuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            // Inside InitializeComponent() method:
            this.buttonOpenAboutUs = new ToolStripMenuItem();  // Initialize ToolStripMenuItem
            this.buttonOpenAboutUs.Text = "About Us";  // Set the text for the menu item
            this.buttonOpenAboutUs.Click += new EventHandler(this.buttonOpenAboutUs_Click);  // Assign event handler
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 1, 0, 1);
            menuStrip1.Size = new Size(514, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logInToolStripMenuItem1, signUpToolStripMenuItem, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 22);
            fileToolStripMenuItem.Text = "File";
            // 
            // logInToolStripMenuItem1
            // 
            logInToolStripMenuItem1.Name = "logInToolStripMenuItem1";
            logInToolStripMenuItem1.Size = new Size(113, 22);
            logInToolStripMenuItem1.Text = "Log in";
            logInToolStripMenuItem1.Click += logInToolStripMenuItem1_Click;
            // 
            // signUpToolStripMenuItem
            // 
            signUpToolStripMenuItem.Name = "signUpToolStripMenuItem";
            signUpToolStripMenuItem.Size = new Size(113, 22);
            signUpToolStripMenuItem.Text = "sign up";
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(113, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            contextMenuStrip3.Items.AddRange(new ToolStripItem[] { logInToolStripMenuItem, signOutToolStripMenuItem });
            contextMenuStrip3.Name = "contextMenuStrip3";
            contextMenuStrip3.Size = new Size(118, 48);
            // 
            // logInToolStripMenuItem
            // 
            logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            logInToolStripMenuItem.Size = new Size(117, 22);
            logInToolStripMenuItem.Text = "log in";
            // 
            // signOutToolStripMenuItem
            // 
            signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            signOutToolStripMenuItem.Size = new Size(117, 22);
            signOutToolStripMenuItem.Text = "sign out";
            // 
            // Ok
            // 
            Ok.BackColor = Color.FromArgb(110, 148, 207);
            Ok.ForeColor = SystemColors.Window;
            Ok.Location = new Point(146, 273);
            Ok.Name = "Ok";
            Ok.Size = new Size(239, 23);
            Ok.TabIndex = 3;
            Ok.TextChanged += textBox1_TextChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(108, 148, 207);
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(146, 326);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(239, 23);
            textBox1.TabIndex = 4;
            textBox1.PasswordChar = '*'; // Set the PasswordChar property to '*'
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(40, 72, 123);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Candara", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(227, 379);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "LOG IN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(92, 275);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 6;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(64, 324);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 7;
            label2.Text = "Password";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(159, 150);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(202, 72);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;

            // Adding ToolStripMenuItem to the Help menu
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.buttonOpenAboutUs });
            
            // Modify the Help menu creation section:
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { buttonOpenAboutUs });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 22);
            helpToolStripMenuItem.Text = "Help";


            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(514, 561);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(Ok);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            MaximizeBox = false;
            MaximumSize = new Size(530, 600);
            MinimumSize = new Size(530, 600);
            Name = "Form1";
            Text = "DailyDots";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            contextMenuStrip3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem logInToolStripMenuItem1;
        private ToolStripMenuItem signUpToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem logInToolStripMenuItem;
        private ToolStripMenuItem signOutToolStripMenuItem;
        private TextBox Ok;
        private TextBox textBox1;
        private Button button1;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
    }
}
