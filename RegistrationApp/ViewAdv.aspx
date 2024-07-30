<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAdv.aspx.cs" Inherits="RegistrationApp.ViewAdv" %>

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
                      <li class="nav-item active">
                          <%--<span class="nav-link" style="font-size:15px">Notification No.: HAL/BKP/HR/RECT/2023/733</span>--%>
                      </li>
 <%--                       <a class="nav-link" href="index">
                            <i class="fas fa-fw fa-home text-white-400"></i>
                            <span>Home</span></a>--%>
                    </li>
 <%--                   <li class="nav-item active">
                        <a class="nav-link" href="\img\Advertisement_HAL2024.pdf" target="_blank"><i class='fas fa-bullhorn'></i>Advertisement <span class="sr-only">(current)</span></a>
                   </li>--%>

               </ul>

                <ul class="navbar-nav">
 <%--                  <li class="nav-item active">
                       <span class="nav-link" style="font-size:15px">Notification No.: HAL/BKP/HR/RECT/2023/733</span>
                   </li>--%>
                </ul>

                <ul class="navbar-nav">
 <%--                   <li class="nav-item active">
                        <a class="nav-link" href="Register.aspx"><i class="far fa-edit"></i><span>New Registration</span></a>
                    </li>--%>
                  <li class="nav-item active">
                      <%--<a class="nav-link" href="Login.aspx"><i class="fas fa-sign-in-alt"></i> <span>Applicant Login</span></a>--%>
                  </li>
                </ul>

            </div>
        </div>
    </nav>

    <form runat="server" autocompletetype="Disabled" autocomplete="off">
    <section class="pt-0">
        <div class="container-fluid">
            <div class="row text-center">
               <div class="col-md-12">
                    <div class="card overflow-hidden">
                       <div class="text-center">
                           <iframe id="iframe1" src="/img/Advertisement_KPT-TBE-2024-03.pdf" style="border:none;width:999px;height:420px;" frameborder="1" framespacing="0" marginheight="0" marginwidth="0"></iframe>
                        </div>
                     </div>
                </div>
            </div>
        </div>
         <div class="row">
            <div class="col-6 text-left">
                <asp:CheckBox ID="chkConfirm" runat="server" class="text-dark font-weight-bolder form-check mt-3" style="font-size:large" Text=" I have read the advertisement carefully!" AutoPostBack="true" OnCheckedChanged="chkConfirm_CheckedChanged"/>
            </div>
            <div class="col-6 text-center">
                <asp:Button ID="btnProceed" runat="server" class="btn btn-primary mt-2" enabled="false" Text="Click here to Proceed >>>" OnClick="btnProceed_Click"/>
            </div>
        </div>
    </section>
    </form>
</body>
</html>
