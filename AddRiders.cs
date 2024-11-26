using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP.SQL
{
    public partial class AddRiders : Form
    {
        public AddRiders()
        {
            InitializeComponent();
            NameField1.Text = "Введіть ім'я";
            NameField1.ForeColor = Color.Gray;
            CurnameField1.Text = "Введіть фамілію";
            CurnameField1.ForeColor = Color.Gray;
            weightField1.Text = "Введіть свою вагу";
            weightField1.ForeColor = Color.Gray;
        }

        private void NameField1_Enter(object sender, EventArgs e)
        {
            if (NameField1.Text == "Введіть повне ім'я водія")
                NameField1.Text = "";
            NameField1.ForeColor = Color.Black;
        }

        private void NameField1_Leave(object sender, EventArgs e)
        {
            if (NameField1.Text == "")
                NameField1.Text = "Введіть повне ім'я водія";
            NameField1.ForeColor = Color.Gray;
        }

        private void CurnameField1_Enter(object sender, EventArgs e)
        {
            if (CurnameField1.Text == "Введіть досвід водія")
                CurnameField1.Text = "";
            CurnameField1.ForeColor = Color.Black;
        }

        private void CurnameField1_Leave(object sender, EventArgs e)
        {
            if (CurnameField1.Text == "")
                CurnameField1.Text = "Введіть досвід водія";
            NameField1.ForeColor = Color.Gray;
        }

        private void weightField1_Enter(object sender, EventArgs e)
        {
            if (weightField1.Text == "Введіть марку авто водія")
                weightField1.Text = "";
            weightField1.ForeColor = Color.Black;
        }

        private void weightField1_Leave(object sender, EventArgs e)
        {
            if (weightField1.Text == "")
                weightField1.Text = "Введіть марку авто водія";
            NameField1.ForeColor = Color.Gray;
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if (NameField1.Text == "Введіть повне ім'я водія")
            {
                MessageBox.Show("Введіть повне ім'я водія");
                return;
            }

            if (CurnameField1.Text == "Введіть досвід водія")
            {
                MessageBox.Show("Введіть досвід водія");
                return;
            }

            if (weightField1.Text == "Введіть марку авто водія")
            {
                MessageBox.Show("Введіть марку авто водія");
                return;
            }
            if (guna2TextBox1.Text == "Введіть код авто")
            {
                MessageBox.Show("Введіть код авто");
                return;
            }
            DB db = new DB();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("INSERT INTO `Drivers` (`Driver_ID`, `Full_Name`, `Experience`, `Vehicle_Brand`, `Vehicle_Code`) VALUES (@IDR, @name, @exp, @brand, @codCar)", db.GetConnection());

            command.Parameters.Add("@name", SqlDbType.VarChar).Value = NameField1.Text;
            command.Parameters.Add("@exp", SqlDbType.VarChar).Value = CurnameField1.Text;
            command.Parameters.Add("@brand", SqlDbType.VarChar).Value = weightField1.Text;
            command.Parameters.Add("@codCar", SqlDbType.VarChar).Value = guna2TextBox1.Text;
            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                this.Hide();
                    this.Hide();
                    adminForm adminForm = new adminForm();
                    adminForm.Show();
            }
            else
            {
                MessageBox.Show("Учасника не було додано");
            }

            db.closeConnection();
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

        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {
            if (weightField1.Text == "Введіть код авто")
                weightField1.Text = "";
            weightField1.ForeColor = Color.Black;
        }

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (weightField1.Text == "")
                weightField1.Text = "Введіть код авто";
            NameField1.ForeColor = Color.Gray;
        }
    }
}
