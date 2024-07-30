<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RegistrationApp.Register" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="nns" content=""/>

    <title>HAL - Koraput</title>
    <link rel="icon" type="image/x-icon" href="/img/favicon.ico"/>

    <!-- Custom fonts for this template-->
    <link href="css/all.min.css" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet"/>

    <!-- Custom styles for this template -->
    <link href="css/layout.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.13.2/themes/smoothness/jquery-ui.css"/>

    <%--FOR TIMER--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <script type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        function ValidateAlpha(evt) {
            evt = (evt) ? evt : window.event;
            var keyCode = (evt.which) ? evt.which : evt.keyCode;
            if ((keyCode < 65 || keyCode > 90) &&
                (keyCode < 97 || keyCode > 123) &&
                keyCode != 32 && keyCode != 39) {
                return false;
            }
            return true;
        }

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }

        //for sms timer
        $(document).ready(function () {
            var timer = 10 * 60;
            var interval;

            //alert("Timer has started!");

            function startTimer() {
                interval = setInterval(updateTimer, 1000);
            }

            function updateTimer() {
                var minutes = Math.floor(timer / 60);
                var seconds = timer % 60;
                document.getElementById("timer").innerHTML = minutes + ":" + seconds + " mins";

                if (minutes == 0 & seconds == 0) {
                    document.getElementById('<%=btnSendOTP.ClientID %>').style.visibility = "visible";
            }

            timer--;
            if (timer < 0) {
                clearInterval(interval);
                document.getElementById('<%=btnSendOTP.ClientID %>').style.visibility = "visible";
                }
            }
            startTimer();
        });

    </script>
</head>

