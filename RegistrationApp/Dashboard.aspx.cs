using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationApp
{
    public partial class Dashboard : System.Web.UI.Page
    {
        DataTable dt;
        siteclass site = new siteclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["APPNO"] == null)
                {
                    Response.Redirect("adminlogin", false);
                }
                else
                {
                    if (Session["APPNO"].ToString() == "GTD*786")
                    {
                        if(Session["AUTH"].ToString().ToUpper().Trim() == "ADMIN")
                            btnExport.Visible = true;
                        else
                            btnExport.Visible = false;

                        BindRecords();
                    }
                    else
                    {
                        Response.Redirect("adminlogin", false);
                    }
                }
            }
        }
        void BindRecords()
        {
            try
            {
                string xSql = "select APPLICANT.USERID,APPLICANT.APPLIED_DISCIPLINE,APPLICANT.APPLICANT_NAME,APPLICANT.GENDER,APPLICANT.MARITAL_STATUS,APPLICANT.NATIONALITY,APPLICANT.AADHAR_NO,APPLICANT.MOBILE,APPLICANT.EMAIL,APPLICANT.PASSWORD,APPLICANT.PERSONALINFO_PAGE,APPLICANT.EDUCATION_PAGE,APPLICANT.EXPERIENCE_PAGE,APPLICANT.DOCUMENT_PAGE,CONVERT(VARCHAR(10),APPLICANT.DOB,103) AS DOB1 from APPLICANT";
                dt = site.getdatatable(xSql);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                dt = site.getdatatable("select count(distinct(USERID)) as Total from APPLICANT");
                txtTotal.Text = dt.Rows[0]["Total"].ToString();

                dt = site.getdatatable("select count(distinct(USERID)) as Total from APPLICANT where DOCUMENT_PAGE=1");
                if (dt.Rows.Count > 0)
                    txtComplete.Text = dt.Rows[0]["Total"].ToString();
                else
                    txtComplete.Text = "0";

                txtInComplete.Text = Convert.ToString(Convert.ToUInt32(txtTotal.Text) - Convert.ToUInt32(txtComplete.Text));

            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }

        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            Label lblAppno = (Label)gvr.FindControl("lblAppno");
            string AppNo = lblAppno.Text;
            Session["APPNO"] = AppNo;
            Response.Redirect("Preview",false);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text.Trim() != "")
                {
                    string xQuery = "";
                    if (ddlFilter.SelectedItem.Text.Trim() == "Application No.")
                        xQuery = "APPLICANT.USERID='" + txtSearch.Text.Trim() + "'";
                    else if (ddlFilter.SelectedItem.Text.Trim() == "Mobile No.")
                        xQuery = "APPLICANT.MOBILE='" + txtSearch.Text.Trim() + "'";
                    else if (ddlFilter.SelectedItem.Text.Trim() == "EMail ID")
                        xQuery = "APPLICANT.EMAIL='" + txtSearch.Text.Trim() + "'";
                    else if (ddlFilter.SelectedItem.Text.Trim() == "Aadhar No.")
                        xQuery = "APPLICANT.AADHAR_NO='" + txtSearch.Text.Trim() + "'";

                    string xSql = "select APPLICANT.*,CONVERT(VARCHAR(10),APPLICANT.DOB,103) AS DOB1 from APPLICANT WHERE " + xQuery;
                    dt = site.getdatatable(xSql);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            BindRecords();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindRecords();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }
        private void ExportGridToExcel()
        {
            try
            {
                //both are working

                //if (GridView1.Rows.Count > 0)
                //{
                //    Response.Clear();
                //    Response.Buffer = true;
                //    Response.AddHeader("content-disposition", "attachment;filename=dmi.xls");
                //    Response.Charset = "";
                //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                //    StringWriter sw = new StringWriter();
                //    GridView1.HeaderRow.Style.Add("background-color", "#fff");
                //    GridView1.HeaderRow.Style.Add("color", "#000");
                //    GridView1.HeaderRow.Style.Add("font-weight", "bold");

                //    for (int i = 0; i < GridView1.Rows.Count; i++)
                //    {
                //        GridViewRow grow = GridView1.Rows[i];
                //        grow.BackColor = System.Drawing.Color.White;
                //        grow.Attributes.Add("class", "textmode");
                //    }

                //    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                //    {
                //        GridView1.RenderControl(hw);
                //        Response.Output.Write(sw.ToString());
                //        Response.Flush();
                //        Response.End();
                //    }
                //}

                //string xSql = "SELECT APPLICANT.USERID,APPLICANT.PASSWORD,APPLICANT.APPLICANT_NAME,APPLICANT.GENDER,APPLICANT.MARITAL_STATUS,APPLICANT.NATIONALITY,";
                //xSql += "CONVERT(VARCHAR(10),APPLICANT.DOB,103) AS DOB1,APPLICANT.DOB_DD,APPLICANT.DOB_MM,APPLICANT.DOB_YYYY,APPLICANT.APPLICANT_AGE,APPLICANT.EMAIL,APPLICANT.MOBILE,APPLICANT.ID_DOX,APPLICANT.ID_NO,APPLICANT.APPLIED_DISCIPLINE,APPLICANT.CATEGORY_APPLIED,";
                //xSql += "APPLICANT.CATEGORY_CERT_NO,APPLICANT.CATEGORY_CERT_ISSUE_DATE,APPLICANT.FATHER_NAME,APPLICANT.MOTHER_NAME,APPLICANT.DOMICILE_BIHAR,APPLICANT.DOMICILE_NO,APPLICANT.DOMICILE_ISSUE_DATE,";
                //xSql += "APPLICANT.PH_APPLICANT,APPLICANT.PH_TYPE,APPLICANT.PH_PERCENT,APPLICANT.CURRENT_ADDRESS,APPLICANT.CITY_CA,APPLICANT.DIST_CA,APPLICANT.STATE_CA,APPLICANT.PIN_CA,APPLICANT.PERMANENT_ADDRESS,";
                //xSql += "APPLICANT.CITY_PA,APPLICANT.DIST_PA,APPLICANT.STATE_PA,APPLICANT.PIN_PA,APPLICANT.BOARD_10TH,APPLICANT.BOARD10_PASSING_YEAR,APPLICANT.BOARD10_MARKS_OBTAIN,APPLICANT.BOARD10_TOT_MARKS,APPLICANT.BOARD10_PERCENT,";
                //xSql += "APPLICANT.BOARD_12TH,APPLICANT.BOARD12_BASE,APPLICANT.BOARD12_STREAM,APPLICANT.BOARD12_PASSING_YEAR,APPLICANT.BOARD12_MARKS_OBTAIN,APPLICANT.BOARD12_TOT_MARKS,APPLICANT.BOARD12_PERCENT,APPLICANT.GRADUATION_UNIV,";
                //xSql += "APPLICANT.GRADUATION_STREAM,APPLICANT.GRADUATION_PASSING_YEAR,APPLICANT.GRADUATION_MARKS_OBTAIN,APPLICANT.GRADUATION_TOT_MARKS,APPLICANT.GRADUATION_PERCENT,APPLICANT.POSTGRAD_STREAM,APPLICANT.POSTGRAD_UNIV,";
                //xSql += "APPLICANT.POSTGRAD_PASSING_YEAR,APPLICANT.POSTGRAD_MARKS_OBTAIN,APPLICANT.POSTGRAD_TOT_MARKS,APPLICANT.POSTGRAD_PERCENT,APPLICANT.OTHER_QUAL,APPLICANT.GOVT_JOB,APPLICANT.CURRENTLY_WORKING,APPLICANT.JOB_QUAL_REQ,";
                //xSql += "APPLICANT.UPLOAD_PHOTO,APPLICANT.UPLOAD_SIGN,APPLICANT.UPLOAD_PHOTOID,APPLICANT.UPLOAD_10TH,APPLICANT.UPLOAD_12TH,APPLICANT.UPLOAD_RESUME,";
                //xSql += "APPLICANT.UPLOAD_GRADUATION,APPLICANT.UPLOAD_POSTGRAD,APPLICANT.UPLOAD_DOMICILE,APPLICANT.UPLOAD_CASTE,APPLICANT.UPLOAD_PWD,";
                //xSql += "APPLICANT.DATED,APPLICANT.PERSONALINFO_PAGE,APPLICANT.EDUCATION_PAGE,APPLICANT.WORK_EXP_PAGE,APPLICANT.DOCUMENT_PAGE,APPLICANT.REFERENCE_NO,APPLICANT.Amount,APPLICANT.PAYMENT_STATUS AS STATUS FROM APPLICANT ";
                //xSql += "GROUP BY APPLICANT.USERID,APPLICANT.PASSWORD,APPLICANT.APPLICANT_NAME,APPLICANT.GENDER,APPLICANT.MARITAL_STATUS,APPLICANT.NATIONALITY,";
                //xSql += "CONVERT(VARCHAR(10),APPLICANT.DOB,103),APPLICANT.DOB_DD,APPLICANT.DOB_MM,APPLICANT.DOB_YYYY,APPLICANT.APPLICANT_AGE,APPLICANT.EMAIL,APPLICANT.MOBILE,APPLICANT.ID_DOX,APPLICANT.ID_NO,APPLICANT.APPLIED_DISCIPLINE,APPLICANT.CATEGORY_APPLIED,";
                //xSql += "APPLICANT.CATEGORY_CERT_NO,APPLICANT.CATEGORY_CERT_ISSUE_DATE,APPLICANT.FATHER_NAME,APPLICANT.MOTHER_NAME,APPLICANT.DOMICILE_BIHAR,APPLICANT.DOMICILE_NO,APPLICANT.DOMICILE_ISSUE_DATE,";
                //xSql += "APPLICANT.PH_APPLICANT,APPLICANT.PH_TYPE,APPLICANT.PH_PERCENT,APPLICANT.CURRENT_ADDRESS,APPLICANT.CITY_CA,APPLICANT.DIST_CA,APPLICANT.STATE_CA,APPLICANT.PIN_CA,APPLICANT.PERMANENT_ADDRESS,";
                //xSql += "APPLICANT.CITY_PA,APPLICANT.DIST_PA,APPLICANT.STATE_PA,APPLICANT.PIN_PA,APPLICANT.BOARD_10TH,APPLICANT.BOARD10_PASSING_YEAR,APPLICANT.BOARD10_MARKS_OBTAIN,APPLICANT.BOARD10_TOT_MARKS,APPLICANT.BOARD10_PERCENT,";
                //xSql += "APPLICANT.BOARD_12TH,APPLICANT.BOARD12_BASE,APPLICANT.BOARD12_STREAM,APPLICANT.BOARD12_PASSING_YEAR,APPLICANT.BOARD12_MARKS_OBTAIN,APPLICANT.BOARD12_TOT_MARKS,APPLICANT.BOARD12_PERCENT,APPLICANT.GRADUATION_UNIV,";
                //xSql += "APPLICANT.GRADUATION_STREAM,APPLICANT.GRADUATION_PASSING_YEAR,APPLICANT.GRADUATION_MARKS_OBTAIN,APPLICANT.GRADUATION_TOT_MARKS,APPLICANT.GRADUATION_PERCENT,APPLICANT.POSTGRAD_STREAM,APPLICANT.POSTGRAD_UNIV,";
                //xSql += "APPLICANT.POSTGRAD_PASSING_YEAR,APPLICANT.POSTGRAD_MARKS_OBTAIN,APPLICANT.POSTGRAD_TOT_MARKS,APPLICANT.POSTGRAD_PERCENT,APPLICANT.OTHER_QUAL,APPLICANT.GOVT_JOB,APPLICANT.CURRENTLY_WORKING,APPLICANT.JOB_QUAL_REQ,";
                //xSql += "APPLICANT.UPLOAD_PHOTO,APPLICANT.UPLOAD_SIGN,APPLICANT.UPLOAD_PHOTOID,APPLICANT.UPLOAD_10TH,APPLICANT.UPLOAD_12TH,APPLICANT.UPLOAD_RESUME,";
                //xSql += "APPLICANT.UPLOAD_GRADUATION,APPLICANT.UPLOAD_POSTGRAD,APPLICANT.UPLOAD_DOMICILE,APPLICANT.UPLOAD_CASTE,APPLICANT.UPLOAD_PWD,";
                //xSql += "APPLICANT.DATED,APPLICANT.PERSONALINFO_PAGE,APPLICANT.EDUCATION_PAGE,APPLICANT.WORK_EXP_PAGE,APPLICANT.DOCUMENT_PAGE,APPLICANT.REFERENCE_NO,APPLICANT.Amount,APPLICANT.PAYMENT_STATUS ORDER BY APPLICANT.USERID";

                string xPeriod = "";
                int z = site.executeNonQuery("delete from WORK_EXPERIENCE_TMP");
                dt = site.getdatatable("SELECT USERID from WORK_EXPERIENCE group by USERID order by USERID");
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    //z = site.executeNonQuery("Insert into TMP VALUES('" + dt.Rows[x]["USERID"].ToString().Trim() + "')");
                    int xDays = 0;
                    DataTable dt1 = site.getdatatable("SELECT * from WORK_EXPERIENCE where USERID='" + dt.Rows[x]["USERID"].ToString().Trim() + "' order by seq");
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        xDays += Convert.ToInt32(dt1.Rows[i]["DAYS"].ToString().Trim());
                        TimeSpan ts = TimeSpan.FromDays(xDays);
                        DateTime age = DateTime.MinValue + ts;

                        int xYear = age.Year - 1;
                        int xMon = age.Month - 1;
                        int xDay = age.Day - 1;
                        xPeriod= xYear +" years "+ xMon + " months "+xDay + " days";

                        if (i == 0)
                            z = site.executeNonQuery("Insert into WORK_EXPERIENCE_TMP(USERID,ORGANISATION_NAME1,DESIGNATION1,SALARY_PM1,JOIN_DATE1,END_DATE1,PERIOD1,DESCS1,TOTAL_PERIOD) VALUES('" + dt1.Rows[i]["USERID"].ToString().Trim() + "','" + dt1.Rows[i]["ORGANISATION_NAME"].ToString().Trim() + "','" + dt1.Rows[i]["DESIGNATION"].ToString().Trim() + "'," + dt1.Rows[i]["SALARY_PM"].ToString().Trim() + ",'" + dt1.Rows[i]["JOIN_DATE"].ToString().Trim() + "','" + dt1.Rows[i]["END_DATE"].ToString().Trim() + "','" + dt1.Rows[i]["PERIOD"].ToString().Trim() + "','" + dt1.Rows[i]["DESCS"].ToString().Trim() + "','" + xPeriod + "')");
                        else if (i == 1)
                            z = site.executeNonQuery("UPDATE WORK_EXPERIENCE_TMP SET ORGANISATION_NAME2='" + dt1.Rows[i]["ORGANISATION_NAME"].ToString().Trim() + "',DESIGNATION2='" + dt1.Rows[i]["DESIGNATION"].ToString().Trim() + "',SALARY_PM2=" + dt1.Rows[i]["SALARY_PM"].ToString().Trim() + ",JOIN_DATE2='" + dt1.Rows[i]["JOIN_DATE"].ToString().Trim() + "',END_DATE2='" + dt1.Rows[i]["END_DATE"].ToString().Trim() + "',PERIOD2='" + dt1.Rows[i]["PERIOD"].ToString().Trim() + "',DESCS2='" + dt1.Rows[i]["DESCS"].ToString().Trim() + "',TOTAL_PERIOD='" + xPeriod + "' WHERE USERID = '" + dt1.Rows[i]["USERID"].ToString().Trim() + "'");
                        else if (i == 2)
                            z = site.executeNonQuery("UPDATE WORK_EXPERIENCE_TMP SET ORGANISATION_NAME3='" + dt1.Rows[i]["ORGANISATION_NAME"].ToString().Trim() + "',DESIGNATION3='" + dt1.Rows[i]["DESIGNATION"].ToString().Trim() + "',SALARY_PM3=" + dt1.Rows[i]["SALARY_PM"].ToString().Trim() + ",JOIN_DATE3='" + dt1.Rows[i]["JOIN_DATE"].ToString().Trim() + "',END_DATE3='" + dt1.Rows[i]["END_DATE"].ToString().Trim() + "',PERIOD3='" + dt1.Rows[i]["PERIOD"].ToString().Trim() + "',DESCS3='" + dt1.Rows[i]["DESCS"].ToString().Trim() + "',TOTAL_PERIOD='" + xPeriod + "' WHERE USERID = '" + dt1.Rows[i]["USERID"].ToString().Trim() + "'");
                        else if (i == 3)
                            z = site.executeNonQuery("UPDATE WORK_EXPERIENCE_TMP SET ORGANISATION_NAME4='" + dt1.Rows[i]["ORGANISATION_NAME"].ToString().Trim() + "',DESIGNATION4='" + dt1.Rows[i]["DESIGNATION"].ToString().Trim() + "',SALARY_PM4=" + dt1.Rows[i]["SALARY_PM"].ToString().Trim() + ",JOIN_DATE4='" + dt1.Rows[i]["JOIN_DATE"].ToString().Trim() + "',END_DATE4='" + dt1.Rows[i]["END_DATE"].ToString().Trim() + "',PERIOD4='" + dt1.Rows[i]["PERIOD"].ToString().Trim() + "',DESCS4='" + dt1.Rows[i]["DESCS"].ToString().Trim() + "',TOTAL_PERIOD='" + xPeriod + "' WHERE USERID = '" + dt1.Rows[i]["USERID"].ToString().Trim() + "'");
                        else if (i == 4)
                            z = site.executeNonQuery("UPDATE WORK_EXPERIENCE_TMP SET ORGANISATION_NAME5='" + dt1.Rows[i]["ORGANISATION_NAME"].ToString().Trim() + "',DESIGNATION5='" + dt1.Rows[i]["DESIGNATION"].ToString().Trim() + "',SALARY_PM5=" + dt1.Rows[i]["SALARY_PM"].ToString().Trim() + ",JOIN_DATE5='" + dt1.Rows[i]["JOIN_DATE"].ToString().Trim() + "',END_DATE5='" + dt1.Rows[i]["END_DATE"].ToString().Trim() + "',PERIOD5='" + dt1.Rows[i]["PERIOD"].ToString().Trim() + "',DESCS5='" + dt1.Rows[i]["DESCS"].ToString().Trim() + "',TOTAL_PERIOD='" + xPeriod + "' WHERE USERID = '" + dt1.Rows[i]["USERID"].ToString().Trim() + "'");
                        else if (i == 5)
                            z = site.executeNonQuery("UPDATE WORK_EXPERIENCE_TMP SET ORGANISATION_NAME6='" + dt1.Rows[i]["ORGANISATION_NAME"].ToString().Trim() + "',DESIGNATION6='" + dt1.Rows[i]["DESIGNATION"].ToString().Trim() + "',SALARY_PM6=" + dt1.Rows[i]["SALARY_PM"].ToString().Trim() + ",JOIN_DATE6='" + dt1.Rows[i]["JOIN_DATE"].ToString().Trim() + "',END_DATE6='" + dt1.Rows[i]["END_DATE"].ToString().Trim() + "',PERIOD6='" + dt1.Rows[i]["PERIOD"].ToString().Trim() + "',DESCS6='" + dt1.Rows[i]["DESCS"].ToString().Trim() + "',TOTAL_PERIOD='" + xPeriod + "' WHERE USERID = '" + dt1.Rows[i]["USERID"].ToString().Trim() + "'");
                        else if (i == 6)
                            z = site.executeNonQuery("UPDATE WORK_EXPERIENCE_TMP SET ORGANISATION_NAME7='" + dt1.Rows[i]["ORGANISATION_NAME"].ToString().Trim() + "',DESIGNATION7='" + dt1.Rows[i]["DESIGNATION"].ToString().Trim() + "',SALARY_PM7=" + dt1.Rows[i]["SALARY_PM"].ToString().Trim() + ",JOIN_DATE7='" + dt1.Rows[i]["JOIN_DATE"].ToString().Trim() + "',END_DATE7='" + dt1.Rows[i]["END_DATE"].ToString().Trim() + "',PERIOD7='" + dt1.Rows[i]["PERIOD"].ToString().Trim() + "',DESCS7='" + dt1.Rows[i]["DESCS"].ToString().Trim() + "',TOTAL_PERIOD='" + xPeriod + "' WHERE USERID = '" + dt1.Rows[i]["USERID"].ToString().Trim() + "'");
                        else if (i == 7)
                            z = site.executeNonQuery("UPDATE WORK_EXPERIENCE_TMP SET ORGANISATION_NAME8='" + dt1.Rows[i]["ORGANISATION_NAME"].ToString().Trim() + "',DESIGNATION8='" + dt1.Rows[i]["DESIGNATION"].ToString().Trim() + "',SALARY_PM8=" + dt1.Rows[i]["SALARY_PM"].ToString().Trim() + ",JOIN_DATE8='" + dt1.Rows[i]["JOIN_DATE"].ToString().Trim() + "',END_DATE8='" + dt1.Rows[i]["END_DATE"].ToString().Trim() + "',PERIOD8='" + dt1.Rows[i]["PERIOD"].ToString().Trim() + "',DESCS8='" + dt1.Rows[i]["DESCS"].ToString().Trim() + "',TOTAL_PERIOD='" + xPeriod + "' WHERE USERID = '" + dt1.Rows[i]["USERID"].ToString().Trim() + "'");

                    }

                }


                string xQuery = "SELECT APPLICANT.*,CONVERT(VARCHAR(10),APPLICANT.DOB,103) AS DOB1 ";
                xQuery += ",WORK_EXPERIENCE_TMP.ORGANISATION_NAME1,WORK_EXPERIENCE_TMP.DESIGNATION1,WORK_EXPERIENCE_TMP.SALARY_PM1,WORK_EXPERIENCE_TMP.JOIN_DATE1,WORK_EXPERIENCE_TMP.END_DATE1,WORK_EXPERIENCE_TMP.PERIOD1,WORK_EXPERIENCE_TMP.DESCS1";
                xQuery += ",WORK_EXPERIENCE_TMP.ORGANISATION_NAME2,WORK_EXPERIENCE_TMP.DESIGNATION2,WORK_EXPERIENCE_TMP.SALARY_PM2,WORK_EXPERIENCE_TMP.JOIN_DATE2,WORK_EXPERIENCE_TMP.END_DATE2,WORK_EXPERIENCE_TMP.PERIOD2,WORK_EXPERIENCE_TMP.DESCS2";
                xQuery += ",WORK_EXPERIENCE_TMP.ORGANISATION_NAME3,WORK_EXPERIENCE_TMP.DESIGNATION3,WORK_EXPERIENCE_TMP.SALARY_PM3,WORK_EXPERIENCE_TMP.JOIN_DATE3,WORK_EXPERIENCE_TMP.END_DATE3,WORK_EXPERIENCE_TMP.PERIOD3,WORK_EXPERIENCE_TMP.DESCS3";
                xQuery += ",WORK_EXPERIENCE_TMP.ORGANISATION_NAME4,WORK_EXPERIENCE_TMP.DESIGNATION4,WORK_EXPERIENCE_TMP.SALARY_PM4,WORK_EXPERIENCE_TMP.JOIN_DATE4,WORK_EXPERIENCE_TMP.END_DATE4,WORK_EXPERIENCE_TMP.PERIOD4,WORK_EXPERIENCE_TMP.DESCS4";
                xQuery += ",WORK_EXPERIENCE_TMP.ORGANISATION_NAME5,WORK_EXPERIENCE_TMP.DESIGNATION5,WORK_EXPERIENCE_TMP.SALARY_PM5,WORK_EXPERIENCE_TMP.JOIN_DATE5,WORK_EXPERIENCE_TMP.END_DATE5,WORK_EXPERIENCE_TMP.PERIOD5,WORK_EXPERIENCE_TMP.DESCS5";
                xQuery += ",WORK_EXPERIENCE_TMP.ORGANISATION_NAME6,WORK_EXPERIENCE_TMP.DESIGNATION6,WORK_EXPERIENCE_TMP.SALARY_PM6,WORK_EXPERIENCE_TMP.JOIN_DATE6,WORK_EXPERIENCE_TMP.END_DATE6,WORK_EXPERIENCE_TMP.PERIOD6,WORK_EXPERIENCE_TMP.DESCS6";
                xQuery += ",WORK_EXPERIENCE_TMP.ORGANISATION_NAME7,WORK_EXPERIENCE_TMP.DESIGNATION7,WORK_EXPERIENCE_TMP.SALARY_PM7,WORK_EXPERIENCE_TMP.JOIN_DATE7,WORK_EXPERIENCE_TMP.END_DATE7,WORK_EXPERIENCE_TMP.PERIOD7,WORK_EXPERIENCE_TMP.DESCS7";
                xQuery += ",WORK_EXPERIENCE_TMP.ORGANISATION_NAME8,WORK_EXPERIENCE_TMP.DESIGNATION8,WORK_EXPERIENCE_TMP.SALARY_PM8,WORK_EXPERIENCE_TMP.JOIN_DATE8,WORK_EXPERIENCE_TMP.END_DATE8,WORK_EXPERIENCE_TMP.PERIOD8,WORK_EXPERIENCE_TMP.DESCS8,WORK_EXPERIENCE_TMP.TOTAL_PERIOD";
                xQuery += " from APPLICANT left join WORK_EXPERIENCE_TMP on APPLICANT.USERID=WORK_EXPERIENCE_TMP.USERID order by APPLICANT.SEQ";
                //string xQuery = "SELECT APPLICANT.*,CONVERT(VARCHAR(10),APPLICANT.DOB,103) AS DOB1 from APPLICANT right join WORK_EXPERIENCE_TMP on APPLICANT.USERID=WORK_EXPERIENCE_TMP.USERID order by APPLICANT.SEQ";

                dt = site.getdatatable(xQuery);
                if (dt.Rows.Count > 0)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }

                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                string FileName = "pdil" + DateTime.Now + ".xls";
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                GridView2.GridLines = GridLines.Both;
                GridView2.HeaderStyle.Font.Bold = true;
                GridView2.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                Response.End();
            }
 
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }

        //protected void btnQuery_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string xQuery = "";
        //        if (ddlDiscipline.SelectedIndex>0)
        //            xQuery = "APPLICANT.APPLIED_DISCIPLINE='" + ddlDiscipline.SelectedItem.Text.Trim() + "'";
        //        if (ddlStream.SelectedIndex > 0)
        //        {
        //            if(xQuery.Trim()=="")
        //                xQuery = "APPLICANT.DEGREE_STREAM_DISCIPLINE='" + ddlStream.SelectedItem.Text.Trim() + "'";
        //            else
        //                xQuery += " and APPLICANT.DEGREE_STREAM_DISCIPLINE='" + ddlStream.SelectedItem.Text.Trim() + "'";
        //        }

        //        string xSql = "select APPLICANT.*,CONVERT(VARCHAR(10),APPLICANT.DOB,103) AS DOB1 from APPLICANT WHERE " + xQuery;
        //        dt = site.getdatatable(xSql);
        //        if (dt.Rows.Count == 0)
        //        {
        //            GridView1.DataSource = null; 
        //            GridView1.DataBind();
        //        }
        //        else
        //        {
        //            GridView1.DataSource = dt;
        //            GridView1.DataBind();
        //        }
        //        //lblRex.Text="Records : "+dt.Rows.Count;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Fetch Error:" + ex.Message);
        //    }
        //}
    }
}