<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="RegistrationApp.Index" %>
<!DOCTYPE html>

<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>HAL - Koraput</title>
    <link rel="icon" type="image/x-icon" href="/img/favicon.ico">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <!-- Custom fonts for this template -->
    <link href="css/all.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
        <%--FOR FONT-AWESOME--%>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">

    <%--this script is for eye field in password box--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom styles for this template -->
    <link href="css/layout.css" rel="stylesheet">

    <script type="text/javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }

        function ValidateAlpha(evt) {
            let charCode = char.charCodeAt(0);
            if (!(charCode > 47 && charCode < 58) &&
                !(charCode > 96 && charCode < 123) &&
                !(charCode > 64 && charCode < 91)
            ) {
                return;
            }
    </script>
</head>

<body style="background-color:#ECF0F1;" onunload="disableBackButton()">
    <div class="container-fluid bg-white">
        <div class="row">
            <div class="col-md-2 col-12">
                <center>
                    <img src="img/logo.png" class="img img-rounded img-responsive" height="80px" width="150px" />
                </center>
            </div>
            <div class="col-lg-6 col-12">
                <center class="py-1">
                    <h4 class="text-primary">&emsp;&emsp;&emsp;&emsp;&emsp;<b>Hindustan Aeronautics Limited</b></h4>
                    <h5 class="mb-0">&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Koraput Division (A Govt. of India Enterprise)</h5>
                    <p class="mb-0">&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;PO: Sunabeda-763002, Dist. : Koraput, Odisha, India</p>
                </center>
            </div>
            <div class="col-lg-4 col-12">
                <div class="text-right py-0">
                    <p class="mb-0 mt-3">For Technical Support Only (10:00 AM to 5:00 PM)</p>
                    <p class="mb-0"><span class="text"><i class="fa fa-phone"></i>&nbsp; Contact Number : 9234191300 </span></p>
                    <p class="mb-0"><span class="text"><i class="fa fa-envelope"></i>&nbsp;Email : halkpt@reg.org.in</span></p>
                </div>
            </div>
        </div>
    </div>


    <nav class="navbar-expand-sm navbar-dark bg-gradient-info">
        <div class="container-fluid">
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse justify-content-between align-items-center" id="navbarSupportedContent">
                <ul class="navbar-nav">
                    <li class="nav-item active">
 <%--                       <a class="nav-link" href="index">
                            <i class="fas fa-fw fa-home text-white-400"></i>
                            <span>Home</span></a>--%>
                    </li>
  <%--                  <li class="nav-item active">
                        <a class="nav-link" href="\img\Advertisement_HAL2024.pdf" target="_blank"><i class='fas fa-bullhorn'></i>Advertisement <span class="sr-only">(current)</span></a>
                   </li>--%>

               </ul>

                <ul class="navbar-nav">
                    <li class="nav-item active">
                        <span class="nav-link" style="font-size:15px">&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Advertisement No.: KPT/TBE/2024-02</span>
                    </li>
                </ul>

                <ul class="navbar-nav">
<%--                    <li class="nav-item active">
                        <a class="nav-link" href="Register.aspx"><i class="far fa-edit"></i><span>New Registration</span></a>
                    </li>--%>
                  <li class="nav-item active">
                      <a class="nav-link" href="Login.aspx"><i class="fas fa-sign-in-alt"></i> <span>Applicant Login</span></a>
                  </li>
                </ul>

            </div>
        </div>
    </nav>

    <form runat="server" AutoCompleteType="Disabled" autocomplete="off">

      <%-- <marquee class="bg-white text-dark text-center mt-1 mb-0"> 
           <h5 style="color:blue">Login to download your Admit Card</h5> 
       </marquee> --%>

    <section class="pt-0 mt-3">
        <div class="container-fluid">

            <div class="row text-center">
               <div class="col-md-12 mb-1">
                    <div class="card overflow-hidden">
                        <div class="card-heading bg-info text-white">
                            <h5 class="card-title py-1 mb-0">General Information</h5>
                        </div>
                        <div class="card-body">
                            <table class="table table-bordered table-responsive table-striped text-left">
                                <tbody style="font-size:smaller; font-family:'Century Gothic'">

                                    <tr>
                                        <td>01. Candidates sponsered by the Employment Exchange/T&DI Sunabeda/Sainik Boards/Customer Bases, who have received communication from HAL Koraput are only eligible to apply.</td>
                                    </tr>

                                    <tr>
                                        <td>02. Only Indian Nationals are eligible to apply</td>
                                    </tr>
                                    <tr>
                                        <td>03.	To fill out the online application form please use Laptop or Desktop only. (Do not use Mobile Phone)</td>
                                    </tr>

                                    <tr>
                                        <td>04.	One candidate can apply for one post only.</td>
                                    </tr>
                                   <tr>
                                        <td>05.	Applications of the candidates who submit two or more applications for one position will be rejected.</td>
                                    </tr>

                                    <tr>
                                        <td>06.	Cut-off date for determining the age and experience shall be 01-05-2024.</td>
                                    </tr>
                                    <tr>
                                        <td>07.	Experience gained after acquiring the minimum essential qualification only would be considered for deciding the eligibility.</td>
                                    </tr>
                                    <tr>
                                        <td>08.	Candidates seeking relaxation in age will be required to produce relevant proof of eligibility at the time of document verification.</td>
                                    </tr>
                                    <tr>
                                        <td>09.	Candidates seeking reservation benefit have to produce relevant certificate to that effect at the time of document verification.</td>
                                    </tr>
                                    <tr>
                                        <td>10.	Canvassing in any form will lead to disqualification.</td>
                                    </tr>
                                    <tr>
                                        <td>11.	The last date of submitting the online application form is <b> 15th JULY 2024.</b></td>
                                    </tr>
                                    <tr>
                                        <td>12.	HAL,Koraput reserves the right to cancel this recruitment process fully or partially at any stage at its discretion.</td>
                                    </tr>
                                    <tr>
                                        <td>13.	All information furnished by the candidate should be correct. Furnishing wrong information at any stage of recruitment and selection process will lead to disqualification.</td>
                                    </tr>
                                    <tr>
                                        <td>14.	All applicants are required to go through the detailed advertisement carefully and ensure that he/she fulfills the eligibility and other norms as mentioned in the advertisement before applying. </td>
                                    </tr>
                                    <tr>
                                        <td><b>15. The information regarding schedule of examination, venue and date for downloading of Admit cards will be announced later on, on the Official website https://hal-india.co.in</b></td>
                                    </tr>
                                    <tr>
                                        <td><b>16. The Admit cards indicating the date of examination and venue shall be downloaded by the candidates from the official website https://hal-india.co.in</b></td>
                                    </tr>
                                    <tr>
                                        <td>17. Preserve the Computerized Profile page after submitting your application. Before the examination, applicants can download their admit card from https://hal-india.co.in</td>
                                    </tr>
                                    <tr>
                                        <td>18. Candidates possessing higher technical qualifications than the required qualification indicated in the Notification need not apply. Candidature of personnel who possess higher qualifications than the required qualification indicated in the Advertisement / Notification and who apply for the post, will be rejected at any stage of the Recruitment/ Selection.</td>
                                    </tr>
                                    <tr>
                                        <td>19. Candidates with Part Time/ Correspondence/ Distance Education/ E-learning qualification & whose results are awaited/withheld will not be eligible to apply.</td>
                                    </tr>
                                   <tr>
                                       <td>20. In case of any particular clarification, the candidates can write to the E-mail ID at recruitment.koraput@hal-india.co.in (or) halkpt@reg.org.in. No other method of Communication will be entertained.</td>
                                   </tr>
                                    <tr>
                                        <td>21. Soft copy of Passport size Photo (20Kb-100Kb), Signature (20Kb-100Kb) and Aadhaar Card (100Kb-500Kb) of the candidate are required to be uploaded at the time of applying online.</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
    </form>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>
    <script src="js/customScript.min.js"></script>
</body>
</html>