<body style="background-color:#ECF0F1 ;" onunload="disableBackButton()">
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
 <%--                  <li class="nav-item active">
                       <a class="nav-link" href="Register.aspx"><i class="far fa-edit"></i><span>New Registration</span></a>
                   </li>--%>
                 <li class="nav-item active">
                     <a class="nav-link" href="Login.aspx"><i class="fas fa-sign-in-alt"></i> <span>Applicant Login</span></a>
                 </li>
               </ul>
           </div>
       </div>
   </nav>

    <div>
        <div class="card o-hidden border-0 shadow-sms my-1">
            <form runat="server" autocompletetype="Disabled" autocomplete="off">
                <div class="card overflow-hidden ml-5 mr-5">
                    <div class="card-heading bg-info text-white">
                        <h5 class="card-title py-1 mb-0 text-center">New Registration</h5>
                    </div>

                    <div class="card-body ml-3 mr-3 text-left">
 <%--                       <div class="form-row text-center">
                            <h5 class="card-heading py-1 mb-0 text-center text-red blink">Registration is only open for </h5>
                        </div>--%>
                        <div class="card-heading badge-light text-danger">
                            <h5 class="card-title mb-2 py-1 text-center blink">Only candidates who have completed apprenticeship from HAL Koraput or are registered with Koraput's employment exchange are eligible to apply for this position.</h5>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-6"> 
                                <label for="inputDiscipline" class="form-label font-weight-bold">HAL,Koraput Apprenticeship No./Koraput, Employment Exchange Reg.No.? <font color="red">*</font> </label>
                                <asp:DropDownList ID="ddlNo" class="form-control" ValidationGroup="regn" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Apprenticeship No., HAL Koraput</asp:ListItem>
                                    <asp:ListItem>Employment Exchange Reg.No., Koraput</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblNo" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="Selection Required"></asp:Label>                                                
                            </div>

                            <div class="form-group col-md-6"> 
                                <label for="inputDiscipline" class="form-label font-weight-bold">Apprenticeship No./Employment Exchange Registration No. <font color="red">*</font> </label>
                                <asp:TextBox ID="txtApprenticeNo" class="form-control form-control-sm" MaxLength="25" AutoCompleteType="Disabled" autocomplete="off" oncopy="return false" onpaste="return false" oncut="return false" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                <asp:Label ID="lblApprenticeNo" runat="server" Visible="false"  ForeColor="Red" Font-Bold="true" Text="Apprenticeship No./Employment Exchange No Required"></asp:Label>   
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-6"> 
                                <label for="inputDiscipline" class="form-label font-weight-bold">Applicant Name <font color="red">*</font> </label>
                                <asp:TextBox ID="txtName" class="form-control form-control-sm" MaxLength="100" AutoCompleteType="Disabled" autocomplete="off" oncopy="return false" onpaste="return false" oncut="return false" runat="server" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                <asp:Label ID="lblName" runat="server" Visible="false"  ForeColor="Red" Font-Bold="true" Text="Applicant Name Required"></asp:Label>   
                            </div>
                            <div class="form-group col-md-2"> 
                                <label for="inputDiscipline" class="form-label font-weight-bold">Gender <font color="red">*</font> </label>
                                <asp:DropDownList ID="ddlGender" class="form-control" ValidationGroup="regn" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblGender" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="Gender Required"></asp:Label>                                                
                            </div>
                            <div class="form-group col-md-2"> 
                                <label for="inputDiscipline" class="form-label font-weight-bold">Marital Status <font color="red">*</font> </label>
                                <asp:DropDownList ID="ddlMaritalStatus" ValidationGroup="regn" class="form-control" runat="server">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Married</asp:ListItem>
                                    <asp:ListItem>Single</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblMaritalStatus" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="Marital Status Required"></asp:Label>
                            </div>
                            <div class="form-group col-md-2"> 
                                <label for="inputDiscipline" class="form-label font-weight-bold">Nationality<font color="red">*</font> </label>
                                <asp:DropDownList ID="ddlNationality" ValidationGroup="regn" class="form-control" runat="server">
                                    <asp:ListItem>INDIAN</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-row">                         
                            <div class="form-group col-md-4">
                                <label for="inputEmail" class="form-label font-weight-bold">Email ID <font color="red">*</font></label>
                                <asp:TextBox ID="txtEmail" class="form-control form-control-sm" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                <asp:Label ID="lblMail" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="EMail Required"></asp:Label>
                            </div>
                            <div class="form-group col-md-2 text-center">
                                <asp:Button ID="btnSendOTP" runat="server" class="btn btn-outline-primary font-weight-bolder mt-4" Text="Send OTP" OnClick="btnSendOTP_Click"/>
                            </div>
                            <div class="form-group col-md-2 text-center" runat="server" id="divtimer">
                                <label for="inputEmail" class="form-label font-weight-bold">Resend OTP after</label><br />
                                <asp:Label ID="timer" class="form-label font-weight-bold" Visible="false" runat="server" ForeColor="Blue" Font-Bold="true" Text=""></asp:Label>
                            </div>
                            <div class="form-group col-md-2">
                                <label for="inputEmail" class="form-label font-weight-bold">Input OTP <font color="red">*</font></label>
                                <asp:TextBox ID="txtOTP" class="form-control form-control-sm" Placeholder="Input OTP" oncopy="return false" onpaste="return false" oncut="return false"  autocomplete="off" runat="server" onkeypress="return isNumber(event)"></asp:TextBox>
                                <asp:Label ID="lblOTP" runat="server" ForeColor="Green" Visible="false" Font-Bold="true" Text="OTP sent successfully, valid for 10-mins only."></asp:Label>
                            </div>
                            <div class="form-group col-md-2 text-center">
                                <asp:Button ID="btnVerifyOTP" runat="server" class="btn btn-outline-primary font-weight-bolder mt-4" Text="Verify OTP" OnClick="btnVerifyOTP_Click"/>
                            </div>

                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-2">
                                <label for="inputAadhar" class="form-label font-weight-bold">Aadhar No. <font color="red">*</font></label>
                                <asp:TextBox ID="txtAdhar" class="form-control form-control-sm" MinLength="12" MaxLength="12" autocomplete="off" runat="server" type="Password" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                <asp:Label ID="lblAdhar" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="Aadhar No. Required"></asp:Label>
                            </div>
                            <div class="form-group col-md-2">
                                <label for="inputAadhar" class="form-label font-weight-bold">Confirm Aadhar No. <font color="red">*</font></label>
                                <asp:TextBox ID="txtAdhar1" class="form-control form-control-sm" MinLength="12" MaxLength="12" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                <asp:Label ID="lblAdhar1" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="Confirm Aadhar No. not matching"></asp:Label>
                            </div>
                            <div class="form-group col-md-2">
                                <label for="inputMobile" class="form-label font-weight-bold">Mobile No.<font color="red">*</font></label>
                                <asp:TextBox ID="txtMobile" class="form-control form-control-sm" autocomplete="off" MaxLength="10" runat="server" type="Password" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                <asp:Label ID="lblMobile" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="Mobile No. Required"></asp:Label>
                            </div>
                            <div class="form-group col-md-2">
                                <label for="inputMobile" class="form-label font-weight-bold">Confirm Mobile No.<font color="red">*</font></label>
                                <asp:TextBox ID="txtMobile1" class="form-control form-control-sm" autocomplete="off" MaxLength="10" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                <asp:Label ID="lblMobile1" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="Mobile No. not matching"></asp:Label>
                            </div>
                            <div class="form-group col-md-2">
                                <label for="InputPassword" class="form-label font-weight-bold">Password <font color="red">*</font></label>
                                <asp:TextBox ID="txtPassword" class="form-control form-control-sm" MaxLength="15" type="Password" oncopy="return false" onpaste="return false" oncut="return false"  autocomplete="off" runat="server"></asp:TextBox>
                                <asp:Label ID="lblPwd" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="Password Required"></asp:Label>
                            </div>
                            <div class="form-group col-md-2">
                                <label for="InputConPassword" class="form-label font-weight-bold">Confirm Password <font color="red">*</font></label>
                                <asp:TextBox ID="txtPassword1" class="form-control form-control-sm" oncopy="return false" onpaste="return false" oncut="return false"  autocomplete="off" type="Password" MaxLength="15" runat="server"></asp:TextBox>
                                <asp:Label ID="lblPwd1" runat="server" Visible="false" ForeColor="Red" Font-Bold="true" Text="Password not matching"></asp:Label>
                            </div>
                        </div>

                        <div class="text-left mt-1 ml-0 mr-4">
                            <div>
                                <asp:CheckBox ID="chkConfirm" class="form-label font-weight-bold" runat="server" Text="&nbsp;I have read and understood the advertisement carefully."/>
                            </div>
                        </div>

                        <div>
                            <asp:Label ID="lblStatus" runat="server" Visible="false" Font-Bold="true" ForeColor="Red" Font-Size="Large" Text=""></asp:Label>
                        </div>

                        <div class="text-center mt-3 mb-2">
                            <asp:Button ID="btnSave" runat="server" class="btn btn-outline-primary font-weight-bolder" Text="  REGISTER  " OnClick="btnSave_Click"/>
                        </div>
                    </div>
                </div>
            </form>
            <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
            <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
        </div>
    </div>
     <script type="text/javascript">
         if (document.referrer == "") {
             document.location = "/Login.aspx";
         }
    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.13.2/jquery-ui.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>
</body>
</html>