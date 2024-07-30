<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkExperience.aspx.cs" Inherits="RegistrationApp.WorkExperience" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript" language="javascript">
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container col-lg-12">
        <div class="card o-hidden border-0 shadow-sms my-2">
            <div class="card-body p-0">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="p-2">
                            <form runat="server" AutoCompleteType="Disabled" autocomplete="off">
                                
                                <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

                                <div class="card-heading text-white bg-info">
                                    <h6 class="card-title py-1 mb-3 text-center">&nbsp;<i class="fa fa-history" aria-hidden="true"></i> Experience / Organisations / Institutions / Firms</h6>
                                </div>

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
 
 <%--                                <asp:Panel runat="server" id="pnlExp" Visible="false">
                                    <div class="alert alert-success alert-dismissible fade show" role="alert">
                                        <h5 class="blink"><asp:Label ID="lblExp" runat="server"  Font-Bold="true" ForeColor="Blue" Font-Size="Small" Text=""></asp:Label></h5>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                </asp:Panel>--%>

 
                                <div class="card-heading text-white bg-info">
                                    <h6 class="card-title py-1 mb-3 text-left">&nbsp;Details of Post Qualification Experience (in Chronological order starting from current employment) as on 01-01-2024</h6>
                                </div>
            
                               <asp:Panel runat="server" id="pnlSuccess" Visible="false">
                                    <div class="alert alert-success alert-dismissible fade show" role="alert">
                                        <h5 class="blink">Record(s) updated successfully!.</h5>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"">
                                        <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                </asp:Panel>

                                <div class="form-row">
                                    <div class="form-group col-md-2">
                                        <label for="inputEmail" class="form-label font-weight-bold">Designation / Name of the position / Name of the post</label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="inputEmail" class="form-label font-weight-bold">Name of Organisation / Establishment / Employer</label>
                                    </div>
                                    <div class="form-group col-md-1">
                                        <label for="inputEmail" class="form-label font-weight-bold">Central Govt. / State Govt. / Central PSU / State PSU / Private Org.</label>
                                    </div>
                                    <div class="form-group col-md-1">
                                        <label for="inputEmail" class="form-label font-weight-bold">On Contract / Ad-hoc / Permanent / Temporary / On-the-job training</label>
                                    </div>       

                                    <div class="form-group col-md-1">
                                        <label for="inputEmail" class="form-label font-weight-bold">From Date</label>
                                    </div>
                                    <div class="form-group col-md-1">
                                        <label for="inputEmail" class="form-label font-weight-bold">To Date </label>
                                    </div>
                                   <div class="form-group col-md-1">
                                       <label for="inputEmail" class="form-label font-weight-bold">Pay Scale</label>
                                   </div>
                                    <div class="form-group col-md-1">
                                        <label for="inputEmail" class="form-label font-weight-bold">Gross Pay</label>
                                    </div>
                                    <div class="form-group col-md-1">
                                        <label for="inputEmail" class="form-label font-weight-bold">Reason for Leaving</label>
                                    </div>
                              </div>

                                <div class="form-row">
                                    <div class="form-group col-md-2">
                                        <asp:TextBox ID="txtDesignation" class="form-control form-control-sm" style="font-size:smaller" MaxLength="99" autocomplete="off" placeholder="Designation / Name of the position / Name of the post" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:TextBox ID="txtOrg" class="form-control form-control-sm" style="font-size:smaller" MaxLength="99" autocomplete="off" placeholder="Name of Organisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-1">
                                        <asp:DropDownList ID="ddlPostType" class="form-control form-control-sm" style="font-size:smaller" runat="server">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Central Govt.</asp:ListItem>
                                            <asp:ListItem>State Govt.</asp:ListItem>
                                            <asp:ListItem>Central PSU</asp:ListItem>
                                            <asp:ListItem>State PSU</asp:ListItem>
                                            <asp:ListItem>Private Org.</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-1">
                                        <asp:DropDownList ID="ddlJobType" class="form-control form-control-sm" style="font-size:smaller" runat="server">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>On Contract</asp:ListItem>
                                            <asp:ListItem>Ad-hoc</asp:ListItem>
                                            <asp:ListItem>Permanent</asp:ListItem>
                                            <asp:ListItem>Temporary</asp:ListItem>
                                            <asp:ListItem>On-the-job training</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="form-group col-md-1">
                                        <asp:TextBox ID="txtBegin" class="form-control form-control-sm" style="font-size:smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender id="maskDOB" runat="server" TargetControlID="txtBegin" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    </div>
                                   <div class="form-group col-md-1">
                                        <asp:TextBox ID="txtEnd" class="form-control form-control-sm" style="font-size:smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                       <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender1" runat="server" TargetControlID="txtEnd" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender> 
                                    </div>

                                    <div class="form-group col-md-1">
                                        <asp:TextBox ID="txtPay" class="form-control form-control-sm" style="font-size:smaller" MaxLength="20" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                    </div>
                                   <div class="form-group col-md-1">
                                       <asp:TextBox ID="txtGross" class="form-control form-control-sm" style="font-size:smaller" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                   </div>

                                   <div class="form-group col-md-2">
                                       <asp:TextBox ID="txtReason" class="form-control form-control-sm" style="font-size:smaller" MaxLength="150" autocomplete="off" placeholder="Reason" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                   </div>
                                </div>

                                 <div class="form-row">
                                   <div class="form-group col-md-12 text-right">
                                       <asp:Button ID="btnAdd" runat="server" class="btn btn-sm btn-primary w-10" style="font-size:smaller" Text=" Add " OnClick="btnAdd_Click"/>
                                   </div>
                                </div>
                                <p style="color:blue">Note : You can add multiple work experiences by clicking on ADD button</p>

                                <div class="form-row">
                                    <asp:GridView ID="gvProducts" runat="server" Font-Size="Smaller" AutoGenerateColumns="false" CssClass="table table-striped table-bordered bootstrap-datatable datatable" ShowHeader="true" ShowFooter="true" OnRowCommand="gvProducts_RowCommand">
                                    <RowStyle HorizontalAlign="Left" />
                                    <Columns>
                                       <asp:TemplateField HeaderText="AppNo" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAppno" runat="server"  Text='<%#Eval("USERID")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Designation / Name of the position / Name of the post" HeaderStyle-Width="250px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPosition" runat="server" Text='<%#Eval("DESIGNATION")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Name of Organisation / Establishment / Employer" HeaderStyle-Width="380px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrg" runat="server"  Text='<%#Eval("ORGANISATION_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Central Govt. / State Govt. / Central PSU / State PSU / Private Org." HeaderStyle-Width="280px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrg" runat="server"  Text='<%#Eval("POST_TYPE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="On Contract / Ad-hoc / Permanent / Temporary / On-the-job training" HeaderStyle-Width="280px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrg" runat="server"  Text='<%#Eval("JOB_TYPE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="From Date" HeaderStyle-Width="99px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalary" runat="server"  Text='<%#Eval("JOIN_DATE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="To Date" HeaderStyle-Width="85px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJoinDate" runat="server" Text='<%#Eval("END_DATE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Pay Scale" HeaderStyle-Width="85px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEndDate" runat="server" Text='<%#Eval("PAY_SCALE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Gross Pay" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPeriod" runat="server" Text='<%#Eval("GROSS_PAY")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Reason for Leaving" HeaderStyle-Width="50px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDays" runat="server" Text='<%#Eval("LEAVING_REASON''")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton class="btn btn-sm btn-danger" ID="lnkDelete" CommandName="deleteItem"   OnClientClick="return confirm('Are you sure? want to delete selected record!');" runat="server">Delete</asp:LinkButton>
                                            </ItemTemplate> 
                                        </asp:TemplateField>
                                     </Columns>
                                </asp:GridView>
                                </div>

                                <hr />
                               <div class="card-heading text-white bg-info">
                                   <h6 class="card-title py-1 mb-3 text-left">&nbsp;Details of Apprenticeship Training</h6>
                               </div>

                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="inputEmail" class="form-label font-weight-bold">Name of the Apprenticeship training</label>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="inputEmail" class="form-label font-weight-bold">Institute / Organization</label>
                                    </div>

                                    <div class="form-group col-md-1">
                                        <label for="inputEmail" class="form-label font-weight-bold">From Date</label>
                                    </div>
                                    <div class="form-group col-md-1">
                                        <label for="inputEmail" class="form-label font-weight-bold">To Date </label>
                                    </div>
                              </div>

                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <asp:TextBox ID="txtProgram" class="form-control form-control-sm" style="font-size:smaller" MaxLength="199" autocomplete="off" placeholder="Name of Program" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <asp:TextBox ID="txtOrg1" class="form-control form-control-sm" style="font-size:smaller" MaxLength="50" autocomplete="off" placeholder="Institute / Organisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                    </div>
 
                                    <div class="form-group col-md-1">
                                        <asp:TextBox ID="txtDtBeg" class="form-control form-control-sm" style="font-size:smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                        <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender2" runat="server" TargetControlID="txtDtBeg" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    </div>
                                   <div class="form-group col-md-1">
                                        <asp:TextBox ID="txtDtEnd" class="form-control form-control-sm" style="font-size:smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                       <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender3" runat="server" TargetControlID="txtDtEnd" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender> 
                                    </div>
                                   <div class="form-group col-md-2">
                                       <asp:Button ID="btnAddRex" runat="server" class="btn btn-sm btn-primary" style="font-size:smaller" Text="   Add   " OnClick="btnAddRex_Click"/>
                                   </div>
                                </div>
                                <p style="color:blue">Note : You can add multiple work experiences by clicking on ADD button</p>

                                <div class="form-row">
                                    <asp:GridView ID="gvTraining" runat="server" Font-Size="Smaller" AutoGenerateColumns="false" CssClass="table table-striped table-bordered bootstrap-datatable datatable" ShowHeader="true" ShowFooter="true" OnRowCommand="gvTraining_RowCommand">
                                    <RowStyle HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Seq" Visible="false">
                                        <ItemTemplate>
                                                <asp:Label ID="lblSeq" runat="server"  Text='<%#Eval("SEQ")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                       <asp:TemplateField HeaderText="AppNo" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAppno" runat="server"  Text='<%#Eval("USERID")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Position" HeaderStyle-Width="250px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPosition" runat="server" Text='<%#Eval("PROGRAM_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Organisation Name" HeaderStyle-Width="380px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrg" runat="server"  Text='<%#Eval("ORGANISATION_NAME")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="Joining Date" HeaderStyle-Width="85px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJoinDate" runat="server" Text='<%#Eval("JOIN_DATE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="End Date" HeaderStyle-Width="85px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEndDate" runat="server" Text='<%#Eval("END_DATE")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

   <%--                                     <asp:TemplateField HeaderText="Job Period" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPeriod" runat="server" Text='<%#Eval("PERIOD")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Days" HeaderStyle-Width="50px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDays" runat="server" Text='<%#Eval("DAYS")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton class="btn btn-sm btn-danger" ID="lnkDelete" CommandName="deleteItem" CommandArgument='<%#Eval("SEQ") %>'  OnClientClick="return confirm('Are you sure? want to delete selected record!');" runat="server">Delete</asp:LinkButton>
                                            </ItemTemplate> 
                                        </asp:TemplateField>
                                     </Columns>
                                </asp:GridView>
                                </div>

                                 <asp:Panel runat="server" id="pnlStatus" Visible="false">
                                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                                        <h5 class="blink"><asp:Label ID="lblError" runat="server"  Font-Bold="true" ForeColor="Red" Font-Size="Small" Text=""></asp:Label></h5>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                </asp:Panel>

                                <hr />

                                 <div class="form-row">
 <%--                                   <div>
                                            <asp:CheckBox ID="chkVrs" class="form-control form-control-sm text-dark font-weight-bold text-dark" runat="server" Text="<b> &nbsp;&nbsp; Have you availed Voluntary Retirement (VRS) or benefits of a similar scheme from any of your previous employer?</b>"/>
                                        </div>--%>
                                    <div class="form-group col-md-9">
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Have you availed Voluntary Retirement (VRS) or benefits of a similar scheme from any of your previous employer?<font color="red">*</font></label>
                                        <asp:DropDownList ID="ddlVRS" class="form-control form-control-sm text-dark font-weight-bold text-dark" runat="server">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                 <div class="form-row">
                                    <div class="form-group col-md-5">
