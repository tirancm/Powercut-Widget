using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.Win32;

namespace PowercutGadget
{
    public partial class Form1 : Form
    {
        
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private CookieContainer cookieContainer = new CookieContainer();
        HttpClient client = new HttpClient();

        int apiRequestRetryCount = 0;
        bool onANotification = false;
        

        public Form1()
        {
            InitializeComponent();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Console.WriteLine(getVerificationToken());
            String json=GetLoadSheddingEvents(getVerificationToken());

            if (!json.Equals(""))
            {
                getTimeSlots(json, ConfigFactory.getSheduleGroup());
                updateTimeslotLabels();
            }
            else {
            }
            
        }

        String getVerificationToken()
        {
            try
            {
                string urlAddress = "https://cebcare.ceb.lk/Incognito/DemandMgmtSchedule";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                request.CookieContainer = cookieContainer;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                        Stream receiveStream = response.GetResponseStream();
                        StreamReader readStream = null;
                        if (String.IsNullOrWhiteSpace(response.CharacterSet))
                            readStream = new StreamReader(receiveStream);
                        else
                            readStream = new StreamReader(receiveStream,
                                Encoding.GetEncoding(response.CharacterSet));
                        string data = readStream.ReadToEnd();
                        response.Close();
                        readStream.Close();

                        var doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(data);

                        var node = doc.DocumentNode.SelectSingleNode("//input[@name='__RequestVerificationToken']");

                        return node.Attributes["value"].Value;

                }
            }
            catch (Exception){
            }

            return "";
        }

