using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using NepaliCalender;


namespace calculeAge
{
    
    public partial class Default : System.Web.UI.Page
    {
        protected void page_load(object sender, EventArgs e)
        {

        }
        protected void calDOB_SelectionChanged(object sender, EventArgs e)
        {
            int nDOBYear = calDOB.SelectedDate.Year;
            int nCurrentYear = DateTime.Now.Year;
            tbxDOB.Text = (nCurrentYear - nDOBYear).ToString();
        }

    }
}
