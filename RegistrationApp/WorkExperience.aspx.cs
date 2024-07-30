using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace RegistrationApp
{
    public partial class WorkExperience : System.Web.UI.Page
    {
        DataTable dt;
        siteclass site = new siteclass();
        string appNo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int rex = site.getOfflineStatus("REGISTRATION_PROCESS_ONLINE");
            if (rex == 0)
            {
                Response.Redirect("Timesup.aspx", false);
                return;
            }

            pnlStatus.Visible = false;
            pnlSuccess.Visible = false;

            if (Session["APPNO"] == null)
            {
                Response.Redirect("SessionExpired", false);
                return;
            }
            else
            {
                appNo = Session["APPNO"].ToString();
            }
            if (!IsPostBack)
            {
                txtEnd.Text = "";
                ViewState["SAVE"] = "";
                ViewState["SLN"] = 0;
                getRecords();
                getRecordsTraining();
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //ViewState["SAVE"] = null;
                lblStatus.Text = "";
                ValidateFields();
                //if (ViewState["SAVE"] != null)
                if (!string.IsNullOrEmpty(lblStatus.Text))
                {
                    lblStatus.Visible = true;
                    //lblError.Text = ViewState["SAVE"].ToString();
                    //pnlSuccess.Visible=false;
                    //pnlStatus.Visible= false;
                    //pnlExp.Visible=true;
                    return;
                }
                else
                {
                    //pnlSuccess.Visible = false;
                    //pnlStatus.Visible = false;
                    //pnlExp.Visible = false;
                    string xOrg = "", xPosition = "", xPay = "", xBeg = "", xEnd = "", xGross = "", xQuery = "", xDesc = "", xPost="", xJob="";
                    int rex = 0;
                    ViewState["SLN"] = Convert.ToInt32(ViewState["SLN"]) + 1;

                    //INSERT PREVIOUS JOB RECORDS
                    if (txtDesignation.Text.Trim() != "")
                        xPosition = txtDesignation.Text.Trim();

                    if (txtOrg.Text.Trim() != "")
                        xOrg = txtOrg.Text.Trim();

                    if(ddlPostType.SelectedIndex>0)
                        xPost= ddlPostType.SelectedItem.ToString();

                    if (ddlJobType.SelectedIndex > 0)
                        xJob = ddlJobType.SelectedItem.ToString();

                    if (txtBegin.Text.Trim() != "")
                        xBeg = txtBegin.Text.Trim().ToString();

                    if (txtEnd.Text.Trim() != "")
                        xEnd = txtEnd.Text.Trim();

                    if (txtPay.Text.Trim() != "")
                        xPay = txtPay.Text.Trim();

                    if (txtGross.Text.Trim() != "")
                        xGross = txtGross.Text.Trim();

                    if (txtReason.Text.Trim() != "")
                        xDesc = txtReason.Text.Trim();

                    int xSln = Convert.ToInt32(ViewState["SLN"].ToString());

                    xQuery = "insert into WORK_EXPERIENCE(USERID,SLN,ORGANISATION_NAME,DESIGNATION,POST_TYPE,JOB_TYPE,JOIN_DATE,END_DATE,PAY_SCALE,GROSS_PAY,LEAVING_REASON,DATED)";
                    xQuery += " values('" + appNo + "'," + xSln + ",'" + xOrg + "','" + xPosition + "','" + xPost + "','" + xJob + "','" + xBeg + "','" + xEnd + "','" + xPay + "'," + xGross + ",'" + xDesc + "',getdate())";
                    rex = site.executeNonQuery(xQuery);
                    if (rex == 0)
                    {
                        lblStatus.Text = "Not able save the record!";
                        lblStatus.Visible = true;
                    }
                    else
                    {
                        getRecords();
                        ClearScreen();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        void ClearScreen()
        {
            txtOrg.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            ddlPostType.SelectedIndex = 0;
            ddlJobType.SelectedIndex = 0;
            txtPay.Text = string.Empty;
            txtBegin.Text = string.Empty;
            txtEnd.Text = string.Empty;
            txtGross.Text = string.Empty;
            txtReason.Text = string.Empty;
        }
        private void getRecords()
        {
            try
            {
                dt = site.getdatatable("SELECT * FROM APPLICANT WHERE USERID='" + appNo + "'");
                gvProducts.DataSource = dt;
                gvProducts.DataBind();

                dt = site.getdatatable("SELECT VRS_TAKEN,INTERVIEWED_BY_HAL,POST_INTERVIEWED,INTERVIEWED_DATE,INTERVIEWED_VENUE,RELATIVE_WITH_HAL,RELATIVE_NAME,RELATIVE_DESIG,RELATIVE_DIVISION,RELATIVE_DESC,POLITICAL_RELATION,POLITICAL_PARTY_NAME,POLITICAL_ACTIVITY,POLITICAL_PERIOD,POLITICAL_PARTICIPATION,POLITICAL_OFFICE_HELD FROM APPLICANT WHERE USERID='" + appNo + "'");
                if(dt.Rows.Count > 0)
                {
                    ddlVRS.SelectedValue = dt.Rows[0]["VRS_TAKEN"].ToString() !="" ? dt.Rows[0]["VRS_TAKEN"].ToString() : "Select";

                    ddlInterview.SelectedValue = dt.Rows[0]["INTERVIEWED_BY_HAL"].ToString() != "" ? dt.Rows[0]["INTERVIEWED_BY_HAL"].ToString() : "Select";

                    if (dt.Rows[0]["INTERVIEWED_BY_HAL"].ToString().ToUpper() == "YES")
                    {
                        divInterview.Visible = true;
                        txtIntPost.Text = dt.Rows[0]["POST_INTERVIEWED"].ToString().Trim();
                        txtIntDate.Text = dt.Rows[0]["INTERVIEWED_DATE"].ToString().Trim();
                        txtIntVenue.Text = dt.Rows[0]["INTERVIEWED_VENUE"].ToString().Trim();
                    }
                    else
                    {
                        divInterview.Visible = false;
                        txtIntPost.Text = "";
                        txtIntDate.Text = "";
                        txtIntVenue.Text = "";
                    }

                    ddlRelative.SelectedValue = dt.Rows[0]["RELATIVE_WITH_HAL"].ToString() != "" ? dt.Rows[0]["RELATIVE_WITH_HAL"].ToString() : "Select";
                    if (dt.Rows[0]["RELATIVE_WITH_HAL"].ToString().ToUpper() == "YES")
                    {
                        divRelative.Visible = true;
                        txtName.Text = dt.Rows[0]["RELATIVE_NAME"].ToString().Trim();
                        txtDesig.Text = dt.Rows[0]["RELATIVE_DESIG"].ToString().Trim();
                        txtDiv.Text = dt.Rows[0]["RELATIVE_DIVISION"].ToString().Trim();
                        txtDesc.Text = dt.Rows[0]["RELATIVE_DESC"].ToString().Trim();
                    }
                    else
                    {
                        divRelative.Visible = false;
                        txtName.Text = "";
                        txtDesig.Text = "";
                        txtDiv.Text = "";
                        txtDesc.Text = "";
                    }

                    ddlPolitics.SelectedValue = dt.Rows[0]["POLITICAL_RELATION"].ToString() != "" ? dt.Rows[0]["POLITICAL_RELATION"].ToString() : "Select";
                    if (dt.Rows[0]["POLITICAL_RELATION"].ToString().ToUpper() == "YES")
                    {
                        divPolitics.Visible = true;
                        txtParty.Text = dt.Rows[0]["POLITICAL_PARTY_NAME"].ToString().Trim();
                        txtParticular.Text = dt.Rows[0]["POLITICAL_ACTIVITY"].ToString().Trim();
                        txtPeriod1.Text = dt.Rows[0]["POLITICAL_PERIOD"].ToString().Trim();
                        txtNature.Text = dt.Rows[0]["POLITICAL_PARTICIPATION"].ToString().Trim();
                        txtOffice.Text = dt.Rows[0]["POLITICAL_OFFICE_HELD"].ToString().Trim();
                    }
                    else
                    {
                        divPolitics.Visible= false;
                        txtParty.Text = "";
                        txtParticular.Text = "";
                        txtPeriod1.Text = "";
                        txtNature.Text = "";
                        txtOffice.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        private void ValidateFields()
        {
            if (txtOrg.Text.Trim() == "")
                BindErrors("Organisation");

            if (txtDesignation.Text.Trim() == "")
                BindErrors("Designation");

            if(ddlPostType.SelectedIndex==0)
                BindErrors("Central Govt./State Govt.");

            if (ddlJobType.SelectedIndex==0)
                BindErrors("Contract Govt./Ad-hoc");

            if (txtBegin.Text.Trim() == "__-__-____")
                BindErrors("From Date");

            if (txtEnd.Text.Trim() == "__-__-____")
                BindErrors("To Date");

            if (txtPay.Text.Trim() == "")
                BindErrors("Pay Scale");

            if (txtGross.Text.Trim() == "")
                BindErrors("Gross Pay");

            if (txtReason.Text.Trim() == "")
                BindErrors("Reason for Leaving");

        }
        private void ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                BindErrors("Invalid Email ID");
            }
        }
        void BindErrors(string xErr)
        {
            if (string.IsNullOrEmpty(lblStatus.Text))
            {
                lblStatus.Text = xErr;
            }
            else
            {
                lblStatus.Text += ", " + xErr;
            }
            lblStatus.Visible = true;
        }
        protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int xSeq = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "deleteItem")
                {
                    int rex = site.executeNonQuery("delete from WORK_EXPERIENCE where seq=" + xSeq + "");
                    if (rex == 1)
                    {
                        lblError.Text = "One record deleted successfully!";
                        pnlStatus.Visible = true;
                        pnlSuccess.Visible = false;
                        getRecords();
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        private void ValidateAlphabetWithSpace(string xAlpha, string xField)
        {
            Regex regex = new Regex("^[A-Za-z ]+$");
            Match match = regex.Match(xAlpha);
            if (!match.Success)
            {
                BindErrors("Only Alphabets are allowed with " + xField);
            }
        }
        void ValidateExperience()
        {
            if (CheckBox1.Checked == false)
            {
                //ViewState["SAVE"] = "NO";
                //lblStatus.Text = "Please select the Confirmation Checkbox";
                BindErrors("Please select the Confirmation Checkbox");
                //lblStatus.ForeColor = System.Drawing.Color.Red;
                //lblStatus.Visible = true;
                return;
            }

            String xPost = "";
            dt = site.getdatatable("SELECT APPLIED_DISCIPLINE FROM APPLICANT WHERE USERID='" + appNo + "'");
            if (dt.Rows.Count > 0)
            {
                xPost = dt.Rows[0]["APPLIED_DISCIPLINE"].ToString();
            }

            dt = site.getdatatable("SELECT * FROM WORK_EXPERIENCE WHERE USERID='" + appNo + "' order by SEQ");
            gvProducts.DataSource = dt;
            gvProducts.DataBind();

        }

        private void ValidateFieldsonSave()
        {
 
            if (ddlVRS.SelectedIndex == 0)
                BindErrors("Have you availed VRS");

            if (ddlInterview.SelectedIndex == 0)
                BindErrors("Have you been interviewed by HAL");

            if (ddlInterview.SelectedIndex == 1)
            {
                if (txtIntPost.Text.Trim() == "")
                    BindErrors("Post Interviewed");

                if (txtIntDate.Text.Trim() == "")
                    BindErrors("Date of Interviewed");

                if (txtIntVenue.Text.Trim() == "")
                    BindErrors("Venue of Interviewed");
            }

            if (ddlRelative.SelectedIndex == 0)
                BindErrors("Relatives working in HAL");

            if (ddlRelative.SelectedIndex == 1)
            {
                if (txtName.Text.Trim() == "")
                    BindErrors("Relative Name");
                if (txtDesig.Text.Trim() == "")
                    BindErrors("Relative Designation");
                if (txtDiv.Text.Trim() == "")
                    BindErrors("Relative Division");
                if (txtDesc.Text.Trim() == "")
                    BindErrors("Other Description");
            }
            
            if (ddlPolitics.SelectedIndex == 0)
                BindErrors("Member of Political Party");

            if (ddlPolitics.SelectedIndex == 1)
            {
                if (txtParty.Text.Trim() == "")
                    BindErrors("Polictical Party Name");

                if (txtParticular.Text.Trim() == "")
                    BindErrors("Particulars of Polictical Activity");

                if (txtPeriod1.Text.Trim() == "")
                    BindErrors("Period");

                if (txtNature.Text.Trim() == "")
                    BindErrors("Nature of Polictical Activity");

                if (txtOffice.Text.Trim() == "")
                    BindErrors("Office Held");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "";
                if (string.IsNullOrEmpty(lblStatus.Text))
                {
                    ValidateExperience();
                }

                if (string.IsNullOrEmpty(lblStatus.Text))
                {
                    ValidateFieldsonSave();
                }

                if (!string.IsNullOrEmpty(lblStatus.Text))
                {
                    lblStatus.Text += " fields can't be blank";
                    lblStatus.Visible = true;
                    return;
                }
                else
                {
                    string xQry = "";
                    if (ddlInterview.SelectedIndex>0)
                    {   
                        xQry= "INTERVIEWED_BY_HAL='"+ ddlInterview.SelectedItem.Text + "'";

                        if (!string.IsNullOrEmpty(txtIntPost.Text.Trim()))
                            xQry += ", POST_INTERVIEWED='"+ txtIntPost.Text.Trim() + "'";

                        if (!string.IsNullOrEmpty(txtIntDate.Text.Trim()))
                            xQry += ", INTERVIEWED_DATE='" + DateTime.Parse(txtIntDate.Text).ToString("dd/MM/yyyy") + "'";

                        if (!string.IsNullOrEmpty(txtIntVenue.Text.Trim()))
                            xQry += ", INTERVIEWED_VENUE='" + txtIntVenue.Text.Trim() + "'";
                    }
                    else
                    {
                        xQry = "INTERVIEWED_BY_HAL='No',POST_INTERVIEWED=null,INTERVIEWED_DATE=null,INTERVIEWED_VENUE=null";
                    }

                    if(ddlRelative.SelectedIndex>0)
                    {
                        xQry += ",RELATIVE_WITH_HAL='"+ ddlRelative.SelectedItem.Text + "'";

                        if (!string.IsNullOrEmpty(txtName.Text.Trim()))
                            xQry += ", RELATIVE_NAME='" + txtName.Text.Trim() + "'";

                        if (!string.IsNullOrEmpty(txtDesig.Text.Trim()))
                            xQry += ", RELATIVE_DESIG='" + txtDesig.Text.Trim() + "'";

                        if (!string.IsNullOrEmpty(txtDiv.Text.Trim()))
                            xQry += ", RELATIVE_DIVISION='" + txtDiv.Text.Trim() + "'";

                        if (!string.IsNullOrEmpty(txtDesc.Text.Trim()))
                            xQry += ", RELATIVE_DESC='" + txtDesc.Text.Trim() + "'";
                    }
                    else
                    {
                        xQry += ",RELATIVE_WITH_HAL='No',RELATIVE_NAME=null,RELATIVE_DESIG=null,RELATIVE_DIVISION=null,RELATIVE_DESC=null";
                    }

                    if (ddlPolitics.SelectedIndex>0)
                    {
                        xQry += ",POLITICAL_RELATION='"+ ddlPolitics.SelectedItem.Text + "'";
                        if (!string.IsNullOrEmpty(txtParty.Text.Trim()))
                            xQry += ", POLITICAL_PARTY_NAME='" + txtParty.Text.Trim() + "'";

                        if (!string.IsNullOrEmpty(txtParticular.Text.Trim()))
                            xQry += ", POLITICAL_ACTIVITY='" + txtParticular.Text.Trim() + "'";

                        if (!string.IsNullOrEmpty(txtPeriod1.Text.Trim()))
                            xQry += ", POLITICAL_PERIOD='" + txtPeriod1.Text.Trim() + "'";

                        if (!string.IsNullOrEmpty(txtNature.Text.Trim()))
                            xQry += ", POLITICAL_PARTICIPATION='" + txtNature.Text.Trim() + "'";

                        if (!string.IsNullOrEmpty(txtOffice.Text.Trim()))
                            xQry += ", POLITICAL_OFFICE_HELD='" + txtOffice.Text.Trim() + "'";
                    }
                    else
                    {
                        xQry += ",POLITICAL_RELATION='No',POLITICAL_PARTY_NAME=null,POLITICAL_ACTIVITY=null,POLITICAL_PERIOD=null,POLITICAL_PARTICIPATION=null,POLITICAL_OFFICE_HELD=null";
                    }

                    if (ddlVRS.SelectedIndex>0)
                        xQry += ", VRS_TAKEN='" + ddlVRS.SelectedItem.Text.Trim() + "'";

                    xQry = "UPDATE APPLICANT SET EXPERIENCE_PAGE=1," + xQry + " WHERE USERID='" + appNo + "'";

                    int rex = site.executeNonQuery(xQry);
                    if (rex == 0)
                    {
                        lblStatus.Text = "Not able save the records!";
                        lblStatus.Visible = true;
                        //pnlStatus.Visible = true;
                        //pnlSuccess.Visible = false;
                    }
                    else
                    {
                        rex = site.executeNonQuery("update APPLICANT set DOCUMENT_PAGE=0,UPLOAD_PHOTO=0,UPLOAD_SIGN=0,UPLOAD_ADHAR=0 WHERE USERID='" + appNo + "'");
                        Response.Redirect("UploadFile", false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        private void ValidateNumbers(string xNum)
        {
            Regex regex = new Regex("^[0-9]+$");
            Match match = regex.Match(xNum);
            if (!match.Success)
            {
                BindErrors("Only Numbers are allowed with Phone No.");
            }
        }
        protected void btnPrev_Click(object sender, EventArgs e)
        {
            Response.Redirect("Education", false);
        }
        private void ValidateTrainingFields()
        {
            if (txtOrg1.Text.Trim() == "")
                BindErrors("Organisation");

            if (txtProgram.Text.Trim() == "")
                BindErrors("Position");

            if (txtDtBeg.Text.Trim() == "__-__-____")
                BindErrors("Begin Date");
 

            if (txtDtEnd.Text.Trim() == "__-__-____")
                BindErrors("End Date");
         }
        void ClearScreenTraining()
        {
            txtOrg1.Text = string.Empty;
            txtProgram.Text = string.Empty;
            txtDtBeg.Text = string.Empty;
            txtDtEnd.Text = string.Empty;
 
        }
        private void getRecordsTraining()
        {
            try
            {
                dt = site.getdatatable("SELECT * FROM TRAINING_PROGRAM WHERE USERID='" + appNo + "' order by SEQ");
                gvTraining.DataSource = dt;
                gvTraining.DataBind();

                //int totDays = 0;
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    if (!string.IsNullOrEmpty(dt.Rows[i]["DAYS"].ToString()))
                //    {
                //        totDays += Convert.ToInt32(dt.Rows[i]["DAYS"].ToString());
                //    }
                //}

                //if (totDays > 0)
                //{

                //    TimeSpan ts = TimeSpan.FromDays(totDays);
                //    DateTime age = DateTime.MinValue + ts;

                //    int xYear = age.Year - 1;
                //    int xMon = age.Month - 1;
                //    int xDays = age.Day - 1;
                //    string xDD = xYear + "Year " + xMon + "Month " + xDays + "Days";

                //    gvProducts.FooterRow.Cells[3].Text = "Total Experiences";
                //    gvProducts.FooterRow.Cells[3].Font.Bold = true;
                //    gvProducts.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Left;

                //    gvProducts.FooterRow.Cells[8].Text = xDD;
                //    gvProducts.FooterRow.Cells[8].Font.Bold = true;
                //    gvProducts.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        protected void btnAddRex_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "";
                ValidateTrainingFields();
                if (!string.IsNullOrEmpty(lblStatus.Text))
                {
                    lblStatus.Visible = true;
                    return;
                }
                else
                {
                    string xOrg = "", xPosition = "", xBeg = "", xEnd = "", xQuery = "";
                    int rex = 0;
                    //ViewState["SLN"] = Convert.ToInt32(ViewState["SLN"]) + 1;

                    //INSERT PREVIOUS JOB RECORDS
                    if (txtOrg1.Text.Trim() != "")
                        xOrg = txtOrg1.Text.Trim();

                    if (txtProgram.Text.Trim() != "")
                        xPosition = txtProgram.Text.Trim();

                    if (txtDtBeg.Text.Trim() != "")
                        xBeg = txtDtBeg.Text.Trim().ToString();

                    if (txtDtEnd.Text.Trim() != "")
                        xEnd = txtDtEnd.Text.Trim();

 
                    xQuery = "insert into TRAINING_PROGRAM(USERID,ORGANISATION_NAME,PROGRAM_NAME,JOIN_DATE,END_DATE,DATED)";
                    xQuery += " values('" + appNo + "','" + xOrg + "','" + xPosition + "','" + xBeg + "','" + xEnd + "',getdate())";
                    rex = site.executeNonQuery(xQuery);
                    if (rex == 0)
                    {
                        lblStatus.Text = "Not able save the record!";
                        lblStatus.Visible = true;
                    }
                    else
                    {
                        getRecordsTraining();
                        ClearScreenTraining();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        protected void gvTraining_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int xSeq = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "deleteItem")
                {
                    int rex = site.executeNonQuery("delete from TRAINING_PROGRAM where seq=" + xSeq + "");
                    if (rex == 1)
                    {
                        lblError.Text = "One record deleted successfully!";
                        pnlStatus.Visible = true;
                        pnlSuccess.Visible = false;
                        getRecords();
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        //protected void chkInterview_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkInterview.Checked)
        //    {
        //        divInterview.Visible = true;
        //        txtIntPost.Focus();
        //    }
        //    else
        //    {
        //        divInterview.Visible = false;
        //    }
        //}
        //protected void chkRelative_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkRelative.Checked)
        //    {
        //        divRelative.Visible = true;
        //        txtName.Focus();
        //    }
        //    else
        //    {
        //        divRelative.Visible = false;
        //    }

        //}
        //protected void chkPolitics_CheckedChanged(object sender, EventArgs e)
        //{

        //   if (chkPolitics.Checked)
        //    {
        //        divPolitics.Visible = true;
        //        txtParty.Focus();
        //    }
        //    else
        //    {
        //        divPolitics.Visible = false;
        //    }
        //}

        protected void ddlInterview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInterview.SelectedIndex == 1)
            {
                divInterview.Visible = true;
            }
            else
            {
                divInterview.Visible = false;
            }
        }
        protected void ddlRelative_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (ddlRelative.SelectedIndex == 1)
            {
                divRelative.Visible = true;
            }
            else
            {
                divRelative.Visible = false;
            }
        }
        protected void ddlPolitics_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (ddlPolitics.SelectedIndex == 1)
            {
                divPolitics.Visible = true;
            }
            else
            {
                divPolitics.Visible = false;
            }
        }
        
    }
}