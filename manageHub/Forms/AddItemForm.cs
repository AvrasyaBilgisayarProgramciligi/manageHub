using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace manageHub
{
    public partial class AddItemForm : Form
    {
        private DashBoardForm dash;

        //--------------------------------------DataBase---------------------------------------------
        OleDbConnection conn = new OleDbConnection("Provider =  Microsoft.ACE.OLEDB.12.0;Data Source = manageHubDb.accdb");
        //-------------------------------------------------------------------------------------------

        public AddItemForm(DashBoardForm dash)
        {
            InitializeComponent();
            this.dash = dash;
        }

        private void BAddItem_Click(object sender, EventArgs e)
        {
            if (itemName.Text.Trim().ToString().Equals(""))
            {
                MessageBox.Show("Item name cannot be empty", "Fill gaps", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (dash.todoList.Items.Count >= 5)
                {
                    //TODO: Add option need a word limit
                    MessageBox.Show("You work too hard, we put a restriction on here for thinking about you.", "Calm Down!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (dash.addWasClicked == true)
                    {
                        string item = itemName.Text.Trim().ToString();
                        dash.todoList.Items.Add(item);
                        dash.addWasClicked = false;
                        this.Close();
                    }
                    else if (dash.add2WasClicked == true)
                    {
                        string item = itemName.Text.Trim().ToString();

                        try
                        {
                            conn.Open();
                            OleDbCommand cmd = new OleDbCommand("INSERT INTO roles ([roleName]) VALUES (@roleName)", conn);
                            cmd.Parameters.AddWithValue("@roleName", item);
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.ToString());
                        }
                        finally
                        {
                            conn.Close();
                        }

                        dash.roleBox.Items.Add(item);
                        dash.add2WasClicked = false;
                        this.Close();
                    }
                }
            }
        }

        private void BClosee_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
