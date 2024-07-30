<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="RegistrationApp.Dashboard" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>HAL - Dashboard</title>
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

<body style="background-color:#ECF0F1 ;">
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
<%--                    <li class="nav-item active">
                        <a class="nav-link" href="\img\Advertisement_DMI_Patna.pdf" target="_blank"><i class='fas fa-bullhorn'></i>Advertisement <span class="sr-only">(current)</span></a>
                   </li>--%>

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
    <div class="container-fluid bg-white">
        <div class="card o-hidden border-0 shadow-sms my-1">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <div class="col-lg-12 col-12">
                        <div class="p-1">
                            <div class="text-center">
                                <h1 class="h4 text-primary font-weight-bold text-uppercase"><u>DASHBOARD</u></h1>
                            </div>
                            <br />
                            <form runat="server">
                                <asp:Panel ID="pan" runat="server">
                                     <div class="form-row justify-content-center mt-2">
                                       <div class="form-group col-md-2">
                                            <label for="father" class="text-dark font-weight-bold">Total</label>
                                            <asp:TextBox ID="txtTotal" class="form-control"  style="font-size:large; text-align:center" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-2">
                                            <label for="father" class="text-dark font-weight-bold">Completed</label>
                                            <asp:TextBox ID="txtComplete"  class="form-control" style="font-size:large;text-align:center" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="form-group col-md-2">
                                            <label for="inputAadhar" class="text-dark font-weight-bold">Incomplete</label>
                                            <asp:TextBox ID="txtInComplete" class="form-control" style="font-size:large;text-align:center" runat="server"></asp:TextBox>
                                        </div>
 
                                        <div class="form-group col-md-2">
                                            <label for="father" class="text-dark font-weight-bold">Search Text</label>
                                            <asp:TextBox ID="txtSearch" class="form-control" style="font-size:large; text-align:center" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-2">
                                            <label for="father" class="text-dark font-weight-bold">Field Name</label>
                                            <asp:DropDownList ID="ddlFilter" class="form-control" runat="server">
                                                <asp:ListItem>Application No.</asp:ListItem>
                                                <asp:ListItem>Mobile No.</asp:ListItem>
                                                <asp:ListItem>EMail ID</asp:ListItem>
                                                <asp:ListItem>Aadhar No.</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <div class="form-group col-md-2">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-outline-info mt-3" OnClick="btnSearch_Click"/>
                                            <asp:Button ID="btnShow" runat="server" Text="Show All" class="btn btn-outline-primary mt-3" OnClick="btnShow_Click"/>
                                        </div>
    
                                    </div>


