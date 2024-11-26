using System.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace OOP.SQL
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 64);
            userLoginField.Text = "Введіть нік";
            userLoginField.ForeColor = Color.Gray;
            userPassField.Text = "Введіть пароль";
            userPassField.ForeColor = Color.Gray;
            loginField.Text = "Введіть нік";
            loginField.ForeColor = Color.Gray;
            passField.Text = "Введіть пароль";
        }



        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        Point lastPoint;
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }



        private void signIn1_MouseEnter(object sender, EventArgs e)
        {
            signIn1.ForeColor = Color.Green;
        }

        private void signIn1_MouseLeave(object sender, EventArgs e)
        {
            signIn1.ForeColor = Color.Green;
        }

        private void userLoginField_Enter(object sender, EventArgs e)
        {
            if (userLoginField.Text == "Введіть нік")
                userLoginField.Text = "";
            userLoginField.ForeColor = Color.Black;
        }

        private void userLoginField_Leave(object sender, EventArgs e)
        {
            if (userLoginField.Text == "")
                userLoginField.Text = "Введіть нік";
            userLoginField.ForeColor = Color.Gray;
        }

        private void UserPassField_Enter(object sender, EventArgs e)
        {
            if (userPassField.Text == "Введіть пароль")
                userPassField.Text = "";
            userPassField.ForeColor = Color.Black;
        }

        private void UserPassField_Leave(object sender, EventArgs e)
        {
            if (userPassField.Text == "")
                userPassField.Text = "Введіть пароль";
            userPassField.ForeColor = Color.Gray;
        }



        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Введіть нік")
                loginField.Text = "";
            loginField.ForeColor = Color.Black;
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (loginField.Text == "")
                loginField.Text = "Введіть нік";
            loginField.ForeColor = Color.Gray;
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Введіть пароль")
                passField.Text = "";
            passField.ForeColor = Color.Black;
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "")
                passField.Text = "Введіть пароль";
            passField.ForeColor = Color.Gray;
        }

        private void signIn1_Click(object sender, EventArgs e)
        {

            String loginUser = loginField.Text;
            String passUser = passField.Text;

            DB db = new DB();
            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM users WHERE login = @uL AND pass = @uP", db.GetConnection());
            command.Parameters.Add("@uL", SqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", SqlDbType.VarChar).Value = passUser;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                string isAdmin = table.Rows[0]["admin"].ToString();
                if (isAdmin == "1")
                {
                    this.Hide();
                    adminForm adminForm = new adminForm();
                    adminForm.Show();
                }
                else
                {
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
            }
            else
                MessageBox.Show("Користувач не існує або введений не правильний пароль");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
         

            if (userLoginField.Text == "Введіть нік")
            {
                MessageBox.Show("Введіть нік");
                return;
            }

            if (userPassField.Text == "Введіть пароль")
            {
                MessageBox.Show("Введіть пароль");
                return;
            }

            if (checkUser())
                return;

            DB db = new DB();
            SqlCommand command = new SqlCommand("INSERT INTO users (login, pass,admin) VALUES (@login, @pass, @admin)", db.GetConnection());

            command.Parameters.Add("@login", SqlDbType.VarChar).Value = userLoginField.Text;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = userPassField.Text;
            command.Parameters.Add("@admin", SqlDbType.VarChar).Value = "0";
            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
                MessageBox.Show("Акаунт не було створено");

            db.closeConnection();

        }

        public Boolean checkUser()
        {
            DB db = new DB();
            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM users WHERE login = @uL", db.GetConnection());
            command.Parameters.Add("@uL", SqlDbType.VarChar).Value = userLoginField.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Цей нік вже використовується");
                return true;
            }
            else
                return false;
        }

        private void closeButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}