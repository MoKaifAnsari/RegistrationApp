using System;
using System.Data;

namespace RegistrationApp
{
    public partial class DownloadAdmitCard : System.Web.UI.Page
    {
        DataTable dt;
        siteclass site = new siteclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("Timesup.aspx");
            //return;

            try
            {
                  dt = site.getdatatable("SELECT APPLICANT_NAME,APPLIED_DISCIPLINE FROM APPLICANT WHERE USERID='" + Session["APPNO"].ToString().Trim() + "'");
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Manager-Academic Program")
                        trManager.Visible = true;
                    else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Accountant")
                        trAccountant.Visible = true;
                    else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Secretary")
                        trSecretary.Visible = true;
                    else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Programme Assistant for PGP")
                        trPGP.Visible = true;
                    else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Programme Assistant for CEP")
                        trCEP.Visible = true;
                    else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "ITeS Assistant-Web Developer")
                        trWeb.Visible = true;
                    else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "ITeS Assistant-Hardware")
                        trHardware.Visible = true;
                    else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "ITeS Assistant-MIS")
                        trMIS.Visible = true;
                    else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Maintenance Engineer-Cum-Supervisor (Civil)")
                        trCivil.Visible = true;
                    else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Maintenance Engineer-Cum-Supervisor (Electrical)")
                        trElec.Visible = true;
                    else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Library Assistant")
                        trLibrary.Visible = true;
                }



                //Applicant response 
                string xHTML = "<table border='1'> <thead> <tr>";
                dt = site.getdatatable("SELECT APPLICANT_RESPONSE.* FROM BIOMETRICS_REGISTRATION INNER JOIN APPLICANT_RESPONSE ON BIOMETRICS_REGISTRATION.ROLLNO = APPLICANT_RESPONSE.RollNumber where BIOMETRICS_REGISTRATION.USERID='" + Session["APPNO"].ToString() + "'");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i > 1)
                        {
                            xHTML += "<td>" + dt.Columns[i].ToString() + "</td>";
                        }
                    }
                    xHTML += "</tr><tr>";
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        if (i > 1)
                        {
                            xHTML += "<td>" + dt.Rows[0][i].ToString() + "</td>";
                        }
                    }
                    xHTML += " </tr></thead></table>";
                }
                lblResponse.Text = xHTML;

                //answer keys
                xHTML = "<table border='1'> <thead> <tr>";
                dt = site.getdatatable("select * from ANSWER_KEY where domain in(SELECT APPLICANT_RESPONSE.ExamName FROM BIOMETRICS_REGISTRATION INNER JOIN APPLICANT_RESPONSE ON BIOMETRICS_REGISTRATION.ROLLNO = APPLICANT_RESPONSE.RollNumber where BIOMETRICS_REGISTRATION.USERID='" + Session["APPNO"].ToString() + "')");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            xHTML += "<td>" + dt.Columns[i].ToString() + "</td>";
                        }
                    }
                    xHTML += "</tr><tr>";
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            xHTML += "<td>" + dt.Rows[0][i].ToString() + "</td>";
                        }
                    }
                    xHTML += " </tr></thead></table>";
                }
                lblAns.Text = xHTML;

            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //lblStatus.Text = "Clarification of Objections downloaded successfully!";
            //lblStatus.Visible = true;
            //string fileName = txtRegno.Text.Trim() + ".pdf";
            //string fileName = Session["APPNO"].ToString().Trim()+ ".pdf";
            string fileName = "DMI_Objections.pdf";
            string filePath = Server.MapPath(string.Format("~/img/{0}", fileName));
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.WriteFile(filePath);
            Response.Flush();
            Response.End();
        }
    }
}