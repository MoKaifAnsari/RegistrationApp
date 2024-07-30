<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="RegistrationApp.PersonalInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>HAL - Koraput </title>
    <link rel="icon" type="image/x-icon" href="/img/favicon.ico" />

    <!-- Custom fonts for this template-->
    <link href="css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />

    <%--this script is for eye field in password box--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom styles for this template -->
    <link href="css/layout.css" rel="stylesheet" />


    <script type="text/javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }

        //function isNumber(evt) {
        //    evt = (evt) ? evt : window.event;
        //    var charCode = (evt.which) ? evt.which : evt.keyCode;
        //    if (charCode >= 48 || charCode <= 57) {
        //        return false;
        //    }
        //    return true;
        //}

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

        function validateEmail() {
            var email = document.getElementById('<%= txtMail.ClientID %>').value;
            var confirmEmail = document.getElementById('<%= txtMail1.ClientID %>').value;
            var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            var emailError = document.getElementById('<%= lblMail.ClientID %>');
            var confirmEmailError = document.getElementById('<%= lblMail1.ClientID %>');

            // Clear previous error messages
            emailError.style.display = 'none';
            confirmEmailError.style.display = 'none';

            if (!emailPattern.test(email)) {
                emailError.textContent = 'Invalid Email Address';
                emailError.style.display = 'block';
                return false;
            }

            if (email !== confirmEmail) {
                confirmEmailError.textContent = 'Email addresses do not match';
                confirmEmailError.style.display = 'block';
                return false;
            }

            return true;
        }

        document.getElementById('<%= txtMail.ClientID %>').onblur = validateEmail;
        document.getElementById('<%= txtMail1.ClientID %>').onblur = validateEmail;

        /*   Start Mobile*/
        function isNumber(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode >= 48 && charCode <= 57) {
                return true;
            } else {
                return false;
            }
        }

        function validateMobileNumber(input) {
            var mobile = input.value;
            var regex = /^[6-9]\d{9}$/;

            if (regex.test(mobile)) {
                input.style.borderColor = '';
                return true;
            } else {
                input.style.borderColor = 'red';
                return false;
            }
        }

        function validateMobileFields() {
            var mobile1 = document.getElementById('<%= txtMobile.ClientID %>');
            var mobile2 = document.getElementById('<%= txtMobile1.ClientID %>');

            var isValidMobile1 = validateMobileNumber(mobile1);
            var isValidMobile2 = validateMobileNumber(mobile2);

            var mobileMatches = mobile1.value === mobile2.value;

            document.getElementById('<%= lblMobile.ClientID %>').style.display = isValidMobile1 ? 'none' : 'inline';
            document.getElementById('<%= lblMobile1.ClientID %>').style.display = isValidMobile2 ? 'none' : 'inline';

            if (!mobileMatches) {
                document.getElementById('<%= lblMobile1.ClientID %>').innerText = "Mobile numbers do not match";
                document.getElementById('<%= lblMobile1.ClientID %>').style.display = 'inline';
            } else if (isValidMobile1 && isValidMobile2) {
                document.getElementById('<%= lblMobile1.ClientID %>').style.display = 'none';
            }

            return isValidMobile1 && isValidMobile2 && mobileMatches;
        }


    </script>

