using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http.Dispatcher;
using System.Web.UI.WebControls;

namespace RegistrationApp
{
    public partial class Education : System.Web.UI.Page
    {
        DataTable dt;
        siteclass site = new siteclass();
        string appNo = "";
        string today = DateTime.Now.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            int rex = site.getOfflineStatus("REGISTRATION_PROCESS_ONLINE");
            if (rex == 0)
            {
                Response.Redirect("Timesup.aspx", false);
                return;
            }


            if (Session["APPNO"] == null)
                Response.Redirect("SessionExpired");
            else
                appNo = Session["APPNO"].ToString();

            if (!IsPostBack)
            {
                if (appNo != null)
                {
                    ViewState["SAVE"] = "NO";
                    getRecords(appNo);
                    //getRecordEXps();
                }
            }
        }
        void ValidateFields()
        {
            if (CheckBox1.Checked == false)
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

            if (txtEdu10.Text.Trim() == "")
            {
                lblEdu10.Visible = true;
                txtEdu10.Focus();
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                string xStat = site.ValidateTextWithourSpecialChars(txtEdu10.Text.Trim());
                if (xStat == "YES")
                {
                    ViewState["SAVE"] = "YES";
                    lblEdu10.Visible = false;
                }
                else
                {
                    lblEdu10.Text = "Only Alphabets are allowed";
                    lblEdu10.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
            }

            if (ddlNature10.SelectedIndex == 0)
            {
                lblNature10.Visible = true;
                ddlNature10.Focus();
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                ViewState["SAVE"] = "YES";
                lblNature10.Visible = false;
            }

            if (txtDuration10.Text.Trim() == "")
            {
                lblDuraion10.Visible = true;
                txtDuration10.Focus();
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                string xStat = site.ValidateTextWithourSpecialChars(txtDuration10.Text.Trim());
                if (xStat == "YES")
                {
                    ViewState["SAVE"] = "YES";
                    lblDuraion10.Visible = false;
                }
                else
                {
                    lblDuraion10.Text = "Only Alphabets are allowed";
                    lblDuraion10.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
            }

            if (txtSub10.Text.Trim() == "")
            {
                lblSub10.Visible = true;
                txtSub10.Focus();
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                //string xStat = site.ValidateTextWithourSpecialChars(txtSub10.Text.Trim());
                //if (xStat == "YES")
                //{
                ViewState["SAVE"] = "YES";
                lblSub10.Visible = false;
                //}
                //else
                //{
                //    lblSub10.Text = "Only Alphabets are allowed";
                //    lblSub10.Visible = true;
                //    ViewState["SAVE"] = "NO";
                //    return;
                //}
            }

            //if (txtDiv10.Text.Trim() == "")
            //{
            //    lblDiv10.Visible = true;
            //    ViewState["SAVE"] = "NO";
            //    return;
            //}
            //else
            //{
            //    string xStat = site.ValidateTextWithourSpecialChars(txtDiv10.Text.Trim());
            //    if (xStat == "YES")
            //    {
            //        ViewState["SAVE"] = "YES";
            //        lblDiv10.Visible = false;
            //    }
            //    else
            //    {
            //        lblDiv10.Text = "Only Alphabets are allowed";
            //        lblDiv10.Visible = true;
            //        ViewState["SAVE"] = "NO";
            //        return;
            //    }
            //}

            if (txtPercent10.Text.Trim() == "")
            {
                lblPercent10.Visible = true;
                txtPercent10.Focus();
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                if (Convert.ToDecimal(txtPercent10.Text.Trim()) > 33)
                {
                    ViewState["SAVE"] = "YES";
                    lblPercent10.Visible = false;
                }
                else
                {
                    lblPercent10.Text = "Min. 33% of marks required";
                    lblPercent10.Visible = true;
                    ViewState["SAVE"] = "NO";
                    return;
                }
            }

            if (txtPassDate10.Text.Trim().ToUpper() == "")
            {
                lblYear10.Visible = true;
                txtPassDate10.Focus();
                ViewState["SAVE"] = "NO";
                return;
            }
            else
            {
                //ViewState["SAVE"] = "YES";
                //lblYear10.Visible = false;
                if (!checkDate(today.Trim(), txtPassDate10.Text.Trim(), out bool wrong))
                {
                    ViewState["SAVE"] = "NO";
                    lblYear10.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                    lblYear10.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblYear10.Visible = false;
                }
            }

            //====== 12th education
            if (txtEdu12.Text.Trim() != "")
            {
                if (txtEdu12.Text.Trim() == "")
                {
                    lblEdu12.Visible = true;
                    txtEdu12.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    string xStat = site.ValidateTextWithourSpecialChars(txtEdu12.Text.Trim());
                    if (xStat == "YES")
                    {
                        ViewState["SAVE"] = "YES";
                        lblEdu12.Visible = false;
                    }
                    else
                    {
                        lblEdu12.Text = "Only Alphabets are allowed";
                        lblEdu12.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }

                }

                if (ddlNature12.SelectedIndex == 0)
                {
                    lblNature12.Visible = true;
                    ddlNature10.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblNature12.Visible = false;
                }

                if (txtDuration12.Text.Trim() == "")
                {
                    lblDuration12.Visible = true;
                    txtDuration12.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    string xStat = site.ValidateTextWithourSpecialChars(txtDuration12.Text.Trim());
                    if (xStat == "YES")
                    {
                        ViewState["SAVE"] = "YES";
                        lblDuration12.Visible = false;
                    }
                    else
                    {
                        lblDuration12.Text = "Only Alphabets are allowed";
                        lblDuration12.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                }

                if (txtSub12.Text.Trim() == "")
                {
                    lblSub12.Visible = true;
                    txtSub12.Focus();   
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    //string xStat = site.ValidateTextWithourSpecialChars(txtSub12.Text.Trim());
                    //if (xStat == "YES")
                    //{
                    ViewState["SAVE"] = "YES";
                    lblSub12.Visible = false;
                    //}
                    //else
                    //{
                    //    lblSub12.Text = "Only Alphabets are allowed";
                    //    lblSub12.Visible = true;
                    //    ViewState["SAVE"] = "NO";
                    //    return;
                    //}
                }

                //if (txtDiv12.Text.Trim() == "")
                //{
                //    lblDiv12.Visible = true;
                //    ViewState["SAVE"] = "NO";
                //    return;
                //}
                //else
                //{
                //    string xStat = site.ValidateTextWithourSpecialChars(txtDiv12.Text.Trim());
                //    if (xStat == "YES")
                //    {
                //        ViewState["SAVE"] = "YES";
                //        lblDiv12.Visible = false;
                //    }
                //    else
                //    {
                //        lblDiv12.Text = "Only Alphabets are allowed";
                //        lblDiv12.Visible = true;
                //        ViewState["SAVE"] = "NO";
                //        return;
                //    }
                //}
                if (txtPercent12.Text.Trim() == "")
                {
                    lblPercent12.Visible = true;
                    txtPercent12.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    if (Convert.ToDecimal(txtPercent12.Text.Trim()) > 33)
                    {
                        ViewState["SAVE"] = "YES";
                        lblPercent12.Visible = false;
                    }
                    else
                    {
                        lblPercent12.Text = "Min. 33% of marks required";
                        lblPercent12.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                }

                if (txtPassDate12.Text.Trim().ToUpper() == "")
                {
                    lblYear12.Visible = true;
                    txtPassDate12.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    //ViewState["SAVE"] = "YES";
                    //lblYear12.Visible = false;
                    if (!checkDate(today.Trim(), txtPassDate12.Text.Trim(), out bool wrong))
                    {
                        ViewState["SAVE"] = "NO";
                        lblYear12.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                        lblYear12.Visible = true;
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblYear12.Visible = false;
                    }
                }

            }
            else if (divRank.Visible)
            {
                if (txtEdu12.Text == "" || txtRank.Text != "")
                {
                    if (txtRank.Text == "")
                    {
                        lblRank.Visible = true;
                        txtRank.Focus();
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        lblRank.Visible = false;
                        ViewState["SAVE"] = "YES";
                    }

                    if (txtFrom.Text == "")
                    {
                        lblFrom.Visible = true;
                        txtFrom.Focus();
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        if (!checkDate(today.Trim(), txtFrom.Text.Trim(), out bool wrong))
                        {
                            ViewState["SAVE"] = "NO";
                            lblFrom.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                            lblFrom.Visible = true;
                            return;
                        }
                        else
                        {
                            ViewState["SAVE"] = "YES";
                            lblFrom.Visible = false;
                        }
                    }

                    if (txtUpto.Text == "")
                    {
                        lblUpto.Visible = true;
                        txtUpto.Focus();
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        if (!checkDate(today.Trim(), txtUpto.Text.Trim(), out bool wrong))
                        {
                            ViewState["SAVE"] = "NO";
                            lblUpto.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                            lblUpto.Visible = true;
                            return;
                        }
                        else
                        {
                            ViewState["SAVE"] = "YES";
                            lblUpto.Visible = false;
                        }
                    }
                }
            }

            if (divITI.Visible)
            {
                if (!string.IsNullOrEmpty(txtITI.Text.Trim()))
                {
                    if (txtITI.Text.Trim() == "")
                    {
                        lblITI.Visible = true;
                        txtITI.Focus();
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        string xStat = site.ValidateTextWithourSpecialChars(txtITI.Text.Trim());
                        if (xStat == "YES")
                        {
                            ViewState["SAVE"] = "YES";
                            lblITI.Visible = false;
                        }
                        else
                        {
                            lblITI.Text = "Only Alphabets are allowed";
                            lblITI.Visible = true;
                            ViewState["SAVE"] = "NO";
                            return;
                        }
                    }

                    if (ddlNatureITI.SelectedIndex == 0)
                    {
                        lblNatureITI.Visible = true;
                        ddlNatureITI.Focus();
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblNatureITI.Visible = false;
                    }

                    if (txtDurationITI.Text.Trim() == "")
                    {
                        lblDurationITI.Visible = true;
                        txtDurationITI.Focus();
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        string xStat = site.ValidateTextWithourSpecialChars(txtDurationITI.Text.Trim());
                        if (xStat == "YES")
                        {
                            ViewState["SAVE"] = "YES";
                            lblDurationITI.Visible = false;
                        }
                        else
                        {
                            lblDurationITI.Text = "Only Alphabets are allowed";
                            lblDurationITI.Visible = true;
                            ViewState["SAVE"] = "NO";
                            return;
                        }
                    }

                    if (txtSubITI.Text.Trim() == "")
                    {
                        lblSubITI.Visible = true;
                        txtSubITI.Focus();
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        //string xStat = site.ValidateTextWithourSpecialChars(txtSubITI.Text.Trim());
                        //if (xStat == "YES")
                        //{
                        ViewState["SAVE"] = "YES";
                        lblSubITI.Visible = false;
                        //}
                        //else
                        //{
                        //    lblSubITI.Text = "Only Alphabets are allowed";
                        //    lblSubITI.Visible = true;
                        //    ViewState["SAVE"] = "NO";
                        //    return;
                        //}
                    }

                    //if (txtDivITI.Text.Trim() == "")
                    //{
                    //    lblDivITI.Visible = true;
                    //    ViewState["SAVE"] = "NO";
                    //    return;
                    //}
                    //else
                    //{
                    //    string xStat = site.ValidateTextWithourSpecialChars(txtDivITI.Text.Trim());
                    //    if (xStat == "YES")
                    //    {
                    //        ViewState["SAVE"] = "YES";
                    //        lblDivITI.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        lblDivITI.Text = "Only Alphabets are allowed";
                    //        lblDivITI.Visible = true;
                    //        ViewState["SAVE"] = "NO";
                    //        return;
                    //    }
                    //}

                    if (txtITIDate.Text.Trim().ToUpper() == "")
                    {
                        lblITIDate.Visible = true;
                        txtITIDate.Focus();
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblITIDate.Visible = false;
                    }

                    if (txtITIPercent.Text.Trim() == "")
                    {
                        lblITIPercent.Visible = true;
                        txtITIPercent.Focus();
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblITIPercent.Visible = false;
                    }
                }
            }

            if (divDiploma.Visible)
            {
                if (txtDip.Text.Trim() == "")
                {
                    lblDip.Visible = true;
                    txtDip.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblDip.Visible = false;
                }

                if (ddlNatureDip.SelectedIndex == 0)
                {
                    lblNatureDip.Visible = true;
                    ddlNatureDip.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblNatureDip.Visible = false;
                }

                if (txtDurationDip.Text.Trim() == "")
                {
                    lblDurationDip.Visible = true;
                    txtDurationDip.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    string xStat = site.ValidateTextWithourSpecialChars(txtDurationDip.Text.Trim());
                    if (xStat == "YES")
                    {
                        ViewState["SAVE"] = "YES";
                        lblDurationDip.Visible = false;
                    }
                    else
                    {
                        lblDurationDip.Text = "Only Alphabets are allowed";
                        lblDurationDip.Visible = true;
                        ViewState["SAVE"] = "NO";
                        return;
                    }
                }

                if (txtSubDip.Text.Trim() == "")
                {
                    lblSubDip.Visible = true;
                    txtSubDip.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    //string xStat = site.ValidateTextWithourSpecialChars(txtSubDip.Text.Trim());
                    //if (xStat == "YES")
                    //{
                    ViewState["SAVE"] = "YES";
                    lblSubDip.Visible = false;
                    //}
                    //else
                    //{
                    //    lblSubDip.Text = "Only Alphabets are allowed";
                    //    lblSubDip.Visible = true;
                    //    ViewState["SAVE"] = "NO";
                    //    return;
                    //}
                }

                //if (txtDivDip.Text.Trim() == "")
                //{
                //    lblDivDip.Visible = true;
                //    ViewState["SAVE"] = "NO";
                //    return;
                //}
                //else
                //{
                //    string xStat = site.ValidateTextWithourSpecialChars(txtDivDip.Text.Trim());
                //    if (xStat == "YES")
                //    {
                //        ViewState["SAVE"] = "YES";
                //        lblDivDip.Visible = false;
                //    }
                //    else
                //    {
                //        lblDivDip.Text = "Only Alphabets are allowed";
                //        lblDivDip.Visible = true;
                //        ViewState["SAVE"] = "NO";
                //        return;
                //    }
                //}

                if (txtDipPer.Text.Trim() == "")
                {
                    lblDipPer.Visible = true;
                    txtDipPer.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    string xCategory = "", xPost = "", xPwd = "";
                    try
                    {
                        dt = site.getdatatable("select CATEGORY_APPLIED,APPLIED_DISCIPLINE,PWD_APPLIED from APPLICANT where USERID='" + appNo + "'");
                        if (dt.Rows.Count > 0)
                        {
                            xCategory = dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim();
                            xPost = dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim();
                            xPwd = dt.Rows[0]["PWD_APPLIED"].ToString().Trim();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Fetch Error:" + ex.Message);
                    }


                    if (xPost != "")
                    {
                        double xPer = Convert.ToDouble(txtDipPer.Text);
                        {
                            if (xPwd == "Yes")
                            {
                                if (xPer < 50)
                                {
                                    lblDipPer.Visible = true;
                                    lblDipPer.Text = "Minimum 50% or above required";
                                    ViewState["SAVE"] = "NO";
                                    return;
                                }
                                else
                                {
                                    ViewState["SAVE"] = "YES";
                                    lblDipPer.Visible = false;
                                }
                            }
                            else
                            {
                                if (xCategory == "UR" || xCategory == "OBC(NCL)" || xCategory == "EWS")
                                {
                                    if (xPer < 60)
                                    {
                                        lblDipPer.Visible = true;
                                        lblDipPer.Text = "Minimum 60% or above required";
                                        ViewState["SAVE"] = "NO";
                                        return;
                                    }
                                    else
                                    {
                                        ViewState["SAVE"] = "YES";
                                        lblDipPer.Visible = false;
                                    }
                                }
                                else if (xCategory == "SC" || xCategory == "ST")
                                {
                                    if (xPer < 50)
                                    {
                                        lblDipPer.Visible = true;
                                        lblDipPer.Text = "Minimum 50% or above required";
                                        ViewState["SAVE"] = "NO";
                                        return;
                                    }
                                    else
                                    {
                                        ViewState["SAVE"] = "YES";
                                        lblDipPer.Visible = false;
                                    }
                                }

                            }
                        }
                    }
                }

                if (txtDipDate.Text.Trim().ToUpper() == "")
                {
                    lblDipDate.Visible = true;
                    txtDipDate.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    if (!checkDate(today.Trim(), txtDipDate.Text.Trim(), out bool wrong))
                    {
                        ViewState["SAVE"] = "NO";
                        lblDipDate.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                        lblDipDate.Visible = true;
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblDipDate.Visible = false;
                    }
                }
            }

            if (divNAC.Visible)
            {
                if (txtNacUniv.Text == "")
                {
                    lblNac.Visible = true;
                    txtNacUniv.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblNac.Visible = false;
                }

                if (txtNacDate.Text.Trim() == "")
                {
                    lblNacDate.Visible = true;
                    txtNacDate.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblNacDate.Visible = false;
                }

                if (txtNacPer.Text.Trim() == "")
                {
                    lblNacPer.Visible = true;
                    txtNacPer.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    string xCategory = "", xPost = "", xPwd = "";
                    try
                    {
                        dt = site.getdatatable("select CATEGORY_APPLIED,APPLIED_DISCIPLINE,PWD_APPLIED from APPLICANT where USERID='" + appNo + "'");
                        if (dt.Rows.Count > 0)
                        {
                            xCategory = dt.Rows[0]["CATEGORY_APPLIED"].ToString().Trim();
                            xPost = dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim();
                            xPwd = dt.Rows[0]["PWD_APPLIED"].ToString().Trim();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Fetch Error:" + ex.Message);
                    }


                    if (xPost != "")
                    {
                        double xPer = Convert.ToDouble(txtNacPer.Text);
                        if (xPost != "Security Guard")
                        {
                            if (xPwd == "Yes")
                            {
                                if (xPer < 50)
                                {
                                    lblNacPer.Visible = true;
                                    lblNacPer.Text = "Minimum 50% or above required";
                                    ViewState["SAVE"] = "NO";
                                    return;
                                }
                                else
                                {
                                    ViewState["SAVE"] = "YES";
                                    lblNacPer.Visible = false;
                                }
                            }
                            else
                            {
                                if (xCategory == "UR" || xCategory == "OBC(NCL)" || xCategory == "EWS")
                                {
                                    if (xPer < 60)
                                    {
                                        lblNacPer.Visible = true;
                                        lblNacPer.Text = "Minimum 60% or above required";
                                        ViewState["SAVE"] = "NO";
                                        return;
                                    }
                                    else
                                    {
                                        ViewState["SAVE"] = "YES";
                                        lblNacPer.Visible = false;
                                    }
                                }
                                else if (xCategory == "SC" || xCategory == "ST")
                                {
                                    if (xPer < 50)
                                    {
                                        lblNacPer.Visible = true;
                                        lblNacPer.Text = "Minimum 50% or above required";
                                        ViewState["SAVE"] = "NO";
                                        return;
                                    }
                                    else
                                    {
                                        ViewState["SAVE"] = "YES";
                                        lblNacPer.Visible = false;
                                    }
                                }

                            }
                        }
                    }
                }
            }

            if (divESM.Visible)
            {
                if (txtESMCert.Text == "")
                {
                    lblESM2.Visible = true;
                    txtESMCert.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblESM2.Visible = false;
                }

                if (txtESMDate.Text.Trim() == "")
                {
                    lblESMDate.Visible = true;
                    txtESMDate.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    //ViewState["SAVE"] = "YES";
                    //lblESMDate.Visible = false;
                    if (!checkDate(today.Trim(), txtESMDate.Text.Trim(), out bool wrong))
                    {
                        ViewState["SAVE"] = "NO";
                        lblESMDate.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                        lblESMDate.Visible = true;
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblESMDate.Visible = false;
                    }
                }
            }
            //Experience 

            if (txtOrg1.Text.Trim() == "")
            {
                ViewState["SAVE"] = "NO";
                txtOrg1.Focus();
                lblOrg.Visible = true;
                return;
            }
            else
            {
                ViewState["SAVE"] = "YES";
                lblOrg.Visible = false;
            }

            if (txtPosition1.Text.Trim() == "")
            {
                ViewState["SAVE"] = "NO";
                txtPosition1.Focus();
                lblPosition.Visible = true;
                return;
            }
            else
            {
                ViewState["SAVE"] = "YES";
                lblPosition.Visible = false;
            }

            if (txtPay1.Text.Trim() == "")
            {
                ViewState["SAVE"] = "NO";
                txtPay1.Focus();
                lblPay.Visible = true;
                return;
            }
            else
            {
                ViewState["SAVE"] = "YES";
                lblPay.Visible = false;
            }

            if (txtBegin1.Text.Trim() == "")
            {
                ViewState["SAVE"] = "NO";
                txtBegin1.Focus();
                lblBegin.Visible = true;
                return;
            }
            else
            {
                if (!checkDate(today.Trim(), txtBegin1.Text.Trim(), out bool wrong))
                {
                    ViewState["SAVE"] = "NO";
                    lblBegin.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                    lblBegin.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblBegin.Visible = false;
                }
            }

            if (txtEnd1.Text.Trim() == "")
            {
                ViewState["SAVE"] = "NO";
                txtEnd1.Focus();
                lblEnd.Visible = true;
                return;
            }
            else
            {
                if (!checkDate(today.Trim(), txtEnd1.Text.Trim(), out bool wrong))
                {
                    ViewState["SAVE"] = "NO";
                    lblEnd.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                    lblEnd.Visible = true;
                    return;
                }
                else if (!checkDate(txtEnd1.Text.Trim(), txtBegin1.Text.Trim()))
                {
                    ViewState["SAVE"] = "NO";
                    lblEnd.Text = "Joining Date cannot be later than Leaving Date";
                    lblEnd.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblEnd.Visible = false;
                }
            }

            if (ValidateAppDateOverlap(txtBegin1.Text.Trim(), txtEnd1.Text.Trim()))
            {
                ViewState["SAVE"] = "YES";
            }
            else
            {
                ViewState["SAVE"] = "NO";
                return;
            }
            if (txtDescs1.Text.Trim() == "")
            {
                ViewState["SAVE"] = "NO";
                txtDescs1.Focus();
                lblDescs.Visible = true;
                return;
            }
            else
            {
                ViewState["SAVE"] = "YES";
                lblDescs.Visible = false;
            }


            if (txtOrg2.Text.Trim() != "")
            {
                if (txtOrg2.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtOrg2.Focus();
                    lblOrg.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblOrg.Visible = false;
                }

                if (txtPosition2.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtPosition2.Focus();
                    lblPosition.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblPosition.Visible = false;
                }

                if (txtPay2.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtPay2.Focus();
                    lblPay.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblPay.Visible = false;
                }

                if (txtBegin2.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtBegin2.Focus();
                    lblBegin.Text = "Joining Date Required";
                    lblBegin.Visible = true;
                    return;
                }
                else
                {
                    if (!checkDate(today.Trim(), txtBegin2.Text.Trim(), out bool wrong))
                    {
                        ViewState["SAVE"] = "NO";
                        lblBegin.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                        lblBegin.Visible = true;
                        return;
                    }
                    if (checkDate(txtBegin2.Text.Trim(), txtEnd1.Text.Trim()))
                    {
                        ViewState["SAVE"] = "YES";
                        lblBegin.Visible = false;
                    }
                    else
                    {
                        ViewState["SAVE"] = "NO";
                        lblBegin.Text = "Joining Date of Exp2 is earlier than Leaving Date of Exp1";
                        lblBegin.Visible = true;
                        return;
                    }
                }

                if (txtEnd2.Text.Trim() == "")
                {
                    lblEnd.Text = "Leaving Date Required";
                    ViewState["SAVE"] = "NO";
                    txtEnd2.Focus();
                    lblEnd.Visible = true;
                    return;
                }
                else
                {
                    if (!checkDate(today.Trim(), txtEnd2.Text.Trim(), out bool wrong))
                    {
                        ViewState["SAVE"] = "NO";
                        lblEnd.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                        lblEnd.Visible = true;
                        return;
                    }
                    else if (!checkDate(txtEnd2.Text.Trim(), txtBegin2.Text.Trim()))
                    {
                        ViewState["SAVE"] = "NO";
                        lblEnd.Text = "Joining Date cannot be later than Leaving Date";
                        lblEnd.Visible = true;
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblEnd.Visible = false;
                    }
                }

                if (ValidateAppDateOverlap(txtBegin2.Text.Trim(), txtEnd2.Text.Trim()))
                {
                    ViewState["SAVE"] = "YES";
                }
                else
                {
                    ViewState["SAVE"] = "NO";
                    return;
                }

                if (txtDesc2.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtDesc2.Focus();
                    lblDescs.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblDescs.Visible = false;
                }
            }

            if (txtOrg3.Text.Trim() != "")
            {
                if (txtOrg3.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtOrg3.Focus();
                    lblOrg.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblOrg.Visible = false;
                }

                if (txtPosition3.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtPosition3.Focus();
                    lblPosition.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblPosition.Visible = false;
                }

                if (txtPay3.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtPay3.Focus();
                    lblPay.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblPay.Visible = false;
                }

                if (txtBegin3.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtBegin3.Focus();
                    lblBegin.Text = "Joining Date Required";
                    lblBegin.Visible = true;
                    return;
                }
                else
                {
                    if (!checkDate(today.Trim(), txtBegin3.Text.Trim(), out bool wrong))
                    {
                        ViewState["SAVE"] = "NO";
                        lblBegin.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                        lblBegin.Visible = true;
                        return;
                    }
                    if (checkDate(txtBegin3.Text.Trim(), txtEnd2.Text.Trim()))
                    {
                        ViewState["SAVE"] = "YES";
                        lblBegin.Visible = false;
                    }
                    else
                    {
                        ViewState["SAVE"] = "NO";
                        lblBegin.Text = "Joining Date of Exp3 is earlier than Leaving Date of Exp2";
                        lblBegin.Visible = true;
                        return;
                    }
                }

                if (txtEnd3.Text.Trim() == "")
                {
                    lblEnd.Text = "Leaving Date Required";
                    lblEnd.Visible = true;
                    ViewState["SAVE"] = "NO";
                    lblEnd.Visible = true;
                    return;
                }
                else
                {
                    if (!checkDate(today.Trim(), txtEnd3.Text.Trim(), out bool wrong))
                    {
                        ViewState["SAVE"] = "NO";
                        lblEnd.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                        lblEnd.Visible = true;
                        return;
                    }
                    else if (!checkDate(txtEnd3.Text.Trim(), txtBegin3.Text.Trim()))
                    {
                        ViewState["SAVE"] = "NO";
                        lblEnd.Text = "Joining Date cannot be later than Leaving Date";
                        lblEnd.Visible = true;
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblEnd.Visible = false;
                    }
                }

                if (ValidateAppDateOverlap(txtBegin3.Text.Trim(), txtEnd3.Text.Trim()))
                {
                    ViewState["SAVE"] = "YES";
                }
                else
                {
                    ViewState["SAVE"] = "NO";
                    return;
                }

                if (txtDesc3.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtDesc3.Focus();
                    lblDescs.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblDescs.Visible = false;
                }
            }

            if (txtOrg4.Text.Trim() != "")
            {
                if (txtOrg4.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtOrg4.Focus();
                    lblOrg.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblOrg.Visible = false;
                }

                if (txtPosition4.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtPosition4.Focus();
                    lblPosition.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblPosition.Visible = false;
                }

                if (txtPay4.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtPay4.Focus();
                    lblPay.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblPay.Visible = false;
                }

                if (txtBegin4.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtBegin4.Focus();
                    lblBegin.Text = "Joining Date Required";
                    lblBegin.Visible = true;
                    return;
                }
                else
                {
                    if (!checkDate(today.Trim(), txtBegin4.Text.Trim(), out bool wrong))
                    {
                        ViewState["SAVE"] = "NO";
                        lblBegin.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                        lblBegin.Visible = true;
                        return;
                    }
                    if (checkDate(txtBegin4.Text.Trim(), txtEnd3.Text.Trim()))
                    {
                        ViewState["SAVE"] = "YES";
                        lblBegin.Visible = false;
                    }
                    else
                    {
                        ViewState["SAVE"] = "NO";
                        lblBegin.Text = "Joining Date of Exp4 is earlier than Leaving Date of Exp3";
                        lblBegin.Visible = true;
                        return;
                    }
                }

                if (txtEnd4.Text.Trim() == "")
                {
                    lblEnd.Text = "Leaving Date Required";
                    txtEnd4.Focus();
                    ViewState["SAVE"] = "NO";
                    lblEnd.Visible = true;
                    return;
                }
                else
                {
                    if (!checkDate(today.Trim(), txtEnd4.Text.Trim(), out bool wrong))
                    {
                        ViewState["SAVE"] = "NO";
                        lblEnd.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                        lblEnd.Visible = true;
                        return;
                    }
                    else if (!checkDate(txtEnd4.Text.Trim(), txtBegin4.Text.Trim()))
                    {
                        ViewState["SAVE"] = "NO";
                        lblEnd.Text = "Joining Date cannot be later than Leaving Date";
                        lblEnd.Visible = true;
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblEnd.Visible = false;
                    }
                }

                if (ValidateAppDateOverlap(txtBegin4.Text.Trim(), txtEnd4.Text.Trim()))
                {
                    ViewState["SAVE"] = "YES";
                }
                else
                {
                    ViewState["SAVE"] = "NO";
                    return;
                }

                if (txtDesc4.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtDesc4.Focus();
                    lblDescs.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblDescs.Visible = false;
                }
            }

            if (txtOrg5.Text.Trim() != "")
            {
                if (txtOrg5.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtOrg5.Focus();
                    lblOrg.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblOrg.Visible = false;
                }
                if (txtPosition5.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtPosition5.Focus();
                    lblPosition.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblPosition.Visible = false;
                }

                if (txtPay5.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtPay5.Focus();
                    lblPay.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblPay.Visible = false;
                }

                if (txtBegin5.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtBegin5.Focus();
                    lblBegin.Text = "Joining Date Required";
                    lblBegin.Visible = true;
                    return;
                }
                else
                {
                    if (!checkDate(today.Trim(), txtBegin5.Text.Trim(), out bool wrong))
                    {
                        ViewState["SAVE"] = "NO";
                        lblBegin.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                        lblBegin.Visible = true;
                        return;
                    }
                    if (checkDate(txtBegin5.Text.Trim(), txtEnd4.Text.Trim()))
                    {
                        ViewState["SAVE"] = "YES";
                        lblBegin.Visible = false;
                    }
                    else
                    {
                        ViewState["SAVE"] = "NO";
                        lblBegin.Text = "Joining Date of Exp5 is earlier than Leaving Date of Exp4";
                        lblBegin.Visible = true;
                        return;
                    }
                }

                if (txtEnd5.Text.Trim() == "")
                {
                    lblEnd.Text = "Leaving Date Required";
                    txtEnd5.Focus();
                     ViewState["SAVE"] = "NO";
                    lblEnd.Visible = true;
                    return;
                }
                else
                {
                    if (!checkDate(today.Trim(), txtEnd5.Text.Trim(), out bool wrong))
                    {
                        ViewState["SAVE"] = "NO";
                        lblEnd.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                        lblEnd.Visible = true;
                        return;
                    }
                    else if (!checkDate(txtEnd5.Text.Trim(), txtBegin5.Text.Trim()))
                    {
                        ViewState["SAVE"] = "NO";
                        lblEnd.Text = "Joining Date cannot be later than Leaving Date";
                        lblEnd.Visible = true;
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblEnd.Visible = false;
                    }
                }

                if (ValidateAppDateOverlap(txtBegin5.Text.Trim(), txtEnd5.Text.Trim()))
                {
                    ViewState["SAVE"] = "YES";
                }
                else
                {
                    ViewState["SAVE"] = "NO";
                    return;
                }

                if (txtDesc5.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtDesc5.Focus();
                    lblDescs.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblDescs.Visible = false;
                }
            }

            dt = site.getdatatable("SELECT * FROM APPLICANT WHERE USERID='" + appNo + "'");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["RELEVANT_EXP"].ToString().ToUpper() == "YES" || dt.Rows[0]["EX_SERVICE_MAN"].ToString().ToUpper() == "YES")
                {
                    if (txtOrg1.Text.Trim() == "")
                    {
                        ViewState["SAVE"] = "NO";
                        lblOrg.Visible = true;
                        return;
                    }
                    else
                    {
                        if (dt.Rows[0]["EX_SERVICE_MAN"].ToString().ToUpper() == "YES")
                        {
                            int TotDays = 0;
                            if (txtDays1.Text.Trim().Length > 0 && txtOrg1.Text.Trim().Length > 3)
                                TotDays = Convert.ToInt32(txtDays1.Text.Trim());

                            if (txtDays2.Text.Trim().Length > 0 && txtOrg2.Text.Trim().Length > 3)
                                TotDays += Convert.ToInt32(txtDays2.Text.Trim());

                            if (txtDays3.Text.Trim().Length > 0 && txtOrg3.Text.Trim().Length > 3)
                                TotDays += Convert.ToInt32(txtDays3.Text.Trim());

                            if (txtDays4.Text.Trim().Length > 0 && txtOrg4.Text.Trim().Length > 3)
                                TotDays += Convert.ToInt32(txtDays4.Text.Trim());

                            if (txtDays5.Text.Trim().Length > 0 && txtOrg5.Text.Trim().Length > 3)
                                TotDays += Convert.ToInt32(txtDays5.Text.Trim());

                            if (TotDays > 0)
                            {
                                TimeSpan ts = TimeSpan.FromDays(TotDays);
                                DateTime age = DateTime.MinValue + ts;

                                int xYear = age.Year - 1;
                                if (xYear >= 3)
                                {
                                    ViewState["SAVE"] = "YES";
                                    lblOrg.Visible = false;
                                }
                                else
                                {
                                    ViewState["SAVE"] = "NO";
                                    lblOrg.Text = "Minimum 3-years of experience required";
                                    lblOrg.Visible = true;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            ViewState["SAVE"] = "YES";
                            lblOrg.Visible = false;
                        }
                    }
                }

                //    if (dt.Rows[0]["HAL_APPRENTICESHIP"].ToString().ToUpper() == "YES")
                //    {
                //        if (txtProgram1.Text.Trim() == "")
                //        {
                //            ViewState["SAVE"] = "NO";
                //            lblProgram.Visible = true;
                //            return;
                //        }
                //        else
                //        {
                //            ViewState["SAVE"] = "YES";
                //            lblProgram.Visible = false;
                //        }
                //    }
            }

            if (ddlVRS.SelectedIndex == 0)
            {
                ViewState["SAVE"] = "NO";
                ddlVRS.Focus();
                lblVRS.Visible = true;
                return;
            }
            else
            {
                ViewState["SAVE"] = "YES";
                lblVRS.Visible = false;
            }

            if (ddlInterview.SelectedIndex == 0)
            {
                ViewState["SAVE"] = "NO";
                ddlInterview.Focus();
                lblIntr.Visible = true;
                return;
            }
            else
            {
                ViewState["SAVE"] = "YES";
                lblIntr.Visible = false;
            }

            if (ddlInterview.SelectedIndex == 1)
            {
                lblInstPost.Visible = false;
                lblIntDate.Visible = false;
                lblIntVenue.Visible = false;
                if (txtIntPost.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtIntPost.Focus();
                    lblInstPost.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblInstPost.Visible = false;
                }

                if (txtIntDate.Text.Trim() == "")
                {
                    lblIntDate.Visible = true;
                    txtIntDate.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    if (!checkDate(today.Trim(), txtIntDate.Text.Trim(), out bool wrong))
                    {
                        ViewState["SAVE"] = "NO";
                        lblIntDate.Text = wrong ? "Wrong Date Format" : "Future Date not Allowed";
                        lblIntDate.Visible = true;
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblIntDate.Visible = false;
                    }
                }

                if (txtIntVenue.Text.Trim() == "")
                {
                    lblIntVenue.Visible = true;
                    txtIntVenue.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblIntVenue.Visible = false;
                }

            }

            if (ddlRelative.SelectedIndex == 0)
            {
                ViewState["SAVE"] = "NO";
                ddlRelative.Focus();
                lblRelative.Visible = true;
                return;
            }
            else
            {
                ViewState["SAVE"] = "YES";
                lblRelative.Visible = false;
            }

            if (ddlRelative.SelectedIndex == 1)
            {
                lblName.Visible = false;
                lblDesig.Visible = false;
                lblDiv.Visible = false;

                if (txtName.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    txtName.Focus();
                    lblName.Visible = true;
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblName.Visible = false;
                }

                if (txtDesig.Text.Trim() == "")
                {
                    lblDesig.Visible = true;
                    txtDesig.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblDesig.Visible = false;
                }

                if (txtDiv.Text.Trim() == "")
                {
                    lblDiv.Visible = true;
                    txtDiv.Focus();
                    ViewState["SAVE"] = "NO";
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblDiv.Visible = false;
                }
            }

            if (ddlPolitics.SelectedIndex == 0)
            {
                ViewState["SAVE"] = "NO";
                ddlPolitics.Focus();
                lblPolitics.Visible = true;
                return;
            }
            else
            {
                ViewState["SAVE"] = "YES";
                lblPolitics.Visible = false;
            }

            if (ddlPolitics.SelectedIndex == 1)
            {
                lblParty.Visible = false;
                lblParticular.Visible = false;
                lblMemPeriod.Visible = false;
                lblNature.Visible = false;
                lblOffice.Visible = false;

                if (txtParty.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    lblParty.Visible = true;
                    txtParty.Focus();
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblParty.Visible = false;
                }
                if (txtParticular.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    lblParticular.Visible = true;
                    txtParticular.Focus();
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblParticular.Visible = false;
                }

                //if (txtMemPeriod.Text.Trim() == "")
                //{
                //    ViewState["SAVE"] = "NO";
                //    lblMemPeriod.Visible = true;
                //    txtMemPeriod.Focus();
                //    return;
                //}
                //else
                //{
                //    ViewState["SAVE"] = "YES";
                //    lblMemPeriod.Visible = false;
                //}

                string periodOfMembership = txtMemPeriod.Text.Trim();
                string errorMessage = "Invalid format. Please use YYYY to YYYY.";

                // Regular expression to match the "YYYY to YYYY" format
                string pattern = @"^\d{4}\s*((t|T)o|-\s*)\d{4}$";
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);

                if (!regex.IsMatch(periodOfMembership))
                {
                    lblMemPeriod.Visible = true;
                    lblMemPeriod.Text = errorMessage;
                    ViewState["SAVE"] = "NO";
                    txtMemPeriod.Focus();
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblMemPeriod.Visible = false;
                    // Proceed with form processing or database operations
                }

                if (txtNature.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    lblNature.Visible = true;
                    txtNature.Focus();
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblNature.Visible = false;
                }
                if (txtOffice.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    lblOffice.Visible = true;
                    txtOffice.Focus();
                    return;
                }
                else
                {
                    ViewState["SAVE"] = "YES";
                    lblOffice.Visible = false;
                }
            }

            //Experience
            //decimal xMark = 0;
            //try
            //{
            //    DataTable dt1 = site.getdatatable("SELECT POST_EDU_AGE.Per_UR, POST_EDU_AGE.Per_EWS, POST_EDU_AGE.Per_SC, POST_EDU_AGE.Per_ST,POST_EDU_AGE.Per_OBC, APPLICANT.CATEGORY_APPLIED FROM APPLICANT INNER JOIN POST_EDU_AGE ON APPLICANT.APPLIED_DISCIPLINE = POST_EDU_AGE.DISCIPLINE where APPLICANT.USERID='" + Session["APPNO"].ToString() + "'");
            //    if (dt1.Rows.Count > 0)
            //    {
            //        string xFld = "";
            //        string xCat = dt1.Rows[0]["CATEGORY_APPLIED"].ToString();
            //        if (xCat == "OBC(NCL)")
            //            xFld = "Per_OBC";
            //        else
            //            xFld = "Per_" + xCat;

            //        xMark = Convert.ToDecimal(dt1.Rows[0][xFld].ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Fetch Error:" + ex.Message);
            //}
            if (divTraining.Visible)
            {
                lblProgram.Visible = false;
                lblOrgName.Visible = false;
                lblBegDate.Visible = false;
                lblEndDate.Visible = false;

                //if (xVal == 1)
                //{
                if (txtProgram1.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    lblProgram.Visible = true;
                    return;
                }
                else
                {
                    lblProgram.Visible = false;
                    ViewState["SAVE"] = "YES";
                }

                if (txtOrgName1.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    lblOrgName.Visible = true;
                    return;
                }
                else
                {
                    lblOrgName.Visible = false;
                    ViewState["YES"] = "YES";
                }

                if (txtBegDate1.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    lblBegDate.Visible = true;
                    return;
                }
                else
                {
                    if (!checkDate(today.Trim(), txtBegDate1.Text.Trim()))
                    {
                        ViewState["SAVE"] = "NO";
                        lblBegDate.Text = "Future Date not Allowed";
                        lblBegDate.Visible = true;
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblBegDate.Visible = false;
                    }
                }
                if (txtEndDate1.Text.Trim() == "")
                {
                    ViewState["SAVE"] = "NO";
                    lblEndDate.Visible = true;
                    return;
                }
                else
                {
                    if (!checkDate(today.Trim(), txtEndDate1.Text.Trim()))
                    {
                        ViewState["SAVE"] = "NO";
                        lblEndDate.Text = "Future Date not Allowed";
                        lblEndDate.Visible = true;
                        return;
                    }
                    else
                    {
                        ViewState["SAVE"] = "YES";
                        lblEndDate.Visible = false;
                    }
                }
            }
        }
        void getRecords(string xApp)
        {
            try
            {
                dt = site.getdatatable("select * from APPLICANT where USERID='" + xApp + "'");
                if (dt.Rows.Count > 0)
                {
                    divESM.Visible = false;
                    if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Security Guard")
                    {
                        divITI.Visible = false;
                        divRank.Visible = true;
                        divRank2.Visible = true;
                        divNAC.Visible = false;
                        divDiploma.Visible = false;
                    }
                    else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Operator (Welding)" || dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Operator (Fitting)")
                    {
                        divITI.Visible = true;
                        divNAC.Visible = true;
                        divDiploma.Visible = false;
                    }
                    else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Technician (Mechanical)" || dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Technician (Electrical)")
                    {
                        divITI.Visible = false;
                        divNAC.Visible = false;
                        divDiploma.Visible = true;
                    }
                    else
                    {
                        if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "ESM Technician (Engine Fitter)")
                        {
                            lblESM.Text = "Airforce Engine Fitter Certificate";
                            LBLESM34.Text += " in Machanical Engineering";
                        }
                        else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "ESM Technician (Electrical Fitter)")
                        {
                            lblESM.Text = "Airforce Electrical Fitter Certificate";
                            LBLESM34.Text += " in Electrical Engineering";
                        }
                        else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "ESM Technician (Mechanician-Air Electrical)")
                        {
                            lblESM.Text = "Airforce Mechanician–Air Electrical Certificate";
                            LBLESM34.Text += " in Electrical Engineering";
                        }
                        else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "ESM Technician (Aircraft Artificer-Air Engineering)")
                        {
                            lblESM.Text = "Airforce Artificer-Air Certificate";
                            LBLESM34.Text += " in Machanical Engineering";
                        }
                        divESM.Visible = true;
                        divITI.Visible = false;
                        divRank.Visible = false;
                        divRank2.Visible = false;
                        divNAC.Visible = false;
                        divDiploma.Visible = false;
                    }

                    if (dt.Rows[0]["BOARD10_INST"].ToString().Trim() != "")
                        txtEdu10.Text = dt.Rows[0]["BOARD10_INST"].ToString();
                    if (dt.Rows[0]["BOARD10_NATURE"].ToString().Trim() != "")
                        ddlNature10.SelectedValue = dt.Rows[0]["BOARD10_NATURE"].ToString();
                    if (dt.Rows[0]["BOARD10_DURATION"].ToString().Trim() != "")
                        txtDuration10.Text = dt.Rows[0]["BOARD10_DURATION"].ToString();
                    if (dt.Rows[0]["BOARD10_SUBJECTS"].ToString().Trim() != "")
                        txtSub10.Text = dt.Rows[0]["BOARD10_SUBJECTS"].ToString();
                    //if (dt.Rows[0]["BOARD10_DIVISION"].ToString().Trim() != "")
                    //    txtDiv10.Text = dt.Rows[0]["BOARD10_DIVISION"].ToString();
                    if (dt.Rows[0]["BOARD10_PERCENT"].ToString().Trim() != "")
                        txtPercent10.Text = dt.Rows[0]["BOARD10_PERCENT"].ToString();
                    if (dt.Rows[0]["BOARD10_PASSING_DATE"].ToString().Trim() != "")
                        txtPassDate10.Text = dt.Rows[0]["BOARD10_PASSING_DATE"].ToString();

                    if (!string.IsNullOrEmpty(dt.Rows[0]["BOARD12_INST"].ToString()))
                    {
                        if (dt.Rows[0]["BOARD12_INST"].ToString() != "")
                            txtEdu12.Text = dt.Rows[0]["BOARD12_INST"].ToString();
                        if (dt.Rows[0]["BOARD12_NATURE"].ToString() != "")
                            ddlNature12.SelectedValue = dt.Rows[0]["BOARD12_NATURE"].ToString();
                        if (dt.Rows[0]["BOARD12_DURATION"].ToString() != "")
                            txtDuration12.Text = dt.Rows[0]["BOARD12_DURATION"].ToString();
                        if (dt.Rows[0]["BOARD12_SUBJECTS"].ToString() != "")
                            txtSub12.Text = dt.Rows[0]["BOARD12_SUBJECTS"].ToString();
                        //if (dt.Rows[0]["BOARD12_DIVISION"].ToString() != "")
                        //    txtDiv12.Text = dt.Rows[0]["BOARD12_DIVISION"].ToString();
                        if (dt.Rows[0]["BOARD12_PERCENT"].ToString() != "")
                            txtPercent12.Text = dt.Rows[0]["BOARD12_PERCENT"].ToString();
                        if (dt.Rows[0]["BOARD12_PASSING_DATE"].ToString() != "")
                            txtPassDate12.Text = dt.Rows[0]["BOARD12_PASSING_DATE"].ToString();
                    }

                    if (divITI.Visible)
                    {
                        if (dt.Rows[0]["ITI_INST"].ToString() != "")
                            txtITI.Text = dt.Rows[0]["ITI_INST"].ToString();
                        if (dt.Rows[0]["ITI_NATURE"].ToString() != "")
                            ddlNatureITI.SelectedValue = dt.Rows[0]["ITI_NATURE"].ToString();
                        if (dt.Rows[0]["ITI_DURATION"].ToString() != "")
                            txtDurationITI.Text = dt.Rows[0]["ITI_DURATION"].ToString();
                        if (dt.Rows[0]["ITI_SUBJECTS"].ToString() != "")
                            txtSubITI.Text = dt.Rows[0]["ITI_SUBJECTS"].ToString();
                        //if (dt.Rows[0]["ITI_DIVISION"].ToString() != "")
                        //    txtDivITI.Text = dt.Rows[0]["ITI_DIVISION"].ToString();
                        if (dt.Rows[0]["ITI_PERCENT"].ToString() != "")
                            txtITIPercent.Text = dt.Rows[0]["ITI_PERCENT"].ToString();
                        if (dt.Rows[0]["ITI_PASSING_DATE"].ToString() != "")
                            txtITIDate.Text = dt.Rows[0]["ITI_PASSING_DATE"].ToString();
                    }

                    if (divDiploma.Visible)
                    {
                        if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Technician (Mechanical)")
                        {
                            txtSubDip.Text = "Mechanical";
                        }
                        else if (dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim() == "Technician (Electrical)")
                        {
                            txtSubDip.Text = "Electrical";
                        }
                        else
                        {
                            txtSubDip.Text = "";
                        }

                        if (dt.Rows[0]["DIPLOMA_INST"].ToString() != "")
                            txtDip.Text = dt.Rows[0]["DIPLOMA_INST"].ToString();
                        if (dt.Rows[0]["DIPLOMA_NATURE"].ToString() != "")
                            ddlNatureDip.SelectedValue = dt.Rows[0]["DIPLOMA_NATURE"].ToString();
                        if (dt.Rows[0]["DIPLOMA_DURATION"].ToString() != "")
                            txtDurationDip.Text = dt.Rows[0]["DIPLOMA_DURATION"].ToString();
                        //if (dt.Rows[0]["DIPLOMA_DIVISION"].ToString() != "")
                        //    txtDivDip.Text = dt.Rows[0]["DIPLOMA_DIVISION"].ToString();
                        if (dt.Rows[0]["DIPLOMA_PERCENT"].ToString() != "")
                            txtDipPer.Text = dt.Rows[0]["DIPLOMA_PERCENT"].ToString();
                        if (dt.Rows[0]["DIPLOMA_PASSING_DATE"].ToString() != "")
                            txtDipDate.Text = dt.Rows[0]["DIPLOMA_PASSING_DATE"].ToString();
                    }


                    if (divNAC.Visible)
                    {
                        if (dt.Rows[0]["NAC_UNIV"].ToString() != "")
                            txtNacUniv.Text = dt.Rows[0]["NAC_UNIV"].ToString();
                        //if (dt.Rows[0]["NAC_NCTVT"].ToString().Trim() != "")
                        //    ddlNac.SelectedValue = dt.Rows[0]["NAC_NCTVT"].ToString();
                        if (dt.Rows[0]["NAC_NCTVT_PASSING_DATE"].ToString().Trim() != "")
                            txtNacDate.Text = dt.Rows[0]["NAC_NCTVT_PASSING_DATE"].ToString();
                        if (dt.Rows[0]["NAC_NCTVT_PERCENT"].ToString() != "")
                            txtNacPer.Text = dt.Rows[0]["NAC_NCTVT_PERCENT"].ToString();
                    }

                    if (divRank.Visible)
                    {
                        if (dt.Rows[0]["RANK_HELD2"].ToString() != "")
                            txtRank.Text = dt.Rows[0]["RANK_HELD2"].ToString();

                        if (dt.Rows[0]["JOINING_DATE"].ToString().Trim() != "")
                            txtFrom.Text = dt.Rows[0]["JOINING_DATE"].ToString();

                        if (dt.Rows[0]["LEAVING_DATE"].ToString().Trim() != "")
                            txtUpto.Text = dt.Rows[0]["LEAVING_DATE"].ToString();

                        if (dt.Rows[0]["PERIOD"].ToString() != "")
                            txtPeriod.Text = dt.Rows[0]["PERIOD"].ToString();
                    }

                    if (divESM.Visible)
                    {
                        if (dt.Rows[0]["ESM_PASSING_DATE"].ToString().Trim() != "")
                            txtESMDate.Text = dt.Rows[0]["ESM_PASSING_DATE"].ToString();
                        if (dt.Rows[0]["ESM_CERT_NO"].ToString() != "")
                            txtESMCert.Text = dt.Rows[0]["ESM_CERT_NO"].ToString();
                    }

                    if (dt.Rows[0]["HAL_APPRENTICESHIP"].ToString().Trim() == "Yes")
                    {
                        divTraining.Visible = true;
                        divTraining1.Visible = true;
                    }
                    else
                    {
                        divTraining.Visible = false;
                        divTraining1.Visible = false;
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["ORGANISATION_NAME_EXP1"].ToString()))
                    {
                        if (dt.Rows[0]["ORGANISATION_NAME_EXP1"].ToString().Trim() != "")
                            txtOrg1.Text = dt.Rows[0]["ORGANISATION_NAME_EXP1"].ToString();
                        if (dt.Rows[0]["ORGANISATION_NAME_EXP2"].ToString().Trim() != "")
                        {
                            divExp2.Visible = true;
                            divDesc2.Visible = true;
                            txtOrg2.Text = dt.Rows[0]["ORGANISATION_NAME_EXP2"].ToString();
                        }
                        if (dt.Rows[0]["ORGANISATION_NAME_EXP3"].ToString().Trim() != "")
                        {
                            divExp3.Visible = true;
                            divDesc3.Visible = true;
                            txtOrg3.Text = dt.Rows[0]["ORGANISATION_NAME_EXP3"].ToString();
                        }
                        if (dt.Rows[0]["ORGANISATION_NAME_EXP4"].ToString().Trim() != "")
                        {
                            divExp4.Visible = true;
                            divDesc4.Visible = true;
                            txtOrg4.Text = dt.Rows[0]["ORGANISATION_NAME_EXP4"].ToString();
                        }
                        if (dt.Rows[0]["ORGANISATION_NAME_EXP5"].ToString().Trim() != "")
                        {
                            divExp4.Visible = true;
                            divDesc4.Visible = true;
                            txtOrg5.Text = dt.Rows[0]["ORGANISATION_NAME_EXP5"].ToString();
                        }

                        if (dt.Rows[0]["DESIGNATION_EXP1"].ToString().Trim() != "")
                            txtPosition1.Text = dt.Rows[0]["DESIGNATION_EXP1"].ToString();
                        if (dt.Rows[0]["DESIGNATION_EXP2"].ToString().Trim() != "")
                            txtPosition2.Text = dt.Rows[0]["DESIGNATION_EXP2"].ToString();
                        if (dt.Rows[0]["DESIGNATION_EXP3"].ToString().Trim() != "")
                            txtPosition3.Text = dt.Rows[0]["DESIGNATION_EXP3"].ToString();
                        if (dt.Rows[0]["DESIGNATION_EXP4"].ToString().Trim() != "")
                            txtPosition4.Text = dt.Rows[0]["DESIGNATION_EXP4"].ToString();
                        if (dt.Rows[0]["DESIGNATION_EXP5"].ToString().Trim() != "")
                            txtPosition5.Text = dt.Rows[0]["DESIGNATION_EXP5"].ToString();


                        if (dt.Rows[0]["SALARY_PM_EXP1"].ToString().Trim() != "")
                            txtPay1.Text = dt.Rows[0]["SALARY_PM_EXP1"].ToString();
                        if (dt.Rows[0]["SALARY_PM_EXP2"].ToString().Trim() != "")
                            txtPay2.Text = dt.Rows[0]["SALARY_PM_EXP2"].ToString();
                        if (dt.Rows[0]["SALARY_PM_EXP3"].ToString().Trim() != "")
                            txtPay3.Text = dt.Rows[0]["SALARY_PM_EXP3"].ToString();
                        if (dt.Rows[0]["SALARY_PM_EXP4"].ToString().Trim() != "")
                            txtPay4.Text = dt.Rows[0]["SALARY_PM_EXP4"].ToString();
                        if (dt.Rows[0]["SALARY_PM_EXP5"].ToString().Trim() != "")
                            txtPay5.Text = dt.Rows[0]["SALARY_PM_EXP5"].ToString();


                        if (dt.Rows[0]["JOIN_DATE_EXP1"].ToString().Trim() != "")
                            txtBegin1.Text = dt.Rows[0]["JOIN_DATE_EXP1"].ToString();
                        if (dt.Rows[0]["JOIN_DATE_EXP2"].ToString().Trim() != "")
                            txtBegin2.Text = dt.Rows[0]["JOIN_DATE_EXP2"].ToString();
                        if (dt.Rows[0]["JOIN_DATE_EXP3"].ToString().Trim() != "")
                            txtBegin3.Text = dt.Rows[0]["JOIN_DATE_EXP3"].ToString();
                        if (dt.Rows[0]["JOIN_DATE_EXP4"].ToString().Trim() != "")
                            txtBegin4.Text = dt.Rows[0]["JOIN_DATE_EXP4"].ToString();
                        if (dt.Rows[0]["JOIN_DATE_EXP5"].ToString().Trim() != "")
                            txtBegin5.Text = dt.Rows[0]["JOIN_DATE_EXP5"].ToString();

                        if (dt.Rows[0]["END_DATE_EXP1"].ToString().Trim() != "")
                            txtEnd1.Text = dt.Rows[0]["END_DATE_EXP1"].ToString();
                        if (dt.Rows[0]["END_DATE_EXP2"].ToString().Trim() != "")
                            txtEnd2.Text = dt.Rows[0]["END_DATE_EXP2"].ToString();
                        if (dt.Rows[0]["END_DATE_EXP3"].ToString().Trim() != "")
                            txtEnd3.Text = dt.Rows[0]["END_DATE_EXP3"].ToString();
                        if (dt.Rows[0]["END_DATE_EXP4"].ToString().Trim() != "")
                            txtEnd4.Text = dt.Rows[0]["END_DATE_EXP4"].ToString();
                        if (dt.Rows[0]["END_DATE_EXP5"].ToString().Trim() != "")
                            txtEnd5.Text = dt.Rows[0]["END_DATE_EXP5"].ToString();


                        if (dt.Rows[0]["PERIOD_EXP1"].ToString().Trim() != "")
                            TextBox1.Text = dt.Rows[0]["PERIOD_EXP1"].ToString();
                        if (dt.Rows[0]["PERIOD_EXP2"].ToString().Trim() != "")
                            txtPeriod2.Text = dt.Rows[0]["PERIOD_EXP2"].ToString();
                        if (dt.Rows[0]["PERIOD_EXP3"].ToString().Trim() != "")
                            txtPeriod3.Text = dt.Rows[0]["PERIOD_EXP3"].ToString();
                        if (dt.Rows[0]["PERIOD_EXP4"].ToString().Trim() != "")
                            txtPeriod4.Text = dt.Rows[0]["PERIOD_EXP4"].ToString();
                        if (dt.Rows[0]["PERIOD_EXP5"].ToString().Trim() != "")
                            txtPeriod5.Text = dt.Rows[0]["PERIOD_EXP5"].ToString();

                        if (dt.Rows[0]["DAYS_EXP1"].ToString().Trim() != "")
                            txtDays1.Text = dt.Rows[0]["DAYS_EXP1"].ToString();
                        if (dt.Rows[0]["DAYS_EXP2"].ToString().Trim() != "")
                            txtDays2.Text = dt.Rows[0]["DAYS_EXP2"].ToString();
                        if (dt.Rows[0]["DAYS_EXP3"].ToString().Trim() != "")
                            txtDays3.Text = dt.Rows[0]["DAYS_EXP3"].ToString();
                        if (dt.Rows[0]["DAYS_EXP4"].ToString().Trim() != "")
                            txtDays4.Text = dt.Rows[0]["DAYS_EXP4"].ToString();
                        if (dt.Rows[0]["DAYS_EXP5"].ToString().Trim() != "")
                            txtDays5.Text = dt.Rows[0]["DAYS_EXP5"].ToString();

                        if (dt.Rows[0]["REMARKS_EXP1"].ToString().Trim() != "")
                            txtDescs1.Text = dt.Rows[0]["REMARKS_EXP1"].ToString();
                        if (dt.Rows[0]["REMARKS_EXP2"].ToString().Trim() != "")
                            txtDesc2.Text = dt.Rows[0]["REMARKS_EXP2"].ToString();
                        if (dt.Rows[0]["REMARKS_EXP3"].ToString().Trim() != "")
                            txtDesc3.Text = dt.Rows[0]["REMARKS_EXP3"].ToString();
                        if (dt.Rows[0]["REMARKS_EXP4"].ToString().Trim() != "")
                            txtDesc4.Text = dt.Rows[0]["REMARKS_EXP4"].ToString();
                        if (dt.Rows[0]["REMARKS_EXP5"].ToString().Trim() != "")
                            txtDesc5.Text = dt.Rows[0]["REMARKS_EXP5"].ToString();

                        if (!string.IsNullOrEmpty(dt.Rows[0]["PERIOD_EXP1"].ToString()))
                        {
                            int TotDays = 0;
                            string yDays = "";
                            if (!string.IsNullOrEmpty(dt.Rows[0]["PERIOD_EXP1"].ToString()))
                            {
                                txtBegin1.Text = dt.Rows[0]["JOIN_DATE_EXP1"].ToString();
                                txtEnd1.Text = dt.Rows[0]["END_DATE_EXP1"].ToString();
                                TextBox1.Text = dt.Rows[0]["DAYS_EXP1"].ToString();
                                TextBox1.Text = CalcPeriod(txtBegin1.Text.Trim(), txtEnd1.Text.Trim(), ref yDays);
                                txtDays1.Text = yDays;
                                if (yDays.Trim().Length > 0)
                                    TotDays = Convert.ToInt32(txtDays1.Text);
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["PERIOD_EXP2"].ToString()))
                            {
                                //check date overlapping
                                txtBegin2.Text = dt.Rows[0]["JOIN_DATE_EXP2"].ToString();
                                txtEnd2.Text = dt.Rows[0]["END_DATE_EXP2"].ToString();
                                txtPeriod2.Text = dt.Rows[0]["DAYS_EXP2"].ToString();
                                if ((txtBegin2.Text.Trim() != "") && (txtEnd1.Text.Trim() != ""))
                                {
                                    string xx = ValidateOverlappingDate(txtBegin2.Text.Trim(), txtEnd1.Text.Trim());
                                    if (xx == "NO")
                                    {
                                        lblBegin.Visible = true;
                                        lblBegin.Text = "Joining Date is Overlapping with Previous Date";
                                        return;
                                    }
                                    else
                                    {
                                        lblBegin.Visible = false;
                                        txtPeriod2.Text = CalcPeriod(txtBegin2.Text.Trim(), txtEnd2.Text.Trim(), ref yDays);
                                        txtDays2.Text = yDays;
                                        if (yDays.Trim().Length > 0)
                                        {
                                            TotDays = Convert.ToInt32(txtDays1.Text) + Convert.ToInt32(txtDays2.Text);
                                        }
                                    }
                                }
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["PERIOD_EXP3"].ToString()))
                            {
                                //check date overlapping
                                txtBegin3.Text = dt.Rows[0]["JOIN_DATE_EXP3"].ToString();
                                txtEnd3.Text = dt.Rows[0]["END_DATE_EXP3"].ToString();
                                txtPeriod3.Text = dt.Rows[0]["DAYS_EXP3"].ToString();
                                if ((txtBegin3.Text.Trim() != "") && (txtEnd2.Text.Trim() != ""))
                                {
                                    string xx = ValidateOverlappingDate(txtBegin3.Text.Trim(), txtEnd2.Text.Trim());
                                    if (xx == "NO")
                                    {
                                        lblBegin.Visible = true;
                                        lblBegin.Text = "Joining Date is Overlapping with Previous Date";
                                        return;
                                    }
                                    else
                                    {
                                        lblBegin.Visible = false;
                                        txtPeriod3.Text = CalcPeriod(txtBegin3.Text.Trim(), txtEnd3.Text.Trim(), ref yDays);
                                        txtDays3.Text = yDays;
                                        if (yDays.Trim().Length > 0)
                                        {
                                            TotDays = Convert.ToInt32(txtDays1.Text) + Convert.ToInt32(txtDays2.Text) + Convert.ToInt32(txtDays3.Text);
                                        }
                                    }
                                }
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["PERIOD_EXP4"].ToString()))
                            {
                                //check date overlapping
                                txtBegin4.Text = dt.Rows[0]["JOIN_DATE_EXP4"].ToString();
                                txtEnd4.Text = dt.Rows[0]["END_DATE_EXP4"].ToString();
                                txtPeriod4.Text = dt.Rows[0]["DAYS_EXP4"].ToString();
                                if ((txtBegin4.Text.Trim() != "") && (txtEnd3.Text.Trim() != ""))
                                {
                                    string xx = ValidateOverlappingDate(txtBegin4.Text.Trim(), txtEnd3.Text.Trim());
                                    if (xx == "NO")
                                    {
                                        lblBegin.Visible = true;
                                        lblBegin.Text = "Joining Date is Overlapping with Previous Date";
                                        return;
                                    }
                                    else
                                    {
                                        lblBegin.Visible = false;
                                        txtPeriod4.Text = CalcPeriod(txtBegin4.Text.Trim(), txtEnd4.Text.Trim(), ref yDays);
                                        txtDays4.Text = yDays;
                                        if (yDays.Trim().Length > 0)
                                        {
                                            TotDays = Convert.ToInt32(txtDays1.Text) + Convert.ToInt32(txtDays2.Text) + Convert.ToInt32(txtDays3.Text) + Convert.ToInt32(txtDays4.Text);
                                        }
                                    }
                                }
                            }
                            if (!string.IsNullOrEmpty(dt.Rows[0]["PERIOD_EXP5"].ToString()))
                            {
                                //check date overlapping
                                txtBegin5.Text = dt.Rows[0]["JOIN_DATE_EXP5"].ToString();
                                txtEnd5.Text = dt.Rows[0]["END_DATE_EXP5"].ToString();
                                txtPeriod5.Text = dt.Rows[0]["DAYS_EXP5"].ToString();
                                if ((txtBegin5.Text.Trim() != "") && (txtEnd4.Text.Trim() != ""))
                                {
                                    string xx = ValidateOverlappingDate(txtBegin5.Text.Trim(), txtEnd4.Text.Trim());
                                    if (xx == "NO")
                                    {
                                        lblBegin.Visible = true;
                                        lblBegin.Text = "Joining Date is Overlapping with Previous Date";
                                        return;
                                    }
                                    else
                                    {
                                        lblBegin.Visible = false;
                                        txtPeriod5.Text = CalcPeriod(txtBegin5.Text.Trim(), txtEnd5.Text.Trim(), ref yDays);
                                        txtDays5.Text = yDays;
                                        if (yDays.Trim().Length > 0)
                                        {
                                            TotDays = Convert.ToInt32(txtDays1.Text) + Convert.ToInt32(txtDays2.Text) + Convert.ToInt32(txtDays3.Text) + Convert.ToInt32(txtDays4.Text) + Convert.ToInt32(txtDays5.Text);
                                        }
                                    }
                                }
                            }
                            if (TotDays > 0)
                            {
                                TimeSpan ts = TimeSpan.FromDays(TotDays);
                                DateTime age = DateTime.MinValue + ts;

                                int xYear = age.Year - 1;
                                int xMon = age.Month - 1;
                                int xDays = age.Day - 1;
                                txtTotPeriod.Text = xYear + "-Year " + xMon + "-Month " + xDays + "-Days";
                            }

                        }

                    }


                    if (!string.IsNullOrEmpty(dt.Rows[0]["ORGANISATION_NAME_TRAINING1"].ToString()))
                    {
                        if (dt.Rows[0]["ORGANISATION_NAME_TRAINING1"].ToString().Trim() != "")
                        {
                            txtProgram1.Text = dt.Rows[0]["ORGANISATION_NAME_TRAINING1"].ToString();
                        }
                        //if (dt.Rows[0]["ORGANISATION_NAME_TRAINING2"].ToString().Trim() != "")
                        //{
                        //    //divTraining2.Visible = true;
                        //    //btnAddRex2.Visible = false;
                        //    //btnAddRex1.Visible = false;
                        //    txtProgram2.Text = dt.Rows[0]["ORGANISATION_NAME_TRAINING2"].ToString();
                        //}
                        if (dt.Rows[0]["PROGRAM_NAME_TRAINING1"].ToString().Trim() != "")
                        {
                            txtOrgName1.Text = dt.Rows[0]["PROGRAM_NAME_TRAINING1"].ToString();
                            //txtOrgName2.Text = dt.Rows[0]["PROGRAM_NAME_TRAINING2"].ToString();
                        }
                        if (dt.Rows[0]["JOIN_DATE_TRAINING1"].ToString().Trim() != "")
                        {
                            txtBegDate1.Text = dt.Rows[0]["JOIN_DATE_TRAINING1"].ToString();
                            //txtBegDate2.Text = dt.Rows[0]["JOIN_DATE_TRAINING2"].ToString();
                        }
                        if (dt.Rows[0]["END_DATE_TRAINING1"].ToString().Trim() != "")
                        {
                            txtEndDate1.Text = dt.Rows[0]["END_DATE_TRAINING1"].ToString();
                            //txtEndDate2.Text = dt.Rows[0]["END_DATE_TRAINING2"].ToString();
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["VRS_TAKEN"].ToString()))
                        ddlVRS.Text = dt.Rows[0]["VRS_TAKEN"].ToString().Trim();

                    if (!string.IsNullOrEmpty(dt.Rows[0]["INTERVIEWED_BY_HAL"].ToString()))
                    {
                        if (dt.Rows[0]["INTERVIEWED_BY_HAL"].ToString().Trim() != "")
                        {
                            if (dt.Rows[0]["INTERVIEWED_BY_HAL"].ToString().Trim() == "Yes")
                            {
                                divInterview.Visible = true;
                                ddlInterview.Text = dt.Rows[0]["INTERVIEWED_BY_HAL"].ToString();
                            }
                            else
                            {
                                ddlInterview.Text = dt.Rows[0]["INTERVIEWED_BY_HAL"].ToString();
                            }
                        }
                        if (dt.Rows[0]["POST_INTERVIEWED"].ToString().Trim() != "")
                            txtIntPost.Text = dt.Rows[0]["POST_INTERVIEWED"].ToString();

                        if (dt.Rows[0]["INTERVIEWED_DATE"].ToString().Trim() != "")
                            txtIntDate.Text = dt.Rows[0]["INTERVIEWED_DATE"].ToString();

                        if (dt.Rows[0]["INTERVIEWED_VENUE"].ToString().Trim() != "")
                            txtIntVenue.Text = dt.Rows[0]["INTERVIEWED_VENUE"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["RELATIVE_WITH_HAL"].ToString()))
                    {

                        if (dt.Rows[0]["RELATIVE_WITH_HAL"].ToString().Trim() != "")
                        {
                            if (dt.Rows[0]["RELATIVE_WITH_HAL"].ToString() == "Yes")
                            {
                                divRelative.Visible = true;
                                ddlRelative.Text = dt.Rows[0]["RELATIVE_WITH_HAL"].ToString();
                            }
                            else
                            {
                                ddlRelative.Text = dt.Rows[0]["RELATIVE_WITH_HAL"].ToString();
                            }
                        }

                        if (dt.Rows[0]["RELATIVE_NAME"].ToString().Trim() != "")
                            txtName.Text = dt.Rows[0]["RELATIVE_NAME"].ToString();

                        if (dt.Rows[0]["RELATIVE_DESIG"].ToString().Trim() != "")
                            txtDesig.Text = dt.Rows[0]["RELATIVE_DESIG"].ToString();

                        if (dt.Rows[0]["RELATIVE_DIVISION"].ToString().Trim() != "")
                            txtDiv.Text = dt.Rows[0]["RELATIVE_DIVISION"].ToString();

                        if (dt.Rows[0]["RELATIVE_DESC"].ToString().Trim() != "")
                            txtDesc.Text = dt.Rows[0]["RELATIVE_DIVISION"].ToString();

                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["POLITICAL_RELATION"].ToString()))
                    {
                        if (dt.Rows[0]["POLITICAL_RELATION"].ToString().Trim() != "")
                        {
                            if (dt.Rows[0]["POLITICAL_RELATION"].ToString() == "Yes")
                            {
                                divPolitics.Visible = true;
                                ddlPolitics.Text = dt.Rows[0]["POLITICAL_RELATION"].ToString();
                            }
                            else
                            {
                                ddlPolitics.Text = dt.Rows[0]["POLITICAL_RELATION"].ToString();
                            }
                        }
                        if (dt.Rows[0]["POLITICAL_PARTY_NAME"].ToString().Trim() != "")
                            txtParty.Text = dt.Rows[0]["POLITICAL_PARTY_NAME"].ToString();

                        if (dt.Rows[0]["POLITICAL_ACTIVITY"].ToString().Trim() != "")
                            txtParticular.Text = dt.Rows[0]["POLITICAL_ACTIVITY"].ToString();

                        if (dt.Rows[0]["POLITICAL_PERIOD"].ToString().Trim() != "")
                            txtMemPeriod.Text = dt.Rows[0]["POLITICAL_PERIOD"].ToString();

                        if (dt.Rows[0]["POLITICAL_PARTICIPATION"].ToString().Trim() != "")
                            txtNature.Text = dt.Rows[0]["POLITICAL_PARTY_NAME"].ToString();

                        if (dt.Rows[0]["POLITICAL_OFFICE_HELD"].ToString().Trim() != "")
                            txtOffice.Text = dt.Rows[0]["POLITICAL_PARTY_NAME"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        protected void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox1.Checked == true)
                {
                    lblStatus.Visible = false;
                    lblStatus.Text = "";
                }
                else
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Please Select CheckBox and click Save & Next";
                    return;
                }

                ValidateFields();
                if (ViewState["SAVE"].ToString() == "NO")
                {
                    lblStatus.Text = "Please Fill up all the details, Incomplete page not allowed here!";
                    lblStatus.Visible = true;
                    return;
                }
                else
                {
                    lblStatus.Text = "";
                    lblStatus.Visible = false;

                    string xSQL = "";
                    if (Session["APPNO"] != null)
                    {
                        if (txtEdu10.Text.Trim().ToUpper() != "")
                            //xSQL += "BOARD10_INST = '" + txtEdu10.Text.Trim().ToUpper() +"'";
                            xSQL += txtEdu10.Text.Trim() == "" ? " BOARD10_INST=null" : " BOARD10_INST='" + txtEdu10.Text.Trim() + "'";

                        if (ddlNature10.SelectedIndex > 0)
                            //xSQL += ", BOARD10_NATURE = '" + ddlNature10.SelectedItem.Text + "'";
                            xSQL += ddlNature10.Text.Trim() == "" ? ", BOARD10_NATURE=null" : ", BOARD10_NATURE='" + ddlNature10.Text.Trim() + "'";

                        if (txtDuration10.Text.Trim().ToUpper() != "")
                            //xSQL += ", BOARD10_DURATION = '" + txtDuration10.Text.Trim().ToUpper() + "'";
                            xSQL += txtDuration10.Text.Trim() == "" ? ", BOARD10_DURATION=null" : ", BOARD10_DURATION='" + txtDuration10.Text.Trim() + "'";

                        if (txtSub10.Text.Trim().ToUpper() != "")
                            //xSQL += ",BOARD10_SUBJECTS = '" + txtSub10.Text.Trim().ToUpper() + "'";
                            xSQL += txtSub10.Text.Trim() == "" ? ", BOARD10_SUBJECTS=null" : ", BOARD10_SUBJECTS='" + txtSub10.Text.Trim() + "'";

                        //if (txtDiv10.Text.Trim().ToUpper() != "")
                        ////xSQL += ",BOARD10_DIVISION = '" + txtDiv10.Text.Trim().ToUpper() + "'";
                        //xSQL += txtDiv10.Text.Trim() == "" ? ", BOARD10_DIVISION=null" : ", BOARD10_DIVISION='" + txtDiv10.Text.Trim() + "'";

                        if (txtPercent10.Text.Trim() != "")
                            // xSQL += ",BOARD10_PERCENT = " + txtPercent10.Text.Trim() + "";
                            xSQL += txtPercent10.Text.Trim() == "" ? ", BOARD10_PERCENT=null" : ", BOARD10_PERCENT='" + txtPercent10.Text.Trim() + "'";

                        if (txtPassDate10.Text.Trim().ToUpper() != "")
                            //xSQL += ",BOARD10_PASSING_DATE= '" + txtPassDate10.Text + "'";
                            xSQL += txtPassDate10.Text.Trim() == "" ? ", BOARD10_PASSING_DATE=null" : ", BOARD10_PASSING_DATE='" + txtPassDate10.Text.Trim() + "'";


                        if (txtEdu12.Text.Trim() != "")
                        {
                            if (txtEdu12.Text.Trim().ToUpper() != "")
                                //xSQL += ",BOARD12_INST = '" + txtEdu12.Text.Trim() + "'";
                                xSQL += txtEdu12.Text.Trim() == "" ? ", BOARD12_INST=null" : ", BOARD12_INST='" + txtEdu12.Text.Trim() + "'";

                            if (ddlNature12.SelectedIndex > 0)
                                //xSQL += ",BOARD12_NATURE = '" + ddlNature12.SelectedItem.Text + "'";
                                xSQL += ddlNature12.Text.Trim() == "" ? ", BOARD12_NATURE=null" : ", BOARD12_NATURE='" + ddlNature12.Text.Trim() + "'";

                            if (txtDuration12.Text.Trim().ToUpper() != "")
                                //xSQL += ",BOARD12_DURATION = '" + txtDuration12.Text.Trim().ToUpper() + "'";
                                xSQL += txtDuration12.Text.Trim() == "" ? ", BOARD12_DURATION=null" : ", BOARD12_DURATION='" + txtDuration12.Text.Trim() + "'";

                            if (txtSub12.Text.Trim().ToUpper() != "")
                                //xSQL += ",BOARD12_SUBJECTS = '" + txtSub12.Text.Trim().ToUpper() + "'";
                                xSQL += txtSub12.Text.Trim() == "" ? ", BOARD12_SUBJECTS=null" : ", BOARD12_SUBJECTS='" + txtSub12.Text.Trim() + "'";

                            //if (txtDiv12.Text.Trim().ToUpper() != "")
                            //    //xSQL += ",BOARD12_DIVISION = '" + txtDiv12.Text.Trim().ToUpper() + "'";
                            //    xSQL += txtDiv12.Text.Trim() == "" ? ", BOARD12_DIVISION=null" : ", BOARD12_DIVISION='" + txtDiv12.Text.Trim() + "'";

                            if (txtPercent12.Text.Trim() != "")
                                //xSQL += ",BOARD12_PERCENT = " + txtPercent12.Text.Trim() + "";
                                xSQL += txtPercent12.Text.Trim() == "" ? ", BOARD12_PERCENT=null" : ", BOARD12_PERCENT='" + txtPercent12.Text.Trim() + "'";

                            if (txtPassDate12.Text.Trim() != "")
                                //xSQL += ",BOARD12_PASSING_DATE = '" + txtPassDate12.Text.Trim() + "'";
                                xSQL += txtPassDate12.Text.Trim() == "" ? ", BOARD12_PASSING_DATE=null" : ", BOARD12_PASSING_DATE='" + txtPassDate12.Text.Trim() + "'";
                        }
                        else
                        {
                            xSQL += ",BOARD12_INST = null, BOARD12_NATURE= null, BOARD12_DURATION = null ,BOARD12_SUBJECTS = null,BOARD12_DIVISION=null,BOARD12_PERCENT=null,BOARD12_PASSING_DATE=null";
                        }

                        if (divITI.Visible)
                        {
                            if (txtITI.Text.Trim() != "")
                            {
                                if (txtITI.Text.Trim() != "")
                                    xSQL += ",ITI_INST = '" + txtITI.Text.Trim().ToUpper() + "'";

                                if (ddlNatureITI.SelectedIndex > 0)
                                    xSQL += ",ITI_NATURE = '" + ddlNatureITI.SelectedItem.Text + "'";

                                if (txtDurationITI.Text.Trim() != "")
                                    xSQL += ",ITI_DURATION = '" + txtDurationITI.Text.Trim().ToUpper() + "'";

                                if (txtSubITI.Text.Trim() != "")
                                    xSQL += ",ITI_SUBJECTS = '" + txtSubITI.Text.Trim().ToUpper() + "'";

                                //if (txtDivITI.Text.Trim() != "")
                                //    xSQL += ",ITI_DIVISION = '" + txtDivITI.Text.Trim().ToUpper() + "'";

                                if (txtITIPercent.Text.Trim() != "")
                                    xSQL += ",ITI_PERCENT = " + txtITIPercent.Text.Trim() + "";

                                if (txtITIDate.Text.Trim() != "")
                                    xSQL += ",ITI_PASSING_DATE = '" + txtITIDate.Text.Trim().ToUpper() + "'";
                            }
                            else
                            {
                                xSQL += ",ITI_INST = null, ITI_NATURE= null, ITI_DURATION = null, ITI_SUBJECTS = null, ITI_DIVISION=null, ITI_PERCENT=null,ITI_PASSING_DATE=null";
                            }
                        }

                        if (divDiploma.Visible)
                        {
                            if (txtDip.Text.Trim() != "")
                            {
                                if (txtDip.Text.Trim() != "")
                                    xSQL += ",DIPLOMA_INST = '" + txtDip.Text.Trim().ToUpper() + "'";

                                if (ddlNatureDip.SelectedIndex > 0)
                                    xSQL += ",DIPLOMA_NATURE = '" + ddlNatureDip.SelectedItem.Text + "'";

                                if (txtDurationDip.Text.Trim() != "")
                                    xSQL += ",DIPLOMA_DURATION = '" + txtDurationDip.Text.Trim().ToUpper() + "'";

                                if (txtSubDip.Text.Trim() != "")
                                    xSQL += ",DIPLOMA_SUBJECTS = '" + txtSubDip.Text.Trim().ToUpper() + "'";

                                //if (txtDivDip.Text.Trim() != "")
                                //    xSQL += ",DIPLOMA_DIVISION = '" + txtDivDip.Text.Trim().ToUpper() + "'";

                                if (txtDipPer.Text.Trim() != "")
                                    xSQL += ",DIPLOMA_PERCENT = " + txtDipPer.Text.Trim() + "";

                                if (txtDipDate.Text.Trim() != "")
                                    xSQL += ",DIPLOMA_PASSING_DATE = '" + txtDipDate.Text.Trim().ToUpper() + "'";
                            }
                            else
                            {
                                xSQL += ",DIPLOMA_INST = null, DIPLOMA_NATURE= null, DIPLOMA_DURATION = null, DIPLOMA_SUBJECTS = null,DIPLOMA_DIVISION=null,DIPLOMA_PERCENT=null,DIPLOMA_PASSING_DATE=null";
                            }
                        }


                        if (divNAC.Visible)
                        {
                            //if (ddlNac.SelectedIndex>0)
                            //    xSQL += ",NAC_NCTVT = '" + ddlNac.SelectedItem.Text + "'";

                            if (txtNacUniv.Text.Trim() != "")
                                xSQL += ",NAC_UNIV = '" + txtNacUniv.Text.Trim() + "'";

                            xSQL += ",NAC_NCTVT = 'NAC'";

                            if (txtNacDate.Text.Trim().ToUpper() != "")
                            {
                                string xDate = DateTime.Parse(txtNacDate.Text).ToString("dd/MM/yyyy");
                                xSQL += ",NAC_NCTVT_PASSING_DATE= '" + xDate + "'";
                            }
                            if (txtNacPer.Text.Trim().ToUpper() != "")
                                xSQL += ",NAC_NCTVT_PERCENT= " + txtNacPer.Text.Trim() + "";
                        }
                        else
                        {
                            xSQL += ",NAC_UNIV = null, NAC_NCTVT= null, NAC_NCTVT_PASSING_DATE = null, NAC_NCTVT_PERCENT = null";
                        }

                        if (divRank.Visible)
                        {
                            if (txtRank.Text.Length > 0)
                                xSQL += ",RANK_HELD2 = '" + txtRank.Text.Trim() + "'";

                            if (txtFrom.Text.Trim().ToUpper() != "")
                            {
                                string xDate = DateTime.Parse(txtFrom.Text).ToString("dd/MM/yyyy");
                                xSQL += ",JOINING_DATE= '" + xDate + "'";
                            }

                            if (txtUpto.Text.Trim().ToUpper() != "")
                            {
                                string xDate = DateTime.Parse(txtUpto.Text).ToString("dd/MM/yyyy");
                                xSQL += ",LEAVING_DATE= '" + xDate + "'";
                            }

                            if (txtPeriod.Text.Trim() != "")
                                xSQL += ",PERIOD = '" + txtPeriod.Text.Trim() + "'";
                        }
                        else
                        {
                            xSQL += ",RANK_HELD2 = null, JOINING_DATE= null, LEAVING_DATE = null, PERIOD = null";
                        }

                        if (divESM.Visible)
                        {
                            if (txtESMCert.Text.Trim() != "")
                                xSQL += ",ESM_CERT_NO = '" + txtESMCert.Text.Trim() + "'";

                            if (txtESMDate.Text.Trim().ToUpper() != "")
                            {
                                string xDate = DateTime.Parse(txtESMDate.Text).ToString("dd/MM/yyyy");
                                xSQL += ",ESM_PASSING_DATE= '" + xDate + "'";
                            }
                        }
                        else
                        {
                            xSQL += ",ESM_CERT_NO = null, ESM_PASSING_DATE= null";
                        }

                        if (!string.IsNullOrEmpty(txtOrg1.Text.Trim()))
                        {
                            xSQL += txtOrg1.Text.Trim() == "" ? ", ORGANISATION_NAME_EXP1=null" : ", ORGANISATION_NAME_EXP1='" + txtOrg1.Text.Trim() + "'";

                            xSQL += txtPosition1.Text.Trim() == "" ? ", DESIGNATION_EXP1=null" : ", DESIGNATION_EXP1='" + txtPosition1.Text.Trim() + "'";

                            xSQL += txtPay1.Text.Trim() == "" ? " ,SALARY_PM_EXP1=null" : " ,SALARY_PM_EXP1='" + txtPay1.Text.Trim() + "'";

                            xSQL += txtBegin1.Text.Trim() == "" ? " ,JOIN_DATE_EXP1=null" : " ,JOIN_DATE_EXP1='" + txtBegin1.Text.Trim() + "'";

                            xSQL += txtEnd1.Text.Trim() == "" ? " ,END_DATE_EXP1=null" : " ,END_DATE_EXP1='" + txtEnd1.Text.Trim() + "'";

                            xSQL += TextBox1.Text.Trim() == "" ? " ,PERIOD_EXP1=null" : ", PERIOD_EXP1='" + TextBox1.Text.Trim() + "'";

                            xSQL += txtDays1.Text.Trim() == "" ? " ,DAYS_EXP1=null" : " ,DAYS_EXP1='" + txtDays1.Text.Trim() + "'";

                            xSQL += txtDescs1.Text.Trim() == "" ? " ,REMARKS_EXP1=null" : " ,REMARKS_EXP1='" + txtDescs1.Text.Trim() + "'";


                            //if (!string.IsNullOrEmpty(txtOrg2.Text.Trim()))
                            //{
                            xSQL += txtOrg2.Text.Trim() == "" ? " , ORGANISATION_NAME_EXP2=null" : " , ORGANISATION_NAME_EXP2='" + txtOrg2.Text.Trim() + "'";

                            xSQL += txtOrg2.Text.Trim() == "" ? " , DESIGNATION_EXP2=null" : " , DESIGNATION_EXP2='" + txtPosition2.Text.Trim() + "'";

                            xSQL += txtOrg2.Text.Trim() == "" ? " , SALARY_PM_EXP2=null" : " , SALARY_PM_EXP2='" + txtPay2.Text.Trim() + "'";

                            xSQL += txtOrg2.Text.Trim() == "" ? " , JOIN_DATE_EXP2=null" : " , JOIN_DATE_EXP2='" + txtBegin2.Text.Trim() + "'";

                            xSQL += txtOrg2.Text.Trim() == "" ? " , END_DATE_EXP2=null" : " , END_DATE_EXP2='" + txtEnd2.Text.Trim() + "'";

                            xSQL += txtOrg2.Text.Trim() == "" ? " , PERIOD_EXP2=null" : " , PERIOD_EXP2='" + txtPeriod2.Text.Trim() + "'";

                            xSQL += txtOrg2.Text.Trim() == "" ? " , DAYS_EXP2=null" : " , DAYS_EXP2='" + txtDays2.Text.Trim() + "'";

                            xSQL += txtOrg2.Text.Trim() == "" ? " ,REMARKS_EXP2=null" : " ,REMARKS_EXP2='" + txtDesc2.Text.Trim() + "'";

                            //}
                            //if (!string.IsNullOrEmpty(txtOrg3.Text.Trim()))
                            //{
                            xSQL += txtOrg3.Text.Trim() == "" ? " , ORGANISATION_NAME_EXP3=null" : " , ORGANISATION_NAME_EXP3='" + txtOrg3.Text.Trim() + "'";

                            xSQL += txtOrg3.Text.Trim() == "" ? " , DESIGNATION_EXP3=null" : " , DESIGNATION_EXP3='" + txtPosition3.Text.Trim() + "'";

                            xSQL += txtOrg3.Text.Trim() == "" ? " , SALARY_PM_EXP3=null" : " , SALARY_PM_EXP3='" + txtPay3.Text.Trim() + "'";

                            xSQL += txtOrg3.Text.Trim() == "" ? " , JOIN_DATE_EXP3=null" : " , JOIN_DATE_EXP3='" + txtBegin3.Text.Trim() + "'";

                            xSQL += txtOrg3.Text.Trim() == "" ? " , END_DATE_EXP3=null" : " , END_DATE_EXP3='" + txtEnd3.Text.Trim() + "'";

                            xSQL += txtOrg3.Text.Trim() == "" ? " , PERIOD_EXP3=null" : " , PERIOD_EXP3='" + txtPeriod3.Text.Trim() + "'";

                            xSQL += txtOrg3.Text.Trim() == "" ? " , DAYS_EXP3=null" : " , DAYS_EXP3='" + txtDays3.Text.Trim() + "'";

                            xSQL += txtOrg3.Text.Trim() == "" ? " , REMARKS_EXP3=null" : " , REMARKS_EXP3='" + txtDesc3.Text.Trim() + "'";

                            //}

                            //if (!string.IsNullOrEmpty(txtOrg4.Text.Trim()))
                            //{
                            xSQL += txtOrg4.Text.Trim() == "" ? " , ORGANISATION_NAME_EXP4=null" : " , ORGANISATION_NAME_EXP4='" + txtOrg4.Text.Trim() + "'";

                            xSQL += txtOrg4.Text.Trim() == "" ? " , DESIGNATION_EXP4=null" : " , DESIGNATION_EXP4='" + txtPosition4.Text.Trim() + "'";

                            xSQL += txtOrg4.Text.Trim() == "" ? " , SALARY_PM_EXP4=null" : " , SALARY_PM_EXP4='" + txtPay4.Text.Trim() + "'";

                            xSQL += txtOrg4.Text.Trim() == "" ? " ,JOIN_DATE_EXP4=null" : " ,JOIN_DATE_EXP4='" + txtBegin4.Text.Trim() + "'";

                            xSQL += txtOrg4.Text.Trim() == "" ? " , END_DATE_EXP4=null" : " , END_DATE_EXP4='" + txtEnd4.Text.Trim() + "'";

                            xSQL += txtOrg4.Text.Trim() == "" ? " , PERIOD_EXP4=null" : " , PERIOD_EXP4='" + txtPeriod4.Text.Trim() + "'";

                            xSQL += txtOrg4.Text.Trim() == "" ? " , DAYS_EXP4=null" : " , DAYS_EXP4='" + txtDays4.Text.Trim() + "'";

                            xSQL += txtOrg4.Text.Trim() == "" ? " , REMARKS_EXP4=null" : " ,REMARKS_EXP4='" + txtDesc4.Text.Trim() + "'";

                            //}

                            //if (!string.IsNullOrEmpty(txtOrg5.Text.Trim()))
                            //{
                            xSQL += txtOrg5.Text.Trim() == "" ? " , ORGANISATION_NAME_EXP5=null" : " , ORGANISATION_NAME_EXP5='" + txtOrg5.Text.Trim() + "'";

                            xSQL += txtOrg5.Text.Trim() == "" ? " , DESIGNATION_EXP5=null" : " , DESIGNATION_EXP5='" + txtPosition5.Text.Trim() + "'";

                            xSQL += txtOrg5.Text.Trim() == "" ? " , SALARY_PM_EXP5=null" : " , SALARY_PM_EXP5='" + txtPay5.Text.Trim() + "'";

                            xSQL += txtOrg5.Text.Trim() == "" ? " , JOIN_DATE_EXP5=null" : " , JOIN_DATE_EXP5='" + txtBegin5.Text.Trim() + "'";

                            xSQL += txtOrg5.Text.Trim() == "" ? " , END_DATE_EXP5=null" : " , END_DATE_EXP5='" + txtEnd5.Text.Trim() + "'";

                            xSQL += txtOrg5.Text.Trim() == "" ? " , PERIOD_EXP5=null" : " , PERIOD_EXP5='" + txtPeriod5.Text.Trim() + "'";

                            xSQL += txtOrg5.Text.Trim() == "" ? " , DAYS_EXP5=null" : " , DAYS_EXP5='" + txtDays5.Text.Trim() + "'";

                            xSQL += txtOrg5.Text.Trim() == "" ? " , REMARKS_EXP5=null" : " , REMARKS_EXP5='" + txtDesc5.Text.Trim() + "'";

                            //}
                        }

                        if (!string.IsNullOrEmpty(txtProgram1.Text.Trim()))
                        {
                            if (xSQL.Trim().Length == 0)
                                xSQL += txtProgram1.Text.Trim() == "" ? ", ORGANISATION_NAME_TRAINING1=null" : " , ORGANISATION_NAME_TRAINING1='" + txtProgram1.Text.Trim() + "'";

                            else
                                xSQL += txtProgram1.Text.Trim() == "" ? " , ORGANISATION_NAME_TRAINING1=null" : " , ORGANISATION_NAME_TRAINING1='" + txtProgram1.Text.Trim() + "'";

                            xSQL += txtOrgName1.Text.Trim() == "" ? " , PROGRAM_NAME_TRAINING1=null" : " , PROGRAM_NAME_TRAINING1='" + txtOrgName1.Text.Trim() + "'";

                            xSQL += txtBegDate1.Text.Trim() == "" ? " , JOIN_DATE_TRAINING1=null" : " , JOIN_DATE_TRAINING1='" + txtBegDate1.Text.Trim() + "'";

                            xSQL += txtEndDate1.Text.Trim() == "" ? " , END_DATE_TRAINING1=null" : " , END_DATE_TRAINING1='" + txtEndDate1.Text.Trim() + "'";

                            //if (!string.IsNullOrEmpty(txtProgram2.Text.Trim()))
                            //{
                            //    if (xSQL.Trim().Length == 0)
                            //        xSQL += txtProgram2.Text.Trim() == "" ? " , ORGANISATION_NAME_TRAINING2=null" : " , ORGANISATION_NAME_TRAINING2='" + txtProgram2.Text.Trim() + "'";
                            //    //xSQL += "ORGANISATION_NAME_TRAINING2='" + txtProgram2.Text.Trim() + "'";
                            //    else
                            //        xSQL += txtProgram2.Text.Trim() == "" ? " , ORGANISATION_NAME_TRAINING2=null" : " , ORGANISATION_NAME_TRAINING2='" + txtProgram2.Text.Trim() + "'";
                            //    // xSQL += ", ORGANISATION_NAME_TRAINING2='" + txtProgram2.Text.Trim() + "'";

                            //    if (!string.IsNullOrEmpty(txtOrgName2.Text.Trim()))
                            //    {
                            //        xSQL += txtOrgName2.Text.Trim() == "" ? " , PROGRAM_NAME_TRAINING2=null" : " , PROGRAM_NAME_TRAINING2='" + txtOrgName2.Text.Trim() + "'";
                            //        //xSQL += ", PROGRAM_NAME_TRAINING2='" + txtOrgName2.Text.Trim() + "'";
                            //    }
                            //    if (!string.IsNullOrEmpty(txtBegDate2.Text.Trim()))
                            //    {
                            //        xSQL += txtBegDate2.Text.Trim() == "" ? " , JOIN_DATE_TRAINING2=null" : " , JOIN_DATE_TRAINING2='" + txtBegDate2.Text.Trim() + "'";
                            //        //xSQL += ", JOIN_DATE_TRAINING2='" + txtBegDate2.Text.Trim() + "'";
                            //    }
                            //    if (!string.IsNullOrEmpty(txtEndDate2.Text.Trim()))
                            //    {
                            //        xSQL += txtEndDate2.Text.Trim() == "" ? " , END_DATE_TRAINING2=null" : " , END_DATE_TRAINING2='" + txtEndDate2.Text.Trim() + "'";
                            //        //xSQL += ", END_DATE_TRAINING2='" + txtEndDate2.Text.Trim() + "'";
                            //    }
                            //}

                        }

                        if (ddlVRS.SelectedIndex > 0)
                            xSQL += ", VRS_TAKEN='" + ddlVRS.SelectedItem.Text.Trim() + "'";

                        if (ddlInterview.SelectedIndex == 1)
                        {
                            if (xSQL.Trim().Length == 0)
                                xSQL += "INTERVIEWED_BY_HAL='Yes'";
                            else
                                xSQL += ", INTERVIEWED_BY_HAL='Yes'";

                            if (!string.IsNullOrEmpty(txtIntPost.Text.Trim()))
                                xSQL += ", POST_INTERVIEWED='" + txtIntPost.Text.Trim() + "'";

                            if (!string.IsNullOrEmpty(txtIntDate.Text.Trim()))
                                xSQL += ", INTERVIEWED_DATE='" + DateTime.Parse(txtIntDate.Text).ToString("dd/MM/yyyy") + "'";

                            if (!string.IsNullOrEmpty(txtIntVenue.Text.Trim()))
                                xSQL += ", INTERVIEWED_VENUE='" + txtIntVenue.Text.Trim() + "'";
                        }
                        else
                        {
                            if (xSQL.Trim().Length == 0)
                                xSQL += "INTERVIEWED_BY_HAL='No',POST_INTERVIEWED=null,INTERVIEWED_DATE=null,INTERVIEWED_VENUE=null";
                            else
                                xSQL += ",INTERVIEWED_BY_HAL='No',POST_INTERVIEWED=null,INTERVIEWED_DATE=null,INTERVIEWED_VENUE=null";
                        }

                        if (ddlRelative.SelectedIndex == 1)
                        {
                            if (xSQL.Trim().Length == 0)
                                xSQL += "RELATIVE_WITH_HAL='Yes'";
                            else
                                xSQL += ",RELATIVE_WITH_HAL='Yes'";

                            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
                                xSQL += txtName.Text.Trim() == "" ? " , RELATIVE_NAME=null" : " , RELATIVE_NAME='" + txtName.Text.Trim() + "'";
                            //xSQL += ", RELATIVE_NAME='" + txtName.Text.Trim() + "'";

                            if (!string.IsNullOrEmpty(txtDesig.Text.Trim()))
                                xSQL += txtDesig.Text.Trim() == "" ? " , RELATIVE_DESIG=null" : " , RELATIVE_DESIG='" + txtDesig.Text.Trim() + "'";
                            //xSQL += ", RELATIVE_DESIG='" + txtDesig.Text.Trim() + "'";

                            if (!string.IsNullOrEmpty(txtDiv.Text.Trim()))
                                xSQL += txtDiv.Text.Trim() == "" ? " , RELATIVE_DIVISION=null" : " , RELATIVE_DIVISION='" + txtDiv.Text.Trim() + "'";
                                xSQL += txtDesc.Text.Trim() == "" ? " , RELATIVE_DESC=null" : " , RELATIVE_DESC='" + txtDesc.Text.Trim() + "'";
                            //xSQL += ", RELATIVE_DESC='" + txtDesc.Text.Trim() + "'";
                        }
                        else
                        {
                            if (xSQL.Trim().Length == 0)
                                xSQL += "RELATIVE_WITH_HAL='No',RELATIVE_NAME=null,RELATIVE_DESIG=null,RELATIVE_DIVISION=null,RELATIVE_DESC=null";
                            else
                                xSQL += ",RELATIVE_WITH_HAL='No',RELATIVE_NAME=null,RELATIVE_DESIG=null,RELATIVE_DIVISION=null,RELATIVE_DESC=null";
                        }

                        if (ddlPolitics.SelectedIndex == 1)
                        {
                            if (xSQL.Trim().Length == 0)
                                xSQL += "POLITICAL_RELATION='Yes'";
                            else
                                xSQL += ",POLITICAL_RELATION='Yes'";

                            if (!string.IsNullOrEmpty(txtParty.Text.Trim()))
                                xSQL += txtParty.Text.Trim() == "" ? " , POLITICAL_PARTY_NAME=null" : " , POLITICAL_PARTY_NAME='" + txtParty.Text.Trim() + "'";
                            //xSQL += ", POLITICAL_PARTY_NAME='" + txtParty.Text.Trim() + "'";

                            if (!string.IsNullOrEmpty(txtParticular.Text.Trim()))
                                xSQL += txtParticular.Text.Trim() == "" ? " , POLITICAL_ACTIVITY=null" : " , POLITICAL_ACTIVITY='" + txtParticular.Text.Trim() + "'";
                            //xSQL += ", POLITICAL_ACTIVITY='" + txtParticular.Text.Trim() + "'";

                            if (!string.IsNullOrEmpty(txtMemPeriod.Text.Trim()))
                                xSQL += txtMemPeriod.Text.Trim() == "" ? " , POLITICAL_PERIOD=null" : " , POLITICAL_PERIOD='" + txtMemPeriod.Text.Trim() + "'";
                            //xSQL += ", POLITICAL_PERIOD='" + txtMemPeriod.Text.Trim() + "'";

                            if (!string.IsNullOrEmpty(txtNature.Text.Trim()))
                                xSQL += txtNature.Text.Trim() == "" ? " , POLITICAL_PARTICIPATION=null" : " , POLITICAL_PARTICIPATION='" + txtNature.Text.Trim() + "'";
                            //xSQL += ", POLITICAL_PARTICIPATION='" + txtNature.Text.Trim() + "'";

                            if (!string.IsNullOrEmpty(txtOffice.Text.Trim()))
                                xSQL += txtOffice.Text.Trim() == "" ? " , POLITICAL_OFFICE_HELD=null" : " , POLITICAL_OFFICE_HELD='" + txtOffice.Text.Trim() + "'";
                            //xSQL += ", POLITICAL_OFFICE_HELD='" + txtOffice.Text.Trim() + "'";
                        }
                        else
                        {
                            if (xSQL.Trim().Length == 0)
                                xSQL += "POLITICAL_RELATION='No',POLITICAL_PARTY_NAME=null,POLITICAL_ACTIVITY=null,POLITICAL_PERIOD=null,POLITICAL_PARTICIPATION=null,POLITICAL_OFFICE_HELD=null";
                            else
                                xSQL += ",POLITICAL_RELATION='No',POLITICAL_PARTY_NAME=null,POLITICAL_ACTIVITY=null,POLITICAL_PERIOD=null,POLITICAL_PARTICIPATION=null,POLITICAL_OFFICE_HELD=null";
                        }

                        xSQL = "UPDATE APPLICANT SET  " + xSQL + " WHERE USERID='" + appNo + "'";

                        int rex = site.executeNonQuery(xSQL);
                        if (rex == 0)
                        {
                            lblStatus.Text = "Not able save the records!";
                            lblStatus.Visible = true;
                        }
                        else
                        {
                            //rex = site.executeNonQuery("update APPLICANT set UPLOAD_PAGE=null,PHOTO=null,SIGN=null,AADHAR_CARD=null WHERE APPLICATION_NO='" + appNo + "'");
                            Response.Redirect("EducationPreview", false);
                        }
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
            txtEdu10.Text = "";
            txtPassDate10.Text = "";
            txtPercent10.Text = "";

            Clear12th();

            ClearITI();
        }
        void ClearITI()
        {
            txtITI.Text = "";
            txtITIDate.Text = "";
            txtITIPercent.Text = "";
        }
        void Clear12th()
        {
            txtEdu12.Text = "";
            txtPassDate12.Text = "";
            txtPercent12.Text = "";
        }
        protected void txtUpto_TextChanged(object sender, EventArgs e)
        {
            if (txtFrom.Text.Trim() != "" && txtUpto.Text.Trim() != "")
            {
                if (!string.IsNullOrEmpty(txtFrom.Text) && !string.IsNullOrEmpty(txtUpto.Text))
                {
                    DateTime cuttoffDate = DateTime.Parse(txtUpto.Text.Trim());
                    DateTime candDateofBirth = DateTime.Parse(txtFrom.Text.Trim());
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
                    txtPeriod.Text = string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                        xYear, (xYear == 1) ? "" : "s",
                        xMon, (xMon == 1) ? "" : "s",
                        xDays, (xDays == 1) ? "" : "s");

                    if (xYear >= 3)
                    {
                        btnSave.Enabled = true;
                        //txtPeriod.Text = site.calculatePeriod(txtFrom.Text.Trim(), txtUpto.Text.Trim());
                        lblUpto.Visible = false;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                        //txtPeriod.Text = "";
                        lblUpto.Text = "Minimum 3 years of service required";
                        lblUpto.ForeColor = Color.Red;
                        lblUpto.Visible = true;
                    }
                }

            }
        }
        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {
            txtUpto.Text = "";
            txtUpto.Focus();
        }
        protected void btnAdd_ClickEXP(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string buttonId = button.ID.Trim();

            if (!string.IsNullOrEmpty(buttonId))
            {
                string btnId = buttonId.Trim().Substring(buttonId.Trim().Length - 1, 1);
                ValidateWorkExperience(Convert.ToInt32(btnId));
            }

            if (lblOrg.Visible == false)
            {
                if (buttonId == "btnAdd1")
                {
                    btnAdd1.Visible = false;
                    divExp2.Visible = true;
                    divDesc2.Visible = true;
                }
                else if (buttonId == "btnAdd2")
                {
                    btnAdd2.Visible = false;
                    divExp3.Visible = true;
                    divDesc3.Visible = true;
                }
                else if (buttonId == "btnAdd3")
                {
                    btnAdd3.Visible = false;
                    divExp4.Visible = true;
                    divDesc4.Visible = true;
                }
                else if (buttonId == "btnAdd4")
                {
                    btnAdd4.Visible = false;
                    divExp5.Visible = true;
                    divDesc5.Visible = true;
                    btnAdd5.Visible = false;
                }
            }
        }
        void ValidateWorkExperience(int xVal)
        {
            lblOrg.Visible = false;
            lblPosition.Visible = false;
            lblPay.Visible = false;
            lblBegin.Visible = false;
            lblEnd.Visible = false;
            lblDescs.Visible = false;

            if (xVal == 1)
            {
                if (txtOrg1.Text.Trim() == "")
                {
                    lblOrg.Visible = true;
                }
                if (txtPosition1.Text.Trim() == "")
                {
                    lblPosition.Visible = true;
                }
                if (txtPay1.Text.Trim() == "")
                {
                    lblPay.Visible = true;
                }
                if (txtBegin1.Text.Trim() == "")
                {
                    lblBegin.Visible = true;
                }
                if (txtEnd1.Text.Trim() == "")
                {
                    lblEnd.Visible = true;
                }
                if (txtDescs1.Text.Trim() == "")
                {
                    lblDescs.Visible = true;
                    lblOrg.Visible = false;
                }
            }
            else if (xVal == 2)
            {
                if (txtOrg2.Text.Trim() == "")
                {
                    lblOrg.Visible = true;
                }
                if (txtPosition2.Text.Trim() == "")
                {
                    lblPosition.Visible = true;
                }
                if (txtPay2.Text.Trim() == "")
                {
                    lblPay.Visible = true;
                }
                if (txtBegin2.Text.Trim() == "")
                {
                    lblBegin.Visible = true;
                }
                if (txtEnd2.Text.Trim() == "")
                {
                    lblEnd.Visible = true;
                }
                if (txtDesc2.Text.Trim() == "")
                {
                    lblDescs.Visible = true;
                    lblOrg.Visible = false;
                }
            }
            else if (xVal == 3)
            {
                if (txtOrg3.Text.Trim() == "")
                {
                    lblOrg.Visible = true;
                }
                if (txtPosition3.Text.Trim() == "")
                {
                    lblPosition.Visible = true;
                }
                if (txtPay3.Text.Trim() == "")
                {
                    lblPay.Visible = true;
                }
                if (txtBegin3.Text.Trim() == "")
                {
                    lblBegin.Visible = true;
                }
                if (txtEnd3.Text.Trim() == "")
                {
                    lblEnd.Visible = true;
                }
                if (txtDesc3.Text.Trim() == "")
                {
                    lblDescs.Visible = true;
                    lblOrg.Visible = false;
                }
            }
            else if (xVal == 4)
            {
                if (txtOrg4.Text.Trim() == "")
                {
                    lblOrg.Visible = true;
                }
                if (txtPosition4.Text.Trim() == "")
                {
                    lblPosition.Visible = true;
                }
                if (txtPay4.Text.Trim() == "")
                {
                    lblPay.Visible = true;
                }
                if (txtBegin4.Text.Trim() == "")
                {
                    lblBegin.Visible = true;
                }
                if (txtEnd4.Text.Trim() == "")
                {
                    lblEnd.Visible = true;
                }
                if (txtDesc4.Text.Trim() == "")
                {
                    lblDescs.Visible = true;
                    lblOrg.Visible = false;
                }
            }
            else if (xVal == 5)
            {
                if (txtOrg5.Text.Trim() == "")
                {
                    lblOrg.Visible = true;
                }
                if (txtPosition5.Text.Trim() == "")
                {
                    lblPosition.Visible = true;
                }
                if (txtPay5.Text.Trim() == "")
                {
                    lblPay.Visible = true;
                }
                if (txtBegin5.Text.Trim() == "")
                {
                    lblBegin.Visible = true;
                }
                if (txtEnd5.Text.Trim() == "")
                {
                    lblEnd.Visible = true;
                }
                if (txtDesc5.Text.Trim() == "")
                {
                    lblDescs.Visible = true;
                    lblOrg.Visible = false;
                }
            }
        }
        //protected void btnAddRex_ClickTrain(object sender, EventArgs e)
        //{
        //    Button button = sender as Button;
        //    string buttonId = button.ID.Trim();

        //    if (!string.IsNullOrEmpty(buttonId))
        //    {
        //        string btnId = buttonId.Trim().Substring(buttonId.Trim().Length - 1, 1);
        //        ValidateApprenticeship(Convert.ToInt32(btnId));
        //    }

        //    if (divTraining1.Visible == true)
        //    {
        //        if (buttonId == "btnAddRex1")
        //        {
        //            btnAddRex1.Visible = false;
        //            btnAddRex2.Visible = false;
        //            divTraining2.Visible = true;
        //        }
        //    }


        //    //string xOrg = "", xPosition = "", xBeg = "", xEnd = "", xPeriod = "",  xQuery = "";
        //    //int rex = 0;
        //    //ViewState["SLN"] = Convert.ToInt32(ViewState["SLN"]) + 1;

        //    //INSERT PREVIOUS JOB RECORDS
        //    //if (txtOrg1.Text.Trim() != "")
        //    //    xOrg = txtOrg1.Text.Trim();

        //    //if (txtProgram.Text.Trim() != "")
        //    //    xPosition = txtProgram.Text.Trim();

        //    //if (txtDtBeg.Text.Trim() != "")
        //    //    xBeg = txtDtBeg.Text.Trim().ToString();

        //    //if (txtDtEnd.Text.Trim() != "")
        //    //    xEnd = txtDtEnd.Text.Trim();

        //    //if (txtPeriod1.Text.Trim() != "")
        //    //    xPeriod = txtPeriod1.Text.Trim();

        //    //if (txtDays.Text.Trim() != "")
        //    //    xDays = txtDays.Text.Trim();

        //    //xQuery = "insert into TRAINING_PROGRAM(APPLICATION_NO,ORGANISATION_NAME,PROGRAM_NAME,JOIN_DATE,END_DATE,DATED)";
        //    //xQuery += " values('" + appNo + "','" + xOrg + "','" + xPosition + "','" + xBeg + "','" + xEnd + "',getdate())";


        //}
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
        //void ClearScreenTraining()
        //{
        //    txtOrg1.Text = string.Empty;
        //    txtProgram.Text = string.Empty;
        //    txtDtBeg.Text = string.Empty;
        //    txtDtEnd.Text = string.Empty;

        //}


        protected void txtBegin_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            string txtId = txt.ID.Trim();

            if (!string.IsNullOrEmpty(txtId))
            {
                string btnId = txtId.Trim().Substring(txtId.Trim().Length - 1, 1);
                if (btnId == "1")
                {
                    txtEnd1.Text = "";
                    txtEnd1.Focus();
                }
                else if (btnId == "2")
                {
                    txtEnd2.Text = "";
                    txtEnd2.Focus();
                }
                else if (btnId == "3")
                {
                    txtEnd3.Text = "";
                    txtEnd3.Focus();
                }
                else if (btnId == "4")
                {
                    txtEnd4.Text = "";
                    txtEnd4.Focus();
                }
                else if (btnId == "5")
                {
                    txtEnd5.Text = "";
                    txtEnd5.Focus();
                }
            }
        }
        protected void txtEnd_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            lblStatus.Text = "";

            TextBox txt = sender as TextBox;
            string txtId = txt.ID.Trim();

            if (!string.IsNullOrEmpty(txtId))
            {
                int TotDays = 0;
                string yDays = "";
                string btnId = txtId.Trim().Substring(txtId.Trim().Length - 1, 1);
                if (btnId == "1")
                {
                    TextBox1.Text = CalcPeriod(txtBegin1.Text.Trim(), txtEnd1.Text.Trim(), ref yDays);
                    txtDays1.Text = yDays;
                    if (yDays.Trim().Length > 0)
                        TotDays = Convert.ToInt32(txtDays1.Text);
                }
                else if (btnId == "2")
                {
                    //check date overlapping
                    if ((txtBegin2.Text.Trim() != "") && (txtEnd1.Text.Trim() != ""))
                    {
                        string xx = ValidateOverlappingDate(txtBegin2.Text.Trim(), txtEnd1.Text.Trim());
                        if (xx == "NO")
                        {
                            lblBegin.Visible = true;
                            lblBegin.Text = "Joining Date is Overlapping with Previous Date";
                            return;
                        }
                        else
                        {
                            lblBegin.Visible = false;
                            txtPeriod2.Text = CalcPeriod(txtBegin2.Text.Trim(), txtEnd2.Text.Trim(), ref yDays);
                            txtDays2.Text = yDays;
                            if (yDays.Trim().Length > 0)
                            {
                                TotDays = Convert.ToInt32(txtDays1.Text) + Convert.ToInt32(txtDays2.Text);
                            }
                        }
                    }
                }
                else if (btnId == "3")
                {
                    //check date overlapping
                    if ((txtBegin3.Text.Trim() != "") && (txtEnd2.Text.Trim() != ""))
                    {
                        string xx = ValidateOverlappingDate(txtBegin3.Text.Trim(), txtEnd2.Text.Trim());
                        if (xx == "NO")
                        {
                            lblBegin.Visible = true;
                            lblBegin.Text = "Joining Date is Overlapping with Previous Date";
                            return;
                        }
                        else
                        {
                            lblBegin.Visible = false;
                            txtPeriod3.Text = CalcPeriod(txtBegin3.Text.Trim(), txtEnd3.Text.Trim(), ref yDays);
                            txtDays3.Text = yDays;
                            if (yDays.Trim().Length > 0)
                            {
                                TotDays = Convert.ToInt32(txtDays1.Text) + Convert.ToInt32(txtDays2.Text) + Convert.ToInt32(txtDays3.Text);
                            }
                        }
                    }
                }
                else if (btnId == "4")
                {
                    //check date overlapping
                    if ((txtBegin4.Text.Trim() != "") && (txtEnd3.Text.Trim() != ""))
                    {
                        string xx = ValidateOverlappingDate(txtBegin4.Text.Trim(), txtEnd3.Text.Trim());
                        if (xx == "NO")
                        {
                            lblBegin.Visible = true;
                            lblBegin.Text = "Joining Date is Overlapping with Previous Date";
                            return;
                        }
                        else
                        {
                            lblBegin.Visible = false;
                            txtPeriod4.Text = CalcPeriod(txtBegin4.Text.Trim(), txtEnd4.Text.Trim(), ref yDays);
                            txtDays4.Text = yDays;
                            if (yDays.Trim().Length > 0)
                            {
                                TotDays = Convert.ToInt32(txtDays1.Text) + Convert.ToInt32(txtDays2.Text) + Convert.ToInt32(txtDays3.Text) + Convert.ToInt32(txtDays4.Text);
                            }
                        }
                    }
                }
                else if (btnId == "5")
                {
                    //check date overlapping
                    if ((txtBegin5.Text.Trim() != "") && (txtEnd4.Text.Trim() != ""))
                    {
                        string xx = ValidateOverlappingDate(txtBegin5.Text.Trim(), txtEnd4.Text.Trim());
                        if (xx == "NO")
                        {
                            lblBegin.Visible = true;
                            lblBegin.Text = "Joining Date is Overlapping with Previous Date";
                            return;
                        }
                        else
                        {
                            lblBegin.Visible = false;
                            txtPeriod5.Text = CalcPeriod(txtBegin5.Text.Trim(), txtEnd5.Text.Trim(), ref yDays);
                            txtDays5.Text = yDays;
                            if (yDays.Trim().Length > 0)
                            {
                                TotDays = Convert.ToInt32(txtDays1.Text) + Convert.ToInt32(txtDays2.Text) + Convert.ToInt32(txtDays3.Text) + Convert.ToInt32(txtDays4.Text) + Convert.ToInt32(txtDays5.Text);
                            }
                        }
                    }
                }
                if (TotDays > 0)
                {
                    TimeSpan ts = TimeSpan.FromDays(TotDays);
                    DateTime age = DateTime.MinValue + ts;

                    int xYear = age.Year - 1;
                    int xMon = age.Month - 1;
                    int xDays = age.Day - 1;
                    txtTotPeriod.Text = xYear + "-Year " + xMon + "-Month " + xDays + "-Days";
                }
            }
        }
        public string CalcPeriod(string begDate, string endDate, ref string yDays)
        {
            if (begDate == "" || endDate == "")
            {
                return "";
            }
            else
            {
                //DateTime cuttoffDate = DateTime.Parse(endDate);
                //DateTime candDateofBirth = DateTime.Parse(begDate);
                //int xYear = cuttoffDate.Year - candDateofBirth.Year;
                //int xMon = cuttoffDate.Month - candDateofBirth.Month;
                //if (cuttoffDate.Day < candDateofBirth.Day)
                //{
                //    xMon--;
                //}
                //if (xMon < 0)
                //{
                //    xYear--;
                //    xMon += 12;
                //}
                //int xDays = (cuttoffDate - candDateofBirth.AddMonths((xYear * 12) + xMon)).Days;
                //txtPeriod.Text = string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                //    xYear, (xYear == 1) ? "" : "s",
                //    xMon, (xMon == 1) ? "" : "s",
                //    xDays, (xDays == 1) ? "" : "s");
                //txtDays.Text = xDays.ToString();

                //string asOnYear = DateTime.Parse(endDate).ToString("yyyy");
                //string asOnMon = DateTime.Parse(endDate).ToString("MM");
                //string asOnDays = DateTime.Parse(endDate).ToString("dd");

                //string dobYear = DateTime.Parse(begDate).ToString("yyyy");
                //string dobMon = DateTime.Parse(begDate).ToString("MM");
                //string dobDays = DateTime.Parse(begDate).ToString("dd");

                //DateTime birth = new DateTime(Convert.ToInt32(dobYear), Convert.ToInt32(dobMon), Convert.ToInt32(dobDays));
                //DateTime today = new DateTime(Convert.ToInt32(asOnYear), Convert.ToInt32(asOnMon), Convert.ToInt32(asOnDays));
                //TimeSpan span = today.Subtract(birth);
                //DateTime age = DateTime.MinValue + span;

                //int xYear = age.Year - 1;
                //int xMon = age.Month - 1;
                //int xDays = age.Day - 1;

                //string[] xArr = span.ToString().Split('.');
                //yDays = xArr[0].ToString();

                //string xPeriod = xYear + "Year " + xMon + "Month " + xDays + "Days";
                //return xPeriod;
                int xYear = 0;
                int xMon = 0;
                int xDays = 0;
                if (checkDate(endDate, begDate))
                {
                    string asOnYear = DateTime.Parse(endDate).ToString("yyyy");
                    string asOnMon = DateTime.Parse(endDate).ToString("MM");
                    string asOnDays = DateTime.Parse(endDate).ToString("dd");

                    string dobYear = DateTime.Parse(begDate).ToString("yyyy");
                    string dobMon = DateTime.Parse(begDate).ToString("MM");
                    string dobDays = DateTime.Parse(begDate).ToString("dd");

                    Int32.TryParse(dobYear, out int dobYearInt);
                    Int32.TryParse(dobMon, out int dobMonInt);
                    Int32.TryParse(dobDays, out int dobDaysInt);
                    Int32.TryParse(asOnYear, out int asOnYearInt);
                    Int32.TryParse(asOnMon, out int asOnMonInt);
                    Int32.TryParse(asOnDays, out int asOnDaysInt);
                    DateTime birth = new DateTime(dobYearInt, dobMonInt, dobDaysInt);
                    DateTime today = new DateTime(asOnYearInt, asOnMonInt, asOnDaysInt);
                    TimeSpan span = today.Subtract(birth);
                    DateTime age = DateTime.MinValue + span;

                    xYear = age.Year - 1;
                    xMon = age.Month - 1;
                    xDays = age.Day - 1;

                    string[] xArr = span.ToString().Split('.');
                    if (xArr.Length > 1)
                        yDays = xArr[0].ToString();
                    else
                        yDays = "0";
                }

                string xPeriod = xYear + "Year " + xMon + "Month " + xDays + "Days";
                return xPeriod;

            }
        }
        protected bool checkDate(string d1, string d2)
        {
            if (DateTime.TryParse(d1, out DateTime date1) && DateTime.TryParse(d2, out DateTime date2))
            {
                if (DateTime.Compare(date1, date2) >= 0)
                {
                    return true;
                }
                else { return false; }
            }
            else
            {
                lblBegin.Text = "Wrong date Format";
                lblBegin.Visible = true;
                return false;
            }
        }
        protected bool checkDate(string d1, string d2, out bool wrong)
        {
            if (DateTime.TryParse(d1, out DateTime date1) && DateTime.TryParse(d2, out DateTime date2))
            {
                wrong = false;
                if (DateTime.Compare(date1, date2) >= 0)
                {
                    return true;
                }
                else { return false; }
            }
            else
            {
                wrong = true;
                //lblYear10.Text = "Wrong date Format";
                //lblYear10.Visible = true;
                return false;
            }
        }
        private string ValidateOverlappingDate(string BegDate, string EndDate)
        {
            string xVal = "";
            DateTime date1 = Convert.ToDateTime(EndDate);
            DateTime date2 = Convert.ToDateTime(BegDate);
            int diff = DateTime.Compare(date1, date2);
            if (diff > 0)
            {
                xVal = "NO";
            }
            else
            {
                xVal = "YES";
            }
            return xVal;
        }
        public bool ValidateAppDateOverlap(string begExpDate, string endExpDate)
        {
            DateTime.TryParse(begExpDate, out DateTime start);
            DateTime.TryParse(endExpDate, out DateTime end);
            DateTime.TryParse(txtBegDate1.Text.Trim(), out DateTime startApp);
            DateTime.TryParse(txtEndDate1.Text.Trim(), out DateTime endApp);
            if (DateTime.Compare(start, startApp) > 0 && DateTime.Compare(start, endApp) < 0)
            {
                lblBegin.Text = "Joining date cannot overlap with Apprenticeship Period";
                lblBegin.Visible = true;
                lblEnd.Visible = false;
                return false;
            }
            else if (DateTime.Compare(end, startApp) > 0 && DateTime.Compare(end, endApp) < 0)
            {
                lblEnd.Text = "Leaving date cannot overlap with Apprenticeship Period";
                lblEnd.Visible = true;
                lblBegin.Visible = false;
                return false;
            }
            else
            {
                lblBegin.Text = "Joining Date Required";
                lblEnd.Text = "Leaving Date Required";
                lblEnd.Visible = false;
                lblBegin.Visible = false;
                return true;
            }
        }
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
        protected void chkConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
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