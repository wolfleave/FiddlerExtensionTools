using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventReportTest
{
    public partial class EventReportControl : UserControl
    {
        delegate void SetTextCallback(IList<string> eventList);

        public EventReportControl()
        {
            InitializeComponent();
        }

        public void UpdateEvent(IList<string> eventList)
        {
            if (EventID.InvokeRequired)
            {
                EventID.Invoke(new SetTextCallback(UpdateEvent), eventList);
            }
            else
            {
                EventID.DataSource = eventList.ToList();
            }
        }
    }
}