<%--                                        <div>
                                            <asp:CheckBox ID="chkInterview" class="form-control form-control-sm text-dark font-weight-bold text-dark" runat="server" Text="<b> &nbsp;&nbsp; Have you been interviewd by HAL any time earlier?</b>" AutoPostBack="true" OnCheckedChanged="chkInterview_CheckedChanged"/>
                                        </div>--%>
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Have you been interviewed by HAL any time earlier?<font color="red">*</font></label>
                                        <asp:DropDownList ID="ddlInterview" class="form-control form-control-sm text-dark font-weight-bold text-dark" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInterview_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                               <div class="form-row" runat="server" id="divInterview" visible="false">
                                   <div class="form-group col-md-5">
                                       <label for="inputDiscipline" class="form-label font-weight-bold">Post Interviewed <font color="red">*</font></label>
                                       <asp:TextBox ID="txtIntPost" class="form-control form-control-sm" style="font-size:smaller" MaxLength="99" autocomplete="off" placeholder="Post Interviewed" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                   </div>
                    
                                   <div class="form-group col-md-2">
                                       <label for="inputDiscipline" class="form-label font-weight-bold">Date of Interviewed <font color="red">*</font></label>
                                       <asp:TextBox ID="txtIntDate" class="form-control form-control-sm" style="font-size:smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                       <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender4" runat="server" TargetControlID="txtIntDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                   </div>
                                   <div class="form-group col-md-5">
                                       <label for="inputDiscipline" class="form-label font-weight-bold">Venue of Interviewed <font color="red">*</font></label>
                                       <asp:TextBox ID="txtIntVenue" class="form-control form-control-sm" style="font-size:smaller" MaxLength="150" autocomplete="off" placeholder="Venue of Interviewed" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                   </div>
                               </div>

                                 <div class="form-row">
                                    <div class="form-group col-md-6">
  <%--                                      <div>
                                            <asp:CheckBox ID="chkRelative" class="form-control form-control-sm text-dark font-weight-bold text-dark" runat="server" Text="<b> &nbsp;&nbsp; Are any of your close relatives working in HAL?</b>" AutoPostBack="true" OnCheckedChanged="chkRelative_CheckedChanged"/>
                                        </div>--%>
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Are any of your close relatives working in HAL?<font color="red">*</font></label>
                                        <asp:DropDownList ID="ddlRelative" class="form-control form-control-sm text-dark font-weight-bold text-dark" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRelative_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                               <div class="form-row" runat="server" id="divRelative" visible="false">
                                   <div class="form-group col-md-3">
                                       <label for="inputDiscipline" class="form-label font-weight-bold">Name<font color="red">*</font></label>
                                       <asp:TextBox ID="txtName" class="form-control form-control-sm" style="font-size:smaller" MaxLength="99" autocomplete="off" placeholder="Name" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                   </div>
                    
                                   <div class="form-group col-md-3">
                                       <label for="inputDiscipline" class="form-label font-weight-bold">Designation<font color="red">*</font></label>
                                       <asp:TextBox ID="txtDesig" class="form-control form-control-sm" style="font-size:smaller" autocomplete="off" runat="server" placeholder="Designation" MaxLength="99" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                   </div>
                                   <div class="form-group col-md-3">
                                       <label for="inputDiscipline" class="form-label font-weight-bold">Division<font color="red">*</font></label>
                                       <asp:TextBox ID="txtDiv" class="form-control form-control-sm" style="font-size:smaller" MaxLength="99" autocomplete="off" placeholder="Division" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                   </div>
                                    <div class="form-group col-md-3">
                                       <label for="inputDiscipline" class="form-label font-weight-bold">Any other Description<font color="red">*</font></label>
                                       <asp:TextBox ID="txtDesc" class="form-control form-control-sm" style="font-size:smaller" MaxLength="150" autocomplete="off" placeholder="Any other Description" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                   </div>
                               </div>

                                 <div class="form-row">
                                    <div class="form-group col-md-9">
 <%--                                       <div>
                                            <asp:CheckBox ID="chkPolitics" class="form-control form-control-sm text-dark font-weight-bold text-dark" runat="server" Text="<b> &nbsp;&nbsp; Have you ever been a member/worker of any polictical party/organisation or participated any political activities?</b>" AutoPostBack="true" OnCheckedChanged="chkPolitics_CheckedChanged"/>
                                        </div>--%>
                                        <label for="inputDiscipline" class="form-label font-weight-bold">Have you ever been a member/worker of any polictical party/organisation or participated any political activities?<font color="red">*</font></label>
                                        <asp:DropDownList ID="ddlPolitics" class="form-control form-control-sm text-dark font-weight-bold text-dark" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPolitics_SelectedIndexChanged">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                               <div class="form-row" runat="server" id="divPolitics" visible="false">
                                   <div class="form-group col-md-3">
                                       <label for="inputDiscipline" class="form-label font-weight-bold">Name of Political Party/Organisation<font color="red">*</font></label>
                                       <asp:TextBox ID="txtParty" class="form-control form-control-sm" style="font-size:smaller" MaxLength="150" autocomplete="off" placeholder="Name of Political Party/Organisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                   </div>
                    
                                   <div class="form-group col-md-3">
                                       <label for="inputDiscipline" class="form-label font-weight-bold">Particulars of Political Activity<font color="red">*</font></label>
                                       <asp:TextBox ID="txtParticular" class="form-control form-control-sm" style="font-size:smaller" placeholder="Particulars of Political Activity" autocomplete="off" runat="server" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                   </div>
                                   <div class="form-group col-md-1">
                                       <label for="inputDiscipline" class="form-label font-weight-bold">Period of Membership<font color="red">*</font></label>
                                       <asp:TextBox ID="txtPeriod1" class="form-control form-control-sm" style="font-size:smaller" MaxLength="12" autocomplete="off" placeholder="YYYY to YYYY" runat="server" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                   </div>
                                    <div class="form-group col-md-3">
                                       <label for="inputDiscipline" class="form-label font-weight-bold">Nature of Participation in Political Activity<font color="red">*</font></label>
                                       <asp:TextBox ID="txtNature" class="form-control form-control-sm" style="font-size:smaller" MaxLength="150" autocomplete="off" placeholder="Nature of Participation in Political Activity" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                   </div>
                                    <div class="form-group col-md-2">
                                       <label for="inputDiscipline" class="form-label font-weight-bold">Office, if any, held in Political Party<font color="red">*</font></label>
                                       <asp:TextBox ID="txtOffice" class="form-control form-control-sm" style="font-size:smaller" MaxLength="150" autocomplete="off" placeholder="Office, if any, held in Political Party" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                   </div>
                               </div>


                                 <div class="form-row">
                                    <div class="form-group col-md-12">
                                        <%--<label for="edu10n" class="text-dark font-weight-bold mb-2"><b>Declaration:</b></label>--%>
                                        <div>
                                            <asp:CheckBox ID="CheckBox1" class="form-control form-control-sm text-dark font-weight-bold text-dark" runat="server" Text="<b> &nbsp;&nbsp; I hereby declare that the above information is true to the best of my knowledge.</b>"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-row text-center">
                                    <asp:Label ID="lblStatus" runat="server" Font-Bold="true" Font-Size="Larger" ForeColor="Red" Text=""></asp:Label>
                                </div>

                                <div class="d-flex justify-content-between mb-2">
                                    <asp:Button ID="btnSave" runat="server" class="btn btn-outline-primary" Text=" Save and Next " OnClick="btnSave_Click"/>
                                    <asp:Button ID="btnPrev" runat="server" class="btn btn-outline-primary" Text=" Previous "  OnClick= "btnPrev_Click"/>
                                    <%--<asp:Button ID="btnNext" runat="server" class="btn btn-outline-primary" Text="  Next  " OnClick="btnNext_Click"/>--%>
                                </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>


                            </form>

                            <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
                            <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
                            <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
