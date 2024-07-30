using System;
using System.Data;

namespace RegistrationApp
{
    public partial class Timesup1 : System.Web.UI.Page
    {
        siteclass site = new siteclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = site.getdatatable("select TIMESUP_MSG from utility");
            if (dt.Rows.Count>0)
            {
                lblStatus.Text = dt.Rows[0]["TIMESUP_MSG"].ToString();
            }
            else
            {
                lblStatus.Text = "";
            }
        }
    }
}