using System;
using System.Data;
using System.Configuration;
using Org.BouncyCastle.Asn1.Cmp;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;

namespace RegistrationApp
{
    public partial class PersonalInfoPreview : System.Web.UI.Page
    {
        DataTable dt;
        siteclass site = new siteclass();
        string cutOffDate = "01-05-2024";
        private string AppNo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                 if (Session["APPNO"] == null)
                    return;
                else
                {
                    AppNo = Session["APPNO"].ToString();

                }
                if (!IsPostBack)
                {
                    dt = site.getdatatable("select * FROM APPLICANT where USERID='" + AppNo + "'");
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["USERID"].ToString().Trim() != "")
                        {
                            lblAppno.Text = "&nbsp;" + dt.Rows[0]["USERID"].ToString().Trim();
                        }

                        if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() != "")
                            lblPost.Text = dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim();


                        if (dt.Rows[0]["DOB"].ToString().Trim() != "")
                        {
                            DateTime xDate1 = DateTime.Parse(dt.Rows[0]["DOB"].ToString());
                            lblDOB.Text = "&nbsp;" + xDate1.ToString("dd/MM/yyyy") + " ( Age as on "+ cutOffDate+" is " + dt.Rows[0]["APPLICANT_AGE"].ToString().Trim() + " )";
                        }

                        if (dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim() != "")
                            lblCategory.Text = "&nbsp;" + dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim();
                        
                        if (dt.Rows[0]["MOBILE"].ToString().Trim() != "")
                            lblMobile.Text = "&nbsp;" + dt.Rows[0]["MOBILE"].ToString().Trim();

                        if (dt.Rows[0]["AADHAR_NO"].ToString().Trim() != "")
                            lblAdhar.Text = "&nbsp;" + dt.Rows[0]["AADHAR_NO"].ToString().Trim();

                        
                        if (!string.IsNullOrEmpty(dt.Rows[0]["APPLICANT_Name"].ToString().Trim()))
                        {
                            lblName.Text = "&nbsp;" + dt.Rows[0]["APPLICANT_Name"].ToString().Trim();
                        }

                        if (dt.Rows[0]["FATHER_NAME"].ToString().Trim() != "")
                            lblFather.Text = "&nbsp;" + dt.Rows[0]["FATHER_NAME"].ToString().Trim();
                        if (dt.Rows[0]["MOTHER_NAME"].ToString().Trim() != "")
                            lblMother.Text = "&nbsp;" + dt.Rows[0]["MOTHER_NAME"].ToString().Trim();

                        if (dt.Rows[0]["GENDER"].ToString().Trim() != "")
                            lblGender.Text = "&nbsp;" + dt.Rows[0]["GENDER"].ToString().Trim();

                        if (dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim() != "")
                        {
                            lblCategory.Text = "&nbsp;" + dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim();
                            
                        }

                        if (dt.Rows[0]["CASTE_CERT_NO"].ToString().Trim() != "")
                            lblCastNo.Text = dt.Rows[0]["CASTE_CERT_NO"].ToString().Trim();
                        if (dt.Rows[0]["CASTE_CERT_ISSUE_DATE"].ToString().Trim() != "")
                        {
                            DateTime xDate = DateTime.Parse(dt.Rows[0]["CASTE_CERT_ISSUE_DATE"].ToString());
                            lblCasteDate.Text = xDate.ToString("dd/MM/yyyy");
                        }
                        if (dt.Rows[0]["PWD_APPLIED"].ToString().Trim() != "")
                        {
                            lblPH.Text = dt.Rows[0]["PWD_APPLIED"].ToString().Trim();
                        }
                       
                        if (dt.Rows[0]["PWD_TYPE"].ToString().Trim() == "")
                            lblPwdType.Text = "";
                        else
                            lblPwdType.Text = dt.Rows[0]["PWD_TYPE"].ToString().Trim();
                        
