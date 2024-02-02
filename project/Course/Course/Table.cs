using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Course
{

    public partial class Table : Form
    {

        DbDataAdapter adapter;
        DbDataAdapter adpt;
        DataTable dt;
        BindingSource bs = new BindingSource();
        
        public Table()
        {
        
            InitializeComponent();      
            shwTable();
            label1.Text = GetRole.loginUser;
            System.Windows.Forms.ToolTip t1 = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip t2 = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip t3 = new System.Windows.Forms.ToolTip();
            t1.SetToolTip(query1_button, "Получить топ-3 клиентов с наибольшим количеством заказов");
            t2.SetToolTip(query2_button, "Товары, которые чаще всего заказывают в порядке убывания");
            t3.SetToolTip(query3_button, "Корреллированный запрос с подзапросом: Подсчитать количество заказов для каждого клиента");
            userName.Text = GetRole.loginUser;
            /*this.AcceptButton = null;
            if (GetRole.GetID() == 4) this.AcceptButton = customSQLButton;
            */

        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Вы хотите сохранить изменения?","",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                adapter.Update((DataTable)bs.DataSource);
                //adpt.Update((DataTable)bs.DataSource);
                
            }
        }

        private void shwTable()
        {
            DB db = new DB();

            db.openConnection();

            List<string> TableNames = new List<string>();
            foreach (DataRow row in db.getConnection().GetSchema("Tables").Rows)
            {
                TableNames.Add(row[2].ToString());
            }
            //textBox1.Text = TableNames.ToString();
            int role = GetRole.GetID();
                          
            query1_button.Visible = false;
            query2_button.Visible = false;
            query3_button.Visible = false;
            if (role == 1)
            {
                TableNames.Remove("deliveries");
                TableNames.Remove("orders");
                TableNames.Remove("products");
                TableNames.Remove("clients");
                TableNames.Remove("order_product");

            }
            else if (role == 2)
            {
                try

                {
                    TableNames.Remove("users");
                    TableNames.Remove("roles");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else if (role == 3)
            {
                TableNames.Remove("users");
                TableNames.Remove("roles");
                tableSQL.ReadOnly = true;
            }
            else if (role == 4)
            {
                tablesBox.Visible = false;
                saveButton.Visible = false;
                query1_button.Visible = true;
                query2_button.Visible = true;
                query3_button.Visible = true;
                tableSQL.ReadOnly = true;
                customSQLTextBox.Visible = true;
                customSQLButton.Visible = true;
                

            }
            try
            {
                tablesBox.DataSource = TableNames;
                string selectedState = tablesBox.SelectedItem.ToString();
                tablesBox.Text = selectedState;
                string table = selectedState;
                string sql = "SELECT * FROM " + table;
                if (role == 4) showQuery(sql_query1);
                else
                {
                    adapter = new MySqlDataAdapter(sql, db.getConnection());
                    MySqlCommandBuilder myCommandBuilder = new MySqlCommandBuilder(adapter as MySqlDataAdapter);
                    adapter.InsertCommand = myCommandBuilder.GetInsertCommand();
                    adapter.UpdateCommand = myCommandBuilder.GetUpdateCommand();
                    adapter.DeleteCommand = myCommandBuilder.GetDeleteCommand();

                    dt = new DataTable();
                    adapter.Fill(dt); //загрузка данных
                    bs.DataSource = dt;
                    tableSQL.DataSource = bs;
                    //привязка к DataGrid
                    /*if (tableSQL.Columns["Code_city"] != null) { tableSQL.Columns["Code_city"].DisplayIndex = 0; }
                    if (tableSQL.Columns["Code_conservations"] != null) { tableSQL.Columns["Code_conservations"].DisplayIndex = 0; }
                    if (tableSQL.Columns["Code_discount"] != null) { tableSQL.Columns["Code_discount"].DisplayIndex = 0; }
                    if (tableSQL.Columns["Code_abonent"] != null) { tableSQL.Columns["Code_abonent"].DisplayIndex = 0; }
                    if (tableSQL.Columns["role_code"] != null) { tableSQL.Columns["role_code"].DisplayIndex = 0; }
                    if (tableSQL.Columns["id"] != null) { tableSQL.Columns["id"].DisplayIndex = 0; }*/


                    tableSQL.Columns[0].ReadOnly = true;
                    dt.Columns[0].AutoIncrement = true;
                    DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
                    object value = lastRow[0];
                    dt.Columns[0].AutoIncrementSeed = Convert.ToInt64(value) + 1;
                    db.closeConnection();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            DataGridViewSelectedCellCollection selectedCell = tableSQL.SelectedCells;
            tableSQL.ClearSelection();
            selectedCell = tableSQL.SelectedCells;
            
        }

            /*private void bd()
            {
                DB db = new DB();

                db.openConnection();

                string sql1 = "SELECT login FROM users";
                adapter = new MySqlDataAdapter(new MySqlCommand(sql1, db.getConnection()));
                //MySqlCommand myCommandBuilder = new MySqlCommand(adapter as MySqlDataAdapter);
                //adapter.InsertCommand = myCommandBuilder.GetInsertCommand();
                //adapter.UpdateCommand = myCommandBuilder.GetUpdateCommand();
                //adapter.DeleteCommand = myCommandBuilder.GetDeleteCommand();


                DataTable dt1 = new DataTable();
                adapter.Fill(dt1);
                Column1.DataSource = dt1;
                Column1.DisplayMember = "login";
                Column1.ValueMember = "login";
                db.closeConnection();
            }*/

            private void tablesBox_SelectionChangeCommitted(object sender, EventArgs e)
            {
            try
            {
                //tableSQL.Columns[0].ReadOnly=false;
                string table = "";
                tableSQL.ReadOnly = false;
                DB db = new DB();

                db.openConnection();

                string selectedState = tablesBox.SelectedItem.ToString();
                tablesBox.Text = selectedState;
                table = selectedState;
                string sql = "SELECT * FROM " + table;
                if (table == "order_product" && GetRole.GetID()!=3) 
                {
                    sql = "SELECT * from order_product";
                    adpt = new MySqlDataAdapter(sql, db.getConnection());
                    MySqlCommandBuilder myCommandBuilder = new MySqlCommandBuilder(adapter as MySqlDataAdapter);
                    adpt.InsertCommand = myCommandBuilder.GetInsertCommand();
                    adpt.UpdateCommand = myCommandBuilder.GetUpdateCommand();
                    adpt.DeleteCommand = myCommandBuilder.GetDeleteCommand();
                    dt = new DataTable();
                    adpt.Fill(dt);
                    bs.DataSource = dt;
                    tableSQL.DataSource = bs;
                    tableSQL.ReadOnly = true;
                }
                else if (table == "orders" && GetRole.GetID()==3)
                {
                    sql = "SELECT  Clients.Name_client,\r\n       " +
                        "Orders.Code_order, Orders.Date_order,\r\n   " +
                        "Deliveries.Name_delivery\r\n" +
                        "FROM ordermanagement.Clients\r\nJOIN ordermanagement.Orders ON Clients.Code_client = Orders.Code_client\r\n" +
                        "JOIN ordermanagement.Deliveries ON Orders.Code_delivery = Deliveries.Code_delivery;\r\n";
                    adpt = new MySqlDataAdapter(sql, db.getConnection());
                    MySqlCommandBuilder myCommandBuilder = new MySqlCommandBuilder(adapter as MySqlDataAdapter);
                    adpt.InsertCommand = myCommandBuilder.GetInsertCommand();
                    adpt.UpdateCommand = myCommandBuilder.GetUpdateCommand();
                    adpt.DeleteCommand = myCommandBuilder.GetDeleteCommand();
                    dt = new DataTable();
                    adpt.Fill(dt);
                    bs.DataSource = dt;
                    tableSQL.DataSource = bs;
                }
                else if (table == "order_product" && GetRole.GetID()==3)
                {
                    /*sql = "SELECT  Products.Name_product,\r\n       " +
                        "Orders.Code_order, Products.Price_product, Products.Amount_product,\r\n   " +
                        "Order_product.Code_order_product\r\n" +
                        "FROM ordermanagement.Order_product\r\nJOIN ordermanagement.Orders ON Order_product.Code_order = Orders.Code_order\r\n" +
                        "JOIN ordermanagement.Products ON Orders.Code_product = Products.Code_product;\r\n";
                    */
                    /*sql = "SELECT Products.Name_product, " +
                          "Orders.Code_order, Products.Price_product, Products.Amount_product, " +
                          "Order_product.Code_order_product " +
                          "FROM ordermanagement.Order_product " +
                          "JOIN ordermanagement.Orders ON Order_product.Code_order = Orders.Code_order " +
                          "JOIN ordermanagement.Products ON Order_product.Code_product = Products.Code_product;";
                    */
                    sql = "SELECT Order_product.Code_order_product, Clients.Name_client, Products.Name_product, Order_Product.Price_product, Order_Product.Amount_product\r\nFROM ordermanagement.Clients\r\nJOIN ordermanagement.Orders ON Clients.Code_client = Orders.Code_client\r\nJOIN ordermanagement.Order_Product ON Orders.Code_order = Order_Product.Code_order\r\nJOIN ordermanagement.Products ON Order_Product.Code_product = Products.Code_product;\r\n";

                    adpt = new MySqlDataAdapter(sql, db.getConnection());
                    MySqlCommandBuilder myCommandBuilder = new MySqlCommandBuilder(adapter as MySqlDataAdapter);
                    adpt.InsertCommand = myCommandBuilder.GetInsertCommand();
                    adpt.UpdateCommand = myCommandBuilder.GetUpdateCommand();
                    adpt.DeleteCommand = myCommandBuilder.GetDeleteCommand();
                    dt = new DataTable();
                    adpt.Fill(dt);
                    bs.DataSource = dt;
                    tableSQL.DataSource = bs;
                }
                else
                {
                    adapter = new MySqlDataAdapter(sql, db.getConnection());
                    MySqlCommandBuilder myCommandBuilder = new MySqlCommandBuilder(adapter as MySqlDataAdapter);
                    adapter.InsertCommand = myCommandBuilder.GetInsertCommand();
                    adapter.UpdateCommand = myCommandBuilder.GetUpdateCommand();
                    adapter.DeleteCommand = myCommandBuilder.GetDeleteCommand();
                    dt = new DataTable();
                    adapter.Fill(dt); //загрузка данных
                    bs.DataSource = dt;
                    tableSQL.DataSource = bs;
                }
                if (GetRole.GetID() == 3)
                {
                    if (selectedState != "products")
                        tableSQL.ReadOnly = true;
                    else
                        tableSQL.ReadOnly = false;
                }
                if (tableSQL.Columns["code_client"] != null && selectedState == "clients") 
                {
                    dt.Columns["code_client"].SetOrdinal(0);
                    tableSQL.Columns["code_client"].DisplayIndex = 0; }

                if (tableSQL.Columns["code_delivery"] != null && selectedState == "deliveries") 
                {
                    dt.Columns["code_delivery"].SetOrdinal(0);
                    tableSQL.Columns["code_delivery"].DisplayIndex = 0; 
                }
                if (tableSQL.Columns["code_product"] != null && selectedState == "products") 
                {
                    dt.Columns["code_product"].SetOrdinal(0);
                    tableSQL.Columns["code_product"].DisplayIndex = 0; 
                }
                if (tableSQL.Columns["code_order"] != null && selectedState == "orders") 
                {
                    dt.Columns["code_order"].SetOrdinal(0);
                    tableSQL.Columns["code_order"].DisplayIndex = 0;
                }
                if (tableSQL.Columns["code_role"] != null && selectedState == "roles") 
                {
                    dt.Columns["code_role"].SetOrdinal(0);
                    tableSQL.Columns["code_role"].DisplayIndex = 0; 
                }
                if (tableSQL.Columns["code_order_product"] != null && selectedState == "order_product")
                {
                    dt.Columns["code_order_product"].SetOrdinal(0);
                    tableSQL.Columns["code_order_product"].DisplayIndex = 0; 
                }
                if (tableSQL.Columns["id"] != null && selectedState == "users")
                {
                    dt.Columns["id"].SetOrdinal(0);
                    tableSQL.Columns["id"].DisplayIndex = 0; 
                }
                tableSQL.Columns[0].ReadOnly = true;
                dt.Columns[0].AutoIncrement = true;
                DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
                object value = lastRow[0];
                dt.Columns[0].AutoIncrementSeed = Convert.ToInt64(value) + 1;
                db.closeConnection();

                /*Thread thr = new Thread(bd);
                thr.Start();*/


                //привязка к DataGrid
                /*DataGridViewCheckBoxColumn cl = new DataGridViewCheckBoxColumn();
                if (table == "users")
                {


                    cl.Name = tableSQL.Columns[5].Name;
                    tableSQL.Columns[5].Visible = false;
                    tableSQL.Columns.AddRange(cl);
                }
                else
                {
                    cl.Visible = false;
                    //tableSQL.Columns[5].Visible = true;
                }*/
                /*if (table == "users") 
                { 
                    ArrayList enableList = new ArrayList();
                    foreach (DataRow item in dt.Rows)
                    {
                        enableList.Add(item["login"].ToString());
                    }
                    foreach (DataRow item in dt.Rows)
                    {
                        int n = tableSQL.Rows.Add();
                        var boxCell = new DataGridViewComboBoxCell();
                        boxCell.DataSource = enableList;
                        tableSQL.Rows[n].Cells[0].Value = item[0].ToString();
                        tableSQL.Rows[n].Cells[1].Value = boxCell;
                        //tableSQL.Rows[n].Cells[2].Value = boxCell;

                    } 
                }*/
                //textBox1.Text = enableList[0].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowLogin() => Application.Run(new LoginForm());

        private void logOutButton_Click(object sender, EventArgs e)
        {
            Thread thr2 = new Thread(ShowLogin);
            thr2.Start();
            this.Dispose();
        }

        private void query1_button_Click(object sender, EventArgs e)
        {
            showQuery(sql_query1);
        }

        private void query2_button_Click(object sender, EventArgs e)
        {
            showQuery(sql_query2);
        }

        private void query3_button_Click(object sender, EventArgs e)
        {
            showQuery(sql_query3);
        }

        private void showQuery(string sql)
        {
            DB db = new DB();
            db.openConnection();
            adpt = new MySqlDataAdapter(sql, db.getConnection());
            dt = new DataTable();
            adpt.Fill(dt);
            bs.DataSource = dt;
            tableSQL.DataSource = bs;
            db.closeConnection();
        }
       /*private void showQuery2(string sql)
        {
            DB db = new DB();
            db.openConnection();
            adpt = new MySqlDataAdapter(sql, db.getConnection());
            dt = new DataTable();
            adpt.Fill(dt);
            bs.DataSource = dt;
            tableSQL.DataSource = bs;
            db.closeConnection();
        }*/

        private string sql_query1 = "SELECT ordermanagement.clients.Name_client, COUNT(ordermanagement.Orders.Code_order) AS Amount_order " +
                                    "FROM ordermanagement.Clients JOIN ordermanagement.Orders ON ordermanagement.Clients.Code_client = ordermanagement.Orders.Code_client " +
                                    "GROUP BY ordermanagement.Clients.Name_client ORDER BY Amount_order DESC LIMIT 3;";

        private string sql_query2 = "SELECT ordermanagement.Products.Name_product, COUNT(ordermanagement.order_product.Code_product) AS Amount_order " +
                                    "FROM ordermanagement.Products LEFT JOIN ordermanagement.order_product " +
                                    "ON ordermanagement.Products.Code_product = ordermanagement.order_product.Code_product " +
                                    "GROUP BY ordermanagement.Products.Name_product ORDER BY Amount_order DESC;";

        private string sql_query3 = "SELECT Name_client,( SELECT COUNT(*) " +
                                    "FROM ordermanagement.Orders WHERE ordermanagement.clients.Code_client = ordermanagement.Orders.Code_client)" +
                                    " AS Amount_order FROM ordermanagement.clients;";

        private void tableSQL_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            tableSQL.ClearSelection();
        }

        private void customSQLButton_Click(object sender, EventArgs e)
        {
            string[] banTable = {"ROLES", "USERS"};
            string[] banQuery = {"DELETE", "UPDATE", "CREATE", "INSERT", "DROP", "RENAME", "ALTER", "GRANT", "REVOKE", "DENY", "COMMIT", "ROLLBACK", "BEGIN"};
            string query = customSQLTextBox.Text.ToUpper();

            foreach (string item in banQuery)
            {
                if (query.Contains(item))
                {
                    MessageBox.Show($"Нельзя использовать вид запроса - {item}!\nВы можете использовать только - SELECT.","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }

            foreach (string item in banTable)
            {
                if (query.Contains(item))
                {
                    MessageBox.Show($"Вы не можете обращаться к таблице - {item}!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                string sql = query.ToLower();
                DB db = new DB();
                db.openConnection();
                adpt = new MySqlDataAdapter(sql, db.getConnection());
                dt = new DataTable();
                adpt.Fill(dt);
                bs.DataSource = dt;
                tableSQL.DataSource = bs;
                db.closeConnection();
                tableSQL.ReadOnly = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thr2 = new Thread(ShowLogin);
            thr2.Start();
            this.Dispose();
        }
    }
}    