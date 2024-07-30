using System;
using System.Data;
using System.Configuration;

namespace RegistrationApp
{
    public partial class EducationPreview : System.Web.UI.Page
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


                        //lblBoard10.Text = "10th / Matriculation";
                        if (dt.Rows[0]["BOARD10_INST"].ToString().Trim() != "")
                            lblInst10.Text = "&nbsp;" + dt.Rows[0]["BOARD10_INST"].ToString().Trim();

                        if (dt.Rows[0]["BOARD10_NATURE"].ToString().Trim() != "")
                            lblMode10.Text = "&nbsp;" + dt.Rows[0]["BOARD10_NATURE"].ToString().Trim();

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
                            lblMode12.Text = "&nbsp;" + dt.Rows[0]["BOARD12_NATURE"].ToString().Trim();

                        //if (dt.Rows[0]["BOARD12_STREAM"].ToString().Trim() != "")
                        //    lblSub12.Text = "&nbsp;" + dt.Rows[0]["BOARD12_STREAM"].ToString().Trim();

                        if (dt.Rows[0]["BOARD12_PERCENT"].ToString().Trim() != "")
                            lblPercent12.Text = "&nbsp;" + dt.Rows[0]["BOARD12_PERCENT"].ToString().Trim();

                        if (dt.Rows[0]["BOARD12_PASSING_DATE"].ToString().Trim() != "")
                            lblPassDate12.Text = "&nbsp;" + dt.Rows[0]["BOARD12_PASSING_DATE"].ToString().Trim();

                        //if (dt.Rows[0]["ITI_UNIV"].ToString().Trim() != "")
                        //{
                        //    trITI.Visible = true;
                        //    lblInstITI.Text = "&nbsp;" + dt.Rows[0]["ITI_UNIV"].ToString().Trim();
                        //}
                        //else
                        //{
                        //    trITI.Visible = false;
                        //}

                        if (dt.Rows[0]["ITI_NATURE"].ToString().Trim() == "")
                            trITI.Visible = false;
                        else
                            trITI.Visible = true;

                        if (dt.Rows[0]["ITI_SUBJECTS"].ToString().Trim() != "")
                            lblCourseITI.Text = "&nbsp;" + dt.Rows[0]["ITI_SUBJECTS"].ToString().Trim();

                        if (dt.Rows[0]["ITI_NATURE"].ToString().Trim() != "")
                            lblModeITI.Text = "&nbsp;" + dt.Rows[0]["ITI_NATURE"].ToString().Trim();

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

                        if (dt.Rows[0]["DIPLOMA_SUBJECTS"].ToString().Trim() != "")
                            lblCourseDip.Text = "&nbsp;" + dt.Rows[0]["DIPLOMA_SUBJECTS"].ToString().Trim();

                        if (dt.Rows[0]["DIPLOMA_NATURE"].ToString().Trim() != "")
                            lblModeDip.Text = "&nbsp;" + dt.Rows[0]["DIPLOMA_NATURE"].ToString().Trim();

                        if (dt.Rows[0]["DIPLOMA_PERCENT"].ToString().Trim() != "")
                            lblPercentDip.Text = "&nbsp;" + dt.Rows[0]["DIPLOMA_PERCENT"].ToString().Trim();

                        if (dt.Rows[0]["DIPLOMA_PASSING_DATE"].ToString().Trim() != "")
                            lblPassDateDip.Text = "&nbsp;" + dt.Rows[0]["DIPLOMA_PASSING_DATE"].ToString().Trim();


                        if (dt.Rows[0]["NAC_NCTVT"].ToString().Trim() != "")
                        {
                            trNAC.Visible = true;
                            txtNacUniv.Text = "&nbsp;" + dt.Rows[0]["NAC_NCTVT"].ToString().Trim();
                        }
                        else
                        {
                            trNAC.Visible = false;
                        }
                        if (dt.Rows[0]["NAC_UNIV"].ToString().Trim() != "")
                            lblNacMode.Text = "&nbsp;" + dt.Rows[0]["NAC_UNIV"].ToString().Trim();
                        if (dt.Rows[0]["NAC_NCTVT_PASSING_DATE"].ToString().Trim() != "")
                            txtNacDate.Text = "&nbsp;" + dt.Rows[0]["NAC_NCTVT_PASSING_DATE"].ToString().Trim();
                        if (dt.Rows[0]["NAC_NCTVT_PERCENT"].ToString().Trim() != "")
                            txtNacPer.Text = "&nbsp;" + dt.Rows[0]["NAC_NCTVT_PERCENT"].ToString().Trim();

