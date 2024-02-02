namespace Course
{
    partial class RegisterForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.RegisterButton = new System.Windows.Forms.Button();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.confirmPassBox = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(76, 138);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(128, 23);
            this.RegisterButton.TabIndex = 0;
            this.RegisterButton.Text = "Зарегистрироваться";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // LoginBox
            // 
            this.LoginBox.Location = new System.Drawing.Point(76, 48);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(128, 20);
            this.LoginBox.TabIndex = 1;
            this.LoginBox.Text = "Логин";
            this.LoginBox.Click += new System.EventHandler(this.LoginBox_Click);
            // 
            // PassBox
            // 
            this.PassBox.Location = new System.Drawing.Point(76, 74);
            this.PassBox.Name = "PassBox";
            this.PassBox.Size = new System.Drawing.Size(128, 20);
            this.PassBox.TabIndex = 2;
            this.PassBox.Text = "Пароль";
            this.PassBox.UseSystemPasswordChar = true;
            this.PassBox.Click += new System.EventHandler(this.PassBox_Click);
            this.PassBox.TextChanged += new System.EventHandler(this.PassBox_TextChanged);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(76, 22);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(128, 20);
            this.nameBox.TabIndex = 3;
            this.nameBox.Text = "Имя";
            this.nameBox.Click += new System.EventHandler(this.nameBox_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(210, 86);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Скрывать пароль";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // confirmPassBox
            // 
            this.confirmPassBox.Location = new System.Drawing.Point(76, 100);
            this.confirmPassBox.Name = "confirmPassBox";
            this.confirmPassBox.Size = new System.Drawing.Size(128, 20);
            this.confirmPassBox.TabIndex = 5;
            this.confirmPassBox.Text = "Пароль";
            this.confirmPassBox.UseSystemPasswordChar = true;
            this.confirmPassBox.Click += new System.EventHandler(this.confirmPassBox_Click);
            this.confirmPassBox.TextChanged += new System.EventHandler(this.confirmPassBox_TextChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(33, 143);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(37, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Войти";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // RegisterForm
            // 
            this.AcceptButton = this.RegisterButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 183);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.confirmPassBox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.PassBox);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.RegisterButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RegisterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox confirmPassBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

