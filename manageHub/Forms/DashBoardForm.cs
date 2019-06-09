using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
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

        private List<TextBox> myTextBoxes = new List<TextBox>();
        private List<Panel> myPanels = new List<Panel>();
        //-------------------------------------------------------------------------------------------

        //-----------------------------------Forms & Classes-----------------------------------------
        private LoginForm login;
        //ChangeCityForm changeCityForm = new ChangeCityForm();
        //-------------------------------------------------------------------------------------------

        //--------------------------------------DataBase---------------------------------------------
        OleDbConnection conn = new OleDbConnection("Provider =  Microsoft.ACE.OLEDB.12.0;Data Source = ../../Database/manageHubDb.accdb");
        //-------------------------------------------------------------------------------------------

        //----------------------------------------API's----------------------------------------------
        private const string ApiKeyWeather = "fe9447ea77fff3fa6d1d4a713b6ea456";
        private string connectWeatherKey = "https://api.openweathermap.org/data/2.5/forecast?q=Trabzon,tr&mode=xml&units=metric&appid=" + ApiKeyWeather;
        private string connectExchangeKey = "https://blockchain.info/ticker";
        //-------------------------------------------------------------------------------------------

        public DashBoardForm(LoginForm login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void DashBoardForm_Load(object sender, EventArgs e)
        {

            deleteItem.Visible = false;

            //---------------------------------API's & Time functions-----------------------------------
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
            d_Tick();

            exchangeAPI();
            weatherAPI();
            dateTime();
            //-------------------------------------------------------------------------------------------

            //------------------------------------Data functions-----------------------------------------
            SplineChart();
            AddItemStaffBox();
            AddRoleComboBox();
            AddRoleComboBox2();
            CallRoles();
            pieChart();
            addItemOnToDoList();
            //-------------------------------------------------------------------------------------------

            //------------------------------------Data selections----------------------------------------
            checkBoxes();
            checkMoneyUnit();
            //-------------------------------------------------------------------------------------------

            //------------------------------------Other functions----------------------------------------
            MainTab.SelectedIndex = 0;
            makeIdea();
            //-------------------------------------------------------------------------------------------

            //------------------------------------List functions-----------------------------------------

            myTextBoxes.Add(addPersonName);
            myTextBoxes.Add(addPersonLastName);
            myTextBoxes.Add(addPersonDepart);
            myTextBoxes.Add(addPersonSalary);
            myTextBoxes.Add(addPersonMail);
            myTextBoxes.Add(addPersonAdress);

            myPanels.Add(alert1);
            myPanels.Add(alert2);
            myPanels.Add(alert3);
            myPanels.Add(alert4);
            myPanels.Add(alert5);
            myPanels.Add(alert6);

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

        private void checkBoxes()
        {
            if (roleComboBox.Items.Count > 0)
            {
                roleComboBox.SelectedIndex = 0;
                staffBox.SelectedIndex = 0;
            }
            else
            {
                return;
            }

            if (roleComboBox2.Items.Count > 0)
            {
                roleComboBox2.SelectedIndex = 0;
            }
            else
            {
                return;
            }
        }

        private void checkMoneyUnit()
        {
            if (cultureInfo.Name.Equals("tr-TR"))
            {
                moneyUnit.SelectedIndex = 0;
            }
            else if (cultureInfo.Name.Equals("en-US"))
            {
                moneyUnit.SelectedIndex = 1;
            }
            else
            {
                moneyUnit.SelectedIndex = 2;
            }
        }

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
                return;
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
                welcomeBox.Text = msg[0] + ",\n" + msg[1];
            }
            else if (hours < 12)
            {
                string[] msg = welcomeBox.Text.Split(',');
                msg[0] = "Good Morning";
                msg[1] = name.ToString().Trim();
                welcomeBox.Text = msg[0] + ",\n" + msg[1];
            }
            else if (hours < 18)
            {
                string[] msg = welcomeBox.Text.Split(',');
                msg[0] = "Good Afternoon";
                msg[1] = name.ToString().Trim();
                welcomeBox.Text = msg[0] + ",\n" + msg[1];
            }
            else if (hours < 22)
            {
                string[] msg = welcomeBox.Text.Split(',');
                msg[0] = "Good Evening";
                msg[1] = name.ToString().Trim();
                welcomeBox.Text = msg[0] + ",\n" + msg[1];
            }
        }

        private void exchangeAPI()
        {
            try
            {
                WebClient client = new WebClient();
                var data = client.DownloadString(connectExchangeKey);
                JObject currencies = JObject.Parse(data);
                double currency = Convert.ToDouble(currencies.SelectToken("USD.15m"));
                bitcoinToDolar.Text = Convert.ToString(currency * 10);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }

            try
            {
                WebClient client = new WebClient();
                var data = client.DownloadString(connectExchangeKey);
                JObject currencies = JObject.Parse(data);
                double currency = Convert.ToDouble(currencies.SelectToken("EUR.15m"));
                bitcoinToEuro.Text = Convert.ToString(currency * 10);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }

            try
            {
                WebClient client = new WebClient();
                var data = client.DownloadString(connectExchangeKey);
                JObject currencies = JObject.Parse(data);
                double currency = Convert.ToDouble(currencies.SelectToken("GBP.15m"));
                bitcoinToPound.Text = Convert.ToString(currency * 10);
                Console.WriteLine(Convert.ToString(currency * 10));
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        private void RefreshExchange_Click(object sender, EventArgs e)
        {
            exchangeAPI();
        }

        public void weatherAPI()
        {
            decimal celcius = 0;
            try
            {
                XDocument weather = XDocument.Load(connectWeatherKey);
                var valueTemp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                if (cultureInfo.Name.Equals("tr-TR"))
                {
                    celcius = decimal.Parse(valueTemp.Replace('.', ','));
                }
                else
                {
                    celcius = decimal.Parse(valueTemp);
                }

                var valueHumi = weather.Descendants("humidity").ElementAt(0).Attribute("value").Value;
                double humie = double.Parse(valueHumi.ToString());
                labelHumi.Text = string.Concat("%" + (humie));
            }
            catch (Exception exc)
            {
                DialogResult result;
                Console.WriteLine(exc.ToString());
                result = MessageBox.Show("Something went wrong", "Manage Hub", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    weatherAPI(); // Need a test
                }
                else
                {
                    Application.Exit();
                }
            }

            //int lastCelcius = Convert.ToDecimal(celcius);
            decimal celciusLast = Math.Ceiling(celcius);
            Console.WriteLine("Weather status " + celciusLast); //Check weather status
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
            }
            else
            {
                weatherSymbol.Image = global::manageHub.Properties.Resources.baseline_wb_sunny_white_48dp;
            }
        }

        private void makeIdea()
        {
            List<string> ideaList = new List<string>();
            ideaList.Add("It's not bad idea to add something on to-do list.");
            ideaBox.Text = ideaList[0];
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
            string year = Convert.ToString(yy);
            year = year.Substring(2, 2);
            date += year;

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
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM todolist WHERE [itemName] = @itemName", conn);
                    cmd.Parameters.AddWithValue("@itemName", item);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.ToString());
                }
                finally
                {
                    conn.Close();
                    deleteItem.Visible = false;
                    todoList.Items.Clear();
                    addItemOnToDoList();
                }
            }

        }

        private void TodoList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            todoList.SetSelected(todoList.SelectedIndex, false);

            if (!(todoList.GetItemChecked(e.Index)))
            {
                deleteItem.Visible = true;
            }
            else
            {
                deleteItem.Visible = false;
            }
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
                    if (todoList.Items.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        todoList.Items.Add(reader["itemName"].ToString());
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

        string[] seasons = new string[6];
        private void SplineChart()
        {
            //Series series = new Series();
            //Series seriess = new Series();
            //productChart.Titles.Add("Company Expenditure Average");

            string[] seasons = { "January", "February", "March", "April", "May", "June", "July", "August",
                "September", "October", "November", "December"};

            //productChart.ChartAreas[0].AxisX.Minimum = 12;
            //productChart.ChartAreas[0].AxisX.

            /*seasons[0] = "January" + "-" + "February";
            seasons[1] = "March" + "-" + "April";
            seasons[2] = "May" + "-" + "June";
            seasons[3] = "July" + "-" + "August";
            seasons[4] = "September" + "-" + "October";
            seasons[5] = "November" + "-" + "December";*/

            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT pID FROM personnel", conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                int personnelCount = 0;
                while (reader.Read())
                {
                    personnelCount += 1;
                    //seriess.Points.AddY(personnelCount);
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

            //personnelRoleChart
        }

        //---------------------------------------Chart 2---------------------------------------------

        private void pieChart()
        {
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0:n0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            pieChart1.Series = new LiveCharts.SeriesCollection();

            PieSeries pie = new PieSeries();
            pie.Title = "Programmer";
            pie.Values = new ChartValues<double> { Convert.ToDouble(1) };
            pie.DataLabels = true;
            pie.LabelPoint = labelPoint;
            pieChart1.Series.Add(pie);


            PieSeries pie1 = new PieSeries();
            pie1.Title = "Staff";
            pie1.Values = new ChartValues<double> { Convert.ToDouble(2) };
            pie1.DataLabels = true;
            pie1.LabelPoint = labelPoint;
            pieChart1.Series.Add(pie1);
            pieChart1.LegendLocation = LegendLocation.Right;

            /*PieSeries pie2 = new PieSeries();
            pie2.Title = "Yellow";
            pie2.Values = new ChartValues<double> { Convert.ToDouble(40) };
            pie2.DataLabels = true;
            pie2.LabelPoint = labelPoint;
            pieChart1.Series.Add(pie2);*/

        }

        /*private void PersonnelRoleChart_Customize(object sender, EventArgs e)
        {
            List<string> roles = new List<string>();
            List<int> points = new List<int>();
            points.Add(5);
            points.Add(10);
            int low = 10;
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT pRole FROM personnel", conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roles.Add(reader["pRole"].ToString())
                    low--;
                }

                for (int i = 0; i < roles.Count; i++)
                {
                    Series series = this.personnelRoleChart.Series.Add(roles[i]);
                    series.ChartType = SeriesChartType.Pie;
                    series.Points.Add(points[i]);
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

            /*int i = 0;
            bool exit = true;

            try
            {
                Console.WriteLine(roles[i]);
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM personnel WHERE [pRole] = @pRole", conn);
                cmd.Parameters.AddWithValue("@pRole", roles[i]);
                OleDbDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    //Console.WriteLine(reader["pRole"].ToString());
                    
                }

                if ((i + 1) >= roles.Count)
                {
                    exit = false;
                }
                i++;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
            finally
            {
                conn.Close();
            }
            while (exit)
            {
                
            }
        }*/

        private void SaveChart_Click(object sender, EventArgs e)
        {
            String s = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + "\\Chart.png";
            productChart.SaveImage(s, ChartImageFormat.Png);

            MessageBox.Show("Chart saved successfully\nPath: " + s, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddItemStaffBox()
        {
            staffBox.Items.Clear();
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT pName, pLastName FROM personnel WHERE [pRole] = @pRole", conn);
                cmd.Parameters.AddWithValue("@pRole", roleComboBox.GetItemText(roleComboBox.SelectedItem));
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
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

        private void StaffBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (staffBox.SelectedItem == null)
            {
                return;
            }
            else
            {
                nameLabel.Text = "Name: " + staffBox.SelectedItem.ToString().Substring(0, staffBox.SelectedItem.ToString().LastIndexOf(' ')).Trim();
                lastNameLabel.Text = "Last Name: " + staffBox.SelectedItem.ToString().Substring(staffBox.SelectedItem.ToString().LastIndexOf(' ')).Trim();
            }


            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT [pDepart], [pSalary], [pRole], [pPhone], [pE-Mail], [pAdress] FROM personnel WHERE [pName] = @pName", conn);
                cmd.Parameters.AddWithValue("@pName", staffBox.SelectedItem.ToString().Substring(0, staffBox.SelectedItem.ToString().LastIndexOf(' ')));
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    departLabel.Text = "Depart: " + reader["pDepart"].ToString();
                    salaryLabel.Text = "Salary: " + reader["pSalary"].ToString();
                    rolesLabel.Text = "Roles: " + reader["pRole"].ToString();
                    phoneLabel.Text = "Phone: " + reader["pPhone"].ToString();
                    eMailLabel.Text = "e-Mail: " + reader["pE-Mail"].ToString();
                    adressLabel.Text = "Adress: " + reader["pAdress"].ToString();
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

        private void AddRoleComboBox2()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM roles", conn);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string role = reader["roleName"].ToString();

                    if (roleComboBox2.Items.Contains(role))
                    {
                        continue;
                    }
                    else
                    {
                        roleComboBox2.Items.Add(role);
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
            if (roleBox.CheckedItems.Count < 1)
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
            this.deleteRole.Font = new Font("Segoe UI", 9, FontStyle.Underline);
        }

        private void DeleteRole_MouseLeave(object sender, EventArgs e)
        {
            this.deleteRole.Font = new Font("Segoe UI", 9, FontStyle.Regular);
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

            if (myTextBoxes[0].Text.ToString().Trim().Equals("") || myTextBoxes[1].Text.ToString().Trim().Equals("") || myTextBoxes[2].Text.ToString().Trim().Equals("") ||
                myTextBoxes[3].Text.ToString().Trim().Equals("") || myTextBoxes[4].Text.ToString().Trim().Equals("") || myTextBoxes[5].Text.ToString().Trim().Equals("")
                || roleBox.CheckedItems.Count < 1 || addPersonPhone.Text.ToString().Trim().Equals("") || moneyUnit.SelectedIndex == -1)
            {
                for(int i = 0; i < myTextBoxes.Count; i++)
                {
                    if (myTextBoxes[i].Text.ToString().Trim().Equals(""))
                    {
                        myPanels[i].Visible = true;
                    }
                }

                if (addPersonPhone.MaskCompleted == false)
                {
                    alertPhone.Visible = true;
                }

                if(roleBox.CheckedItems.Count < 1)
                {
                    alertRoles.Visible = true;
                }

                if(moneyUnit.SelectedIndex == -1)
                {
                    alertMoneyUnit.Visible = true;
                }

                MessageBox.Show("Boxes cannot be left blank", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result;
            result = MessageBox.Show("Are you sure want to add new person?", "Manage Hub", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO personnel ([pName], [pLastName], [pDepart], [pSalary], [pRole], [pE-Mail], [pPhone], [pAdress]) VALUES (@pName, @pLastName, @pDepart, @pSalary, @pRole, @pEMail, @pPhone, @pAdress)", conn);
                    cmd.Parameters.AddWithValue("@pName", addPersonName.Text.Trim());
                    cmd.Parameters.AddWithValue("@pLastName", addPersonLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@pDepart", addPersonDepart.Text.Trim());
                    cmd.Parameters.AddWithValue("@pSalary", moneyUnit.GetItemText(moneyUnit.SelectedItem) + " " + addPersonSalary.Text.Trim());
                    foreach (object checkedItems in roleBox.CheckedItems)
                    {
                        string chckedItem = checkedItems.ToString();
                        cmd.Parameters.AddWithValue("@pRole", chckedItem);
                    }
                    cmd.Parameters.AddWithValue("@pEMail", addPersonMail.Text.Trim());
                    cmd.Parameters.AddWithValue("@pPhone", addPersonPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@pAdress", addPersonAdress.Text.Trim());
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
                    updateStaffBox();
                    clearBoxes();
                }
            }
            else
            {
                return;
            }
        }

        private void AddPersonName_Enter(object sender, EventArgs e)
        {
            alert1.Visible = false;
        }

        private void AddPersonLastName_Enter(object sender, EventArgs e)
        {
            alert2.Visible = false;
        }

        private void AddPersonDepart_Enter(object sender, EventArgs e)
        {
            alert3.Visible = false;
        }

        private void MoneyUnit_Enter(object sender, EventArgs e)
        {
            alertMoneyUnit.Visible = false;
        }

        private void AddPersonSalary_Enter(object sender, EventArgs e)
        {
            alert4.Visible = false;
        }

        private void AddPersonMail_Enter(object sender, EventArgs e)
        {
            alert5.Visible = false;
        }

        private void AddPersonPhone_Enter(object sender, EventArgs e)
        {
            alertPhone.Visible = false;
        }

        private void AddPersonAdress_Enter(object sender, EventArgs e)
        {
            alert6.Visible = false;
        }

        private void RoleBox_Enter(object sender, EventArgs e)
        {
            alertRoles.Visible = false;
        }

        private void clearBoxes()
        {
            addPersonName.ResetText();
            addPersonLastName.ResetText();
            addPersonDepart.ResetText();
            addPersonSalary.ResetText();
            addPersonMail.ResetText();
            addPersonPhone.ResetText();
            foreach (int i in roleBox.CheckedIndices)
            {
                roleBox.SetItemCheckState(i, CheckState.Unchecked);
            }
            addPersonAdress.ResetText();
        }

        private void RoleComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            staffBox2.Items.Clear();
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT pName, pLastName FROM personnel WHERE [pRole] = @pRole", conn);
                cmd.Parameters.AddWithValue("@pRole", roleComboBox2.GetItemText(roleComboBox2.SelectedItem));
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    staffBox2.Items.Add(reader["pName"].ToString() + " " + reader["pLastName"].ToString());
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

        private void RoleComboBox2_MouseMove(object sender, MouseEventArgs e)
        {
            roleComboBox2.Items.Clear();
            AddRoleComboBox2();
        }

        private void updateStaffBox()
        {
            staffBox2.Items.Clear();
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT pName, pLastName FROM personnel WHERE [pRole] = @pRole", conn);
                cmd.Parameters.AddWithValue("@pRole", roleComboBox2.Text);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //Console.WriteLine(reader["pName"].ToString() + " " + reader["pLastName"].ToString());
                    staffBox2.Items.Add(reader["pName"].ToString() + " " + reader["pLastName"].ToString());
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

        private void RemovePerson_Click(object sender, EventArgs e)
        {

            Console.WriteLine(staffBox2.GetItemText(staffBox2.SelectedItem.ToString().Substring(0, staffBox2.SelectedItem.ToString().LastIndexOf(' '))).Trim());
            Console.WriteLine(staffBox2.GetItemText(staffBox2.SelectedItem.ToString().Substring(staffBox2.SelectedItem.ToString().LastIndexOf(' '))).Trim());
            DialogResult result;
            result = MessageBox.Show("Are you sure want to remove selected person?", "Manage Hub", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM personnel WHERE [pName] = @pName AND [pLastNAme] = @pLastName", conn);
                    cmd.Parameters.AddWithValue("@pName", staffBox2.GetItemText(staffBox2.SelectedItem.ToString().Substring(0, staffBox2.SelectedItem.ToString().LastIndexOf(' '))).Trim());
                    cmd.Parameters.AddWithValue("@pLastName", staffBox2.GetItemText(staffBox2.SelectedItem.ToString().Substring(staffBox2.SelectedItem.ToString().LastIndexOf(' '))).Trim());
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.ToString());
                }
                finally
                {
                    conn.Close();
                    updateStaffBox();
                }
            }
            else
            {
                return;
            }
        }

        private void MainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainTab.SelectedIndex == 2)
            {
                AddItemStaffBox();
            }

            if (MainTab.SelectedIndex == 3)
            {
                int currentPerson = 0;
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT pID FROM personnel", conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        currentPerson += 1;
                    }
                    if (currentPerson < 10)
                    {
                        labelCurrentStaff.Text = "0" + Convert.ToString(currentPerson);
                    }
                    else
                    {
                        labelCurrentStaff.Text = Convert.ToString(currentPerson);
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
}