using Grpc.Core;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using Cell = iText.Layout.Element.Cell;
using Document = iText.Layout.Document;
using Image = iText.Layout.Element.Image;
using Paragraph = iText.Layout.Element.Paragraph;
using Table = iText.Layout.Element.Table;

namespace RegistrationApp
{
    public class siteclass
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);

        public DataTable getdatatable(string sqlStr)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataSet getdataset(string sqlStr)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        public int executeNonQuery(String sqlStr)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            int rex = cmd.ExecuteNonQuery();
            con.Close();
            return rex;
        }
        public int getOfflineStatus(string xFieldName)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from utility", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            int xOnline = 0;
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][xFieldName].ToString() == "1")
                    xOnline = 1;
            }
            return xOnline;
        }

        public string ValidateTextNumberWithourSpecialChars(string xStr)
        {
            string xStatus = "NO";
            Regex regex = new Regex("^[\\w-/. ]*$");            //Aa-zZ0-9-.space
            Match match = regex.Match(xStr);
            if (match.Success)
            {
                xStatus = "YES";
            }
            return xStatus;
        }
        public string ValidateTextWithourSpecialChars(string xStr)
        {
            string xStatus = "NO";
            Regex regex = new Regex("^[\\w ]*$");            //Aa-zZspace
            //Regex regex = new Regex("^[A-Za-z ]+$");
            Match match = regex.Match(xStr);
            if (match.Success)
            {
                xStatus = "YES";
            }
            return xStatus;
        }
        public string ValidateNumbers(string xNum)
        {
            string xStatus = "NO";
            Regex regex = new Regex("^[0-9]+$");
            Match match = regex.Match(xNum);
            if (match.Success)
            {
                xStatus = "YES";
            }
            return xStatus;
        }

        public string calculatePeriod(string xDate1, string xDate2)
        {
            string xStatus = "";
            DateTime cuttoffDate = DateTime.Parse(xDate2);
            DateTime candDateofBirth = DateTime.Parse(xDate1);
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
            xStatus = string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                xYear, (xYear == 1) ? "" : "s",
                xMon, (xMon == 1) ? "" : "s",
                xDays, (xDays == 1) ? "" : "s");
            return xStatus;
        }
        public string CreatePofile_Executive_Nashik(string xAppno, string path, string logoPath, string photoPath, string signPath, string pathAdhar)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from APPLICANT where USERID='" + xAppno + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    //string xAppno = dt.Rows[x]["USERID"].ToString().Trim();
                    //string xPost = dt.Rows[x]["APPLIED_DISCIPLINE"].ToString().Trim();
                    //string path = Server.MapPath("/profile/") + xAppno + ".pdf";

                    using (PdfWriter writer = new PdfWriter(path))
                    using (PdfDocument pdf = new PdfDocument(writer))
                    using (Document doc = new Document(pdf))
                    {
                        PageSize pageSize = PageSize.A4;
                        PdfPage page = pdf.AddNewPage(pageSize);
                        doc.SetMargins(10, 10, 10, 10);
                        doc.SetFontSize(10);
                        Table table = new Table(new float[] { 100, 350, 120 });

                        //string logoPath = Server.MapPath("img/header_Nashik.png");
                        Image image = new Image(ImageDataFactory.Create(logoPath));
                        Cell cell = new Cell(1, 3);
                        cell.SetMarginTop(10);
                        image.SetWidth(570);
                        image.SetHeight(40);
                        cell.SetWidth(100);
                        cell.SetHeight(45);
                        cell.Add(image);
                        table.AddCell(cell);

                        doc.Add(table);
                        float[] wid = { 200.0f, 300.0f, 120.0f };
                        table = new Table(wid);
                        Cell header = new Cell(1, 4).Add(new Paragraph("Application Form"));
                        header.SetTextAlignment(TextAlignment.CENTER);
                        header.SetFontSize(12);
                        header.SetBold();
                        table.AddCell(header);


                        Cell cell2 = new Cell().Add(new Paragraph("Application Number"));
                        cell2.SetHeight(22);
                        //cell2.SetWidth(200);
                        cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                        table.AddCell(cell2);

                        Cell cell3 = new Cell().Add(new Paragraph(xAppno));
                        //cell3.SetWidth(350);
                        cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                        table.AddCell(cell3);


                        //// Add cells with rowspan and colspan
                        //string photoPath = Server.MapPath("UPLOADEDFILESEXE/PHOTOGRAPH/" + xAppno + "_photo.jpg");
                        if (File.Exists(photoPath))
                        {
                            Image imgPhoto = new Image(ImageDataFactory.Create(photoPath)).SetBorder(Border.NO_BORDER);
                            Cell photoCell = new Cell(5, 1); // 5 rows, 1 columns
                            imgPhoto.SetWidth(UnitValue.CreatePointValue(100)); // Set the width in points
                            imgPhoto.SetHeight(UnitValue.CreatePointValue(100)); //
                            imgPhoto.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                            photoCell.SetWidth(UnitValue.CreatePercentValue(5));
                            //photoCell.SetWidth(100);
                            photoCell.Add(imgPhoto);
                            table.AddCell(photoCell);
                        }

                        Cell cell5 = new Cell().Add(new Paragraph("Post Applied for"));
                        cell5.SetHeight(22);
                        //cell5.SetWidth(200);
                        cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                        table.AddCell(cell5);

                        Cell cell6 = new Cell().Add(new Paragraph(dt.Rows[x]["APPLIED_DISCIPLINE"].ToString().Trim()));
                        cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                        cell6.SetWidth(350);
                        table.AddCell(cell6);

                        Cell cell7 = new Cell().Add(new Paragraph("Name of Applicant"));
                        cell7.SetHeight(22);
                        cell7.SetWidth(200);
                        cell7.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                        table.AddCell(cell7);

                        string xName = dt.Rows[x]["APPLICANT_NAME"].ToString().Trim();
                        Cell cell8 = new Cell().Add(new Paragraph(xName));
                        cell8.SetWidth(350);
                        cell8.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                        table.AddCell(cell8);

                        // Cell cell9 = new Cell().Add(new Paragraph("Father's Name :" + dt.Rows[x]["FATHER_NAME"].ToString().Trim()));
                        //Cell cell9 = new Cell().Add(new Paragraph("Gender : " + dt.Rows[x]["GENDER"].ToString().Trim()));
                        DateTime xDate = DateTime.Parse(dt.Rows[x]["DOB"].ToString());
                        Cell cell9 = new Cell().Add(new Paragraph("Date of Birth : " + xDate.ToString("dd-MM-yyyy")));
                        cell9.SetHeight(22);
                        cell9.SetWidth(200);
                        cell9.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                        table.AddCell(cell9);

                        //Cell cell10 = new Cell().Add(new Paragraph(dt.Rows[x]["FATHER_NAME"].ToString().Trim()));
                        //cell10.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                        //cell10.SetWidth(350);
                        //table.AddCell(cell10);

                        //Cell cell11 = new Cell().Add(new Paragraph("Mother's Name :" + dt.Rows[x]["MOTHER_NAME"].ToString().Trim()));
                        //Cell cell11 = new Cell().Add(new Paragraph("Marital Status : " + dt.Rows[x]["MARITAL_STATUS"].ToString().Trim())); 
                        Cell cell11 = new Cell().Add(new Paragraph("Age as on 01-05-2024: " + dt.Rows[x]["APPLICANT_AGE"].ToString().Trim()));
                        cell11.SetWidth(200);
                        cell11.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                        table.AddCell(cell11);
                        doc.Add(table);
                        table = new Table(new float[] { 150, 300, 150 });


                        Cell cell17 = new Cell(1, 3).Add(new Paragraph("Basic Details :"));
                        cell17.SetBold();
                        table.AddCell(cell17);

                        doc.Add(table);

                        table = new Table(new float[] { 1, 1 });
                        table.SetWidth(575);
                        Cell cell18f = new Cell().Add(new Paragraph("Father's Name : " + dt.Rows[x]["FATHER_NAME"].ToString().Trim()));
                        table.AddCell(cell18f);
                        Cell cell20m = new Cell().Add(new Paragraph("Mother's Name : " + dt.Rows[x]["MOTHER_NAME"].ToString().Trim()));
                        table.AddCell(cell20m);
                        doc.Add(table);
                        table = new Table(new float[] { 150, 270, 170 });


                        //DateTime xDate = DateTime.Parse(dt.Rows[x]["DOB"].ToString());
                        Cell cell27 = new Cell().Add(new Paragraph("Gender : " + dt.Rows[x]["GENDER"].ToString().Trim()));
                        table.AddCell(cell27);
                        Cell cell28 = new Cell().Add(new Paragraph("Marital Status : " + dt.Rows[x]["MARITAL_STATUS"].ToString().Trim()));
                        table.AddCell(cell28);
                        Cell cell21a = new Cell().Add(new Paragraph("Religion : " + dt.Rows[x]["RELIGION_NAME"].ToString().Trim()));
                        table.AddCell(cell21a);
                        //Cell cell19 = new Cell().Add(new Paragraph("Nationality : " + dt.Rows[x]["NATIONALITY"].ToString().Trim()));
                        //table.AddCell(cell19);

                        Cell cell21 = new Cell().Add(new Paragraph("Category : " + dt.Rows[x]["CATEGORY_APPLIED"].ToString().Trim()));
                        table.AddCell(cell21);
                        Cell cell22 = new Cell().Add(new Paragraph("Caste Certificate No. : " + dt.Rows[x]["CASTE_CERT_NO"].ToString().Trim()));
                        table.AddCell(cell22);
                        Cell cell23 = new Cell().Add(new Paragraph("Issue Date : " + dt.Rows[x]["CASTE_CERT_ISSUE_DATE"].ToString().Trim()));
                        table.AddCell(cell23);

                        Cell cell24 = new Cell().Add(new Paragraph("PwD : " + dt.Rows[x]["PWD_APPLIED"].ToString().Trim()));
                        table.AddCell(cell24);
                        Cell cell25 = new Cell().Add(new Paragraph("PwD Type : " + dt.Rows[x]["PWD_TYPE"].ToString().Trim()));
                        table.AddCell(cell25);
                        Cell cell26 = new Cell().Add(new Paragraph("PwD % : " + dt.Rows[x]["PWD_PERCENT"].ToString().Trim()));
                        table.AddCell(cell26);


                        Cell cell30 = new Cell().Add(new Paragraph("Aadhar No. : " + dt.Rows[x]["AADHAR_NO"].ToString().Trim()));
                        table.AddCell(cell30);
                        Cell cell32 = new Cell().Add(new Paragraph("EMail Id : " + dt.Rows[x]["EMAIL"].ToString().Trim()));
                        table.AddCell(cell32);
                        Cell cell31 = new Cell().Add(new Paragraph("Mobile No. : " + dt.Rows[x]["MOBILE"].ToString().Trim()));
                        table.AddCell(cell31);


                        Cell cell29 = new Cell().Add(new Paragraph("Domicile State : " + dt.Rows[x]["DOMICILE_STATE"].ToString().Trim()));
                        table.AddCell(cell29);
                        Cell cell18 = new Cell().Add(new Paragraph("Domicile of Jammu & Kashmir : " + dt.Rows[x]["JK_DOMICILE"].ToString().Trim()));
                        table.AddCell(cell18);
                        string DateD = dt.Rows[x]["DOMICILE_DATE"].ToString();
                        if (!string.IsNullOrEmpty(DateD))
                        {
                            DateTime DDate = DateTime.Parse(dt.Rows[x]["DOMICILE_DATE"].ToString());
                            Cell cell20d = new Cell().Add(new Paragraph("Issue Date : " + DDate.ToString("dd-MM-yyyy").Trim()));
                            table.AddCell(cell20d);
                        }
                        else
                        {
                            Cell cell20d = new Cell().Add(new Paragraph("Issue Date : "));
                            table.AddCell(cell20d);
                        }

                        doc.Add(table);

                        table = new Table(new float[] { 1, 1, 1, 1, 1, 1 });
                        table.SetWidth(575);
                        if (dt.Rows[x]["RELEVANT_EXP"].ToString().Trim().ToUpper() == "NO")
                        {
                            cell18 = new Cell(1, 6).Add(new Paragraph("Relevant Experiences? : " + dt.Rows[x]["RELEVANT_EXP"].ToString().Trim()));
                            cell18.SetBold();
                            table.AddCell(cell18);
                        }
                        else
                        {
                            cell18 = new Cell(1, 3).Add(new Paragraph("Relevant Experiences? : " + dt.Rows[x]["RELEVANT_EXP"].ToString().Trim()));
                            cell18.SetBold();
                            table.AddCell(cell18);
                            if (dt.Rows[x]["RELEVANT_EXP"].ToString() == "Yes")
                            {
                                Cell cell201 = new Cell(1, 3).Add(new Paragraph("Relevant Exp. Duration : " + dt.Rows[0]["REL_YEARS"].ToString().Trim() + " year(s) " + dt.Rows[0]["REL_MONTH"].ToString().Trim() + " month(s) " + dt.Rows[0]["REL_DAY"].ToString().Trim() + " day(s)"));
                                table.AddCell(cell201);
                            }
                            else
                            {
                                Cell cell201 = new Cell(1, 3).Add(new Paragraph(""));
                                table.AddCell(cell201);
                            }
                        }

                        if (dt.Rows[x]["EX_SERVICE_MAN"].ToString().Trim().ToUpper() == "NO")
                        {
                            cell18 = new Cell(1, 6).Add(new Paragraph("Ex-Serviceman Experience(Armed Forces)? : " + dt.Rows[x]["EX_SERVICE_MAN"].ToString().Trim()));
                            cell18.SetBold();
                            table.AddCell(cell18);
                        }
                        else
                        {
                            cell18 = new Cell(1, 3).Add(new Paragraph("Ex-Serviceman Experience(Armed Forces)? : " + dt.Rows[x]["EX_SERVICE_MAN"].ToString().Trim()));
                            cell18.SetBold();
                            table.AddCell(cell18);
                            if (dt.Rows[x]["EX_SERVICE_MAN"].ToString() == "Yes")
                            {
                                Cell cell201 = new Cell(1, 3).Add(new Paragraph("Period of Ex-Serviceman Exp. : " + dt.Rows[0]["EXP_YEAR"].ToString().Trim() + " year(s) " + dt.Rows[0]["EXP_MONTH"].ToString().Trim() + " month(s) " + dt.Rows[0]["EXP_DAY"].ToString().Trim() + " day(s)"));
                                table.AddCell(cell201);
                            }
                            else
                            {
                                Cell cell201 = new Cell(1, 3).Add(new Paragraph(""));
                                table.AddCell(cell201);
                            }
                        }

                        //cell18 = new Cell(1,1).Add(new Paragraph("Ex-Servicemen Experience(Armed Forces)? : " + dt.Rows[x]["EX_SERVICE_MAN"].ToString().Trim()));
                        //table.AddCell(cell18);
                        //Cell cell20 = new Cell(1,3).Add(new Paragraph("Period of Ex-Servicemen Exp. : " + dt.Rows[x]["EXP_YEAR"].ToString().Trim() + " years " + dt.Rows[x]["EXP_MONTH"].ToString().Trim() + " months " + dt.Rows[x]["EXP_DAY"].ToString().Trim() + " days"));
                        //table.AddCell(cell20);

                        //doc.Add(table);


                        Cell celladd17 = new Cell(1, 6).Add(new Paragraph("Address Details :"));
                        celladd17.SetBold();
                        table.AddCell(celladd17);
                        doc.Add(table);

                        table = new Table(new float[] { 1, 1, 1 });
                        table.SetWidth(575);
                        Cell cell13 = new Cell(1, 1).Add(new Paragraph("Communication Address"));
                        cell13.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                        table.AddCell(cell13);

                        string xAdd = dt.Rows[0]["HOUSE_NO_CA"].ToString().Trim() + ", " + dt.Rows[0]["AREA_CA"].ToString().Trim() + ", " + dt.Rows[0]["LANDMARK_CA"].ToString().Trim() + ", " + dt.Rows[0]["CITY_CA"].ToString().Trim() + ", " + dt.Rows[0]["DISTRICT_CA"].ToString().Trim() + ", " + dt.Rows[0]["STATE_CA"].ToString().Trim() + ", " + dt.Rows[0]["PIN_CA"].ToString().Trim() + ", " + dt.Rows[0]["POST_OFFICE_CA"].ToString().Trim() + ", " + dt.Rows[0]["RAILWAY_STATION_CA"].ToString().Trim();
                        Cell cell14 = new Cell(1, 2).Add(new Paragraph(xAdd));
                        table.AddCell(cell14);

                        Cell cell15 = new Cell(1, 1).Add(new Paragraph("Permanent Address"));
                        cell15.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                        table.AddCell(cell15);

                        xAdd = dt.Rows[0]["HOUSE_NO_PA"].ToString().Trim() + ", " + dt.Rows[0]["AREA_PA"].ToString().Trim() + ", " + dt.Rows[0]["LANDMARK_PA"].ToString().Trim() + ", " + dt.Rows[0]["CITY_PA"].ToString().Trim() + ", " + dt.Rows[0]["DISTRICT_PA"].ToString().Trim() + ", " + dt.Rows[0]["STATE_PA"].ToString().Trim() + ", " + dt.Rows[0]["PIN_PA"].ToString().Trim() + ", " + dt.Rows[0]["POST_OFFICE_PA"].ToString().Trim() + ", " + dt.Rows[0]["RAILWAY_STATION_PA"].ToString().Trim();
                        Cell cell16 = new Cell(1, 2).Add(new Paragraph(xAdd));
                        table.AddCell(cell16);

                        Cell cell33 = new Cell(1, 3).Add(new Paragraph("Educational Qualifications :"));
                        cell33.SetBold();
                        table.AddCell(cell33);

                        doc.Add(table);

                        table = new Table(new float[] { 1, 1, 1, 1, 1, 1 });
                        table.SetWidth(575);

                        //header
                        Cell cell34 = new Cell().Add(new Paragraph("Examination Passed"));
                        table.AddCell(cell34);
                        Cell cell38 = new Cell().Add(new Paragraph("Stream"));
                        table.AddCell(cell38);
                        cell38 = new Cell().Add(new Paragraph("Education Mode"));
                        table.AddCell(cell38);
                        Cell cell35 = new Cell().Add(new Paragraph("Name of Board/University"));
                        table.AddCell(cell35);
                        Cell cell36 = new Cell().Add(new Paragraph("Passing Year"));
                        table.AddCell(cell36);
                        Cell cell37 = new Cell().Add(new Paragraph("Marks(%)"));
                        table.AddCell(cell37);


                        //tenth
                        Cell cell39 = new Cell().Add(new Paragraph("10th"));
                        table.AddCell(cell39);
                        Cell cell43 = new Cell().Add(new Paragraph(dt.Rows[x]["BOARD10_SUBJECTS"].ToString().Trim()));
                        table.AddCell(cell43);
                        Cell cell40 = new Cell().Add(new Paragraph(dt.Rows[x]["BOARD10_NATURE"].ToString().Trim()));
                        table.AddCell(cell40);
                        cell40 = new Cell().Add(new Paragraph(dt.Rows[x]["BOARD10_INST"].ToString().Trim()));
                        table.AddCell(cell40);
                        Cell cell41 = new Cell().Add(new Paragraph(dt.Rows[x]["BOARD10_PASSING_DATE"].ToString().Trim()));
                        table.AddCell(cell41);
                        Cell cell42 = new Cell().Add(new Paragraph(dt.Rows[x]["BOARD10_PERCENT"].ToString().Trim()));
                        table.AddCell(cell42);

                        //Twelfth
                        if (!string.IsNullOrEmpty(dt.Rows[x]["BOARD12_SUBJECTS"].ToString()))
                        {
                            Cell cell44 = new Cell().Add(new Paragraph("12th"));
                            table.AddCell(cell44);
                            Cell cell48 = new Cell().Add(new Paragraph(dt.Rows[x]["BOARD12_SUBJECTS"].ToString().Trim()));
                            table.AddCell(cell48);
                            cell48 = new Cell().Add(new Paragraph(dt.Rows[x]["BOARD12_NATURE"].ToString().Trim()));
                            table.AddCell(cell48);
                            Cell cell45 = new Cell().Add(new Paragraph(dt.Rows[x]["BOARD12_INST"].ToString().Trim()));
                            table.AddCell(cell45);
                            Cell cell46 = new Cell().Add(new Paragraph(dt.Rows[x]["BOARD12_PASSING_DATE"].ToString().Trim()));
                            table.AddCell(cell46);
                            Cell cell47 = new Cell().Add(new Paragraph(dt.Rows[x]["BOARD12_PERCENT"].ToString().Trim()));
                            table.AddCell(cell47);
                        }
                        //ITI
                        if (!string.IsNullOrEmpty(dt.Rows[x]["ITI_INST"].ToString()))
                        {
                            Cell cell49d = new Cell().Add(new Paragraph("TIT"));
                            table.AddCell(cell49d);
                            Cell cell50d = new Cell().Add(new Paragraph(dt.Rows[x]["ITI_SUBJECTS"].ToString().Trim()));
                            table.AddCell(cell50d);
                            cell50d = new Cell().Add(new Paragraph(dt.Rows[x]["ITI_NATURE"].ToString().Trim()));
                            table.AddCell(cell50d);
                            Cell cell51d = new Cell().Add(new Paragraph(dt.Rows[x]["ITI_INST"].ToString().Trim()));
                            table.AddCell(cell51d);
                            Cell cell52a = new Cell().Add(new Paragraph(dt.Rows[x]["ITI_PASSING_DATE"].ToString().Trim()));
                            table.AddCell(cell52a);
                            Cell cell53 = new Cell().Add(new Paragraph(dt.Rows[x]["ITI_PERCENT"].ToString().Trim()));
                            table.AddCell(cell53);
                        }
                        //Diploma
                        if (!string.IsNullOrEmpty(dt.Rows[x]["DIPLOMA_INST"].ToString()))
                        {
                            Cell cell49d = new Cell().Add(new Paragraph("DIPLOMA"));
                            table.AddCell(cell49d);
                            Cell cell50d = new Cell().Add(new Paragraph(dt.Rows[x]["DIPLOMA_SUBJECTS"].ToString().Trim()));
                            table.AddCell(cell50d);
                            cell50d = new Cell().Add(new Paragraph(dt.Rows[x]["DIPLOMA_NATURE"].ToString().Trim()));
                            table.AddCell(cell50d);
                            Cell cell51d = new Cell().Add(new Paragraph(dt.Rows[x]["DIPLOMA_INST"].ToString().Trim()));
                            table.AddCell(cell51d);
                            Cell cell52a = new Cell().Add(new Paragraph(dt.Rows[x]["DIPLOMA_PASSING_DATE"].ToString().Trim()));
                            table.AddCell(cell52a);
                            Cell cell53 = new Cell().Add(new Paragraph(dt.Rows[x]["DIPLOMA_PERCENT"].ToString().Trim()));
                            table.AddCell(cell53);
                        }
                        //NAC
                        if (!string.IsNullOrEmpty(dt.Rows[0]["NAC_UNIV"].ToString()))
                        {
                            Cell cell49d = new Cell().Add(new Paragraph("NAC"));
                            table.AddCell(cell49d);
                            Cell cell50d = new Cell().Add(new Paragraph(""));
                            table.AddCell(cell50d);
                            cell50d = new Cell().Add(new Paragraph(""));
                            table.AddCell(cell50d);
                            Cell cell51d = new Cell().Add(new Paragraph(dt.Rows[x]["NAC_UNIV"].ToString().Trim()));
                            table.AddCell(cell51d);
                            Cell cell52a = new Cell().Add(new Paragraph(dt.Rows[x]["NAC_NCTVT_PASSING_DATE"].ToString().Trim()));
                            table.AddCell(cell52a);
                            Cell cell53 = new Cell().Add(new Paragraph(dt.Rows[x]["NAC_NCTVT_PERCENT"].ToString().Trim()));
                            table.AddCell(cell53);
                        }

                        string post = dt.Rows[0]["APPLIED_DISCIPLINE"].ToString().Trim();
                        if (post == "ESM Technician (Aircraft Artificer-Air Engineering)" || post == "ESM Technician (Mechanician-Air Electrical)" || post == "ESM Technician (Engine Fitter)" || post == "ESM Technician (Electrical Fitter)")
                        {
                            Cell cell49ESM = new Cell(1, 6).Add(new Paragraph("Detaiol of Airforce :"));
                            cell49ESM.SetBold();
                            table.AddCell(cell49ESM);

                            cell49ESM = new Cell(1, 4).Add(new Paragraph("Airforce Trade"));
                            table.AddCell(cell49ESM);
                            cell49ESM = new Cell(1, 2).Add(new Paragraph("Date"));
                            table.AddCell(cell49ESM);

                            cell49ESM = new Cell(1, 4).Add(new Paragraph(dt.Rows[0]["ESM_CERT_NO"].ToString().Trim()));
                            table.AddCell(cell49ESM);
                            cell49ESM = new Cell(1, 2).Add(new Paragraph(DateTime.Parse(dt.Rows[0]["ESM_PASSING_DATE"].ToString()).ToString("dd/MM/yyyy")));
                            table.AddCell(cell49ESM);

                        }
                        if (post == "Security Guard")
                        {
                            Cell cell49ESM = new Cell(1, 6).Add(new Paragraph("Detaiol of Combatant Experiences :"));
                            cell49ESM.SetBold();
                            table.AddCell(cell49ESM);

                            cell49ESM = new Cell(1, 3).Add(new Paragraph("Rank Held"));
                            table.AddCell(cell49ESM);
                            cell49ESM = new Cell().Add(new Paragraph("Joining Date"));
                            table.AddCell(cell49ESM);
                            cell49ESM = new Cell().Add(new Paragraph("Leaving Date"));
                            table.AddCell(cell49ESM);
                            cell49ESM = new Cell().Add(new Paragraph("Duration"));
                            table.AddCell(cell49ESM);

                            cell49ESM = new Cell(1, 3).Add(new Paragraph(dt.Rows[0]["RANK_HELD2"].ToString().Trim()));
                            table.AddCell(cell49ESM);
                            cell49ESM = new Cell().Add(new Paragraph(DateTime.Parse(dt.Rows[0]["JOINING_DATE"].ToString()).ToString("dd/MM/yyyy")));
                            table.AddCell(cell49ESM);
                            cell49ESM = new Cell().Add(new Paragraph(DateTime.Parse(dt.Rows[0]["LEAVING_DATE"].ToString()).ToString("dd/MM/yyyy")));
                            table.AddCell(cell49ESM);
                            cell49ESM = new Cell().Add(new Paragraph(dt.Rows[0]["PERIOD"].ToString().Trim()));
                            table.AddCell(cell49ESM);
                        }
                        doc.Add(table);

                        //Additional Qualifivation
                        table = new Table(new float[] { 1, 1, 1, 1, 1, 1 });
                        table.SetWidth(575);

                        Cell cell49 = new Cell(1, 6).Add(new Paragraph("Working Experience, if any : "));
                        cell49.SetBold();
                        table.AddCell(cell49);

                        Cell cell50 = new Cell().Add(new Paragraph("Name of the Post"));
                        table.AddCell(cell50);
                        cell50 = new Cell().Add(new Paragraph("Name of Organisation"));
                        table.AddCell(cell50);
                        cell50 = new Cell().Add(new Paragraph("Date of Joining"));
                        table.AddCell(cell50);
                        cell50 = new Cell().Add(new Paragraph("Date of Leaving"));
                        table.AddCell(cell50);
                        cell50 = new Cell().Add(new Paragraph("Salary (P.M.)"));
                        table.AddCell(cell50);
                        cell50 = new Cell().Add(new Paragraph("Period"));
                        table.AddCell(cell50);

                        for (int i = 1; i <= 5; i++)
                        {
                            string Desct = dt.Rows[x]["ORGANISATION_NAME_EXP" + i].ToString();
                            if (!string.IsNullOrEmpty(Desct))
                            {
                                cell50 = new Cell().Add(new Paragraph(dt.Rows[x]["DESIGNATION_EXP" + i].ToString().Trim()));
                                table.AddCell(cell50);
                                cell50 = new Cell().Add(new Paragraph(dt.Rows[x]["ORGANISATION_NAME_EXP" + i].ToString().Trim()));
                                table.AddCell(cell50);
                                Cell cell51a = new Cell().Add(new Paragraph(dt.Rows[x]["JOIN_DATE_EXP" + i].ToString().Trim()));
                                table.AddCell(cell51a);
                                cell51a = new Cell().Add(new Paragraph(dt.Rows[x]["END_DATE_EXP" + i].ToString().Trim()));
                                table.AddCell(cell51a);
                                Cell cell52 = new Cell().Add(new Paragraph(dt.Rows[x]["SALARY_PM_EXP" + i].ToString().Trim()));
                                table.AddCell(cell52);
                                cell51a = new Cell().Add(new Paragraph(dt.Rows[x]["PERIOD_EXP" + i].ToString().Trim()));
                                table.AddCell(cell51a);
                            }
                        }

                        //HAL working interview
                        doc.Add(table);

                        table = new Table(new float[] { 1, 1, 1, 1 });
                        table.SetWidth(575);

                        cell49 = new Cell(1, 4).Add(new Paragraph("Have you done any Apprenticeship in HAL? : " + dt.Rows[x]["HAL_APPRENTICESHIP"].ToString().Trim()));
                        cell49.SetBold();
                        table.AddCell(cell49);

                        if (dt.Rows[x]["HAL_APPRENTICESHIP"].ToString().Trim() == "Yes")
                        {
                            cell50 = new Cell().Add(new Paragraph("Name of Organization"));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph("Name of the Apprenticeship training"));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph("From Date"));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph("Upto Date"));
                            table.AddCell(cell50);

                            cell50 = new Cell().Add(new Paragraph(dt.Rows[x]["ORGANISATION_NAME_TRAINING1"].ToString().Trim()));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph(dt.Rows[x]["PROGRAM_NAME_TRAINING1"].ToString().Trim()));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph(dt.Rows[x]["JOIN_DATE_TRAINING1"].ToString().Trim()));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph(dt.Rows[x]["END_DATE_TRAINING1"].ToString().Trim()));
                            table.AddCell(cell50);
                        }
                        doc.Add(table);

                        table = new Table(new float[] { 1, 1, 1 });
                        table.SetWidth(575);

                        Cell cell49h = new Cell(1, 3).Add(new Paragraph("Have you been Interviewed by HAL any time earlier? : " + dt.Rows[x]["INTERVIEWED_BY_HAL"].ToString().Trim()));
                        cell49h.SetBold();
                        table.AddCell(cell49h);

                        if (dt.Rows[x]["INTERVIEWED_BY_HAL"].ToString().Trim().ToUpper() == "YES")
                        {
                            Cell cell50h = new Cell().Add(new Paragraph("Post Interviewed"));
                            table.AddCell(cell50h);
                            cell50h = new Cell().Add(new Paragraph("Date of Interview"));
                            table.AddCell(cell50h);
                            cell50h = new Cell().Add(new Paragraph("Venue of Interview"));
                            table.AddCell(cell50h);

                            cell50 = new Cell().Add(new Paragraph(dt.Rows[x]["POST_INTERVIEWED"].ToString().Trim()));
                            table.AddCell(cell50);
                            string Hatdate = dt.Rows[x]["INTERVIEWED_DATE"].ToString();
                            if (!string.IsNullOrEmpty(Hatdate))
                            {
                                DateTime Jdate = DateTime.Parse(dt.Rows[x]["INTERVIEWED_DATE"].ToString());
                                cell50 = new Cell().Add(new Paragraph(Jdate.ToString("dd-MM-yyyy").Trim()));
                                table.AddCell(cell50);
                            }
                            Cell cell51h = new Cell().Add(new Paragraph(dt.Rows[x]["INTERVIEWED_VENUE"].ToString().Trim()));
                            table.AddCell(cell51h);
                        }

                        //HAL Working
                        doc.Add(table);
                        table = new Table(new float[] { 1, 1, 1, 1 });
                        table.SetWidth(575);

                        cell49 = new Cell(1, 4).Add(new Paragraph("Are any of your close relatives working in HAL, Koraput? : " + dt.Rows[x]["RELATIVE_WITH_HAL"].ToString().Trim()));
                        cell49.SetBold();
                        table.AddCell(cell49);
                        if (dt.Rows[x]["RELATIVE_WITH_HAL"].ToString().Trim().ToUpper() == "YES")
                        {
                            cell50 = new Cell().Add(new Paragraph("Name of Relative"));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph("Designation"));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph("Division"));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph("Any other Description"));
                            table.AddCell(cell50);

                            cell50 = new Cell().Add(new Paragraph(dt.Rows[x]["RELATIVE_NAME"].ToString().Trim()));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph(dt.Rows[x]["RELATIVE_DESIG"].ToString().Trim()));
                            table.AddCell(cell50);
                            Cell cell51r = new Cell().Add(new Paragraph(dt.Rows[x]["RELATIVE_DIVISION"].ToString().Trim()));
                            table.AddCell(cell51r);
                            cell51r = new Cell().Add(new Paragraph(dt.Rows[x]["RELATIVE_DESC"].ToString().Trim()));
                            table.AddCell(cell51r);
                        }
                        // Political Activities
                        doc.Add(table);
                        table = new Table(new float[] { 1, 1, 1, 1, 1 });
                        table.SetWidth(575);

                        cell49 = new Cell(1, 5).Add(new Paragraph("Member/Worker of any Political Party/Organisation or Participated in any Political Activities? : " + dt.Rows[x]["POLITICAL_RELATION"].ToString().Trim()));
                        cell49.SetBold();
                        table.AddCell(cell49);
                        if (dt.Rows[x]["POLITICAL_RELATION"].ToString().ToUpper() == "YES")
                        {
                            cell50 = new Cell().Add(new Paragraph("Name of Political Party/Organisation"));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph("Particulars of Political Activity"));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph("Period of Membership"));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph("Nature of Participation in Political Activity"));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph("Office, if any held in Political Party"));
                            table.AddCell(cell50);

                            cell50 = new Cell().Add(new Paragraph(dt.Rows[x]["POLITICAL_PARTY_NAME"].ToString().Trim()));
                            table.AddCell(cell50);
                            cell50 = new Cell().Add(new Paragraph(dt.Rows[x]["POLITICAL_ACTIVITY"].ToString().Trim()));
                            table.AddCell(cell50);
                            Cell cell51 = new Cell().Add(new Paragraph(dt.Rows[x]["POLITICAL_PERIOD"].ToString().Trim()));
                            table.AddCell(cell51);
                            cell51 = new Cell().Add(new Paragraph(dt.Rows[x]["POLITICAL_PARTICIPATION"].ToString().Trim()));
                            table.AddCell(cell51);
                            cell51 = new Cell(1, 1).Add(new Paragraph(dt.Rows[x]["POLITICAL_OFFICE_HELD"].ToString().Trim()));
                            table.AddCell(cell51);

                        }
                        doc.Add(table);

                        table = new Table(new float[] { 1, 1, 1 });
                        table.SetWidth(575);

                        Cell cell81 = new Cell(1, 3).Add(new Paragraph("Declarations"));
                        cell81.SetBold();
                        table.AddCell(cell81);

                        Cell cell812 = new Cell(1, 3).Add(new Paragraph("It is hereby declared that the information furnished by me herein above is true to my personal knowledge and belief. It is also declared that neither Criminal case is pending against me nor I have ever been punished by any court of law, nor am I involved in or related with any criminal case for any offence involving moral turpitude. I know that if anything stated herein above turns out to be false, the HAL, Koraput may cancel my candidature at any stage of Selection process and may debar me from appearing in the examination at its sole discretion. I further declare that if I obtain appointment on any false or incorrect information, my appointment shall be terminated/cancelled and I shall be liable for prosecution under the Law."));
                        cell81.SetFontSize(8);
                        table.AddCell(cell812);

                        Cell cell82 = new Cell(1, 4).Add(new Paragraph("I accept the above mentioned declaration : Yes"));
                        table.AddCell(cell82);

                        doc.Add(table);
                        table = new Table(new float[] { 1, 1 });
                        table.SetWidth(575);

                        Cell cell83 = new Cell().Add(new Paragraph("Date : " + DateTime.Parse(dt.Rows[x]["DATED"].ToString().Trim()).ToString("dd-MM-yyyy")));
                        table.AddCell(cell83);

                        //Cell cell84 = new Cell().Add(new Paragraph("\n\n"));
                        //table.AddCell(cell84);

                        //string signPath = Server.MapPath("UPLOADEDFILESEXE/SIGNATURE/" + xAppno + "_sign.jpg");
                        if (File.Exists(signPath))
                        {
                            Image imgSign = new Image(ImageDataFactory.Create(signPath));
                            imgSign.SetWidth(UnitValue.CreatePointValue(100)); // Set the width in points
                            imgSign.SetHeight(UnitValue.CreatePointValue(25)); //
                            imgSign.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                            Cell signCell = new Cell();
                            signCell.SetWidth(120);
                            signCell.Add(imgSign);
                            table.AddCell(signCell);
                        }

                        //imgSign.SetWidth(UnitValue.CreatePointValue(100)); // Set the width in points
                        //imgSign.SetHeight(UnitValue.CreatePointValue(25)); //
                        //imgSign.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                        //Cell signCell2 = new Cell();
                        //signCell.Add(imgSign);
                        //table.AddCell(signCell2);

                        Cell cell85 = new Cell().Add(new Paragraph(""));
                        cell85.SetWidth(285);
                        table.AddCell(cell85);

                        Cell cell86 = new Cell().Add(new Paragraph("( Signature of Applicant )")).SetTextAlignment(TextAlignment.CENTER);
                        cell86.SetWidth(290);
                        table.AddCell(cell86);

                        doc.Add(table);

                        //addon pages
                        //string pathAdhar = Server.MapPath("UPLOADEDFILESEXE/AADHAR/" + xAppno + "_adhar.jpg");
                        if (File.Exists(pathAdhar))
                        {
                            Image imgAdhar = new Image(ImageDataFactory.Create(pathAdhar)).SetAutoScale(true);
                            doc.Add(new AreaBreak());
                            table = new Table(new float[] { 1 });
                            cell = new Cell().Add(new Paragraph("Aadhar Card - " + xAppno)).SetTextAlignment(TextAlignment.CENTER);
                            table.AddCell(cell);
                            cell = new Cell().Add(new Paragraph($"Aadhar Card"));
                            doc.Add(table);
                            doc.Add(imgAdhar);
                        }

                        doc.Close();
                    }
                }

            }
            catch (Exception Ex)
            {
                //Response.Write(Ex.Message);
            }


            return "OK";
        }


    }
}