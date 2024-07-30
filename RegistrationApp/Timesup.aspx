<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Timesup.aspx.cs" Inherits="RegistrationApp.Timesup1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>HAL - Koraput </title>
    <link rel="icon" type="image/x-icon" href="/img/favicon.ico"/>

    <!-- Custom fonts for this template-->
    <link href="css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet"/>

   <%--this script is for eye field in password box--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom styles for this template -->
    <link href="css/layout.css" rel="stylesheet"/>


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
                   <p class="mb-0"><span class="text"><i class="fa fa-envelope"></i>&nbsp; Email : halkpt@reg.org.in</span></p>
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
                       <a class="nav-link" href="index">
                           <i class="fas fa-fw fa-home text-white-400"></i>
                           <span>Home</span></a>
                   </li>
               </ul>

               <ul class="navbar-nav">
                   <li class="nav-item active">
                       <span class="nav-link">Notification No.: HR/TBE/12/2023/18</span>
                   </li>
               </ul>

               <ul class="navbar-nav">
<%--                   <li class="nav-item active">
                       <a class="nav-link" href="Register.aspx"><i class="far fa-edit"></i><span>New Registration</span></a>
                   </li>--%>
                 <li class="nav-item active">
                     <a class="nav-link" href="Login.aspx"><i class="fas fa-sign-in-alt"></i> <span>Applicant Login</span></a>
                 </li>
               </ul>
           </div>
       </div>
   </nav>
    <div class="container">
        <div class="row justify-content-center py-5 mt-5">
             <h2><b><asp:Label ID="lblStatus" class="blink" runat="server" Text=""></asp:Label></b></h2>
        </div>
    </div>
</body>

</html>
