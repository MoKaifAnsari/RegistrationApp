<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviewFinal.aspx.cs" Inherits="RegistrationApp.PreviewFinal" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
   <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Jharkhand High Court</title>
    <link rel="icon" type="image/x-icon" href="/img/favicon.ico">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <!-- Custom fonts for this template-->
    <link href="css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <%--this script is for eye field in password box--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom styles for this template -->
    <link href="css/layout.css" rel="stylesheet"> 



    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <style type="text/css">
         .auto-style1 {
            width: 780px;
        }
 
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 352px;
            height: 116px;
        }
        .auto-style4 {
            width: 130px;
            height: 110px;
            margin-left: 0px;
        }
        .auto-style5 {
            width: 1127px;
        }
        .auto-style6 {
            width: 130px;
            height: 30px;
        }
        .auto-style7 {
            height: 57px;
            width: 441px;
            text-align: left;
        }
        .auto-style8 {
            width: 1127px;
            height: 57px;
        }
        .auto-style10 {
            height: 69px;
            width: 441px;
            text-align: left;
        }
        .auto-style11 {
            width: 1127px;
            height: 69px;
        }
        .auto-style12 {
            width: 100%;
            height: 296px;
            margin-bottom: 20px;
        }
        .auto-style13 {
            text-align: left;
            width: 515px;
        }
        .auto-style15 {
            text-align: left;
            margin-top:10px;
        }
        .auto-style17 {
            width: 308px;
        }
        .auto-style19 {
            width: 188px;
        }
        .auto-style21 {
            width: 844px;
        }
        .auto-style23 {
            width: 302px;
        }
        .auto-style24 {
            text-align: center;
            width: 852px;
        }
        .auto-style25 {
            width: 852px;
        }
        .auto-style26 {
            width: 190px;
        }
        .auto-style27 {
            width: 190px;
            text-align: center;
        }
        .auto-style28 {
            width: 302px;
            text-align: center;
        }
        .auto-style29 {
            width: 621px;
            text-align: left;
        }
        .auto-style31 {
            height: 52px;
            text-align: left;
        }
        .auto-style32 {
            text-align: center;
            width: 677px;
        }
        .auto-style33 {
            text-align: center;
            height: 28px;
        }
        .auto-style34 {
            text-align: center;
            width: 677px;
            height: 28px;
        }
        .auto-style37 {
            width: 478px;
            text-align: center;
        }
        .auto-style39 {
            width: 358px;
            text-align: left;
        }
        .auto-style40 {
            width: 538px;
            text-align: left;
        }
        .auto-style41 {
            font-size: small;
        }
        .auto-style42 {
            text-align: justify;
            height: 104px;
        }
        .auto-style43 {
            text-align: left;
            width: 452px;
        }

        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }

        .auto-style45 {
            font-size: large;
        }
        .auto-style46 {
            width: 100%;
            height:auto
            /*height: 1462px;*/
        }
        .auto-style47 {
            width: 677px;
            text-align: left;
        }
        .auto-style48 {
            font-family: Lato, sans-serif;
            font-weight: bold;
            color: #333333;
            letter-spacing: normal;
            background-color: #FFFFFF;
        }
        .auto-style49 {
            text-align: justify;
            height: 28px;
            margin-top: 19px;
        }
        .auto-style50 {
            width: 1127px;
            text-align: left;
        }
        .auto-style51 {
            width: 441px;
            text-align: left;
        }
        .auto-style52 {
            text-align: center;
            width: 457px;
        }
        .auto-style53 {
            width: 191px;
        }
    </style>
</head>

