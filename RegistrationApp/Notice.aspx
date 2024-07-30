<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="RegistrationApp.Notice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
                        <a class="nav-link" href="index"><i class="fas fa-fw fa-home text-white-400"></i><span>Home</span></a>
                    </li>
<%--                    <li class="nav-item active">
                        <a class="nav-link" href="\img\Advertisement_HAL_Koraput_2024.pdf" target="_blank"><i class='fas fa-bullhorn'></i>Advertisement <span class="sr-only">(current)</span></a>
                   </li>--%>
               </ul>

                <ul class="navbar-nav">
                   <li class="nav-item active">
                       <span class="nav-link" style="font-size:15px">Advertisement No.: KPT/TBE/2024-02</span>
                   </li>
                </ul>

                <ul class="navbar-nav">
 <%--                   <li class="nav-item active">
                        <a class="nav-link" href="Register.aspx"><i class="far fa-edit"></i><span>New Registration</span></a>
                    </li>--%>
                  <li class="nav-item active">
                      <a class="nav-link" href="Login.aspx"><i class="fas fa-sign-out-alt"></i> <span>Logout</span></a>
                  </li>
                </ul>

            </div>
        </div>
    </nav>

    <form runat="server" AutoCompleteType="Disabled" autocomplete="off">
    <section class="pt-0">
        <div class="container-fluid">

            <div class="row text-center">
               <div class="col-md-12 mb-1">
                    <div class="card overflow-hidden">
                        <div class="card-heading bg-info text-white mt-1">
                            <h5 class="card-title py-1 mb-0">Note for Candidates</h5>
                        </div>
                        <div class="card-body">
                            <table class="table table-bordered table-responsive table-striped text-left">
                                <tbody style="font-size:large; font-family:'Century Gothic'">
                                    <tr>
                                        <td>i) It may be noted that the information posted in HAL Website only are considered authentic.
                                            Accordingly, candidates may please note that Career opportunities in HAL shall be explored in HAL
                                            Website only. Newspaper advertisement need to be verified through HAL Website.
                                        </td>
                                    </tr>
                                    <tr><td> &nbsp;</td></tr>
                                    <tr>
                                        <td>ii) Candidates should be aware of fake e-mails and communications received and should not make
                                            payment with any Individual/ Agency for securing employment in HAL. In case any person/ agency is
                                            found to be engaged in malpractices/ corruption related to recruitment in HAL, HAL will take legal
                                            action against those fraudsters. 
                                        </td>
                                    </tr>
                                    <tr><td> &nbsp;</td></tr>
                                   <tr>
                                        <td>iii) Candidates are requested to read the advertisement carefully before filling the application form.</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div>
                            <asp:Button ID="btnProceed" runat="server" class="btn btn-primary w-25 mb-2" Text="Click here to Proceed >>>" OnClick="btnProceed_Click"/>
                            <%--<asp:Button ID="Button1" runat="server" class="btn btn-primary w-25 mb-2" Text="Profile" OnClick="Button1_Click"/>--%>
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
