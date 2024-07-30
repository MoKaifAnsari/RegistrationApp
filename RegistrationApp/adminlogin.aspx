<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="RegistrationApp.adminlogin" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>HAL - Admin Login</title>
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
                        <a class="nav-link" href="adminlogin">
                            <i class="fas fa-fw fa-home text-white-400"></i>
                            <span>Home</span></a>
                    </li>
               </ul>

                <ul class="navbar-nav">
                    <li class="nav-item active">
                        <span class="nav-link">&nbsp;</span>
                    </li>
                </ul>

                <ul class="navbar-nav">
                    <li class="nav-item active">
                       <%-- <a class="nav-link" href="adminlogin"><i class="fa fa-sign-out" aria-hidden="true"></i> Logout </a>--%>
                    </li>
                </ul>

            </div>
        </div>
    </nav>

    <div class="container">
        <div class="row justify-content-center">
            <div class="col-xl-5 col-lg-6 col-md-6">
                <div class="card o-hidden border-0 shadow-sm my-3">

                <div class="title text-center">
                    <h5 class="text-white font-weight-bold mb-2 bg-info py-2">Admin Login</h5>
                </div>

                    <div class="card-body p-0">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="p-5">
                                    <form class="user text-center" runat="server">
                                        <div class="form-group text-left">
                                            <label for="RegistrationNo" class="text-dark font-weight-bold">User ID</label>
                                            <asp:TextBox ID="txtRegno" style="text-transform:uppercase" class="form-control" autocomplete="off" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group text-left">
                                            <label for="InputPassword" class="text-dark font-weight-bold">Password</label>
                                            <asp:TextBox ID="txtPassword" class="form-control" autocomplete="off" TextMode="Password" runat="server"></asp:TextBox>
                                        </div>
                                        <br /> <br />
                                        <asp:Button ID="btnLogin" runat="server" class="btn btn-outline-primary w-50" Text="Login" OnClick="btnLogin_Click"/>
                                        <br /> <br />
                                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>

    <!-- Bootstrap core JavaScript-->
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>

</body>

</html>