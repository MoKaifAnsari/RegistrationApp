using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace RegistrationApp
{
    public partial class Login : System.Web.UI.Page
    {
        DataTable dt;
        siteclass site = new siteclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            //int rex = site.getOfflineStatus("LOGIN_PROCESS_ONLINE");
            //if (rex == 0)
            //{
            //    Response.Redirect("Timesup.aspx", false);
            //    return;
            //}

            Session["POST"] = null;
            if (!IsPostBack)
            {
                FillCapctha();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                if (txtRegno.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtCaptcha.Text.Trim() == "")
                {
                    lblStatus.Text = "Sorry, Blank fields are not allowed!";
                    lblStatus.Visible = true;
                    return;
                }

                if (txtCaptcha.Text.Trim() != Session["captcha"].ToString())
                {
                    lblStatus.Text = "Captcha not Matching";
                    lblStatus.Visible = true;
                    return;
                }

                ValidateRegno(txtRegno.Text.Trim());

                if (ViewState["SAVE"].ToString() == "NO")
                {
                    lblStatus.Text = "Special Chars not allowed with User ID";
                    lblStatus.Visible = true;
                    return;
                }
                else
                {
                    dt = site.getdatatable("select * from APPLICANT where USERID='" + txtRegno.Text.Trim() + "' and PASSWORD='" + txtPassword.Text.Trim() + "'");
                    if (dt.Rows.Count == 0)
                    {
                        lblStatus.Text = "Login Failed or not active!";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        Session["APPNO"] = txtRegno.Text.Trim().ToUpper();
                        Session["NAME"] = dt.Rows[0]["APPLICANT_NAME"].ToString().Trim();

                        //if (dt.Rows[0]["ADMIT_CARD_SEND"].ToString().Trim() == "1")
                        //{
                        //    Logger();
                        //    Response.Redirect("download", false);
                        //}
                        //else
                        //{
                        //    if (dt.Rows[0]["NOT_ELIGIBLE_REASON"].ToString().Trim() == "")
                        //    {
                        //        lblStatus.Text = "Login Failed or not active!";
                        //        lblStatus.ForeColor = System.Drawing.Color.Red;
                        //    }
                        //    else
                        //    {
                        //        lblStatus.Text = dt.Rows[0]["NOT_ELIGIBLE_REASON"].ToString().Trim();
                        //        lblStatus.ForeColor = System.Drawing.Color.Red;
                        //    }
                        //}

                        Response.Redirect("Notice", false);

                    //    if (dt.Rows[0]["SHOW_NOTICE"].ToString().Trim() == "0")
                    //    {
                    //        Response.Redirect("Notice", false);
                    //    }
                    //    else if (dt.Rows[0]["SHOW_ADVT"].ToString().Trim() == "0")
                    //    {
                    //        Response.Redirect("viewadv", false);
                    //    }
                    //    else if (dt.Rows[0]["PERSONALINFO_PAGE"].ToString().Trim() == "0")
                    //    {
                    //        Response.Redirect("PersonalInfo", false);
                    //    }
                    //    else if (dt.Rows[0]["EDUCATION_PAGE"].ToString().Trim() == "0")
                    //    {
                    //        Response.Redirect("Education", false);
                    //    }
                    //    else if (dt.Rows[0]["EXPERIENCE_PAGE"].ToString().Trim() != "0")
                    //    {
                    //        Response.Redirect("workexperience", false);
                    //    }
                    //    else if (dt.Rows[0]["DOCUMENT_PAGE"].ToString().Trim() == "0")
                    //    {
                    //        Response.Redirect("uploadfile", false);
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("Preview", false);
                    //    }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        private void ValidateRegno(string xUid)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9\s,]*$");
            Match match = regex.Match(xUid);
            if (match.Success)
            {
                ViewState["SAVE"] = "YES";
            }
            else
            {
                ViewState["SAVE"] = "NO";
                return;
            }
        }
        private string GetUserIP()
        {
            // Check if the user is behind a proxy or load balancer
            string userIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            // If the user is not behind a proxy or load balancer, get the user's IP address directly
            if (string.IsNullOrEmpty(userIPAddress))
            {
                userIPAddress = Request.ServerVariables["REMOTE_ADDR"];
            }

            if (userIPAddress == "::1")
            {
                userIPAddress = "127.0.0.1";
            }

            return userIPAddress;
        }
        void Logger()
        {
            string userIpAddress = GetUserIP();
            string xQuery = "INSERT INTO ADMITCARD_LOGGER VALUES('" + txtRegno.Text.Trim().ToUpper() + "','" + userIpAddress + "',getdate())";
            int rex = site.executeNonQuery(xQuery);
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            FillCapctha();
        }
        void FillCapctha()
        {
            try
            {
                Random random = new Random();
                string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                StringBuilder captcha = new StringBuilder();
                for (int i = 0; i < 5; i++)
                {
                    captcha.Append(combination[random.Next(combination.Length)]);
                    Session["captcha"] = captcha.ToString();
                    imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}