using System;
using System.Data;

namespace RegistrationApp
{
    public partial class Preview : System.Web.UI.Page
    {

        DataTable dt;
        siteclass site = new siteclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Session["APPNO"] = "967709";
                string AppNo = "";
                if (Session["APPNO"] == null)
                    return;
                else
                {
                    AppNo = Session["APPNO"].ToString();
                    //lblApp0.Text = AppNo;
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

                        if (dt.Rows[0]["DATED"].ToString().Trim() != "")
                        {
                            DateTime xDate1 = DateTime.Parse(dt.Rows[0]["DATED"].ToString());
                            lblDated.Text = "&nbsp;" + xDate1.ToString("dd-MM-yyyy");
                        }

                        if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() != "")
                            lblPost.Text = "&nbsp;" + dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim();


                        if (dt.Rows[0]["DOB"].ToString().Trim() != "")
                        {
                            DateTime xDate1 = DateTime.Parse(dt.Rows[0]["DOB"].ToString());
                            lblDOB.Text = "&nbsp;" + xDate1.ToString("dd-MM-yyyy") + " ( Age as on 01-01-2024 is " + dt.Rows[0]["APPLICANT_AGE"].ToString().Trim() + " )";
                        }

                        if (dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim() != "")
                            lblCategory.Text = "&nbsp;" + dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim();
                        if (dt.Rows[0]["MOBILE"].ToString().Trim() != "")
                            lblMobile.Text = "&nbsp;" + dt.Rows[0]["MOBILE"].ToString().Trim();

                        if (dt.Rows[0]["AADHAR_NO"].ToString().Trim() != "")
                            lblAdhar.Text = "&nbsp;" + dt.Rows[0]["AADHAR_NO"].ToString().Trim();

                        //imgPhoto = "uploadedfiles/photograph/iocl00002.jpg";
                        imgPic.ImageUrl = "~/UPLOADEDFILES/PHOTOGRAPH/" + AppNo + "_photo.jpg";
                        imgSign.ImageUrl = "~/UPLOADEDFILES/SIGNATURE/" + AppNo + "_sign.jpg";
                        imgSign2.ImageUrl = "~/UPLOADEDFILES/SIGNATURE/" + AppNo + "_sign.jpg";
                        //imgSign2.ImageUrl = "~/UPLOADEDFILES/SIGNATURE/" + xUrl;

                        if (!string.IsNullOrEmpty(dt.Rows[0]["Applicant_Name"].ToString().Trim()))
                        {
                            lblName.Text = "&nbsp;" + dt.Rows[0]["Applicant_Name"].ToString().Trim();
                            lblName1.Text = "&nbsp;" + dt.Rows[0]["Applicant_Name"].ToString().Trim();
                        }

                        if (dt.Rows[0]["FATHER_NAME"].ToString().Trim() != "")
                            lblFather.Text = "&nbsp;" + dt.Rows[0]["FATHER_NAME"].ToString().Trim();
                        if (dt.Rows[0]["MOTHER_NAME"].ToString().Trim() != "")
                            lblMother.Text = "&nbsp;" + dt.Rows[0]["MOTHER_NAME"].ToString().Trim();

                        if (dt.Rows[0]["GENDER"].ToString().Trim() != "")
                            lblGender.Text = "&nbsp;" + dt.Rows[0]["GENDER"].ToString().Trim();

                        if (dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim() != "")
                            lblCategory.Text = "&nbsp;" + dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim();

                        if (dt.Rows[0]["CASTE_CERT_NO"].ToString().Trim() != "")
                            lblCastNo.Text = dt.Rows[0]["CASTE_CERT_NO"].ToString().Trim();
                        if (dt.Rows[0]["CASTE_CERT_ISSUE_DATE"].ToString().Trim() != "")
                        {
                            DateTime xDate = DateTime.Parse(dt.Rows[0]["CASTE_CERT_ISSUE_DATE"].ToString());
                            lblCasteDate.Text = dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim() == "UR" ? "" : xDate.ToString("dd-MM-yyyy");
                        }

