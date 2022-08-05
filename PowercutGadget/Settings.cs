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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://cebcare.ceb.lk/Incognito/DemandMgmtSchedule");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigFactory.writeSheduleGroup(comboBox1.Text);
            Application.Restart();
            Environment.Exit(0);
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            comboBox1.Text=ConfigFactory.getSheduleGroup();
        }
    }
}
