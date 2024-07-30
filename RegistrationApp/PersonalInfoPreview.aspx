<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalInfoPreview.aspx.cs" Inherits="RegistrationApp.PersonalInfoPreview" %>

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
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <!-- Custom fonts for this template-->
    <link href="css/all.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

    <%--this script is for eye field in password box--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom styles for this template -->
    <link href="css/layout.css" rel="stylesheet">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style>
        td {
            height: 30px;
        }

        .checkbox-container {
            width: 150px; /* Adjust this width as needed */
            margin: 0px auto;
        }
    </style>
</head>

<body>
    <div class="container-fluid bg-white">
        <div class="row">
            <div class="col-md-2 col-12">
                <center>
                    <img src="img/logo.png" class="img img-rounded img-responsive" height="80px" width="150px" />
                </center>
            </div>
            <div class="col-lg-6 col-12">
                <center class="py-1">
                    <h4 class="text-primary">&emsp;&emsp;&emsp;<b>Hindustan Aeronautics Limited.</b></h4>
                    <h5 class="mb-0">&emsp;&emsp;&emsp;Aircraft Division, Nashik</h5>
                    <p class="mb-0">&emsp;&emsp;&emsp;Ojhar Township (Post), Nashik-422207 </p>
                </center>
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
                        <span class="nav-link">Notification No. HR/TBE/2024/03</span>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <form id="form1" runat="server">
        <div id="printView" class="container invoice-container" style="margin-top: 20px; margin-bottom: 10px;">

            <page size="A4">
                <table style="border: 2px solid #000; width: 100%;">
                    <tr>
                        <th>
                            <center class="bg-info text-white">
                                <h5><strong>Preview For Personal Information</strong></h5>
                            </center>
                        </th>
                    </tr>
                    <tr>
                        <td>

                            <table border="1" style="width: 100%;">
                                <tr>
                                    <td>&nbsp;Application Number</td>
                                    <td>&nbsp;
                                        <asp:Label ID="lblAppno" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="mt-1">&nbsp;Post applied for</td>
                                    <td>&nbsp;
                                        <asp:Label ID="lblPost" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;Name of Applicant</td>
                                    <td>&nbsp;
                                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;Date of Birth(DD-MM-YYYY)</td>
                                    <td>&nbsp;
                                        <asp:Label ID="lblDOB" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>

                            <table border="1" style="width: 100%;">
                                <tr>
                                    <td colspan="3"><b>Personal Information :</b></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;Father's Name</td>
                                    <td colspan="2">&nbsp;
                                        <asp:Label ID="lblFather" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;Mother's Name</td>
                                    <td colspan="2">&nbsp;
                                        <asp:Label ID="lblMother" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;Mobile Number : <span>
                                        <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label></span></td>
                                    <td>&nbsp;E-mail Id : <span>
                                        <asp:Label ID="lblMail" runat="server" Text=""></asp:Label></span></td>
                                    <td>&nbsp;Aadhar Number : <span>
                                        <asp:Label ID="lblAdhar" runat="server" Text=""></asp:Label></span></td>
                                </tr>

                                <tr>
                                    <td>&nbsp;Gender : <span>
                                        <asp:Label ID="lblGender" runat="server" Text=""></asp:Label></span></td>
                                    <td>&nbsp;Marital Status : <span>
                                        <asp:Label ID="lblMarital" runat="server" Text=""></asp:Label></span></td>
                                    <td>&nbsp;Nationality : <span>
                                        <asp:Label ID="lblNationality" runat="server" Text=""></asp:Label></span></td>
                                </tr>

                                <tr>
                                    <td>&nbsp;Religion : <span>
                                        <asp:Label ID="lblReligion" runat="server" Text=""></asp:Label></span></td>
                                    <td>&nbsp;Other Religion : <span>
                                        <asp:Label ID="lblReligionOther" runat="server" Text=""></asp:Label></span></td>
                                    <td>&nbsp;State of Domicile : <span>
                                        <asp:Label ID="lblDomState" runat="server" Text=""></asp:Label></span></td>
                                </tr>

                                <tr>
                                    <td>&nbsp;Category : <span>
                                        <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label></span></td>
                                    <td>&nbsp;Caste Certificate No.: <span>
                                        <asp:Label ID="lblCastNo" runat="server" Text=""></asp:Label></span></td>
                                    <td>&nbsp;Date of Issue : <span>
                                        <asp:Label ID="lblCasteDate" runat="server" Text=""></asp:Label></span></td>
                                </tr>

                                <tr>
                                    <td>&nbsp;PwD : <span>
                                        <asp:Label ID="lblPH" runat="server" Text=""></asp:Label></span></td>
                                    <td>&nbsp;PwD Type : <span>
                                        <asp:Label ID="lblPwdType" runat="server" Text=""></asp:Label></span></td>
                                    <td>&nbsp;PwD % :<span><asp:Label ID="lblPHPer" runat="server" Text=""></asp:Label></span></td>
                                </tr>
                            </table>


                            <table border="1" style="width: 100%;">
                                <tr>
                                    <td colspan="2"><b>Address Details :</b></td>
                                </tr>
                                <tr>
                                    <td width="28%">&nbsp;Communication Address</td>
                                    <td colspan="2">&nbsp;<asp:Label ID="lblAddress1" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;Permanent Address</td>
                                    <td colspan="2">&nbsp;
                                        <asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>

                            <table border="1" style="width: 100%;">
                                <tr>
                                    <td style="width: 50%">&nbsp;Domicile of Jammu & Kashmir : <span>
                                        <asp:Label ID="lblDom" runat="server" Text=""></asp:Label></span></td>
                                    <td>&nbsp;Domicile Issue Date : <span>
                                        <asp:Label ID="lblDomDate1" runat="server" Text=""></asp:Label></span></td>

                                </tr>

                                <tr>
                                    <td>&nbsp;Do you have Relevant Experience? : <span>
                                        <asp:Label ID="lblRelExp1" runat="server" Text=""></asp:Label></span></td>
                                    <td colspan="2">&nbsp;Period of Relevant Experience : <span>
                                        <asp:Label ID="lblPeriod" runat="server" Text=""></asp:Label></span></td>
                                </tr>

                                <tr>
                                    <td>&nbsp;Ex-Servicemen Experience (Armed Forces)? : <span>
                                        <asp:Label ID="lblExService" runat="server" Text=""></asp:Label></span></td>
                                    <td colspan="2">&nbsp;Period of Ex-Servicemen Experience : <span>
                                        <asp:Label ID="lblExService1" runat="server" Text=""></asp:Label></span></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;Have you done Apprenticeship with HAL, Nashik? : <span>
                                        <asp:Label ID="lblAppHal" runat="server" Text=""></asp:Label></span></td>
                                    <td>&nbsp;Period of Apprenticeship  : <span>
                                        <asp:Label ID="lblApprentiship" runat="server" Text=""></asp:Label></span></td>
                                </tr>
                            </table>
                            <table>
                                <center class="bg-info text-white">
                                    <h5><strong>Document Required !</strong></h5>
                                </center>
                            </table>
                            <table>
                                <tr>
                                    <td class="checkbox-container" runat="server" id="tdPhoto">
                                        <asp:CheckBox runat="server" ID="ChkPhoto" Text="Photo" />
                                    </td>
                                    <td class="checkbox-container" runat="server" id="tdSighn">
                                        <asp:CheckBox runat="server" ID="ChkSign" Text="Signature" />
                                    </td>
                                    <td class="checkbox-container" runat="server" id="tdAdhar">
                                        <asp:CheckBox runat="server" ID="ChkAadhar" Text="Aadhar Card" />

                                    </td>
                                    <%--<td class="checkbox-container" runat="server" id="tdPwd" visible="false">
                                        <asp:CheckBox runat="server" ID="ChkPwd" Text="Pwd Certificate" />
                                    </td>
                                    <td class="checkbox-container" runat="server" id="tdCaste" visible="false">
                                        <asp:CheckBox runat="server" ID="ChkCaste" Text="Caste Certificate" />
                                    </td>
                                    <td class="checkbox-container" runat="server" id="tdHALApr" visible="false">
                                        <asp:CheckBox runat="server" ID="ChkHALApr" Text="Apprenticeship with HAL Certificate" />
                                    </td>
                                    <td class="checkbox-container" runat="server" id="tdJK" visible="false">
                                        <asp:CheckBox runat="server" ID="ChkJK" Text="Domicile J & K Certificate" />
                                    </td>
                                    <td class="checkbox-container" runat="server" id="tdCmb" visible="false">
                                        <asp:CheckBox runat="server" ID="ChCmb" Text="Combatant Certificate" />
                                    </td>--%>
                                </tr>
                            </table>
                            <div class="text-left mt-1 ml-0 mr-4 text-center">
                                <h6>
                                    <asp:Label Text="" ID="Error" runat="server" /></h6>
                            </div>

                            <hr />
                            <div class="text-left mt-1 ml-0 mr-4 text-center">
                                <h6 class="blink"><font color="red">Once you click 'Save & Next,' no more changes will be allowed on this page.<br />
                                    एक बार "Save & Next" पर क्लिक करने पर इस पृष्ठ पर कोई और बदलाव की अनुमति नहीं दी जाएगी।</font></h6>
                            </div>
                            <hr />
                            <div class="row" style="align-items: center; display: flex; margin-top: 10px; margin-bottom: 10px; justify-content: center;">
                                <div class="col-sm-2">
                                    <%--                                    <button class="btn btn-danger w-25" style="margin-left: 5%;" >Edit</button>--%>
                                    <asp:Button ID="btnEdit" runat="server" class="btn btn-info w-100" Text="Edit" OnClick="btnEdit_Click" />
                                </div>
                                <div class="col-sm-2">
                                    <%-- <button class="btn btn-success w-25" style="margin-left: 70%;" onClick="btnSave_Click">Next</button>--%>
                                    <asp:Button ID="btnSave" runat="server" class="btn btn-success w-100" Text="Next" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </page>

            <script>
                $(document).ready(function () {

                    if (document.referrer == "") {
                        document.location = "/index.aspx";
                    }
                });
            </script>
        </div>
    </form>
</body>
</html>
