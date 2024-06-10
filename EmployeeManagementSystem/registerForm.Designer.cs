namespace EmployeeManagementSystem
{
    partial class registerForm
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
            this.showpassCheck = new System.Windows.Forms.CheckBox();
            this.registerBtn = new System.Windows.Forms.Button();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.usernameField = new System.Windows.Forms.TextBox();
            this.pswLbl = new System.Windows.Forms.Label();
            this.usrLbl = new System.Windows.Forms.Label();
            this.RgsLBL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.img = new System.Windows.Forms.PictureBox();
            this.employeeLbl = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.loginLbl = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // showpassCheck
            // 
            this.showpassCheck.AutoSize = true;
            this.showpassCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showpassCheck.Location = new System.Drawing.Point(665, 423);
            this.showpassCheck.Name = "showpassCheck";
            this.showpassCheck.Size = new System.Drawing.Size(161, 26);
            this.showpassCheck.TabIndex = 16;
            this.showpassCheck.Text = "Show Password";
            this.showpassCheck.UseVisualStyleBackColor = true;
            this.showpassCheck.CheckedChanged += new System.EventHandler(this.showpassCheck_CheckedChanged);
            // 
            // registerBtn
            // 
            this.registerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.registerBtn.FlatAppearance.BorderSize = 0;
            this.registerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registerBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.registerBtn.Location = new System.Drawing.Point(477, 456);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(132, 51);
            this.registerBtn.TabIndex = 15;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = false;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // passwordField
            // 
            this.passwordField.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordField.Location = new System.Drawing.Point(477, 372);
            this.passwordField.Name = "passwordField";
            this.passwordField.Size = new System.Drawing.Size(349, 45);
            this.passwordField.TabIndex = 14;
            this.passwordField.UseSystemPasswordChar = true;
            // 
            // usernameField
            // 
            this.usernameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usernameField.Location = new System.Drawing.Point(477, 256);
            this.usernameField.Name = "usernameField";
            this.usernameField.Size = new System.Drawing.Size(349, 45);
            this.usernameField.TabIndex = 13;
            // 
            // pswLbl
            // 
            this.pswLbl.AutoSize = true;
            this.pswLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pswLbl.Location = new System.Drawing.Point(471, 337);
            this.pswLbl.Name = "pswLbl";
            this.pswLbl.Size = new System.Drawing.Size(138, 32);
            this.pswLbl.TabIndex = 12;
            this.pswLbl.Text = "Password";
            // 
            // usrLbl
            // 
            this.usrLbl.AutoSize = true;
            this.usrLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usrLbl.Location = new System.Drawing.Point(471, 221);
            this.usrLbl.Name = "usrLbl";
            this.usrLbl.Size = new System.Drawing.Size(144, 32);
            this.usrLbl.TabIndex = 11;
            this.usrLbl.Text = "Username";
            // 
            // RgsLBL
            // 
            this.RgsLBL.AutoSize = true;
            this.RgsLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RgsLBL.Location = new System.Drawing.Point(510, 159);
            this.RgsLBL.Name = "RgsLBL";
            this.RgsLBL.Size = new System.Drawing.Size(283, 38);
            this.RgsLBL.TabIndex = 10;
            this.RgsLBL.Text = "Register Account";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.panel1.Controls.Add(this.img);
            this.panel1.Controls.Add(this.employeeLbl);
            this.panel1.Controls.Add(this.loginBtn);
            this.panel1.Controls.Add(this.loginLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 721);
            this.panel1.TabIndex = 9;
            // 
            // img
            // 
            this.img.Image = global::EmployeeManagementSystem.Properties.Resources._7237991;
            this.img.Location = new System.Drawing.Point(127, 99);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(167, 157);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img.TabIndex = 11;
            this.img.TabStop = false;
            // 
            // employeeLbl
            // 
            this.employeeLbl.AutoSize = true;
            this.employeeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.employeeLbl.ForeColor = System.Drawing.Color.White;
            this.employeeLbl.Location = new System.Drawing.Point(30, 293);
            this.employeeLbl.Name = "employeeLbl";
            this.employeeLbl.Size = new System.Drawing.Size(359, 29);
            this.employeeLbl.TabIndex = 10;
            this.employeeLbl.Text = "Employee Management System ";
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.loginBtn.FlatAppearance.BorderSize = 0;
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loginBtn.Location = new System.Drawing.Point(12, 570);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(377, 51);
            this.loginBtn.TabIndex = 9;
            this.loginBtn.Text = "LOGIN";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // loginLbl
            // 
            this.loginLbl.AutoSize = true;
            this.loginLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginLbl.ForeColor = System.Drawing.Color.White;
            this.loginLbl.Location = new System.Drawing.Point(86, 535);
            this.loginLbl.Name = "loginLbl";
            this.loginLbl.Size = new System.Drawing.Size(254, 32);
            this.loginLbl.TabIndex = 9;
            this.loginLbl.Text = "Login your account";
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.Location = new System.Drawing.Point(865, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(37, 36);
            this.exit.TabIndex = 17;
            this.exit.Text = "X";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // registerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 721);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.showpassCheck);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.usernameField);
            this.Controls.Add(this.pswLbl);
            this.Controls.Add(this.usrLbl);
            this.Controls.Add(this.RgsLBL);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "registerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "registerForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox showpassCheck;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.TextBox passwordField;
        private System.Windows.Forms.TextBox usernameField;
        private System.Windows.Forms.Label pswLbl;
        private System.Windows.Forms.Label usrLbl;
        private System.Windows.Forms.Label RgsLBL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.Label employeeLbl;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label loginLbl;
        private System.Windows.Forms.Label exit;
    }
}