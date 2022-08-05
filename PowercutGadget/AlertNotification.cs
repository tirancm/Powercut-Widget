using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowercutGadget
{
    public partial class AlertNotification : Form
    {
        int timeslotIndex;
        int stayed = 0;

        public AlertNotification()
        {
            InitializeComponent();
        }

        public AlertNotification(int timeslotIndex)
        {
            this.timeslotIndex = timeslotIndex;
            InitializeComponent();
        }

        private void AlertNotification_Load(object sender, EventArgs e)
        {
            double inititialLocX = System.Windows.SystemParameters.FullPrimaryScreenWidth - Size.Width-2;
            double initialLocY = System.Windows.SystemParameters.FullPrimaryScreenHeight-Size.Height-8;
            this.Location = new Point((int)inititialLocX, (int)initialLocY);

            this.Activate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text=SyncedData.TimeSlots[timeslotIndex].StartTime.Subtract(DateTime.Now).ToString("hh':'mm");
            stayed++;

            if (stayed >= 60)
            {
                this.Close();
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.close_btn_hover;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.close_btn;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
