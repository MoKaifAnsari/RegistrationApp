using System;

namespace RegistrationApp
{
    public partial class Index : System.Web.UI.Page
    {
        //DataTable dt;
        //siteclass site = new siteclass();
        protected void Page_Load(object sender, EventArgs e)
        {

            //lblStatus.Visible = false;
            if (!IsPostBack)
            {
                Session.RemoveAll();
                Session.Clear();

                Session["security"] = "OmNamah#Shivay$!";
               // FillCapctha();
            }
        }
        //void FillCapctha()
        //{
        //    try
        //    {
        //        Random random = new Random();
        //        string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        //        StringBuilder captcha = new StringBuilder();
        //        for (int i = 0; i < 5; i++)
        //        {
        //            captcha.Append(combination[random.Next(combination.Length)]);
        //            Session["captcha"] = captcha.ToString();
        //            //txtCaptcha.Text = captcha.ToString();
        //            imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        //protected void btnLogin_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        lblStatus.ForeColor = System.Drawing.Color.Red;
        //        //if (txtRegno.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtCaptcha.Text.Trim() == "")
        //        if (txtRegno.Text.Trim() == "" || txtPassword.Text.Trim() == "")
        //        {
        //            lblStatus.Text = "Sorry, Blank fields are not allowed!";
        //            lblStatus.Visible = true;
        //            return;
        //        }

        //        //if (txtCaptcha.Text.Trim() != Session["captcha"].ToString())
        //        //{
        //        //    lblStatus.Text = "Captcha not Matching";
        //        //    lblStatus.Visible = true;
        //        //    return;
        //        //}

        //        ValidateRegno(txtRegno.Text.Trim());

        //        if (ViewState["SAVE"].ToString() == "NO")
        //        {
        //            lblStatus.Text = "Special Chars not allowed with User ID";
        //            lblStatus.Visible = true;
        //            return;
        //        }
        //        else
        //        {
        //            dt = site.getdatatable("select * from APPLICANT where USERID='" + txtRegno.Text.Trim() + "' and PASSWORD='" + txtPassword.Text.Trim() + "'");
        //            if (dt.Rows.Count == 0)
        //            {
        //                lblStatus.Text = "Login Failed!, Registration No or Password is not correct!";
        //                lblStatus.Visible = true;
        //                return;
        //            }
        //            else
        //            {

        //                //CREATE LOG
        //                Logger();

        //                Session["APPNO"] = txtRegno.Text.Trim().ToUpper();
        //                if (!string.IsNullOrEmpty(dt.Rows[0]["APPLICANT_NAME"].ToString().Trim()))
        //                    Session["APPLICANT_NAME"] = dt.Rows[0]["APPLICANT_NAME"].ToString();

        //                dt = site.getdatatable("select * from PAYMENT_STATUS where USERID='" + txtRegno.Text.Trim() + "' and STATUS='SUCCESS'");
        //                if (dt.Rows.Count == 0)
        //                {
        //                    lblStatus.Text = "Your Application is not completed!";
        //                    lblStatus.Visible = true;
        //                    return;
        //                }
        //                else
        //                {
        //                    dt = site.getdatatable("select USERID from BIOMETRICS_REGISTRATION where USERID='" + txtRegno.Text.Trim() + "'");
        //                    if (dt.Rows.Count == 0)
        //                    {
        //                        lblStatus.Text = "You are not appeared the examination!";
        //                        lblStatus.Visible = true;
        //                        return;
        //                    }
        //                    else
        //                    {
        //                        Response.Redirect("WorkExperience.aspx", false);
        //                        // Response.Redirect("Result.aspx", false);
        //                        //Response.Redirect("Objections.aspx", false);
        //                        //Response.Redirect("DownloadAdmitCard.aspx", false);
        //                        //Response.Redirect("Preview", false);
        //                    }
        //                }