                        if (dt.Rows[0]["PWD_PERCENT"].ToString().Trim() == "0")
                            lblPHPer.Text = "";
                        else
                            lblPHPer.Text = dt.Rows[0]["PWD_PERCENT"].ToString().Trim();

                        if (dt.Rows[0]["MARITAL_STATUS"].ToString().Trim() != "")
                            lblMarital.Text = "&nbsp;" + dt.Rows[0]["MARITAL_STATUS"].ToString().Trim();

                        lblNationality.Text = "&nbsp;INDIAN";

                        if (dt.Rows[0]["EMAIL"].ToString().Trim() != "")
                            lblMail.Text = "&nbsp;" + dt.Rows[0]["EMAIL"].ToString().Trim();
                        if (dt.Rows[0]["MOBILE"].ToString().Trim() != "")
                            lblMobile.Text = "&nbsp;" + dt.Rows[0]["MOBILE"].ToString().Trim();
                        if (dt.Rows[0]["AADHAR_NO"].ToString().Trim() != "")
                            lblAdhar.Text = "&nbsp;" + dt.Rows[0]["AADHAR_NO"].ToString().Trim();

                        if (dt.Rows[0]["RELIGION_NAME"].ToString().Trim() != "")
                            lblReligion.Text = "&nbsp;" + dt.Rows[0]["RELIGION_NAME"].ToString().Trim();
                     
                        if (dt.Rows[0]["DOMICILE_STATE"].ToString().Trim() != "")
                            lblDomState.Text = "&nbsp;" + dt.Rows[0]["DOMICILE_STATE"].ToString().Trim();

                        if (dt.Rows[0]["JK_DOMICILE"].ToString().Trim() != "")
                            lblDom.Text = "&nbsp;" + dt.Rows[0]["JK_DOMICILE"].ToString().Trim();
                        if (dt.Rows[0]["DOMICILE_DATE"].ToString().Trim() != "")
                        {
                            DateTime xDate = DateTime.Parse(dt.Rows[0]["DOMICILE_DATE"].ToString());
                            lblDomDate1.Text = xDate.ToString("dd/MM/yyyy");
                        }
                      
                        if (dt.Rows[0]["HOUSE_NO_CA"].ToString().Trim() != "")
                            lblAddress1.Text = dt.Rows[0]["HOUSE_NO_CA"].ToString().Trim()+","+dt.Rows[0]["AREA_CA"].ToString().Trim() + "," + dt.Rows[0]["LANDMARK_CA"].ToString().Trim() + "," + dt.Rows[0]["CITY_CA"].ToString().Trim() + "," + dt.Rows[0]["DISTRICT_CA"].ToString().Trim() + "," + dt.Rows[0]["STATE_CA"].ToString().Trim() + "," + dt.Rows[0]["PIN_CA"].ToString().Trim() + "," + dt.Rows[0]["POST_OFFICE_CA"].ToString().Trim() + "," + dt.Rows[0]["RAILWAY_STATION_CA"].ToString().Trim();

                        if (dt.Rows[0]["HOUSE_NO_PA"].ToString().Trim() != "")
                            lblAddress2.Text = dt.Rows[0]["HOUSE_NO_PA"].ToString().Trim() + "," + dt.Rows[0]["AREA_PA"].ToString().Trim() + "," + dt.Rows[0]["LANDMARK_PA"].ToString().Trim() + "," + dt.Rows[0]["CITY_PA"].ToString().Trim() + "," + dt.Rows[0]["DISTRICT_PA"].ToString().Trim() + "," + dt.Rows[0]["STATE_PA"].ToString().Trim() + "," + dt.Rows[0]["PIN_PA"].ToString().Trim() + "," + dt.Rows[0]["POST_OFFICE_PA"].ToString().Trim() + "," + dt.Rows[0]["RAILWAY_STATION_PA"].ToString().Trim();



