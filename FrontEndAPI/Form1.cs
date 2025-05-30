using Microsoft.VisualBasic;
using Newtonsoft.Json;
using UserModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEndAPI
{
    public partial class Form1 : Form
    {
        // Constructor
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal; // Ensure the window starts normally
        }

        // Optional: Prevent Alt+Enter from toggling full screen
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MAXIMIZE = 0xF030;

            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_MAXIMIZE)
            {
                
                return; // Block maximize command
            }
            base.WndProc(ref m);
        }

        // Form Load event
        private void Form1_Load(object sender, EventArgs e)
        {
            // Your code when the form loads, if any
        }

        // Event handler for Close menu item
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close the form when the Close menu item is clicked
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = Ok.Text;
            string password = textBox1.Text;

            try
            {
                string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");

                if (!File.Exists(jsonFilePath))
                {
                    MessageBox.Show("User data file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string jsonData = File.ReadAllText(jsonFilePath);
                UserList? userList = JsonConvert.DeserializeObject<UserList>(jsonData);

                if (userList == null || userList.Users == null)
                {
                    MessageBox.Show("Failed to load user data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Show the progress form
                ProgressForm progressForm = new ProgressForm();
                progressForm.Show();

                // Simulate verification process
                for (int i = 0; i <= 10; i++)
                {
                    progressForm.progressBar.Value = i * 10;
                    await Task.Delay(500); // Wait for 500ms
                }

                var matchedUser = userList.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                progressForm.Close(); // Close the progress form

                if (matchedUser != null)
                {
                    // Show welcome message
                    MessageBox.Show($"Welcome back, {matchedUser.Username}!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open the main page form
                    MainPage mainPage = new MainPage();

                    // Show the main form as a dialog, ensuring it is modal
                    this.Hide(); // Hide login form before showing main page
                    mainPage.ShowDialog();

                    // Once mainPage closes, close the login form completely
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid credentials. Access denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logInToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Restart the application
            Application.Restart();
        }

        private void buttonOpenAboutUs_Click(object sender, EventArgs e)
        {
            AboutUsForm aboutUsForm = new AboutUsForm();  // Create an instance of the AboutUsForm
            aboutUsForm.ShowDialog();  // Show the AboutUsForm as a modal dialog
        }
    }
}

