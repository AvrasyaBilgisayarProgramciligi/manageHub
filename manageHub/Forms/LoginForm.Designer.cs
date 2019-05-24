namespace manageHub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.bClose = new System.Windows.Forms.Button();
            this.mainText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bSignIn = new System.Windows.Forms.Button();
            this.bSignUp = new System.Windows.Forms.Button();
            this.signInPage = new System.Windows.Forms.Panel();
            this.signAlert2 = new System.Windows.Forms.Panel();
            this.signAlert1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbSignIn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.signPsw = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.signEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eMail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.psw = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSignUp = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.alert3 = new System.Windows.Forms.Panel();
            this.alert4 = new System.Windows.Forms.Panel();
            this.signUpPage = new System.Windows.Forms.Panel();
            this.alert2 = new System.Windows.Forms.Panel();
            this.alert1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.TextBox();
            this.mainPanel.SuspendLayout();
            this.signInPage.SuspendLayout();
            this.signUpPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(90)))), ((int)(((byte)(102)))));
            this.mainPanel.Controls.Add(this.bClose);
            this.mainPanel.Controls.Add(this.mainText);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(440, 28);
            this.mainPanel.TabIndex = 15;
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseDown);
            // 
            // bClose
            // 
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClose.FlatAppearance.BorderSize = 0;
            this.bClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.bClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.Image = ((System.Drawing.Image)(resources.GetObject("bClose.Image")));
            this.bClose.Location = new System.Drawing.Point(398, 0);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(42, 28);
            this.bClose.TabIndex = 0;
            this.bClose.TabStop = false;
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // mainText
            // 
            this.mainText.AutoSize = true;
            this.mainText.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainText.Location = new System.Drawing.Point(3, 8);
            this.mainText.Name = "mainText";
            this.mainText.Size = new System.Drawing.Size(78, 14);
            this.mainText.TabIndex = 0;
            this.mainText.Text = "MANAGE HUB";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.panel1.Location = new System.Drawing.Point(103, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 4);
            this.panel1.TabIndex = 0;
            // 
            // bSignIn
            // 
            this.bSignIn.BackColor = System.Drawing.Color.Transparent;
            this.bSignIn.FlatAppearance.BorderSize = 0;
            this.bSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSignIn.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSignIn.ForeColor = System.Drawing.Color.Gray;
            this.bSignIn.Location = new System.Drawing.Point(223, 33);
            this.bSignIn.Name = "bSignIn";
            this.bSignIn.Size = new System.Drawing.Size(113, 51);
            this.bSignIn.TabIndex = 0;
            this.bSignIn.TabStop = false;
            this.bSignIn.Text = "Sign In";
            this.bSignIn.UseVisualStyleBackColor = false;
            this.bSignIn.Click += new System.EventHandler(this.bSignIn_Click);
            // 
            // bSignUp
            // 
            this.bSignUp.BackColor = System.Drawing.Color.Transparent;
            this.bSignUp.FlatAppearance.BorderSize = 0;
            this.bSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSignUp.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSignUp.ForeColor = System.Drawing.Color.Gray;
            this.bSignUp.Location = new System.Drawing.Point(103, 33);
            this.bSignUp.Name = "bSignUp";
            this.bSignUp.Size = new System.Drawing.Size(113, 51);
            this.bSignUp.TabIndex = 0;
            this.bSignUp.TabStop = false;
            this.bSignUp.Text = "Sign Up";
            this.bSignUp.UseVisualStyleBackColor = false;
            this.bSignUp.Click += new System.EventHandler(this.bSignUp_Click);
            // 
            // signInPage
            // 
            this.signInPage.Controls.Add(this.signAlert2);
            this.signInPage.Controls.Add(this.signAlert1);
            this.signInPage.Controls.Add(this.panel3);
            this.signInPage.Controls.Add(this.cbSignIn);
            this.signInPage.Controls.Add(this.label6);
            this.signInPage.Controls.Add(this.signPsw);
            this.signInPage.Controls.Add(this.label7);
            this.signInPage.Controls.Add(this.signEmail);
            this.signInPage.Controls.Add(this.label10);
            this.signInPage.Location = new System.Drawing.Point(514, 94);
            this.signInPage.Name = "signInPage";
            this.signInPage.Size = new System.Drawing.Size(350, 350);
            this.signInPage.TabIndex = 20;
            // 
            // signAlert2
            // 
            this.signAlert2.BackColor = System.Drawing.Color.Red;
            this.signAlert2.Location = new System.Drawing.Point(31, 218);
            this.signAlert2.Name = "signAlert2";
            this.signAlert2.Size = new System.Drawing.Size(293, 2);
            this.signAlert2.TabIndex = 17;
            this.signAlert2.Visible = false;
            // 
            // signAlert1
            // 
            this.signAlert1.BackColor = System.Drawing.Color.Red;
            this.signAlert1.Location = new System.Drawing.Point(31, 147);
            this.signAlert1.Name = "signAlert1";
            this.signAlert1.Size = new System.Drawing.Size(293, 2);
            this.signAlert1.TabIndex = 16;
            this.signAlert1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.panel3.Location = new System.Drawing.Point(3, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(347, 4);
            this.panel3.TabIndex = 15;
            // 
            // cbSignIn
            // 
            this.cbSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cbSignIn.FlatAppearance.BorderSize = 0;
            this.cbSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSignIn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSignIn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbSignIn.Location = new System.Drawing.Point(28, 276);
            this.cbSignIn.Name = "cbSignIn";
            this.cbSignIn.Size = new System.Drawing.Size(297, 36);
            this.cbSignIn.TabIndex = 3;
            this.cbSignIn.Text = "Sign In";
            this.cbSignIn.UseVisualStyleBackColor = false;
            this.cbSignIn.Click += new System.EventHandler(this.CbSignIn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(26, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Password";
            // 
            // signPsw
            // 
            this.signPsw.BackColor = System.Drawing.Color.White;
            this.signPsw.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signPsw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.signPsw.Location = new System.Drawing.Point(29, 188);
            this.signPsw.Name = "signPsw";
            this.signPsw.Size = new System.Drawing.Size(297, 32);
            this.signPsw.TabIndex = 2;
            this.signPsw.UseSystemPasswordChar = true;
            this.signPsw.Click += new System.EventHandler(this.SignPsw_Click);
            this.signPsw.TextChanged += new System.EventHandler(this.SignPsw_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(26, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Email";
            // 
            // signEmail
            // 
            this.signEmail.BackColor = System.Drawing.Color.White;
            this.signEmail.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.signEmail.Location = new System.Drawing.Point(29, 117);
            this.signEmail.Name = "signEmail";
            this.signEmail.Size = new System.Drawing.Size(297, 32);
            this.signEmail.TabIndex = 1;
            this.signEmail.Click += new System.EventHandler(this.SignEmail_Click);
            this.signEmail.TextChanged += new System.EventHandler(this.SignEmail_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(125, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 32);
            this.label10.TabIndex = 1;
            this.label10.Text = "Sign In";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(63, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sign Up For Free";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(184, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = " ";
            // 
            // eMail
            // 
            this.eMail.BackColor = System.Drawing.Color.White;
            this.eMail.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.eMail.Location = new System.Drawing.Point(29, 152);
            this.eMail.Name = "eMail";
            this.eMail.Size = new System.Drawing.Size(297, 32);
            this.eMail.TabIndex = 3;
            this.eMail.Click += new System.EventHandler(this.EMail_Click);
            this.eMail.TextChanged += new System.EventHandler(this.EMail_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(27, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Email";
            // 
            // psw
            // 
            this.psw.BackColor = System.Drawing.Color.White;
            this.psw.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.psw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.psw.Location = new System.Drawing.Point(29, 216);
            this.psw.Name = "psw";
            this.psw.Size = new System.Drawing.Size(297, 32);
            this.psw.TabIndex = 4;
            this.psw.UseSystemPasswordChar = true;
            this.psw.Click += new System.EventHandler(this.Psw_Click);
            this.psw.TextChanged += new System.EventHandler(this.Psw_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(27, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password";
            // 
            // cbSignUp
            // 
            this.cbSignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.cbSignUp.FlatAppearance.BorderSize = 0;
            this.cbSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSignUp.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSignUp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbSignUp.Location = new System.Drawing.Point(28, 276);
            this.cbSignUp.Name = "cbSignUp";
            this.cbSignUp.Size = new System.Drawing.Size(297, 36);
            this.cbSignUp.TabIndex = 5;
            this.cbSignUp.Text = "Sign Up";
            this.cbSignUp.UseVisualStyleBackColor = false;
            this.cbSignUp.Click += new System.EventHandler(this.CbSignUp_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.panel2.Location = new System.Drawing.Point(3, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 4);
            this.panel2.TabIndex = 14;
            // 
            // alert3
            // 
            this.alert3.BackColor = System.Drawing.Color.Red;
            this.alert3.Location = new System.Drawing.Point(31, 182);
            this.alert3.Name = "alert3";
            this.alert3.Size = new System.Drawing.Size(293, 2);
            this.alert3.TabIndex = 15;
            this.alert3.Visible = false;
            // 
            // alert4
            // 
            this.alert4.BackColor = System.Drawing.Color.Red;
            this.alert4.Location = new System.Drawing.Point(31, 246);
            this.alert4.Name = "alert4";
            this.alert4.Size = new System.Drawing.Size(293, 2);
            this.alert4.TabIndex = 16;
            this.alert4.Visible = false;
            // 
            // signUpPage
            // 
            this.signUpPage.Controls.Add(this.alert4);
            this.signUpPage.Controls.Add(this.alert3);
            this.signUpPage.Controls.Add(this.alert2);
            this.signUpPage.Controls.Add(this.alert1);
            this.signUpPage.Controls.Add(this.label8);
            this.signUpPage.Controls.Add(this.panel2);
            this.signUpPage.Controls.Add(this.cbSignUp);
            this.signUpPage.Controls.Add(this.label5);
            this.signUpPage.Controls.Add(this.psw);
            this.signUpPage.Controls.Add(this.label4);
            this.signUpPage.Controls.Add(this.eMail);
            this.signUpPage.Controls.Add(this.label3);
            this.signUpPage.Controls.Add(this.lastName);
            this.signUpPage.Controls.Add(this.label2);
            this.signUpPage.Controls.Add(this.firstName);
            this.signUpPage.Controls.Add(this.label1);
            this.signUpPage.Location = new System.Drawing.Point(45, 94);
            this.signUpPage.Name = "signUpPage";
            this.signUpPage.Size = new System.Drawing.Size(350, 350);
            this.signUpPage.TabIndex = 18;
            // 
            // alert2
            // 
            this.alert2.BackColor = System.Drawing.Color.Red;
            this.alert2.Location = new System.Drawing.Point(189, 116);
            this.alert2.Name = "alert2";
            this.alert2.Size = new System.Drawing.Size(135, 2);
            this.alert2.TabIndex = 15;
            this.alert2.Visible = false;
            // 
            // alert1
            // 
            this.alert1.BackColor = System.Drawing.Color.Red;
            this.alert1.Location = new System.Drawing.Point(31, 116);
            this.alert1.Name = "alert1";
            this.alert1.Size = new System.Drawing.Size(135, 2);
            this.alert1.TabIndex = 14;
            this.alert1.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(184, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Last Name";
            // 
            // lastName
            // 
            this.lastName.BackColor = System.Drawing.Color.White;
            this.lastName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.lastName.Location = new System.Drawing.Point(187, 86);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(139, 32);
            this.lastName.TabIndex = 2;
            this.lastName.Click += new System.EventHandler(this.LastName_Click);
            this.lastName.TextChanged += new System.EventHandler(this.LastName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(25, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "First Name";
            // 
            // firstName
            // 
            this.firstName.BackColor = System.Drawing.Color.White;
            this.firstName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.firstName.Location = new System.Drawing.Point(29, 86);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(139, 32);
            this.firstName.TabIndex = 1;
            this.firstName.Click += new System.EventHandler(this.FirstName_Click);
            this.firstName.TextChanged += new System.EventHandler(this.FirstName_TextChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::manageHub.Properties.Resources._55738_O8C8V0_13;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(440, 634);
            this.Controls.Add(this.signInPage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.signUpPage);
            this.Controls.Add(this.bSignIn);
            this.Controls.Add(this.bSignUp);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.signInPage.ResumeLayout(false);
            this.signInPage.PerformLayout();
            this.signUpPage.ResumeLayout(false);
            this.signUpPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Label mainText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bSignIn;
        private System.Windows.Forms.Button bSignUp;
        private System.Windows.Forms.Panel signInPage;
        private System.Windows.Forms.Panel signAlert2;
        private System.Windows.Forms.Panel signAlert1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button cbSignIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox signPsw;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox eMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox psw;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cbSignUp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel alert3;
        private System.Windows.Forms.Panel alert4;
        private System.Windows.Forms.Panel signUpPage;
        private System.Windows.Forms.Panel alert2;
        private System.Windows.Forms.Panel alert1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstName;
        public System.Windows.Forms.TextBox signEmail;
    }
}