<body style="height: 856px">
<form id="form1" runat="server">
<div id="printView" class="container invoice-container mt-3">
<page size="A4">     
    <table style="margin:0; page-break-after: always; border-style: solid; border-color: inherit; border-width: medium;" class="auto-style46">
    <tr><td class="auto-style1">
        <img src="img/jharhc.png" class="auto-style2" /><br />
        <strong><span class="auto-style45">Application Form</span></strong>
        <table class="auto-style12" border="1">
        <tr>
            <td class="auto-style51">Application Number</td>
            <td class="auto-style50"><asp:Label ID="lblAppno" runat="server" Text=""></asp:Label></td>
            <td rowspan="6">
                <asp:Image ID="imgPic" runat="server" class="auto-style4" AlternateText="img"></asp:Image>
                <br />
                <asp:Image ID="imgSign" runat="server" class="auto-style6" AlternateText="sign"></asp:Image>
            </td>
        </tr>
        <tr>
            <td class="auto-style51">Post applied for</td>
            <td class="auto-style51"><b>Personal Assistant of High Court of Jharkhand, Ranchi</b></td>
        </tr>
        <tr>
            <td class="auto-style51">Name of Applicant</td>
            <td class="auto-style51"><asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style51">Father&#39;s/Husband&#39;s Name</td>
            <td class="auto-style51"><asp:Label ID="lblFather" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style51">Address for communication with Pin Code </td>
            <td class="auto-style51"><asp:Label ID="lblAddress1" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style51">Permanent Address with Pin Code </td>
            <td class="auto-style51"><asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>

        <table style="width:100%;">
            <tr>
                <td class="auto-style51">Date of Birth :<span><asp:Label ID="lblDOB" runat="server" Text=""></asp:Label></span></td>
                <td class="auto-style51">Age as on 01-04-2022 :<span><asp:Label ID="lblAge" runat="server" Text=""></asp:Label></span></td>
                <td class="auto-style51">Place of Birth :<span><asp:Label ID="lblPlace" runat="server" Text=""></asp:Label></span></td>
            </tr>
            <tr>
                <td class="auto-style51">Nationality :<span><asp:Label ID="lblNationality" runat="server" Text=""></asp:Label></span></td>
                <td class="auto-style51">Mobile Number :<span><asp:Label ID="lblMobile" runat="server" Text=""></asp:Label></span></td>
                <td class="auto-style51">Email Id :<span><asp:Label ID="lblMail" runat="server" Text=""></asp:Label></span></td>
            </tr>
        </table>

        <p class="auto-style15"><strong>Educational and Professional Qualifications :</strong></p>
        <table style="width:100%;">
        <tr>
            <td class="auto-style17">Examination Passed</td>
            <td class="auto-style21">Name of Board/University</td>
            <td class="auto-style19">Year of Passing</td>
            <td class="auto-style53">% of Marks</td>
            <td class="auto-style53">Class/Division</td>
        </tr>
        <tr>
            <td class="auto-style17">10th</td>
            <td class="auto-style21"><asp:Label ID="lblBoard10" runat="server" Text=""></asp:Label></td>
            <td class="auto-style19"><asp:Label ID="lblPassDate10" runat="server" Text=""></asp:Label></td>
            <td class="auto-style53"><asp:Label ID="lblPercent10" runat="server" Text=""></asp:Label></td>
            <td class="auto-style53"><asp:Label ID="lblDiv10" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style17">12th</td>
            <td class="auto-style21"><asp:Label ID="lblBoard12" runat="server" Text=""></asp:Label></td>
            <td class="auto-style19"><asp:Label ID="lblPassDate12" runat="server" Text=""></asp:Label></td>
            <td class="auto-style53"><asp:Label ID="lblPercent12" runat="server" Text=""></asp:Label></td>
            <td class="auto-style53"><asp:Label ID="lblDiv12" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style17">Graduation/Equivalent Degree</td>
            <td class="auto-style21"><asp:Label ID="lblGrad" runat="server" Text=""></asp:Label></td>
            <td class="auto-style19"><asp:Label ID="lblPassDateGrad" runat="server" Text=""></asp:Label></td>
            <td class="auto-style53"><asp:Label ID="lblPercentGrad" runat="server" Text=""></asp:Label></td>
            <td class="auto-style53"><asp:Label ID="lblDivGrad" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>

        <p class="auto-style15"><strong>Special Qualification, if any :</strong></p>
        <table style="width:100%;">
            <tr>
                <td class="auto-style28">Examination Passed</td>
                <td class="auto-style24">Name of Board/University</td>
                <td class="auto-style27">Year of Passing</td>
                <td class="auto-style1">% of Marks</td>
                <td class="auto-style1">Class/Division</td>
            </tr>
            <tr>
                <td class="auto-style23"><asp:Label ID="lblEssential" runat="server" Text=""></asp:Label></td>
                <td class="auto-style25"><asp:Label ID="lblTrade" runat="server" Text=""></asp:Label></td>
                <td class="auto-style26"><asp:Label ID="lblPassDateEss" runat="server" Text=""></asp:Label></td>
                <td class="auto-style1"><asp:Label ID="lblPerEss" runat="server" Text=""></asp:Label></td>
                <td class="auto-style1"><asp:Label ID="lblDivEss" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style29">Category :<span><asp:Label ID="lblCategory" runat="server" Text=""></asp:Label></span></td>
                <td class="auto-style47">Game and Sports Quota :<span><asp:Label ID="lblSports" runat="server" Text=""></asp:Label></span></td>
                <td class="auto-style15">Gender :<span><asp:Label ID="lblGender" runat="server" Text=""></asp:Label></span></td>
            </tr>
            <tr>
                <td class="auto-style15">PwD : <span><asp:Label ID="lblPH" runat="server" Text=""></asp:Label></span></td>
                <td class="auto-style47">PwD Type :<span><asp:Label ID="lblPHType" runat="server" Text=""></asp:Label></span></td>
                <td class="auto-style15">PwD % :<span><asp:Label ID="lblPHPer" runat="server" Text=""></asp:Label></span></td>
            </tr>
            <tr>
                <td class="auto-style31" colspan="3"><strong>Whether presently serving in any Govt. Institution/Undertaking (Yes/No) : <span><asp:Label ID="lblJob" runat="server" Text=""></asp:Label></span> </strong></td>
            </tr>
            <tr>
                <td class="auto-style33">Name of Department/Institutions</td>
                <td class="auto-style34">Name of Post Held</td>
                <td class="auto-style33">Since</td>
            </tr>
            <tr>
                <td class="auto-style1"><asp:Label ID="lblDept" runat="server" Text=""></asp:Label></td>
                <td class="auto-style32"><asp:Label ID="lblDesig" runat="server" Text=""></asp:Label></td>
                <td class="auto-style1"><asp:Label ID="lblSince" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>

        <p class="auto-style15"><strong>Fees Details :</strong></p>
        <table style="width:100%;">
        <tr>
            <td class="auto-style52">Order Id</td>
            <td class="auto-style37">Payment Id</td>
            <td class="auto-style1">Amount of Fee Paid</td>
            <td class="auto-style1">Date &amp; Time</td>
        </tr>
        <tr>
            <td class="auto-style52"><asp:Label ID="lblOrderID" runat="server" Text=""></asp:Label></td>
            <td class="auto-style37"><asp:Label ID="lblPayId" runat="server" Text=""></asp:Label></td>
            <td class="auto-style1"><asp:Label ID="lblAmt" runat="server" Text=""></asp:Label></td>
            <td class="auto-style1"><asp:Label ID="lblDate" runat="server" Text=""></asp:Label></td>                    
        </tr>
    </table>
               
            
        <p class="auto-style49"><span class="auto-style48"><strong>Declarations :</strong></span></p>
        <p class="auto-style42"><span class="auto-style41" style="color: rgb(51, 51, 51); font-family: Lato, sans-serif; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 200; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">It is hereby declared that the infotmation furnished by me herin above is true to my personal knowledge and belief. It is also declared that neither Criminal case is pending against me nor I have ever been punished by any court of law, nor am I involved in or related with any criminal case for any offence involving moral turpitude. I know that if anything stated herein above turns out to be false, the High court of Jharkhand may 
            cancel my candidature at any stage of Selection process and may debar me from appearing in the examination at its sole discretion. I further declare that if I obtain appointment on any false or incorrect information, my appointment shall be terminated / cancelled and I shall be liable for prosecution under the Law.</span></p>
        <p class="auto-style15">I accept the following declaration : Yes</p>
        <p class="auto-style15">&nbsp;</p>


        <p class="auto-style39">Date : <span><asp:Label ID="lblDated" runat="server" Text=""></asp:Label></span></p>
        <p class="auto-style39">Place :<span><asp:Label ID="lblPlace1" runat="server" Text=""></asp:Label></span></p>
    </td></tr>
    </table>
