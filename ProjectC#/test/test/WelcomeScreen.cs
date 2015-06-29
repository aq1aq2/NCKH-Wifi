using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;

namespace test
{
    public partial class WelcomeScreen : MetroForm
    {
        public WelcomeScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            circularProgress1.Value += 1;
            progressBarX1.Increment(1);
            if(circularProgress1.Value == 110)
            {
                circularProgress1.Value = 0;
                progressBarX1.Value = 0;

            }
            
           


        }

        private void progressPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
