using System;
using System.Data;

namespace RegistrationApp
{
    public partial class Forget : System.Web.UI.Page
    {
        DataTable dt;
        siteclass site = new siteclass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.Trim() == "" || txtAadhar.Text.Trim() == "")
                {
                    lblStatus.Text = " Blank Email ID or Aadhar Number is not allowed";
                    lblStatus.BackColor = System.Drawing.Color.White;
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    dt = site.getdatatable("select USERID,PASSWORD from APPLICANT where EMAIL='" + txtEmail.Text.Trim().ToUpper() + "' and ID_NO='" + txtAadhar.Text.Trim() + "'");
                    if (dt.Rows.Count == 0)
                    {
                        lblStatus.Text = " Email ID or Aadhar Number is not correct!";
                        lblStatus.BackColor = System.Drawing.Color.White;
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblStatus.Text = "Registration No : " + dt.Rows[0]["USERID"].ToString().Trim() + "<br />"
                                       + "Password : " + dt.Rows[0]["PASSWORD"].ToString().Trim();
                        lblStatus.BackColor = System.Drawing.Color.White;
                        lblStatus.ForeColor = System.Drawing.Color.Blue;
                    }
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