                        if (dt.Rows[0]["PWD_APPLIED"].ToString().Trim() != "")
                            lblPH.Text = dt.Rows[0]["PWD_APPLIED"].ToString().Trim();

                        if (dt.Rows[0]["PWD_TYPE"].ToString().Trim() == "")
                            lblPwdType.Text = "";
                        else
                            lblPwdType.Text = dt.Rows[0]["PWD_TYPE"].ToString().Trim() + ", " + dt.Rows[0]["PWD_SUB"].ToString().Trim();

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
                        if (dt.Rows[0]["OTHER_RELIGION"].ToString().Trim() != "")
                            lblReligionOther.Text = "&nbsp;" + dt.Rows[0]["OTHER_RELIGION"].ToString().Trim();
                        if (dt.Rows[0]["DOMICILE_STATE"].ToString().Trim() != "")
                            lblDomState.Text = "&nbsp;" + dt.Rows[0]["DOMICILE_STATE"].ToString().Trim();

                        if (dt.Rows[0]["JK_DOMICILE"].ToString().Trim() != "")
                            lblDom.Text = "&nbsp;" + dt.Rows[0]["JK_DOMICILE"].ToString().Trim();
                        if (dt.Rows[0]["DOMICILE_DATE"].ToString().Trim() != "")
                        {
                            DateTime xDate = DateTime.Parse(dt.Rows[0]["DOMICILE_DATE"].ToString());
                            lblDomDate1.Text = dt.Rows[0]["JK_DOMICILE"].ToString().Trim() == "No" ? "N/A" : xDate.ToString("dd-MM-yyyy");
                        }

                        string MailAdd = "";
                        if (dt.Rows[0]["HOUSE_NO_CA"].ToString().Trim() != "")
                        {
                            MailAdd = dt.Rows[0]["HOUSE_NO_CA"].ToString().Trim() + ", " + dt.Rows[0]["AREA_CA"].ToString().Trim() + ", " + dt.Rows[0]["LANDMARK_CA"].ToString().Trim() + ", " + dt.Rows[0]["CITY_CA"].ToString().Trim() + ", " + dt.Rows[0]["DISTRICT_CA"].ToString().Trim() + ", " + dt.Rows[0]["STATE_CA"].ToString().Trim() + ", " + dt.Rows[0]["PIN_CA"].ToString().Trim() + ", " + dt.Rows[0]["POST_OFFICE_CA"].ToString().Trim() + ", " + dt.Rows[0]["RAILWAY_STATION_CA"].ToString().Trim();
                            lblAddress1.Text = MailAdd;
                        }

                        if (dt.Rows[0]["HOUSE_NO_PA"].ToString().Trim() != "")
                        {
                            MailAdd = dt.Rows[0]["HOUSE_NO_PA"].ToString().Trim() + ", " + dt.Rows[0]["AREA_PA"].ToString().Trim() + ", " + dt.Rows[0]["LANDMARK_PA"].ToString().Trim() + ", " + dt.Rows[0]["CITY_PA"].ToString().Trim() + ", " + dt.Rows[0]["DISTRICT_PA"].ToString().Trim() + ", " + dt.Rows[0]["STATE_PA"].ToString().Trim() + ", " + dt.Rows[0]["PIN_PA"].ToString().Trim() + ", " + dt.Rows[0]["POST_OFFICE_PA"].ToString().Trim() + ", " + dt.Rows[0]["RAILWAY_STATION_PA"].ToString().Trim();
                            lblAddress2.Text = MailAdd;
                        }


                        //lblBoard10.Text = "10th / Matriculation";
                        if (dt.Rows[0]["BOARD10_INST"].ToString().Trim() != "")
                            lblInst10.Text = "&nbsp;" + dt.Rows[0]["BOARD10_INST"].ToString().Trim();

                        if (dt.Rows[0]["BOARD10_NATURE"].ToString().Trim() != "")
                            lblNature10.Text = "&nbsp;" + dt.Rows[0]["BOARD10_NATURE"].ToString().Trim();

