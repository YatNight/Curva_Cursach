using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
namespace OOP.SQL
{
    public partial class AddCargo : Form
    {
        public AddCargo()
        {
            InitializeComponent();
            NameField1.Text = "Введіть назву вантажу";
            NameField1.ForeColor = Color.Gray;
            CurnameField1.Text = "Введіть вагу вантажу";
            CurnameField1.ForeColor = Color.Gray;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminForm admForm = new adminForm();
            admForm.Show();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if (NameField1.Text == "Введіть назву вантажу")
            {
                MessageBox.Show("Введіть назву вантажу");
                return;
            }

            if (weightField1.Text == "Введіть вагу вантажу")
            {
                MessageBox.Show("Введіть вагу вантажу");
                return;
            }

            DB db = new DB();

            try
            {
                // SQL-запит для вставки нового запису з автоматичним генеруванням Cargo_ID
                SqlCommand command = new SqlCommand(
                    "INSERT INTO `Cargo` (`Name`, `Unit_Weight`) VALUES (@name, @unitWeight)",
                    db.GetConnection()
                );

                // Параметри для назви та ваги вантажу
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = NameField1.Text;

                if (decimal.TryParse(weightField1.Text, out decimal unitWeight))
                {
                    command.Parameters.Add("@unitWeight", SqlDbType.Decimal).Value = unitWeight;
                }
                else
                {
                    MessageBox.Show("Некоректне значення для ваги. Введіть числове значення.");
                    return;
                }

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Вантаж успішно додано.");
                    this.Hide();
                    adminForm AdminForm = new adminForm();
                    AdminForm.Show();
                }
                else
                {
                    MessageBox.Show("Не вдалося додати вантаж.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при додаванні вантажу: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
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
            if (weightField1.Text == "Досвід")
                weightField1.Text = "";
            weightField1.ForeColor = Color.Black;
        }

        private void weightField1_Leave(object sender, EventArgs e)
        {
            if (weightField1.Text == "")
                weightField1.Text = "Досвід";
            weightField1.ForeColor = Color.Gray;
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
