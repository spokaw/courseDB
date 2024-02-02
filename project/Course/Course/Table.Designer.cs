namespace Course
{
    partial class Table
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tablesBox = new System.Windows.Forms.ComboBox();
            this.logOutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableSQL = new System.Windows.Forms.DataGridView();
            this.query1_button = new System.Windows.Forms.Button();
            this.query2_button = new System.Windows.Forms.Button();
            this.query3_button = new System.Windows.Forms.Button();
            this.customSQLTextBox = new System.Windows.Forms.TextBox();
            this.customSQLButton = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.userName = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tableSQL)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(644, 363);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 27);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tablesBox
            // 
            this.tablesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tablesBox.FormattingEnabled = true;
            this.tablesBox.Location = new System.Drawing.Point(643, 29);
            this.tablesBox.Name = "tablesBox";
            this.tablesBox.Size = new System.Drawing.Size(121, 21);
            this.tablesBox.TabIndex = 4;
            this.tablesBox.SelectionChangeCommitted += new System.EventHandler(this.tablesBox_SelectionChangeCommitted);
            // 
            // logOutButton
            // 
            this.logOutButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.logOutButton.Location = new System.Drawing.Point(736, 415);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(59, 23);
            this.logOutButton.TabIndex = 6;
            this.logOutButton.Text = "Выйти";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Visible = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(701, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "User";
            this.label1.Visible = false;
            // 
            // tableSQL
            // 
            this.tableSQL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableSQL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableSQL.Location = new System.Drawing.Point(25, 29);
            this.tableSQL.Name = "tableSQL";
            this.tableSQL.Size = new System.Drawing.Size(612, 359);
            this.tableSQL.TabIndex = 1;
            this.tableSQL.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.tableSQL_DataBindingComplete);
            // 
            // query1_button
            // 
            this.query1_button.Location = new System.Drawing.Point(25, 394);
            this.query1_button.Name = "query1_button";
            this.query1_button.Size = new System.Drawing.Size(75, 23);
            this.query1_button.TabIndex = 8;
            this.query1_button.Text = "Запрос 1";
            this.query1_button.UseVisualStyleBackColor = true;
            this.query1_button.Click += new System.EventHandler(this.query1_button_Click);
            // 
            // query2_button
            // 
            this.query2_button.Location = new System.Drawing.Point(106, 394);
            this.query2_button.Name = "query2_button";
            this.query2_button.Size = new System.Drawing.Size(75, 23);
            this.query2_button.TabIndex = 9;
            this.query2_button.Text = "Запрос 2";
            this.query2_button.UseVisualStyleBackColor = true;
            this.query2_button.Click += new System.EventHandler(this.query2_button_Click);
            // 
            // query3_button
            // 
            this.query3_button.Location = new System.Drawing.Point(187, 394);
            this.query3_button.Name = "query3_button";
            this.query3_button.Size = new System.Drawing.Size(75, 23);
            this.query3_button.TabIndex = 10;
            this.query3_button.Text = "Запрос 3";
            this.query3_button.UseVisualStyleBackColor = true;
            this.query3_button.Click += new System.EventHandler(this.query3_button_Click);
            // 
            // customSQLTextBox
            // 
            this.customSQLTextBox.Location = new System.Drawing.Point(643, 54);
            this.customSQLTextBox.Multiline = true;
            this.customSQLTextBox.Name = "customSQLTextBox";
            this.customSQLTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.customSQLTextBox.Size = new System.Drawing.Size(152, 274);
            this.customSQLTextBox.TabIndex = 11;
            this.customSQLTextBox.Visible = false;
            // 
            // customSQLButton
            // 
            this.customSQLButton.Location = new System.Drawing.Point(644, 334);
            this.customSQLButton.Name = "customSQLButton";
            this.customSQLButton.Size = new System.Drawing.Size(120, 23);
            this.customSQLButton.TabIndex = 12;
            this.customSQLButton.Text = "Выполнить запрос";
            this.customSQLButton.UseVisualStyleBackColor = true;
            this.customSQLButton.Visible = false;
            this.customSQLButton.Click += new System.EventHandler(this.customSQLButton_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userName});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 27);
            this.menuStrip2.TabIndex = 13;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // userName
            // 
            this.userName.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(145, 23);
            this.userName.Text = "toolStripMenuItem1";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.logOutButton;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customSQLButton);
            this.Controls.Add(this.customSQLTextBox);
            this.Controls.Add(this.query3_button);
            this.Controls.Add(this.query2_button);
            this.Controls.Add(this.query1_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.tablesBox);
            this.Controls.Add(this.tableSQL);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Table";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Таблица";
            ((System.ComponentModel.ISupportInitialize)(this.tableSQL)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox tablesBox;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tableSQL;
        private System.Windows.Forms.Button query1_button;
        private System.Windows.Forms.Button query2_button;
        private System.Windows.Forms.Button query3_button;
        private System.Windows.Forms.TextBox customSQLTextBox;
        private System.Windows.Forms.Button customSQLButton;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem userName;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}