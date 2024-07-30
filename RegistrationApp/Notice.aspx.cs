using System;
using System.Data;
using System.Xml.Linq;

namespace RegistrationApp
{
    public partial class Notice : System.Web.UI.Page
    {
        DataTable dt;
        siteclass site = new siteclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
                dt = site.getdatatable("select SHOW_ADVT from APPLICANT where USERID='" + Session["APPNO"].ToString().Trim() + "'");
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SHOW_ADVT"].ToString()=="1")
                        Response.Redirect("personalinfo", false);
                    else
                        Response.Redirect("viewadv", false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Preview", false);
        }
    }
}