                        if (dt.Rows[0]["BOARD10_DURATION"].ToString().Trim() != "")
                            lblDuration10.Text = "&nbsp;" + dt.Rows[0]["BOARD10_DURATION"].ToString().Trim();

                        if (dt.Rows[0]["BOARD10_SUBJECTS"].ToString().Trim() != "")
                            lblSub10.Text = "&nbsp;" + dt.Rows[0]["BOARD10_SUBJECTS"].ToString().Trim();

                        //if (dt.Rows[0]["BOARD10_DIVISION"].ToString().Trim() != "")
                        //    lblDiv10.Text = "&nbsp;" + dt.Rows[0]["BOARD10_DIVISION"].ToString().Trim();

                        if (dt.Rows[0]["BOARD10_PERCENT"].ToString().Trim() != "")
                            lblPercent10.Text = "&nbsp;" + dt.Rows[0]["BOARD10_PERCENT"].ToString().Trim();

                        if (dt.Rows[0]["BOARD10_PASSING_DATE"].ToString().Trim() != "")
                            lblPassDate10.Text = "&nbsp;" + dt.Rows[0]["BOARD10_PASSING_DATE"].ToString().Trim();


                        if (dt.Rows[0]["BOARD12_INST"].ToString().Trim() != "")
                        {
                            tr12.Visible = true;
                            lblInst12.Text = "&nbsp;" + dt.Rows[0]["BOARD12_INST"].ToString().Trim();
                        }
                        else
                        {
                            tr12.Visible = false;
                        }

                        if (dt.Rows[0]["BOARD12_NATURE"].ToString().Trim() != "")
                            lblNature12.Text = "&nbsp;" + dt.Rows[0]["BOARD12_NATURE"].ToString().Trim();

                        if (dt.Rows[0]["BOARD12_DURATION"].ToString().Trim() != "")
                            lblDuration12.Text = "&nbsp;" + dt.Rows[0]["BOARD12_DURATION"].ToString().Trim();

                        if (dt.Rows[0]["BOARD12_SUBJECTS"].ToString().Trim() != "")
                            lblSub12.Text = "&nbsp;" + dt.Rows[0]["BOARD12_SUBJECTS"].ToString().Trim();

                        //if (dt.Rows[0]["BOARD12_DIVISION"].ToString().Trim() != "")
                        //    lblDiv12.Text = "&nbsp;" + dt.Rows[0]["BOARD12_DIVISION"].ToString().Trim();

                        if (dt.Rows[0]["BOARD12_PERCENT"].ToString().Trim() != "")
                            lblPercent12.Text = "&nbsp;" + dt.Rows[0]["BOARD12_PERCENT"].ToString().Trim();

                        if (dt.Rows[0]["BOARD12_PASSING_DATE"].ToString().Trim() != "")
                            lblPassDate12.Text = "&nbsp;" + dt.Rows[0]["BOARD12_PASSING_DATE"].ToString().Trim();


                        if (dt.Rows[0]["ITI_INST"].ToString().Trim() != "")
                        {
                            trITI.Visible = true;
                            lblInstITI.Text = "&nbsp;" + dt.Rows[0]["ITI_INST"].ToString().Trim();
                        }
                        else
                        {
                            trITI.Visible = false;
                        }

                        if (dt.Rows[0]["ITI_NATURE"].ToString().Trim() != "")
                            lblNatureITI.Text = "&nbsp;" + dt.Rows[0]["ITI_NATURE"].ToString().Trim();

                        if (dt.Rows[0]["ITI_DURATION"].ToString().Trim() != "")
                            lblDurationITI.Text = "&nbsp;" + dt.Rows[0]["ITI_DURATION"].ToString().Trim();

                        if (dt.Rows[0]["ITI_SUBJECTS"].ToString().Trim() != "")
                            lblSubITI.Text = "&nbsp;" + dt.Rows[0]["ITI_SUBJECTS"].ToString().Trim();

                        if (dt.Rows[0]["ITI_DIVISION"].ToString().Trim() != "")
                            lblDivITI.Text = "&nbsp;" + dt.Rows[0]["ITI_DIVISION"].ToString().Trim();

