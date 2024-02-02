using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Course
{
    public partial class LoginForm : Form
    {

        private bool checkerLogin, checkerPass = false;
        public LoginForm()
        {
            InitializeComponent();
        }

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

        private void ShowTable()
        {
            try
            {
                Application.Run(new Table());
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void ShowRegister() => Application.Run(new RegisterForm());


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread thr = new Thread(ShowRegister);
            thr.Start();
            this.Dispose();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            
            //String loginUser = LoginBox.Text;
            GetRole.loginUser = LoginBox.Text;
            string loginUser = GetRole.loginUser; 
            String passUser = PassBox.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass` = @uP", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                //MySqlDataReader reader;
                /*this.Dispose();*/
                //MessageBox.Show("Yes");
                /*db.openConnection();
                MySqlCommand com = new MySqlCommand("SELECT role_code FROM users WHERE login = '" + loginUser + "'", db.getConnection());

                MessageBox.Show(LoginBox.Text);
                reader = com.ExecuteReader();
                reader.Read();
                int numId = Convert.ToInt32(reader[0]);
                reader.Close();
                MessageBox.Show(numId.ToString());
                db.closeConnection();
                MessageBox.Show(reader.GetName(0));*/

                /*Form t = new Table();
                t.ShowDialog();
                this.Close();*/
                db.openConnection();
                MySqlCommand com = new MySqlCommand("SELECT code_role, enable FROM users WHERE login = '" + loginUser + "'", db.getConnection());
                MySqlDataReader reader = com.ExecuteReader();
                reader.Read();
                int role = Convert.ToInt32(reader[0]);
                bool enable = Convert.ToBoolean(reader[1]);
                reader.Close();
                if (enable == true)
                {
                    Thread thr = new Thread(ShowTable);
                    thr.SetApartmentState(ApartmentState.STA);
                    thr.Start();
                    this.Dispose();
                }
                else
                    MessageBox.Show("Ваш аккаунт был заблокирован.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                MessageBox.Show("Неверный логин или пароль.","Ошибка",MessageBoxButtons.OK ,MessageBoxIcon.Error);
                
            }
            db.closeConnection();
        }
    }
}
