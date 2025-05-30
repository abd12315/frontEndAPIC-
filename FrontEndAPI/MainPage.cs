

//Backup Code ver 1.2
using System;
using System.Collections.Generic; //Code declaration...
using System.Drawing;
using System.Drawing.Drawing2D; //Image box for emotions...
using System.IO;
using System.Text;
using System.Windows.Forms; //Simple window without any components...
using FrontEndAPI; //referencing submit button

namespace FrontEndAPI //To connect it with overall program/project...
{
    public partial class MainPage : Form
    {
        private bool drawContents = true; // Flag to control drawing
        private List<string> imagePaths = new List<string>
        {
            "data/images/Angry.png",
            "data/images/Happy.png",
            "data/images/sleepy.png",
            "data/images/scared.png",
            "data/images/Cool.png",
            "data/images/sad.png"
        }; // List to store predefined image paths
        private string logFilePath = "imageLog.txt"; // Path to the log file
        private PictureBox marqueePictureBox; // PictureBox for the marquee
        private Label marqueeLabel; // Label for the marquee message
        private System.Windows.Forms.Timer marqueeTimer; // Timer for the marquee
        private int marqueeSpeed = 17; // Speed of the marquee
        private int marqueeThreshold; // Threshold for the marquee
        private TextBox feedbackTextBox; // TextBox for the feedback
        private CustomMonthCalendar customMonthCalendar; // CustomMonthCalendar for displaying the current month's dates
        private Button submitButton; // Submit button for the feedback
        private ToolTip toolTip; // ToolTip for displaying the image name
        private string currentImagePath; // Store the current image path

        public MainPage()
        {
            InitializeComponent();
            this.BackColor = Color.SkyBlue; // Set background color to sky blue
            this.MinimumSize = new Size(800, 600); // Set minimum size to 800x600
            this.MaximizeBox = false; // Disable maximize button
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Disable resizing while keeping minimum size

            // Initialize the ToolTip
            toolTip = new ToolTip
            {
                IsBalloon = true,
                ToolTipIcon = ToolTipIcon.Info,
                ToolTipTitle = "Image Information"
            };
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!drawContents)
            {
                return; // Skip drawing if the flag is false
            }

            // Define the margin
            int margin = 130;

            // Define the rectangle dimensions
            int rectWidth = this.ClientSize.Width - 2 * margin;
            int rectHeight = this.ClientSize.Height - 2 * margin;

            // Define the rectangle position
            int rectX = margin;
            int rectY = margin;

            // Create a semi-transparent light grey brush
            using (Brush brush = new SolidBrush(Color.FromArgb(128, 211, 211, 211)))
            {
                // Draw the rectangle
                e.Graphics.FillRectangle(brush, rectX, rectY, rectWidth, rectHeight);
            }

            // Define the text to be drawn
            string text = "How are you feeling Today";

            // Define the font and brush for the text
            using (Font font = new Font("Arial", 16, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.Orange)) // Change text color to orange
            {
                // Measure the size of the text
                SizeF textSize = e.Graphics.MeasureString(text, font);

                // Calculate the position to center the text within the rectangle
                float textX = rectX + (rectWidth - textSize.Width) / 2;
                float textY = rectY + 20; // Position the text at the top with some padding

                // Draw the text
                e.Graphics.DrawString(text, font, textBrush, textX, textY);
            }

            // Define the size and margin for the image boxes
            int boxMargin = 20;
            int rowMargin = 40; // Additional margin between rows
            int availableWidth = rectWidth - 4 * boxMargin;
            int availableHeight = rectHeight - 100; // Subtract space for the heading and padding
            int boxSize = Math.Min(availableWidth / 3, availableHeight / 2) - 20; // Calculate dynamic box size and reduce by 20px

            // Set minimum and maximum box size
            int minBoxSize = 30; // Reduced by 20px
            int maxBoxSize = 80; // Reduced by 20px
            boxSize = Math.Max(minBoxSize, Math.Min(boxSize, maxBoxSize));

            // Calculate the starting position for the image boxes
            int startY = rectY + 80; // Position the boxes below the text with some padding

