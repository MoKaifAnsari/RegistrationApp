<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DownloadAdmitCard.aspx.cs" Inherits="RegistrationApp.DownloadAdmitCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">

   <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
   <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

   <!-- Custom fonts for this template -->
   <link href="css/all.min.css" rel="stylesheet" type="text/css">
   <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
       <%--FOR FONT-AWESOME--%>
   <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
   <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="container-fluid">
       <div class="row justify-content-center">
           <div class="col-xl-4 col-lg-6 col-md-6">
               <div class="card o-hidden border-0 shadow-sm my-1">
                    <div class="card-body p-0">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="card-heading bg-info text-white text-center">
                                    <h5 class="text-center py-1">Question Paper</h5>
                                </div>
                                <div class="p-1">
                                    <table class="table table-bordered table-striped text-left">
                                        <thead class="bg-info text-white">
                                            <tr>
                                                <th>Topic</th>
                                                <th>Download</th>
                                            </tr>
                                        </thead>
                                        <tbody">
                                            <tr runat="server" id="trAccountant" visible="false">
                                                <td class="bg-info text-white font-weight-bolder">Q.P. Accountant</td>
                                                <td class="bg-info text-white font-weight-bolder"><a class="nav-link text-white" href="\UPLOADEDFILES\QP\Accountant.pdf" target="_blank"><i class="fa fa-download" aria-hidden="true"> </i></a></td>
                                            </tr>

                                            <tr runat="server" id="trHardware" visible="false">
                                                <td class="bg-info text-white font-weight-bolder">Q.P. ITes Assistant-Hardware</td>
                                                <td class="bg-info text-white font-weight-bolder"><a class="nav-link text-white" href="\UPLOADEDFILES\QP\ITes-Assistant-Hardware.pdf" target="_blank"><i class="fa fa-download" aria-hidden="true"> </i></a></td>
                                            </tr>
                                            <tr runat="server" id="trMIS" visible="false">
                                                <td class="bg-info text-white font-weight-bolder">Q.P. ITeS Assistant-MIS</td>
                                                <td class="bg-info text-white font-weight-bolder"><a class="nav-link text-white" href="\UPLOADEDFILES\QP\ITeS-Assistant-MIS.pdf" target="_blank"><i class="fa fa-download" aria-hidden="true"> </i></a></td>
                                            </tr>

                                            <tr runat="server" id="trWeb" visible="false">
                                                <td class="bg-info text-white font-weight-bolder">Q.P. ITeS Assistant-Web Developer</td>
                                                <td class="bg-info text-white font-weight-bolder"><a class="nav-link text-white" href="\UPLOADEDFILES\QP\ITeS-Assistant-Web-Developer.pdf" target="_blank"><i class="fa fa-download" aria-hidden="true"> </i></a></td>
                                            </tr>
                                            <tr runat="server" id="trLibrary" visible="false">
                                                <td class="bg-info text-white font-weight-bolder">Q.P. Library-Assistant</td>
                                                <td class="bg-info text-white font-weight-bolder"><a class="nav-link text-white" href="\UPLOADEDFILES\QP\Library-Assistant.pdf" target="_blank"><i class="fa fa-download" aria-hidden="true"> </i></a></td>
                                            </tr>
                                            <tr runat="server" id="trCivil" visible="false">
                                                <td class="bg-info text-white font-weight-bolder">Q.P. Maintenance Engineer Civil</td>
                                                <td class="bg-info text-white font-weight-bolder"><a class="nav-link text-white" href="\UPLOADEDFILES\QP\Maintenance-Engineer-Civil.pdf" target="_blank"><i class="fa fa-download" aria-hidden="true"> </i></a></td>
                                            </tr>
                                            <tr runat="server" id="trElec" visible="false">
                                                <td class="bg-info text-white font-weight-bolder">Q.P. Maintenance-Engineer-Cum-Supervisor-Electrical</td>
                                                <td class="bg-info text-white font-weight-bolder"><a class="nav-link text-white" href="\UPLOADEDFILES\QP\Maintenance-Engineer-Cum-Supervisor-Electrical.pdf" target="_blank"><i class="fa fa-download" aria-hidden="true"> </i></a></td>
                                            </tr>
                                            <tr runat="server" id="trManager" visible="false">
                                                <td class="bg-info text-white font-weight-bolder">Q.P. Manager-Academic Program</td>
                                                <td class="bg-info text-white font-weight-bolder"><a class="nav-link text-white" href="\UPLOADEDFILES\QP\Manager-Academic-Program.pdf" target="_blank"><i class="fa fa-download" aria-hidden="true">  </i></a></td>
                                            </tr>
                                            <tr runat="server" id="trCEP" visible="false">
                                                <td class="bg-info text-white font-weight-bolder">Q.P. Programme (CEP)</td>
                                                <td class="bg-info text-white font-weight-bolder"><a class="nav-link text-white" href="\UPLOADEDFILES\QP\Programme-(CEP).pdf" target="_blank"><i class="fa fa-download" aria-hidden="true">  </i></a></td>
                                            </tr>
                                            <tr runat="server" id="trPGP" visible="false">
                                                <td class="bg-info text-white font-weight-bolder">Q.P. Programme (PGP)</td>
                                                <td class="bg-info text-white font-weight-bolder"><a class="nav-link text-white" href="\UPLOADEDFILES\QP\Programme-(PGP).pdf" target="_blank"><i class="fa fa-download" aria-hidden="true">  </i></a></td>
                                            </tr>
                                            <tr runat="server" id="trSecretary" visible="false">
                                                <td class="bg-info text-white font-weight-bolder">Q.P. Secretary</td>
                                                <td class="bg-info text-white font-weight-bolder"><a class="nav-link text-white" href="\UPLOADEDFILES\QP\Secretary.pdf" target="_blank"><i class="fa fa-download" aria-hidden="true">  </i></a></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


          <div class="col-xl-4 col-lg-6 col-md-6">
              <div class="card o-hidden border-0 shadow-sm my-1">
                   <div class="card-body p-0">
                       <div class="row">
                           <div class="col-lg-12">
                               <div class="card-heading bg-info text-white text-center">
                                   <h5 class="text-center py-1">Download your Clarification of Objection</h5>
                               </div>
                               <div class="text-center mt-5">
                                   <asp:Button ID="btnLogin" runat="server" class="btn btn-primary mb-5 mt-1" Text="Download Clarification of Objection" OnClick="btnLogin_Click"/>
                               </div>
                           </div>
                       </div>
                   </div>
               </div>
           </div>

        </div>

        <div class="row justify-content-center">
            <div class="col-md-12 mb-1 mt-1">
                <div class="card overflow-hidden">
                    
                    <div class="card-heading bg-info text-white text-center">
                        <%--<h5 class="card-title py-1 mb-0 ">Admit Card Generated, Download Now.</h5>--%>
                        <%--<h5 class="card-title py-1 mb-0 ">Clarification of Objections are ready to download.</h5>--%>
                        <h5 class="card-title py-1 mb-0 ">Applicant Response and Answer Key</h5>
                    </div>
                    <div class="d-flex flex-row flex-nowrap overflow-auto">
                        <div>
                            <h5>Applicant Response</h5>
                            <asp:Label ID="lblResponse" runat="server" Text=""></asp:Label>

                            <br />
                            <h5>Answer Key</h5>
                            <asp:Label ID="lblAns" runat="server" Text=""></asp:Label>
                        </div>
                   </div>


 <%--               <h5 class="text-center mt-5">Click the below Download button to download your Clarification of Objections<i class="fa fa-hand-o-down" style="font-size:36px"></i></h5>
                    <div class="card-body ml-3 mr-3 text-left">
                        <asp:Label ID="lblStatus" runat="server" ForeColor="Red" Text=""></asp:Label>
                        <div class="text-center">
                            <asp:Button ID="btnLogin" runat="server" class="btn btn-outline-primary mb-2 mt-5" Text="Download Clarification of Objection" OnClick="btnLogin_Click"/>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>
    </div>
    </form>
</asp:Content>
