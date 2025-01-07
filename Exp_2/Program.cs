using System;
using System.Windows.Forms;

namespace ELearningApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set up the home page title
            this.Text = "E-Learning Platform";
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Size = new System.Drawing.Size(800, 600);

            // Create a welcome label
            Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome to E-Learning Platform!";
            lblWelcome.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold);
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new System.Drawing.Point(250, 50);
            this.Controls.Add(lblWelcome);

            // Create a description label
            Label lblDescription = new Label();
            lblDescription.Text = "Start Learning. Anytime, Anywhere!";
            lblDescription.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Italic);
            lblDescription.AutoSize = true;
            lblDescription.Location = new System.Drawing.Point(290, 100);
            this.Controls.Add(lblDescription);

            // Create a button for "View Courses"
            Button btnCourses = new Button();
            btnCourses.Text = "View Courses";
            btnCourses.Font = new System.Drawing.Font("Arial", 12);
            btnCourses.Size = new System.Drawing.Size(150, 40);
            btnCourses.Location = new System.Drawing.Point(325, 200);
            btnCourses.Click += BtnCourses_Click; // Event handler for button click
            this.Controls.Add(btnCourses);

            // Create a button for "Register"
            Button btnRegister = new Button();
            btnRegister.Text = "Register";
            btnRegister.Font = new System.Drawing.Font("Arial", 12);
            btnRegister.Size = new System.Drawing.Size(150, 40);
            btnRegister.Location = new System.Drawing.Point(325, 270);
            btnRegister.Click += BtnRegister_Click; // Event handler for button click
            this.Controls.Add(btnRegister);

            // Create a button for "Login"
            Button btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Font = new System.Drawing.Font("Arial", 12);
            btnLogin.Size = new System.Drawing.Size(150, 40);
            btnLogin.Location = new System.Drawing.Point(325, 340);
            btnLogin.Click += BtnLogin_Click; // Event handler for button click
            this.Controls.Add(btnLogin);

            // Create a picture box for logo (optional)
            PictureBox pictureBox = new PictureBox();
            pictureBox.ImageLocation = "https://via.placeholder.com/150"; // Placeholder image
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new System.Drawing.Size(150, 150);
            pictureBox.Location = new System.Drawing.Point(325, 400);
            this.Controls.Add(pictureBox);
        }

        // Event handler for "View Courses"
        private void BtnCourses_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Redirecting to Courses Page...");
        }

        // Event handler for "Register"
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Redirecting to Register Page...");
        }

        // Event handler for "Login"
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Redirecting to Login Page...");
        }
    }
}
