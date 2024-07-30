using System;
using System.Data;

namespace RegistrationApp
{
    public partial class adminlogin : System.Web.UI.Page
    {
        DataTable dt;
        siteclass site = new siteclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtRegno.Focus();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                dt = site.getdatatable("select auth from admin_users where userid='" + txtRegno.Text.Trim() + "' and PASSWORD='" + txtPassword.Text.Trim() + "'");
                if (dt.Rows.Count == 0)
                {
                    lblStatus.Text = "Login Failed!, Userid or Password is not correct!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    Session["AUTH"] = dt.Rows[0]["AUTH"].ToString().Trim().ToUpper();
                    Session["APPNO"] = "GTD*786";

                    if(dt.Rows[0]["AUTH"].ToString().Trim().ToUpper()=="ADMIN")
                        Response.Redirect("dashboard",false);
                    else
                        Response.Redirect("adminpage",false);
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                // do nothing
            }

            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
    }
}