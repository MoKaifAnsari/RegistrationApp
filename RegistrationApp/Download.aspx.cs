using System;

namespace RegistrationApp
{
    public partial class Download : System.Web.UI.Page
    {
        string xFile = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            xFile = Session["APPNO"].ToString();
            lblRegno.Text = "Application No : " + xFile;
            lblName.Text = "Applicant Name : " + Session["NAME"].ToString();
        }

        protected void Link_Click(object sender, EventArgs e)
        {
            xFile = Session["APPNO"].ToString() + ".pdf";
            var filePath = "\\AdmitCard\\" + xFile;
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + xFile);
            Response.TransmitFile(filePath);
            Response.End();
        }
        protected void btnProfile_Click(object sender, EventArgs e)
        {
            if (Session["APPNO"] != null)
            {
                string xAppno = Session["APPNO"].ToString();
                string path = Server.MapPath("/profile/") + xAppno + ".pdf";
                string logoPath = Server.MapPath("img/header.png");
                string photoPath = Server.MapPath("UPLOADEDFILES/PHOTOGRAPH/" + xAppno + "_photo.jpg");
                string signPath = Server.MapPath("UPLOADEDFILES/SIGNATURE/" + xAppno + "_sign.jpg");
                string pathAdhar = Server.MapPath("UPLOADEDFILES/AADHAR/" + xAppno + "_adhar.jpg");
                //string pathCaste = Server.MapPath("UPLOADEDFILES/CASTE/" + xAppno + "_caste.jpg");
                //string pathPwd = Server.MapPath("UPLOADEDFILES/PWD/" + xAppno + "_pwd.jpg");
                //string Path10 = Server.MapPath("UPLOADEDFILES/BOARD10/" + xAppno + "_ten.jpg");
                //string Path12 = Server.MapPath("UPLOADEDFILES/BOARD12/" + xAppno + "_twelve.jpg");
                //string PathDegree = Server.MapPath("UPLOADEDFILES/degree/" + xAppno + "_degree.jpg");
                //string PathCombat = Server.MapPath("UPLOADEDFILES/COMBATANT/" + xAppno + "_combat.jpg");
                //string PathSpl = Server.MapPath("UPLOADEDFILES/special/" + xAppno + "_spl.jpg");
                //string PathDomicile = Server.MapPath("UPLOADEDFILES/DOMICILE/" + xAppno + "_dom.jpg");
                //string PathExp1 = Server.MapPath("UPLOADEDFILES/EXPERIENCE1/" + xAppno + "_exp1.jpg");
                //string PathExp2 = Server.MapPath("UPLOADEDFILES/EXPERIENCE2/" + xAppno + "_exp2.jpg");
                //string PathExp3 = Server.MapPath("UPLOADEDFILES/EXPERIENCE3/" + xAppno + "_exp3.jpg");
                //string PathExp4 = Server.MapPath("UPLOADEDFILES/EXPERIENCE4/" + xAppno + "_exp4.jpg");
                //string PathExp5 = Server.MapPath("UPLOADEDFILES/EXPERIENCE5/" + xAppno + "_exp5.jpg");

                siteclass siteclass = new siteclass();
                //string xVal = siteclass.CreatePofile_Executive_Nashik(xAppno, path, logoPath, photoPath, signPath, pathAdhar, pathCaste, pathPwd, Path10, Path12, PathDegree, PathCombat, PathSpl, PathDomicile, PathExp1, PathExp2, PathExp3, PathExp4, PathExp5);
                string xVal = siteclass.CreatePofile_Executive_Nashik(xAppno, path, logoPath, photoPath, signPath, pathAdhar);

                if (xVal == "OK")
                {
                    //string pathFILE = Server.MapPath("/profile/") + xAppno + ".pdf";
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + xAppno + ".pdf");
                    Response.TransmitFile(path);
                    Response.End();
                }


            }
        }
    }
}