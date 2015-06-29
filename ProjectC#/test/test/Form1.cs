using DevComponents.DotNetBar.Metro;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;



namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Thread welcome_thread = new Thread(new ThreadStart(welcome));
          //  welcome_thread.Start();
            //Thread.Sleep(12000);
            InitializeComponent();
            bgworker_setsignal.DoWork += bgworker_setsignal_DoWork;
            bgworker_setsignal.RunWorkerCompleted += bgworker_setsignal_RunWorkerCompleted;
            bgworker_setsignal.ProgressChanged += bgworker_setsignal_ProgressChanged;
            bgworker_setsignal.WorkerReportsProgress = true;
            bgworker_setsignal.WorkerSupportsCancellation = true;

            //welcome_thread.Abort();
            
        }
        // khai bao bien cho thao tac di chuyen form
        Boolean flag; int x, y;
        
        // end 
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
            x = e.X;
            y = e.Y;

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag == true)
            {
                this.SetDesktopLocation(Cursor.Position.X - x, Cursor.Position.Y - y);

            }
        }
        private void welcome()
        {
            Application.Run(new WelcomeScreen());

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            //pictureBox1.BackgroundImage = Properties.Resources.hover_close;
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.hover_close;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.iconsineed_cross_24_1281;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
           
        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.settings_hover;
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.settings_icon;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.minimize_hover2;
        }
        private void pictureBox3_MouseLeave_1(object sender, EventArgs e)
        {
            //pictureBox3.BackgroundImage = Properties.Resources.minimize;
        }
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.minimize;
        }
        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Hide();
            
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void xtraTab_dashboard_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // gán dữ liệu cho chartControl1
            chartControl1.Series.Clear();
            
            Series s = new Series("Speed",ViewType.SplineArea)
            {
                
                DataSource = ChartControl.ExcelRead.OpenFile("t.xlsx"),
                ArgumentScaleType = ScaleType.Qualitative,
                ArgumentDataMember = "Cot1",
                ValueScaleType = ScaleType.Numerical

            };

            
            s.ValueDataMembers.AddRange(new string[] { "Cot1" });
            chartControl1.Series.Add(s);
            chartControl1.RefreshData();

        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = Properties.Resources.QuickTest1;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = Properties.Resources.QuickTest_hover1;
        }

        private void gaugeControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (bgworker_setsignal.IsBusy)
            {
                bgworker_setsignal.CancelAsync();

            }
            else
            {
                bgworker_setsignal.RunWorkerAsync();

            }

        }

        // set lb_signal text
       
        private void bgworker_setsignal_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            
        }
        private void bgworker_setsignal_DoWork(object sender, DoWorkEventArgs e)
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "netsh.exe",
                    Arguments = "wlan show interfaces",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            while (true)
            {
                proc.Start();
                string line;
                int strength = 0;
                while (!proc.StandardOutput.EndOfStream)
                {
                    line = proc.StandardOutput.ReadLine();
                    if (line.Contains("Signal"))
                    {
                        //  label1.Text = line.Split(':')[1];
                        string tmp = line.Split(':')[1].Split('%')[0];
                        Int32.TryParse(tmp, out strength);
                        bgworker_setsignal.ReportProgress(strength);
                    }
                }
            }

        }
        private void bgworker_setsignal_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            procbar_signal.Value = e.ProgressPercentage;
            
            
            lb_signal.Text = e.ProgressPercentage.ToString() + "%" ;
            linearScaleComponent1.Value = e.ProgressPercentage;
        }
        //

        private void xtraTab_speedtest_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void createProcessbar_signal(int vl)
        {
          //  ProgressBar progbar;
            //= new ProgressBar();
          //  progbar.Value = vl;

        }
        // get list wifi
        private void GetListAccessPoint()
        {
            string line;
            string[] wifiName = new string[255];
            string[] wifiAuth = new string[255];
            string[] wifiMacAdd = new string[255];
            string[] wifiSignal = new string[255];
            int i = 0;
            Process p = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "netsh.exe",
                    Arguments = "wlan show networks mode=bssid",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            p.Start();
            while (!p.StandardOutput.EndOfStream)
            {

                line = p.StandardOutput.ReadLine();
                if (line.Contains("SSID") && !line.Contains("BSSID"))
                {
                    wifiName[i] = line.Split(':')[1];
                }
                if (line.Contains("Authentication"))
                {
                    wifiAuth[i] = line.Split(':')[1];
                }
                if (line.Contains("BSSID"))
                {
                    wifiMacAdd[i] = line.Split(new string[] {" : "}, StringSplitOptions.None)[1];
                }
                if (line.Contains("Signal"))
                {
                    wifiSignal[i] = line.Split(':')[1];
                    i++;
                }
            }
           
            for (int j = 0; j < i; j++)
            {

                int sn;
                Int32.TryParse(wifiSignal[j].Split('%')[0], out sn);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[j].Cells[0].Value = wifiName[j];
                dataGridView1.Rows[j].Cells[0].ToolTipText = wifiName[j]+" Access point";
                dataGridView1.Rows[j].Cells[1].Value = wifiAuth[j];
                dataGridView1.Rows[j].Cells[2].Value ="Đã bị giấu =]]]ưz";
                dataGridView1.Rows[j].Cells[3].Value = sn;
                dataGridView1.Rows[j].Cells[3].ToolTipText = "Signal strength "+wifiSignal[j];
                

            }

        }
        //

        private void xtraTab_signalstrength_Paint(object sender, PaintEventArgs e)
        {
           // GetListAccessPoint();
        }

        private void xtraTab_signalstrength_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GetListAccessPoint();
        }


    }
}