       string GetLoadSheddingEvents(String reqAuthToken)
        {
            try
            {
                String cookieString = getCookieStringForSite(cookieContainer, "https://cebcare.ceb.lk");

                var url = "https://cebcare.ceb.lk/Incognito/GetLoadSheddingEvents";
                var data = "StartTime="+DateTime.Now.Date.ToString("yyyy-MM-dd") + "&EndTime="+ DateTime.Now.Date.AddDays(1).ToString("yyyy-MM-dd");
                Console.WriteLine(data);
                byte[] contentBytes = Encoding.ASCII.GetBytes(data);

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "POST";

                httpRequest.ContentType = "application/x-www-form-urlencoded";
                httpRequest.Headers.Add("RequestVerificationToken", getVerificationToken());
                httpRequest.Headers.Add("Cookie", cookieString);
                //httpRequest.Headers.Add("Host", "cebcare.ceb.lk");
                httpRequest.Host = "cebcare.ceb.lk";
                httpRequest.ContentLength = contentBytes.Length;                

                Console.WriteLine(httpRequest.ContentLength);


                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }

                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    return result;
                }

            }
            catch (Exception)
            {
            }

            return "";
        }

        String getCookieStringForSite(CookieContainer container,String site)
        {
            String cookieString = "";
            foreach (var cookie in cookieContainer.GetCookies(new Uri(site)))
            {
                //Console.WriteLine(cookie.ToString()); // test=testValue
                cookieString = cookieString + cookie.ToString() + ";";
            }

            return cookieString;
        }

        private void closeBtn_MouseHover(object sender, EventArgs e)
        {
            closeBtn.Image = Properties.Resources.close_btn_hover;
        }

        private void settingBtn_MouseHover(object sender, EventArgs e)
        {
            settingBtn.Image = Properties.Resources.setting_btn_hower1;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.settingBtn, "Open Settings");
        }

        private void settingBtn_MouseLeave(object sender, EventArgs e)
        {
            settingBtn.Image = Properties.Resources.setting_btn1;
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.Image = Properties.Resources.close_btn;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterInStartup(true);
            Console.WriteLine(ConfigFactory.getSheduleGroup());

            notifyIcon1.Icon=Properties.Resources.ceb;

            double inititialLocX = System.Windows.SystemParameters.FullPrimaryScreenWidth - Size.Width - 15;
            double initialLocY = 15;
            this.Location = new Point((int)inititialLocX, (int)initialLocY);


            //load data for the first time
            Task.Run(() => tryLoadData());
            updateTimeslotLabels();
        }

        async void tryLoadData()
        {
            String json = GetLoadSheddingEvents(getVerificationToken());

            if (!json.Equals(""))
            {
                getTimeSlots(json, ConfigFactory.getSheduleGroup());

                if (SyncedData.isSynced())
                {
                    apiRequestRetryCount = 0;
                }
                else {
                    apiRequestRetryCount++;
                }
            }
            else {
                apiRequestRetryCount++;
            }
        }

        async void getTimeSlots(String json, String group)
        {
            List<TimeSlot> timeslots = new List<TimeSlot>();

            try
            {
                JArray textArray = JArray.Parse(json);

                List<JObject> powercutTimeSlots = new List<JObject>();

                foreach (JObject item in textArray)
                {
                    string loadshed = item.GetValue("loadShedGroupId").ToString();

                    if (loadshed.Equals(group))
                    {
                        String startT = item.GetValue("startTime").ToString();
                        String endT = item.GetValue("endTime").ToString();

                        timeslots.Add(new TimeSlot(DateTime.Parse(startT),
                                                   DateTime.Parse(endT)));

                    }
                }
                List<TimeSlot> SortedList = timeslots.OrderBy(o => o.StartTime).ToList();
                SyncedData.TimeSlots = SortedList;
                
            }
            catch (Exception e){
            }
        }

      
        void updateTimeslotLabels()
        {
            if (SyncedData.isSynced())
            {
                blockUiPanel.Visible = false;

                int nearestTimeslotIndex = SyncedData.getIndexOfNearestTimeSlotIndex();
                String suffix = " ";

                if (nearestTimeslotIndex == -2)
                {
                }
                else if (nearestTimeslotIndex == -1)
                {
                    int i = 0;
                    foreach (TimeSlot t in SyncedData.TimeSlots)
                    {
                        if (DateTime.Now <= t.EndTime && DateTime.Now >= t.StartTime)
                        {
                            nearestTimeslotIndex = i;
                            break;
                        }

                        i++;
                    }
                    suffix = " ongoing";
                }
                else {
                    String defference = SyncedData.TimeSlots[nearestTimeslotIndex].StartTime.Subtract(DateTime.Now).ToString("hh':'mm");
                    suffix = " - happens in (" + defference + ")";

                    int minutes = (Int32)SyncedData.TimeSlots[nearestTimeslotIndex].StartTime.Subtract(DateTime.Now).TotalMinutes;

                    createNotification(nearestTimeslotIndex,60);
                    createNotification(nearestTimeslotIndex,30);
                    createNotification(nearestTimeslotIndex, 15);
                    createNotification(nearestTimeslotIndex, 5);
                    createNotification(nearestTimeslotIndex, 2);

                }

                //updating labels
                if (SyncedData.timeSlotCount() > 0)
                {
                    String s = "";
                    if (nearestTimeslotIndex == 0)
                    {
                        s = suffix;
                        lbl_timeslot1.ForeColor = Color.YellowGreen;
                    }
                    else
                    {
                        lbl_timeslot1.ForeColor = Color.White;
                    }
                    lbl_timeslot1.Text = "1. " + SyncedData.TimeSlots[0].StartTime.ToString("HH:mm") + " to " + SyncedData.TimeSlots[0].EndTime.ToString("HH:mm") + s;
                }
                else {
                    lbl_timeslot1.Text = "-";
                    lbl_timeslot2.Text = "-";
                    lbl_timeslot3.Text = "-";
                }

                if (SyncedData.timeSlotCount() > 1)
                {
                    String s = "";
                    if (nearestTimeslotIndex == 1)
                    {
                        s = suffix;
                        lbl_timeslot2.ForeColor = Color.YellowGreen;
                    }
                    else
                    {
                        lbl_timeslot2.ForeColor = Color.White;
                    }

                    lbl_timeslot2.Text = "2. " + SyncedData.TimeSlots[1].StartTime.ToString("HH:mm") + " to " + SyncedData.TimeSlots[1].EndTime.ToString("HH:mm") + s;
                }
                else {
                    lbl_timeslot2.Text = "-";
                    lbl_timeslot3.Text = "-";
                }

                if (SyncedData.timeSlotCount() > 2)
                {
                    String s = "";
                    if (nearestTimeslotIndex == 2)
                    {
                        s = suffix;
                        lbl_timeslot3.ForeColor = Color.YellowGreen;
                    }
                    else
                    {
                        lbl_timeslot3.ForeColor = Color.White;
                    }

                    lbl_timeslot3.Text = "3. " + SyncedData.TimeSlots[2].StartTime.ToString("HH:mm") + " to " + SyncedData.TimeSlots[2].EndTime.ToString("HH:mm") + s;
                }
                else {
                    lbl_timeslot3.Text = "-";
                }
                lastSynced.Text = "Updated " + SyncedData.LastSyncDateTime.ToString("HH:mm");
            }
            else
            {
                timer2.Enabled = true;
            }  
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.sync_hower;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.sync;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateTimeslotLabels();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (SyncedData.isSynced())
            {
                apiRequestRetryCount = 0;
                timer2.Enabled = false;
            }
            else if (apiRequestRetryCount < 5)
            {
                Task.Run(() => tryLoadData());
                Console.WriteLine("retring to get response..");
            }
            else
            {
                blockUiPanel.Visible = true;
                Console.WriteLine("failed 5 times to get response");
            }
        }

        void createNotification(int timeslotIndex,int minute)
        {
            int minutes = (Int32)SyncedData.TimeSlots[timeslotIndex].StartTime.Subtract(DateTime.Now).TotalMinutes;

            if (onANotification == false && minutes <= minute && minutes >= minute)
            {
                onANotification = true;

                notifyIcon2.BalloonTipTitle = "Powercut Alert!!";
                notifyIcon2.BalloonTipText = "Next powercut happens in : " + SyncedData.TimeSlots[timeslotIndex].StartTime.Subtract(DateTime.Now).ToString("hh':'mm");
                notifyIcon2.Visible = true;
                notifyIcon2.ShowBalloonTip(500);

                new AlertNotification(timeslotIndex).Show();
            }

            if (minutes == minute-1 )
            {
                onANotification = false;
            }

        }

        private void blockUiPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            
        }

    

        private void Form1_Resize(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "Minimized";
            notifyIcon1.BalloonTipText = "PowecutShedule App was successfully minimized to tray.";

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(100);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingBtn_Click(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
        }

        private void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("ApplicationName", Application.ExecutablePath);
            }
            else
            {
                registryKey.DeleteValue("ApplicationName");
            }
        }
    }
}
