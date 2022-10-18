using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account_Manager
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Steam Steam  = new Steam();
            Steam.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            BattleNet BattleNet = new BattleNet();
            BattleNet.Show();
            this.Hide();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            EpicGames EpicGames = new EpicGames();
            EpicGames.Show();
            this.Hide();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Origin Origin = new Origin();
            Origin.Show();
            this.Hide();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            radioButton4.Checked = false;
            radioButton3.Checked = false;
            radioButton3.Checked = false;
            radioButton1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Steam Steam = new Steam();
                Steam.Show();
                this.Hide();
            }
            if (radioButton2.Checked == true)
            {
                BattleNet BattleNet = new BattleNet();
                BattleNet.Show();
                this.Hide();
            }
            if (radioButton3.Checked == true)
            {

            }
            if (radioButton4.Checked == true)
            {

            }
        }
    }
}
