using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace OOP.SQL
{
    public partial class AddCostamers : Form
    {
        public AddCostamers()
        {
            InitializeComponent();
           
            NameField1.Text = "Ім'я";
            NameField1.ForeColor = Color.Gray;
            CurnameField1.Text = "Фамілія";
            CurnameField1.ForeColor = Color.Gray;
            weightField1.Text = "Номер місця";
            weightField1.ForeColor = Color.Gray;
        }

        Point lastPoint;



        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminForm admForm = new adminForm();
            admForm.Show();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if (NameField1.Text == "Ім'я")
            {
                MessageBox.Show("Ім'я");
                return;
            }

            if (CurnameField1.Text == "Фамілія")
            {
                MessageBox.Show("Фамілія");
                return;
            }

            if (weightField1.Text == "Номер місця")
            {
                MessageBox.Show("Номер місця");
                return;
            }

            DB db = new DB();
            SqlCommand command = new SqlCommand("INSERT INTO `Customers` (`Full_Name`, `Phone`) VALUES (@IDC, @Fname, @num)", db.GetConnection());

            command.Parameters.Add("@IDC", SqlDbType.VarChar).Value = NameField1.Text;
            command.Parameters.Add("@Fname", SqlDbType.VarChar).Value = CurnameField1.Text;
            command.Parameters.Add("@num", SqlDbType.VarChar).Value = weightField1.Text;
            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                this.Hide();
                adminForm AdminForm = new adminForm();
                AdminForm.Show();
            }
            else
                MessageBox.Show("Глядача не було додано");

            db.closeConnection();

        }



        private void NameField1_Enter(object sender, EventArgs e)
        {
            if (NameField1.Text == "Ім'я")
                NameField1.Text = "";
            NameField1.ForeColor = Color.Black;
        }

        private void NameField1_Leave(object sender, EventArgs e)
        {
            if (NameField1.Text == "")
                NameField1.Text = "Ім'я";
            NameField1.ForeColor = Color.Gray;
        }
        private void CurnameField1_Enter(object sender, EventArgs e)
        {
            if (CurnameField1.Text == "Фамілія")
                CurnameField1.Text = "";
            CurnameField1.ForeColor = Color.Black;
        }

        private void CurnameField1_Leave(object sender, EventArgs e)
        {
            if (CurnameField1.Text == "")
                CurnameField1.Text = "Фамілія";
            CurnameField1.ForeColor = Color.Gray;
        }
        private void weightField1_Enter(object sender, EventArgs e)
        {
            if (weightField1.Text == "Номер місця")
                weightField1.Text = "";
            weightField1.ForeColor = Color.Black;
        }

        private void weightField1_Leave(object sender, EventArgs e)
        {
            if (weightField1.Text == "")
                weightField1.Text = "Номер місця";
            weightField1.ForeColor = Color.Gray;
        }

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