                        if (dt.Rows[0]["ITI_PERCENT"].ToString().Trim() != "")
                            lblPercentITI.Text = "&nbsp;" + dt.Rows[0]["ITI_PERCENT"].ToString().Trim();

                        if (dt.Rows[0]["ITI_PASSING_DATE"].ToString().Trim() != "")
                            lblPassDateITI.Text = "&nbsp;" + dt.Rows[0]["ITI_PASSING_DATE"].ToString().Trim();


                        if (dt.Rows[0]["DIPLOMA_INST"].ToString().Trim() != "")
                        {
                            trDiploma.Visible = true;
                            lblInstDip.Text = "&nbsp;" + dt.Rows[0]["DIPLOMA_INST"].ToString().Trim();
                        }
                        else
                        {
                            trDiploma.Visible = false;
                        }

                        if (dt.Rows[0]["DIPLOMA_NATURE"].ToString().Trim() != "")
                            lblNatureDip.Text = "&nbsp;" + dt.Rows[0]["DIPLOMA_NATURE"].ToString().Trim();

                        if (dt.Rows[0]["DIPLOMA_DURATION"].ToString().Trim() != "")
                            lblDurationDip.Text = "&nbsp;" + dt.Rows[0]["DIPLOMA_DURATION"].ToString().Trim();

                        if (dt.Rows[0]["DIPLOMA_SUBJECTS"].ToString().Trim() != "")
                            lblSubDip.Text = "&nbsp;" + dt.Rows[0]["DIPLOMA_SUBJECTS"].ToString().Trim();

                        if (dt.Rows[0]["DIPLOMA_DIVISION"].ToString().Trim() != "")
                            lblDivDip.Text = "&nbsp;" + dt.Rows[0]["DIPLOMA_DIVISION"].ToString().Trim();

                        if (dt.Rows[0]["DIPLOMA_PERCENT"].ToString().Trim() != "")
                            lblPercentDip.Text = "&nbsp;" + dt.Rows[0]["DIPLOMA_PERCENT"].ToString().Trim();

                        if (dt.Rows[0]["DIPLOMA_PASSING_DATE"].ToString().Trim() != "")
                            lblPassDateDip.Text = "&nbsp;" + dt.Rows[0]["DIPLOMA_PASSING_DATE"].ToString().Trim();


                        //if (dt.Rows[0]["NAC_NCTVT"].ToString().Trim() != "")
                        //    txtNacUniv.Text = "&nbsp;" + dt.Rows[0]["NAC_NCTVT"].ToString().Trim();
                        if (dt.Rows[0]["NAC_UNIV"].ToString().Trim() != "")
                        {
                            trNAC.Visible = true;
                            txtNacUniv.Text = "&nbsp;" + dt.Rows[0]["NAC_UNIV"].ToString().Trim();
                        }
                        else
                        {
                            trNAC.Visible = false;
                        }
                        if (dt.Rows[0]["NAC_NCTVT_PASSING_DATE"].ToString().Trim() != "")
                            txtNacDate.Text = "&nbsp;" + dt.Rows[0]["NAC_NCTVT_PASSING_DATE"].ToString().Trim();
                        if (dt.Rows[0]["NAC_NCTVT_PERCENT"].ToString().Trim() != "")
                            txtNacPer.Text = "&nbsp;" + dt.Rows[0]["NAC_NCTVT_PERCENT"].ToString().Trim();

                        if (dt.Rows[0]["ESM_COURSE"].ToString().Trim() != "")
                            txtESMCert.Text = "&nbsp;" + dt.Rows[0]["ESM_COURSE"].ToString().Trim();
                        if (dt.Rows[0]["ESM_CERT_NO"].ToString().Trim() != "")
                            txtESMCertNo.Text = "&nbsp;" + dt.Rows[0]["ESM_CERT_NO"].ToString().Trim();
                        if (dt.Rows[0]["ESM_PASSING_DATE"].ToString().Trim() != "")
                            txtESMDate.Text = "&nbsp;" + dt.Rows[0]["ESM_PASSING_DATE"].ToString().Trim();


