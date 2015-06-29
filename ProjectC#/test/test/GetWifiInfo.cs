using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;

namespace test
{
    
    
    public class GetWifiInfo
    {
        
        public void getsignal(object ob)
        {

            bgWorkerInterfaces bg_getsignal = new MyBackgroundWorker();
         //   bg_getsignal.DoWork += System.ComponentModel.DoWorkEventHandler(bg_getsinal_DoWork);
          //  bg_getsignal.RunWorkerCompleted += DoWorkEventHandler(bg_getsignal_RunWorkerCompleted);
          //  bg_getsignal.ProgressChanged += DoWorkEventHandler(bg_getsignal_ProgressChanged);
          //  bg_getsignal.WorkerReportsProgress = true;
           // bg_getsignal.WorkerSupportsCancellation = true;
//
           // bg_getsignal.DoWork(ob);
            
        }



        static void bg_getsinal_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            throw new NotImplementedException();
            //

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
                        //bg_getsignal.ReportProgress(strength);
                    }
                }
            }
        }
        static void bg_getsignal_RunWorkerCompleted(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }
        static void bg_getsignal_ProgressChanged(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }
        
        
    }
}
 