<%--                                     <div class="form-row justify-content-center mt-2">
                                        <div class="form-group col-md-3">
                                            <label for="father" class="text-dark font-weight-bold">Discipline Applied</label>
                                            <asp:DropDownList ID="ddlDiscipline" class="form-control" runat="server">
                                                <asp:ListItem>Select</asp:ListItem>
                                                <asp:ListItem>Engineer Gr-I (8)/Executive Gr-I (8)</asp:ListItem>
                                                <asp:ListItem>Engineer Gr-II (5)/Executive Gr-II (5)</asp:ListItem>
                                                <asp:ListItem>Engineer Gr-III (2)/Executive Gr-III (2)</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label for="father" class="text-dark font-weight-bold">Stream Name</label>
                                            <asp:DropDownList ID="ddlStream" class="form-control" runat="server">
                                                <asp:ListItem>Select</asp:ListItem>
                                                <asp:ListItem>Applied Instrumentation Control</asp:ListItem>
                                                <asp:ListItem>Chemical</asp:ListItem>
                                                <asp:ListItem>Chemical Technology</asp:ListItem>
                                                <asp:ListItem>Civil</asp:ListItem>
                                                <asp:ListItem>Electrical</asp:ListItem>
                                                <asp:ListItem>Electronics & Communication</asp:ListItem>
                                                <asp:ListItem>Electronics & Instrumentation</asp:ListItem>
                                                <asp:ListItem>Electronics & Telecommunication</asp:ListItem>
                                                <asp:ListItem>Electronics, Instrumentation & Control</asp:ListItem>
                                                <asp:ListItem>Engineering Degree (any discipline)</asp:ListItem>
                                                <asp:ListItem>Instrumentation & Control</asp:ListItem>
                                                <asp:ListItem>Mechanical</asp:ListItem>
                                                <asp:ListItem>Structural</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-md-4">
                                            <asp:Button ID="btnQuery" runat="server" Text="Search" class="btn btn-outline-info mt-3 " OnClick="btnQuery_Click"/><br />
                                            <asp:Label ID="lblRex" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>--%>
                                </asp:Panel>
                               
                                <div class="form-group" runat="server" id="Div1">
                                    <div class="card-body">
                                        <div class="table-responsive">
                                          <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                               <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered"  DataKeyNames="USERID" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="true" ShowFooter="true" AllowPaging="true" PageSize ="10" OnPageIndexChanging="GridView1_PageIndexChanging">
                                                    <pagersettings  mode="NumericFirstLast" FirstPageText = "First" LastPageText = "Last" position="Bottom" pagebuttoncount="4"/>
                                                    <pagerstyle  backcolor="LightGreen" Font-Bold="true" ForeColor="White" height="30px"  verticalalign="Bottom" horizontalalign="Center"/>

 <%--                                           <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered"  DataKeyNames="USERID" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="true">--%>
                                                <Columns>
                                                        <asp:TemplateField HeaderText="Applicantion No" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAppno" runat="server" Visible="false" Text='<%#Eval("USERID")%>'></asp:Label>
                                                                <asp:Label ID="lblAppno2" runat="server" Text='<%# String.Format(string.Concat(Eval("USERID"),"</br>",Eval("PASSWORD"),"</br>",Eval("APPLIED_DISCIPLINE") )) %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

<%--                                                        <asp:TemplateField HeaderText="State/Discipline Applied" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblState" runat="server" Text='<%#Eval("APPLIED_DISCIPLINE")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>

                                                        <asp:TemplateField HeaderText="Applicant Details" HeaderStyle-Width="400px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%# String.Format(string.Concat("Name : ",Eval("APPLICANT_NAME"),"</br>Gender :",Eval("GENDER"),"</br>DOB :",Eval("DOB1"),"</br>Mobile No :",Eval("MOBILE"),"</br>Email ID :",Eval("EMAIL"))) %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