                        string post = dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim();
                        if (post == "Security Guard")
                        {
                            TBLEssQual.Visible = false;
                            TBLCom.Visible = true;
                            TBLESM.Visible = false;

                            lblRank.Text = dt.Rows[0]["RANK_HELD2"].ToString().Trim();
                            lblJoin.Text = dt.Rows[0]["JOINING_DATE"].ToString().Trim();
                            lblLeave.Text = dt.Rows[0]["LEAVING_DATE"].ToString().Trim();
                            lblDura.Text = dt.Rows[0]["PERIOD"].ToString().Trim();

                        }else if (post == "ESM Technician (Aircraft Artificer-Air Engineering)" || post== "ESM Technician (Mechanician-Air Electrical)" || post== "ESM Technician (Engine Fitter)" || post== "ESM Technician (Electrical Fitter)")
                        {
                            TBLEssQual.Visible = false;
                            TBLCom.Visible = false;
                            TBLESM.Visible = true;

                            lblAirTrad.Text = dt.Rows[0]["ESM_CERT_NO"].ToString().Trim();
                            lblDate.Text = DateTime.Parse(dt.Rows[0]["ESM_PASSING_DATE"].ToString()).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            TBLEssQual.Visible = true;
                            TBLCom.Visible = false;
                            TBLESM.Visible = false;
                        }

                        if (dt.Rows[0]["ORGANISATION_NAME_EXP1"].ToString().Trim() != "")
                        {
                            TeExp1.Visible = true;
                            lblNameOrd.Text = dt.Rows[0]["ORGANISATION_NAME_EXP1"].ToString().Trim();
                        }

                        if (dt.Rows[0]["DESIGNATION_EXP1"].ToString().Trim() != "")
                            lblDesin.Text = dt.Rows[0]["DESIGNATION_EXP1"].ToString().Trim();

                        if (dt.Rows[0]["SALARY_PM_EXP1"].ToString().Trim() != "")
                            lblSalary.Text = dt.Rows[0]["SALARY_PM_EXP1"].ToString().Trim();

                        if (dt.Rows[0]["JOIN_DATE_EXP1"].ToString().Trim() != "")
                            lblJoinDate.Text = dt.Rows[0]["JOIN_DATE_EXP1"].ToString().Trim();

                        if (dt.Rows[0]["END_DATE_EXP1"].ToString().Trim() != "")
                            lblEndDate.Text = dt.Rows[0]["END_DATE_EXP1"].ToString().Trim();

                        if (dt.Rows[0]["PERIOD_EXP1"].ToString().Trim() != "")
                            lblPeriodExp.Text = dt.Rows[0]["PERIOD_EXP1"].ToString().Trim();


                        if (dt.Rows[0]["ORGANISATION_NAME_EXP2"].ToString().Trim() != "")
                        {
                            TeExp2.Visible = true;
                            lblNameOrd2.Text = dt.Rows[0]["ORGANISATION_NAME_EXP2"].ToString().Trim();
                        }

                        if (dt.Rows[0]["DESIGNATION_EXP2"].ToString().Trim() != "")
                            lblDesin2.Text = dt.Rows[0]["DESIGNATION_EXP2"].ToString().Trim();

                        if (dt.Rows[0]["SALARY_PM_EXP2"].ToString().Trim() != "")
                            lblSalary2.Text = dt.Rows[0]["SALARY_PM_EXP2"].ToString().Trim();

                        if (dt.Rows[0]["JOIN_DATE_EXP2"].ToString().Trim() != "")
                            lblJoinDate2.Text = dt.Rows[0]["JOIN_DATE_EXP2"].ToString().Trim();

                        if (dt.Rows[0]["END_DATE_EXP2"].ToString().Trim() != "")
                            lblEndDate2.Text = dt.Rows[0]["END_DATE_EXP2"].ToString().Trim();

                        if (dt.Rows[0]["PERIOD_EXP2"].ToString().Trim() != "")
                            lblPeriodExp2.Text = dt.Rows[0]["PERIOD_EXP2"].ToString().Trim();


                        if (dt.Rows[0]["ORGANISATION_NAME_EXP3"].ToString().Trim() != "")
                        {
                            TeExp3.Visible = true;
                            lblNameOrd3.Text = dt.Rows[0]["ORGANISATION_NAME_EXP3"].ToString().Trim();
                        }

