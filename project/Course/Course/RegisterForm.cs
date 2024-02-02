using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Course
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

        }
        private bool checkerLogin, checkerPass, checkerName, checkerConfirm = false;

        private void LoginBox_Click(object sender, EventArgs e)
        {
            if (checkerLogin == false)
            {
                LoginBox.Text = "";
                checkerLogin = true;
            }
        }

        private void PassBox_Click(object sender, EventArgs e)
        {
            if (checkerPass == false)
            {
                PassBox.Text = "";
                checkerPass = true;
            }
        }

        private void nameBox_Click(object sender, EventArgs e)
        {
            if (checkerName == false)
            {
                nameBox.Text = "";
                checkerName = true;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {

            string pass = PassBox.Text;
            if (checkBox1.Checked)
            {
                PassBox.UseSystemPasswordChar = true;
                confirmPassBox.UseSystemPasswordChar = true;
            }
            else
            {
                PassBox.UseSystemPasswordChar = false;
                confirmPassBox.UseSystemPasswordChar = false;
            }
        }



        private void confirmPassBox_TextChanged(object sender, EventArgs e)
        {
            if (PassBox.Text == confirmPassBox.Text)
                RegisterButton.Enabled = true;
            else
                RegisterButton.Enabled = false;
        }

        private void PassBox_TextChanged(object sender, EventArgs e)
        {
            if (PassBox.Text == confirmPassBox.Text)
                RegisterButton.Enabled = true;
            else
                RegisterButton.Enabled = false;
        }

        private void confirmPassBox_Click(object sender, EventArgs e)
        {
            if (checkerConfirm == false)
            {
                confirmPassBox.Text = "";
                checkerConfirm = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread thr = new Thread(ShowLogin);
            thr.Start();
            this.Dispose();
        }

        private void ShowLogin() => Application.Run(new LoginForm());

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                String loginUser = LoginBox.Text;
                String passUser = PassBox.Text;
                String nameUser = nameBox.Text;

                if (UserExists())
                    return;
                else
                {
                    DB db = new DB();
                    MySqlCommand command = new MySqlCommand("INSERT INTO `ordermanagement`.`users` (`login`, `pass`, `name`, `code_role`, `enable`) VALUES (@uL, @uP, @uN, 4, true)", db.getConnection());
                    command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                    command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
                    command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = nameUser;

                    db.openConnection();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Аккаунт был создан");
                        Thread thr = new Thread(ShowLogin);
                        thr.Start();
                        this.Dispose();
                    }

                    else
                        MessageBox.Show("Аккаунт не был создан");
                    db.closeConnection();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            /* DataTable table = new DataTable();

             MySqlDataAdapter adapter = new MySqlDataAdapter();
             MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass` = @uP", db.getConnection());
             command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
             command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

             adapter.SelectCommand = command;
             adapter.Fill(table);
             if (table.Rows.Count > 0) {
                 MessageBox.Show("Yes");
             }
             else MessageBox.Show("No");
             Form t = new Table();
             t.Show();*/
        }
        public Boolean UserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginBox.Text;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже существует");
                return true;
            }
            else
            {
                return false;
            }
            //return false;
        }


    }
}
