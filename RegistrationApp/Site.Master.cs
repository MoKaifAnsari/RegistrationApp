using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace RegistrationApp
{
    public partial class SiteMaster : MasterPage
    {
        DataTable dt;
        siteclass site = new siteclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //if (Session["APPNO"] == null)
                    //{
                    //    Response.Redirect("SessionExpired");
                    //}
                    //else
                    //{
                    //    //lblRegno.Text = "Registration No: " + Session["APPNO"].ToString();
                    //}

                    dt = site.getdatatable("select USERID,APPLIED_DISCIPLINE from APPLICANT where USERID='" + Session["APPNO"].ToString() + "'");
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() != "")
                        {
                            lblAppno.Text = dt.Rows[0]["USERID"].ToString().Trim() + ", " + dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim();
                        }


                        //if (dt.Rows[0]["APPLICANT_NAME"].ToString().Trim() == "")
                        //    lblUserName.Text = "User Name";
                        //else
                        //    lblUserName.Text = dt.Rows[0]["APPLICANT_NAME"].ToString().Trim();

                        //if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "")
                        //    lblPost.Text = "Discipline Applied";
                        //else
                        //    lblPost.Text = "Discipline Applied: " + dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim();


                        //if (!string.IsNullOrEmpty(dt.Rows[0]["DOCUMENT_PAGE"].ToString()))
                        //{
                        //    if (dt.Rows[0]["DOCUMENT_PAGE"].ToString().Trim() == "1")
                        //        lblProfile.Visible = true;
                        //    else
                        //        lblProfile.Visible = false;
                        //}

                        //if (dt.Rows[0]["PRIMARY_PAGE"].ToString().Trim() == "1" && dt.Rows[0]["EDUCATION_PAGE"].ToString().Trim() == "1" && dt.Rows[0]["DOCUMENT_PAGE"].ToString().Trim() == "1")
                        //{
                        //    makePayment.Visible = true;
                        //}
                        //else
                        //{
                        //    makePayment.Visible = false;
                        //}
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string msg = "Fetch Error:";
                    msg += ex.Message;
                    throw new Exception(msg);
                }
            }
        }

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
        public DataTable getdatatable(string sqlStr)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataSet getdataset(string sqlStr)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }
        public int executeNonQuery(String sqlStr)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            int rex = cmd.ExecuteNonQuery();
            con.Close();
            return rex;
        }
        public int getOfflineStatus(string xFieldName)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from utility", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            int xOnline = 0;
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][xFieldName].ToString() == "1")
                    xOnline = 1;
            }
            return xOnline;
        }
        public string ValidateTextNumberWithSomeSpecialChars(string xStr)
        {
            string xStatus = "NO";
            Regex regex = new Regex("^[\\w-/. ]*$");            //Aa-zZ0-9-.space
            Match match = regex.Match(xStr);
            if (match.Success)
            {
                xStatus = "YES";
            }
            return xStatus;
        }
        public string ValidateTextWithoutSpecialChars(string xStr)
        {
            string xStatus = "NO";
            Regex regex = new Regex("^[\\w ]*$");            //Aa-zZspace
            //Regex regex = new Regex("^[A-Za-z ]+$");
            Match match = regex.Match(xStr);
            if (match.Success)
            {
                xStatus = "YES";
            }
            return xStatus;
        }
        public string ValidateNumbers(string xNum)
        {
            string xStatus = "NO";
            Regex regex = new Regex("^[0-9]+$");
            Match match = regex.Match(xNum);
            if (match.Success)
            {
                xStatus = "YES";
            }
            return xStatus;
        }
        public string calculateAge(string xDOB, string xCutOfDate, ref int zYear, ref int zMon, ref int zDays)
        {
            DateTime cuttoffDate = DateTime.Parse(xCutOfDate);
            DateTime candDateofBirth = DateTime.Parse(xDOB);
            int xYear = cuttoffDate.Year - candDateofBirth.Year;
            int xMon = cuttoffDate.Month - candDateofBirth.Month;
            if (cuttoffDate.Day < candDateofBirth.Day)
            {
                xMon--;
            }
            if (xMon < 0)
            {
                xYear--;
                xMon += 12;
            }
            int xDays = (cuttoffDate - candDateofBirth.AddMonths((xYear * 12) + xMon)).Days;
            string xStatus = string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                xYear, (xYear == 1) ? "" : "s",
                xMon, (xMon == 1) ? "" : "s",
                xDays, (xDays == 1) ? "" : "s");

            zYear = xYear;
            zMon = xMon;
            zDays = xDays;

            return xStatus;
        }
        public string calculatePeriod(string xDate1, string xDate2)
        {
            string xStatus = "";
            DateTime cuttoffDate = DateTime.Parse(xDate2);
            DateTime candDateofBirth = DateTime.Parse(xDate1);
            int xYear = cuttoffDate.Year - candDateofBirth.Year;
            int xMon = cuttoffDate.Month - candDateofBirth.Month;
            if (cuttoffDate.Day < candDateofBirth.Day)
            {
                xMon--;
            }
            if (xMon < 0)
            {
                xYear--;
                xMon += 12;
            }
            int xDays = (cuttoffDate - candDateofBirth.AddMonths((xYear * 12) + xMon)).Days;
            xStatus = string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                xYear, (xYear == 1) ? "" : "s",
                xMon, (xMon == 1) ? "" : "s",
                xDays, (xDays == 1) ? "" : "s");
            return xStatus;
        }
       
    }
}