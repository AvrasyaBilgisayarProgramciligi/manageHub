using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace manageHub
{
    public partial class DashBoardForm : Form
    {

        //-------------------------------------Attributes-------------------------------------------
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        Timer t = new Timer();
        CultureInfo cultureInfo = CultureInfo.CurrentUICulture;
        private string pName = "";
        private string pLastName = "";
        public bool addWasClicked = false;
        public bool add2WasClicked = false;
        //-------------------------------------------------------------------------------------------

        //-----------------------------------Forms & Classes-----------------------------------------
        private Classes.Manager manager;
        private Classes.Programmer programmer;
        private LoginForm login;
        //ChangeCityForm changeCityForm = new ChangeCityForm();
        //-------------------------------------------------------------------------------------------

        //--------------------------------------DataBase---------------------------------------------
        OleDbConnection conn = new OleDbConnection("Provider =  Microsoft.ACE.OLEDB.12.0;Data Source = manageHubDb.accdb");
        //-------------------------------------------------------------------------------------------

        //-----------------------------------------API-----------------------------------------------
        private const string ApiKeyWeather = "fe9447ea77fff3fa6d1d4a713b6ea456";
        private string connect = "https://api.openweathermap.org/data/2.5/forecast?q=Trabzon,tr&mode=xml&units=metric&appid=" + ApiKeyWeather;
        //-------------------------------------------------------------------------------------------

        public DashBoardForm(LoginForm login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void DashBoardForm_Load(object sender, EventArgs e)
        {

            //---------------------------------API's & Time functions-----------------------------------
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
            d_Tick();

            weatherAPI();
            dateTime();
            //-------------------------------------------------------------------------------------------

            //------------------------------------Data functions-----------------------------------------
            SplineChart();
            AddItemStaffBox();
            AddRoleComboBox();
            CallRoles();
            //-------------------------------------------------------------------------------------------

            //------------------------------------Data selections----------------------------------------
            staffBox.SelectedIndex = 0;
            roleComboBox.SelectedIndex = 0;
            MainTab.SelectedIndex = 0;
            //-------------------------------------------------------------------------------------------

            //---------------------------------Testing Inheritance---------------------------------------

            /*programmer = new Classes.Programmer("Orhan", "Turğul", "IT", 100, "Java");
            programmer.addLanguage("Python");
            programmer.addLanguage("JS");
            programmer.addLanguage("SQL");
            Console.WriteLine(programmer.showInfos());*/

            /*manager = new Classes.Manager("Orhan", "Tuğrul", "Manager", 1500, 100);
            Console.WriteLine(manager.showInfos());;*/

            /*Classes.Manager manager = new Classes.Manager("Orhan", "ŞAHİN", "Manager", 1500, 100); 
            Console.WriteLine("Name: "+ manager.getName());
            Console.WriteLine("Surname: "+ manager.getSurname());
            Console.WriteLine("Depart: "+ manager.getDepart());
            Console.WriteLine("Salary: "+ manager.getSalary());
            Console.WriteLine("Respon: "+ manager.getRespon());*/

            //-------------------------------------------------------------------------------------------
        }

        /*if (staffBox.Items.Count == 0 || roleComboBox.Items.Count == 0)
        {

        }
        else
        {
            staffBox.SelectedIndex = 0;
            roleComboBox.SelectedIndex = 0;
        }*/

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to exit Manage Hub?", "Manage Hub", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {

            }
        }

        private void dateTime()
        {
            int hours = DateTime.Now.Hour;
            //Console.WriteLine(hours); testing clock (fixed)

            string eMail = login.signEmail.Text.ToString().Trim();
            string name = null;

            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM accountInfos WHERE [eMail] = @eMail", conn);
                cmd.Parameters.AddWithValue("@eMail", eMail);
                OleDbDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    name = read["firstName"].ToString();
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                MessageBox.Show("Oops something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            if (hours < 4 || hours > 22)
            {
                string[] msg = welcomeBox.Text.Split(',');
                msg[0] = "Good Night";
                msg[1] = name.ToString().Trim();
                welcomeBox.Text = msg[0] + ", " + msg[1];
            }
            else if (hours < 12)
            {
                string[] msg = welcomeBox.Text.Split(',');
                msg[0] = "Good Morning";
                msg[1] = name.ToString().Trim();
                welcomeBox.Text = msg[0] + ", " + msg[1];
            }
            else if (hours < 18)
            {
                string[] msg = welcomeBox.Text.Split(',');
                msg[0] = "Good Afternoon";
                msg[1] = name.ToString().Trim();
                welcomeBox.Text = msg[0] + ", " + msg[1];
            }
            else if (hours < 22)
            {
                string[] msg = welcomeBox.Text.Split(',');
                msg[0] = "Good Evening";
                msg[1] = name.ToString().Trim();
                welcomeBox.Text = msg[0] + ", " + msg[1];
            }
        }

        public void weatherAPI()
        {
            decimal celcius = 0;
            try
            {
                XDocument weather = XDocument.Load(connect);
                var hot = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                if (cultureInfo.Name.Equals("tr-TR"))
                {
                    celcius = decimal.Parse(hot.Replace('.', ','));
                }
                else
                {
                    celcius = decimal.Parse(hot);
                }

                var humi = weather.Descendants("humidity").ElementAt(0).Attribute("value").Value;
                double humie = double.Parse(humi.ToString());
                labelHumi.Text = string.Concat("%" + (humie));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Something went wrong", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.OK;
                Application.Exit();
            }

            //int lastCelcius = Convert.ToDecimal(celcius);
            decimal celciusLast = Math.Ceiling(celcius);
            Console.WriteLine("Weather status " + celciusLast); //check weather status
            if (celciusLast < 10)
            {
                labelHot.Text = string.Concat("0" + (celciusLast).ToString("#"));
            }
            else
            {
                labelHot.Text = string.Concat((celciusLast).ToString("#"));
            }

            if (celciusLast < 15)
            {
                weatherSymbol.Location = new Point(182, 32);
                weatherSymbol.Image = global::manageHub.Properties.Resources.baseline_cloud_white_48dp;
                ideaBox.Text = "Weather looks cool,\nYou'd better dress up.";
            }
            else
            {
                weatherSymbol.Image = global::manageHub.Properties.Resources.baseline_wb_sunny_white_48dp;
                ideaBox.Font = new Font("Calibri", 12, FontStyle.Bold);
                ideaBox.Text = "Weather seems hot,\nWhat are you waiting for to go outside?";
            }
        }

        private void t_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            string time = "";

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            timer.Text = time;
        }

        private void d_Tick()
        {
            int dd = DateTime.Now.Day;
            int mm = DateTime.Now.Month;
            int yy = DateTime.Now.Year;

            string date = "";

            if (dd < 10)
            {
                date += "0" + dd;
            }
            else
            {
                date += dd;
            }
            date += "/";

            if (mm < 10)
            {
                date += "0" + mm;
            }
            else
            {
                date += mm;
            }
            date += "/";
            date += yy;

            day.Text = date;
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            AddItemForm addItemForm = new AddItemForm(this);
            addWasClicked = true;
            addItemForm.ShowDialog();
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            foreach (string item in todoList.CheckedItems.OfType<string>().ToList())
            {
                todoList.Items.Remove(item);
                deleteItem.Visible = false;
            }

        }

        private void TodoList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!(todoList.GetItemChecked(e.Index)))
            {
                deleteItem.Visible = true;
            }
            else
            {
                deleteItem.Visible = false;
            }
        }

        private void SplineChart()
        {
            Random rndm = new Random();

            string[] seasons = { "January", "February", "March", "April", "May", "June", "July", "August",
                "September", "October", "November", "December"};

            productChart.ChartAreas[0].AxisX.IsMarginVisible = false;

            this.productChart.Series.Clear();
            this.productChart.Titles.Add("Balance");

            Series series = this.productChart.Series.Add("Products Sold");
            Series seriess = this.productChart.Series.Add("Personnel");

            series.BorderWidth = 2;
            seriess.BorderWidth = 2;

            series.ChartType = SeriesChartType.Spline;
            seriess.ChartType = SeriesChartType.Spline;

            foreach (string season in seasons)
            {
                series.Points.AddXY(season, rndm.NextDouble() * 15);
            }

            /*series.Points.AddXY("January", 18);
            series.Points.AddXY("February", 16);
            series.Points.AddXY("March", 10);
            series.Points.AddXY("April", 20);
            series.Points.AddXY("May", 21);
            series.Points.AddXY("June", 14);
            series.Points.AddXY("July", 9);
            series.Points.AddXY("August", 5);
            series.Points.AddXY("September", 3);
            series.Points.AddXY("October", 5);
            series.Points.AddXY("November", 10);
            series.Points.AddXY("December", 5);*/

            seriess.Points.AddY(5);
            seriess.Points.AddY(5);
            seriess.Points.AddY(6);
            seriess.Points.AddY(6);
            seriess.Points.AddY(6);
            seriess.Points.AddY(8);
            seriess.Points.AddY(8);
            seriess.Points.AddY(8);
            seriess.Points.AddY(5);
            seriess.Points.AddY(7);
            seriess.Points.AddY(6);
            seriess.Points.AddY(9);
        }


        private void SaveChart_Click(object sender, EventArgs e)
        {
            String s = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + "\\Chart.png";
            productChart.SaveImage(s, ChartImageFormat.Png);

            MessageBox.Show("Chart saved successfully\nPath: " + s, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddItemStaffBox()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM personnel WHERE [pName] AND [pLastName] AND [pRole] = @pRole", conn);
                cmd.Parameters.AddWithValue("@pRole", "Programmer");
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(pName + " " + pLastName);
                    staffBox.Items.Add(reader[1].ToString() + " " + reader[2].ToString());
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                MessageBox.Show("Oops something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void StaffBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (staffBox.SelectedItem == null)
            {
                return;
            }
            else
            {
                nameLabel.Text = staffBox.SelectedItem.ToString().Substring(0, staffBox.SelectedItem.ToString().LastIndexOf(' ')).Trim();
                surnameLabel.Text = staffBox.SelectedItem.ToString().Substring(staffBox.SelectedItem.ToString().LastIndexOf(' ')).Trim();
            }


            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT pDepart, pSalary, pRole FROM personnel WHERE [pName] = @pName", conn);
                cmd.Parameters.AddWithValue("@pName", staffBox.SelectedItem.ToString().Substring(0, staffBox.SelectedItem.ToString().LastIndexOf(' ')));
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    departLabel.Text = "Depart: " + reader["pDepart"].ToString();
                    salaryLabel.Text = "Salary: $" + reader["pSalary"].ToString();
                    rolesLabel.Text = "Roles: " + reader["pRole"].ToString();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void UpdateStaffBox()
        {
            staffBox.Items.Clear();
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT pName, pLastName FROM personnel WHERE [pRole] = @pRole", conn);
                cmd.Parameters.AddWithValue("@pRole", roleComboBox.Text);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["pName"].ToString() + " " + reader["pLastName"].ToString());
                    staffBox.Items.Add(reader["pName"].ToString() + " " + reader["pLastName"].ToString());
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                MessageBox.Show("Oops something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void AddRoleComboBox()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM roles", conn);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string role = reader["roleName"].ToString();

                    if (roleComboBox.Items.Contains(role))
                    {
                        continue;
                    }
                    else
                    {
                        roleComboBox.Items.Add(role);
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

        private void RoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT pName, pLastName FROM personnel WHERE [pRole] = @pRole", conn);
                cmd.Parameters.AddWithValue("@pRole", roleComboBox.GetItemText(roleComboBox.SelectedItem));
                OleDbDataReader reader = cmd.ExecuteReader();
                staffBox.Items.Clear();

                while (reader.Read())
                {
                    staffBox.Items.Add(reader["pName"].ToString() + " " + reader["pLastName"].ToString());
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

        private void RoleComboBox_MouseMove(object sender, MouseEventArgs e)
        {
            roleComboBox.Items.Clear();
            AddRoleComboBox();
        }

        private void AddNewRole_Click(object sender, EventArgs e)
        {
            AddItemForm addItemForm = new AddItemForm(this);
            add2WasClicked = true;
            addItemForm.ShowDialog();
        }

        private void AddNewRole_MouseEnter(object sender, EventArgs e)
        {
            this.addNewRole.Font = new Font("Arial", 9, FontStyle.Underline);
        }

        private void AddNewRole_MouseLeave(object sender, EventArgs e)
        {
            this.addNewRole.Font = new Font("Arial", 9, FontStyle.Regular);
        }

        private void DeleteRole_Click(object sender, EventArgs e)
        {
            if(roleBox.CheckedItems.Count < 1)
            {
                return;
            }
            DialogResult result;
            result = MessageBox.Show("Are you sure want to delete the selected roles?", "Manage Hub", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (string item in roleBox.CheckedItems.OfType<string>().ToList())
                {
                    try
                    {
                        conn.Open();
                        OleDbCommand cmd = new OleDbCommand("DELETE FROM roles WHERE [roleName] = @roleName", conn);
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
                    roleBox.Items.Remove(item);
                }
            }
            else
            {
                return;
            }
        }

        private void DeleteRole_MouseEnter(object sender, EventArgs e)
        {
            this.deleteRole.Font = new Font("Arial", 9, FontStyle.Underline);
        }

        private void DeleteRole_MouseLeave(object sender, EventArgs e)
        {
            this.deleteRole.Font = new Font("Arial", 9, FontStyle.Regular);
        }

        private void CallRoles()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM roles", conn);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    roleBox.Items.Add(reader["roleName"].ToString());
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

        private void AddPerson_Click(object sender, EventArgs e)
        {

            if (roleBox.CheckedItems.Count > 1)
            {
                MessageBox.Show("You can't add 2 role", "Manage Hub", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (addPersonName.Text.ToString().Trim().Equals("") || addPersonLastName.Text.ToString().Trim().Equals("") || addPersonDepart.Text.ToString().Trim().Equals("") ||
                addPersonSalary.Text.ToString().Trim().Equals("") || roleBox.SelectedIndex == -1)
            {
                MessageBox.Show("Boxes cannot be left blank", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO personnel ([pName], [pLastName], [pDepart], [pSalary], [pRole]) VALUES (@pName, @pLastName, @pDepart, @pSalary, @pRole)", conn);
                cmd.Parameters.AddWithValue("@pName", addPersonName.Text.Trim());
                cmd.Parameters.AddWithValue("@pLastName", addPersonLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@pDepart", addPersonDepart.Text.Trim());
                cmd.Parameters.AddWithValue("@pSalary", addPersonSalary.Text.Trim());
                foreach (object checkedItems in roleBox.CheckedItems)
                {
                    string chckedItem = checkedItems.ToString();
                    cmd.Parameters.AddWithValue("@pRole", chckedItem);
                }
                cmd.ExecuteNonQuery();

                MessageBox.Show("Person successfully added", "İnfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
            finally
            {
                conn.Close();
                UpdateStaffBox();
            }
        }
    }
}