</page>

<%--<page size="A4">
    <table style="margin:0 auto; page-break-after: always;" width="100%">
        <tr>
            <td>
                <table border="1" width="100%">
                    <tr>
                        <td style="padding:15px;"><asp:Image ID="imgAdhar" runat="server" Width="100%"></asp:Image></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</page>--%>

<page size="A4">
    <table style="margin:0 auto; page-break-after: always;" width="100%">
        <tr>
            <td>
                <table border="1" width="100%">
                    <tr>
                        <td><h7>10th Board Certificate</h7></td>
                    </tr>
                    <tr>
                        <td style="padding:15px;"><asp:Image ID="img10" runat="server" Width="100%"></asp:Image></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</page>

<page size="A4">
    <table style="margin:0 auto; page-break-after: always;" width="100%">
        <tr>
            <td>
                <table border="1" width="100%">
                    <tr>
                        <td><h7>Graduation Certificate</h7></td>
                    </tr>

                    <tr>
                        <td style="padding:15px;"><asp:Image ID="imgGrad" runat="server" Width="100%"></asp:Image></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</page>

<page size="A4" runat="server" id="essenPage">
    <table style="margin:0 auto; page-break-after: always;" width="100%">
        <tr>
            <td>
                <table border="1" width="100%">
                    <tr>
                        <td><h7>Other Qualification Certificate</h7></td>
                    </tr>
                    <tr>
                        <td style="padding:15px;"><asp:Image ID="imgEssen" runat="server" Width="100%"></asp:Image></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</page>

