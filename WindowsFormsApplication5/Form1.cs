using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;


namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            string port;
            port = "106";
            string Host;
            Host = "192.168.99.13";
            string dicompath = @"C:\MyDir";
            string finalpath;
            string[] files = Directory.GetFiles(dicompath, "*.*", SearchOption.AllDirectories);

            
            foreach (string s in files)
            {
                //if (File.Exists(s))
                finalpath = Host + " " + port + " " + s;
                //Process pr = new Process();
                Process prs = new Process();
                prs.StartInfo.CreateNoWindow = true;
                prs.StartInfo.UseShellExecute = false;
                prs.StartInfo.RedirectStandardOutput = true;
                prs.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                prs.StartInfo.FileName = @"C:\dcmtk\bin\storescu-tls.exe";
                prs.StartInfo.Arguments = finalpath;
                textBox2.Text = s;
                

                              
                ThreadStart ths = new ThreadStart(() => prs.Start());
                Thread th = new Thread(ths);
                th.Start();
                prs.WaitForExit(1000 * 60 * 5);

                File.Delete(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}

