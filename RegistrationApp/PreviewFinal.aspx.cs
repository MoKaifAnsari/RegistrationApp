using RegUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationApp
{
    public partial class PreviewFinal : System.Web.UI.Page
    {
        DataTable dt;
        siteclass site = new siteclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string AppNo = "";
                //lblDated.Text = DateTime.Now.ToString("f");
                if (Session["APPNO"] == null)
                    return;
                else
                {
                    AppNo = Session["APPNO"].ToString();
                    //xUrl = AppNo + ".jpg";
                }
                if (!IsPostBack)
                {
                    dt = site.getdatatable("select APPLICANT.*,WEBHOOK_DATA.payment_id,WEBHOOK_DATA.order_id, convert(varchar, WEBHOOK_DATA.dated, 20) as dated,WEBHOOK_DATA.Amount  FROM APPLICANT left join WEBHOOK_DATA on APPLICANT.APPLICATION_NO = WEBHOOK_DATA.Application_no where APPLICANT.APPLICATION_NO='" + AppNo + "'");
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["APPLICATION_NO"].ToString().Trim() != "")
                        {
                            lblAppno.Text = dt.Rows[0]["APPLICATION_NO"].ToString().Trim();
                            //lblAppno2.Text = dt.Rows[0]["APPLICATION_NO"].ToString().Trim();
                            //lblAppno5.Text = dt.Rows[0]["APPLICATION_NO"].ToString().Trim();
                            //lblAppno6.Text = dt.Rows[0]["APPLICATION_NO"].ToString().Trim();
                            //lblAppno7.Text = dt.Rows[0]["APPLICATION_NO"].ToString().Trim();
                            //lblAppno8.Text = dt.Rows[0]["APPLICATION_NO"].ToString().Trim();
                        }

                        //if (dt.Rows[0]["APPLIED_STATE"].ToString().Trim() != "")
                        //    lblState.Text = dt.Rows[0]["APPLIED_STATE"].ToString().Trim();

                        //if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() != "")
                        //    lblPost.Text = "&nbsp;&nbsp;Post Applied for : " + dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim();

                        //imgPhoto = "uploadedfiles/photograph/iocl00002.jpg";
                        //imgPic.ImageUrl = "~/UPLOADEDFILES/PHOTOGRAPH/" + AppNo + "_photo.jpg";
                        //imgSign.ImageUrl = "~/UPLOADEDFILES/SIGNATURE/" + AppNo + "_sign.jpg";
                        //imgSign2.ImageUrl = "~/UPLOADEDFILES/SIGNATURE/" + xUrl;

                        if (!string.IsNullOrEmpty(dt.Rows[0]["Applicant_Title"].ToString().Trim()))
                        {
                            lblName.Text = dt.Rows[0]["Applicant_Title"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["First_Name"].ToString().Trim()))
                        {
                            lblName.Text = lblName.Text.Trim() + " " + dt.Rows[0]["First_Name"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["Middle_Name"].ToString().Trim()))
                        {
                            lblName.Text = lblName.Text.Trim() + " " + dt.Rows[0]["Middle_Name"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["Sur_Name"].ToString().Trim()))
                        {
                            lblName.Text = lblName.Text.Trim() + " " + dt.Rows[0]["Sur_Name"].ToString().Trim();
                        }

                        if (dt.Rows[0]["FATHER_NAME"].ToString().Trim() != "")
                            lblFather.Text = dt.Rows[0]["FATHER_NAME"].ToString().Trim();
                        //if (dt.Rows[0]["MOTHER_NAME"].ToString().Trim() != "")
                        //    lblMother.Text = dt.Rows[0]["MOTHER_NAME"].ToString().Trim();
                        if (dt.Rows[0]["GENDER"].ToString().Trim() != "")
                            lblGender.Text = dt.Rows[0]["GENDER"].ToString().Trim();
                        if (dt.Rows[0]["DOB"].ToString().Trim() != "")
                        {
                            DateTime xDate = DateTime.Parse(dt.Rows[0]["DOB"].ToString());
                            lblDOB.Text = xDate.ToString("dd-MM-yyyy");
                        }

                        if (dt.Rows[0]["APPLICANT_AGE"].ToString().Trim() != "")
                            lblAge.Text = dt.Rows[0]["APPLICANT_AGE"].ToString().Trim();

                        if (dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim() != "")
                            lblCategory.Text = dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim();
                        //if (dt.Rows[0]["CATEGORY_CERT_NO"].ToString().Trim() != "")
                        //    lblCatCertNo.Text = dt.Rows[0]["CATEGORY_CERT_NO"].ToString().Trim();
                        //if (dt.Rows[0]["CATEGORY_CERT_ISSUE_DATE"].ToString().Trim() != "")
                        //{
                        //    DateTime xDate = DateTime.Parse(dt.Rows[0]["CATEGORY_CERT_ISSUE_DATE"].ToString());
                        //    lblIssueDate.Text = xDate.ToString("dd-MM-yyyy");
                        //}

                        //if (dt.Rows[0]["DOMICILE_JHARKHAND"].ToString().Trim() != "")
                        //    lblDom.Text = dt.Rows[0]["DOMICILE_JHARKHAND"].ToString().Trim();
                        //if (dt.Rows[0]["DOMICILE_NO"].ToString().Trim() != "")
                        //    lblDomNo.Text = dt.Rows[0]["DOMICILE_NO"].ToString().Trim();
                        //if (dt.Rows[0]["DOMICILE_ISSUE_DATE"].ToString().Trim() != "")
                        //{
                        //    DateTime xDate = DateTime.Parse(dt.Rows[0]["DOMICILE_ISSUE_DATE"].ToString());
                        //    lblDomIssueDt.Text = xDate.ToString("dd-MM-yyyy");
                        //}

                        //if (dt.Rows[0]["STENO_TYPING"].ToString().Trim() != "")
                        //    lblSteno.Text = dt.Rows[0]["STENO_TYPING"].ToString().Trim();
                        if (dt.Rows[0]["SPORTS_QUOTA"].ToString().Trim() != "")
                            lblSports.Text = dt.Rows[0]["SPORTS_QUOTA"].ToString().Trim();
                        if (dt.Rows[0]["JOB_EXPERIENCE"].ToString().Trim() != "")
                            lblJob.Text = dt.Rows[0]["JOB_EXPERIENCE"].ToString().Trim();

                        if (dt.Rows[0]["JOB_DEPT"].ToString().Trim() != "")
                            lblDept.Text = dt.Rows[0]["JOB_DEPT"].ToString().Trim();
                        if (dt.Rows[0]["JOB_DESIG"].ToString().Trim() != "")
                            lblDesig.Text = dt.Rows[0]["JOB_DESIG"].ToString().Trim();
                        if (dt.Rows[0]["JOB_SINCE"].ToString().Trim() != "")
                            lblSince.Text = dt.Rows[0]["JOB_SINCE"].ToString().Trim();


                        if (dt.Rows[0]["PH_APPLICANT"].ToString().Trim() != "")
                        {
                            lblPH.Text = dt.Rows[0]["PH_APPLICANT"].ToString().Trim();
                            //if (dt.Rows[0]["PH_APPLICANT"].ToString().ToUpper() == "YES")
                            //{
                            //    btnPay.Visible = false;
                            //}
                            //else
                            //{
                            //    btnPay.Visible = true;
                            //}
                        }
                        if (dt.Rows[0]["PH_TYPE"].ToString().Trim() != "")
                            lblPHType.Text = dt.Rows[0]["PH_TYPE"].ToString().Trim();
                        if (dt.Rows[0]["PH_PERCENT"].ToString().Trim() == "0")
                            lblPHPer.Text = "";
                        else
                            lblPHPer.Text = dt.Rows[0]["PH_PERCENT"].ToString().Trim();


                        if (dt.Rows[0]["BIRTH_PLACE"].ToString().Trim() != "")
                            lblPlace.Text = dt.Rows[0]["BIRTH_PLACE"].ToString().Trim();
                        //if (dt.Rows[0]["MARITAL_STATUS"].ToString().Trim() != "")
                        //    lblMarital.Text = dt.Rows[0]["MARITAL_STATUS"].ToString().Trim();
                        //if (dt.Rows[0]["NATIONALITY"].ToString().Trim() != "")
                            lblNationality.Text = dt.Rows[0]["NATIONALITY"].ToString().Trim();

                        if (dt.Rows[0]["EMAIL"].ToString().Trim() != "")
                            lblMail.Text = dt.Rows[0]["EMAIL"].ToString().Trim();
                        if (dt.Rows[0]["MOBILE"].ToString().Trim() != "")
                            lblMobile.Text = dt.Rows[0]["MOBILE"].ToString().Trim();
                        //if (dt.Rows[0]["AADHAR_NO"].ToString().Trim() != "")
                        //    lblAdhar.Text = dt.Rows[0]["AADHAR_NO"].ToString().Trim();


                        if (dt.Rows[0]["CURRENT_ADDRESS"].ToString().Trim() != "")
                            lblAddress1.Text = dt.Rows[0]["CURRENT_ADDRESS"].ToString().Trim();
                        if (dt.Rows[0]["CITY_CA"].ToString().Trim() != "")
                            lblAddress1.Text = lblAddress1.Text.Trim() + " " + dt.Rows[0]["CITY_CA"].ToString().Trim();
                        
                        if (dt.Rows[0]["DIST_CA"].ToString().Trim() != "")
                            lblAddress1.Text = lblAddress1.Text.Trim() + " " + dt.Rows[0]["DIST_CA"].ToString().Trim();

                        if (dt.Rows[0]["STATE_CA"].ToString().Trim() != "")
                        {
                            lblPlace1.Text = dt.Rows[0]["STATE_CA"].ToString().Trim();
                            lblAddress1.Text = lblAddress1.Text.Trim() + " " + dt.Rows[0]["STATE_CA"].ToString().Trim();
                        }

                        if (dt.Rows[0]["PIN_CA"].ToString().Trim() != "")
                            lblAddress1.Text = lblAddress1.Text.Trim() + " " + dt.Rows[0]["PIN_CA"].ToString().Trim();


                        if (dt.Rows[0]["PERMANENT_ADDRESS"].ToString().Trim() != "")
                            lblAddress2.Text = dt.Rows[0]["PERMANENT_ADDRESS"].ToString().Trim();

                        if (dt.Rows[0]["CITY_PA"].ToString().Trim() != "")
                            lblAddress2.Text = lblAddress2.Text.Trim() + " " + dt.Rows[0]["CITY_PA"].ToString().Trim();

                        if (dt.Rows[0]["DIST_PA"].ToString().Trim() != "")
                            lblAddress2.Text = lblAddress2.Text.Trim() + " " + dt.Rows[0]["DIST_PA"].ToString().Trim();

                       if (dt.Rows[0]["STATE_PA"].ToString().Trim() != "")
                            lblAddress2.Text = lblAddress2.Text.Trim() + " " + dt.Rows[0]["STATE_PA"].ToString().Trim();

                        if (dt.Rows[0]["PIN_PA"].ToString().Trim() != "")
                            lblAddress2.Text = lblAddress2.Text.Trim() + " " + dt.Rows[0]["PIN_PA"].ToString().Trim();

                        if (dt.Rows[0]["BOARD_10TH"].ToString().Trim() != "")
                            lblBoard10.Text = dt.Rows[0]["BOARD_10TH"].ToString().Trim();
                        if (dt.Rows[0]["BOARD10_PASSING_DATE"].ToString().Trim() != "")
                            lblPassDate10.Text = dt.Rows[0]["BOARD10_PASSING_DATE"].ToString();
                        if (dt.Rows[0]["BOARD10_PERCENT"].ToString().Trim() != "")
                            lblPercent10.Text = dt.Rows[0]["BOARD10_PERCENT"].ToString().Trim();
                        if (dt.Rows[0]["BOARD10_DIV"].ToString().Trim() != "")
                            lblDiv10.Text = dt.Rows[0]["BOARD10_DIV"].ToString().Trim();
                        

                        if (dt.Rows[0]["BOARD_12TH"].ToString().Trim() != "")
                            lblBoard12.Text = dt.Rows[0]["BOARD_12TH"].ToString().Trim();
                        if (dt.Rows[0]["BOARD12_PASSING_DATE"].ToString().Trim() != "")
                            lblPassDate12.Text = dt.Rows[0]["BOARD12_PASSING_DATE"].ToString();
                        if (dt.Rows[0]["BOARD12_PERCENT"].ToString().Trim() != "")
                            lblPercent12.Text = dt.Rows[0]["BOARD12_PERCENT"].ToString().Trim();
                        if (dt.Rows[0]["BOARD12_DIV"].ToString().Trim() != "")
                            lblDiv12.Text = dt.Rows[0]["BOARD12_DIV"].ToString().Trim();


                        if (dt.Rows[0]["GRADUATION_UNIV"].ToString().Trim() != "")
                            lblGrad.Text = dt.Rows[0]["GRADUATION_UNIV"].ToString().Trim();
                        if (dt.Rows[0]["GRADUATION_PASSING_DATE"].ToString().Trim() != "")
                            lblPassDateGrad.Text = dt.Rows[0]["GRADUATION_PASSING_DATE"].ToString();
                        if (dt.Rows[0]["GRADUATION_PERCENT"].ToString().Trim() != "")
                            lblPercentGrad.Text = dt.Rows[0]["GRADUATION_PERCENT"].ToString().Trim();
                        if (dt.Rows[0]["GRADUATION_DIV"].ToString().Trim() != "")
                            lblDivGrad.Text = dt.Rows[0]["GRADUATION_DIV"].ToString().Trim();


                        if (dt.Rows[0]["ESSENTIAL_INST"].ToString().Trim() != "")
                            lblEssential.Text = dt.Rows[0]["ESSENTIAL_INST"].ToString().Trim();
                        if (dt.Rows[0]["ESSENTIAL_SKILL"].ToString().Trim() != "")
                            lblTrade.Text = dt.Rows[0]["ESSENTIAL_SKILL"].ToString().Trim();
                        if (dt.Rows[0]["ESSENTIAL_PASSING_DATE"].ToString().Trim() != "")
                            lblPassDateEss.Text = dt.Rows[0]["ESSENTIAL_PASSING_DATE"].ToString();
                        if (dt.Rows[0]["ESSENTIAL_PERCENT"].ToString().Trim() != "")
                            lblDivEss.Text = dt.Rows[0]["ESSENTIAL_PERCENT"].ToString().Trim();
                        if (dt.Rows[0]["ESSENTIAL_DIV"].ToString().Trim() != "")
                            lblDivEss.Text = dt.Rows[0]["ESSENTIAL_DIV"].ToString().Trim();


                        if (dt.Rows[0]["order_id"].ToString().Trim() != "")
                            lblOrderID.Text = dt.Rows[0]["order_id"].ToString().Trim();
                        if (dt.Rows[0]["payment_id"].ToString().Trim() != "")
                            lblPayId.Text = dt.Rows[0]["payment_id"].ToString().Trim();
                        if (dt.Rows[0]["Amount"].ToString().Trim() != "")
                        {
                            int xAmt = Convert.ToInt32(dt.Rows[0]["Amount"].ToString()) / 100;
                            if (xAmt >= 500 && xAmt <= 550)
                                lblAmt.Text = "500";
                            else if (xAmt >= 100 && xAmt <= 150)
                                lblAmt.Text = "125";
                            else
                                lblAmt.Text = "0";

                        }
                        if (dt.Rows[0]["dated"].ToString().Trim() != "")
                            lblDate.Text = dt.Rows[0]["dated"].ToString().Trim();

                        //imgAdhar.ImageUrl = "~/UPLOADEDFILES/AADHAR/" + AppNo + "_adhar.jpg";
                        img10.ImageUrl = "~/UPLOADEDFILES/BOARD10/" + AppNo + "_tenth.jpg";
                        //img12.ImageUrl = "~/UPLOADEDFILES/BOARD12/" + AppNo + "_twelveth.jpg";
                        imgGrad.ImageUrl = "~/UPLOADEDFILES/GRADUATION/" + AppNo + "_grad.jpg";
                        //imgEssen.ImageUrl = "~/UPLOADEDFILES/ESSENTIAL/" + AppNo + "_essen.jpg";
                        //imgCaste.ImageUrl = "~/UPLOADEDFILES/CASTE/" + AppNo + "_caste.jpg";
                        //imgDom.ImageUrl = "~/UPLOADEDFILES/DOMICILE/" + AppNo + "_dom.jpg";
                        //imgPH.ImageUrl = "~/UPLOADEDFILES/PH/" + AppNo + "_ph.jpg";
                        //imgSports.ImageUrl = "~/UPLOADEDFILES/SPORTS/" + AppNo + "_sports.jpg";
                        //imgNOC.ImageUrl = "~/UPLOADEDFILES/NOC/" + AppNo + "_noc.jpg";
                    }
                }
                getValues(AppNo);
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
        private void getValues(string xApp)
        {
            try
            {
                dt = site.getdatatable("SELECT ESSENTIAL_INST,CATEGORY_APPLIED,DOMICILE_JHARKHAND,PH_APPLICANT,SPORTS_QUOTA,JOB_EXPERIENCE from APPLICANT WHERE APPLICATION_NO='" + xApp + "'");
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CATEGORY_APPLIED"].ToString()))
                    {
                        if (dt.Rows[0]["CATEGORY_APPLIED"].ToString() == "UR")
                        {
                            castePage.Visible = false;
                        }
                        else
                        {
                            imgCaste.ImageUrl = "~/UPLOADEDFILES/CASTE/" + xApp + "_caste.jpg";
                            castePage.Visible = true;
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["ESSENTIAL_INST"].ToString()))
                    {
                        if (dt.Rows[0]["ESSENTIAL_INST"].ToString() == "")
                        {
                            essenPage.Visible = false;
                        }
                        else
                        {
                            imgEssen.ImageUrl = "~/UPLOADEDFILES/ESSENTIAL/" + xApp + "_essen.jpg";
                            essenPage.Visible = true;
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["DOMICILE_JHARKHAND"].ToString()))
                    {
                        if (dt.Rows[0]["DOMICILE_JHARKHAND"].ToString().ToUpper() == "NO")
                        {
                            domicilePage.Visible = false;
                        }
                        else
                        {
                            imgDom.ImageUrl = "~/UPLOADEDFILES/DOMICILE/" + xApp + "_dom.jpg";
                            domicilePage.Visible = true;
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["PH_APPLICANT"].ToString()))
                    {
                        if (dt.Rows[0]["PH_APPLICANT"].ToString().ToUpper() == "NO")
                        {
                            phPage.Visible = false;
                        }
                        else
                        {
                            imgPH.ImageUrl = "~/UPLOADEDFILES/PH/" + xApp + "_ph.jpg";
                            phPage.Visible = true;
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["SPORTS_QUOTA"].ToString()))
                    {
                        if (dt.Rows[0]["SPORTS_QUOTA"].ToString().ToUpper() == "NO")
                        {
                            sportsPage.Visible = false;
                        }
                        else
                        {
                            imgSports.ImageUrl = "~/UPLOADEDFILES/SPORTS/" + xApp + "_sports.jpg";
                            sportsPage.Visible = true;
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["JOB_EXPERIENCE"].ToString()))
                    {
                        if (dt.Rows[0]["JOB_EXPERIENCE"].ToString().ToUpper() == "NO")
                        {
                            nocPage.Visible = false;
                        }
                        else
                        {
                            imgNOC.ImageUrl = "~/UPLOADEDFILES/NOC/" + xApp + "_noc.jpg";
                            nocPage.Visible = true;
                        }
                    }
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
            Response.Redirect("login");
        }
    }
}