<page size="A4" runat="server" id="domicilePage">
    <table style="margin:0 auto; page-break-after: always;" width="100%">
        <tr>
            <td>
                <table border="1" width="100%">
                    <tr>
                        <td><h7>Domicile Certificate</h7></td>
                    </tr>

                    <tr>
                        <td style="padding:15px;"><asp:Image ID="imgDom" runat="server" Width="100%"></asp:Image></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</page>

<page size="A4" runat="server" id="phPage">
    <table style="margin:0 auto; page-break-after: always;" width="100%">
        <tr>
            <td>
                <table border="1" width="100%">
                    <tr>
                        <td><h7>PwD Certificate</h7></td>
                    </tr>

                    <tr>
                        <td style="padding:15px;"><asp:Image ID="imgPH" runat="server" Width="100%"></asp:Image></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</page>

<page size="A4" runat="server" id="sportsPage">
    <table style="margin:0 auto; page-break-after: always;" width="100%">
        <tr>
            <td>
                <table border="1" width="100%">
                    <tr>
                        <td><h7>Sports/Game Certificate</h7></td>
                    </tr>

                    <tr>
                        <td style="padding:15px;"><asp:Image ID="imgSports" runat="server" Width="100%"></asp:Image></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</page>

<page size="A4" runat="server" id="nocPage">
        <table style="margin:0 auto; page-break-after: always;" width="100%">
            <tr>
                <td>
                    <table border="1" width="100%">
                        <tr>
                            <td><h7> NOC Certificate of Employer</h7></td>
                        </tr>

                        <tr>
                            <td style="padding:15px;"><asp:Image ID="imgNOC" runat="server" Width="100%"></asp:Image></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
</page>
<page size="A4" runat="server" id="castePage">
    <table style="margin:0 auto; page-break-after: always;" width="100%">
        <tr>
            <td>
                <table border="1" width="100%">
                    <tr>
                        <td><h7>Caste Certificate</h7></td>
                    </tr>
                    <tr>
                        <td style="padding:15px;"><asp:Image ID="imgCaste" runat="server" Width="100%"></asp:Image></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</page>
    <br />
<div class="container justify-content-lg-center">
    <asp:Button ID="btnPrint" class="btn btn-outline-primary"  runat="server" Text="  Print  " OnClientClick="javascript:window.print();"/>
    <asp:Button ID="btnlogout" class="btn btn-outline-primary" runat="server" Text=" Logout " onCLick="btnlogout_Clicked"/>
</div>
    <br /> <br />
</div>
</form>
</body>
</html>
