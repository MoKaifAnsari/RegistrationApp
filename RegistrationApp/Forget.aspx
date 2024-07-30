<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forget.aspx.cs" Inherits="RegistrationApp.Forget" %>

<!DOCTYPE html>

<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>HAL - Password Retrieval</title>
    <link rel="icon" type="image/x-icon" href="/img/favicon.ico">

    <!-- Custom fonts for this template-->
    <link href="css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

        <%--FOR FONT-AWESOME--%>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">

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
 <%--                   <li class="nav-item active">
                        <a class="nav-link" href="\img\Advertisement_HAL2024.pdf" target="_blank"><i class='fas fa-bullhorn'></i>Advertisement <span class="sr-only">(current)</span></a>
                   </li>--%>

               </ul>

                <ul class="navbar-nav">
                    <li class="nav-item active">
                        <span class="nav-link">&emsp;&emsp;&emsp;Advertisement No.: KPT/TBE/2024-01</span>
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


    <div class="container">
        <!-- Outer Row -->
        <div class="row justify-content-center">
            <div class="col-xl-5 col-lg-6 col-md-6">
                <div class="card o-hidden border-0 shadow-sm my-4">
                    <div class="title text-center">
                        <h5 class="text-white font-weight-bold mb-2 bg-info py-2">Retrieval of Application No. and Password</h5>
                    </div>
                    <div class="card-body p-3">
                        <div class="row">
                            <div class="col-lg-12">

                                <div class="p-2">
                                    <form class="user text-center" runat="server">
                                        <div class="form-group text-left">
                                            <label for="RegistrationNo" class="text-dark font-weight-bold">Email ID</label>
                                            <asp:TextBox ID="txtEmail" style="text-transform:uppercase" class="form-control" Placeholder="Email ID" autocomplete="off" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group text-left">
                                            <label for="InputPassword" class="text-dark font-weight-bold">Aadhar Number</label>
                                            <asp:TextBox ID="txtAadhar" class="form-control" autocomplete="off" Placeholder="Aadhar Number" runat="server"></asp:TextBox>
                                        </div>

                                       
                                        <asp:Button ID="btnLogin" runat="server" class="btn btn-outline-primary mt-4 w-50" Text="Retrive" OnClick="btnLogin_Click"/>
                                        <br /><br />
                                        <asp:Label ID="lblStatus" runat="server" Font-Bold="true" Font-Size="Larger" BackColor="Blue" Text=""></asp:Label>
                                    </form>

                                   
<%--                                    <div class="text-center">
                                        <a class="small" href="register">Don't have an account? Register Now</a>
                                    </div>--%>
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
