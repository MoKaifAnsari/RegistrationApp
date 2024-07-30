<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EducationPreview.aspx.cs" Inherits="RegistrationApp.EducationPreview" %>

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
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
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
                        <span class="nav-link" style="font-size: 20px">Advertisement No.: KPT/TBE/2024-02</span>
                    </li>
                </ul>
                <ul class="navbar-nav">
                    <li class="nav-item active">
                        <%--<span class="nav-link">Advertisement No.: KPT/TBE/2024-02</span>--%>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <form id="form1" runat="server">
        <div id="printView" class="container invoice-container">

            <page size="A4">
                <table style="border: 2px solid #000; width: 100%; margin-top: 10px; margin-bottom: 10px;">
                    <tr>
                        <td>

                            <table border="1" style="width: 100%;">
                                <tr>
                                    <th colspan="5">
                                        <center class="bg-info text-white">
                                            <h3><strong>Preview For Education</strong></h3>
                                        </center>
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="5"><b>Educational Qualifications :</b></td>
                                </tr>
                                <tr>
                                    <td>Examination</td>
                                    <td>Education Mode</td>
                                    <td>Board/University</td>
                                    <td>Date of Passing</td>
                                    <td>% of Marks</td>
                                </tr>

                                <tr>
                                    <td>10th/Matriculation</td>
                                    <td>
                                        <asp:Label ID="lblMode10" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblInst10" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblPassDate10" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblPercent10" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr id="tr12" runat="server">
                                    <td>12th/Intermediate</td>
                                    <td>
                                        <asp:Label ID="lblMode12" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblInst12" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblPassDate12" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblPercent12" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>

                            <table border="1" style="width: 100%;" runat="server" id="TBLEssQual">
                                <tr>
                                    <td colspan="6"><b>Essential Qualifications :</b></td>
                                </tr>
                                <tr>
                                    <td>Examination</td>
                                    <td>Streem</td>
                                    <td>Education Mode</td>
                                    <td>Board/University</td>
                                    <td>Date of Passing</td>
                                    <td>% of Marks</td>
                                </tr>

                                <tr id="trITI" runat="server" visible="false">
                                    <td>ITI</td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lblCourseITI" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblModeITI" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblPassDateITI" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblPercentITI" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr id="trDiploma" runat="server" visible="false">
                                    <td>Diploma</td>
                                    <td>
                                        <asp:Label ID="lblCourseDip" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblModeDip" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblInstDip" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblPassDateDip" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblPercentDip" runat="server" Text=""></asp:Label></td>
                                </tr>

                                <tr id="trNAC" runat="server" visible="false">
                                    <td>NAC Course</td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lblNacMode" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtNacUniv" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtNacDate" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="txtNacPer" runat="server" Text=""></asp:Label></td>

                                </tr>
                            </table>

                            <table border="1" style="width: 100%;" runat="server" id="TBLCom">
                                <tr>
                                    <th colspan="4">Detaiol of Combatant Experiences :<asp:Label ID="Label1" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr runat="server">
                                    <td>Rank Held</td>
                                    <td>Joining Date</td>
                                    <td>Leaving Date</td>
                                    <td>Duration</td>
                                </tr>
                                <tr runat="server">
                                    <td>
                                        <asp:Label ID="lblRank" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblJoin" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblLeave" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDura" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>

                            <table border="1" style="width: 100%;" runat="server" id="TBLESM">
                                <tr>
                                    <th colspan="4">Detaiol of Airforce :<asp:Label ID="Label2" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr runat="server">
                                    <td>Airforce Trade</td>
                                    <td>Date</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAirTrad" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>
                            <table border="1" style="width: 100%;">
                                <tr>
                                    <th>Details of Experience :</th>
                                </tr>
                                <tr>
                                    <th>&nbsp;Name organization</th>
                                    <th>&nbsp;Designation</th>
                                    <th>&nbsp;Salary</th>
                                    <th>&nbsp;Join Date</th>
                                    <th>&nbsp;End Date</th>
                                    <th>&nbsp;Period of Experience</th>
                                </tr>
                                <tr id="TeExp1" runat="server" visible="false">
                                    <td>&nbsp;<asp:Label ID="lblNameOrd" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblDesin" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblSalary" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblJoinDate" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblPeriodExp" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr id="TeExp2" runat="server" visible="false">
                                    <td>&nbsp;<asp:Label ID="lblNameOrd2" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblDesin2" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblSalary2" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblJoinDate2" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblEndDate2" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblPeriodExp2" runat="server" Text=""></asp:Label></td>
                                </tr>

                                <tr id="TeExp3" runat="server" visible="false">
                                    <td>&nbsp;<asp:Label ID="lblNameOrd3" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblDesin3" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblSalary3" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblJoinDate3" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblEndDate3" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblPeriodExp3" runat="server" Text=""></asp:Label></td>
                                </tr>

                                <tr id="TeExp4" runat="server" visible="false">
                                    <td>&nbsp;<asp:Label ID="lblNameOrd4" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblDesin4" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblSalary4" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblJoinDate4" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblEndDate4" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblPeriodExp4" runat="server" Text=""></asp:Label></td>
                                </tr>

                                <tr id="TeExp5" runat="server" visible="false">
                                    <td>&nbsp;<asp:Label ID="lblNameOrd5" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblDesin5" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblSalary5" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblJoinDate5" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblEndDate5" runat="server" Text=""></asp:Label></td>
                                    <td>&nbsp;<asp:Label ID="lblPeriodExp5" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>

                            <table border="1" style="width: 100%;" runat="server" id="TblApprenticeship" visible="false">
                                <tr>
                                    <th colspan="4">Have you done any Apprenticeship in HAL?* :<asp:Label ID="lblAppr" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr>
                                    <td width="20%">Name of the Apprenticeship training</td>
                                    <td width="10%">Institute / Organization</td>
                                    <td width="10%">From Date</td>
                                    <td width="10%">Upto Date</td>
                                </tr>
                                <tr id="TrAppr1" runat="server" visible="false">

                                    <td>
                                        <asp:Label ID="lbtPreNameAppr" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblOrdTrnApr" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDateSt" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDateEd" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr id="TrAppr2" runat="server" visible="false">

                                    <td>
                                        <asp:Label ID="lbtPreNameAppr2" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblOrdTrnApr2" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDateSt2" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDateEd2" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>

                            <table border="1" style="width: 100%;">
                                <tr>
                                    <th colspan="4">Have you availed Voluntary Retirement (VRS) or benefits of a similar scheme from any of your previous employer :<asp:Label ID="lblVRS" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr>
                                    <th colspan="4">Have you been interviewed by HAL any time earlier :
                                        <asp:Label ID="lblInterview" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr runat="server" visible="false" id="trInter">
                                    <td>Post Interviewed</td>
                                    <td>Date of Interview </td>
                                    <td>Venue of Interview</td>
                                </tr>
                                <tr runat="server" visible="false" id="lblInter">
                                    <td>
                                        <asp:Label ID="lblPostInter" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDateInter" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblVenueInter" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>

                            <table border="1" style="width: 100%;">
                                <tr>
                                    <th colspan="4">Are any of your close relatives working in HAL?* :<asp:Label ID="lblRelWork" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr runat="server" visible="false" id="TdRelWork">
                                    <td>Name of Relative</td>
                                    <td>Designation</td>
                                    <td>Division</td>
                                    <td>Any other Description</td>
                                </tr>
                                <tr runat="server" visible="false" id="TdRelWork2">
                                    <td>
                                        <asp:Label ID="lblNameRel" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDesigRel" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDivRel" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDescRel" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>

                            <table border="1" style="width: 100%;">
                                <tr>
                                    <th colspan="5">Have you ever been a member/worker of any polictical party/organisation or participated any political activities?:
                                    <asp:Label ID="lblPolParty" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr runat="server" visible="false" id="TdPol">
                                    <td>Name of Political Party/Organisation</td>
                                    <td>Particulars of Political Activity</td>
                                    <td>Period of Membership</td>
                                    <td>Nature of Participation in Political Activity</td>
                                    <td>Office, if any, held in Political Party</td>
                                </tr>
                                <tr runat="server" visible="false" id="TdPol2">
                                    <td>
                                        <asp:Label ID="lblPartyName" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblActivity" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblPeriodMemb" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblNature" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblOffice" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>
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

            <script type="text/javascript">
                if (document.referrer == "") {
                    document.location = "/index.aspx";
                }
            </script>

        </div>
    </form>
</body>
</html>
