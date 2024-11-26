using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace OOP.SQL
{
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
            NameField111.Text = "Введіть ім'я";
            NameField111.ForeColor = Color.Gray;
            CurnameField112.Text = "Введіть фамілію";
            CurnameField112.ForeColor = Color.Gray;
            weightField113.Text = "Введіть нік";
            weightField113.ForeColor = Color.Gray;
            weightField114.Text = "Введіть пароль";
            weightField114.ForeColor = Color.Gray;
            weightField115.Text = "Права адміна";
            weightField115.ForeColor = Color.Gray;
        }

        private void NameField111_Enter_1(object sender, EventArgs e)
        {
            if (NameField111.Text == "Введіть код водія")
                NameField111.Text = "";
            NameField111.ForeColor = Color.Black;
        }

        private void NameField111_Leave(object sender, EventArgs e)
        {
            if (NameField111.Text == "")
                NameField111.Text = "Введіть код водія";
            NameField111.ForeColor = Color.Gray;
        }

        private void CurnameField112_Enter(object sender, EventArgs e)
        {
            if (CurnameField112.Text == "Введіть код вантажу")
                CurnameField112.Text = "";
            CurnameField112.ForeColor = Color.Black;
        }

        private void CurnameField112_Leave(object sender, EventArgs e)
        {
            if (CurnameField112.Text == "")
                CurnameField112.Text = "Введіть код вантажу";
            CurnameField112.ForeColor = Color.Gray;
        }

        private void weightField113_Enter(object sender, EventArgs e)
        {
            if (weightField113.Text == "Введіть місце відправки")
                weightField113.Text = "";
            weightField113.ForeColor = Color.Black;
        }

        private void weightField113_Leave(object sender, EventArgs e)
        {
            if (weightField113.Text == "")
                weightField113.Text = "Введіть місце відправки";
            weightField113.ForeColor = Color.Gray;
        }

        private void weightField114_Enter(object sender, EventArgs e)
        {
            if (weightField114.Text == "Введіть місце прибуття")
                weightField114.Text = "";
            weightField114.ForeColor = Color.Black;
        }

        private void weightField114_Leave(object sender, EventArgs e)
        {
            if (weightField114.Text == "")
                weightField114.Text = "Введіть місце прибуття";
            weightField114.ForeColor = Color.Gray;
        }

        private void weightField115_Enter_1(object sender, EventArgs e)
        {
            if (weightField115.Text == "Введіть вагу вантажу")
                weightField115.Text = "";
            weightField115.ForeColor = Color.Black;
        }

        private void weightField115_Leave(object sender, EventArgs e)
        {
            if (weightField113.Text == "")
                weightField115.Text = "Введіть вагу вантажу";
            weightField115.ForeColor = Color.Gray;
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if (NameField111.Text == "Введіть код водія")
            {
                MessageBox.Show("Введіть код водія");
                return;
            }

            if (CurnameField112.Text == "Введіть код вантажу")
            {
                MessageBox.Show("Введіть код вантажу");
                return;
            }

            if (weightField113.Text == "Введіть місце відправки")
            {
                MessageBox.Show("Введіть місце відправки");
                return;
            }

            if (weightField114.Text == "Введіть місце прибуття")
            {
                MessageBox.Show("Введіть місце прибуття");
                return;
            }

            if (weightField114.Text == "Введіть вагу вантажу")
            {
                MessageBox.Show("Введіть вагу вантажу");
                return;
            }
            if (checkUser())
                return;

            DB db = new DB();
            SqlCommand command = new SqlCommand("INSERT INTO `Orders` (`Driver_ID`, `Cargo_ID`, `Departure_Place`, `Arrival_Place`,`Cargo_Weight`) VALUES (@IDR, @IDC, @DP, @AP, @CW)", db.GetConnection());

            command.Parameters.Add("@IDR", SqlDbType.VarChar).Value = weightField113.Text;
            command.Parameters.Add("@IDC", SqlDbType.VarChar).Value = weightField114.Text;
            command.Parameters.Add("@DP", SqlDbType.VarChar).Value = NameField111.Text;
            command.Parameters.Add("@AP", SqlDbType.VarChar).Value = CurnameField112.Text;
            command.Parameters.Add("@CW", SqlDbType.VarChar).Value = weightField115.Text;
            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                this.Hide();
                adminForm AdminForm = new adminForm();
                AdminForm.Show();
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
            SqlCommand command = new SqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.GetConnection());
            command.Parameters.Add("@uL", SqlDbType.VarChar).Value = weightField113.Text;
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminForm admForm = new adminForm();
            admForm.Show();
        }
        Point lastPoint;

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
