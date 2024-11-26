using System.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace OOP.SQL
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer timer;
        public MainForm()
        {

            InitializeComponent();

            // Ініціалізація таймера
            timer = new System.Windows.Forms.Timer
            {
                Interval = 5000 // Час в мілісекундах (тут кожні 5 секунд)
            };
            timer.Tick += new EventHandler(timer_Tick1);
            timer.Tick += new EventHandler(timer_Tick2);
            timer.Tick += new EventHandler(timer_Tick3);
            timer.Start();
            flowLayoutPanel11.AutoScroll = true;
            flowLayoutPanel12.AutoScroll = true;
            flowLayoutPanel13.AutoScroll = true;
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
        private void closeButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        Point lastPoint;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }


        private void UpdateListFromServer1()
        {
            DB db = new DB();
            DataTable newTable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM participants", db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(newTable);
            flowLayoutPanel11.Controls.Clear();
            if (newTable.Rows.Count > 0)
            {
                foreach (DataRow row in newTable.Rows)
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    panel.AutoSize = true;

                    TextBox participantNameTextBox = new TextBox
                    {
                        Text = row["name"].ToString(),
                        Name = "name",
                        Width = 150,
                        Enabled = false
                    };
                    panel.Controls.Add(participantNameTextBox);

                    TextBox participantSurTextBox = new TextBox
                    {
                        Text = row["surname"].ToString(),
                        Name = "surname",
                        Width = 150,
                        Enabled = false
                    };
                    panel.Controls.Add(participantSurTextBox);

                    TextBox participantWeightTextBox = new TextBox
                    {
                        Text = row["weight"].ToString(),
                        Name = "weight",
                        Width = 150,
                        Enabled = false
                    };
                    panel.Controls.Add(participantWeightTextBox);


                    flowLayoutPanel11.Controls.Add(panel);
                }
            }
        }
        private void UpdateListFromServer2()
        {
            DB db = new DB();
            DataTable newTable = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT * FROM viewers", db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(newTable);
            flowLayoutPanel12.Controls.Clear();
            if (newTable.Rows.Count > 0)
            {
                foreach (DataRow row in newTable.Rows)
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    panel.AutoSize = true;

                    TextBox viewersNameTextBox = new TextBox
                    {
                        Text = row["name"].ToString(),
                        Name = "name",
                        Width = 150,
                        Enabled = false
                    };
                    panel.Controls.Add(viewersNameTextBox);

                    TextBox viewersSurTextBox = new TextBox
                    {
                        Text = row["surname"].ToString(),
                        Name = "surname",
                        Width = 150,
                        Enabled = false
                    };
                    panel.Controls.Add(viewersSurTextBox);

                    TextBox viewersExperienceTextBox = new TextBox
                    {
                        Text = row["seatnumber"].ToString(),
                        Name = "seatnumber",
                        Width = 150,
                        Enabled = false
                    };
                    panel.Controls.Add(viewersExperienceTextBox);


                    flowLayoutPanel12.Controls.Add(panel);
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
            flowLayoutPanel13.Controls.Clear();
            if (newTable.Rows.Count > 0)
            {
                foreach (DataRow row in newTable.Rows)
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.FlowDirection = FlowDirection.LeftToRight;
                    panel.AutoSize = true;

                    TextBox JudgesNameTextBox = new TextBox
                    {
                        Text = row["name"].ToString(),
                        Name = "name",
                        Width = 150,
                        Enabled = false
                    };
                    panel.Controls.Add(JudgesNameTextBox);

                    TextBox JudgesSurTextBox = new TextBox
                    {
                        Text = row["surname"].ToString(),
                        Name = "surname",
                        Width = 150,
                        Enabled = false
                    };
                    panel.Controls.Add(JudgesSurTextBox);

                    TextBox JudgesExperienceTextBox = new TextBox
                    {
                        Text = row["experience"].ToString(),
                        Name = "experience",
                        Width = 150,
                        Enabled = false
                    };
                    panel.Controls.Add(JudgesExperienceTextBox);


                    flowLayoutPanel13.Controls.Add(panel);
                }
            }
        }
    }
}