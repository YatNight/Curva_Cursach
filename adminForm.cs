using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace OOP.SQL
{
    public partial class adminForm : Form
    {
        private System.Windows.Forms.Timer timer;
        public adminForm()
        {

            InitializeComponent();

            // Ініціалізація таймера
            timer = new System.Windows.Forms.Timer
            {
                Interval = 5000 // Час в мілісекундах (тут кожні 5 секунд)
            };
            timer.Tick += new EventHandler(timer_Tick);
            timer.Tick += new EventHandler(timer_Tick1);
            timer.Tick += new EventHandler(timer_Tick2);
            timer.Tick += new EventHandler(timer_Tick3);
            timer.Start();
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel3.AutoScroll = true;
            flowLayoutPanel4.AutoScroll = true;
            flowLayoutPanel5.AutoScroll = true;

            IDTextBox1.Text = "ID";
            IDTextBox1.ForeColor = Color.Gray;
            IDTextBox2.Text = "ID";
            IDTextBox2.ForeColor = Color.Gray;
            IDTextBox3.Text = "ID";
            IDTextBox3.ForeColor = Color.Gray;
            IDTextBox4.Text = "ID";
            IDTextBox4.ForeColor = Color.Gray;

            guna31.Text = "ID Замовника";
            guna31.ForeColor = Color.Gray;
            guna32.Text = "ID Водія";
            guna32.ForeColor = Color.Gray;
            guna33.Text = "ID Вантажу";
            guna33.ForeColor = Color.Gray;
            guna34.Text = "Прибуття";
            guna34.ForeColor = Color.Gray;
            guna35.Text = "Відбуття";
            guna35.ForeColor = Color.Gray;
            guna36.Text = "Вага";
            guna36.ForeColor = Color.Gray;

            guna41.Text = "ID Водія";
            guna41.ForeColor = Color.Gray;
            guna42.Text = "Повне Ім'я";
            guna42.ForeColor = Color.Gray;
            guna43.Text = "Досвід";
            guna43.ForeColor = Color.Gray;
            guna44.Text = "Марка авто";
            guna44.ForeColor = Color.Gray;
            guna45.Text = "Код авто";
            guna45.ForeColor = Color.Gray;

            guna51.Text = "ID Замовника";
            guna51.ForeColor = Color.Gray;
            guna52.Text = "Повне Ім'я";
            guna52.ForeColor = Color.Gray;
            guna53.Text = "Телефон";
            guna53.ForeColor = Color.Gray;

            guna61.Text = "ID Вантажу";
            guna61.ForeColor = Color.Gray;
            guna62.Text = "Назва";
            guna62.ForeColor = Color.Gray;
            guna63.Text = "Вага одиниці";
            guna63.ForeColor = Color.Gray;
        }


        private void IDTextBox_Enter(object sender, EventArgs e)
        {
            if (IDTextBox1.Text == "ID")
                IDTextBox1.Text = "";
            IDTextBox1.ForeColor = Color.Black;
        }
        private void IDTextBox_Leave(object sender, EventArgs e)
        {
            if (IDTextBox1.Text == "")
                IDTextBox1.Text = "ID";
            IDTextBox1.ForeColor = Color.Gray;
        }
        private void guna2TextBox10_Enter(object sender, EventArgs e)
        {
            if (IDTextBox4.Text == "ID")
                IDTextBox4.Text = "";
            IDTextBox4.ForeColor = Color.Black;
        }
        private void guna2TextBox10_Leave(object sender, EventArgs e)
        {
            if (IDTextBox4.Text == "")
                IDTextBox4.Text = "ID";
            IDTextBox4.ForeColor = Color.Gray;
        }
        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {
            if (IDTextBox2.Text == "ID")
                IDTextBox2.Text = "";
            IDTextBox2.ForeColor = Color.Black;
        }
        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (IDTextBox2.Text == "")
                IDTextBox2.Text = "ID";
            IDTextBox2.ForeColor = Color.Gray;
        }
        private void guna2TextBox9_Enter(object sender, EventArgs e)
        {
            if (IDTextBox3.Text == "ID")
                IDTextBox3.Text = "";
            IDTextBox3.ForeColor = Color.Black;
        }
        private void guna2TextBox9_Leave(object sender, EventArgs e)
        {
            if (IDTextBox3.Text == "")
                IDTextBox3.Text = "ID";
            IDTextBox3.ForeColor = Color.Gray;
        }





        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateListFromServer();
        }
        private void timer_Tick1(object sender, EventArgs e)
        {
            UpdateListFromServer1();
        }
        private void timer_Tick2(object sender, EventArgs e)
        {
            UpdateListFromServer2();
        }
        private void timer_Tick3(object sender, EventArgs e)
        {
            UpdateListFromServer3();
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        private void UpdateListFromServer()
        {
            DB db = new DB();
            DataTable newTable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM users", db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(newTable);
            flowLayoutPanel1.Controls.Clear();
            if (newTable.Rows.Count > 0)
            {
                foreach (DataRow row in newTable.Rows)
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    panel.AutoSize = true;

                    TextBox userIDTextBox = new TextBox
                    {
                        Text = row["id"].ToString(),
                        Name = "id",
                        Width = 20,
                        Enabled = false
                    };
                    panel.Controls.Add(userIDTextBox);
                    TextBox userNameTextBox = new TextBox
                    {
                        Text = row["name"].ToString(),
                        Name = "userName",
                        Width = 110,
                        Enabled = false
                    };
                    panel.Controls.Add(userNameTextBox);

                    TextBox userSurTextBox = new TextBox
                    {
                        Text = row["surname"].ToString(),
                        Name = "userSur",
                        Width = 110,
                        Enabled = false
                    };
                    panel.Controls.Add(userSurTextBox);

                    TextBox userLoginTextBox = new TextBox
                    {
                        Text = row["login"].ToString(),
                        Name = "userLogin",
                        Width = 110,
                        Enabled = false
                    };
                    panel.Controls.Add(userLoginTextBox);

                    TextBox userPassTextBox = new TextBox
                    {
                        Text = row["pass"].ToString(),
                        Name = "userPass",
                        Width = 110,
                        Enabled = false
                    };
                    panel.Controls.Add(userPassTextBox);

                    TextBox userAdminTextBox = new TextBox
                    {
                        Text = row["admin"].ToString(),
                        Name = "admin",
                        Width = 110,
                        Enabled = false
                    };
                    panel.Controls.Add(userAdminTextBox);

                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
        }
        private void UpdateListFromServer1()
        {
            DB db = new DB();
            DataTable newTable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM Orders", db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(newTable);
            flowLayoutPanel2.Controls.Clear();
            if (newTable.Rows.Count > 0)
            {
                foreach (DataRow row in newTable.Rows)
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    panel.AutoSize = true;

                    TextBox participantIDTextBox = new TextBox
                    {
                        Text = row["ID"].ToString(),
                        Name = "ID",
                        Width = 40,
                        Enabled = false
                    };
                    panel.Controls.Add(participantIDTextBox);
                    TextBox participantNameTextBox = new TextBox
                    {


                        Text = row["name"].ToString(),
                        Name = "name",
                        Width = 225,
                        Enabled = false
                    };
                    panel.Controls.Add(participantNameTextBox);

                    TextBox participantSurTextBox = new TextBox
                    {
                        Text = row["surname"].ToString(),
                        Name = "surname",
                        Width = 200,
                        Enabled = false
                    };
                    panel.Controls.Add(participantSurTextBox);

                    TextBox participantWeightTextBox = new TextBox
                    {
                        Text = row["weight"].ToString(),
                        Name = "weight",
                        Width = 75,
                        Enabled = false
                    };
                    panel.Controls.Add(participantWeightTextBox);


                    flowLayoutPanel2.Controls.Add(panel);
                }
            }
        }
        private void UpdateListFromServer2()
        {
            DB db = new DB();
            DataTable newTable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM Drivers", db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(newTable);
            flowLayoutPanel4.Controls.Clear();
            if (newTable.Rows.Count > 0)
            {
                foreach (DataRow row in newTable.Rows)
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    panel.AutoSize = true;

                    TextBox viewersIDTextBox = new TextBox
                    {
                        Text = row["ID"].ToString(),
                        Name = "ID",
                        Width = 40,
                        Enabled = false
                    };
                    panel.Controls.Add(viewersIDTextBox);
                    TextBox viewersNameTextBox = new TextBox
                    {
                        Text = row["name"].ToString(),
                        Name = "name",
                        Width = 190,
                        Enabled = false
                    };
                    panel.Controls.Add(viewersNameTextBox);

                    TextBox viewersSurTextBox = new TextBox
                    {
                        Text = row["surname"].ToString(),
                        Name = "surname",
                        Width = 190,
                        Enabled = false
                    };
                    panel.Controls.Add(viewersSurTextBox);

                    TextBox viewersExperienceTextBox = new TextBox
                    {
                        Text = row["seatnumber"].ToString(),
                        Name = "seatnumber",
                        Width = 75,
                        Enabled = false
                    };
                    panel.Controls.Add(viewersExperienceTextBox);


                    flowLayoutPanel4.Controls.Add(panel);
                }
            }
        }
        private void UpdateListFromServer3()
        {
            DB db = new DB();
            DataTable newTable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM judges", db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(newTable);
            flowLayoutPanel5.Controls.Clear();
            if (newTable.Rows.Count > 0)
            {
                foreach (DataRow row in newTable.Rows)
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    panel.AutoSize = true;

                    TextBox JudgesIDTextBox = new TextBox
                    {
                        Text = row["ID"].ToString(),
                        Name = "ID",
                        Width = 40,
                        Enabled = false
                    };
                    panel.Controls.Add(JudgesIDTextBox);
                    TextBox JudgesNameTextBox = new TextBox
                    {
                        Text = row["name"].ToString(),
                        Name = "name",
                        Width = 225,
                        Enabled = false
                    };
                    panel.Controls.Add(JudgesNameTextBox);

                    TextBox JudgesSurTextBox = new TextBox
                    {
                        Text = row["surname"].ToString(),
                        Name = "surname",
                        Width = 200,
                        Enabled = false
                    };
                    panel.Controls.Add(JudgesSurTextBox);

                    TextBox JudgesExperienceTextBox = new TextBox
                    {
                        Text = row["experience"].ToString(),
                        Name = "experience",
                        Width = 75,
                        Enabled = false
                    };
                    panel.Controls.Add(JudgesExperienceTextBox);


                    flowLayoutPanel5.Controls.Add(panel);
                }
            }
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddOrder addForm = new AddOrder();
            addForm.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddRiders admForm = new AddRiders();
            admForm.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Створюємо екземпляр класу для роботи з базою даних
            DB db = new DB();

            // Отримуємо значення id з текстового поля
            string CustIdText = IDTextBox1.Text;

            // Перетворюємо значення id в ціле число (якщо необхідно)
            if (int.TryParse(CustIdText, out int CustId))
            {
                // Відкриваємо з'єднання з базою даних
                db.GetConnection().Open();

                // Створюємо команду для видалення користувача
                SqlCommand command = new SqlCommand("DELETE FROM `Order` WHERE `Customer_ID` = @CustId", db.GetConnection());
                command.Parameters.AddWithValue("@CustId", CustId);

                // Виконуємо команду
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Користувача успішно видалено.");
                    }
                    else
                    {
                        MessageBox.Show("Замовника з таким id не знайдено.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при видаленні користувача: " + ex.Message);
                }
                finally
                {
                    // Закриваємо з'єднання
                    db.GetConnection().Close();
                }
            }
            else
            {
                MessageBox.Show("Введіть коректний id.");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Створюємо екземпляр класу для роботи з базою даних
            DB db = new DB();

            // Отримуємо значення id з текстового поля
            string userIdText = IDTextBox2.Text;

            // Перетворюємо значення id в ціле число (якщо необхідно)
            if (int.TryParse(userIdText, out int userId))
            {
                // Відкриваємо з'єднання з базою даних
                db.GetConnection().Open();

                // Створюємо команду для видалення користувача
                SqlCommand command = new SqlCommand("DELETE FROM `participants` WHERE `ID` = @userId", db.GetConnection());
                command.Parameters.AddWithValue("@userId", userId);

                // Виконуємо команду
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Учасника успішно видалено.");
                    }
                    else
                    {
                        MessageBox.Show("Учасника з таким id не знайдено.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при видаленні учасника: " + ex.Message);
                }
                finally
                {
                    // Закриваємо з'єднання
                    db.GetConnection().Close();
                }
            }
            else
            {
                MessageBox.Show("Введіть коректний id.");
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            // Створюємо екземпляр класу для роботи з базою даних
            DB db = new DB();

            // Отримуємо значення id з текстового поля
            string userIdText = IDTextBox3.Text;

            // Перетворюємо значення id в ціле число (якщо необхідно)
            if (int.TryParse(userIdText, out int userId))
            {
                // Відкриваємо з'єднання з базою даних
                db.GetConnection().Open();

                // Створюємо команду для видалення користувача
                SqlCommand command = new SqlCommand("DELETE FROM `viewers` WHERE `ID` = @userId", db.GetConnection());
                command.Parameters.AddWithValue("@userId", userId);

                // Виконуємо команду
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Глядача успішно видалено.");
                    }
                    else
                    {
                        MessageBox.Show("Глядача з таким id не знайдено.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при видаленні глядача: " + ex.Message);
                }
                finally
                {
                    // Закриваємо з'єднання
                    db.GetConnection().Close();
                }
            }
            else
            {
                MessageBox.Show("Введіть коректний id.");
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            // Створюємо екземпляр класу для роботи з базою даних
            DB db = new DB();

            // Отримуємо значення id з текстового поля
            string userIdText = IDTextBox4.Text;

            // Перетворюємо значення id в ціле число (якщо необхідно)
            if (int.TryParse(userIdText, out int userId))
            {
                // Відкриваємо з'єднання з базою даних
                db.GetConnection().Open();

                // Створюємо команду для видалення користувача
                SqlCommand command = new SqlCommand("DELETE FROM `judges` WHERE `ID` = @userId", db.GetConnection());
                command.Parameters.AddWithValue("@userId", userId);

                // Виконуємо команду
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Суддю успішно видалено.");
                    }
                    else
                    {
                        MessageBox.Show("Судді з таким id не знайдено.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при видаленні судді: " + ex.Message);
                }
                finally
                {
                    // Закриваємо з'єднання
                    db.GetConnection().Close();
                }
            }
            else
            {
                MessageBox.Show("Введіть коректний id.");
            }
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



        private void guna2Button6_Click(object sender, EventArgs e)
        {
            // Створюємо екземпляр класу для роботи з базою даних
            DB db = new DB();

            // Отримуємо значення id з текстового поля
            string userIdText = guna31.Text;

            // Отримуємо значення для оновлення з текстових полів
            string login = guna32.Text;
            string pass = guna33.Text;
            string name = guna34.Text;
            string surname = guna35.Text;
            string adminText = guna36.Text;

            // Перетворюємо значення id в ціле число (якщо необхідно)
            if (int.TryParse(userIdText, out int userId) && int.TryParse(adminText, out int admin))
            {
                // Відкриваємо з'єднання з базою даних
                db.GetConnection().Open();

                // Створюємо команду для оновлення користувача
                SqlCommand command = new SqlCommand(
                    "UPDATE `users` SET `login` = @login, `pass` = @pass, `name` = @name, `surname` = @surname, `admin` = @admin WHERE `id` = @userId",
                    db.GetConnection()
                );

                // Додаємо параметри
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@pass", pass);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@surname", surname);
                command.Parameters.AddWithValue("@admin", admin);

                // Виконуємо команду
                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Дані користувача успішно оновлено.");
                    }
                    else
                    {
                        MessageBox.Show("Користувача з таким id не знайдено.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при оновленні даних користувача: " + ex.Message);
                }
                finally
                {
                    db.GetConnection().Close();
                }
            }
            else
            {
                MessageBox.Show("Введіть коректний id та значення admin.");
            }
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string userIdText = guna41.Text;
            string name = guna42.Text;
            string surname = guna43.Text;
            string weight = guna44.Text;

            // Перевірка на порожні поля
            if (string.IsNullOrWhiteSpace(userIdText) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(weight))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.");
                return;
            }

            try
            {
                db.GetConnection().Open();

                SqlCommand command = new SqlCommand(
                    "UPDATE `participants` SET `name` = @name, `surname` = @surname, `weight` = @weight WHERE `ID` = @userId",
                    db.GetConnection()
                );

                command.Parameters.AddWithValue("@userId", userIdText);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@surname", surname);
                command.Parameters.AddWithValue("@weight", weight);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Дані учасника успішно оновлено.");
                }
                else
                {
                    MessageBox.Show("Учасника з таким id не знайдено.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при оновленні даних учасника: " + ex.Message);
            }
            finally
            {
                db.GetConnection().Close();
            }
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string userIdText = guna51.Text;
            string name = guna52.Text;
            string surname = guna53.Text;

            // Перевірка на порожні поля
            if (string.IsNullOrWhiteSpace(userIdText) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(surname))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.");
                return;
            }

            try
            {
                db.GetConnection().Open();

                SqlCommand command = new SqlCommand(
                    "UPDATE `viewers` SET `name` = @name, `surname` = @surname, `seatnumber` = @seatnumber WHERE `ID` = @userId",
                    db.GetConnection()
                );

                command.Parameters.AddWithValue("@userId", userIdText);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@surname", surname);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Дані глядача успішно оновлено.");
                }
                else
                {
                    MessageBox.Show("Глядача з таким id не знайдено.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при оновленні даних глядача: " + ex.Message);
            }
            finally
            {
                db.GetConnection().Close();
            }
        }
        private void guna2Button9_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string cargoIdText = guna61.Text;
            string name = guna62.Text;
            string unitWeightText = guna63.Text;

            // Перевірка на порожні поля
            if (string.IsNullOrWhiteSpace(cargoIdText) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(unitWeightText))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.");
                return;
            }

            try
            {
                db.GetConnection().Open();

                SqlCommand command = new SqlCommand(
                    "UPDATE `Cargo` SET `Name` = @name, `Unit_Weight` = @unitWeight WHERE `Cargo_ID` = @cargoId",
                    db.GetConnection()
                );

                command.Parameters.AddWithValue("@cargoId", cargoIdText);
                command.Parameters.AddWithValue("@name", name);

                // Перетворення Unit_Weight на число для зберігання у базі даних
                if (decimal.TryParse(unitWeightText, out decimal unitWeight))
                {
                    command.Parameters.AddWithValue("@unitWeight", unitWeight);
                }
                else
                {
                    MessageBox.Show("Некоректне значення для Unit Weight. Введіть числове значення.");
                    return;
                }

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Дані вантажу успішно оновлено.");
                }
                else
                {
                    MessageBox.Show("Вантаж із таким ID не знайдено.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при оновленні даних вантажу: " + ex.Message);
            }
            finally
            {
                db.GetConnection().Close();
            }
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCostamers vivForm = new AddCostamers();
            vivForm.Show();
        }




        private void guna2TextBox16_Enter(object sender, EventArgs e)
        {
            if (guna31.Text == "ID")
                guna31.Text = "";
            guna31.ForeColor = Color.Black;
        }

        private void guna2TextBox16_Leave(object sender, EventArgs e)
        {
            if (guna31.Text == "")
                guna31.Text = "ID";
            guna31.ForeColor = Color.Gray;
        }

        private void guna2TextBox17_Enter(object sender, EventArgs e)
        {
            if (guna32.Text == "Нік")
                guna32.Text = "";
            guna32.ForeColor = Color.Black;
        }

        private void guna2TextBox17_Leave(object sender, EventArgs e)
        {
            if (guna32.Text == "")
                guna32.Text = "Нік";
            guna32.ForeColor = Color.Gray;
        }

        private void userIDTextBox_Enter(object sender, EventArgs e)
        {
            if (guna33.Text == "Пароль")
                guna33.Text = "";
            guna33.ForeColor = Color.Black;
        }

        private void userIDTextBox_Leave(object sender, EventArgs e)
        {
            if (guna33.Text == "")
                guna33.Text = "Пароль";
            guna33.ForeColor = Color.Gray;
        }

        private void guna2TextBox11_Enter(object sender, EventArgs e)
        {
            if (guna34.Text == "Ім'я")
                guna34.Text = "";
            guna34.ForeColor = Color.Black;
        }

        private void guna2TextBox11_Leave(object sender, EventArgs e)
        {
            if (guna34.Text == "")
                guna34.Text = "Ім'я";
            guna34.ForeColor = Color.Gray;
        }

        private void guna2TextBox8_Enter(object sender, EventArgs e)
        {
            if (guna35.Text == "Фамілія")
                guna35.Text = "";
            guna35.ForeColor = Color.Black;
        }

        private void guna2TextBox8_Leave(object sender, EventArgs e)
        {
            if (guna35.Text == "")
                guna35.Text = "Фамілія";
            guna35.ForeColor = Color.Gray;
        }

        private void guna2TextBox15_Enter(object sender, EventArgs e)
        {
            if (guna36.Text == "Адмін")
                guna36.Text = "";
            guna36.ForeColor = Color.Black;
        }

        private void guna2TextBox15_Leave(object sender, EventArgs e)
        {
            if (guna36.Text == "")
                guna36.Text = "Адмін";
            guna36.ForeColor = Color.Gray;
        }



        private void guna2TextBox21_Enter(object sender, EventArgs e)
        {
            if (guna41.Text == "ID")
                guna41.Text = "";
            guna41.ForeColor = Color.Black;
        }

        private void guna2TextBox21_Leave(object sender, EventArgs e)
        {
            if (guna41.Text == "")
                guna41.Text = "ID";
            guna41.ForeColor = Color.Gray;
        }

        private void guna2TextBox19_Enter(object sender, EventArgs e)
        {
            if (guna42.Text == "Ім'я")
                guna42.Text = "";
            guna42.ForeColor = Color.Black;
        }

        private void guna2TextBox19_Leave(object sender, EventArgs e)
        {
            if (guna42.Text == "")
                guna42.Text = "Ім'я";
            guna42.ForeColor = Color.Gray;
        }

        private void guna2TextBox20_Enter(object sender, EventArgs e)
        {
            if (guna43.Text == "Фамілія")
                guna43.Text = "";
            guna43.ForeColor = Color.Black;
        }

        private void guna2TextBox20_Leave(object sender, EventArgs e)
        {
            if (guna43.Text == "")
                guna43.Text = "Фамілія";
            guna43.ForeColor = Color.Gray;
        }

        private void guna2TextBox18_Enter(object sender, EventArgs e)
        {
            if (guna44.Text == "Вага")
                guna44.Text = "";
            guna44.ForeColor = Color.Black;
        }

        private void guna2TextBox18_Leave(object sender, EventArgs e)
        {
            if (guna44.Text == "")
                guna44.Text = "Вага";
            guna44.ForeColor = Color.Gray;
        }




        private void guna2TextBox7_Enter(object sender, EventArgs e)
        {
            if (guna51.Text == "ID")
                guna51.Text = "";
            guna51.ForeColor = Color.Black;
        }

        private void guna2TextBox7_Leave(object sender, EventArgs e)
        {
            if (guna51.Text == "")
                guna51.Text = "ID";
            guna51.ForeColor = Color.Gray;
        }

        private void guna2TextBox3_Enter(object sender, EventArgs e)
        {
            if (guna52.Text == "Ім'я")
                guna52.Text = "";
            guna52.ForeColor = Color.Black;
        }

        private void guna2TextBox3_Leave(object sender, EventArgs e)
        {
            if (guna52.Text == "")
                guna52.Text = "Ім'я";
            guna52.ForeColor = Color.Gray;
        }

        private void guna2TextBox6_Enter(object sender, EventArgs e)
        {
            if (guna53.Text == "Фамілія")
                guna53.Text = "";
            guna53.ForeColor = Color.Black;
        }

        private void guna2TextBox6_Leave(object sender, EventArgs e)
        {
            if (guna53.Text == "")
                guna53.Text = "Фамілія";
            guna53.ForeColor = Color.Gray;
        }



        private void guna2TextBox23_Enter(object sender, EventArgs e)
        {
            if (guna51.Text == "ID")
                guna51.Text = "";
            guna51.ForeColor = Color.Black;
        }

        private void guna2TextBox23_Leave(object sender, EventArgs e)
        {
            if (guna51.Text == "")
                guna51.Text = "ID";
            guna51.ForeColor = Color.Gray;
        }

        private void guna2TextBox13_Enter(object sender, EventArgs e)
        {
            if (guna52.Text == "Ім'я")
                guna52.Text = "";
            guna52.ForeColor = Color.Black;
        }

        private void guna2TextBox13_Leave(object sender, EventArgs e)
        {
            if (guna52.Text == "")
                guna52.Text = "Ім'я";
            guna52.ForeColor = Color.Gray;
        }

        private void guna2TextBox22_Enter(object sender, EventArgs e)
        {
            if (guna53.Text == "Фамілія")
                guna53.Text = "";
            guna53.ForeColor = Color.Black;
        }

        private void guna2TextBox22_Leave(object sender, EventArgs e)
        {
            if (guna53.Text == "")
                guna53.Text = "Фамілія";
            guna53.ForeColor = Color.Gray;
        }

        private void guna2TextBox12_Enter(object sender, EventArgs e)
        {
            if (guna53.Text == "Досвід")
                guna53.Text = "";
            guna53.ForeColor = Color.Black;
        }

        private void guna2TextBox12_Leave(object sender, EventArgs e)
        {
            if (guna53.Text == "")
                guna53.Text = "Досвід";
            guna53.ForeColor = Color.Gray;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCargo JudForm = new AddCargo();
            JudForm.Show();
        }

    }
}


