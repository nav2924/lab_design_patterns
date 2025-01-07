using System;
using System.Drawing;
using System.Windows.Forms;

namespace ELearningApp
{
    public class Form1 : Form
    {
        private System.Windows.Forms.Timer animationTimer; // Specify the namespace explicitly
        private Label lblWelcome;
        private int fadeStep = 5;
        private bool fadeOut = false;

        public Form1()
        {
            // Form properties for dark theme
            this.Text = "E-Learning Platform";
            this.BackColor = Color.FromArgb(32, 32, 32); // Dark gray background
            this.Size = new Size(900, 650);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Welcome Label
            lblWelcome = new Label();
            lblWelcome.Text = "Welcome to E-Learning Platform!";
            lblWelcome.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(250, 50);
            this.Controls.Add(lblWelcome);

            // Animation Timer for Fading Effect
            animationTimer = new System.Windows.Forms.Timer(); // Explicitly specify the namespace
            animationTimer.Interval = 50;
            animationTimer.Tick += AnimateText;
            animationTimer.Start();

            // Description Label
            Label lblDescription = new Label();
            lblDescription.Text = "Empower your learning experience!";
            lblDescription.Font = new Font("Segoe UI", 14, FontStyle.Italic);
            lblDescription.ForeColor = Color.Gray;
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(300, 100);
            this.Controls.Add(lblDescription);

            // Flat buttons
            AddFlatButton("View Courses", new Point(325, 200), BtnCourses_Click);
            AddFlatButton("Register", new Point(325, 270), BtnRegister_Click);
            AddFlatButton("Login", new Point(325, 340), BtnLogin_Click);

            // Optional Image
            PictureBox pictureBox = new PictureBox();
            pictureBox.ImageLocation = "./diagram.png"; // Replace with your logo/image URL
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(250, 170);
            pictureBox.Location = new Point(300, 420);
            this.Controls.Add(pictureBox);
        }

        private void AddFlatButton(string text, Point location, EventHandler onClickHandler)
        {
            Button button = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 12),
                Size = new Size(200, 50),
                Location = location,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(45, 45, 45), // Darker gray
                ForeColor = Color.White
            };
            button.FlatAppearance.BorderSize = 0; // No border for flat design
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70); // Slightly lighter gray on hover
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 100, 100); // Light gray on click
            button.Click += onClickHandler;
            this.Controls.Add(button);
        }

        // Animation Logic for Fading Effect
        private void AnimateText(object sender, EventArgs e)
        {
            Color currentColor = lblWelcome.ForeColor;
            int alpha = currentColor.A;

            if (fadeOut)
            {
                alpha -= fadeStep;
                if (alpha <= 0)
                {
                    alpha = 0;
                    fadeOut = false;
                }
            }
            else
            {
                alpha += fadeStep;
                if (alpha >= 255)
                {
                    alpha = 255;
                    fadeOut = true;
                }
            }

            lblWelcome.ForeColor = Color.FromArgb(alpha, currentColor.R, currentColor.G, currentColor.B);
        }

        // Button Click Event Handlers
        private void BtnCourses_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Redirecting to Courses Page...");
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Redirecting to Register Page...");
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Redirecting to Login Page...");
        }

        // Entry Point
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