            // Draw the six image boxes in a grid pattern
            for (int i = 0; i < 6; i++)
            {
                int row = i / 3;
                int col = i % 3;

                int boxX;
                if (col == 0)
                {
                    boxX = rectX + boxMargin; // Align to the left
                }
                else if (col == 1)
                {
                    boxX = rectX + (rectWidth - boxSize) / 2; // Align to the center
                }
                else
                {
                    boxX = rectX + rectWidth - boxSize - boxMargin; // Align to the right
                }

                int boxY = startY + row * (boxSize + boxMargin) + (row == 1 ? rowMargin : 0); // Add additional margin for the second row

                // Draw the image if the path is available
                if (i < imagePaths.Count && !string.IsNullOrEmpty(imagePaths[i]))
                {
                    using (Image image = Image.FromFile(imagePaths[i]))
                    {
                        e.Graphics.DrawImage(image, boxX, boxY, boxSize, boxSize);
                    }
                }
                else
                {
                    // Create a placeholder brush for the image boxes
                    using (Brush boxBrush = new SolidBrush(Color.FromArgb(128, 169, 169, 169)))
                    {
                        // Create a rounded rectangle path
                        using (GraphicsPath path = new GraphicsPath())
                        {
                            int radius = 10; // Radius for rounded corners
                            path.AddArc(boxX, boxY, radius, radius, 180, 90);
                            path.AddArc(boxX + boxSize - radius, boxY, radius, radius, 270, 90);
                            path.AddArc(boxX + boxSize - radius, boxY + boxSize - radius, radius, radius, 0, 90);
                            path.AddArc(boxX, boxY + boxSize - radius, radius, radius, 90, 90);
                            path.CloseFigure();

                            // Fill the rounded rectangle
                            e.Graphics.FillPath(boxBrush, path);
                        }
                    }
                }

                // Add a click detection region for each image box
                Rectangle boxBounds = new Rectangle(boxX, boxY, boxSize, boxSize);
                this.Controls.Add(CreateClickablePictureBox(boxBounds, i));
            }
        }

