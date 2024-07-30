using MimeKit;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

namespace RegistrationApp
{
    public partial class UploadFile : System.Web.UI.Page
    {

        DataTable dt;
        siteclass site = new siteclass();
        string AppNo = string.Empty, xStatus = string.Empty;
        int xError = 0, xErrorFileType = 0, xErrorFileSize = 0, xColor = 0;
        int minFileSize = 102400, maxFileSize = 512000;   //1024*(100-500)
        int minSizePhoto = 20480, maxSizePhoto = 102400; //1024*(20-50)
        string today = DateTime.Now.ToString("yyyy-MM-dd");
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
                AppNo = Session["APPNO"].ToString();

            if (!IsPostBack)
            {
                if (AppNo != null)
                {
                    displayUploadedImages();
                }
            }
        }
        void displayUploadedImages()
        {
            try
            {
                string xPost = "";

                dt = site.getdatatable("SELECT * from APPLICANT WHERE USERID='" + AppNo + "'");
                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["APPLICANT_NAME"].ToString()))
                        Session["Name"] = dt.Rows[0]["APPLICANT_NAME"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[0]["EMAIL"].ToString()))
                        Session["Email"] = dt.Rows[0]["EMAIL"].ToString();

                    if (!string.IsNullOrEmpty(dt.Rows[0]["APPLIED_DISCIPLINE"].ToString()))
                    {
                        xPost = dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim();
                        Session["Post"]=dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim();
                    }
                    
                    if (dt.Rows[0]["UPLOAD_PHOTO"].ToString() == "1")
                        imgPhoto.ImageUrl = "~/uploadedfiles/photograph/" + AppNo + "_photo.jpg";

                    if (dt.Rows[0]["UPLOAD_SIGN"].ToString() == "1")
                        imgSign.ImageUrl = "~/uploadedfiles/signature/" + AppNo + "_sign.jpg";

                    if (dt.Rows[0]["UPLOAD_ADHAR"].ToString() == "1")
                        imgAdhar.ImageUrl = "~/uploadedfiles/aadhar/" + AppNo + "_adhar.jpg";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }
        protected void btnPhoto_Upload(object sender, EventArgs e)
        {
            UploadPhoto();
            lblPhoto.Text = xStatus;
            if (xColor == 1)
            {
                lblPhoto.ForeColor = Color.Red;
            }
            else
            {
                markUploadDox("UPLOAD_PHOTO");
                lblPhoto.Text = "File Uploaded Successfully!";
                lblPhoto.ForeColor = Color.Green;
                imgPhoto.ImageUrl = "~/uploadedfiles/photograph/" + AppNo + "_photo.jpg" + "?" + DateTime.Now.Ticks;
            }
        }
        protected void UploadPhoto()
        {
            try
            {
                AppNo = Session["APPNO"].ToString();
                string fileName = string.Empty, fileExtn = string.Empty;
                string specialChar = @"\|!#$%&/()=?»«@£§€{};'<>_,[]+";

                if (FileUploadPhoto.HasFile)
                {
                    dynamic fileUploadControl = FileUploadPhoto;
                    foreach (var selectedfile in fileUploadControl.PostedFiles)
                    {
                        fileName = Path.GetFileName(selectedfile.FileName);
                        fileExtn = System.IO.Path.GetExtension(selectedfile.FileName);
                    }
                }

                if (fileExtn.ToLower() == ".jpg")
                {
                    xErrorFileType = 0;
                }
                else
                {
                    xStatus = "File Type JPG only !";
                    xColor = 1;
                    xErrorFileType = 1;
                    return;
                }

                if ((FileUploadPhoto.PostedFile.ContentLength >= minSizePhoto) && (FileUploadPhoto.PostedFile.ContentLength <= maxSizePhoto))
                {
                    xErrorFileSize = 0;
                }
                else
                {
                    xStatus = "File Size 20-100KB only !";
                    xColor = 1;
                    xErrorFileSize = 1;
                    return;
                }

                int splChar = 0;
                foreach (var item in specialChar)
                {
                    if (fileName.Contains(item))
                    {
                        xStatus = "File Name with special characters are not allowed to upload!";
                        xColor = 1;
                        xError = 1;
                        if (splChar == 0)
                        {
                            splChar = 1;
                        }
                    }
                }

                if (splChar == 0 || xError == 0 || xErrorFileType == 0 || xErrorFileSize == 0)
                {
                    if (FileUploadPhoto.HasFile)
                    {
                        dynamic fileUploadControl = FileUploadPhoto;
                        foreach (var selectedfile in fileUploadControl.PostedFiles)
                        {
                            fileName = Path.GetFileName(selectedfile.FileName);
                            selectedfile.SaveAs(Server.MapPath("~/uploadedfiles/photograph/" + AppNo + "_photo.jpg"));
                        }
                        xStatus = string.Format("File uploaded successfully!");
                        xColor = 0;
                        xError = 0;
                    }
                }
            }
            catch (Exception Ex)
            {
                xError = 1;
                xColor = 1;
                xStatus = "Application Error : " + Ex.Message;
            }
        }
        protected void btnSign_Upload(object sender, EventArgs e)
        {
            UploadSign();
            lblSign.Text = xStatus;
            if (xColor == 1)
            {
                lblSign.ForeColor = Color.Red;
            }
            else
            {
                markUploadDox("UPLOAD_SIGN");
                lblSign.Text = "File Uploaded Successfully!";
                lblSign.ForeColor = Color.Green;
                imgSign.ImageUrl = "~/uploadedfiles/signature/" + AppNo + "_sign.jpg" + "?" + DateTime.Now.Ticks;
            }
        }
        protected void UploadSign()
        {
            try
            {
                AppNo = Session["APPNO"].ToString();
                string fileName = string.Empty, fileExtn = string.Empty;
                string specialChar = @"\|!#$%&/()=?»«@£§€{};'<>_,[]+";

                if (FileUploadSign.HasFile)
                {
                    dynamic fileUploadControl = FileUploadSign;
                    foreach (var selectedfile in fileUploadControl.PostedFiles)
                    {
                        fileName = Path.GetFileName(selectedfile.FileName);
                        fileExtn = System.IO.Path.GetExtension(selectedfile.FileName);
                    }
                }

                if (fileExtn.ToLower() == ".jpg")
                {
                    xErrorFileType = 0;
                }
                else
                {
                    xStatus = "File Type JPG only !";
                    xColor = 1;
                    xErrorFileType = 1;
                    return;
                }

                if ((FileUploadSign.PostedFile.ContentLength >= minSizePhoto) && (FileUploadSign.PostedFile.ContentLength <= maxSizePhoto))
                {
                    xErrorFileSize = 0;
                }
                else
                {
                    xStatus = "File Size 20-100 KB only !";
                    xColor = 1;
                    xErrorFileSize = 1;
                    return;
                }

                int splChar = 0;
                foreach (var item in specialChar)
                {
                    if (fileName.Contains(item))
                    {
                        xStatus = "File Name with special characters are not allowed to upload!";
                        xColor = 1;
                        xError = 1;
                        if (splChar == 0)
                        {
                            splChar = 1;
                        }
                    }
                }

                if (splChar == 0 || xError == 0 || xErrorFileType == 0 || xErrorFileSize == 0)
                {
                    if (FileUploadSign.HasFile)
                    {
                        dynamic fileUploadControl = FileUploadSign;
                        foreach (var selectedfile in fileUploadControl.PostedFiles)
                        {
                            fileName = Path.GetFileName(selectedfile.FileName);
                            selectedfile.SaveAs(Server.MapPath("~/uploadedfiles/signature/" + AppNo + "_sign.jpg"));
                        }
                        xStatus = string.Format("File uploaded successfully!");
                        xColor = 0;
                        xError = 0;
                    }
                }
            }
            catch (Exception Ex)
            {
                xError = 1;
                xColor = 1;
                xStatus = "Application Error : " + Ex.Message;
            }
        }
        protected void btnAdhar_Upload(object sender, EventArgs e)
        {
            UploadAdhar();
            lblAdhar.Text = xStatus;
            if (xColor == 1)
            {
                lblAdhar.ForeColor = Color.Red;
            }
            else
            {
                markUploadDox("UPLOAD_ADHAR");
                lblAdhar.Text = "File Uploaded Successfully!";
                lblAdhar.ForeColor = Color.Green;
                imgAdhar.ImageUrl = "~/uploadedfiles/aadhar/" + AppNo + "_adhar.jpg" + "?" + DateTime.Now.Ticks;
            }
        }
        protected void UploadAdhar()
        {
            try
            {
                AppNo = Session["APPNO"].ToString();
                string fileName = string.Empty, fileExtn = string.Empty;
                string specialChar = @"\|!#$%&/()=?»«@£§€{};'<>_,[]+";

                if (FileUploadAdhar.HasFile)
                {
                    dynamic fileUploadControl = FileUploadAdhar;
                    foreach (var selectedfile in fileUploadControl.PostedFiles)
                    {
                        fileName = Path.GetFileName(selectedfile.FileName);
                        fileExtn = System.IO.Path.GetExtension(selectedfile.FileName);
                        fileExtn = fileExtn.ToLower();
                        
                    }
                }

                if (fileExtn == ".jpg")
                {
                    xErrorFileType = 0;
                }
                else
                {
                    xStatus = "File Type JPG only !";
                    xColor = 1;
                    xErrorFileType = 1;
                    return;
                }

                if ((FileUploadAdhar.PostedFile.ContentLength >= minFileSize) && (FileUploadAdhar.PostedFile.ContentLength <= maxFileSize))
                {
                    xErrorFileSize = 0;
                }
                else
                {
                    xStatus = "File Size 100-500 KB only !";
                    xColor = 1;
                    xErrorFileSize = 1;
                    return;
                }

                int splChar = 0;
                foreach (var item in specialChar)
                {
                    if (fileName.Contains(item))
                    {
                        xStatus = "File Name with special characters are not allowed to upload!";
                        xColor = 1;
                        xError = 1;
                        if (splChar == 0)
                        {
                            splChar = 1;
                        }
                    }
                }

                if (splChar == 0 || xError == 0 || xErrorFileType == 0 || xErrorFileSize == 0)
                {
                    if (FileUploadAdhar.HasFile)
                    {
                        dynamic fileUploadControl = FileUploadAdhar;
                        foreach (var selectedfile in fileUploadControl.PostedFiles)
                        {
                            fileName = Path.GetFileName(selectedfile.FileName);
                            selectedfile.SaveAs(Server.MapPath("~/uploadedfiles/aadhar/" + AppNo + "_adhar.jpg"));
                        }
                        xStatus = string.Format("File uploaded successfully!");
                        xColor = 0;
                        xError = 0;
                    }
                }
            }
            catch (Exception Ex)
            {
                xError = 1;
                xColor = 1;
                xStatus = "Application Error : " + Ex.Message;
            }
        }
        protected void validatePageValues()
        {
            try
            {
                if (Session["APPNO"] == null)
                {
                    Response.Redirect("SessionExpired");
                }
                else
                {
                    AppNo = Session["APPNO"].ToString();
                    dt = site.getdatatable("SELECT * from APPLICANT WHERE USERID='" + AppNo + "'");
                    if (dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[0]["PERSONALINFO_PAGE"].ToString()))
                        {
                            if (Convert.ToInt32(dt.Rows[0]["PERSONALINFO_PAGE"]) == 1)
                            {
                                ViewState["ERROR"] = 0;
                                lblStatus.Visible = false;
                            }
                            else
                            {
                                lblStatus.Text = "Personal Information Page is not completed!";
                                lblStatus.Visible = true;
                                ViewState["ERROR"] = 1;
                                return;
                            }
                        }
                        else
                        {
                            lblStatus.Text = "Personal Information Page is not completed!";
                            lblStatus.Visible = true;
                            ViewState["ERROR"] = 1;
                            return;
                        }

                        if (!string.IsNullOrEmpty(dt.Rows[0]["EDUCATION_PAGE"].ToString()))
                        {
                            if (Convert.ToInt32(dt.Rows[0]["EDUCATION_PAGE"]) == 1)
                            {
                                ViewState["ERROR"] = 0;
                                lblStatus.Visible = false;
                            }
                            else
                            {
                                lblStatus.Text = "Education Page is not completed!";
                                lblStatus.Visible = true;
                                ViewState["ERROR"] = 1;
                                return;
                            }
                        }
                        else
                        {
                            lblStatus.Text = "Education Page is not completed!";
                            lblStatus.Visible = true;
                            ViewState["ERROR"] = 1;
                            return;
                        }

                        //if (!string.IsNullOrEmpty(dt.Rows[0]["EXPERIENCE_PAGE"].ToString()))
                        //{
                        //    if (Convert.ToInt32(dt.Rows[0]["EXPERIENCE_PAGE"]) == 1)
                        //    {
                        //        ViewState["ERROR"] = 0;
                        //        lblStatus.Visible = false;
                        //    }
                        //    else
                        //    {
                        //        lblStatus.Text = "Work Experince Page is not completed!";
                        //        lblStatus.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}
                        //else
                        //{
                        //    lblStatus.Text = "Work Experince Page is not completed!";
                        //    lblStatus.Visible = true;
                        //    ViewState["ERROR"] = 1;
                        //    return;
                        //}

                        if (!string.IsNullOrEmpty(dt.Rows[0]["UPLOAD_PHOTO"].ToString()))
                        {
                            if (Convert.ToInt32(dt.Rows[0]["UPLOAD_PHOTO"]) == 1)
                            {
                                ViewState["ERROR"] = 0;
                                lblPhoto.Visible = false;
                            }
                            else
                            {
                                lblPhoto.Text = "Please upload your photograph";
                                lblPhoto.Visible = true;
                                ViewState["ERROR"] = 1;
                                return;
                            }
                        }
                        else
                        {
                            lblPhoto.Text = "Please upload your photograph";
                            lblPhoto.Visible = true;
                            ViewState["ERROR"] = 1;
                            return;
                        }

                        if (!string.IsNullOrEmpty(dt.Rows[0]["UPLOAD_SIGN"].ToString()))
                        {
                            if (Convert.ToInt32(dt.Rows[0]["UPLOAD_SIGN"]) == 1)
                            {
                                ViewState["ERROR"] = 0;
                                lblSign.Visible = false;
                            }
                            else
                            {
                                lblSign.Text = "Please upload your signature";
                                lblSign.Visible = true;
                                ViewState["ERROR"] = 1;
                                return;
                            }
                        }
                        else
                        {
                            lblSign.Text = "Please upload your signature";
                            lblSign.Visible = true;
                            ViewState["ERROR"] = 1;
                            return;
                        }

                        if (!string.IsNullOrEmpty(dt.Rows[0]["UPLOAD_ADHAR"].ToString()))
                        {
                            if (Convert.ToInt32(dt.Rows[0]["UPLOAD_ADHAR"]) == 1)
                            {
                                ViewState["ERROR"] = 0;
                                lblAdhar.Visible = false;
                            }
                            else
                            {
                                lblAdhar.Text = "Please upload Aadhar Card";
                                lblAdhar.Visible = true;
                                ViewState["ERROR"] = 1;
                                return;
                            }
                        }
                        else
                        {
                            lblAdhar.Text = "Please upload Aadhar Card";
                            lblAdhar.Visible = true;
                            ViewState["ERROR"] = 1;
                            return;
                        }

                        //if (dt.Rows[0]["CATEGORY_APPLIED"].ToString().ToUpper() != "UR")
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["UPLOAD_CASTE"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["UPLOAD_CASTE"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblCaste.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblCaste.Text = "Please upload caste certificate";
                        //            lblCaste.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblCaste.Text = "Please upload caste certificate";
                        //        lblCaste.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }

                        //}

                        //if (dt.Rows[0]["PWD_APPLIED"].ToString().ToUpper() == "YES")
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["UPLOAD_PWD"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["UPLOAD_PWD"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblPH.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblPH.Text = "Please upload PwD Certificate";
                        //            lblPH.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblPH.Text = "Please upload PwD Certificate";
                        //        lblPH.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }

                        //}

                        //if (!string.IsNullOrEmpty(dt.Rows[0]["UPLOAD_10TH"].ToString()))
                        //{
                        //    if (Convert.ToInt32(dt.Rows[0]["UPLOAD_10TH"]) == 1)
                        //    {
                        //        ViewState["ERROR"] = 0;
                        //        lblTen.Visible = false;
                        //    }
                        //    else
                        //    {
                        //        lblTen.Text = "Please upload Tenth Certificate";
                        //        lblTen.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}
                        //else
                        //{
                        //    lblTen.Text = "Please upload Tenth Certificate";
                        //    lblTen.Visible = true;
                        //    ViewState["ERROR"] = 1;
                        //    return;
                        //}

                        //if (!string.IsNullOrEmpty(dt.Rows[0]["MARKSHEET_10TH"].ToString()))
                        //{
                        //    if (Convert.ToInt32(dt.Rows[0]["MARKSHEET_10TH"]) == 1)
                        //    {
                        //        ViewState["ERROR"] = 0;
                        //        lblTenMS.Visible = false;
                        //    }
                        //    else
                        //    {
                        //        lblTenMS.Text = "Please upload Tenth Marksheet";
                        //        lblTenMS.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}
                        //else
                        //{
                        //    lblTenMS.Text = "Please upload Tenth Marksheet";
                        //    lblTenMS.Visible = true;
                        //    ViewState["ERROR"] = 1;
                        //    return;
                        //}

                        //if (div12.Visible)
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["UPLOAD_12TH"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["UPLOAD_12TH"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblTwelve.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblTwelve.Text = "Please upload twelveth certificate";
                        //            lblTwelve.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblTwelve.Text = "Please upload twelveth certificate";
                        //        lblTwelve.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }

                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["MARKSHEET_12TH"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["MARKSHEET_12TH"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblTwelveMS.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblTwelveMS.Text = "Please upload Twelveth Marksheet";
                        //            lblTwelveMS.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblTwelveMS.Text = "Please upload Twelveth Marksheet";
                        //        lblTwelveMS.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}

                        //if ((dt.Rows[0]["DEGREE_DISCIPLINE"].ToString().ToUpper() == "B.E. with Lateral Entry") || (dt.Rows[0]["DEGREE_DISCIPLINE"].ToString() == "B.Tech. with Lateral Entry"))
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["UPLOAD_DIPLOMA"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["UPLOAD_DIPLOMA"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblDiploma.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblDiploma.Text = "Please upload Diploma certificate";
                        //            lblDiploma.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblDiploma.Text = "Please upload Diploma certificate";
                        //        lblDiploma.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }

                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["DIPLOMA_MARKSHEET"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["DIPLOMA_MARKSHEET"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblDiplomaMS.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblDiplomaMS.Text = "Please upload Diploma Marksheet";
                        //            lblDiplomaMS.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblDiplomaMS.Text = "Please upload Diploma Marksheet";
                        //        lblDiplomaMS.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}

                        //if ((dt.Rows[0]["DEGREE_DISCIPLINE"].ToString().ToUpper() == "MBA (2 years regular course) with major as PM&IR/HR") || (dt.Rows[0]["DEGREE_DISCIPLINE"].ToString() == "PG Degree/PG Diploma (2 years regular course) in PM/HR/PM&IR") || (dt.Rows[0]["DEGREE_DISCIPLINE"].ToString() == "PG Degree/PG Diploma (2 years regular course) in Labour & Social Welfare Labour relations (LSW)"))
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["UPLOAD_GRADUATION"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["UPLOAD_GRADUATION"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblGrad.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblGrad.Text = "Please upload Graduation Certificate";
                        //            lblGrad.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblGrad.Text = "Please upload Graduation Certificate";
                        //        lblGrad.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }

                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["GRAD_MARKSHEET"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["GRAD_MARKSHEET"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblGradMS.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblGradMS.Text = "Please upload Graduation Marksheet";
                        //            lblGradMS.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblGradMS.Text = "Please upload Graduation Marksheet";
                        //        lblGradMS.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}

                        //if (!string.IsNullOrEmpty(dt.Rows[0]["UPLOAD_DEGREE"].ToString()))
                        //{
                        //    if (Convert.ToInt32(dt.Rows[0]["UPLOAD_DEGREE"]) == 1)
                        //    {
                        //        ViewState["ERROR"] = 0;
                        //        lblDegree.Visible = false;
                        //    }
                        //    else
                        //    {
                        //        lblDegree.Text = "Please upload Degree Certificate";
                        //        lblDegree.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}
                        //else
                        //{
                        //    lblDegree.Text = "Please upload Degree Certificate";
                        //    lblDegree.Visible = true;
                        //    ViewState["ERROR"] = 1;
                        //    return;
                        //}

                        //if (!string.IsNullOrEmpty(dt.Rows[0]["DEGREE_MARKSHEET"].ToString()))
                        //{
                        //    if (Convert.ToInt32(dt.Rows[0]["DEGREE_MARKSHEET"]) == 1)
                        //    {
                        //        ViewState["ERROR"] = 0;
                        //        lblDegreeMS.Visible = false;
                        //    }
                        //    else
                        //    {
                        //        lblDegreeMS.Text = "Please upload Degree Marksheet";
                        //        lblDegreeMS.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}
                        //else
                        //{
                        //    lblDegreeMS.Text = "Please upload Degree Marksheet";
                        //    lblDegreeMS.Visible = true;
                        //    ViewState["ERROR"] = 1;
                        //    return;
                        //}

                        //if (dt.Rows[0]["DEGREE_STREAM"].ToString().ToUpper() == "SAFETY")
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["UPLOAD_DIPLOMA_SAFETY"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["UPLOAD_DIPLOMA_SAFETY"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblDiplomaSafety.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblDiplomaSafety.Text = "Please upload Diploma in Safety Certificate";
                        //            lblDiplomaSafety.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblDiplomaSafety.Text = "Please upload Diploma in Safety Certificate";
                        //        lblDiplomaSafety.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }

                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["DIPLOMA_MARKSHEET_SAFETY"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["DIPLOMA_MARKSHEET_SAFETY"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblDiplomaSafetyMS.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblDiplomaSafetyMS.Text = "Please upload Diploma in Safety Marksheet";
                        //            lblDiplomaSafetyMS.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblDiplomaSafetyMS.Text = "Please upload Diploma in Safety Marksheet";
                        //        lblDiplomaSafetyMS.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }

                        //}
 
                        //if (!string.IsNullOrEmpty(dt.Rows[0]["EXPERIENCE1"].ToString()))
                        //{
                        //    if (Convert.ToInt32(dt.Rows[0]["EXPERIENCE1"]) == 1)
                        //    {
                        //        ViewState["ERROR"] = 0;
                        //        lblExp1.Visible = false;
                        //    }
                        //    else
                        //    {
                        //        lblExp1.Text = "Please upload Experience-1 Certificate";
                        //        lblExp1.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}
                        //else
                        //{
                        //    lblExp1.Text = "Please upload Experience-1 Certificate";
                        //    lblExp1.Visible = true;
                        //    ViewState["ERROR"] = 1;
                        //    return;
                        //}


                        //if (divExp2.Visible)
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["EXPERIENCE2"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["EXPERIENCE2"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblExp2.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblExp2.Text = "Please upload Experience-2 Certificate";
                        //            lblExp2.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblExp2.Text = "Please upload Experience-2 Certificate";
                        //        lblExp2.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}

                        //if (divExp3.Visible)
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["EXPERIENCE3"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["EXPERIENCE3"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblExp3.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblExp3.Text = "Please upload Experience-3 Certificate";
                        //            lblExp3.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblExp3.Text = "Please upload Experience-3 Certificate";
                        //        lblExp3.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}

                        //if (divExp4.Visible)
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["EXPERIENCE4"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["EXPERIENCE4"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblExp4.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblExp4.Text = "Please upload Experience-4 Certificate";
                        //            lblExp4.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblExp4.Text = "Please upload Experience-4 Certificate";
                        //        lblExp4.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}

                        //if (divExp5.Visible)
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["EXPERIENCE5"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["EXPERIENCE5"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblExp5.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblExp5.Text = "Please upload Experience-5 Certificate";
                        //            lblExp5.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblExp5.Text = "Please upload Experience-5 Certificate";
                        //        lblExp5.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}

                        //if (divExp6.Visible)
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["EXPERIENCE6"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["EXPERIENCE6"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblExp6.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblExp6.Text = "Please upload Experience-6 Certificate";
                        //            lblExp6.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblExp6.Text = "Please upload Experience-6 Certificate";
                        //        lblExp6.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}

                        //if (divExp7.Visible)
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["EXPERIENCE7"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["EXPERIENCE7"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblExp7.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblExp7.Text = "Please upload Experience-7 Certificate";
                        //            lblExp7.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblExp7.Text = "Please upload Experience-7 Certificate";
                        //        lblExp7.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}

                        //if (divExp8.Visible)
                        //{
                        //    if (!string.IsNullOrEmpty(dt.Rows[0]["EXPERIENCE8"].ToString()))
                        //    {
                        //        if (Convert.ToInt32(dt.Rows[0]["EXPERIENCE8"]) == 1)
                        //        {
                        //            ViewState["ERROR"] = 0;
                        //            lblExp8.Visible = false;
                        //        }
                        //        else
                        //        {
                        //            lblExp8.Text = "Please upload Experience-8 Certificate";
                        //            lblExp8.Visible = true;
                        //            ViewState["ERROR"] = 1;
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        lblExp8.Text = "Please upload Experience-8 Certificate";
                        //        lblExp8.Visible = true;
                        //        ViewState["ERROR"] = 1;
                        //        return;
                        //    }
                        //}
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
            if (CheckBox1.Checked == false)
            {
                lblStatus.Text = "Please Check & confirm the declaration!";
                lblStatus.Visible = true;
                return;
            }

            validatePageValues();
            if (ViewState["ERROR"].ToString() == "1")
            {
                lblStatus.Text = "Please upload all documents or Previous Pages are not completed yet!";
                lblStatus.Visible = true;
            }
            else
            {
                try
                {
                    if (Session["APPNO"] == null)
                    {
                        Response.Redirect("SessionExpired");
                    }
                    else
                    {
                        AppNo = Session["APPNO"].ToString();

                        int rex = site.executeNonQuery("UPDATE APPLICANT SET DOCUMENT_PAGE=1,DATED='"+ today +"' WHERE USERID='" + AppNo + "'");

                        RegistrationMail(Session["Email"].ToString(), AppNo, Session["Name"].ToString(), Session["Post"].ToString());

                        if (rex == 0)
                        {
                            lblStatus.Text = "Error, not able to update records";
                        }
                        else
                        {
                            //Session["MAKE_PAYMENT"] = "YES";
                            Response.Redirect("Download", false);
                            //Response.Redirect("PaymentGateway");
                            
                        }
                    }
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
        }
        protected void btnPrev_Click(object sender, EventArgs e)
        {
            Response.Redirect("workexperience",false);
        }
        private void markUploadDox(string xFileUploaded)
        {
            try
            {
                if (Session["APPNO"] == null)
                    Response.Redirect("SessionExpired");
                else
                {
                    AppNo = Session["APPNO"].ToString();
                    string xSQL = "UPDATE APPLICANT SET " + xFileUploaded + " = 1 WHERE USERID='" + AppNo + "'";
                    int rex = site.executeNonQuery(xSQL);
                    if (rex == 0)
                    {
                        lblStatus.Text = "Error, not able to update records";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fetch Error:" + ex.Message);
            }
        }

        private void RegistrationMail(string xEmail, string xRegno, string xName, string xPost)
        {
            //xEmail = "sahu.netra@gmail.com";
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("HAL-Koraput", "no-reply@reg.org.in"));
            message.To.Add(new MailboxAddress(xEmail, xEmail));
            message.Subject = "HAL Koraput: Application Successfully Submitted";

            var builder = new BodyBuilder();

            builder.TextBody = "Dear " + xName + ",\n\n"
                + "Application Number : " + xRegno + "\n\n"

                + "We are pleased to inform you that your application for the position of "+ xPost + " at HAL, Koraput has been successfully submitted. Thank you for your interest and effort.\n\n"

                //+ "Please note that the tentative date for the examination is scheduled for March 18th, in Bhubaneswar, Odisha.\n\n"

                + "Further details, including the process for downloading the admit card and any updates regarding the examination, will be communicated to you via email. Please ensure to actively monitor your inbox for any notifications.\n\n"

                + "If you encounter any difficulties, feel free to write us at halkpt@reg.org.in. No other method of communication will be entertained.\n\n"

                + "Best Regards, \n\n"
                + "Hindustan Aeronautics Limited, Koraput\n"
                + "9234191300\n\nhalkpt@reg.org.in\n"

                + "Note: This is an auto generated email, so please do not reply back.\n";

            //builder.Attachments.Add(Server.MapPath("../pdf/files/" + Appno + ".pdf"));
            message.Body = builder.ToMessageBody();

            var client = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                client.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                client.Connect("smtp.zeptomail.com", 587, false);
                client.Authenticate("emailapikey", "wSsVR610/RamCawvnmH7J+0xz19cBA/2REx5iVeg7XWvGvqTosc5l0zHUwT2TvlJFDY6E2Ybou58nUgA1zIJ3dUvmQ0JDyiF9mqRe1U4J3x17qnvhDzJXm9dlxCBKY4Ixglik2NjEcwm+g==");
                client.Send(message);
                client.Disconnect(true);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
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