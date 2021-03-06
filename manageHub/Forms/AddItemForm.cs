﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace manageHub
{
    public partial class AddItemForm : Form
    {
        private DashBoardForm dash;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //--------------------------------------DataBase---------------------------------------------
        OleDbConnection conn = new OleDbConnection("Provider =  Microsoft.ACE.OLEDB.12.0;Data Source = ../../Database/manageHubDb.accdb");
        //-------------------------------------------------------------------------------------------

        public AddItemForm(DashBoardForm dash)
        {
            InitializeComponent();
            this.dash = dash;
        }

        private void AddItemForm_Load(object sender, EventArgs e)
        {
            this.AcceptButton = bAddItem;
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
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
                    this.Close();
                }
                else
                {
                    if (dash.addWasClicked == true)
                    {
                        string item = itemName.Text.Trim().ToString();
                        if (dash.todoList.Items.Contains(item))
                        {
                            MessageBox.Show("This item already exists in the to-do list.", "Manage Hub", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        try
                        {
                            conn.Open();
                            OleDbCommand cmd = new OleDbCommand("INSERT INTO todolist ([itemName]) VALUES (@itemName)", conn);
                            cmd.Parameters.AddWithValue("@itemName", item);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Item successfully added", "İnfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.ToString());
                        }
                        finally
                        {
                            conn.Close();
                            dash.addWasClicked = false;
                            this.Close();
                        }
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
                            dash.roleBox.Items.Add(item);
                            dash.add2WasClicked = false;
                            this.Close();
                        }
                    }
                }
            }
        }

        private void BClosee_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddItemForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            addItemOnToDoList();
        }

        private void addItemOnToDoList()
        {
            string item = null;
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT [itemName] FROM todolist", conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    item = reader["itemName"].ToString();
                    if (dash.todoList.Items.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        dash.todoList.Items.Add(reader["itemName"].ToString());
                    }
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
}
