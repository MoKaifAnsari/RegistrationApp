using System;
using System.Data;

namespace RegistrationApp
{
    public partial class ViewAdv : System.Web.UI.Page
    {
        siteclass site = new siteclass();
        DataTable dt= new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            //int rex = site.executeNonQuery("UPDATE APPLICANT SET SHOW_ADVT=1 WHERE USERID='" + Session["APPNO"].ToString().Trim() + "'");

            try
            {
                dt = site.getdatatable("select PERSONALINFO_PAGE,EDUCATION_PAGE,EXPERIENCE_PAGE,DOCUMENT_PAGE from APPLICANT where USERID='" + Session["APPNO"].ToString().Trim() + "'");
                if (dt.Rows.Count > 0)
                {
                    
                    if (string.IsNullOrEmpty(dt.Rows[0]["PERSONALINFO_PAGE"].ToString().Trim()) || dt.Rows[0]["PERSONALINFO_PAGE"].ToString().Trim()=="0")
                    {
                        Response.Redirect("PersonalInfo", false);
                    }
                    else if (string.IsNullOrEmpty(dt.Rows[0]["EDUCATION_PAGE"].ToString().Trim()) || dt.Rows[0]["EDUCATION_PAGE"].ToString().Trim() == "0")
                    {
                        Response.Redirect("Education", false);
                    }
                    //else if (string.IsNullOrEmpty(dt.Rows[0]["EXPERIENCE_PAGE"].ToString().Trim()) || dt.Rows[0]["EXPERIENCE_PAGE"].ToString().Trim() == "0")
                    //{
                    //    Response.Redirect("workexperience", false);
                    //}
                    else if (string.IsNullOrEmpty(dt.Rows[0]["DOCUMENT_PAGE"].ToString().Trim()) || dt.Rows[0]["DOCUMENT_PAGE"].ToString().Trim() == "0")
                    {
                        Response.Redirect("uploadfile", false);
                    }
                    else
                    {
                        Response.Redirect("download", false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        protected void chkConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if(chkConfirm.Checked)
            {
                btnProceed.Enabled = true;
            }
            else
            {
                btnProceed.Enabled = false;
            }
        }
    }
}