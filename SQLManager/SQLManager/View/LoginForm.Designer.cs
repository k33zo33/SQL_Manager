﻿namespace SQLManager.View
{
    partial class LoginForm
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
            label1 = new Label();
            tbServer = new TextBox();
            tbUsername = new TextBox();
            label2 = new Label();
            tbPassword = new TextBox();
            label3 = new Label();
            btnLogin = new Button();
            lbError = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(136, 85);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Server:";
            // 
            // tbServer
            // 
            tbServer.Location = new Point(204, 82);
            tbServer.Name = "tbServer";
            tbServer.Size = new Size(258, 23);
            tbServer.TabIndex = 1;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(204, 141);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(258, 23);
            tbUsername.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(136, 144);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Username:";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(204, 202);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(258, 23);
            tbPassword.TabIndex = 5;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(136, 205);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 4;
            label3.Text = "Password:";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(204, 277);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(115, 34);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += BtnLogin_Click;
            // 
            // lbError
            // 
            lbError.AutoSize = true;
            lbError.ForeColor = Color.Red;
            lbError.Location = new Point(204, 342);
            lbError.Name = "lbError";
            lbError.Size = new Size(103, 15);
            lbError.TabIndex = 7;
            lbError.Text = "Wrong credentials";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 443);
            Controls.Add(lbError);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(label3);
            Controls.Add(tbUsername);
            Controls.Add(label2);
            Controls.Add(tbServer);
            Controls.Add(label1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbServer;
        private TextBox tbUsername;
        private Label label2;
        private TextBox tbPassword;
        private Label label3;
        private Button btnLogin;
        private Label lbError;
    }
}