<%--                                                        <asp:TemplateField HeaderText="Applicant Photo" HeaderStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <asp:Image ID="imgPhoto" runat="server" ImageUrl='<%# String.Format(string.Concat("UPLOADEDFILES/PHOTOGRAPH/",Eval("USERID"), ".jpg"))%>' Height="80px" Width="80px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>

                                                        <asp:TemplateField HeaderText="Pages Completed" HeaderStyle-Width="140px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPages" runat="server" Text='<%# String.Format(string.Concat("Personal Details : ",Eval("PERSONALINFO_PAGE").ToString() == "1" ? "Done" : "","</br>Education Details : ",Eval("EDUCATION_PAGE").ToString() == "1" ? "Done" : "","</br>Work Experience : ",Eval("EXPERIENCE_PAGE").ToString() == "1" ? "Done" : "","</br>Document Upload :",Eval("DOCUMENT_PAGE").ToString() == "1" ? "Done" : "")) %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="View Profile" HeaderStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnView" runat="server" Text="View" width="99px" class="btn btn-info btn-circle ml-5 mt-4" OnClick="btnView_Click"/>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate> 
                                            </asp:GridView>
                                            </table>


                                           <div>
                                                <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered" Visible="true" DataKeyNames="USERID" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="true">
                                                    <Columns>
                                                        <asp:BoundField DataField="USERID" HeaderText="USERID" />  
                                                        <asp:BoundField DataField="PASSWORD" HeaderText="PASSWORD" />  
                                                        <asp:BoundField DataField="APPLIED_DISCIPLINE" HeaderText="APPLIED DISCIPLINE" />  
                                                        <asp:BoundField DataField="APPLICANT_NAME" HeaderText="APPLICANT NAME" />  
                                                        <asp:BoundField DataField="GENDER" HeaderText="GENDER" />  
                                                        <asp:BoundField DataField="CATEGORY_APPLIED" HeaderText="CATEGORY_APPLIED" />  
                                                        <asp:BoundField DataField="CASTE_CERT_NO" HeaderText="CERTIFICATE_NO" />  
                                                        <asp:BoundField DataField="CASTE_CERT_ISSUE_DATE" HeaderText="ISSUE_DATE" />  
                                                         <asp:BoundField DataField="PWD_APPLIED" HeaderText="PwD_APPLICANT" />  
                                                        <asp:BoundField DataField="PWD_TYPE" HeaderText="PwD_TYPE" />  
                                                        <asp:BoundField DataField="PWD_PERCENT" HeaderText="PwD_PERCENT" />  
                                                        <asp:BoundField DataField="DOB1" HeaderText="DOB" />  
                                                        <asp:BoundField DataField="DOB_DD" HeaderText="DOB_DD" />  
                                                        <asp:BoundField DataField="DOB_MM" HeaderText="DOB_MM" />  
                                                        <asp:BoundField DataField="DOB_YYYY" HeaderText="DOB_YYYY" />  
                                                        <asp:BoundField DataField="APPLICANT_AGE" HeaderText="APPLICANT_AGE" />  
                                                        <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" />  
                                                        <asp:BoundField DataField="MOBILE" HeaderText="MOBILE" />  
                                                        <asp:BoundField DataField="AADHAR_NO" HeaderText="AADHAR NO" />  
                                                        <asp:BoundField DataField="MARITAL_STATUS" HeaderText="MARITAL_STATUS" />  
                                                        <asp:BoundField DataField="NATIONALITY" HeaderText="NATIONALITY" />  
                                                        <asp:BoundField DataField="FATHER_NAME" HeaderText="FATHER_NAME" />  
                                                        <asp:BoundField DataField="MOTHER_NAME" HeaderText="MOTHER_NAME" />  
                                                        <asp:BoundField DataField="HOUSE_NO_CA" HeaderText="HOUSE NO" />  
                                                        <asp:BoundField DataField="AREA_CA" HeaderText="AREA" />  
                                                        <asp:BoundField DataField="LANDMARK_CA" HeaderText="LANDMARK" />  
                                                        <asp:BoundField DataField="STATE_CA" HeaderText="STATE" />  
                                                        <asp:BoundField DataField="PIN_CA" HeaderText="PIN" />  
                                                        <asp:BoundField DataField="CITY_PA" HeaderText="CITY" />  
                                                        <asp:BoundField DataField="DISTRICT_CA" HeaderText="DISTRICT" />  
                                                        <asp:BoundField DataField="STATE_CA" HeaderText="STATE" />  
                                                        <asp:BoundField DataField="PIN_CA" HeaderText="PIN" />  
                                                        <asp:BoundField DataField="POST_OFFICE_CA" HeaderText="POST OFFICE" /> 
                                                        <asp:BoundField DataField="RAILWAY_STATION_CA" HeaderText="RAILWAY STATION" /> 

                                                       <asp:BoundField DataField="HOUSE_NO_PA" HeaderText="HOUSE NO" />  
                                                       <asp:BoundField DataField="AREA_PA" HeaderText="AREA" />  
                                                       <asp:BoundField DataField="LANDMARK_PA" HeaderText="LANDMARK" />  
                                                       <asp:BoundField DataField="STATE_PA" HeaderText="STATE" />  
                                                       <asp:BoundField DataField="PIN_PA" HeaderText="PIN" />  
                                                       <asp:BoundField DataField="CITY_PA" HeaderText="CITY" />  
                                                       <asp:BoundField DataField="DISTRICT_PA" HeaderText="DISTRICT" />  
                                                       <asp:BoundField DataField="STATE_PA" HeaderText="STATE" />  
                                                       <asp:BoundField DataField="PIN_PA" HeaderText="PIN" />  
                                                       <asp:BoundField DataField="POST_OFFICE_PA" HeaderText="POST OFFICE" /> 
                                                       <asp:BoundField DataField="RAILWAY_STATION_PA" HeaderText="RAILWAY STATION" /> 

                                                        <asp:BoundField DataField="BOARD_10TH" HeaderText="10TH_BOARD" />  
                                                        <asp:BoundField DataField="BOARD10_PASSING_DATE" HeaderText="DATE" />  
                                                        <asp:BoundField DataField="BOARD10_PERCENT" HeaderText="PERCENT" />  
                                                         
                                                        <asp:BoundField DataField="BOARD_12TH" HeaderText="12TH/DIPLOMA" /> 
                                                        <asp:BoundField DataField="BOARD12_STREAM" HeaderText="12TH_STREAM" />
                                                        <asp:BoundField DataField="BOARD12_PASSING_DATE" HeaderText="DATE" />  
                                                        <asp:BoundField DataField="BOARD12_PERCENT" HeaderText="PERCENT" />
                                                        
                                                        <asp:BoundField DataField="ITI_UNIV" HeaderText="ITI INST" />  
                                                        <asp:BoundField DataField="ITI_STREAM" HeaderText="STREAM" />  
                                                        <asp:BoundField DataField="ITI_PASSING_DATE" HeaderText="DATE" />  
                                                        <asp:BoundField DataField="ITI_PERCENT" HeaderText="PERCENT" />  

                                                        <asp:BoundField DataField="DIPLOMA_INST" HeaderText="DIPLOMA INST" />  
                                                        <asp:BoundField DataField="DIPLOMA_STREAM" HeaderText="STREAM" />  
                                                        <asp:BoundField DataField="DIPLOMA_PASSING_DATE" HeaderText="DATE" />  
                                                        <asp:BoundField DataField="DIPLOMA_PERCENT" HeaderText="PERCENT" />  

                                                        <asp:BoundField DataField="NAC_UNIV" HeaderText="NAC INST" />  
                                                        <asp:BoundField DataField="NAC_NCTVT" HeaderText="STREAM" />  
                                                        <asp:BoundField DataField="NAC_NCTVT_PASSING_DATE" HeaderText="DATE" />  
                                                        <asp:BoundField DataField="NAC_NCTVT_PERCENT" HeaderText="PERCENT" />  

                                                        <asp:BoundField DataField="ESM_COURSE" HeaderText="ESM COURSE" />  
                                                        <asp:BoundField DataField="ESM_CERT_NO" HeaderText="CERTIFICATE NO" /> 
                                                        <asp:BoundField DataField="ESM_PASSING_DATE" HeaderText="PASSING DATE" />

                                                        <asp:BoundField DataField="UPLOAD_PHOTO" HeaderText="PHOTO" />  
                                                        <asp:BoundField DataField="UPLOAD_SIGN" HeaderText="SIGN" /> 
                                                        <asp:BoundField DataField="UPLOAD_ADHAR" HeaderText="AADHAR" />
                                                                                                                 
                                                        <asp:BoundField DataField="PERSONALINFO_PAGE" HeaderText="PERSONAL INFO" />  
                                                        <asp:BoundField DataField="EDUCATION_PAGE" HeaderText="EDUCATION" />  
                                                        <asp:BoundField DataField="DOCUMENT_PAGE" HeaderText="FINAL_PAGE" />  
                                                        <asp:BoundField DataField="DATED" HeaderText="DATE/TIME" />  

                                                    </Columns>                                                
                                                </asp:GridView>
                                            </div>
                                            <br />
                                            <div class="row justify-content-center">
                                                <asp:Button ID="btnExport" runat="server" Text="Export to Excel" Visible="false" CssClass="btn btn-outline-primary w-25" OnClick="btnExport_Click"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--<div class="form-group" runat="server" id="ExportDiv">
                                    <Table>
                                        <tr>
                                            <td><asp:Literal ID="lblRex" runat="server"></asp:Literal></td>
                                            <td><asp:Literal ID="lblAppno" runat="server"></asp:Literal></td>
                                            <td><asp:Literal ID="lblState" runat="server"></asp:Literal></td>
                                            <td><asp:Literal ID="lblName" runat="server"></asp:Literal></td>
                                            <td><asp:Image ID="imgPhoto" runat="server" /></td>
                                            <img alt="" src="<img src="UPLOADEDFILES/PHOTOGRAPH/ER00001.jpg" /> 
                                        </tr>
                                    </Table>
                                </div>--%>

                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.13.2/jquery-ui.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>
</body>
</html>