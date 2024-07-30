<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Preview.aspx.cs" Inherits="RegistrationApp.Preview" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
   <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>HAL - Profile</title>
    <link rel="icon" type="image/x-icon" href="/img/favicon.ico">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <!-- Custom fonts for this template-->
    <link href="css/all.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

    <%--this script is for eye field in password box--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom styles for this template -->
    <link href="css/layout.css" rel="stylesheet"> 
    <meta name="viewport" content="width=device-width, initial-scale=1"/>  
</head>

<body>
<form id="form1" runat="server">
<div id="printView" class="container invoice-container">
<page size="A4">     
    <div class="container-fluid bg-white">
      <div class="row">
          <div class="col-md-2 col-12" style="align-items:center">
              <div class="text-center">
                  <img src="img/header.png" class="img img-rounded img-responsive text-center" height="60px" width="650px" />
                </div>
          </div>
      </div>
      <div class="row">
          <div class="col-lg-6 col-12">
              <center class="py-1">
                  <h6>Application Form</h6>
              </center>
          </div>
      </div>
  </div>
    <table style="border:2px solid #000;">
        <tr><td>
        
        <table border="1" style="width:100%;">
            <tr>
                <td style="height:20px;">Application Number</td>
                <td style="height:20px;"><asp:Label ID="lblAppno" runat="server" Text=""></asp:Label></td>
                <td rowspan="4" style="height:20px;">

                    <center><asp:Image ID="imgPic" runat="server" AlternateText="img" Style="width:100px; margin-top:5px;"></asp:Image>
                    <br />
                    <asp:Image ID="imgSign" runat="server" AlternateText="sign" Width="100"></asp:Image></center>
                </td>
            </tr>
 
            <tr>
                <td style="height:20px;" class="mt-1">Post applied for</td>
                <td><asp:Label ID="lblPost" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td style="height:20px;">Name of Applicant</td>
                <td style="height:20px;"><asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td style="height:20px;">Date of Birth</td>
                <td style="height:20px;"><asp:Label ID="lblDOB" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>

        <table border="1" style="width:100%;">
          <tr>
               <td colspan="3"><b>Personal Information :</b></td>
           </tr>
          <tr>
              <td colspan="3">Father's Name: <asp:Label ID="lblFather" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
              <td colspan="3">Mother's Name: <asp:Label ID="lblMother" runat="server" Text=""></asp:Label></td>
          </tr>
             <tr>
                <td>Mobile Number : <span><asp:Label ID="lblMobile" runat="server" Text=""></asp:Label></span></td>
                <td>Email Id : <span><asp:Label ID="lblMail" runat="server" Text=""></asp:Label></span></td>
                 <td>Aadhar Number : <span><asp:Label ID="lblAdhar" runat="server" Text=""></asp:Label></span></td>
            </tr>

            <tr>
                <td>Gender : <span><asp:Label ID="lblGender" runat="server" Text=""></asp:Label></span></td>
                <td>Marital Status : <span><asp:Label ID="lblMarital" runat="server" Text=""></asp:Label></span></td>
                 <td>Nationality : <span><asp:Label ID="lblNationality" runat="server" Text=""></asp:Label></span></td>
            </tr>

            <tr>
                <td>Religion : <span><asp:Label ID="lblReligion" runat="server" Text=""></asp:Label></span></td>
                <td>Other Religion : <span><asp:Label ID="lblReligionOther" runat="server" Text=""></asp:Label></span></td>
                 <td>State of Domicile : <span><asp:Label ID="lblDomState" runat="server" Text=""></asp:Label></span></td>
            </tr>

            <tr>
                <td>Category : <span><asp:Label ID="lblCategory" runat="server" Text=""></asp:Label></span></td>
                <td>Caste Certificate No.: <span><asp:Label ID="lblCastNo" runat="server" Text=""></asp:Label></span></td>
                <td>Date of Issue : <span><asp:Label ID="lblCasteDate" runat="server" Text=""></asp:Label></span></td>
            </tr>

            <tr>
                <td>PwD : <span><asp:Label ID="lblPH" runat="server" Text=""></asp:Label></span></td>
                <td>PwD Type : <span><asp:Label ID="lblPwdType" runat="server" Text=""></asp:Label></span></td>
                <td>PwD % :<span><asp:Label ID="lblPHPer" runat="server" Text=""></asp:Label></span></td>
            </tr>
        </table>

        
        <table border="1" style="width:100%;">
           <tr>
                <td colspan="2"><b>Address Details :</b></td>
            </tr>
          <tr>
                <td>Communication Address</td>
                <td><asp:Label ID="lblAddress1" runat="server" Text=""></asp:Label></td>
          </tr>
          <tr>
                <td>Permanent Address</td>
                <td><asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label></td>
          </tr>
        </table>

        <table border="1" style="width:100%;">
          <tr>
               <td colspan="8"><b>Educational and Professional Qualifications :</b></td>
           </tr>
        <tr>
            <td>Name of Qualification with specialisation wherever applicable</td>
            <td>Institution / University</td>
            <td>Nature of the Course</td>
            <td>Duration of the Course</td>
            <td>Subjects / Specialisation</td>
          <%--  <td>Class / Division</td>--%>
            <td>% of Marks</td>
            <td>Date of Passing</td>
        </tr>

        <tr>
            <td>10th / Matriculation</td>
            <td><asp:Label ID="lblInst10" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblNature10" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblDuration10" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblSub10" runat="server" Text=""></asp:Label></td>
            <%--<td><asp:Label ID="lblDiv10" runat="server" Text=""></asp:Label></td>--%>
            <td><asp:Label ID="lblPercent10" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblPassDate10" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr id="tr12" runat="server">
            <td>12th/Intermediate</td>
            <td><asp:Label ID="lblInst12" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblNature12" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblDuration12" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblSub12" runat="server" Text=""></asp:Label></td>
         <%--   <td><asp:Label ID="lblDiv12" runat="server" Text=""></asp:Label></td>--%>
            <td><asp:Label ID="lblPercent12" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblPassDate12" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr id="trITI" runat="server" visible="false">
            <td>ITI</td>
            <td><asp:Label ID="lblInstITI" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblNatureITI" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblDurationITI" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblSubITI" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblDivITI" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblPercentITI" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblPassDateITI" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr id="trDiploma" runat="server" visible="false">
            <td>Diploma</td>
            <td><asp:Label ID="lblInstDip" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblNatureDip" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblDurationDip" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblSubDip" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblDivDip" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblPercentDip" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblPassDateDip" runat="server" Text=""></asp:Label></td>
        </tr>

        <tr id="trNAC" runat="server" visible="false">
            <td>NAC Course</td>
            <td colspan="4"><asp:Label ID="txtNacUniv" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="txtNacPer" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="txtNacDate" runat="server" Text=""></asp:Label></td>
        </tr>

        <tr id="trATC" runat="server" visible="false">
            <td>Airforce Trade Certificate</td>
            <td><asp:Label ID="txtESMCert" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="txtESMDate" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="txtESMCertNo" runat="server" Text=""></asp:Label></td>
            <td colspan="6"></td>
        </tr>
    </table>

        <table border="1" style="width:100%;">
           <tr>
                <td>Domicile of Jammu & Kashmir : <span><asp:Label ID="lblDom" runat="server" Text=""></asp:Label></span></td>
                <td>Domicile Issue Date : <span><asp:Label ID="lblDomDate1" runat="server" Text=""></asp:Label></span></td>
               <td>&nbsp;</td>
            </tr>

            <tr>
                <td>Do you have Relevant Experience? : <span><asp:Label ID="lblRelExp1" runat="server" Text=""></asp:Label></span></td>
                <td colspan="2">Period of Relevant Experience : <span><asp:Label ID="lblPeriod" runat="server" Text=""></asp:Label></span></td>
            </tr>

            <tr>
                <td>Ex-Servicemen Experience (Armed Forces)? : <span><asp:Label ID="lblExService" runat="server" Text=""></asp:Label></span></td>
                <td>Last Rank Held : <span><asp:Label ID="lblRank" runat="server" Text=""></asp:Label></span></td>
                <td>Date of Enrollment : <span><asp:Label ID="lblExPeriod" runat="server" Text=""></asp:Label></span></td>
            </tr>

            <tr>
                <td>Have you done Apprenticeship with HAL, Koraput? : <span><asp:Label ID="lblAppHal" runat="server" Text=""></asp:Label></span></td>
                <td>Joining Date : <span><asp:Label ID="lblJoinDate" runat="server" Text=""></asp:Label></span></td>
                <td>Leaving Date : <span><asp:Label ID="lblLeveDate" runat="server" Text=""></asp:Label></span></td>
            </tr>

        </table>

        <table border="1" style="width:100%;">
              <tr>
                   <td colspan="3"><b>Have you been interviewd by HAL any time earlier? :<span><asp:Label ID="lblIntHal" runat="server" Text=""></asp:Label></span></b></td>
               </tr>
                <tr>
                    <td widtd="40%">Post Interviewed</td>
                    <td widtd="20%">Date of Interviewed </td>
                    <td widtd="40%">Venue of Interviewed</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblPostInt" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblDateInt" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblVenueInt" runat="server" Text=""></asp:Label></td>
                </tr>
       </table>
              
    
        
        <table border="1" style="width:100%;">
               <tr>
                   <td colspan="4"><b>Are any of your close relatives working in HAL? : <span><asp:Label ID="lblRelWorking" runat="server" Text=""></asp:Label></span></b></td>
               </tr>
                <tr>
                    <td width="30%">Name of Relative</td>
                    <td width="20%">Designation</td>
                    <td width="30%">Division</td>
                    <td width="20%">Any other Description</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNameRel" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblDesigRel" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblDivRel" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblDescRel" runat="server" Text=""></asp:Label></td>
                </tr>
       </table>


       <table border="1" style="width:100%;">
           <thead>
               <tr>
                   <td colspan="9"><b>Working Experience, if any :</b></td>
               </tr>
               <tr>
                   <td>Designation/Name of the post</td>
                   <td>Name of Organisation</td>
                   <td>Joining Date</td>
                   <td>Leaving Date</td>
                   <td>Duration</td>
                   <td>Pay Scale</td>
                   <td>Reason for Leaving</td>
               </tr>
           </thead>
           <tbody>
               <asp:Label ID="lblExperience" runat="server" Text=""></asp:Label>
           </tbody>    
      </table>

       <table border="1" style="width:100%;">
           <thead>
               <tr>
                   <td colspan="4"><b>Details of Apprenticeship Training :</b></td>
               </tr>
               <tr >
                   <td width="25%">Name of the Apprenticeship training</td>
                   <td width="20%">Institute / Organization</td>
                   <td width="10%">From Date</td>
                   <td width="10%">Upto Date</td>
               </tr>
           </thead>
           <tbody>
               <asp:Label ID="lblTraining" runat="server" Text=""></asp:Label>
           </tbody>    
      </table>

        <table border="1" style="width:100%;">
               <tr>
                   <td colspan="5"><b>Have you ever been a member/worker of any polictical party/organisation or participated any political activities?: <span><asp:Label ID="lblPolParty" runat="server" Text=""></asp:Label></span></b></td>
               </tr>
                <tr>
                    <td width="20%">Name of Political Party/Organisation</td>
                    <td width="20%">Particulars of Political Activity</td>
                    <td width="20%">Period of Membership</td>
                    <td width="20%">Nature of Participation in Political Activity</td>
                    <td width="20%">Office, if any, held in Political Party</td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblPartyName" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblActivity" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblPeriodMemb" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblNature" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblOffice" runat="server" Text=""></asp:Label></td>
                </tr>
       </table>
            
        <p><span><strong>Declarations :</strong></span></p>
        <p><span>It is hereby declared that the information furnished by me herein above is true to my personal knowledge and belief. I further declare that if I obtain appointment on any false or incorrect information, my appointment shall be terminated / cancelled and I shall be liable for prosecution under the Law.</span></p>
        <p>I accept the above mentioned declaration : Yes</p>

    <div class="container">
        <div class="row">
            <div class="col-lg-4">
                <p>Date : <span><asp:Label ID="lblDated" runat="server" Text=""></asp:Label></span></p>
                <%--<p>Place :<span><asp:Label ID="lblPlace1" runat="server" Text=""></asp:Label></span></p>--%>
            </div>
            <div class="col-lg-4"></div>
            <div class="col-lg-4 text-center">
                <asp:Image ID="imgSign2" runat="server" AlternateText="sign" Width="100"></asp:Image><br />
                ( <asp:Label ID="lblName1" runat="server" Text=""></asp:Label> )
            </div>
        </div>
    </div>
</td></tr>
</table>

</page>
<div class="container justify-content-evenly noprint">
    <asp:Button ID="btnlogout" class="btn btn-outline-primary" runat="server" Text=" Logout " onCLick="btnlogout_Clicked"/>
    <asp:Button ID="btnPrint" class="btn btn-outline-primary" runat="server" Text=" Print " OnClientClick="javascript:window.print();"/>
</div>
     <script type="text/javascript">
         if (document.referrer == "") {
             document.location = "/Login.aspx";
         }
     </script>

</div>
</form>
</body>
</html>
