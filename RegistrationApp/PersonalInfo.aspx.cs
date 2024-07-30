using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace RegistrationApp
{
    public partial class PersonalInfo : System.Web.UI.Page
    {
        DataTable dt;
        siteclass site = new siteclass();
        string appNo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            appNo = Session["APPNO"].ToString().Trim();
            if (!IsPostBack)
            {
                int rex = site.getOfflineStatus("REGISTRATION_PROCESS_ONLINE");
                if (rex == 0)
                {
                    Response.Redirect("Timesup.aspx", false);
                    return;
                }
                ViewState["SAVE"] = "NO";
                BindDomState();
                bindYYMMDD();
                BindPost();
                BindCategory();
                BindPHType();
                EditableField(true);
                getRecords();
            }
        }
        void BindDomState()
        {
            try
            {
                dt = site.getdatatable("select STATE_NAME,SEQ from INDIAN_STATES order by STATE_NAME");
                ddlDomState.DataSource = dt;
                ddlDomState.DataTextField = "STATE_NAME";
                ddlDomState.DataValueField = "STATE_NAME";
                ddlDomState.DataBind();
                ddlDomState.Items.Insert(0, "Select");
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        void bindYYMMDD()
        {
            ddlYears.Items.Clear();
            for (int i = 1; i < 26; i++)
            {
                ddlYears.Items.Add(i.ToString());
            }
            ddlYears.Items.Insert(0, "Select");

            ddlMonths.Items.Clear();
            for (int i = 0; i < 12; i++)
            {
                ddlMonths.Items.Add(i.ToString());
            }
            ddlMonths.Items.Insert(0, "Select");

            ddlDays.Items.Clear();
            for (int i = 0; i < 31; i++)
            {
                ddlDays.Items.Add(i.ToString());
            }
            ddlDays.Items.Insert(0, "Select");
        }
        void getRecords()
        {
            try
            {
                txtName.Text = "";
                txtRegno.Text = "";
                dt = site.getdatatable("select * from APPLICANT where USERID='" + appNo + "'");
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["APPLICANT_NAME"].ToString().Trim() != "")
                        txtName.Text = dt.Rows[0]["APPLICANT_NAME"].ToString().Trim();
                    if (dt.Rows[0]["USERID"].ToString().Trim() != "")
                        txtRegno.Text = dt.Rows[0]["USERID"].ToString().Trim();
                    if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() != "")
                        ddlPost.SelectedValue = dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim();

                    if (ddlPost.SelectedIndex > 0)
                    {
                        validatePost(ddlPost.SelectedItem.Text);
                    }

                    ddlESM.SelectedValue = dt.Rows[0]["ESM_COURSE"].ToString().Trim();
                    //if (dt.Rows[0]["ESM_COURSE"].ToString().Trim().ToUpper() == "YES")
                    //{
                    //    divESM.Visible = true;
                    //    lblESM.Visible = true;
                    //}
                    //else
                    //{
                    //    divESM.Visible= false;
                    //    lblESM.Visible = false;
                    //}

                    if (dt.Rows[0]["GENDER"].ToString().Trim() != "")
                        ddlGender.SelectedValue = dt.Rows[0]["GENDER"].ToString().Trim();
                    if (dt.Rows[0]["MARITAL_STATUS"].ToString().Trim() != "")
                        ddlMarital.SelectedValue = dt.Rows[0]["MARITAL_STATUS"].ToString().Trim();

                    if (dt.Rows[0]["RELIGION_NAME"].ToString().Trim() != "")
                        ddlReligion.SelectedValue = dt.Rows[0]["RELIGION_NAME"].ToString().Trim();

                    if (dt.Rows[0]["AADHAR_NO"].ToString().Trim() != "")
                        txtAdhar.Text = dt.Rows[0]["AADHAR_NO"].ToString().Trim();
                    if (dt.Rows[0]["AADHAR_NO"].ToString().Trim() != "")
                        txtAdhar1.Text = dt.Rows[0]["AADHAR_NO"].ToString().Trim();
                    if (dt.Rows[0]["EMAIL"].ToString().Trim() != "")
                        txtMail.Text = dt.Rows[0]["EMAIL"].ToString().Trim();
                    if (dt.Rows[0]["EMAIL"].ToString().Trim() != "")
                        txtMail1.Text = dt.Rows[0]["EMAIL"].ToString().Trim();
                    if (dt.Rows[0]["MOBILE"].ToString().Trim() != "")
                        txtMobile.Text = dt.Rows[0]["MOBILE"].ToString().Trim();
                    if (dt.Rows[0]["MOBILE"].ToString().Trim() != "")
                        txtMobile1.Text = dt.Rows[0]["MOBILE"].ToString().Trim();


                    if (ddlReligion.SelectedItem.Text.ToUpper() == "OTHER")
                    {
                        divOther.Visible = true;
                        if (dt.Rows[0]["OTHER_RELIGION"].ToString().Trim() != "")
                            txtOther.Text = dt.Rows[0]["OTHER_RELIGION"].ToString().Trim();
                    }
                    else
                    {
                        txtOther.Text = "";
                        divOther.Visible = false;
                    }


                    if (dt.Rows[0]["DOMICILE_STATE"].ToString().Trim() != "")
                        ddlDomState.SelectedValue = dt.Rows[0]["DOMICILE_STATE"].ToString().Trim();

                    if (dt.Rows[0]["RELEVANT_EXP"].ToString().Trim() != "")
                        ddlRelevantExp.SelectedValue = dt.Rows[0]["RELEVANT_EXP"].ToString().Trim();

                    if (ddlRelevantExp.SelectedIndex == 1)
                    {
                        divYears.Visible = true;
                        divMonths.Visible = true;
                        divDays.Visible = true;
                        //divText.Visible = true;
                        if (dt.Rows[0]["REL_YEARS"].ToString().Trim() != "")
                            ddlYears.SelectedValue = dt.Rows[0]["REL_YEARS"].ToString().Trim();
                        if (dt.Rows[0]["REL_MONTH"].ToString().Trim() != "")
                            ddlMonths.SelectedValue = dt.Rows[0]["REL_MONTH"].ToString().Trim();
                        if (dt.Rows[0]["REL_DAY"].ToString().Trim() != "")
                            ddlDays.SelectedValue = dt.Rows[0]["REL_DAY"].ToString().Trim();
                    }
                    else
                    {
                        divYears.Visible = false;
                        divMonths.Visible = false;
                        divDays.Visible = false;
                        //divText.Visible = false;
                    }

                    //if (ddlRelevantExp.SelectedIndex >0)
                    //{
                    //    divRelexp.Visible= true;
                    //    //divYears.Visible = true;
                    //    //divMonths.Visible = true;
                    //    //divDays.Visible = true;
                    //    //divText.Visible=true;
                    //}
                    //else
                    //{
                    //    divRelexp.Visible = false;
                    //    //divYears.Visible = false;
                    //    //divMonths.Visible = false;
                    //    //divDays.Visible = false;
                    //    //ddlYears.SelectedIndex = 0;
                    //    //ddlMonths.SelectedIndex = 0;
                    //    //ddlDays.SelectedIndex = 0;
                    //    //divText.Visible = false;
                    //}

                    if (dt.Rows[0]["EX_SERVICE_MAN"].ToString().Trim() != "")
                        ddlExArmy.SelectedValue = dt.Rows[0]["EX_SERVICE_MAN"].ToString().Trim();

                    if (ddlExArmy.SelectedIndex == 1)
                    {
                        if (dt.Rows[0]["RANK_HELD"].ToString().Trim() != "")
                            txtRank.Text = dt.Rows[0]["RANK_HELD"].ToString().Trim();
                        if (dt.Rows[0]["ENROLL_DATE"].ToString().Trim() != "")
                            txtFrom.Text = dt.Rows[0]["ENROLL_DATE"].ToString().Trim();
                        if (dt.Rows[0]["DISCHARGE_DATE"].ToString().Trim() != "")
                            txtUpto.Text = dt.Rows[0]["DISCHARGE_DATE"].ToString().Trim();

                        //divExArmy.Visible = true;
                        divRank.Visible = true;
                        divEnroll.Visible = true;
                        divDis.Visible = true;
                    }
                    else
                    {
                        txtRank.Text = "";
                        txtFrom.Text = "";
                        txtUpto.Text = "";
                        //divExArmy.Visible = false;
                        divRank.Visible = false;
                        divEnroll.Visible = false;
                        divDis.Visible = false;
                    }

                    if (dt.Rows[0]["JK_DOMICILE"].ToString().Trim() != "")
                        ddlDomicile.SelectedValue = dt.Rows[0]["JK_DOMICILE"].ToString().Trim();
                    if (ddlDomicile.SelectedIndex == 1)
                    {
                        divJKD.Visible = true;
                        if (dt.Rows[0]["DOMICILE_DATE"].ToString().Trim() != "")
                            txtDomDate.Text = DateTime.Parse(dt.Rows[0]["DOMICILE_DATE"].ToString()).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        divJKD.Visible = false;
                    }

                    if (dt.Rows[0]["HAL_APPRENTICESHIP"].ToString().Trim() != "")
                        ddlApprentice.SelectedValue = dt.Rows[0]["HAL_APPRENTICESHIP"].ToString().Trim();

                    if (ddlApprentice.SelectedIndex == 1)
                    {
                        if (dt.Rows[0]["HAL_JOINING_DATE"].ToString().Trim() != "")
                            txtJoinDate.Text = dt.Rows[0]["HAL_JOINING_DATE"].ToString();

                        if (dt.Rows[0]["HAL_LEAVING_DATE"].ToString().Trim() != "")
                            txtLeaveDate.Text = dt.Rows[0]["HAL_LEAVING_DATE"].ToString();

                        divJoinDate.Visible = true;
                        divLeaveDate.Visible = true;
                        lblApprentice.Visible = false;
                    }
                    else
                    {
                        txtJoinDate.Text = "";
                        txtLeaveDate.Text = "";
                        divJoinDate.Visible = false;
                        divLeaveDate.Visible = false;
                    }


                    //if (divApprentice.Visible)
                    //{
                    //    if (ddlApprentice.SelectedIndex == 1)
                    //    {
                    //        if (dt.Rows[0]["APPRENTICE_YEAR"].ToString().Trim() != "")
                    //            ddlYY.SelectedValue = dt.Rows[0]["APPRENTICE_YEAR"].ToString().Trim();

                    //        if (dt.Rows[0]["APPRENTICE_MONTH"].ToString().Trim() != "")
                    //            ddlMM.SelectedValue = dt.Rows[0]["APPRENTICE_MONTH"].ToString().Trim();

                    //        if (dt.Rows[0]["APPRENTICE_DAY"].ToString().Trim() != "")
                    //            ddlDD.SelectedValue = dt.Rows[0]["APPRENTICE_DAY"].ToString().Trim();
                    //        divYY.Visible = true;
                    //        divMM.Visible = true;
                    //        divDD.Visible = true;
                    //        divApprnt.Visible = true;
                    //    }
                    //    else
                    //    {
                    //        divYY.Visible = false;
                    //        divMM.Visible = false;
                    //        divDD.Visible = false;
                    //        divApprnt.Visible = false;
                    //        ddlYY.SelectedIndex = 0;
                    //        ddlMM.SelectedIndex = 0;
                    //        ddlDD.SelectedIndex = 0;
                    //    }
                    //}


                    if (dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim() != "")
                    {
                        ddlCategory.SelectedValue = dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim();
                        if (ddlCategory.SelectedItem.Text.ToUpper() == "UR")
                        {
                            divCaste.Visible = false;
                            divCasteDt.Visible = false;
                            castCert.Text = "";
                            txtCasteDate.Text = "";
                        }
                        else
                        {
                            divCaste.Visible = true;
                            divCasteDt.Visible = true;
                            if (dt.Rows[0]["CASTE_CERT_NO"].ToString().Trim() != "")
                                castCert.Text = dt.Rows[0]["CASTE_CERT_NO"].ToString().Trim();
                            if (dt.Rows[0]["CASTE_CERT_ISSUE_DATE"].ToString().Trim() != "")
                                txtCasteDate.Text = DateTime.Parse(dt.Rows[0]["CASTE_CERT_ISSUE_DATE"].ToString()).ToString("dd/MM/yyyy");
                        }
                    }
                    ddlPwD.SelectedValue = dt.Rows[0]["PWD_APPLIED"].ToString().Trim();
                    if (dt.Rows[0]["PWD_APPLIED"].ToString().Trim().ToUpper() == "YES")
                    {
                        if (ddlPwD.SelectedItem.Text.ToUpper() == "YES")
                        {
                            divPwdType.Visible = true;
                            divPwBD.Visible = true;
                            //divPwdSub.Visible = true;

                            if (dt.Rows[0]["PWD_TYPE"].ToString().Trim() != "")
                                ddlPwdType.SelectedValue = dt.Rows[0]["PWD_TYPE"].ToString().Trim();
                            //if (dt.Rows[0]["PWD_SUB"].ToString().Trim() != "")
                            //    ddlPwdSub.SelectedValue = dt.Rows[0]["PWD_SUB"].ToString().Trim();
                            if (dt.Rows[0]["PWD_PERCENT"].ToString().Trim() != "")
                                txtPHPer.Text = dt.Rows[0]["PWD_PERCENT"].ToString().Trim();
                        }
                        else
                        {
                            divPwdType.Visible = false;
                            divPwBD.Visible = false;
                            //divPwdSub.Visible = false;
                            ddlPwdType.SelectedIndex = 0;
                            //ddlPwdSub.SelectedIndex = 0;
                            txtPHPer.Text = "";
                        }
                    }

                    if (dt.Rows[0]["DOB"].ToString().Trim() != "")
                        txtDOB.Text = DateTime.Parse(dt.Rows[0]["DOB"].ToString()).ToString("dd/MM/yyyy");
                    if (dt.Rows[0]["APPLICANT_AGE"].ToString().Trim() != "")
                        txtDOB2.Text = dt.Rows[0]["APPLICANT_AGE"].ToString().Trim();
                    if (dt.Rows[0]["FATHER_NAME"].ToString().Trim() != "")
                        txtFatherName.Text = dt.Rows[0]["FATHER_NAME"].ToString().Trim();
                    if (dt.Rows[0]["MOTHER_NAME"].ToString().Trim() != "")
                        txtMotherName.Text = dt.Rows[0]["MOTHER_NAME"].ToString().Trim();

                    if (dt.Rows[0]["HOUSE_NO_CA"].ToString().Trim() != "")
                        txtHNo.Text = dt.Rows[0]["HOUSE_NO_CA"].ToString().Trim();
                    if (dt.Rows[0]["AREA_CA"].ToString().Trim() != "")
                        txtArea.Text = dt.Rows[0]["AREA_CA"].ToString().Trim();
                    if (dt.Rows[0]["LANDMARK_CA"].ToString().Trim() != "")
                        txtLandmark.Text = dt.Rows[0]["LANDMARK_CA"].ToString().Trim();
                    if (dt.Rows[0]["CITY_CA"].ToString().Trim() != "")
                        txtCity.Text = dt.Rows[0]["CITY_CA"].ToString().Trim();
                    if (dt.Rows[0]["DISTRICT_CA"].ToString().Trim() != "")
                        txtDist.Text = dt.Rows[0]["DISTRICT_CA"].ToString().Trim();
                    if (dt.Rows[0]["STATE_CA"].ToString().Trim() != "")
                        txtState.Text = dt.Rows[0]["STATE_CA"].ToString().Trim();
                    if (dt.Rows[0]["PIN_CA"].ToString().Trim() != "")
                        txtPin.Text = dt.Rows[0]["PIN_CA"].ToString().Trim();
                    if (dt.Rows[0]["POST_OFFICE_CA"].ToString().Trim() != "")
                        txtPO.Text = dt.Rows[0]["POST_OFFICE_CA"].ToString().Trim();
                    if (dt.Rows[0]["RAILWAY_STATION_CA"].ToString().Trim() != "")
                        txtRail.Text = dt.Rows[0]["RAILWAY_STATION_CA"].ToString().Trim();

                    if (dt.Rows[0]["SAME_ADDRESS"].ToString().Trim() == "1")
                    {
                        chkSame.Checked = true;
                        txtHNo1.ReadOnly = true;
                        txtArea1.ReadOnly = true;
                        txtLandmark1.ReadOnly = true;
                        txtCity1.ReadOnly = true;
                        txtDist1.ReadOnly = true;
                        txtState1.ReadOnly = true;
                        txtPin1.ReadOnly = true;
                        txtPO1.ReadOnly = true;
                        txtRail1.ReadOnly = true;
                    }
                    else
                    {
                        chkSame.Checked = false;
                        txtHNo1.ReadOnly = false;
                        txtArea1.ReadOnly = false;
                        txtLandmark1.ReadOnly = false;
                        txtCity1.ReadOnly = false;
                        txtDist1.ReadOnly = false;
                        txtState1.ReadOnly = false;
                        txtPin1.ReadOnly = false;
                        txtPO1.ReadOnly = false;
                        txtRail1.ReadOnly = false;
                    }

                    if (dt.Rows[0]["HOUSE_NO_PA"].ToString().Trim() != "")
                        txtHNo1.Text = dt.Rows[0]["HOUSE_NO_PA"].ToString().Trim();
                    if (dt.Rows[0]["AREA_PA"].ToString().Trim() != "")
                        txtArea1.Text = dt.Rows[0]["AREA_PA"].ToString().Trim();
                    if (dt.Rows[0]["LANDMARK_PA"].ToString().Trim() != "")
                        txtLandmark1.Text = dt.Rows[0]["LANDMARK_PA"].ToString().Trim();
                    if (dt.Rows[0]["CITY_PA"].ToString().Trim() != "")
                        txtCity1.Text = dt.Rows[0]["CITY_PA"].ToString().Trim();
                    if (dt.Rows[0]["DISTRICT_PA"].ToString().Trim() != "")
                        txtDist1.Text = dt.Rows[0]["DISTRICT_PA"].ToString().Trim();
                    if (dt.Rows[0]["STATE_PA"].ToString().Trim() != "")
                        txtState1.Text = dt.Rows[0]["STATE_PA"].ToString().Trim();
                    if (dt.Rows[0]["PIN_PA"].ToString().Trim() != "")
                        txtPin1.Text = dt.Rows[0]["PIN_PA"].ToString().Trim();
                    if (dt.Rows[0]["POST_OFFICE_PA"].ToString().Trim() != "")
                        txtPO1.Text = dt.Rows[0]["POST_OFFICE_PA"].ToString().Trim();
                    if (dt.Rows[0]["RAILWAY_STATION_PA"].ToString().Trim() != "")
                        txtRail1.Text = dt.Rows[0]["RAILWAY_STATION_PA"].ToString().Trim();

                    //EditableField(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        void BindPost()
        {
            try
            {
                dt = site.getdatatable("select DISCIPLINE,ID from POST_EDU_AGE order by DISCIPLINE desc");
                ddlPost.DataSource = dt;
                ddlPost.DataTextField = "DISCIPLINE";
                ddlPost.DataValueField = "DISCIPLINE";
                ddlPost.DataBind();
                ddlPost.Items.Insert(0, "Select");
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        void BindPHType()
        {
            try
            {
                dt = site.getdatatable("select NAME,SEQ from PWD_TYPES order by NAME");
                ddlPwdType.DataSource = dt;
                ddlPwdType.DataTextField = "NAME";
                ddlPwdType.DataValueField = "NAME";
                ddlPwdType.DataBind();
                ddlPwdType.Items.Insert(0, "Select");
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        void BindCategory()
        {
            try
            {

                dt = site.getdatatable("select CATEGORY_NAME,SEQ from AGE_CATEGORY_TYPES order by SEQ");
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "CATEGORY_NAME";
                ddlCategory.DataValueField = "CATEGORY_NAME";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "Select");
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
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblStatus.Visible = false;
                }

                if (txtName.Text.Trim() == "")
                {
                    lblName.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblName.Visible = false;
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

                if (ddlMarital.SelectedItem.Text.ToString().ToUpper().Trim() == "SELECT")
                {
                    lblMarital.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblMarital.Visible = false;
                }

                if (ddlReligion.SelectedItem.Text.ToString().ToUpper().Trim() == "SELECT")
                {
                    lblReligion.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblReligion.Visible = false;
                }

                if (ddlPost.SelectedItem.Text.ToString().ToUpper().Trim() == "SELECT")
                {
                    lblPost.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    lblPost.Visible = false;
                    ViewState["SAVE"] = "YES";
                }

                if (ddlCategory.SelectedItem.Text.ToString().ToUpper().Trim() == "SELECT")
                {
                    lblCategory.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblCategory.Visible = false;
                }

                if (divOther.Visible)
                {
                    if (txtOther.Text.Trim() == "")
                    {
                        lblOther.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblOther.Visible = false;
                    }
                }

                if (ddlDomState.SelectedItem.Text.ToString().ToUpper().Trim() == "SELECT")
                {
                    lblDomState.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblDomState.Visible = false;
                }

                if (divESM.Visible)
                {
                    if (ddlESM.SelectedIndex == 1)
                    {
                        ViewState["SAVE"] = "YES";
                        lblESM1.Visible = false;
                    }
                    else
                    {
                        lblESM1.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                }

                if (divCaste.Visible == true)
                {
                    if (castCert.Text.Trim() == "")
                    {
                        lblCastCert.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        string xStat = site.ValidateTextNumberWithourSpecialChars(castCert.Text);
                        if (xStat == "NO")
                        {
                            lblCastCert.Text = "Invalid Caste Certificate No.";
                            lblCastCert.Visible = true;
                            ViewState["SAVE"] = "NO";
                            return;
                        }
                        else
                        {
                            ViewState["SAVE"] = "YES";
                            lblCastCert.Visible = false;
                        }
                    }

                    if (txtCasteDate.Text.Trim() == "")
                    {
                        lblCasteIssDt.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblCasteIssDt.Visible = false;
                    }

                    //if (ddlCategory.SelectedItem.Text.Trim() == "OBC(NCL)")
                    //    ValidateOBCDateFormat(txtCasteDate.Text.Trim());
                    //else
                    //    ValidateDateFormat(txtCasteDate.Text.Trim());

                    //if (ViewState["SAVE"].ToString() == "NO")
                    //{
                    //    lblCasteIssDt.Text = "Invalid OBC(NCL) Issue Date, it is older than 6-month";
                    //    lblCasteIssDt.Visible = true;
                    //    return;
                    //}
                    //else
                    //{
                    //    lblCasteIssDt.Visible = false;
                    //}
                }

                if (divRelexp.Visible)
                {
                    if (ddlRelevantExp.SelectedIndex == 0)
                    {
                        lblRelExp.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblRelExp.Visible = false;
                    }

                    if (ddlRelevantExp.SelectedIndex == 1)
                    {
                        if (ddlYears.SelectedIndex == 0)
                        {
                            lblYears.Visible = true;
                            ViewState["SAVE"] = "NO";
                            return;
                        }
                        else
                        {
                            ViewState["SAVE"] = "YES";
                            lblYears.Visible = false;
                        }

                        if (ddlMonths.SelectedIndex == 0)
                        {
                            lblMonths.Visible = true;
                            ViewState["SAVE"] = "NO";
                            return;
                        }
                        else
                        {
                            ViewState["SAVE"] = "YES";
                            lblMonths.Visible = false;
                        }

                        if (ddlDays.SelectedIndex == 0)
                        {
                            lblDays.Visible = true;
                            ViewState["SAVE"] = "NO";
                            return;
                        }
                        else
                        {
                            ViewState["SAVE"] = "YES";
                            lblDays.Visible = false;
                        }
                    }
                }
                if (ddlExArmy.SelectedIndex == 0)
                {
                    lblExArmy.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    if (ddlExArmy.SelectedIndex == 1)
                    {
                        if (txtRank.Text.Trim() == "")
                        {
                            lblRank.Visible = true;
                            lblExArmy.Visible = false;
                            ViewState["SAVE"] = "NO";
                            return;
                        }
                        else
                        {
                            ViewState["SAVE"] = "YES";
                            lblRank.Visible = false;
                        }

                        if (txtFrom.Text.Trim() == "")
                        {
                            lblFrom.Visible = true;
                            ViewState["SAVE"] = "NO";
                            return;
                        }
                        else
                        {
                            ViewState["SAVE"] = "YES";
                            lblFrom.Visible = false;
                        }

                        if (txtUpto.Text.Trim() == "")
                        {
                            lblUpto.Visible = true;
                            ViewState["SAVE"] = "NO";
                            return;
                        }
                        else
                        {
                            ViewState["SAVE"] = "YES";
                            lblUpto.Visible = false;
                        }
                    }
                }

                if (ddlDomicile.SelectedIndex == 0)
                {
                    lblDomicile.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    if (divJKD.Visible)
                    {
                        if (txtDomDate.Text.Trim() == "")
                        {
                            lblDomDate.Visible = true;
                            ViewState["SAVE"] = "NO";
                            return;
                        }
                        else
                        {
                            ViewState["SAVE"] = "YES";
                            lblDomDate.Visible = false;
                        }
                        lblDomicile.Visible = false;
                    }
                }

                if (ddlApprentice.SelectedIndex == 1)
                {
                    lblApprentice.Visible = false;
                    if (txtJoinDate.Text.Trim() == "")
                    {
                        lblJoinDate.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblJoinDate.Visible = false;
                    }

                    if (txtLeaveDate.Text.Trim() == "")
                    {
                        lblLeaveDate.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblLeaveDate.Visible = false;
                    }
                }

                //if(divApprentice.Visible)
                //{
                //    if(ddlApprentice.SelectedIndex == 0)
                //    {
                //        lblApprentice.Visible = true;
                //        ViewState["SAVE"] = "NO";
                //        return;
                //    }
                //    else
                //    {
                //        if (divYY.Visible)
                //        {
                //            if (ddlYY.SelectedIndex == 0)
                //            {
                //                lblYY.Visible = true;
                //                ViewState["SAVE"] = "NO";
                //                return;
                //            }
                //            else
                //            {
                //                ViewState["SAVE"] = "YES";
                //                lblYY.Visible = false;
                //            }

                //            if (ddlMM.SelectedIndex == 0)
                //            {
                //                lblMM.Visible = true;
                //                ViewState["SAVE"] = "NO";
                //                return;
                //            }
                //            else
                //            {
                //                ViewState["SAVE"] = "YES";
                //                lblMM.Visible = false;
                //            }

                //            if (ddlDD.SelectedIndex == 0)
                //            {
                //                lblDD.Visible = true;
                //                ViewState["SAVE"] = "NO";
                //                return;
                //            }
                //            else
                //            {
                //                ViewState["SAVE"] = "YES";
                //                lblDD.Visible = false;
                //            }
                //        }
                //    }
                //}

                if (ddlPwD.SelectedIndex == 0)
                {
                    lblPwd.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblPwd.Visible = false;
                }

                if (divPwBD.Visible == true)
                {
                    if (ddlPwdType.SelectedItem.Text.ToString().ToUpper().Trim() == "SELECT")
                    {
                        lblPwdType.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblPwdType.Visible = false;
                    }

                    //if (ddlPwdSub.SelectedItem.Text.ToString().ToUpper().Trim() == "SELECT")
                    //{
                    //    lblPwdSub.Visible = true;
                    //    ViewState["SAVE"] = "NO";
                    //    return;
                    //}
                    //else
                    //{
                    //    ViewState["SAVE"] = "YES";
                    //    lblPwdSub.Visible = false;
                    //}

                    if (txtPHPer.Text.Trim() == "")
                    {
                        lblPHPer.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        if (Convert.ToInt32(txtPHPer.Text) >= 40)
                        {
                            ViewState["SAVE"] = "YES";
                            lblPHPer.Visible = false;
                        }
                        else
                        {
                            lblPHPer.Text = "PwD % should be 40% or above";
                            lblPHPer.Visible = true;
                            ViewState["SAVE"] = "NO";
                            return;
                        }
                    }
                }

                if (txtDOB.Text.Trim() == "")
                {
                    lblDOB1.Text = "Invalid Date Of Birth!";
                    lblDOB1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateDOB(txtDOB.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblDOB1.Text = "Invalid Date Of Birth!";
                        lblDOB1.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        lblDOB1.Visible = false;
                        ViewState["SAVE"] = "YES";
                        dobValidation();
                        if (ViewState["SAVE"].ToString() == "NO")
                        {
                            lblDOB1.Text = "Invalid Date Of Birth!";
                            lblDOB1.Visible = true;
                            ViewState["SAVE"] = "NO";
                            return;
                        }
                        else
                        {
                            lblDOB1.Visible = false;
                            ViewState["SAVE"] = "YES";
                        }
                    }
                }

                //Start Mail validation
                string email = txtMail.Text.Trim();
                string confirmEmail = txtMail1.Text.Trim();

                // Clear previous error messages
                lblMail.Visible = false;
                lblMail1.Visible = false;

                if (string.IsNullOrEmpty(email))
                {
                    lblMail.Text = "EMail ID Required";
                    lblMail.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else if (string.IsNullOrEmpty(confirmEmail))
                {
                    lblMail1.Text = "Confirm EMail ID Required";
                    lblMail1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else if (!IsValidEmail(email))
                {
                    lblMail.Text = "Invalid Email Address";
                    lblMail.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else if (email != confirmEmail)
                {
                    lblMail1.Text = "Email addresses do not match";
                    lblMail1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    // Proceed with form processing
                }
                //End Mail validation
                //if (txtMail.Text.Trim() == "")
                //{
                //    lblMail.Visible = true;
                //    ViewState["SAVE"] = "NO";
                //    return;
                //}
                //else
                //{
                //    ViewState["SAVE"] = "YES";
                //    lblMail.Visible = false;
                //}

                //if (txtMail1.Text.Trim() == "")
                //{
                //    lblMail1.Visible = true;
                //    ViewState["SAVE"] = "NO";
                //    return;
                //}
                //else
                //{
                //    ViewState["SAVE"] = "YES";
                //    lblMail1.Visible = false;
                //}

                //if (txtMail.Text.Trim() != txtMail1.Text.Trim())
                //{
                //    lblMail1.Visible = true;
                //    lblMail1.Text = "EMail ID and Confirm EMail ID not matching";
                //    ViewState["SAVE"] = "NO";
                //    return;
                //}
                //else
                //{
                //    ViewState["SAVE"] = "YES";
                //    lblMail1.Visible = false;
                //}

                //start Mobile validation
                //if (txtMobile.Text.Trim() == "")
                //{
                //    lblMobile.Visible = true;
                //    ViewState["SAVE"] = "NO";
                //    return;
                //}
                //else
                //{
                //    ViewState["SAVE"] = "YES";
                //    lblMobile.Visible = false;
                //}

                //if (txtMobile.Text.Trim() == "")
                //{
                //    lblMobile1.Visible = true;
                //    ViewState["SAVE"] = "NO";
                //    return;
                //}
                //else
                //{
                //    ViewState["SAVE"] = "YES";
                //    lblMobile1.Visible = false;
                //}

                //if (txtMobile.Text.Trim() != txtMobile1.Text.Trim())
                //{
                //    lblMobile1.Visible = true;
                //    lblMobile1.Text = "Mobile Number and Confirm Number not matching";
                //    ViewState["SAVE"] = "NO";
                //    return;
                //}
                //else
                //{
                //    ViewState["SAVE"] = "YES";
                //    lblMobile1.Visible = false;
                //}


                string mobile1 = txtMobile.Text.Trim();
                string mobile2 = txtMobile1.Text.Trim();

                // Server-side validation
                if (!IsValidMobileNumber(mobile1))
                {
                    lblMobile.Text = "Invalid Mobile Number";
                    lblMobile.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else if (!mobile1.Equals(mobile2, StringComparison.OrdinalIgnoreCase))
                {
                    lblMobile1.Text = "Mobile numbers do not match";
                    lblMobile1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    lblMobile.Visible = false;
                    lblMobile1.Visible = false;
                    ViewState["SAVE"] = "YES";
                    // Proceed with further processing
                }
                //end Mobile validation

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

                if ((txtAdhar1.Text.Trim() == "") || (txtAdhar1.Text.Trim().Length < 12))
                {
                    ViewState["SAVE"] = "NO";
                    lblAdhar1.Text = "Invalid Aadhar Number";
                    lblAdhar1.Visible = true;
                    return;
                }
                else
                {
                    ValidateAadharNo(txtAdhar1.Text.Trim());
                }

                if (ViewState["SAVE"].ToString() == "YES")
                {
                    lblAdhar1.Visible = false;
                }
                else
                {
                    lblAdhar1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }


                if (txtAdhar.Text.Trim() != txtAdhar1.Text.Trim())
                {
                    lblAdhar1.Visible = true;
                    lblAdhar1.Text = "EMail ID and Confirm EMail ID not matching";
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblAdhar1.Visible = false;
                }

                if (txtFatherName.Text.Trim() == "")
                {
                    lblFather.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtFatherName.Text.Trim().ToUpper());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblFather.Visible = true;
                        lblFather.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblFather.Visible = false;
                    }
                }

                if (txtMotherName.Text.Trim() == "")
                {
                    lblMother.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtMotherName.Text.Trim().ToUpper());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblMother.Visible = true;
                        lblMother.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblMother.Visible = false;
                    }
                }
                //Correspondence Address
                if (txtHNo.Text.Trim() == "")
                {
                    lblHNo.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblHNo.Visible = false;
                }

                if (txtArea.Text.Trim() == "")
                {
                    lblArea.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblArea.Visible = false;
                }

                if (txtLandmark.Text.Trim() == "")
                {
                    lblLandmark.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtLandmark.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblLandmark.Visible = true;
                        lblLandmark.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblLandmark.Visible = false;
                    }
                }

                if (txtCity.Text.Trim() == "")
                {
                    lblCity.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtCity.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblCity.Visible = true;
                        lblCity.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblCity.Visible = false;
                    }
                }

                if (txtDist.Text.Trim() == "")
                {
                    lblDist.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtDist.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblDist.Visible = true;
                        lblDist.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblDist.Visible = false;
                    }
                }

                if (txtState.Text.Trim() == "")
                {
                    lblState.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtState.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblState.Visible = true;
                        lblState.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblState.Visible = false;
                    }
                }

                if (txtPin.Text.Trim() == "")
                {
                    lblPin.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    txtPin.Text = Convert.ToInt32(txtPin.Text.Trim()).ToString();
                    if (txtPin.Text.Trim().Length != 6)
                    {
                        lblPin.Text = "Invalid PIN Code!";
                        lblPin.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblPin.Visible = false;
                    }

                    string xStat = site.ValidateNumbers(txtPin.Text.Trim().ToUpper());
                    if (xStat == "NO")
                    {
                        lblPin.Visible = true;
                        lblPin.Text = "Only Numbers are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblPin.Visible = false;
                    }
                }

                if (txtPO.Text.Trim() == "")
                {
                    lblPO.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtPO.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblPO.Visible = true;
                        lblPO.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblPO.Visible = false;
                    }
                }

                if (txtRail.Text.Trim() == "")
                {
                    lblRail.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtRail.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblRail.Visible = true;
                        lblRail.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblRail.Visible = false;
                    }
                }
                // Permanent Address
                if (txtHNo1.Text.Trim() == "")
                {
                    lblHNo1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblHNo1.Visible = false;
                }

                if (txtArea1.Text.Trim() == "")
                {
                    lblArea1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblArea.Visible = false;
                }

                if (txtLandmark1.Text.Trim() == "")
                {
                    lblLandmark1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtLandmark1.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblLandmark1.Visible = true;
                        lblLandmark1.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblLandmark1.Visible = false;
                    }
                }

                if (txtCity1.Text.Trim() == "")
                {
                    lblCity1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtCity1.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblCity1.Visible = true;
                        lblCity1.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblCity1.Visible = false;
                    }
                }

                if (txtDist1.Text.Trim() == "")
                {
                    lblDist1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtDist1.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblDist1.Visible = true;
                        lblDist1.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblDist1.Visible = false;
                    }
                }

                if (txtState1.Text.Trim() == "")
                {
                    lblState1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtState1.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblState1.Visible = true;
                        lblState1.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblState1.Visible = false;
                    }
                }

                if (txtPin1.Text.Trim() == "")
                {
                    lblPin1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    txtPin1.Text = Convert.ToInt32(txtPin1.Text.Trim()).ToString();
                    if (txtPin1.Text.Trim().Length != 6)
                    {
                        lblPin1.Text = "Invalid PIN Code!";
                        lblPin1.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblPin1.Visible = false;
                    }

                    string xStat = site.ValidateNumbers(txtPin1.Text.Trim().ToUpper());
                    if (xStat == "NO")
                    {
                        lblPin1.Visible = true;
                        lblPin1.Text = "Only Numbers are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblPin1.Visible = false;
                    }
                }

                if (txtPO1.Text.Trim() == "")
                {
                    lblPO1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtPO1.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblPO1.Visible = true;
                        lblPO1.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblPO1.Visible = false;
                    }
                }

                if (txtRail1.Text.Trim() == "")
                {
                    lblRail1.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ValidateAlphabetWithSpace(txtRail1.Text.Trim());
                    if (ViewState["SAVE"].ToString() == "NO")
                    {
                        lblRail1.Visible = true;
                        lblRail1.Text = "Only Alphabets are allowed!";
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblRail1.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        protected void ValidateAadharNo(string xAadhar)     //original
        {
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
        }
        protected void dateValidation(string dated)
        {
            DateTime date1 = Convert.ToDateTime(dated);
            DateTime date2 = DateTime.Now.Date;
            int diff = DateTime.Compare(date1, date2);
            if (diff > 0)
            {
                ViewState["SAVE"] = "NO";
            }
            else
            {
                ViewState["SAVE"] = "YES";
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateFields();

                if (ViewState["SAVE"].ToString() == "NO")
                {
                    lblStatus.Text = "Kindly fill all the required information!";
                    lblStatus.Visible = true;
                    return;
                }
                else
                {
                    lblStatus.Text = "";
                    if (Page.IsValid)
                    {
                        string xName = "", xDiscipline = null, xCategory = null, xPH = null, xPHType = null, xPHPer = "0", xCasteNo = null, xCasteDate = null, xDOB = null, xDD = null, xMM = null, xYYYY = null, xAge = null, xFather = null, xMother = null, xJoinDate = null, xLeavingDate = null, xPHSub = null;
                        string xHNo = null, xArea = null, xLandmark = null, xCity = null, xDist = null, xState = null, xPin = null, xPO = null, xRail = null, xHNo1 = null, xArea1 = null, xLandmark1 = null, xCity1 = null, xDist1 = null, xState1 = null, xPin1 = null, xPO1 = null, xRail1 = null;
                        string xRelExp = null, xSameAdd = null, xYears = null, xMonths = null, xDays = null, xArmy = null, xRank = null, xDom = null, xDomDate = null, xApprentice = null, xESM = null, xDomState = null, xGender = null, xMarital = null, xRel = null, xOther = null, xMail = null, xAdhar = null, xMobile = null, xFrom = null, xUpto = null;

                        if (txtName.Text.Trim() == "")
                            xName = null;
                        else
                            xName = txtName.Text.Trim().ToUpper();

                        if (ddlGender.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                            xGender = null;
                        else
                            xGender = ddlGender.SelectedItem.Text.Trim();

                        if (ddlMarital.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                            xMarital = null;
                        else
                            xMarital = ddlMarital.SelectedItem.Text.Trim();

                        if (ddlReligion.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                            xRel = null;
                        else
                            xRel = ddlReligion.SelectedItem.Text.Trim();

                        if (ddlPost.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                            xDiscipline = null;
                        else
                            xDiscipline = ddlPost.SelectedItem.Text.Trim();

                        if (ddlCategory.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                            xCategory = null;
                        else
                            xCategory = ddlCategory.SelectedItem.Text.Trim();

                        if (ddlDomState.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                            xDomState = null;
                        else
                            xDomState = ddlDomState.SelectedItem.Text.Trim();

                        if (txtOther.Text.Trim() == "")
                            xOther = null;
                        else
                            xOther = txtOther.Text.Trim();

                        if (ddlESM.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                            xESM = null;
                        else
                            xESM = ddlESM.SelectedItem.Text.Trim();

                        if (ddlRelevantExp.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                            xRelExp = null;
                        else
                            xRelExp = ddlRelevantExp.SelectedItem.Text.Trim();

                        if (ddlRelevantExp.SelectedIndex == 1)
                        {
                            if (ddlYears.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                                xYears = null;
                            else
                                xYears = ddlYears.SelectedItem.Text.Trim();

                            if (ddlMonths.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                                xMonths = null;
                            else
                                xMonths = ddlMonths.SelectedItem.Text.Trim();

                            if (ddlDays.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                                xDays = null;
                            else
                                xDays = ddlDays.SelectedItem.Text.Trim();
                        }

                        if (ddlExArmy.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                            xArmy = null;
                        else
                            xArmy = ddlExArmy.SelectedItem.Text.Trim();

                        if (txtRank.Text.Trim() == "")
                            xRank = null;
                        else
                            xRank = txtRank.Text.Trim().ToUpper();

                        if (txtFrom.Text.Trim() == "")
                            xFrom = null;
                        else
                            xFrom = txtFrom.Text.Trim().ToUpper();

                        if (txtUpto.Text.Trim() == "")
                            xUpto = null;
                        else
                            xUpto = txtUpto.Text.Trim().ToUpper();


                        if (ddlDomicile.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                            xDom = null;
                        else
                            xDom = ddlDomicile.SelectedItem.Text.Trim();

                        if (txtDomDate.Text.Trim() == "")
                            xDomDate = null;
                        else
                            xDomDate = DateTime.Parse(txtDomDate.Text).ToString("dd/MM/yyyy");

                        if (ddlApprentice.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                            xApprentice = null;
                        else
                            xApprentice = ddlApprentice.SelectedItem.Text.Trim();

                        if (txtJoinDate.Text.Trim() == "")
                            xJoinDate = null;
                        else
                            xJoinDate = DateTime.Parse(txtJoinDate.Text).ToString("dd/MM/yyyy");

                        if (txtLeaveDate.Text.Trim() == "")
                            xLeavingDate = null;
                        else
                            xLeavingDate = DateTime.Parse(txtLeaveDate.Text).ToString("dd/MM/yyyy");

                        if (ddlPwD.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                            xPH = null;
                        else
                            xPH = ddlPwD.SelectedItem.Text.Trim();

                        if (divPwBD.Visible == true)
                        {
                            if (ddlPwdType.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                                xPHType = null;
                            else
                                xPHType = ddlPwdType.SelectedItem.Text.Trim();

                            //if (ddlPwdSub.SelectedItem.Text.Trim().ToUpper() == "SELECT")
                            //    xPHSub = null;
                            //else
                            //    xPHSub = ddlPwdSub.SelectedItem.Text.Trim();

                            if (txtPHPer.Text.Trim() == "")
                                xPHPer = null;
                            else
                                xPHPer = txtPHPer.Text.Trim();
                        }
                        else
                        {
                            xPHType = "";
                            xPHPer = "0";
                        }

                        if (castCert.Text.Trim() == "")
                            xCasteNo = null;
                        else
                            xCasteNo = castCert.Text.Trim().ToUpper();

                        if (txtCasteDate.Text.Trim() == "")
                            xCasteDate = null;
                        else
                            xCasteDate = DateTime.Parse(txtCasteDate.Text).ToString("dd/MM/yyyy");

                        if (txtDOB.Text.Trim() == "")
                        {
                            xDOB = null;
                            xDD = null;
                            xMM = null;
                            xYYYY = null;
                        }
                        else
                        {
                            xDOB = DateTime.Parse(txtDOB.Text).ToString("dd/MM/yyyy");
                            xDD = DateTime.Parse(txtDOB.Text).ToString("dd");
                            xMM = DateTime.Parse(txtDOB.Text).ToString("MM");
                            xYYYY = DateTime.Parse(txtDOB.Text).ToString("yyyy");
                        }

                        if (txtDOB2.Text.Trim() == "")
                            xAge = null;
                        else
                            xAge = txtDOB2.Text.Trim();

                        if (txtMail.Text.Trim() == "")
                            xMail = null;
                        else
                            xMail = txtMail.Text.Trim();

                        if (txtAdhar.Text.Trim() == "")
                            xAdhar = null;
                        else
                            xAdhar = txtAdhar.Text.Trim();

                        if (txtMobile.Text.Trim() == "")
                            xMobile = null;
                        else
                            xMobile = txtMobile.Text.Trim();

                        if (txtFatherName.Text.Trim() == "")
                            xFather = null;
                        else
                            xFather = txtFatherName.Text.Trim().ToUpper();

                        if (txtMotherName.Text.Trim() == "")
                            xMother = null;
                        else
                            xMother = txtMotherName.Text.Trim().ToUpper();

                        if (txtHNo.Text.Trim() == "")
                            xHNo = null;
                        else
                            xHNo = txtHNo.Text.Trim().ToUpper();

                        if (txtArea.Text.Trim() == "")
                            xArea = null;
                        else
                            xArea = txtArea.Text.Trim().ToUpper();

                        if (txtLandmark.Text.Trim() == "")
                            xLandmark = null;
                        else
                            xLandmark = txtLandmark.Text.Trim().ToUpper();

                        if (txtCity.Text.Trim() == "")
                            xCity = null;
                        else
                            xCity = txtCity.Text.Trim().ToUpper();

                        if (txtDist.Text.Trim() == "")
                            xDist = null;
                        else
                            xDist = txtDist.Text.Trim().ToUpper();

                        if (txtState.Text.Trim() == "")
                            xState = null;
                        else
                            xState = txtState.Text.Trim().ToUpper();

                        if (txtPin.Text.Trim() == "")
                            xPin = null;
                        else
                            xPin = txtPin.Text.Trim().ToUpper();

                        if (txtPO.Text.Trim() == "")
                            xPO = null;
                        else
                            xPO = txtPO.Text.Trim().ToUpper();

                        //if (!chkSame.Checked)
                        //    xSameAdd = null;
                        //else
                        //    xSameAdd=chkSame.Checked.ToString();

                        if (txtRail.Text.Trim() == "")
                            xRail = null;
                        else
                            xRail = txtRail.Text.Trim().ToUpper();

                        if (txtHNo1.Text.Trim() == "")
                            xHNo1 = null;
                        else
                            xHNo1 = txtHNo1.Text.Trim().ToUpper();

                        if (txtArea1.Text.Trim() == "")
                            xArea1 = null;
                        else
                            xArea1 = txtArea1.Text.Trim().ToUpper();

                        if (txtLandmark1.Text.Trim() == "")
                            xLandmark1 = null;
                        else
                            xLandmark1 = txtLandmark1.Text.Trim().ToUpper();

                        if (txtCity1.Text.Trim() == "")
                            xCity1 = null;
                        else
                            xCity1 = txtCity1.Text.Trim().ToUpper();

                        if (txtDist1.Text.Trim() == "")
                            xDist1 = null;
                        else
                            xDist1 = txtDist1.Text.Trim().ToUpper();

                        if (txtState1.Text.Trim() == "")
                            xState1 = null;
                        else
                            xState1 = txtState1.Text.Trim().ToUpper();

                        if (txtPin1.Text.Trim() == "")
                            xPin1 = null;
                        else
                            xPin1 = txtPin1.Text.Trim().ToUpper();

                        if (txtPO1.Text.Trim() == "")
                            xPO1 = null;
                        else
                            xPO1 = txtPO1.Text.Trim().ToUpper();

                        if (txtRail1.Text.Trim() == "")
                            xRail1 = null;
                        else
                            xRail1 = txtRail1.Text.Trim().ToUpper();

                        string xQuery = "UPDATE APPLICANT SET APPLICANT_NAME='" + xName + "', APPLIED_DISCIPLINE='" + xDiscipline + "',CATEGORY_APPLIED='" + xCategory + "',DOB='" + xDOB + "',DOB_DD=" + xDD + ",DOB_MM=" + xMM + ",DOB_YYYY=" + xYYYY + ",APPLICANT_AGE='" + xAge + "',GENDER='" + xGender + "',MARITAL_STATUS='" + xMarital + "',RELIGION_NAME='" + xRel + "',OTHER_RELIGION='" + xOther + "'";
                        xQuery += ",FATHER_NAME='" + xFather + "',MOTHER_NAME='" + xMother + "',PWD_APPLIED='" + xPH + "',PWD_TYPE='" + xPHType + "',PWD_SUB='" + xPHSub + "',PWD_PERCENT=" + xPHPer + ",CASTE_CERT_NO='" + xCasteNo + "',CASTE_CERT_ISSUE_DATE='" + xCasteDate + "',ESM_COURSE='" + xESM + "',DOMICILE_STATE='" + xDomState + "',HAL_JOINING_DATE='" + xJoinDate + "',HAL_LEAVING_DATE='" + xLeavingDate + "'";
                        xQuery += ",RELEVANT_EXP='" + xRelExp + "',EX_SERVICE_MAN='" + xArmy + "',JK_DOMICILE='" + xDom + "',DOMICILE_DATE='" + xDomDate + "',HAL_APPRENTICESHIP='" + xApprentice + "',EMAIL='" + xMail + "',AADHAR_NO=" + xAdhar + ",MOBILE=" + xMobile + ",RANK_HELD='" + xRank + "',ENROLL_DATE='" + xFrom + "', DISCHARGE_DATE='" + xUpto + "'";
                        xQuery += ",HOUSE_NO_CA ='" + xHNo + "',AREA_CA='" + xArea + "' ,LANDMARK_CA='" + xLandmark + "',CITY_CA='" + xCity + "' ,DISTRICT_CA='" + xDist + "',STATE_CA='" + xState + "' ,PIN_CA=" + xPin + " ,POST_OFFICE_CA='" + xPO + "' ,RAILWAY_STATION_CA='" + xRail + "',HOUSE_NO_PA='" + xHNo1 + "',AREA_PA='" + xArea1 + "' ,LANDMARK_PA='" + xLandmark1 + "' ,CITY_PA='" + xCity1 + "' ,DISTRICT_PA='" + xDist1 + "' ,STATE_PA='" + xState1 + "' ,PIN_PA=" + xPin1 + " ,POST_OFFICE_PA='" + xPO1 + "' ,RAILWAY_STATION_PA='" + xRail1 + "'";
                        xQuery += chkSame.Checked ? ",SAME_ADDRESS=1" : ",SAME_ADDRESS=0";
                        if (ddlRelevantExp.SelectedIndex == 1)
                            xQuery += ",REL_YEARS=" + xYears + ",REL_MONTH=" + xMonths + ",REL_DAY=" + xDays + ",dated=getdate() WHERE USERID='" + appNo + "'";
                        else
                            xQuery += " WHERE USERID='" + appNo + "'";

                        int rex = site.executeNonQuery(xQuery);
                        xQuery = null;
                        if (rex == 0)
                        {
                            lblStatus.Text = "Unable to update record(s)!";
                            lblStatus.Visible = true;
                            return;
                        }
                        else
                        {
                            rex = site.executeNonQuery("update APPLICANT set EDUCATION_PAGE=0,EXPERIENCE_PAGE=0,DOCUMENT_PAGE=0,BOARD10_INST=null,BOARD10_NATURE=null,BOARD10_DURATION=null,BOARD10_SUBJECTS=null,BOARD10_DIVISION=null,BOARD10_PERCENT=null,BOARD10_PASSING_DATE=null,BOARD12_INST=null,BOARD12_NATURE=null,BOARD12_DURATION=null,BOARD12_SUBJECTS=null,BOARD12_DIVISION=null,BOARD12_PERCENT=null,BOARD12_PASSING_DATE=null,ITI_INST=null,ITI_NATURE=null,ITI_DURATION=null,ITI_SUBJECTS=null,ITI_DIVISION=null,ITI_PERCENT=null,ITI_PASSING_DATE=null,DIPLOMA_INST=null,DIPLOMA_NATURE=null,DIPLOMA_DURATION=null,DIPLOMA_SUBJECTS=null,DIPLOMA_DIVISION=null,DIPLOMA_PERCENT=null,DIPLOMA_PASSING_DATE=null WHERE USERID='" + appNo + "'");
                            //rex = site.executeNonQuery("DELETE FROM WORK_EXPERIENCE WHERE USERID='" + appNo + "'");
                            Response.Redirect("PersonalInfoPreview");
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        protected void ValidateDOB(string dated)
        {
            ViewState["SAVE"] = "YES";
            if (dated == null)
            {
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                DateTime dtd;
                bool valid = DateTime.TryParseExact(dated, "dd/MM/yyyy", null, DateTimeStyles.None, out dtd);
                if (valid)
                {
                    var dt1 = DateTime.Parse(dated);
                    var dt2 = DateTime.Parse("01-01-1950");
                    var dt3 = DateTime.Parse("01-01-2024");
                    int result1 = DateTime.Compare(dt1, dt2);
                    int result2 = DateTime.Compare(dt1, dt3);
                    if (result1 < 0)
                    {
                        ViewState["SAVE"] = "NO";
                    }
                    else if (result2 > 0)
                    {
                        ViewState["SAVE"] = "NO";
                    }
                }
                else
                {
                    ViewState["SAVE"] = "NO";
                }
            }
        }
        protected void ValidateDateFormat(string dated)
        {
            ViewState["SAVE"] = "YES";
            if (dated == null)
            {
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                DateTime dtd;
                bool valid = DateTime.TryParseExact(dated, "dd/MM/yyyy", null, DateTimeStyles.None, out dtd);
                if (valid)
                {
                    //var dt1 = DateTime.Parse(dated);
                    //var dt2 = DateTime.Parse("01-01-1950");
                    //var dt3 = DateTime.Parse("30-06-2023");
                    //int result1 = DateTime.Compare(dt1, dt2);
                    //int result2 = DateTime.Compare(dt1, dt3);
                    //if (result1 < 0)
                    //{
                    //    ViewState["SAVE"] = "NO";
                    //}
                    //else if (result2 > 0)
                    //{
                    //    ViewState["SAVE"] = "NO";
                    //}
                    ViewState["SAVE"] = "YES";
                }
                else
                {
                    ViewState["SAVE"] = "NO";
                }
            }
        }
        //protected void ValidateOBCDateFormat(string dated)
        //{
        //    ViewState["SAVE"] = "YES";
        //    if (dated == null)
        //    {
        //        ViewState["SAVE"] = "NO";
        //        return;
        //    }
        //    else
        //    {
        //        DateTime dtd;
        //        bool valid = DateTime.TryParseExact(dated, "dd/MM/yyyy", null, DateTimeStyles.None, out dtd);
        //        if (valid)
        //        {
        //            var dt1 = DateTime.Parse(dated);
        //            var dt2 = DateTime.Parse("01-07-2023");
        //            int result1 = DateTime.Compare(dt1, dt2);
        //            if (result1 < 0)
        //            {
        //                ViewState["SAVE"] = "NO";
        //            }
        //        }
        //        else
        //        {
        //            ViewState["SAVE"] = "NO";
        //        }
        //    }
        //}
        protected void txtCasteDate_TextChanged(object sender, EventArgs e)
        {
            txtDOB.Text = "";
            txtDOB2.Text = "";
            //ddlPwD.SelectedIndex = 0;
            ddlPwdType.SelectedIndex = 0;
            txtPHPer.Text = "";

            ValidateDateFormat(txtCasteDate.Text.Trim());
            if (ViewState["SAVE"].ToString() == "NO")
            {
                lblCasteIssDt.Text = "Invalid Date, Date format is DD/MM/YYYY";
                lblCasteIssDt.Visible = true;
            }
            else
            {
                lblCasteIssDt.Visible = false;
                dateValidation(txtCasteDate.Text.Trim());
                if (ViewState["SAVE"].ToString() == "NO")
                {
                    lblCasteIssDt.Text = "Date can not be greater than current date";
                    lblCasteIssDt.Visible = true;
                }
                else
                {
                    lblCasteIssDt.Visible = false;
                }
            }
        }
        protected void chkSame_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSame.Checked == true)
            {
                if (txtHNo.Text.Trim() != "")
                    txtHNo1.Text = txtHNo.Text.Trim();

                if (txtArea.Text.Trim() != "")
                    txtArea1.Text = txtArea.Text.Trim();

                if (txtLandmark.Text.Trim() != "")
                    txtLandmark1.Text = txtLandmark.Text.Trim();

                if (txtCity.Text.Trim() != "")
                    txtCity1.Text = txtCity.Text.Trim();

                if (txtDist.Text.Trim() != "")
                    txtDist1.Text = txtDist.Text.Trim();

                if (txtState.Text.Trim() != "")
                    txtState1.Text = txtState.Text.Trim();

                if (txtPin.Text.Trim() != "")
                    txtPin1.Text = txtPin.Text.Trim();

                if (txtPO.Text.Trim() != "")
                    txtPO1.Text = txtPO.Text.Trim();

                if (txtRail.Text.Trim() != "")
                    txtRail1.Text = txtRail.Text.Trim();

                EditableField(true);
            }
            else
            {
                txtHNo1.Text = "";
                txtArea1.Text = "";
                txtLandmark1.Text = "";
                txtCity1.Text = "";
                txtDist1.Text = "";
                txtState1.Text = "";
                txtPin1.Text = "";
                txtPO1.Text = "";
                txtRail1.Text = "";
                EditableField(false);
            }
        }
        protected void ddlPwD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDOB.Text = string.Empty;
            txtDOB2.Text = string.Empty;
            txtPHPer.Text = string.Empty;
            ddlPwdType.SelectedIndex = 0;
            txtPHPer.Text = "";
            lblPwdType.Visible = false;

            if (ddlPwD.SelectedItem.Text.ToString().ToUpper().Trim() == "YES")
            {
                divPwdType.Visible = true;
                divPwBD.Visible = true;
                //divPwdSub.Visible = true;
            }
            else if (ddlPwD.SelectedItem.Text.ToString().ToUpper().Trim() == "NO")
            {
                divPwdType.Visible = false;
                divPwBD.Visible = false;
                //divPwdSub.Visible = false;
            }

            //ddlPwdType.Items.Clear();
            //if (ddlPost.SelectedItem.Text == "Operator (Welding)")
            //{
            //    ddlPwdType.Items.Add("Select");
            //    ddlPwdType.Items.Add("HI");
            //}
            //else
            //{
            //    if (ddlPwD.Items.Count > 1)
            //    {
            //        ddlPwdType.Items.Add("Select");
            //        ddlPwdType.Items.Add("LD");
            //        ddlPwdType.Items.Add("VI");
            //        ddlPwdType.Items.Add("HI");
            //        ddlPwdType.Items.Add("MD");
            //    }
            //}
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtDOB.Text = string.Empty;
            //txtDOB2.Text = string.Empty;
            //castCert.Text = string.Empty;
            //txtCasteDate.Text = string.Empty;
            ClearScreenCategory();

            if ((ddlCategory.SelectedItem.Text.Trim().ToUpper() == "SELECT") || (ddlCategory.SelectedItem.Text.Trim().ToUpper() == "UR"))
            {
                divCaste.Visible = false;
                divCasteDt.Visible = false;
            }
            else
            {
                divCaste.Visible = true;
                divCasteDt.Visible = true;
            }
        }
        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDOB.Text.Trim() == "")
                {
                    txtDOB2.Text = "";
                    lblDOB1.Text = "Invalid Date format";
                    lblDOB1.Visible = true;
                    ViewState["SAVE"] = "NO";
                }
                else
                {
                    DateTime dtd;
                    bool valid = DateTime.TryParseExact(txtDOB.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out dtd);
                    if (valid)
                    {
                        var dt1 = DateTime.Parse(txtDOB.Text);
                        var dt2 = DateTime.Parse("01-01-1950");
                        var dt3 = DateTime.Parse("01-01-2024");
                        int result1 = DateTime.Compare(dt1, dt2);
                        int result2 = DateTime.Compare(dt1, dt3);
                        if (result1 < 0)
                        {
                            lblDOB1.Visible = true;
                            lblDOB1.Text = "Invalid DOB, Date format is DD/MM/YYYY";
                        }
                        else if (result2 > 0)
                        {
                            lblDOB1.Visible = true;
                            lblDOB1.Text = "Invalid DOB, Date format is DD/MM/YYYY";
                        }
                    }
                    else
                    {
                        lblDOB1.Visible = true;
                        lblDOB1.Text = "Invalid DOB, Date format is DD/MM/YYYY";
                    }
                    lblDOB1.Visible = false;
                    dobValidation();
                }
            }
            catch (Exception)
            {
                txtDOB2.Text = "";
                ViewState["SAVE"] = "NO";
            }
        }
        protected void dobValidation()
        {
            if (txtDOB.Text.Trim() == "")
            {
                lblDOB1.Text = "Invalid Date Of Birth!";
                lblDOB1.Visible = true;
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                try
                {
                    DateTime cuttoffDate = DateTime.Parse("01-01-2024");
                    DateTime candDateofBirth = DateTime.Parse(txtDOB.Text);
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
                    txtDOB2.Text = string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                        xYear, (xYear == 1) ? "" : "s",
                        xMon, (xMon == 1) ? "" : "s",
                        xDays, (xDays == 1) ? "" : "s");

                    int maxAge = 0;

                    //if (ddlPost.SelectedIndex > 0)
                    //{
                    //    string[] zPost = ddlPost.SelectedItem.Text.Trim().Split(' ');
                    //    if (zPost[0].Trim() == "Operator" || zPost[0].Trim() == "Technician")
                    //    {
                    //CALCULATE RELEVANT EXP.
                    //int xYY = Convert.ToInt32(ddlYears.SelectedItem.Text) >= 7 ? 7 : Convert.ToInt32(ddlYears.SelectedItem.Text);
                    //if (ddlApprentice.SelectedIndex == 1)
                    //{
                    //    if (xYY < 7)
                    //        maxAge = xYY + 1;
                    //    else
                    //        maxAge = xYY;
                    //}
                    //else
                    //{
                    //    maxAge = xYY;
                    //}


                    //if (ddlYears.SelectedIndex > 0)
                    //{
                    //    int xYY = Convert.ToInt32(ddlYears.SelectedItem.Text);
                    //    if (xYY > 0 && xYY <= 7)
                    //    {
                    //        maxAge = xYY;
                    //    }
                    //    else
                    //    {
                    //        maxAge = 7;
                    //    }
                    //}


                    //if (ddlApprentice.SelectedIndex == 1)                       //apprenticeship with hal,nashik then add period to maxage
                    //{
                    //    if (ddlDD.SelectedIndex > 0)
                    //    {
                    //        maxDay += Convert.ToInt32(ddlDD.SelectedItem.Text);
                    //    }
                    //    if (ddlMM.SelectedIndex > 0)
                    //    {
                    //        maxMon += Convert.ToInt32(ddlMM.SelectedItem.Text);
                    //    }
                    //    if (ddlYY.SelectedIndex > 0)
                    //    {
                    //        maxAge += Convert.ToInt32(ddlYY.SelectedItem.Text);
                    //    }
                    //}
                    //    }
                    //}

                    //if (ddlDomicile.SelectedIndex == 1)                                 //domicile of j&K between 01-01-1980 and 31-12-1989 - relaxation is 5 years
                    //{
                    //    //JKDomicilePeriod(txtDomDate.Text);
                    //    //if (ViewState["SAVE"].ToString() == "YES")
                    //    //{
                    //    //    maxAge += 5;
                    //    //}
                    //}

                    string xCategory = "", xPwdCategory = "";
                    if (ddlCategory.SelectedItem.Text.Trim().ToUpper() != "SELECT")
                    {
                        if (ddlPost.SelectedItem.Text.Trim().ToUpper() != "SELECT")
                        {
                            DataTable xDt = site.getdatatable("select * from POST_EDU_AGE where DISCIPLINE='" + ddlPost.SelectedItem.Text.Trim() + "'");
                            if (xDt.Rows.Count > 0)
                            {
                                xCategory = ddlCategory.SelectedItem.Text.Trim().ToUpper();
                                xPwdCategory = ddlCategory.SelectedItem.Text.Trim().ToUpper();
                                if (xCategory == "OBC(NCL)")
                                {
                                    xCategory = "AGE_OBC";
                                    xPwdCategory = "PWD_OBC";
                                }
                                else
                                {
                                    xCategory = "AGE_" + xCategory;
                                    xPwdCategory = "PWD_" + xPwdCategory;
                                }
                                //ValidateOBCDateFormat(txtCasteDate.Text.Trim());
                                //if (ViewState["SAVE"].ToString() == "YES")
                                //{
                                if (ddlPwD.SelectedItem.Text.Trim().ToUpper() == "YES")
                                {
                                    maxAge += Convert.ToInt32(xDt.Rows[0][xPwdCategory].ToString());
                                }
                                else
                                {
                                    maxAge += Convert.ToInt32(xDt.Rows[0][xCategory].ToString());
                                }
                                //}
                                //else
                                //{
                                //    maxAge += Convert.ToInt32(xDt.Rows[0][xCategory].ToString());
                                //}

                                //if (ddlPwD.SelectedItem.Text.Trim().ToUpper() == "YES")
                                //{
                                //    string[] zPost = ddlPost.SelectedItem.Text.Trim().Split(' ');
                                //    if (zPost[0].Trim() == "Operator" || zPost[0].Trim() == "Technician")
                                //    {
                                //        ValidateOBCDateFormat(txtCasteDate.Text.Trim());
                                //        if (ViewState["SAVE"].ToString() == "YES")
                                //        {
                                //            //if (ddlPwdType.SelectedItem.Text.Trim().ToUpper() == "HI")
                                //            //{
                                //            //    maxAge += Convert.ToInt32(xDt.Rows[0][xPwdCategory].ToString());
                                //            //}
                                //            //else
                                //            //{
                                //            //    maxAge += Convert.ToInt32(xDt.Rows[0][xCategory].ToString());
                                //            //}
                                //        }
                                //        else
                                //        {
                                //            //if (ddlPwdType.SelectedItem.Text.Trim().ToUpper() == "HI")
                                //            //{
                                //            //    maxAge += Convert.ToInt32(xDt.Rows[0][xPwdCategory].ToString());
                                //            //}
                                //            //else
                                //            //{
                                //            //    maxAge += Convert.ToInt32(xDt.Rows[0][xCategory].ToString());
                                //            //}
                                //        }
                                //    }
                                //    else
                                //    {
                                //        maxAge += Convert.ToInt32(xDt.Rows[0][xPwdCategory].ToString());
                                //    }
                                //}
                                //else
                                //{
                                //    maxAge += Convert.ToInt32(xDt.Rows[0][xCategory].ToString());
                                //}
                            }
                        }
                    }


                    //int xValid = 0, totMM = 0, totDD = 0;
                    //if (ddlExArmy.SelectedIndex == 1)                                               //maxage for ex-army
                    //{
                    //if (Convert.ToInt32(ddlMonths.SelectedItem.Text) > 6)                       // if service period is more than 6 months
                    //{
                    //    xValid = 1;
                    //}

                    //if (xValid == 0)
                    //{
                    //    if (Convert.ToInt32(ddlYears.SelectedItem.Text) > 0)                    // if service period is more than equals to 1 years
                    //    {
                    //        xValid = 1;
                    //    }
                    //}

                    //if (xValid == 1)
                    //{
                    //    maxAge = maxAge + (ddlYears.SelectedIndex > 0 ? ddlYears.SelectedIndex : 0) + 3;
                    //    totMM = ddlMonths.SelectedIndex > 0 ? Convert.ToInt32(ddlMonths.SelectedItem.Text) : 0;
                    //    totDD = ddlDays.SelectedIndex > 0 ? Convert.ToInt32(ddlDays.SelectedItem.Text) : 0;
                    //    if (xYear <= maxAge)
                    //    {
                    //        //maxAge = totYears;
                    //        maxMon += totMM;
                    //        maxDay += totDD;
                    //    }
                    //    else
                    //    {
                    //        maxAge = 18;
                    //        maxMon = 0;
                    //        maxDay = 0;
                    //    }
                    //}
                    //}

                    //lblDOB2.Visible=false;
                    //if (ddlPwD.SelectedItem.ToString().ToUpper() == "YES")
                    //{
                    //    if (xYear > 56)
                    //    {
                    //        txtDOB2.Text = txtDOB2.Text + ",  Not Eligible";
                    //        lblDOB2.Visible = true;
                    //        lblDOB2.Text = "Max age can not be more than 56 for PwD Applicant";
                    //        ViewState["SAVE"] = "NO";
                    //        return;
                    //    }
                    //    else if (xYear == 56)          // age=24
                    //    {
                    //        if ((xMon > 0) || (xDays > 0))
                    //        {
                    //            txtDOB2.Text = txtDOB2.Text + ",  Not Eligible";
                    //            lblDOB2.Visible = true;
                    //            lblDOB2.Text = "Max age can not be more than 56 for PwD Applicant";
                    //            ViewState["SAVE"] = "NO";
                    //            return;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    if (xYear > 55)
                    //    {
                    //        txtDOB2.Text = txtDOB2.Text + ",  Not Eligible";
                    //        lblDOB2.Visible = true;
                    //        lblDOB2.Text = "Max age can not be more than 55";
                    //        ViewState["SAVE"] = "NO";
                    //        return;
                    //    }
                    //    else if (xYear == 55)          // age=24
                    //    {
                    //        if ((xMon > 0) || (xDays > 0))
                    //        {
                    //            txtDOB2.Text = txtDOB2.Text + ",  Not Eligible";
                    //            lblDOB2.Text = "Max age can not be more than 55";
                    //            lblDOB2.Visible = true;
                    //            ViewState["SAVE"] = "NO";
                    //            return;
                    //        }
                    //    }
                    //}

                    //lblDOB2.Visible = false;
                    //int minAge = 18;
                    //if ((xYear < minAge) || (xYear > maxAge))          //age <18 or >24
                    //{
                    //    txtDOB2.Text = txtDOB2.Text + ",  Not Eligible";
                    //    lblDOB2.Text = "Not Eligible";
                    //    lblDOB2.Visible = true;
                    //    ViewState["SAVE"] = "NO";
                    //}
                    //else if (xYear == minAge)          //age=18 
                    //{
                    //    lblDOB2.Visible = false;
                    //    ViewState["SAVE"] = "YES";
                    //}
                    //else if (xYear == maxAge)          // age=24
                    //{
                    //    //if ((xMon > 0) || (xDays > 0))
                    //    //{
                    //    //    txtDOB2.Text = txtDOB2.Text + ",  Not Eligible";
                    //    //    lblDOB2.Text = "Not Eligible";
                    //    //    lblDOB2.Visible = true;
                    //    //    ViewState["SAVE"] = "NO";
                    //    //}
                    //    if ((xMon == 0) && (xDays == 0))
                    //    {
                    //        lblDOB2.Visible = false;
                    //        ViewState["SAVE"] = "YES";
                    //    }
                    //    else
                    //    {
                    //        int totDays1 = 0, totDays2 = 0;
                    //        totDays1 = (xMon * 30) + xDays;
                    //        totDays2 = (maxMon * 30) + maxDay;
                    //        if (totDays1 <= totDays2)
                    //        {
                    //            lblDOB2.Visible = false;
                    //            ViewState["SAVE"] = "YES";
                    //        }
                    //        else
                    //        {
                    //            txtDOB2.Text = txtDOB2.Text + ",  Not Eligible";
                    //            lblDOB2.Text = "Not Eligible";
                    //            lblDOB2.Visible = true;
                    //            ViewState["SAVE"] = "NO";
                    //        }
                    //    }
                    //}
                    //else if ((xYear > minAge) || (xYear < maxAge))          //age >18 or <24
                    //{
                    //    lblDOB2.Visible = false;
                    //    ViewState["SAVE"] = "YES";
                    //}
                    //else
                    //{
                    //    txtDOB2.Text = txtDOB2.Text + ", Not Eligible";
                    //    txtDOB.Text = "";
                    //    lblDOB2.Text = "Not Eligible";
                    //    lblDOB2.Visible = true;
                    //    ViewState["SAVE"] = "NO";
                    //}
                }
                catch (Exception ex)
                {
                    throw new Exception("Error:" + ex.Message);
                }
            }

        }
        protected void ddlPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPost.SelectedIndex > 0)
            {
                ClearScreenPost();
                validatePost(ddlPost.SelectedItem.Text);
            }
        }
        void validatePost(string xPost)
        {
            //if (xPost == "Security Guard"/* || xPost == "ESM Technician (Engine Fitter)" || xPost == "ESM Technician (Electrical Fitter)"*/)
            //{
            //    ////divExArmy.Visible = true;
            //    //divRelexp.Visible = false;
            //    ////divApprentice.Visible = false;
            //    //divESM.Visible = true;
            //    //if (xPost == "ESM Technician (Engine Fitter)")
            //    //{
            //    //    lblESM.Text = "Do you have Certificate in Engine Fitter Trade from Indian air Force";
            //    //    lblESM.Visible = true;
            //    //}
            //    //else if (xPost == "ESM Technician (Electrical Fitter)")
            //    //{
            //    //    lblESM.Text = "Do you have Certificate in Electrical Fitter Trade from Indian air Force";
            //    //    lblESM.Visible = true;
            //    //}
            //    //else
            //    //{
            //    lblESM.Text = "";
            //    divESM.Visible = false;
            //    ddlESM.SelectedIndex = 0;
            //    //}
            //}
            //else
            //{
            //    //divExArmy.Visible = false;
            //    divRelexp.Visible = true;
            //    ////divApprentice.Visible = true;
            //    //lblRelevantExp.Text = "Do you have Relevant Experience in " + xPost;
            //    //lblRelevantExp.Text += "*";
            //    ddlExArmy.SelectedIndex = 0;
            //    divESM.Visible = false;
            //    ddlESM.SelectedIndex = 0;
            //    lblESM.Visible = false;

            //}
            try
            {
                ddlPwdType.Items.Clear();
                string xf = "select PWD_TYPE,SEQ from POST_PWD WHERE POST_NAME='" + xPost + "' AND PWD_TYPE IS NOT NULL order by PWD_TYPE";
                DataTable dt1 = site.getdatatable(xf);
                if (xPost == "Security Guard")
                {
                    ddlPwD.SelectedIndex = 2;
                    ddlPwD.Attributes.Add("Disabled","True");
                    ddlPwdType.Visible = false;
                    txtPHPer.Visible = false;
                }
                else if (dt1.Rows.Count > 0)
                {
                    txtPHPer.Visible = true;
                    ddlPwdType.Visible = true;
                    ddlPwD.Attributes.Remove("Disabled");
                    ddlPwdType.DataSource = dt1;
                    ddlPwdType.DataTextField = "PWD_TYPE";
                    ddlPwdType.DataValueField = "PWD_TYPE";
                    ddlPwdType.DataBind();
                }
                ddlPwdType.Items.Insert(0, "Select");
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        private void ValidateAlphabetWithSpace(string xAlpha)
        {
            Regex regex = new Regex("^[A-Za-z ]+$");
            Match match = regex.Match(xAlpha);
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
        protected void ddlDomicile_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearScreenDomicile();
            txtDomDate.Text = "";
            if (ddlDomicile.SelectedIndex == 1)
            {
                divJKD.Visible = true;
            }
            else
            {
                divJKD.Visible = false;
            }
        }
        protected void ddlRelevantExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ClearScreenRelevantExp();

            //string[] zPost = ddlPost.SelectedItem.Text.Trim().Split(' ');
            //if (zPost[0].Trim() == "Operator" || zPost[0].Trim() == "Technician" || zPost[0].Trim() == "ESM")
            //{
            //    //divExArmy.Visible = false;
                divRank.Visible = false;
                divEnroll.Visible = false;
                divDis.Visible = false;
                if (ddlRelevantExp.SelectedIndex == 1)
                {
                    divYears.Visible = true;
                    divMonths.Visible = true;
                    divDays.Visible = true;
                    //divText.Visible = true;
                }
                else
                {
                    divYears.Visible = false;
                    divMonths.Visible = false;
                    divDays.Visible = false;
                    //divText.Visible = false;
                }
            //}
            //else
            //{
            //    //divExArmy.Visible = true;
            //    divRank.Visible = false;
            //    divEnroll.Visible = false;
            //    divDis.Visible = false;
            //}
        }
        protected void ddlApprentice_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearScreenApprentice();
        }
        void EditableField(bool xVal)
        {
            txtHNo1.ReadOnly = xVal;
            txtArea1.ReadOnly = xVal;
            txtLandmark1.ReadOnly = xVal;
            txtCity1.ReadOnly = xVal;
            txtDist1.ReadOnly = xVal;
            txtState1.ReadOnly = xVal;
            txtPin1.ReadOnly = xVal;
            txtPO1.ReadOnly = xVal;
            txtRail1.ReadOnly = xVal;
        }
        protected void JKDomicilePeriod(string dated)
        {
            ViewState["SAVE"] = "YES";
            if (dated == null)
            {
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                DateTime dtd;
                bool valid = DateTime.TryParseExact(dated, "dd/MM/yyyy", null, DateTimeStyles.None, out dtd);
                if (valid)
                {
                    var dt1 = DateTime.Parse(dated);
                    var dt2 = DateTime.Parse("01-01-1980");
                    var dt3 = DateTime.Parse("31-12-1989");
                    int result1 = DateTime.Compare(dt1, dt2);
                    int result2 = DateTime.Compare(dt1, dt3);
                    if (result1 < 0)
                    {
                        ViewState["SAVE"] = "NO";
                    }
                    else if (result2 > 0)
                    {
                        ViewState["SAVE"] = "NO";
                    }
                }
                else
                {
                    ViewState["SAVE"] = "NO";
                }
            }
        }
        void ClearScreenPost()
        {
            ddlCategory.SelectedIndex = 0;
            ddlDomState.SelectedIndex = 0;
            castCert.Text = string.Empty;
            divCaste.Visible = false;
            txtCasteDate.Text = string.Empty;
            divCasteDt.Visible = false;
            ddlRelevantExp.SelectedIndex = 0;
            divRelexp.Visible = false;
            DivAppr.Visible = false;
            ddlExArmy.SelectedIndex = 0;
            divJoinDate.Visible = false;
            divLeaveDate.Visible = false;
            //divExArmy.Visible = false;
            ddlYears.SelectedIndex = 0;
            divYears.Visible = false;
            ddlMonths.SelectedIndex = 0;
            divMonths.Visible = false;
            ddlDays.SelectedIndex = 0;
            divDays.Visible = false;
            //divExArmy.Visible = false;
            divRank.Visible = false;
            divEnroll.Visible = false;
            divDis.Visible = false;
            ddlDomicile.SelectedIndex = 0;
            divJKD.Visible = false;
            txtDomDate.Text = string.Empty;
            ddlApprentice.SelectedIndex = 0;
            //ddlPwD.SelectedIndex = 0;
            divPwdType.Visible = false;
            ddlPwdType.SelectedIndex = 0;
            divPwBD.Visible = false;
            //divPwdSub.Visible = false;
            //ddlPwdSub.SelectedIndex = 0;
            txtPHPer.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtDOB2.Text = string.Empty;
        }
        void ClearScreenCategory()
        {
            divCaste.Visible = false;
            castCert.Text = string.Empty;
            txtCasteDate.Text = string.Empty;
            divCasteDt.Visible = false;
            ddlRelevantExp.SelectedIndex = 0;
            ddlExArmy.SelectedIndex = 0;
            ddlYears.SelectedIndex = 0;
            divYears.Visible = false;
            ddlMonths.SelectedIndex = 0;
            divMonths.Visible = false;
            ddlDays.SelectedIndex = 0;
            ddlDomState.SelectedIndex = 0;
            ddlDomicile.SelectedIndex = 0;
            txtDomDate.Text = string.Empty;
            ddlApprentice.SelectedIndex = 0;
            //ddlPwD.SelectedIndex = 0;
            divPwdType.Visible = false;
            ddlPwdType.SelectedIndex = 0;
            divPwBD.Visible = false;
            //divPwdSub.Visible = false;  
            //ddlPwdSub.SelectedIndex= 0;
            txtPHPer.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtDOB2.Text = string.Empty;
            //divExArmy.Visible = false;
            divRank.Visible = false;
            divEnroll.Visible = false;
            divDis.Visible = false;
        }
        void ClearScreenRelevantExp()
        {
            ddlDomicile.SelectedIndex = 0;
            ddlRelevantExp.SelectedIndex = 0;
            divJKD.Visible = false;
            txtDomDate.Text = string.Empty;
            ddlApprentice.SelectedIndex = 0;
            //ddlPwD.SelectedIndex = 0;
            divPwdType.Visible = false;
            ddlPwdType.SelectedIndex = 0;
            divPwBD.Visible = false;
            //divPwdSub.Visible = false;
            //ddlPwdSub.SelectedIndex = 0;
            txtPHPer.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtDOB2.Text = string.Empty;
            divYears.Visible = false;
            divMonths.Visible= false;
            divDays.Visible = false;
            divJoinDate.Visible = false;
            divLeaveDate.Visible = false;
        }
        void ClearScreenExService()
        {
            ddlYears.SelectedIndex = 0;
            ddlMonths.SelectedIndex = 0;
            ddlDays.SelectedIndex = 0;
            ddlDomicile.SelectedIndex = 0;
            divJKD.Visible = true;
            txtDomDate.Text = string.Empty;
            ddlApprentice.SelectedIndex = 0;
            //ddlPwD.SelectedIndex = 0;
            divPwdType.Visible = false;
            ddlPwdType.SelectedIndex = 0;
            divPwBD.Visible = false;
            //divPwdSub.Visible = false;
            //ddlPwdSub.SelectedIndex = 0;
            txtPHPer.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtDOB2.Text = string.Empty;
        }
        void ClearScreenDomicile()
        {
            //ddlPwD.SelectedIndex = 0;
            divPwdType.Visible = false;
            ddlPwdType.SelectedIndex = 0;
            divPwBD.Visible = false;
            //divPwdSub.Visible = false;
            //ddlPwdSub.SelectedIndex = 0;
            txtPHPer.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtDOB2.Text = string.Empty;
        }
        void ClearScreenApprentice()
        {
            //ddlPwD.SelectedIndex = 0;
            divPwdType.Visible = false;
            ddlPwdType.SelectedIndex = 0;
            divPwBD.Visible = false;
            //divPwdSub.Visible = false;
            //ddlPwdSub.SelectedIndex = 0;
            txtPHPer.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtDOB2.Text = string.Empty;

            if (ddlApprentice.SelectedIndex == 1)
            {
                divJoinDate.Visible = true;
                divLeaveDate.Visible = true;
                lblApprentice.Visible = false;
            }
            else
            {
                divJoinDate.Visible = false;
                divLeaveDate.Visible = false;
                lblApprentice.Visible = false;
            }
        }
        protected void ddlYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearScreenxArmy();
        }
        protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearScreenxArmy();
        }
        protected void ddlDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearScreenxArmy();
        }
        void clearScreenxArmy()
        {
            ddlDomicile.SelectedIndex = 0;
            txtDomDate.Text = string.Empty;
            //ddlPwD.SelectedIndex = 0;
            divPwdType.Visible = false;
            ddlPwdType.SelectedIndex = 0;
            divPwBD.Visible = false;
            //divPwdSub.Visible = false;
            //ddlPwdSub.SelectedIndex = 0;
            txtPHPer.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtDOB2.Text = string.Empty;
        }
        protected void ddlReligion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReligion.SelectedItem.Text.ToUpper() == "OTHER")
            {
                divOther.Visible = true;
                txtOther.Text = string.Empty;
                txtOther.Focus();
            }
            else
            {
                divOther.Visible = false;
            }
        }
        protected void ddlPwdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPwdType.SelectedIndex > 0)
            {
                dt = site.getdatatable("select DESCS from PWD_TYPES where NAME='" + ddlPwdType.SelectedItem.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    lblPwdType.Text = dt.Rows[0]["DESCS"].ToString();
                    lblPwdType.Visible = false;
                    lblPwdType.ForeColor = Color.Blue;
                }
            }
        }
        protected void ddlExArmy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearScreenRelevantExp();
            if (ddlExArmy.SelectedIndex == 1)
            {
                divRank.Visible = true;
                divEnroll.Visible = true;
                divDis.Visible = true;
                txtRank.Focus();
                divRelexp.Visible = false;
                DivAppr.Visible = false;
            }
            else if (ddlExArmy.SelectedIndex == 2)
            {
                divRelexp.Visible = true;
                DivAppr.Visible = true;
                divRank.Visible = false;
                divEnroll.Visible = false;
                divDis.Visible = false;
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool IsValidMobileNumber(string mobile)
        {
            // Regex to check if the number starts with 6, 7, 8, or 9 and is exactly 10 digits long
            string pattern = "^[6-9]\\d{9}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(mobile);
        }

        protected void chkConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConfirm.Checked)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }
    }
}