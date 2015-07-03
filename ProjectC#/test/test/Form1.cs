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
using NativeWifi;


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
            // initialize for background worker set signal
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
           

            if (bgworker_setsignal.IsBusy)
            {
                bgworker_setsignal.CancelAsync();

            }
            else
            {
                bgworker_setsignal.RunWorkerAsync();

            }
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
                        string tmp = line.Split(':')[1].Split('%')[0];
                        Int32.TryParse(tmp, out strength);
                        break;
                    }
                  
                }
              
                bgworker_setsignal.ReportProgress(strength);

            }

        }
        private void bgworker_setsignal_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage != 0)
            {
                speedtest_lb_signal.Text = e.ProgressPercentage+"%";
                dashboard_lb_signal.Text = e.ProgressPercentage + "%";
                //procbar_signal.Value = e.ProgressPercentage;
                signalStrength1.Value = e.ProgressPercentage;
                signalStrength2.Value = e.ProgressPercentage;
               

            }
            else
            {
                signalStrength1.Value = e.ProgressPercentage;
                signalStrength2.Value = e.ProgressPercentage;
                speedtest_lb_signal.Text = "No network connected !";
                dashboard_lb_signal.Text = "No network connected !";
                //procbar_signal.Value = e.ProgressPercentage;
                
            }
            
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
                dataGridView1.Rows[j].Cells[0].ToolTipText = wifiName[j]+" access point";
                dataGridView1.Rows[j].Cells[1].Value = wifiAuth[j];
                dataGridView1.Rows[j].Cells[2].Value = wifiMacAdd[j];// wifiMacAdd[j];
                dataGridView1.Rows[j].Cells[3].Value = sn;
                dataGridView1.Rows[j].Cells[3].Style.ForeColor = Color.Red;
                dataGridView1.Rows[j].Cells[3].ToolTipText = "Signal strength: "+wifiSignal[j];
              
                
                

            }

        }
        //

        private void xtraTab_signalstrength_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void xtraTab_signalstrength_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("test");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GetListAccessPoint();
            button1.Text = "Refresh";
            button2.Enabled = true;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            button1.Text = "Scan";
            button2.Enabled = false;
        }

        private void procbar_signal_Click(object sender, EventArgs e)
        {

        }

        private void gaugeControl3_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

      

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)

        {
           // MessageBox.Show();

            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Connect to network",connect));
                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
               
                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                }
                m.Show(dataGridView1, new Point(e.X, e.Y));

            }

        }
        private void connect(object sender, EventArgs e)
        {
            
        }

        // Connect to Access point
        /// Converts a 802.11 SSID to a string.
        /// </summary>
        
        ///
        



        private void label5_Click(object sender, EventArgs e)
        {

        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        ///
        //

    }
}