                        if (dt.Rows[0]["RELEVANT_EXP"].ToString().Trim() != "")
                            lblRelExp1.Text = "&nbsp;" + dt.Rows[0]["RELEVANT_EXP"].ToString().Trim();
                        if (dt.Rows[0]["REL_YEARS"].ToString().Trim() != "")
                            lblPeriod.Text = "&nbsp;" + dt.Rows[0]["REL_YEARS"].ToString().Trim() + " year(s) " + dt.Rows[0]["REL_MONTH"].ToString().Trim() + " month(s) " + dt.Rows[0]["REL_DAY"].ToString().Trim() + " day(s)";

                        if (dt.Rows[0]["EX_SERVICE_MAN"].ToString().Trim() != "")
                            lblExService.Text = "&nbsp;" + dt.Rows[0]["EX_SERVICE_MAN"].ToString().Trim();
                        if (dt.Rows[0]["RANK_HELD"].ToString().Trim() != "")
                            lblRank.Text = "&nbsp;" + dt.Rows[0]["RANK_HELD"].ToString().Trim();

                        if (dt.Rows[0]["JOINING_DATE"].ToString().Trim() != "")
                            lblExPeriod.Text = "&nbsp;" + dt.Rows[0]["JOINING_DATE"].ToString().Trim() + "     Date of Discharge : " + dt.Rows[0]["LEAVING_DATE"].ToString().Trim() + " " + dt.Rows[0]["EXP_DAY"].ToString().Trim();

                        if (dt.Rows[0]["HAL_APPRENTICESHIP"].ToString().Trim() != "")
                            lblAppHal.Text = "&nbsp;" + dt.Rows[0]["HAL_APPRENTICESHIP"].ToString().Trim();
                        if (dt.Rows[0]["HAL_JOINING_DATE"].ToString().Trim() != "")
                            lblJoinDate.Text = "&nbsp;" + dt.Rows[0]["HAL_JOINING_DATE"].ToString().Trim();
                        if (dt.Rows[0]["HAL_LEAVING_DATE"].ToString().Trim() != "")
                            lblLeveDate.Text = "&nbsp;" + dt.Rows[0]["HAL_LEAVING_DATE"].ToString().Trim();

                        if (dt.Rows[0]["INTERVIEWED_BY_HAL"].ToString().Trim() != "")
                            lblIntHal.Text = "&nbsp;" + dt.Rows[0]["INTERVIEWED_BY_HAL"].ToString().Trim();
                        if (dt.Rows[0]["POST_INTERVIEWED"].ToString().Trim() != "")
                            lblPostInt.Text = "&nbsp;" + dt.Rows[0]["POST_INTERVIEWED"].ToString().Trim();
                        if (dt.Rows[0]["INTERVIEWED_DATE"].ToString().Trim() != "")
                            lblDateInt.Text = "&nbsp;" + dt.Rows[0]["INTERVIEWED_DATE"].ToString().Trim();
                        if (dt.Rows[0]["INTERVIEWED_VENUE"].ToString().Trim() != "")
                            lblVenueInt.Text = "&nbsp;" + dt.Rows[0]["INTERVIEWED_VENUE"].ToString().Trim();


                        if (dt.Rows[0]["RELATIVE_WITH_HAL"].ToString().Trim() != "")
                            lblRelWorking.Text = "&nbsp;" + dt.Rows[0]["RELATIVE_WITH_HAL"].ToString().Trim();
                        if (dt.Rows[0]["RELATIVE_NAME"].ToString().Trim() != "")
                            lblNameRel.Text = "&nbsp;" + dt.Rows[0]["RELATIVE_NAME"].ToString().Trim();
                        if (dt.Rows[0]["RELATIVE_DESIG"].ToString().Trim() != "")
                            lblDesigRel.Text = "&nbsp;" + dt.Rows[0]["RELATIVE_DESIG"].ToString().Trim();
                        if (dt.Rows[0]["RELATIVE_DIVISION"].ToString().Trim() != "")
                            lblDivRel.Text = "&nbsp;" + dt.Rows[0]["RELATIVE_DIVISION"].ToString().Trim();
                        if (dt.Rows[0]["RELATIVE_DESC"].ToString().Trim() != "")
                            lblDescRel.Text = "&nbsp;" + dt.Rows[0]["RELATIVE_DESC"].ToString().Trim();


