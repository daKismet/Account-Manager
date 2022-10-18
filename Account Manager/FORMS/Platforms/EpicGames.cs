using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account_Manager
{
    public partial class EpicGames : Form
    {
        public EpicGames()
        {
            InitializeComponent();
        }

        string path = @"C:\EpicGames.txt";
        struct user
        {
            public user(string user, string pass)
            {
                username = user;
                Password = pass;
            }

            public string username { get; }
            public string Password { get; }
        }

        List<user> userlist = new List<user>();

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> lines = File.ReadAllLines(path).ToList();
            var User = new user(textBox2.Text, textBox1.Text);
            userlist.Add(User);
            lines.Add(User.username + "," + User.Password);
            File.WriteAllLines(path, lines);

            comboBox1.Items.Clear();
            foreach (user v in userlist)
            {
                comboBox1.Items.Add(v.username);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Process[] workers = Process.GetProcessesByName("Epic");

            foreach (Process worker in workers)
            {
                worker.Kill();
                worker.WaitForExit();
                worker.Dispose();
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = @"C:\Program Files (x86)\Epic Games\Launcher\Portal\Binaries\Win32\EpicGamesLauncher.exe";

            startInfo.Arguments = " -login " + userlist[comboBox1.SelectedIndex].username + " " +
                userlist[comboBox1.SelectedIndex].Password;

            Process.Start(startInfo);
            Process.Start(@"C:\Program Files (x86)\Epic Games\Launcher\Portal\Binaries\Win32\EpicGamesLauncher.exe");
        }

        private void EpicGames_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            if (!File.Exists(path))
            {
                StreamWriter sv = File.CreateText(path);
                sv.Flush();
                sv.Dispose();
            }

            List<string> lines = File.ReadAllLines(path).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                user newuser = new user(entries[0], entries[1]);
                comboBox1.Items.Add(entries[0]);
                userlist.Add(newuser);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Process.Start(path);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage();
            main.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox1.ForeColor = Color.Black;
            }
            else
            {
                textBox1.ForeColor = Color.White;
            }
        }
    }
}