                        if (dt.Rows[0]["DESIGNATION_EXP3"].ToString().Trim() != "")
                            lblDesin3.Text = dt.Rows[0]["DESIGNATION_EXP3"].ToString().Trim();

                        if (dt.Rows[0]["SALARY_PM_EXP3"].ToString().Trim() != "")
                            lblSalary3.Text = dt.Rows[0]["SALARY_PM_EXP3"].ToString().Trim();

                        if (dt.Rows[0]["JOIN_DATE_EXP3"].ToString().Trim() != "")
                            lblJoinDate3.Text = dt.Rows[0]["JOIN_DATE_EXP3"].ToString().Trim();

                        if (dt.Rows[0]["END_DATE_EXP3"].ToString().Trim() != "")
                            lblEndDate3.Text = dt.Rows[0]["END_DATE_EXP3"].ToString().Trim();

                        if (dt.Rows[0]["PERIOD_EXP3"].ToString().Trim() != "")
                            lblPeriodExp3.Text = dt.Rows[0]["PERIOD_EXP3"].ToString().Trim();

                        if (dt.Rows[0]["ORGANISATION_NAME_EXP4"].ToString().Trim() != "")
                        {
                            TeExp4.Visible = true;
                            lblNameOrd4.Text = dt.Rows[0]["ORGANISATION_NAME_EXP4"].ToString().Trim();
                        }

                        if (dt.Rows[0]["DESIGNATION_EXP4"].ToString().Trim() != "")
                            lblDesin4.Text = dt.Rows[0]["DESIGNATION_EXP4"].ToString().Trim();

                        if (dt.Rows[0]["SALARY_PM_EXP4"].ToString().Trim() != "")
                            lblSalary4.Text = dt.Rows[0]["SALARY_PM_EXP4"].ToString().Trim();

                        if (dt.Rows[0]["JOIN_DATE_EXP4"].ToString().Trim() != "")
                            lblJoinDate4.Text = dt.Rows[0]["JOIN_DATE_EXP4"].ToString().Trim();

                        if (dt.Rows[0]["END_DATE_EXP4"].ToString().Trim() != "")
                            lblEndDate4.Text = dt.Rows[0]["END_DATE_EXP4"].ToString().Trim();

                        if (dt.Rows[0]["PERIOD_EXP4"].ToString().Trim() != "")
                            lblPeriodExp4.Text = dt.Rows[0]["PERIOD_EXP4"].ToString().Trim();


                        if (dt.Rows[0]["ORGANISATION_NAME_EXP5"].ToString().Trim() != "")
                        {
                            TeExp5.Visible = true;
                            lblNameOrd5.Text = dt.Rows[0]["ORGANISATION_NAME_EXP5"].ToString().Trim();
                        }

                        if (dt.Rows[0]["DESIGNATION_EXP5"].ToString().Trim() != "")
                            lblDesin5.Text = dt.Rows[0]["DESIGNATION_EXP5"].ToString().Trim();

                        if (dt.Rows[0]["SALARY_PM_EXP5"].ToString().Trim() != "")
                            lblSalary5.Text = dt.Rows[0]["SALARY_PM_EXP5"].ToString().Trim();

                        if (dt.Rows[0]["JOIN_DATE_EXP5"].ToString().Trim() != "")
                            lblJoinDate5.Text = dt.Rows[0]["JOIN_DATE_EXP5"].ToString().Trim();

                        if (dt.Rows[0]["END_DATE_EXP5"].ToString().Trim() != "")
                            lblEndDate5.Text = dt.Rows[0]["END_DATE_EXP5"].ToString().Trim();

                        if (dt.Rows[0]["PERIOD_EXP5"].ToString().Trim() != "")
                            lblPeriodExp5.Text = dt.Rows[0]["PERIOD_EXP5"].ToString().Trim();
                        //Rwlative
                        if (dt.Rows[0]["RELATIVE_WITH_HAL"].ToString().Trim().ToUpper() == "YES")
                        {
                            TdRelWork.Visible = true;
                            TdRelWork2.Visible = true;
                        }
                        else
                        {
                            TdRelWork.Visible = false;
                            TdRelWork2.Visible = false;
                        }

                        if (dt.Rows[0]["RELATIVE_WITH_HAL"].ToString().Trim() != "")
                            lblRelWork.Text = dt.Rows[0]["RELATIVE_WITH_HAL"].ToString().Trim();

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

