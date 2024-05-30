using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Denali_nextGenTurboSupport {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
        
        }
        private void button1_Click(object sender, EventArgs e) {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            timer1.Enabled = false;

            TextBoxTest();
            DelaymS(3000);
            TextBoxPass();

            ClearSN();

            timer1.Enabled = false;
        }
        public static void DelaymS(int mS) {
            Stopwatch stopwatchDelaymS = new Stopwatch();
            stopwatchDelaymS.Restart();
            while (mS > stopwatchDelaymS.ElapsedMilliseconds) {
                if (!stopwatchDelaymS.IsRunning) stopwatchDelaymS.Start();
                Application.DoEvents();
            }
            stopwatchDelaymS.Stop();
        }
        private void TextBoxTest() {
            string testing = "Testing";

            if (pictureBox1.BackColor == Color.Lime) {
                tb_result1.Text = testing;
            }
            if (pictureBox2.BackColor == Color.Lime) {
                tb_result2.Text = testing;
            }
            if (pictureBox3.BackColor == Color.Lime) {
                tb_result3.Text = testing;
            }
            if (pictureBox4.BackColor == Color.Lime) {
                tb_result4.Text = testing;
            }
        }
        private void TextBoxPass() {
            string testing = "Pass";

            if (pictureBox1.BackColor == Color.Lime) {
                tb_result1.Text = testing;
                GenLogTest("KF39A00V44-864593055057078-Denali Alkaline-Configure-Passed.xml");
            }
            if (pictureBox2.BackColor == Color.Lime) {
                tb_result2.Text = testing;
                GenLogTest("KF39A00V94-864593054946073-Denali Alkaline-Configure-Passed.xml");
            }
            if (pictureBox3.BackColor == Color.Lime) {
                tb_result3.Text = testing;
                GenLogTest("KF39A00VA4-864593055034655-Denali Alkaline-Configure-Passed.xml");
            }
            if (pictureBox4.BackColor == Color.Lime) {
                tb_result4.Text = testing;
                GenLogTest("KF39A00VB4-864593055034382-Denali Alkaline-Configure-Passed.xml");
            }
        }
        private void ClearSN() {
            tb_sn1.Text = string.Empty;
            tb_sn2.Text = string.Empty;
            tb_sn3.Text = string.Empty;
            tb_sn4.Text = string.Empty;
        }

        private void GenLogTest(string nameFile) {
            string data = File.ReadAllText("../../../" + nameFile);

            string[] dataSup = data.Replace("<ReportTime>", "ฅ").Replace("</ReportTime>", "ฅ").Split('ฅ');
            string time = dataSup[1];

            string newTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", 
                System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));

            data = data.Replace(time, newTime);

            while (true)
            {
                try
                {
                    File.WriteAllText("../../../Data Log Test/" + nameFile, data);
                    break;
                }
                catch { }
                Thread.Sleep(50);
            }
        }





        private void checkBox1_Click(object sender, EventArgs e) {
            if (checkBox1.Checked) {
                pictureBox1.BackColor = Color.Lime;
                label1.Visible = true;
            } else {
                pictureBox1.BackColor = Color.Red;
                label1.Visible = false;
            }
        }
        private void checkBox2_Click(object sender, EventArgs e) {
            if (checkBox2.Checked) {
                pictureBox2.BackColor = Color.Lime;
                label2.Visible = true;
            } else {
                pictureBox2.BackColor = Color.Red;
                label2.Visible = false;
            }
        }
        private void checkBox3_Click(object sender, EventArgs e) {
            if (checkBox3.Checked) {
                pictureBox3.BackColor = Color.Lime;
                label3.Visible = true;
            } else {
                pictureBox3.BackColor = Color.Red;
                label3.Visible = false;
            }
        }
        private void checkBox4_Click(object sender, EventArgs e) {
            if (checkBox4.Checked) {
                pictureBox4.BackColor = Color.Lime;
                label4.Visible = true;
            } else {
                pictureBox4.BackColor = Color.Red;
                label4.Visible = false;
            }
        }
    }
}