        //                //if ((!string.IsNullOrEmpty(dt.Rows[0]["MOBILE_VERIFIED"].ToString().Trim())) && (!string.IsNullOrEmpty(dt.Rows[0]["EMAIL_VERIFIED"].ToString().Trim())))
        //                //{
        //                //    if ((dt.Rows[0]["MOBILE_VERIFIED"].ToString().Trim() == "1") && (dt.Rows[0]["EMAIL_VERIFIED"].ToString().Trim() == "1"))
        //                //    {
        //                //        if (string.IsNullOrEmpty(dt.Rows[0]["PERSONALINFO_PAGE"].ToString().Trim()))
        //                //        {
        //                //            Response.Redirect("PersonalInfo", false);
        //                //        }
        //                //        else if (string.IsNullOrEmpty(dt.Rows[0]["EDUCATION_PAGE"].ToString().Trim()))
        //                //        {
        //                //            Response.Redirect("Education", false);
        //                //        }
        //                //        else if (string.IsNullOrEmpty(dt.Rows[0]["WORK_EXP_PAGE"].ToString().Trim()))
        //                //        {
        //                //            Response.Redirect("workexperience", false);
        //                //        }
        //                //        else if (string.IsNullOrEmpty(dt.Rows[0]["DOCUMENT_PAGE"].ToString().Trim()))
        //                //        {
        //                //            Response.Redirect("uploadfile", false);

        //                //        }
        //                //        else
        //                //        {
        //                //            Response.Redirect("Preview", false);
        //                //        }
        //                //    }
        //                //    else
        //                //    {
        //                //        Response.Redirect("Verification", false);
        //                //    }
        //                //}
        //                //else
        //                //{
        //                //    Response.Redirect("Verification", false);
        //                //}
        //            }
        //        }
        //    }
        //    catch (System.Threading.ThreadAbortException)
        //    {
        //        // do nothing
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception("Fetch Error:" + ex.Message);
        //    }
        //}
        //private string GetUserIP()
        //{
        //    // Check if the user is behind a proxy or load balancer
        //    string userIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        //    // If the user is not behind a proxy or load balancer, get the user's IP address directly
        //    if (string.IsNullOrEmpty(userIPAddress))
        //    {
        //        userIPAddress = Request.ServerVariables["REMOTE_ADDR"];
        //    }

        //    if (userIPAddress == "::1")
        //    {
        //        userIPAddress = "127.0.0.1";
        //    }

        //    return userIPAddress;
        //}
        //private string GetUserIPAddress()
        //{
        //    string ipAddress = "";
        //    // Check for the "X-Forwarded-For" header to get the real client IP address if the application is behind a proxy or load balancer
        //    string xForwardedFor = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        //    if (!string.IsNullOrEmpty(xForwardedFor))
        //    {
        //        string[] addresses = xForwardedFor.Split(',');
        //        ipAddress = addresses[0];
        //    }
        //    // If "X-Forwarded-For" header is empty or not present, get the remote client IP address
        //    if (string.IsNullOrEmpty(ipAddress))
        //    {
        //        ipAddress = Request.ServerVariables["REMOTE_ADDR"];
        //    }

        //    if (ipAddress == "::1")
        //    {
        //        ipAddress = "127.0.0.1";
        //    }
        //    return ipAddress;
        //}
        //void Logger()
        //{
        //    //string userIpAddress = GetUserIPAddress();  //try this also
        //    string userIpAddress = GetUserIP();

        //    string xQuery = "INSERT INTO LOGGER VALUES('" + txtRegno.Text.Trim().ToUpper() + "','" + userIpAddress + "',getdate())";
        //    int rex = site.executeNonQuery(xQuery);

        //    //string xxDate = DateTime.Parse(DateTime.Now.ToString()).ToString("MM/dd/yyyy HH:mm:ss");
        //    //int rex = site.executeNonQuery("INSERT INTO LOG_HISTORY(USERID,DATED,LOGGED_IN) VALUES('" + txtRegno.Text.Trim() + "','" + xxDate + "',1)");
        //}
        //protected void btnRefresh_Click(object sender, EventArgs e)
        //{
        //    //FillCapctha();
        //}
        //private void ValidateRegno(string xUid)
        //{
        //    Regex regex = new Regex(@"^[a-zA-Z0-9\s,]*$");
        //    Match match = regex.Match(xUid);
        //    if (match.Success)
        //    {
        //        ViewState["SAVE"] = "YES";
        //    }
        //    else
        //    {
        //        ViewState["SAVE"] = "NO";
        //        return;
        //    }
        //}
  
    }
}