                        //Pollitician
                        if (dt.Rows[0]["POLITICAL_RELATION"].ToString().Trim().ToUpper() == "YES")
                        {
                            TdPol.Visible = true;
                            TdPol2.Visible = true;
                        }
                        else
                        {
                            TdPol.Visible = false;
                            TdPol2.Visible = false;
                        }

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

                        lblVRS.Text = dt.Rows[0]["VRS_TAKEN"].ToString().Trim();
                        //Apprenticeship
                        if (dt.Rows[0]["HAL_APPRENTICESHIP"].ToString().Trim() != "")
                            lblAppr.Text = "&nbsp;" + dt.Rows[0]["HAL_APPRENTICESHIP"].ToString().Trim();


                        if (dt.Rows[0]["HAL_APPRENTICESHIP"].ToString().Trim() == "Yes")
                        {

                            if (dt.Rows[0]["PROGRAM_NAME_TRAINING1"].ToString().Trim() != "")
                            {
                                lblAppr.Visible = true;
                                TrAppr1.Visible = true;
                                TblApprenticeship.Visible = true;
                                lbtPreNameAppr.Text = dt.Rows[0]["PROGRAM_NAME_TRAINING1"].ToString().Trim();
                            }

                            if (dt.Rows[0]["ORGANISATION_NAME_TRAINING1"].ToString().Trim() != "")
                                lblOrdTrnApr.Text = dt.Rows[0]["ORGANISATION_NAME_TRAINING1"].ToString().Trim();

                            if (dt.Rows[0]["JOIN_DATE_TRAINING1"].ToString().Trim() != "")
                                lblDateSt.Text = dt.Rows[0]["JOIN_DATE_TRAINING1"].ToString().Trim();

                            if (dt.Rows[0]["END_DATE_TRAINING1"].ToString().Trim() != "")
                                lblDateEd.Text = dt.Rows[0]["END_DATE_TRAINING1"].ToString().Trim();

                            if (dt.Rows[0]["PROGRAM_NAME_TRAINING2"].ToString().Trim() != "")
                            {
                                TrAppr2.Visible = true;
                                lbtPreNameAppr2.Text = dt.Rows[0]["PROGRAM_NAME_TRAINING2"].ToString().Trim();
                            }

                            if (dt.Rows[0]["ORGANISATION_NAME_TRAINING2"].ToString().Trim() != "")
                                lblOrdTrnApr2.Text = dt.Rows[0]["ORGANISATION_NAME_TRAINING2"].ToString().Trim();

                            if (dt.Rows[0]["JOIN_DATE_TRAINING2"].ToString().Trim() != "")
                                lblDateSt2.Text = dt.Rows[0]["JOIN_DATE_TRAINING2"].ToString().Trim();

                            if (dt.Rows[0]["END_DATE_TRAINING2"].ToString().Trim() != "")
                                lblDateEd2.Text = dt.Rows[0]["END_DATE_TRAINING2"].ToString().Trim();
                        }
                        if (dt.Rows[0]["INTERVIEWED_BY_HAL"].ToString().Trim() == "Yes")
                        {
                            trInter.Visible = true;
                            lblInter.Visible = true;
                            lblInterview.Text = dt.Rows[0]["INTERVIEWED_BY_HAL"].ToString().Trim();
                            lblPostInter.Text = dt.Rows[0]["POST_INTERVIEWED"].ToString().Trim();
                            lblDateInter.Text = DateTime.Parse(dt.Rows[0]["INTERVIEWED_DATE"].ToString()).ToString("dd-MM-yyyy").Trim();
                            lblVenueInter.Text = dt.Rows[0]["INTERVIEWED_VENUE"].ToString().Trim();
                        }
                        else
                        {
                            trInter.Visible = false;
                            lblInter.Visible = false;
                            lblInterview.Text = dt.Rows[0]["INTERVIEWED_BY_HAL"].ToString().Trim();
                        }
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
            string upquery = "update APPLICANT set EDUCATION_PAGE=1 where USERID='" + AppNo + "'";
            site.executeNonQuery(upquery);
            Response.Redirect("UploadFile", false);
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            dt = site.getdatatable("select * FROM APPLICANT where USERID='" + AppNo + "'");
            if (dt.Rows[0]["EDUCATION_PAGE"].ToString().Trim() == "1")
            {
                string upquery = "update APPLICANT set EDUCATION_PAGE=NULL where USERID='" + AppNo + "'";
                site.executeNonQuery(upquery);
            }
            Response.Redirect("Education", false);
        }
    }
}