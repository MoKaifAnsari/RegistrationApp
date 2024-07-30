using MimeKit;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace RegistrationApp
{
    public partial class Register : System.Web.UI.Page
    {
        DataTable dt;
        siteclass site = new siteclass();
        string appNo = "";
        int regLen = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("index.aspx", false);
            if (!IsPostBack)
            {
                btnSave.Visible = false;
            }
        }
        private void getCompany()
        {
            try
            {
                regLen = 5;
                long xSeq = 0;
                dt = site.getdatatable("select max(USERID) AS SEQNO from APPLICANT");
                if (dt.Rows.Count != 0)
                {
                    if (dt.Rows[0]["SEQNO"].ToString() == "")
                        xSeq = 1;
                    else
                        xSeq = Convert.ToInt32(dt.Rows[0]["SEQNO"].ToString()) + 1;
                }
                int totalZero = regLen - Convert.ToInt32(xSeq.ToString().Length);
                for (int x = 1; x <= totalZero; x++)
                {
                    appNo = appNo + "0";
                }
                appNo = "KPN" + appNo + xSeq;
                Session["APPNO"] = appNo;
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        void ValidateFields()
        {
            try
            {
                if (chkConfirm.Checked == false)
                {
                    ViewState["SAVE"] = "NO";
                    lblStatus.Text = "Please select the Confirmation Checkbox";
                    lblStatus.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblStatus.Visible = false;
                }

                if (ddlNo.SelectedItem.Text.ToString().ToUpper().Trim() == "SELECT")
                {
                    lblNo.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblNo.Visible = false;
                }

                if (txtApprenticeNo.Text.Trim() == "")
                {
                    lblApprenticeNo.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    txtApprenticeNo.Text = txtApprenticeNo.Text.Replace("'", "");
                    ViewState["SAVE"] = "YES";
                    lblApprenticeNo.Visible = false;
                }


                if (txtName.Text.Trim() == "")
                {
                    lblName.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtName.Text.Trim().ToUpper());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblName.Visible = true;
                        lblName.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblName.Visible = false;
                    }
                }

                if (ddlGender.SelectedItem.Text.ToString().ToUpper().Trim() == "SELECT")
                {
                    lblGender.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblGender.Visible = false;
                }

                if (ddlMaritalStatus.SelectedItem.Text.ToString().ToUpper().Trim() == "SELECT")
                {
                    lblMaritalStatus.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblMaritalStatus.Visible = false;
                }

                if (txtEmail.Text.Trim() == "")
                {
                    lblMail.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateEmail(txtEmail.Text.Trim());
                }

                if ((txtAdhar.Text.Trim() == "") || (txtAdhar.Text.Trim().Length < 12))
                {
                    ViewState["SAVE"] = "NO";
                    lblAdhar.Text = "Invalid Aadhar Number";
                    lblAdhar.Visible = true;
                    return;
                }
                else
                {
                    ValidateAadharNo(txtAdhar.Text.Trim());
                }
                if (ViewState["SAVE"].ToString() == "YES")
                {
                    lblAdhar.Visible = false;
                }
                else
                {
                    lblAdhar.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }


                if (txtAdhar.Text.Trim() == txtAdhar1.Text.Trim())
                {
                    ViewState["SAVE"] = "YES";
                    lblAdhar1.Visible = false;
                }
                else
                {
                    ViewState["SAVE"] = "NO";
                    lblAdhar1.Visible = true;
                    return;
                }


                if ((txtMobile.Text.Trim().Length < 10) || (txtMobile.Text.Trim() == ""))
                {
                    lblMobile.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateMobileNo(txtMobile.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblMobile.Visible = true;
                        return;
                    }
                }

                if (txtMobile.Text.Trim() != txtMobile1.Text.Trim())
                {
                    lblMobile1.Visible = true;
                    lblMobile1.Text = "Mobile Number not matching";
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    lblMobile1.Visible = false;
                    ViewState["SAVE"] = "YES";
                }

                if (txtPassword.Text.Trim() == "")
                {
                    lblPwd.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    lblPwd.Visible = false;
                    ViewState["SAVE"] = "YES";
                }

                if (txtPassword.Text.Trim() != txtPassword1.Text.Trim())
                {
                    lblPwd1.Text = "Confirm Password not matching";
                    lblPwd1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    lblPwd1.Visible = false;
                    ViewState["SAVE"] = "YES";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        protected void ValidateAadharNo(string xAadhar)     //original
        {
            ValidateNumbers(xAadhar, "Aadhar No.");

            if (xAadhar.Trim().Length != 12)
            {
                lblAdhar.Text = "Invalid Aadhar Number";
                lblAdhar.Visible = true;
                ViewState["SAVE"] = "NO";
                return;
            }

            if ((Convert.ToInt32(xAadhar.Substring(0, 1)) >= 0) && (Convert.ToInt32(xAadhar.Substring(0, 1)) <= 1))
            {
                lblAdhar.Text = "Invalid Aadhar Number";
                lblAdhar.Visible = true;
                ViewState["SAVE"] = "NO";
                return;
            }

            if (xAadhar == "333333333333" || xAadhar == "666666666666" || xAadhar == "999999999999")
            {
                lblAdhar.Text = "Invalid Aadhar Number";
                lblAdhar.Visible = true;
                ViewState["SAVE"] = "NO";
                return;
            }

            if (xAadhar.Length == 12)
            {
                if (AadharcardChk.validateVerhoeff(xAadhar))
                {

                }
                else
                {
                    lblAdhar.Text = "Invalid Aadhar Number";
                    lblAdhar.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
            }

            try
            {
                dt = site.getdatatable("select AADHAR_NO from APPLICANT where AADHAR_NO=" + xAadhar + "");
                if (dt.Rows.Count > 0)
                {
                    lblAdhar.Text = "Duplicate Aadhar Number";
                    lblAdhar.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["SAVE"] = null;

                ValidateFields();

                if (ViewState["SAVE"].ToString() == "YES")
                {
                    getCompany();
                    if (Page.IsValid)
                    {
                        string xName = null, xEmail = null, xPass = null, xMobile = "",  xAdhar = "", xGender = "", xMarital = "", xNat = "",xApprentice="", xExchNo="";

                        appNo = Session["APPNO"].ToString();

                        if (ddlNo.SelectedItem.Text.Trim().ToUpper() != "SELECT")
                            xExchNo = ddlNo.SelectedItem.Text.Trim();
                        if (txtApprenticeNo.Text.Trim() != "")
                            xApprentice = txtApprenticeNo.Text.Trim().ToUpper();

                        if (txtName.Text.Trim() != "")
                            xName = txtName.Text.Trim().ToUpper();
                        if (txtAdhar.Text.Trim() != "")
                            xAdhar = txtAdhar.Text.Trim();
                        if (txtEmail.Text.Trim() != "")
                            xEmail = txtEmail.Text.Trim().ToUpper();
                        if (txtPassword.Text.Trim() != "")
                            xPass = txtPassword.Text.Trim();
                        if (txtMobile.Text.Trim() != "")
                            xMobile = txtMobile.Text.Trim();
 
                        if (ddlGender.SelectedItem.Text.Trim().ToUpper() != "SELECT")
                            xGender = ddlGender.SelectedItem.Text.Trim();
                        if (ddlMaritalStatus.SelectedItem.Text.Trim().ToUpper() != "SELECT")
                            xMarital = ddlMaritalStatus.SelectedItem.Text.Trim();
                        if (ddlNationality.SelectedItem.Text.Trim().ToUpper() != "SELECT")
                            xNat = ddlNationality.SelectedItem.Text.Trim();

                         string xQuery = "INSERT INTO APPLICANT(REGISTERED_WITH,APPRENTICE_NO,USERID,APPLICANT_NAME,MOBILE,EMAIL,PASSWORD,AADHAR_NO,GENDER,MARITAL_STATUS,NATIONALITY,DATED) ";
                        xQuery = xQuery + " VALUES('" + xExchNo + "','" + xApprentice + "','" + appNo + "','" + xName + "'," + xMobile + ",'" + xEmail + "','" + xPass + "','" + xAdhar + "','" + xGender + "','" + xMarital + "','" + xNat + "',getdate())";
                        int rex = site.executeNonQuery(xQuery);
                        RegistrationMail(xEmail, appNo, xPass);

                        xQuery = null; xName = null; xEmail = null; xMobile = ""; xAdhar = ""; xGender = ""; xMarital = ""; xNat = ""; xPass = null;

                        if (rex == 0)
                        {
                            //lblStatus.Text = "Error, not able to save records!";
                            //pnlStatus.Visible = true;
                        }
                        else
                        {
                            Session["APPNO"] = appNo;
                            Session["NAME"] = txtName.Text.Trim();
                            Response.Redirect("PersonalInfo", false);
                            //Response.Redirect("Success");
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        protected void ValidateMobileNo(string xMobile)
        {
            ValidateNumbers(xMobile, "Mobile");

            if (txtMobile.Text.Trim().Length != 10)
            {
                lblMobile.Visible = true;
                lblMobile.Text = "Invalid Mobile No.";
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                lblMobile.Visible = false;
                ViewState["SAVE"] = "YES";
            }

            if ((Convert.ToInt32(xMobile.Substring(0, 1)) >= 0) && (Convert.ToInt32(xMobile.Substring(0, 1)) < 6))
            {
                lblMobile.Visible = true;
                lblMobile.Text = "Invalid Mobile No.";
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                lblMobile.Visible = false;
                ViewState["SAVE"] = "YES";
            }

            dt = site.getdatatable("select Mobile from APPLICANT where Mobile='" + xMobile + "'");
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["Mobile"].ToString() == xMobile)
                {
                    lblMobile.Visible = true;
                    lblMobile.Text = "Duplicate Mobile No. found";
                    ViewState["SAVE"] = "NO";
                    return;
                }
            }
            else
            {
                lblMobile.Visible = false;
                ViewState["SAVE"] = "YES";
            }
        }
        private void ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                lblMail.Visible = true;
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                lblMail.Visible = false;
                ViewState["SAVE"] = "YES";
            }

            dt = site.getdatatable("select EMAIL from APPLICANT where EMAIL='" + email + "'");
            if (dt.Rows.Count == 0)
            {
                btnVerifyOTP.Visible = true;
                lblMail.Visible = false;
                ViewState["SAVE"] = "YES";
            }
            else if (dt.Rows[0]["EMAIL"].ToString().ToLower() == email.ToLower())
            {
                lblMail.Text = "Duplicate email found";
                lblMail.Visible = true;
                btnVerifyOTP.Visible = false;
                ViewState["SAVE"] = "NO";
                return;
            }
        }
        private void RegistrationMail(string xEmail, string xRegno, string xPassword)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("HAL-Koraput", "no-reply@reg.org.in"));
            message.To.Add(new MailboxAddress(xEmail, xEmail));
            message.Subject = "HAL, Koraput Application No. is " + xRegno;

            var builder = new BodyBuilder();

            builder.TextBody = "Dear Applicant,\n\n"
                + "You have successfully registered with HAL, Koraput. In order to complete your application form please visit https://halkpt.reg.org.in and fill the necessary details and upload the required documents.\n\n"
                + "Your Login credentials are mentioned below.\n\n"

                + "Application Number : " + xRegno + "\n"
                + "Password : " + xPassword + "\n\n"

                + "Please complete your application form before 18th March, 2024.\n\n"


                + "Regards \n\n"
                + "HAL, Koraput\n\n"

                + "If you have any query regarding to your application form, please contact on help-desk 91-9234191300 or write to us e-mail on nhalkpt@reg.org.in\n\n"
                + "Note: This is an auto generated email, so please do not reply back.\n";

            //builder.Attachments.Add(Server.MapPath("../pdf/files/" + Appno + ".pdf"));
            message.Body = builder.ToMessageBody();

            var client = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                client.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                client.Connect("smtp.zeptomail.com", 587, false);
                client.Authenticate("emailapikey", "wSsVR610/RamCawvnmH7J+0xz19cBA/2REx5iVeg7XWvGvqTosc5l0zHUwT2TvlJFDY6E2Ybou58nUgA1zIJ3dUvmQ0JDyiF9mqRe1U4J3x17qnvhDzJXm9dlxCBKY4Ixglik2NjEcwm+g==");
                client.Send(message);
                client.Disconnect(true);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
        private void ValidateAlphabetWithSpace(string xAlpha)
        {
            Regex regex = new Regex("^[A-Za-z ]+$");
            Match match = regex.Match(xAlpha);
            if (!match.Success)
            {
                lblName.Visible = true;
                lblName.Text = "Only Alphabets are allowed!";
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                lblName.Visible = false;
                ViewState["SAVE"] = "YES";
            }
        }
        private void ValidateNumbers(string xNum, string xField)
        {
            Regex regex = new Regex("^[0-9]+$");
            Match match = regex.Match(xNum);
            if (!match.Success)
            {
                lblMobile.Text = "Only Numbers are allowed with " + xField;
                lblMobile.Visible = true;
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                lblMobile.Visible = false;
                ViewState["SAVE"] = "YES";
            }
        }
        private void SendOTP2Email(string xEmail)
        {
            try
            {
                int rex = 0, alreadyVerified = 0;
                btnSendOTP.Visible = true;
                Random rnd = new Random();
                int randomNumber = rnd.Next(234567, 999999);
                string xOTP = randomNumber.ToString();

                dt = site.getdatatable("select VERIFIED from EMAIL_VERIFICATION where email='" + xEmail + "' order by VERIFIED desc");
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["VERIFIED"].ToString() == "0")
                    {
                        alreadyVerified = 0;
                        rex = site.executeNonQuery("update EMAIL_VERIFICATION set otp=" + xOTP + " where email='" + xEmail + "'");
                        lblOTP.Text = "OTP sent successfully, valid for 10-mins only.";
                        lblOTP.Visible = true;
                        lblOTP.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        alreadyVerified = 1;
                        lblOTP.Text = "EMail Id already verified!";
                        lblOTP.Visible = true;
                        lblOTP.ForeColor = System.Drawing.Color.Red;
                        timer.Visible = false;
                    }
                }
                else
                {
                    alreadyVerified = 0;
                    rex = site.executeNonQuery("insert into EMAIL_VERIFICATION values('" + xEmail + "'," + xOTP + ", 0, getdate())");
                    lblOTP.Text = "OTP sent successfully, valid for 10-mins only.";
                    lblOTP.Visible = true;
                    lblOTP.ForeColor = System.Drawing.Color.Green;
                }

                if (alreadyVerified == 0)
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("HAL-Koraput", "no-reply@reg.org.in"));
                    message.To.Add(new MailboxAddress(xEmail, xEmail));
                    message.Subject = "OTP for email verification is " + xOTP + " from HAL, Koraput";

                    var builder = new BodyBuilder();

                    builder.TextBody = "Dear Applicant,\n\n"
                        + "Thanks for applying for HAL, Koraput.\n\n"
                        + "OTP for email verification is " + xOTP + "\n\n"

                        + "Regards \n\n"
                        + "HAL, Koraput\n\n\n"
                        + "Note: This is an auto generated email, so please do not reply back.\n";

                    message.Body = builder.ToMessageBody();

                    var client = new MailKit.Net.Smtp.SmtpClient();

                    client.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                    client.Connect("smtp.zeptomail.com", 587, false);
                    client.Authenticate("emailapikey", "wSsVR610/RamCawvnmH7J+0xz19cBA/2REx5iVeg7XWvGvqTosc5l0zHUwT2TvlJFDY6E2Ybou58nUgA1zIJ3dUvmQ0JDyiF9mqRe1U4J3x17qnvhDzJXm9dlxCBKY4Ixglik2NjEcwm+g==");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
        protected void btnSendOTP_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
            {
                lblMail.Text = "EMail Id can't be blank";
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                ValidateEmail(txtEmail.Text.Trim());
            }

            if (ViewState["SAVE"].ToString() == "YES")
            {
                txtEmail.ReadOnly = true;
                SendOTP2Email(txtEmail.Text.Trim());
                timer.Visible = true;
                btnSendOTP.Style["visibility"] = "hidden";
            }
            //timer.Visible = true;
            //btnSendOTP.Style["visibility"] = "hidden";         //use this code to hide buttons in javascript and add style.visibility=visible at asp.button

        }
        protected void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            try
            {
                timer.Visible = false;
                if (txtEmail.Text.Trim() == "" && txtOTP.Text.Trim() == "")
                {
                    lblOTP.Text = "Blank EMail ID/OTP not allowed";
                    lblOTP.Visible = true;
                    return;
                }
                else
                {
                    dt = site.getdatatable("select VERIFIED from EMAIL_VERIFICATION where EMAIL='" + txtEmail.Text.Trim() + "' and OTP=" + txtOTP.Text.Trim() + "");
                    if (dt.Rows.Count == 0)
                    {
                        lblOTP.Text = "OTP is not Matching!";
                        lblOTP.Visible = true;
                        lblOTP.ForeColor = System.Drawing.Color.Red;
                        //int rex = site.executeNonQuery("update applicant set EMAIL_VERIFIED=0 where USERID='" + appNo + "'");
                        //return;
                    }
                    else
                    {
                        btnSave.Visible = true;
                        int rex = site.executeNonQuery("update EMAIL_VERIFICATION set VERIFIED=1 where EMAIL='" + txtEmail.Text.Trim() + "' and OTP=" + txtOTP.Text.Trim() + "");
                        lblOTP.Text = "OTP Verified successfully!";
                        lblOTP.Visible = true;
                        lblOTP.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }

    }
}