                        if (dt.Rows[0]["POLITICAL_RELATION"].ToString().Trim() != "")
                            lblPolParty.Text = "&nbsp;" + dt.Rows[0]["POLITICAL_RELATION"].ToString().Trim();
                        if (dt.Rows[0]["POLITICAL_PARTY_NAME"].ToString().Trim() != "")
                            lblPartyName.Text = "&nbsp;" + dt.Rows[0]["POLITICAL_PARTY_NAME"].ToString().Trim();
                        if (dt.Rows[0]["POLITICAL_ACTIVITY"].ToString().Trim() != "")
                            lblActivity.Text = "&nbsp;" + dt.Rows[0]["POLITICAL_ACTIVITY"].ToString().Trim();
                        if (dt.Rows[0]["POLITICAL_PERIOD"].ToString().Trim() != "")
                            lblPeriodMemb.Text = "&nbsp;" + dt.Rows[0]["POLITICAL_PERIOD"].ToString().Trim();
                        if (dt.Rows[0]["POLITICAL_PARTICIPATION"].ToString().Trim() != "")
                            lblNature.Text = "&nbsp;" + dt.Rows[0]["POLITICAL_PARTICIPATION"].ToString().Trim();
                        if (dt.Rows[0]["POLITICAL_OFFICE_HELD"].ToString().Trim() != "")
                            lblOffice.Text = "&nbsp;" + dt.Rows[0]["POLITICAL_OFFICE_HELD"].ToString().Trim();

                        if (dt.Rows[0]["DATED"].ToString().Trim() != "")
                            lblDated.Text = "&nbsp;" + dt.Rows[0]["DATED"].ToString().Trim();

                        if (!string.IsNullOrEmpty(dt.Rows[0]["ORGANISATION_NAME_EXP1"].ToString().Trim()))
                        {
                            for (int x = 1; x <= 5; x++)
                            {
                                lblExperience.Text += "<tr>";
                                lblExperience.Text += "<td>" + dt.Rows[0]["ORGANISATION_NAME_EXP" + x].ToString().Trim() + "</td>";
                                lblExperience.Text += "<td>" + dt.Rows[0]["DESIGNATION_EXP" + x].ToString().Trim() + "</td>";
                                lblExperience.Text += "<td>" + dt.Rows[0]["JOIN_DATE_EXP" + x].ToString().Trim() + "</td>";
                                lblExperience.Text += "<td>" + dt.Rows[0]["END_DATE_EXP" + x].ToString().Trim() + "</td>";
                                lblExperience.Text += "<td>" + dt.Rows[0]["PERIOD_EXP" + x].ToString().Trim() + "</td>";
                                lblExperience.Text += "<td>" + dt.Rows[0]["SALARY_PM_EXP" + x].ToString().Trim() + "</td>";
                                lblExperience.Text += "<td>" + dt.Rows[0]["REMARKS_EXP" + x].ToString().Trim() + "</td>";
                                lblExperience.Text += "</tr>";
                            }
                        }