                        if (dt.Rows[0]["RELEVANT_EXP"].ToString().Trim() != "")
                            lblRelExp1.Text = "&nbsp;" + dt.Rows[0]["RELEVANT_EXP"].ToString().Trim();
                        if (dt.Rows[0]["REL_YEARS"].ToString().Trim() != "")
                            lblPeriod.Text = "&nbsp;" + dt.Rows[0]["REL_YEARS"].ToString().Trim()+" year(s) " + dt.Rows[0]["REL_MONTH"].ToString().Trim()+" month(s) " + dt.Rows[0]["REL_DAY"].ToString().Trim() + " day(s)";

                         if (dt.Rows[0]["EX_SERVICE_MAN"].ToString().Trim() != "")
                            lblExService.Text = "&nbsp;" + dt.Rows[0]["EX_SERVICE_MAN"].ToString().Trim();
                        if (dt.Rows[0]["ENROLL_DATE"].ToString().Trim() != "")
                            lblExService1.Text = "&nbsp;" + dt.Rows[0]["ENROLL_DATE"].ToString().Trim() + " - " + dt.Rows[0]["DISCHARGE_DATE"].ToString().Trim();

                        if (dt.Rows[0]["HAL_APPRENTICESHIP"].ToString().Trim() != "")
                            lblAppHal.Text = "&nbsp;" + dt.Rows[0]["HAL_APPRENTICESHIP"].ToString().Trim();
                        if (dt.Rows[0]["HAL_JOINING_DATE"].ToString().Trim() != "")
                            lblApprentiship.Text= "&nbsp;" + dt.Rows[0]["HAL_JOINING_DATE"].ToString().Trim() + " - " + dt.Rows[0]["HAL_LEAVING_DATE"].ToString().Trim();

                        //if(dt.Rows[0]["PWD_APPLIED"].ToString().Trim().ToUpper() =="YES")
                        //{
                        //    tdPwd.Visible = true;
                        //}
                        //else
                        //{
                        //    tdPwd.Visible = false;
                        //}
                        //if (dt.Rows[0]["CATEGORY_APPLIED"].ToString().ToUpper() == "UR")
                        //    tdCaste.Visible = false;
                        //else
                        //    tdCaste.Visible = true;

                        //if (dt.Rows[0]["HAL_APPRENTICESHIP"].ToString().ToUpper() == "YES")
                        //    tdHALApr.Visible = true;
                        //else
                        //    tdHALApr.Visible = false;

                        //if (dt.Rows[0]["JK_DOMICILE"].ToString().Trim().ToUpper()=="YES")
                        //    tdJK.Visible= true;
                        //else
                        //    tdJK.Visible = false;

                        //if (dt.Rows[0]["EX_SERVICE_MAN"].ToString().Trim().ToUpper() == "YES")
                        //    tdCmb.Visible = true;
                        //else
                        //    tdCmb.Visible = false;
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = true;
            //if (tdPwd.Visible == true && !ChkPwd.Checked)
            //{
            //    flag = false;
            //}
            //if (tdCaste.Visible == true && !ChkCaste.Checked)
            //{
            //    flag = false;
            //}
            //if (tdHALApr.Visible == true && !ChkHALApr.Checked)
            //{
            //    flag = false;
            //}
            //if (tdJK.Visible == true && !ChkJK.Checked)
            //{
            //    flag = false;
            //}
            if (ChkAadhar.Visible == true && !ChkAadhar.Checked)
            {
                flag = false;
            }
            //if (tdCmb.Visible == true && !ChCmb.Checked)
            //{
            //    flag = false;
            //}
            if (flag && ChkPhoto.Checked && ChkSign.Checked)
            {
                string upquery = "update APPLICANT set PERSONALINFO_PAGE=1 where USERID='" + AppNo + "'";
                site.executeNonQuery(upquery);
                Response.Redirect("education", false);
            }
            else
            {
                Error.Text = "Incomplete Selection !";
                Error.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
                string upquery = "update APPLICANT set PERSONALINFO_PAGE=NULL where USERID='" + AppNo +"'";
                site.executeNonQuery(upquery);
                Response.Redirect("PersonalInfo", false);
        }

  
    }
}