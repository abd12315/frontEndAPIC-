using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace FrontEndAPI
{
    public partial class AboutUsForm : Form
    {
        public AboutUsForm()
        {
            InitializeComponent();
            label1.Text = "App Name: DailyDots\nAuthor: Maryam Rahmeen\nVersion:Beta 1.0(Build final)\nContact: Abdasq76@gmail.com";
        }
        //private void fullScreenMenuItem_Click(object sender, EventArgs e)
        //{
        //    // Toggle between normal and full-screen mode
        //    if (this.WindowState == FormWindowState.Normal)
        //    {
        //        this.WindowState = FormWindowState.Maximized;  // Set the window to full screen
        //        this.FormBorderStyle = FormBorderStyle.None;   // Remove borders for full-screen effect
        //    }
        //    else
        //    {
        //        this.WindowState = FormWindowState.Normal;     // Restore the window to normal size
        //        this.FormBorderStyle = FormBorderStyle.Sizable;  // Restore the border
        //    }
        //}
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close(); // This closes the AboutUsForm when the Close button is clicked
        }

        private void AboutUsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