                        if (!string.IsNullOrEmpty(dt.Rows[0]["ORGANISATION_NAME_TRAINING1"].ToString().Trim()))
                        {
                            lblTraining.Text += "<tr>";
                            lblTraining.Text += "<td>" + dt.Rows[0]["ORGANISATION_NAME_TRAINING1"].ToString().Trim() + "</td>";
                            lblTraining.Text += "<td>" + dt.Rows[0]["PROGRAM_NAME_TRAINING1"].ToString().Trim() + "</td>";
                            lblTraining.Text += "<td>" + dt.Rows[0]["JOIN_DATE_TRAINING1"].ToString().Trim() + "</td>";
                            lblTraining.Text += "<td>" + dt.Rows[0]["END_DATE_TRAINING1"].ToString().Trim() + "</td>";
                            lblTraining.Text += "</tr>";
                            lblTraining.Text += "<tr>";
                            lblTraining.Text += "<td>" + dt.Rows[0]["ORGANISATION_NAME_TRAINING2"].ToString().Trim() + "</td>";
                            lblTraining.Text += "<td>" + dt.Rows[0]["PROGRAM_NAME_TRAINING2"].ToString().Trim() + "</td>";
                            lblTraining.Text += "<td>" + dt.Rows[0]["JOIN_DATE_TRAINING2"].ToString().Trim() + "</td>";
                            lblTraining.Text += "<td>" + dt.Rows[0]["END_DATE_TRAINING2"].ToString().Trim() + "</td>";
                            lblTraining.Text += "</tr>";
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }

        private void getWorkExperinces(string xApp)
        {
            try
            {
                dt = site.getdatatable("SELECT * from APPLICANT WHERE USERID='" + xApp + "' ");
                for (int x = 1; x <= 5; x++)
                {
                    lblExperience.Text += "<tr>";
                    lblExperience.Text += "<td>" + dt.Rows[0]["ORGANISATION_NAME_EXP" + x].ToString().Trim() + "</td>";
                    lblExperience.Text += "<td>" + dt.Rows[0]["DESIGNATION_EXP" + x].ToString().Trim() + "</td>";
                    lblExperience.Text += "<td>" + dt.Rows[0]["JOIN_DATE_EXP" + x].ToString().Trim() + "</td>";
                    lblExperience.Text += "<td>" + dt.Rows[0]["END_DATE_EXP" + x].ToString().Trim() + "</td>";
                    lblExperience.Text += "<td>" + dt.Rows[0]["PERIOD_EXP" + x].ToString().Trim() + "</td>";
                    lblExperience.Text += "<td>" + dt.Rows[0]["SALARY_PM_EXP" + x].ToString().Trim() + "</td>";
                    lblExperience.Text += "<td>" + dt.Rows[0]["REMARKS_EXP" + x].ToString().Trim() + "</td>";
                    lblExperience.Text += "</tr>";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }

        private void getTraining(string xApp)
        {
            try
            {
                dt = site.getdatatable("SELECT * from APPLICANT WHERE USERID='" + xApp + "' ORDER BY SEQ");
                for (int x = 0; x <= dt.Rows.Count - 1; x++)
                {
                    lblTraining.Text += "<tr>";
                    lblTraining.Text += "<td>" + dt.Rows[x]["ORGANISATION_NAME_TRAINING1"].ToString().Trim() + "</td>";
                    lblTraining.Text += "<td>" + dt.Rows[x]["PROGRAM_NAME_TRAINING1"].ToString().Trim() + "</td>";
                    lblTraining.Text += "<td>" + dt.Rows[x]["JOIN_DATE_TRAINING1"].ToString().Trim() + "</td>";
                    lblTraining.Text += "<td>" + dt.Rows[x]["END_DATE_TRAINING1"].ToString().Trim() + "</td>";
                    lblTraining.Text += "</tr>";
                    lblTraining.Text += "<tr>";
                    lblTraining.Text += "<td>" + dt.Rows[x]["ORGANISATION_NAME_TRAINING2"].ToString().Trim() + "</td>";
                    lblTraining.Text += "<td>" + dt.Rows[x]["PROGRAM_NAME_TRAINING2"].ToString().Trim() + "</td>";
                    lblTraining.Text += "<td>" + dt.Rows[x]["JOIN_DATE_TRAINING2"].ToString().Trim() + "</td>";
                    lblTraining.Text += "<td>" + dt.Rows[x]["END_DATE_TRAINING3"].ToString().Trim() + "</td>";
                    lblTraining.Text += "</tr>";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        protected void btnlogout_Clicked(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Clear();
            Response.Redirect("index");
        }
    }
}