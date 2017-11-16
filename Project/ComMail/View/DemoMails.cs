using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Droid_communication
{
    public partial class DemoMails : Form
    {
        public DemoMails()
        {
            InitializeComponent();
            InterfaceEmail mi = new InterfaceEmail();
        }
    }
}