</head>
<body style="background-color: #ECF0F1;" onunload="disableBackButton()">
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
                        <span class="nav-link">Advertisement No.: KPT/TBE/2024-02</span>
                    </li>
                </ul>

                <ul class="navbar-nav">
                    <%--                  <li class="nav-item active">
                       <a class="nav-link" href="Register.aspx"><i class="far fa-edit"></i><span>New Registration</span></a>
                   </li>--%>
                    <li class="nav-item active">
                        <a class="nav-link" href="Login.aspx"><i class="fa fa-sign-out" aria-hidden="true"></i><span>Logout</span></a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="container col-lg-12">
        <div class="card o-hidden border-0 shadow-sms my-0">
            <div class="card-body p-0">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="p-3">
                            <div class="text-center">
                                <h5 class="card text-white font-weight-bold mb-2 bg-info p-1">Personal Information</h5>
                            </div>

                            <form runat="server" autocompletetype="Disabled" autocomplete="off">
                                <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                                <div class="form-row">
                                    <div class="form-group col-md-2">
                                        <label for="inputAadhar" class="form-label font-weight-bold">App.No.<font color="red">*</font></label>
                                        <asp:TextBox ID="txtRegno" class="form-control form-control-sm" Style="font-size: small" ReadOnly="true" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Applicant Name <font color="red">*</font> </label>
                                        <asp:TextBox ID="txtName" class="form-control form-control-sm" MaxLength="50" AutoCompleteType="Disabled" autocomplete="off" oncopy="return false" onpaste="return false" oncut="return false" runat="server" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                        <asp:Label ID="lblName" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Applicant Name Required"></asp:Label>
                                    </div>

                                    <div class="form-group col-md-1">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Gender<font color="red">*</font></label>
                                        <asp:DropDownList ID="ddlGender" class="form-control form-control-sm" runat="server">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                            <asp:ListItem>Others</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="lblGender" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Gender Required"></asp:Label>
                                    </div>

                                    <div class="form-group col-md-2">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Marital Status<font color="red">*</font></label>
                                        <asp:DropDownList ID="ddlMarital" class="form-control form-control-sm" runat="server">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Single</asp:ListItem>
                                            <asp:ListItem>Married</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="lblMarital" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Marital Status Required"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-1">
                                        <label for="inputAadhar" class="form-label font-weight-bold">Nationality<font color="red">*</font></label>
                                        <asp:TextBox ID="txtNaty" class="form-control form-control-sm" Text="INDIAN" ReadOnly="true" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-2">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Religion<font color="red">*</font></label>
                                        <asp:DropDownList ID="ddlReligion" class="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlReligion_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Hinduism</asp:ListItem>
                                            <asp:ListItem>Christianity</asp:ListItem>
                                            <asp:ListItem>Islam</asp:ListItem>
                                            <asp:ListItem>Jainism</asp:ListItem>
                                            <asp:ListItem>Sikhism</asp:ListItem>
                                            <asp:ListItem>Buddhism</asp:ListItem>
                                            <asp:ListItem>Other</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="lblReligion" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Religion Required"></asp:Label>
                                    </div>

                                    <div class="form-group col-md-2" id="divOther" runat="server" visible="false">
                                        <label for="father" class="form-label font-weight-bold">Other Religion<font color="red">*</font></label>
                                        <asp:TextBox ID="txtOther" class="form-control form-control-sm" MaxLength="20" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                        <asp:Label ID="lblOther" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Other Religion Required"></asp:Label>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <div class="form-row">
                                            <div class="form-group col-md-3">
                                                <label for="inputDiscipline" class="form-label font-weight-bold">Post Applied for <font color="red">*</font></label>
                                                <asp:DropDownList ID="ddlPost" class="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPost_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:Label ID="lblPost" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Post Applied Required"></asp:Label>
                                            </div>

                                            <div class="form-group col-md-2">
                                                <label for="inputDiscipline" class="form-label font-weight-bold">Category <font color="red">*</font></label>
                                                <asp:DropDownList ID="ddlCategory" class="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:Label ID="lblCategory" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Category Required"></asp:Label>
                                            </div>

                                            <div class="form-group col-md-2" runat="server" visible="false" id="divCaste">
                                                <label for="inputDOc" class="form-label font-weight-bold">Caste Certificate No.<font color="red">*</font></label>
                                                <asp:TextBox ID="castCert" class="form-control form-control-sm" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="40" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                                <asp:Label ID="lblCastCert" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Caste Certificate No. Required"></asp:Label>
                                            </div>
                                            <div class="form-group col-md-2" runat="server" visible="false" id="divCasteDt">
                                                <label for="inputDOd1" class="form-label font-weight-bold">Date of Issue<font color="red">*</font></label>
                                                <asp:TextBox ID="txtCasteDate" class="form-control form-control-sm" placeholder="DD-MM-YYYY" autocomplete="off" Text="" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="10" AutoPostBack="true" OnTextChanged="txtCasteDate_TextChanged"></asp:TextBox>
                                                <asp:Label ID="lblCasteIssDt" runat="server" ForeColor="Red" Visible="false" Font-Bold="true" Text="Certificate Issue Date Required"></asp:Label>
                                                <ajaxToolkit:MaskedEditExtender ID="maskCasteDate" runat="server" TargetControlID="txtCasteDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                            </div>
                                            <div class="form-group col-md-2">
                                                <label for="inputDOd2" class="form-label font-weight-bold">State of Domicile<font color="red">*</font></label>
                                                <asp:DropDownList ID="ddlDomState" class="form-control form-control-sm" runat="server"></asp:DropDownList>
                                                <asp:Label ID="lblDomState" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="State of Domicile Required"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="form-row">
                                            <div class="form-group col-md-6" id="divESM" runat="server" visible="false">
                                                <asp:Label ID="lblESM" runat="server" ForeColor="Black" Font-Bold="true" Text=""></asp:Label>
                                                <asp:DropDownList ID="ddlESM" class="form-control form-control-sm" runat="server">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblESM1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Not Eligible"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="form-row">
                                            <div class="form-group col-md-4">
                                                <label for="inputDiscipline" class="form-label font-weight-bold">Ex-Servicemen Experience (Armed Forces)?<font color="red">*</font></label>
                                                <asp:DropDownList ID="ddlExArmy" class="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlExArmy_SelectedIndexChanged">
                                                    <asp:ListItem Selected Disabled>Select</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblExArmy" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Selection Required"></asp:Label>
                                            </div>

                                            <div class="form-group col-md-4" id="divRank" runat="server" visible="false">
                                                <label for="inputDiscipline" class="form-label font-weight-bold">Last Rank Held<font color="red">*</font></label>
                                                <asp:TextBox ID="txtRank" class="form-control form-control-sm" MaxLength="99" autocomplete="off" placeholder="Last Rank Held" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                                <asp:Label ID="lblRank" runat="server" ForeColor="Red" Visible="false" Text="Last Rank Held Required"></asp:Label>
                                            </div>

                                            <div class="form-group col-md-2" id="divEnroll" runat="server" visible="false">
                                                <label for="inputDiscipline" class="form-label font-weight-bold">Date of Enrollment<font color="red">*</font></label>
                                                <asp:TextBox ID="txtFrom" class="form-control form-control-sm" MaxLength="10" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txtFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                                <asp:Label ID="lblFrom" runat="server" ForeColor="Red" Visible="false" Text="Date of Enrollment Required"></asp:Label>
                                            </div>
                                            <div class="form-group col-md-2" id="divDis" runat="server" visible="false">
                                                <label for="inputDiscipline" class="form-label font-weight-bold">Date of Discharge<font color="red">*</font></label>
                                                <asp:TextBox ID="txtUpto" class="form-control form-control-sm" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="10"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtUpto" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                                <asp:Label ID="lblUpto" runat="server" ForeColor="Red" Visible="false" Text="Date of Discharge Required"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="form-row">
                                            <div class="form-group col-md-3" id="divRelexp" runat="server" visible="false">
                                                <asp:Label ID="lblRelevantExp" runat="server" ForeColor="Black" Font-Bold="true" Text="Do you have Relevant Experience?">Do you have Relevant Experience?</asp:Label>
                                                <asp:DropDownList ID="ddlRelevantExp" class="form-control form-control-sm mt-2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRelevantExp_SelectedIndexChanged">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblRelExp" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Selection Required"></asp:Label>
                                            </div>

                                            <div class="form-group col-md-1" id="divYears" runat="server" visible="false">
                                                <label for="inputDOd1" class="form-label font-weight-bold">Years<font color="red">*</font></label>
                                                <asp:DropDownList ID="ddlYears" class="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlYears_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:Label ID="lblYears" runat="server" ForeColor="Red" Visible="false" Font-Bold="true" Text="Years Required"></asp:Label>
                                            </div>

                                            <div class="form-group col-md-1" id="divMonths" runat="server" visible="false">
                                                <label for="inputDOd1" class="form-label font-weight-bold">Months<font color="red">*</font></label>
                                                <asp:DropDownList ID="ddlMonths" class="form-control form-control-sm" runat="server"></asp:DropDownList>
                                                <asp:Label ID="lblMonths" runat="server" ForeColor="Red" Visible="false" Font-Bold="true" Text="Months Required"></asp:Label>
                                            </div>
                                            <div class="form-group col-md-1" id="divDays" runat="server" visible="false">
                                                <label for="inputDOd1" class="form-label font-weight-bold">Days<font color="red">*</font></label>
                                                <asp:DropDownList ID="ddlDays" class="form-control form-control-sm" runat="server"></asp:DropDownList>
                                                <asp:Label ID="lblDays" runat="server" ForeColor="Red" Visible="false" Font-Bold="true" Text="Days Required"></asp:Label>
                                            </div>


                                            <div class="form-group col-md-3" runat="server" visible="false" id="DivAppr" >
                                                <label for="inputDiscipline" class="form-label font-weight-bold">Have you done Apprenticeship with HAL?<font color="red">*</font></label>
                                                <asp:DropDownList ID="ddlApprentice" class="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlApprentice_SelectedIndexChanged">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblApprentice" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Selection Required"></asp:Label>
                                            </div>

                                            <div class="form-group col-md-1" runat="server" visible="false" id="divJoinDate">
                                                <label for="inputDOd1" class="form-label font-weight-bold">Joining Date<font color="red">*</font></label>
                                                <asp:TextBox ID="txtJoinDate" class="form-control form-control-sm" Width="110%" placeholder="DD-MM-YYYY" autocomplete="off" Text="" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="10" AutoPostBack="true" OnTextChanged="txtCasteDate_TextChanged"></asp:TextBox>
                                                <asp:Label ID="lblJoinDate" runat="server" ForeColor="Red" Visible="false" Font-Bold="true" Text="Joining Date Required"></asp:Label>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtJoinDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                            </div>
                                            &nbsp;&nbsp;&nbsp;&nbsp;

                                            <div class="form-group" runat="server" visible="false" id="divLeaveDate">
                                                <label for="inputDOd1" class="form-label font-weight-bold">Leaving Date<font color="red">*</font></label>
                                                <asp:TextBox ID="txtLeaveDate" class="form-control form-control-sm" placeholder="DD-MM-YYYY" autocomplete="off" Text="" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="10" AutoPostBack="true" OnTextChanged="txtCasteDate_TextChanged"></asp:TextBox>
                                                <asp:Label ID="lblLeaveDate" runat="server" ForeColor="Red" Visible="false" Font-Bold="true" Text="Leaving Date Required"></asp:Label>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtLeaveDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                            </div>

                                        </div>

                                        <div class="form-row">

                                            <div class="form-group col-md-3">
                                                <label for="inputDiscipline" class="form-label font-weight-bold">Domicile in Jammu & Kashmir?<font color="red">*</font></label>
                                                <asp:DropDownList ID="ddlDomicile" class="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDomicile_SelectedIndexChanged">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblDomicile" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Selection Required"></asp:Label>
                                            </div>

                                            <div class="form-group col-md-2" runat="server" visible="false" id="divJKD">
                                                <label for="inputDOd1" class="form-label font-weight-bold">Date of Issue of Domicile<font color="red">*</font></label>
                                                <asp:TextBox ID="txtDomDate" class="form-control form-control-sm" placeholder="DD-MM-YYYY" autocomplete="off" Text="" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="10" AutoPostBack="true" OnTextChanged="txtCasteDate_TextChanged"></asp:TextBox>
                                                <asp:Label ID="lblDomDate" runat="server" ForeColor="Red" Visible="false" Font-Bold="true" Text="Domicile Issue Date Required"></asp:Label>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDomDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                            </div>
                                        </div>

                                        <div class="form-row">
                                            <div class="form-group col-md-2" runat="server">
                                                <label for="inputDOB" class="form-label font-weight-bold">PwD Applicant?<font color="red">*</font></label>
                                                <asp:DropDownList ID="ddlPwD" class="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPwD_SelectedIndexChanged">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                    <asp:ListItem>No</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblPwd" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Selection Required"></asp:Label>
                                            </div>

                                            <div class="form-group col-md-2" runat="server" visible="false" id="divPwdType">
                                                <label for="inputDOB" class="form-label font-weight-bold">PwD Category<font color="red">*</font></label>
                                                <asp:DropDownList ID="ddlPwdType" class="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPwdType_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:Label ID="lblPwdType" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="PwD Category Required"></asp:Label>
                                            </div>
                                            <div class="form-group col-md-1" runat="server" visible="false" id="divPwBD">
                                                <label for="inputCandidatename" class="form-label font-weight-bold">PwD (%)<font color="red">*</font></label>
                                                <asp:TextBox ID="txtPHPer" class="form-control form-control-sm" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="2" autocomplete="off" runat="server" onkeypress="return isNumber(event)"></asp:TextBox>
                                                <asp:Label ID="lblPHPer" runat="server" ForeColor="Red" Visible="false" Font-Bold="true" Text="PwD(%) Required"></asp:Label>
                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPHPer" ForeColor="Red" ErrorMessage="PwD % should be 40% or above" MaximumValue="100" MinimumValue="40" Type="Integer"></asp:RangeValidator>
                                            </div>

                                            <div class="form-group col-md-2">
                                                <label for="inputDOB" class="form-label font-weight-bold">Applicant Date of Birth <font color="red">*</font></label>
                                                <asp:TextBox ID="txtDOB" class="form-control form-control-sm" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="10" placeholder="DD-MM-YYYY" AutoPostBack="true" OnTextChanged="txtDOB_TextChanged"></asp:TextBox>
                                                <asp:Label ID="lblDOB1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Correct Date format DD/MM/YYYY"></asp:Label>
                                                <ajaxToolkit:MaskedEditExtender ID="maskDOB" runat="server" TargetControlID="txtDOB" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                            </div>

                                            <div class="form-group col-md-3">
                                                <label for="inputDOB1" class="form-label font-weight-bold">Age as on 01-01-2024</label>
                                                <asp:TextBox ID="txtDOB2" class="form-control form-control-sm" autocomplete="off" ReadOnly="true" Text="" runat="server"></asp:TextBox>
                                                <asp:Label ID="lblDOB2" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="You are not Eligible"></asp:Label>
                                            </div>
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="father" class="form-label font-weight-bold">EMail ID</label>
                                        <asp:TextBox ID="txtMail" class="form-control form-control-sm" MaxLength="150" Type="Password" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.validateEmail()"></asp:TextBox>
                                        <asp:Label ID="lblMail" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="EMail ID Required"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="father" class="form-label font-weight-bold">Confirm EMail ID <font color="red">*</font></label>
                                        <asp:TextBox ID="txtMail1" class="form-control form-control-sm" MaxLength="150" Style="text-transform: uppercase" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.validateEmail()"></asp:TextBox>
                                        <asp:Label ID="lblMail1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Confirm EMail ID Required"></asp:Label>
                                    </div>

                                    <div class="form-group col-md-2">
                                        <label for="father" class="form-label font-weight-bold">Mobile Number</label>
                                        <asp:TextBox ID="txtMobile" class="form-control form-control-sm" MaxLength="10" Type="Password" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="validateMobileFields()" onkeypress="return isNumber(event)"></asp:TextBox>
                                        <asp:Label ID="lblMobile" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Mobile Number Required"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="father" class="form-label font-weight-bold">Confirm Mobile Number<font color="red">*</font></label>
                                        <asp:TextBox ID="txtMobile1" class="form-control form-control-sm" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" runat="server" onkeyup="validateMobileFields()" onkeypress="return isNumber(event)"></asp:TextBox>
                                        <asp:Label ID="lblMobile1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Confirm Mobile Number Required"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-2">
                                        <label for="father" class="form-label font-weight-bold">Aadhar Number</label>
                                        <asp:TextBox ID="txtAdhar" class="form-control form-control-sm" MaxLength="12" Type="Password" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeypress="return isNumber(event)"></asp:TextBox>
                                        <asp:Label ID="lblAdhar" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Aadhar Required"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="father" class="form-label font-weight-bold">Confirm Aadhar Number<font color="red">*</font></label>
                                        <asp:TextBox ID="txtAdhar1" class="form-control form-control-sm" MaxLength="12" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeypress="return isNumber(event)"></asp:TextBox>
                                        <asp:Label ID="lblAdhar1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Confirm Aadhar Required"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="father" class="form-label font-weight-bold">Father's / Husband's Name <font color="red">*</font></label>
                                        <asp:TextBox ID="txtFatherName" class="form-control form-control-sm" MaxLength="50" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                        <asp:Label ID="lblFather" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Father's / Husband Name Required"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="father" class="form-label font-weight-bold">Mother's Name <font color="red">*</font></label>
                                        <asp:TextBox ID="txtMotherName" class="form-control form-control-sm" MaxLength="50" Style="text-transform: uppercase" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                        <asp:Label ID="lblMother" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Mother's Name Required"></asp:Label>
                                    </div>
                                </div>

                                <div class="text-left">
                                    <h5 class="card text-white font-weight-bold mb-2 bg-info py-1">&emsp;Correspondence Address</h5>
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-3">
                                        <label for="inputEmail" class="form-label font-weight-bold">Flat/House No./Building/Apartment <font color="red">*</font></label>
                                        <asp:TextBox ID="txtHNo" class="form-control form-control-sm mb-2" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" MaxLength="150" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblHNo" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Flat/House No./Building/Apartment Required"></asp:Label>
                                    </div>

                                    <div class="form-group col-md-3">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Area/Colony/Street Name<font color="red">*</font></label>
                                        <asp:TextBox ID="txtArea" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblArea" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Area/Colony/Street Name Required"></asp:Label>
                                    </div>

                                    <div class="form-group col-md-3">
                                        <label for="inputCandidatename" class="form-label font-weight-bold">Landmark <font color="red">*</font></label>
                                        <asp:TextBox ID="txtLandmark" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblLandmark" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Landmark Required"></asp:Label>
                                    </div>

                                    <div class="form-group col-md-3">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">City/Town/Village<font color="red">*</font></label>
                                        <asp:TextBox ID="txtCity" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblCity" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="City/Town/Village Required"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-3">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">District Name<font color="red">*</font></label>
                                        <asp:TextBox ID="txtDist" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblDist" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="District Name Required"></asp:Label>
                                    </div>

                                    <div class="form-group col-md-3">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">State Name<font color="red">*</font></label>
                                        <asp:TextBox ID="txtState" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblState" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="State Name Required"></asp:Label>
                                    </div>

                                    <div class="form-group col-md-2">
                                        <label for="inputCandidatename" class="form-label font-weight-bold">Pin Code <font color="red">*</font></label>
                                        <asp:TextBox ID="txtPin" class="form-control form-control-sm" MaxLength="6" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeypress="return isNumber(event)"></asp:TextBox>
                                        <asp:Label ID="lblPin" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Pin Code Required"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Nearest Post Office<font color="red">*</font></label>
                                        <asp:TextBox ID="txtPO" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblPO" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Nearest Post Office Required"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Nearest Railway Station<font color="red">*</font></label>
                                        <asp:TextBox ID="txtRail" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblRail" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Nearest Railway Station Required"></asp:Label>
                                    </div>
                                </div>

                                <div class="text-left">
                                    <h5 class="card text-white font-weight-bold mb-2 bg-info py-1">&emsp;Permanent Address</h5>
                                </div>

                                <div class="form-row">
                                    <asp:CheckBox ID="chkSame" class="form-control form-control-sm font-weight-bold mb-2 bg-gray-200 text-dark" runat="server" Text="&nbsp; Is Permanent Address Same as Correspondence Address ?" AutoPostBack="true" OnCheckedChanged="chkSame_CheckedChanged" />
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-3">
                                        <label for="inputEmail" class="form-label font-weight-bold">Flat/House No./Building/Apartment <font color="red">*</font></label>
                                        <asp:TextBox ID="txtHNo1" class="form-control form-control-sm mb-2" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" MaxLength="150" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblHNo1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Flat/House No./Building/Apartment Required"></asp:Label>
                                    </div>

                                    <div class="form-group col-md-3">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Area/Colony/Street Name<font color="red">*</font></label>
                                        <asp:TextBox ID="txtArea1" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblArea1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Area/Colony/Street Name Required"></asp:Label>
                                    </div>

                                    <div class="form-group col-md-3">
                                        <label for="inputCandidatename" class="form-label font-weight-bold">Landmark<font color="red">*</font></label>
                                        <asp:TextBox ID="txtLandmark1" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblLandmark1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Landmark Required"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">City/Town/Village<font color="red">*</font></label>
                                        <asp:TextBox ID="txtCity1" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblCity1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="City/Town/Village Required"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-3">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">District Name<font color="red">*</font></label>
                                        <asp:TextBox ID="txtDist1" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblDist1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="District Name Required"></asp:Label>
                                    </div>

                                    <div class="form-group col-md-3">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">State Name<font color="red">*</font></label>
                                        <asp:TextBox ID="txtState1" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblState1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="State Name Required"></asp:Label>
                                    </div>

                                    <div class="form-group col-md-2">
                                        <label for="inputCandidatename" class="form-label font-weight-bold">Pin Code <font color="red">*</font></label>
                                        <asp:TextBox ID="txtPin1" class="form-control form-control-sm" MaxLength="6" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeypress="return isNumber(event)"></asp:TextBox>
                                        <asp:Label ID="lblPin1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Pin Code Required"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Nearest Post Office<font color="red">*</font></label>
                                        <asp:TextBox ID="txtPO1" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblPO1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Nearest Post Office Required"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Nearest Railway Station<font color="red">*</font></label>
                                        <asp:TextBox ID="txtRail1" class="form-control form-control-sm" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" autocomplete="off" runat="server" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:Label ID="lblRail1" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Nearest Railway Station Required"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-12">
                                        <label for="edu10n" class="text-dark font-weight-bold mb-2"><b>Declaration:</b></label>
                                        <div class="col-12 text-left">
                                            <asp:CheckBox ID="chkConfirm" runat="server" class="form-control form-control-sm text-dark font-weight-bold text-dark form-check" Text="<b> &nbsp;&nbsp; I hereby declare that the above information is true to the best of my knowledge.</b>" AutoPostBack="true" OnCheckedChanged="chkConfirm_CheckedChanged" />
                                        </div>
                                    </div>
                                </div>

                                <br />
                                <asp:Label ID="lblStatus" runat="server" ForeColor="Red" Visible="false" Font-Bold="true" Text=""></asp:Label>  

                                <div class="d-flex justify-content-between">
                                   <asp:Button ID="btnSave" runat="server" class="btn btn-primary mt-2" enabled="false" Text=" Save and Next " OnClick="btnSave_Click"/>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        if (document.referrer == "") {
            document.location = "/Login.aspx";
        }
    </script>
</body>
</html>