        private PictureBox CreateClickablePictureBox(Rectangle bounds, int index)
        {
            PictureBox pictureBox = new PictureBox
            {
                Bounds = bounds,
                BackColor = Color.Transparent,
                Tag = index
            };

            pictureBox.MouseClick += (sender, e) =>
            {
                // Store the clicked image path in the log file
                string clickedImagePath = imagePaths[index];
                File.WriteAllText(logFilePath, clickedImagePath, Encoding.Unicode);

                // Store the current image path
                currentImagePath = clickedImagePath;

                // Clear the form and maximize
                drawContents = false;
                this.Controls.Clear();
                this.Refresh();

                // Set the form to windowed fullscreen mode
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Maximized;

                // Trigger event to decode the output of the image and show it on the top right of the screen
                ShowImageOnTopRight();
            };

            return pictureBox;
        }
        private void ShowImageOnTopRight()
        {
            try
            {
                // Read the image path from the log file
                if (!File.Exists(logFilePath))
                {
                    MessageBox.Show("Log file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string imagePath = File.ReadAllText(logFilePath, Encoding.Unicode);

                if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                {
                    MessageBox.Show("Image file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a PictureBox to display the image
                marqueePictureBox = new PictureBox
                {
                    Image = Image.FromFile(imagePath),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(100, 100), // Set the size of the PictureBox
                    Location = new Point(this.ClientSize.Width - 110, 10), // Initial position of the PictureBox
                    BackColor = Color.Transparent
                };

                // Add the PictureBox to the form
                this.Controls.Add(marqueePictureBox);

                // Create a Label for the marquee message
                marqueeLabel = new Label
                {
                    Text = "You're Feeling:",
                    Font = new Font("Proxima Nova", 35, FontStyle.Bold), // Increase size and set style to bold
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent,
                    AutoSize = true
                };

                // Set the initial position of the Label (off-screen to the left)
                marqueeLabel.Location = new Point(-marqueeLabel.Width, 10);

                // Add the Label to the form
                this.Controls.Add(marqueeLabel);

                // Set the threshold for the marquee
                marqueeThreshold = this.ClientSize.Width - 110 - marqueeLabel.Width;

                // Initialize and start the marquee timer
                marqueeTimer = new System.Windows.Forms.Timer();
                marqueeTimer.Interval = 30; // Set the interval for the timer
                marqueeTimer.Tick += MarqueeTimer_Tick;
                marqueeTimer.Start();

                // Add heading text and text area
                AddHeadingAndTextArea();

                // Read the most recent .doc file in the directory
                string docDirectoryPath = "doc/response/";
                string mostRecentDocFilePath = GetMostRecentDocFile(docDirectoryPath);

                if (string.IsNullOrEmpty(mostRecentDocFilePath))
                {
                    MessageBox.Show("No .doc files found in the specified directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetMostRecentDocFile(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);
            var mostRecentFile = directoryInfo.GetFiles("*.doc")
                                              .OrderByDescending(f => f.LastWriteTime)
                                              .FirstOrDefault();
            return mostRecentFile?.FullName;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the feedback text
                string feedbackText = feedbackTextBox.Text;

                // Get the current username (replace with actual logic to get the username)
                string username = "admin"; // Example username

                // Save the feedback to a .doc file
                Submit.SaveToDoc(feedbackText, username, currentImagePath);

                MessageBox.Show("Feedback saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //// Refresh the MainPage
                //Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void AddHeadingAndTextArea()
        {
            try
            {
                // Add heading text
                Label headingLabel = new Label
                {
                    Text = "What Made you Feel This Way?",
                    Font = new Font("Proxima Nova", 30, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    AutoSize = true,
                    Location = new Point(20, 150) // Position the heading with some space from the left and below the marquee
                };

                // Add the heading label to the form
                this.Controls.Add(headingLabel);

                // Create a Panel for the feedback text area
                Panel feedbackPanel = new Panel

                {
                    Size = new Size(this.ClientSize.Width / 2 - 40, 200), // Adjust panel height to match the smaller text area
                    Location = new Point(20, 200), // Position the panel
                    BackColor = Color.SkyBlue,
                    Padding = new Padding(10) // Add padding
                };

                // Create a TextBox for the feedback
                feedbackTextBox = new TextBox
                {
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    BackColor = Color.White, // Change background color to white
                    ForeColor = Color.Black, // Change text color to black
                    BorderStyle = BorderStyle.None,
                    Font = new Font("Arial", 12)
                };

                // Add the TextBox to the Panel
                feedbackPanel.Controls.Add(feedbackTextBox);

                // Add the Panel to the form
                this.Controls.Add(feedbackPanel);
                // Create a submit button
                submitButton = new Button
                {
                    Text = "Submit",
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    BackColor = Color.Orange,
                    ForeColor = Color.White,
                    Size = new Size(100, 40),
                    Location = new Point(feedbackPanel.Right - 110, feedbackPanel.Bottom + 10) // Position the button below the text area
                };

                // Attach the Click event handler
                submitButton.Click += SubmitButton_Click;

                // Add the submit button to the form
                this.Controls.Add(submitButton);





                // Create a custom MonthCalendar for the current month's dates
                customMonthCalendar = new CustomMonthCalendar
                {
                    Location = new Point(this.ClientSize.Width - 250, 200), // Position the calendar to the right of the feedback panel
                    Size = new Size(220, 200), // Set the size of the custom calendar
                    BackColor = Color.SkyBlue, // Change background color to match the form's background color
                    ForeColor = Color.White,
                    BorderColor = Color.White
                };

                // Add the custom MonthCalendar to the form
                this.Controls.Add(customMonthCalendar);

                // Make the edges of the panel transparent
                feedbackPanel.Paint += (s, pe) =>
                {
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        int radius = 10; // Radius for rounded corners
                        path.AddArc(0, 0, radius, radius, 180, 90);
                        path.AddArc(feedbackPanel.Width - radius, 0, radius, radius, 270, 90);
                        path.AddArc(feedbackPanel.Width - radius, feedbackPanel.Height - radius, radius, radius, 0, 90);
                        path.AddArc(0, feedbackPanel.Height - radius, radius, radius, 90, 90);
                        path.CloseFigure();

                        feedbackPanel.Region = new Region(path);
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MarqueeTimer_Tick(object sender, EventArgs e)
        {
            // Move the Label to the right
            marqueeLabel.Left += marqueeSpeed;

            // Stop the marquee when it reaches the threshold
            if (marqueeLabel.Left >= marqueeThreshold)
            {
                marqueeTimer.Stop();
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }
    }

    public class CustomMonthCalendar : Control
    {
        public Color BorderColor { get; set; } = Color.White;
        private int hoveredDay = -1;
        private System.Windows.Forms.Timer hoverTimer;
        private ToolTip toolTip;

        public CustomMonthCalendar()
        {
            this.DoubleBuffered = true;
            this.MouseMove += CustomMonthCalendar_MouseMove;
            this.MouseLeave += CustomMonthCalendar_MouseLeave;
            this.MouseClick += CustomMonthCalendar_MouseClick;

            hoverTimer = new System.Windows.Forms.Timer();
            hoverTimer.Interval = 50; // Adjust the interval for smoother animation
            hoverTimer.Tick += (s, e) => Invalidate();
            hoverTimer.Start();

            toolTip = new ToolTip
            {
                IsBalloon = true,
                ToolTipIcon = ToolTipIcon.Info,
                ToolTipTitle = "Date Information"
            };
        }

        private void CustomMonthCalendar_MouseMove(object sender, MouseEventArgs e)
        {
            int cellWidth = Width / 7;
            int cellHeight = Height / 7;
            int row = (e.Y / cellHeight) - 1;
            int col = e.X / cellWidth;
            int day = col + row * 7 - (int)new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).DayOfWeek + 1;

            if (day != hoveredDay && day > 0 && day <= DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month))
            {
                hoveredDay = day;
                string feeling = GetFeelingForDate(new DateTime(DateTime.Today.Year, DateTime.Today.Month, day));
                toolTip.SetToolTip(this, $"You were feeling {feeling} on {new DateTime(DateTime.Today.Year, DateTime.Today.Month, day).ToShortDateString()}");
                Invalidate();
            }
        }

        private void CustomMonthCalendar_MouseLeave(object sender, EventArgs e)
        {
            hoveredDay = -1;
            toolTip.RemoveAll();
            Invalidate();
        }

        private void CustomMonthCalendar_MouseClick(object sender, MouseEventArgs e)
        {
            int cellWidth = Width / 7;
            int cellHeight = Height / 7;
            int row = (e.Y / cellHeight) - 1;
            int col = e.X / cellWidth;
            int day = col + row * 7 - (int)new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).DayOfWeek + 1;

            if (day > 0 && day <= DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month))
            {
                string feeling = GetFeelingForDate(new DateTime(DateTime.Today.Year, DateTime.Today.Month, day));
                MessageBox.Show($"You were feeling {feeling} on {new DateTime(DateTime.Today.Year, DateTime.Today.Month, day).ToShortDateString()}", "Day Clicked", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private string GetMostRecentDocFile(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);
            var mostRecentFile = directoryInfo.GetFiles("*.doc")
                                              .OrderByDescending(f => f.LastWriteTime)
                                              .FirstOrDefault();
            return mostRecentFile?.FullName;
        }
        private string GetFeelingForDate(DateTime date)
        {
            try
            {
                string docDirectoryPath = "doc/response/";
                string mostRecentDocFilePath = GetMostRecentDocFile(docDirectoryPath);

                if (string.IsNullOrEmpty(mostRecentDocFilePath))
                {
                    return "No feedback";
                }

                // Add logic to process the file or return a specific message
                return "Feedback found";  // Example return statement
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }




        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Set the background color
            e.Graphics.Clear(BackColor);

            // Draw the border
            using (Pen pen = new Pen(BorderColor, 2))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }

            // Draw the calendar
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

            using (Font font = new Font("Arial", 10))
            using (Brush textBrush = new SolidBrush(ForeColor))
            using (Brush hoverBrush = new SolidBrush(Color.FromArgb(128, Color.White)))
            {
                int cellWidth = Width / 7;
                int cellHeight = Height / 7;

                // Draw the day names
                string[] dayNames = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
                for (int i = 0; i < 7; i++)
                {
                    e.Graphics.DrawString(dayNames[i], font, textBrush, i * cellWidth, 0);
                }

                // Draw the days
                int dayOfWeek = (int)firstDayOfMonth.DayOfWeek;
                for (int day = 1; day <= daysInMonth; day++)
                {
                    int x = (dayOfWeek % 7) * cellWidth;
                    int y = (dayOfWeek / 7 + 1) * cellHeight;

                    if (day == hoveredDay)
                    {
                        e.Graphics.FillRectangle(hoverBrush, x, y, cellWidth, cellHeight);
                    }

                    e.Graphics.DrawString(day.ToString(), font, textBrush, x, y);
                    dayOfWeek++;
                }
            }
        }
    }
}



