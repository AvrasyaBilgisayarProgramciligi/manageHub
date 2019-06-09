using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace manageHub
{
    public partial class LoginForm : Form
    {
        //-------------------------------------Attributes-------------------------------------------
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private List<TextBox> myTextBoxes = new List<TextBox>();
        private List<Panel> myPanels = new List<Panel>();
        private List<TextBox> mySignTextBoxes = new List<TextBox>();
        private List<Panel> mySignPanels = new List<Panel>();
        //-------------------------------------------------------------------------------------------

        //--------------------------------------DataBase---------------------------------------------
        OleDbConnection conn = new OleDbConnection("Provider =  Microsoft.ACE.OLEDB.12.0;Data Source = ../../Database/manageHubDb.accdb");
        //-------------------------------------------------------------------------------------------

        public LoginForm()
        {
            InitializeComponent();
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public bool Connection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("https://www.google.com/"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            this.AcceptButton = cbSignUp;

            myTextBoxes.Add(firstName);
            myTextBoxes.Add(lastName);
            myTextBoxes.Add(eMail);
            myTextBoxes.Add(psw);

            myPanels.Add(alert1);
            myPanels.Add(alert2);
            myPanels.Add(alert3);
            myPanels.Add(alert4);

            mySignTextBoxes.Add(signEmail);
            mySignTextBoxes.Add(signPsw);

            mySignPanels.Add(signAlert1);
            mySignPanels.Add(signAlert2);

        }
        
        private void bSignUp_Click(object sender, EventArgs e)
        {
            this.AcceptButton = cbSignUp;

            if (signUpPage.Left == 514)
            {
                signInPage.Visible = false;
                signInPage.Left = 514;

                signUpPage.Visible = false;
                signUpPage.Left = 43;
                signUpPage.Visible = true;
                signUpPage.Refresh();

                panel1.Left = bSignUp.Left;
                panel1.Width = bSignUp.Width;
            }

        }

        private void bSignIn_Click(object sender, EventArgs e)
        {

            this.AcceptButton = cbSignIn;

            if (signInPage.Left == 514)
            {
                signUpPage.Visible = false;
                signUpPage.Left = 514;

                signInPage.Visible = false;
                signInPage.Left = 43;
                signInPage.Visible = true;
                signInPage.Refresh();

                panel1.Left = bSignIn.Left;
                panel1.Width = bSignIn.Width;
            }
        }

        private void CbSignUp_Click(object sender, EventArgs e)
        {

            if (!Connection())
            {
                DialogResult result;

                result = MessageBox.Show("Please check your internet connection and try again", "Connection Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    this.Close();
                    Application.Restart();
                }
                else if (result == DialogResult.Cancel)
                {
                    this.Close();
                }
            }

            if (myTextBoxes[0].Text.Trim().ToString().Equals("") || myTextBoxes[1].Text.Trim().ToString().Equals("") ||
                myTextBoxes[2].Text.Trim().ToString().Equals("") || myTextBoxes[3].Text.Trim().ToString().Equals(""))
            {

                for (int i = 0; i < myTextBoxes.Count; i++)
                {
                    if (myTextBoxes[i].Text.ToString().Trim().Equals(""))
                    {
                        myPanels[i].Visible = true;
                    }
                }

                MessageBox.Show("Information boxes cannot be left blank", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO accountInfos ([firstName], [lastName], [eMail], [psw]) VALUES (@firstName, @lastName, @eMail, @psw)", conn);
                    cmd.Parameters.AddWithValue("@firstName", firstName.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@lastName", lastName.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@eMail", eMail.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@psw", psw.Text.ToString().Trim());
                    cmd.ExecuteNonQuery();

                    signUpPage.Visible = false;
                    signUpPage.Left = 514;

                    signInPage.Visible = false;
                    signInPage.Left = 43;
                    signInPage.Visible = true;
                    signInPage.Refresh();

                    panel1.Left = bSignIn.Left;
                    panel1.Width = bSignIn.Width;

                    MessageBox.Show("Successful registration", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.ToString());
                    MessageBox.Show("Oops something went wrong", "SignUp Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {

                    conn.Close();

                }
            }
        }

        private void CbSignIn_Click(object sender, EventArgs e)
        {

            if (!Connection())
            {
                DialogResult result;

                result = MessageBox.Show("Please check your internet connection and try again", "Connection Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    this.Close();
                    Application.Restart();
                }
                else if (result == DialogResult.Cancel)
                {
                    this.Close();
                }
            }

            if (mySignTextBoxes[0].Text.Trim().ToString().Equals("") || mySignTextBoxes[1].Text.Trim().ToString().Equals(""))
            {

                for (int i = 0; i < mySignTextBoxes.Count; i++)
                {
                    if (mySignTextBoxes[i].Text.Trim().ToString().Equals(""))
                    {
                        mySignPanels[i].Visible = true;
                    }
                }

                MessageBox.Show("Information boxes cannot be left blank", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM accountInfos WHERE [eMail] = @eMail AND [psw] = @psw", conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@eMail", signEmail.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@psw", signPsw.Text.ToString().Trim());
                    int exst = (int)cmd.ExecuteScalar();

                    if (exst != 0)
                    {
                        MessageBox.Show("Successful login", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DashBoardForm dashBoard = new DashBoardForm(this);
                        this.Hide();
                        dashBoard.Show();
                        this.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Email or password is wrong", "Incorrect information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        signEmail.Clear();
                        signPsw.Clear();
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.ToString());
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        private void FirstName_Click(object sender, EventArgs e)
        {
            alert1.Hide();
        }

        private void LastName_Click(object sender, EventArgs e)
        {
            alert2.Hide();
        }

        private void EMail_Click(object sender, EventArgs e)
        {
            alert3.Hide();
        }

        private void Psw_Click(object sender, EventArgs e)
        {
            alert4.Hide();
        }

        private void SignEmail_Click(object sender, EventArgs e)
        {
            signAlert1.Hide();
        }

        private void SignPsw_Click(object sender, EventArgs e)
        {
            signAlert2.Hide();
        }

        private void FirstName_TextChanged(object sender, EventArgs e)
        {
            alert1.Hide();
        }

        private void LastName_TextChanged(object sender, EventArgs e)
        {
            alert2.Hide();
        }

        private void EMail_TextChanged(object sender, EventArgs e)
        {
            alert3.Hide();
        }

        private void Psw_TextChanged(object sender, EventArgs e)
        {
            alert4.Hide();
        }

        private void SignEmail_TextChanged(object sender, EventArgs e)
        {
            signAlert1.Hide();
        }

        private void SignPsw_TextChanged(object sender, EventArgs e)
        {
            signAlert2.Hide();
        }
    }
}