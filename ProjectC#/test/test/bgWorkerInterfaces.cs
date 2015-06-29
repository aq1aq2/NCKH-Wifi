using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace test
{
    public interface bgWorkerInterfaces
    {
       
        bool WorkerReportsProgress { get; set; }
        bool WorkerSupportsCancellation { get; set; }
        event DoWorkEventHandler DoWork;
        event ProgressChangedEventHandler ProgressChanged;
        event RunWorkerCompletedEventHandler RunWorkerCompleted;
        
    }
    
}
