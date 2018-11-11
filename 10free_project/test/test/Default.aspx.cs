using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;


namespace test
{

    public partial class Default : System.Web.UI.Page
    {
        protected void calender_SelectionChang(object sender,EventArgs args)
        {
            int ndbyear = calender.SelectedDate.Year;
            int nucyear = DateTime.Now.Year;
            tbx_calender_select.Text = (nucyear - ndbyear).ToString();
        }
    }
}