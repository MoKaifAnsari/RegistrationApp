<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Education.aspx.cs" Inherits="RegistrationApp.Education" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode == 46) {
                var txt = document.getElementById(id).value;
                if (!(txt.indexOf(".") > -1)) {
                    return true;
                }
            }
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

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container col-lg-12">
        <div class="card o-hidden border-0 shadow-sms my-1">
            <div class="card-heading text-white bg-info">
                <h6 class="card-title py-1 mb-1 text-left">&emsp;<i class='fas fa-user-graduate'></i> &nbsp;Educational Qualification</h6>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-12">
                        <form runat="server" autocompletetype="Disabled" autocomplete="off">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                            <div class="form-row">
                                <div class="form-group col-md-2">
                                    <label for="inputEmail" class="form-label font-weight-bold">Name of Qualification with specialisation wherever applicable<font color="red">*</font></label>
                                </div>
                                <div class="form-group col-md-3">
                                    <label for="inputEmail" class="form-label font-weight-bold">Institution / University<font color="red">*</font></label>
                                </div>
                                <div class="form-group col-md-1">
                                    <label for="inputEmail" class="form-label font-weight-bold">Nature of the Course<font color="red">*</font></label>
                                </div>
                                <div class="form-group col-md-1">
                                    <label for="inputEmail" class="form-label font-weight-bold">Duration of the Course<font color="red">*</font></label>
                                </div>
                                <div class="form-group col-md-2">
                                    <label for="inputEmail" class="form-label font-weight-bold">Subjects / Specialisation<font color="red">*</font></label>
                                </div>
                                <%-- <div class="form-group col-md-1">
                                    <label for="inputEmail" class="form-label font-weight-bold">Class / Division<font color="red">*</font></label>
                                </div>--%>
                                <div class="form-group col-md-1">
                                    <label for="inputEmail" class="form-label font-weight-bold">% of Marks<font color="red">*</font></label>
                                </div>
                                <div class="form-group col-md-2">
                                    <label for="inputEmail" class="form-label font-weight-bold">Date of Passing<font color="red">*</font></label>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-2 font-weight-bold">
                                    <h6><b>10th / Matriculation</b><font color="red">*</font></h6>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtEdu10" class="form-control form-control-sm" autocomplete="off" MaxLength="99" placeholder="Institution/University" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                    <asp:Label ID="lblEdu10" runat="server" ForeColor="Red" Visible="false" Text="Institution/University Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:DropDownList ID="ddlNature10" class="form-control form-control-sm" runat="server">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>Full Time</asp:ListItem>
                                        <asp:ListItem>Part Time</asp:ListItem>
                                        <asp:ListItem>Correspondence</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblNature10" runat="server" ForeColor="Red" Visible="false" Text="Nature of Course Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtDuration10" class="form-control form-control-sm" autocomplete="off" MaxLength="99" placeholder="Duration of Course" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblDuraion10" runat="server" ForeColor="Red" Visible="false" Text="Duration of Course Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtSub10" class="form-control form-control-sm" autocomplete="off" MaxLength="250" placeholder="Subjects/Specialisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblSub10" runat="server" ForeColor="Red" Visible="false" Text="Subjects of Course Required"></asp:Label>
                                </div>

                                <%--<div class="form-group col-md-1">
                                    <asp:TextBox ID="txtDiv10" class="form-control form-control-sm" autocomplete="off" MaxLength="20" placeholder="Class/Division" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblDiv10" runat="server" ForeColor="Red" Visible="false" Text="Duration of Course Required"></asp:Label>
                                </div>--%>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtPercent10" class="form-control form-control-sm" autocomplete="off" runat="server" placeholder="99.99" MaxLength="5" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtPercent10" Mask="99.99" MaskType="Number" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblPercent10" runat="server" ForeColor="Red" Visible="false" Text="% Marks Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtPassDate10" class="form-control form-control-sm" ValidationGroup="regn" autocomplete="off" runat="server" placeholder="DD/MM/YYYY" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="8"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="maskPass" runat="server" TargetControlID="txtPassDate10" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblYear10" runat="server" ForeColor="Red" Visible="false" Text="Month & year of passing Required"></asp:Label>
                                </div>
                            </div>


                            <div class="form-row">
                                <div class="form-group col-md-2 font-weight-bold" id="div12NonStar" runat="server">
                                    <h6><b>12th / Intermediate</b></h6>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtEdu12" class="form-control form-control-sm" MaxLength="99" autocomplete="off" placeholder="Institution/University" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblEdu12" runat="server" ForeColor="Red" Visible="false" Text="Institution/University Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:DropDownList ID="ddlNature12" class="form-control form-control-sm" runat="server">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>Full Time</asp:ListItem>
                                        <asp:ListItem>Part Time</asp:ListItem>
                                        <asp:ListItem>Correspondence</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblNature12" runat="server" ForeColor="Red" Visible="false" Text="Nature of Course Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtDuration12" class="form-control form-control-sm" autocomplete="off" MaxLength="99" placeholder="Duration of Course" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblDuration12" runat="server" ForeColor="Red" Visible="false" Text="Duration of Course Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtSub12" class="form-control form-control-sm" autocomplete="off" MaxLength="250" placeholder="Subjects/Specialisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblSub12" runat="server" ForeColor="Red" Visible="false" Text="Subjects of Course Required"></asp:Label>
                                </div>

                                <%-- <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtDiv12" class="form-control form-control-sm" autocomplete="off" MaxLength="20" placeholder="Class/Division" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblDiv12" runat="server" ForeColor="Red" Visible="false" Text="Duration of Course Required"></asp:Label>
                                </div>--%>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtPercent12" class="form-control form-control-sm" autocomplete="off" runat="server" placeholder="99.99" MaxLength="5" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtPercent12" Mask="99.99" MaskType="Number" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblPercent12" runat="server" ForeColor="Red" Visible="false" Text="% of Marks Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtPassDate12" class="form-control form-control-sm" ValidationGroup="regn" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="8" placeholder="DD/MM/YYYY"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPassDate12" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblYear12" runat="server" ForeColor="Red" Visible="false" Text="Month & year of passing Required"></asp:Label>
                                </div>
                            </div>
                            <div class="card-heading text-white bg-info">
                                <h6 class="card-title py-1 mb-3 text-left">&nbsp;Essential Qualification</h6>
                            </div>
                            <div class="form-row" runat="server" id="divITI" visible="false">
                                <asp:Label ID="lblITI1" class="form-group col-md-2 font-weight-bold" runat="server" Visible="true" Text=""><h6><b>ITI</b></h6></asp:Label>
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtITI" class="form-control form-control-sm" MaxLength="99" autocomplete="off" placeholder="Institution/University" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblITI" runat="server" ForeColor="Red" Visible="false" Text="Institution/University Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:DropDownList ID="ddlNatureITI" class="form-control form-control-sm" runat="server">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>Full Time</asp:ListItem>
                                        <asp:ListItem>Part Time</asp:ListItem>
                                        <asp:ListItem>Correspondence</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblNatureITI" runat="server" ForeColor="Red" Visible="false" Text="Nature of Course Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtDurationITI" class="form-control form-control-sm" autocomplete="off" MaxLength="99" placeholder="Duration of Course" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblDurationITI" runat="server" ForeColor="Red" Visible="false" Text="Duration of Course Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtSubITI" class="form-control form-control-sm" autocomplete="off" MaxLength="250" placeholder="Subjects/Specialisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblSubITI" runat="server" ForeColor="Red" Visible="false" Text="Duration of Course Required"></asp:Label>
                                </div>

                                <%--<div class="form-group col-md-1">
                                    <asp:TextBox ID="txtDivITI" class="form-control form-control-sm" autocomplete="off" MaxLength="20" placeholder="Class/Division" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblDivITI" runat="server" ForeColor="Red" Visible="false" Text="Duration of Course Required"></asp:Label>
                                </div>--%>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtITIPercent" class="form-control form-control-sm" autocomplete="off" runat="server" placeholder="99.99" MaxLength="5" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtITIPercent" Mask="99.99" MaskType="Number" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblITIPercent" runat="server" ForeColor="Red" Visible="false" Text="% Marks of Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtITIDate" class="form-control form-control-sm" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="8" placeholder="DD/MM/YYYY"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtITIDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblITIDate" runat="server" ForeColor="Red" Visible="false" Text="Month & year of of Passing Required"></asp:Label>
                                </div>

                            </div>


                            <div class="form-row" runat="server" id="divDiploma" visible="false">
                                <asp:Label ID="Label8" class="form-group col-md-2 font-weight-bold" runat="server" Visible="true" Text=""><h6><b>Diploma</b><font color="red">*</font></h6></asp:Label>
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtDip" class="form-control form-control-sm" MaxLength="99" autocomplete="off" placeholder="Institution/University" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblDip" runat="server" ForeColor="Red" Visible="false" Text="Institution/University Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:DropDownList ID="ddlNatureDip" class="form-control form-control-sm" runat="server">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>Full Time</asp:ListItem>
                                        <asp:ListItem>Part Time</asp:ListItem>
                                        <asp:ListItem>Correspondence</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblNatureDip" runat="server" ForeColor="Red" Visible="false" Text="Nature of Course Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtDurationDip" class="form-control form-control-sm" autocomplete="off" MaxLength="99" placeholder="Duration of Course" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblDurationDip" runat="server" ForeColor="Red" Visible="false" Text="Duration of Course Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtSubDip" class="form-control form-control-sm" autocomplete="off" MaxLength="250" placeholder="Subjects/Specialisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblSubDip" runat="server" ForeColor="Red" Visible="false" Text="Duration of Course Required"></asp:Label>
                                </div>

                                <%-- <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtDivDip" class="form-control form-control-sm" autocomplete="off" MaxLength="20" placeholder="Class/Division" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblDivDip" runat="server" ForeColor="Red" Visible="false" Text="Duration of Course Required"></asp:Label>
                                </div>--%>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtDipPer" class="form-control form-control-sm" autocomplete="off" runat="server" placeholder="99.99" MaxLength="5" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txtDipPer" Mask="99.99" MaskType="Number" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblDipPer" runat="server" ForeColor="Red" Visible="false" Text="% of Marks Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtDipDate" class="form-control form-control-sm" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="8" placeholder="DD/MM/YYYY"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txtDipDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblDipDate" runat="server" ForeColor="Red" Visible="false" Text="Month & year of of Passing Required"></asp:Label>
                                </div>
                            </div>


                            <div class="form-row" id="divNAC" runat="server" visible="false">
                                <div class="form-group col-md-2 font-weight-bold">
                                    <h6><b>NAC</b><font color="red">*</font></h6>
                                </div>
                                <div class="form-group col-md-7">
                                    <asp:TextBox ID="txtNacUniv" class="form-control form-control-sm" ValidationGroup="regn" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="150" placeholder="NAC University / Institute Name" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblNac" runat="server" ForeColor="Red" Visible="false" Text="NAC Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtNacPer" class="form-control form-control-sm" autocomplete="off" runat="server" placeholder="99.99" MaxLength="5" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender11" runat="server" TargetControlID="txtNacPer" Mask="99.99" MaskType="Number" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblNacPer" runat="server" ForeColor="Red" Visible="false" Text="% Marks Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtNacDate" class="form-control form-control-sm" ValidationGroup="regn" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="8" placeholder="DD/MM/YYYY"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txtNacDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblNacDate" runat="server" ForeColor="Red" Visible="false" Text="Passing Date Required"></asp:Label>
                                </div>
                            </div>

                            <div class="form-row" id="divESM" runat="server" visible="false">
                                <asp:Label ID="lblESM" class="form-group col-md-2 font-weight-bold mt-1" runat="server" Font-Bold="true" Text="Airforce Trade Certificate"></asp:Label>
                                <div class="form-group col-md-7">
                                    <asp:TextBox ID="txtESMCert" class="form-control form-control-sm" ValidationGroup="regn" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="30" placeholder="Airforce Trade Certificate No." onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:Label ID="lblESM2" runat="server" ForeColor="Red" Visible="false" Text="Airforce Certificate Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtESMDate" class="form-control form-control-sm" ValidationGroup="regn" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="10" placeholder="DD/MM/YYYY"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender12" runat="server" TargetControlID="txtESMDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblESMDate" runat="server" ForeColor="Red" Visible="false" Text="Passing Date Required"></asp:Label>
                                </div>
                                <div>
                                    <b>
                                        <asp:Label ID="LBLESM34" runat="server" ForeColor="Red" Visible="true" Text="Equivalent to Diploma"></asp:Label></b>
                                </div>
                            </div>


                            <%--                            <div class="form-row" runat="server" id="divFire" visible="false">
                                <asp:Label ID="Label8" class="form-group col-md-2 font-weight-bold" runat="server" Visible="true" Text=""><h6><b>Fire Fighting</b><font color="red">*</font></h6></asp:Label>
                                    <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtFireCourse" class="form-control form-control-sm" MaxLength="99" autocomplete="off" placeholder="Name of Course" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                    <asp:Label ID="lblFireCourse" runat="server" ForeColor="Red" Visible="false" Text="Course Name Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-5">
                                    <asp:TextBox ID="txtFireInst" class="form-control form-control-sm" MaxLength="99" autocomplete="off" placeholder="Name of the University/Institute" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                    <asp:Label ID="lblFireInst" runat="server" ForeColor="Red" Visible="false" Text="Name of the University/Institute Required"></asp:Label>
                                </div>
                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtFirePass" class="form-control form-control-sm" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="10" placeholder="DD/MM/YYYY"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender7" runat="server" TargetControlID="txtFirePass" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblFirePass" runat="server" ForeColor="Red" Visible="false" Text="Date of Passing Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtFirePer" class="form-control form-control-sm" autocomplete="off" runat="server" placeholder="99.99"  MaxLength="5" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender id="MaskedEditExtender9" runat="server" TargetControlID="txtFirePer" Mask="99.99" MaskType="Number" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblFirePer" runat="server" ForeColor="Red" Visible="false" Text="% Marks Required"></asp:Label>
                                </div>
                            </div>--%>

                            <hr />

                            <div class="form-row" runat="server" id="divRank2" visible="false">
                                <asp:Label ID="Label7" class="form-group col-md-2 font-weight-bold" runat="server" Visible="true" Text=""><h6><b>Combatant Experiences</b></h6></asp:Label>
                                <asp:Label ID="Label2" class="form-group col-md-3 font-weight-bold" runat="server" Visible="true" Text=""><h6><b>Rank Held</b></h6></asp:Label>
                                <asp:Label ID="Label3" class="form-group col-md-2 font-weight-bold" runat="server" Visible="true" Text=""><h6><b>Joining Date</b></h6></asp:Label>
                                <asp:Label ID="Label4" class="form-group col-md-2 font-weight-bold" runat="server" Visible="true" Text=""><h6><b>Leaving Date</b></h6></asp:Label>
                                <asp:Label ID="Label6" class="form-group col-md-3 font-weight-bold" runat="server" Visible="true" Text=""><h6><b>Duration</b></h6></asp:Label>
                            </div>

                            <div class="form-row" runat="server" id="divRank" visible="false">
                                <asp:Label ID="Label1" class="form-group col-md-2 font-weight-bold" runat="server" Visible="true" Text=""><h6><b>( minimum 3-years )</b></h6></asp:Label>
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtRank" class="form-control form-control-sm" MaxLength="99" autocomplete="off" placeholder="Rank Held" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                    <asp:Label ID="lblRank" runat="server" ForeColor="Red" Visible="false" Text="Rank Held Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtFrom" class="form-control form-control-sm" MaxLength="10" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" AutoPostBack="true" OnTextChanged="txtFrom_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txtFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblFrom" runat="server" ForeColor="Red" Visible="false" Text="Join Date Required"></asp:Label>
                                </div>
                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtUpto" class="form-control form-control-sm" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" MaxLength="10" AutoPostBack="true" OnTextChanged="txtUpto_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtUpto" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                    <asp:Label ID="lblUpto" runat="server" ForeColor="Red" Visible="false" Text="Leaving Date Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtPeriod" class="form-control form-control-sm" ReadOnly="true" runat="server" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                    <asp:Label ID="lblPeriod" runat="server" ForeColor="Red" Visible="false" Text="Period of Service Required"></asp:Label>
                                </div>
                            </div>
                            <%--//Start Work Experience --%>
                            <div class="card-heading text-white bg-info">
                                <h6 class="card-title py-1 mb-3 text-left">&nbsp;Details of Post Qualification Experience (in Chronological order starting from first employment) as on 01-05-2024</h6>
                            </div>
                            <div class="form-row" runat="server" id="divExp" visible="true">
                                <div class="form-group col-md-3">
                                    <label for="inputEmail" class="form-label font-weight-bold">Name of Organisation</label>
                                </div>
                                <div class="form-group col-md-3">
                                    <label for="inputEmail" class="form-label font-weight-bold">Position Held</label>
                                </div>
                                <div class="form-group col-md-1">
                                    <label for="inputEmail" class="form-label font-weight-bold">Salary(P.M)</label>
                                </div>

                                <div class="form-group col-md-1">
                                    <label for="inputEmail" class="form-label font-weight-bold">Joining Date</label>
                                </div>
                                <div class="form-group col-md-1">
                                    <label for="inputEmail" class="form-label font-weight-bold">Leaving Date </label>
                                </div>
                                <div class="form-group col-md-2">
                                    <label for="inputEmail" class="form-label font-weight-bold">Job Duration </label>
                                </div>
                            </div>

                            <div class="form-row" runat="server" id="divExp1" visible="true">
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtOrg1" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="99" autocomplete="off" placeholder="Name of the Organisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtPosition1" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="50" autocomplete="off" placeholder="Position Held" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtPay1" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="6" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtBegin1" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)" AutoPostBack="true" OnTextChanged="txtBegin_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="maskDOB" runat="server" TargetControlID="txtBegin1" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtEnd1" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)" AutoPostBack="true" OnTextChanged="txtEnd_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txtEnd1" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="TextBox1" class="form-control form-control-sm" Style="font-size: smaller" ReadOnly="true" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                    <asp:TextBox ID="txtDays1" class="form-control form-control-sm" Visible="false" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>

                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-9">
                                    <asp:TextBox ID="txtDescs1" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="399" autocomplete="off" placeholder="Desribe Job Responsibility" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:Button ID="btnAdd1" runat="server" class="btn btn-sm btn-primary" Style="font-size: smaller; font: bold;" Text=" Add Experiemce " OnClick="btnAdd_ClickEXP" />
                                </div>
                            </div>

                            <div class="form-row" runat="server" id="divExp2" visible="false">
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtOrg2" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="99" autocomplete="off" placeholder="Name of the Organisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtPosition2" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="50" autocomplete="off" placeholder="Position Held" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtPay2" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="6" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtBegin2" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)" AutoPostBack="true" OnTextChanged="txtBegin_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="maskDOB2" runat="server" TargetControlID="txtBegin2" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtEnd2" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)" AutoPostBack="true" OnTextChanged="txtEnd_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender14" runat="server" TargetControlID="txtEnd2" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtPeriod2" class="form-control form-control-sm" Style="font-size: smaller" ReadOnly="true" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                    <asp:TextBox ID="txtDays2" class="form-control form-control-sm" Visible="false" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>

                            </div>

                            <div class="form-row" runat="server" id="divDesc2" visible="false">
                                <div class="form-group col-md-9">
                                    <asp:TextBox ID="txtDesc2" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="399" autocomplete="off" placeholder="Desribe Job Responsibility" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:Button ID="btnAdd2" runat="server" class="btn btn-sm btn-primary" Style="font-size: smaller" Text=" Add Experiemce  " OnClick="btnAdd_ClickEXP" />
                                </div>
                            </div>

                            <div class="form-row" runat="server" id="divExp3" visible="false">
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtOrg3" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="99" autocomplete="off" placeholder="Name of the Organisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtPosition3" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="50" autocomplete="off" placeholder="Position Held" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtPay3" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="6" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtBegin3" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)" AutoPostBack="true" OnTextChanged="txtBegin_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender15" runat="server" TargetControlID="txtBegin3" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtEnd3" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)" AutoPostBack="true" OnTextChanged="txtEnd_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender17" runat="server" TargetControlID="txtEnd3" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtPeriod3" class="form-control form-control-sm" Style="font-size: smaller" ReadOnly="true" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                    <asp:TextBox ID="txtDays3" class="form-control form-control-sm" Visible="false" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>

                            </div>

                            <div class="form-row" runat="server" id="divDesc3" visible="false">
                                <div class="form-group col-md-9">
                                    <asp:TextBox ID="txtDesc3" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="399" autocomplete="off" placeholder="Desribe Job Responsibility" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:Button ID="btnAdd3" runat="server" class="btn btn-sm btn-primary" Style="font-size: smaller" Text=" Add Experiemce  " OnClick="btnAdd_ClickEXP" />
                                </div>
                            </div>

                            <div class="form-row" runat="server" id="divExp4" visible="false">
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtOrg4" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="99" autocomplete="off" placeholder="Name of the Organisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtPosition4" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="50" autocomplete="off" placeholder="Position Held" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtPay4" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="6" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtBegin4" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)" AutoPostBack="true" OnTextChanged="txtBegin_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender18" runat="server" TargetControlID="txtBegin4" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtEnd4" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)" AutoPostBack="true" OnTextChanged="txtEnd_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender19" runat="server" TargetControlID="txtEnd4" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtPeriod4" class="form-control form-control-sm" Style="font-size: smaller" ReadOnly="true" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                    <asp:TextBox ID="txtDays4" class="form-control form-control-sm" Visible="false" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="form-row" runat="server" id="divDesc4" visible="false">
                                <div class="form-group col-md-9">
                                    <asp:TextBox ID="txtDesc4" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="399" autocomplete="off" placeholder="Desribe Job Responsibility" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:Button ID="btnAdd4" runat="server" class="btn btn-sm btn-primary" Style="font-size: smaller" Text=" Add Experiemce  " OnClick="btnAdd_ClickEXP" />
                                </div>
                            </div>

                            <div class="form-row" runat="server" id="divExp5" visible="false">
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtOrg5" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="99" autocomplete="off" placeholder="Name of the Organisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtPosition5" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="50" autocomplete="off" placeholder="Position Held" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtPay5" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="6" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtBegin5" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)" AutoPostBack="true" OnTextChanged="txtBegin_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender20" runat="server" TargetControlID="txtBegin5" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtEnd5" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)" AutoPostBack="true" OnTextChanged="txtEnd_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender21" runat="server" TargetControlID="txtEnd5" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>

                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtPeriod5" class="form-control form-control-sm" Style="font-size: smaller" ReadOnly="true" autocomplete="off" runat="server" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                    <asp:TextBox ID="txtDays5" class="form-control form-control-sm" Visible="false" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>

                            </div>

                            <div class="form-row" runat="server" id="divDesc5" visible="false">
                                <div class="form-group col-md-9">
                                    <asp:TextBox ID="txtDesc5" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="399" autocomplete="off" placeholder="Desribe Job Responsibility" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:Button ID="btnAdd5" runat="server" class="btn btn-sm btn-primary" Style="font-size: smaller" Text=" New Entry " OnClick="btnAdd_ClickEXP" />
                                </div>
                            </div>

                            <div class="form-row" runat="server">
                                <div class="form-group col-md-9"></div>
                                <div class="form-group col-md-2">
                                    <asp:TextBox ID="txtTotPeriod" class="form-control form-control-sm" Style="font-size: smaller" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-3">
                                    <asp:Label ID="lblOrg" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Organisation Name Required"></asp:Label>
                                </div>
                                <div class="form-group col-md-3">
                                    <asp:Label ID="lblPosition" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Position Held Required"></asp:Label>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:Label ID="lblPay" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Salary(P.M) Required"></asp:Label>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:Label ID="lblBegin" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Joining Date Required"></asp:Label>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:Label ID="lblEnd" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Leaving Date Required"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-3">
                                    <asp:Label ID="lblDescs" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Job Description Required"></asp:Label>
                                </div>
                            </div>

                            <p style="color: blue">Note : You can add multiple work experiences by clicking on New Entry button</p>

                            <div class="form-row" runat="server" id="divTraining" visible="false">
                                <div class="card-heading text-white bg-info col-md-12">
                                    <h6 class="card-title py-1 mb-0 text-left">&nbsp;Details of Apprenticeship </h6>
                                </div>
                                <div class="form-group col-md-4 mt-2">
                                    <label for="inputEmail" class="form-label font-weight-bold">Name of Program</label>
                                </div>
                                <div class="form-group col-md-4 mt-2">
                                    <label for="inputEmail" class="form-label font-weight-bold">Institute/Organisation</label>
                                </div>
                                <div class="form-group col-md-1 mt-2">
                                    <label for="inputEmail" class="form-label font-weight-bold">Joining Date</label>
                                </div>
                                <div class="form-group col-md-1 mt-2">
                                    <label for="inputEmail" class="form-label font-weight-bold">Leaving Date </label>
                                </div>
                            </div>

                            <div class="form-row" runat="server" id="divTraining1" visible="false">
                                <div class="form-group col-md-4">
                                    <asp:TextBox ID="txtProgram1" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="199" autocomplete="off" placeholder="Name of Program" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-4">
                                    <asp:TextBox ID="txtOrgName1" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="50" autocomplete="off" placeholder="Institute / Organisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtBegDate1" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender22" runat="server" TargetControlID="txtBegDate1" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtEndDate1" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender23" runat="server" TargetControlID="txtEndDate1" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>
                            </div>
                            <%--<div class="form-group col-md-2">
                                    <asp:Button ID="btnAddRex1" runat="server" class="btn btn-sm btn-primary" Style="font-size: smaller" Text=" New Entry " Visible="false" OnClick="btnAddRex_ClickTrain" />
                                </div>
                            

                           <div class="form-row" runat="server" id="divTraining2" visible="false">
                                <div class="form-group col-md-4">
                                    <asp:TextBox ID="txtProgram2" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="199" autocomplete="off" placeholder="Name of Program" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-4">
                                    <asp:TextBox ID="txtOrgName2" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="50" autocomplete="off" placeholder="Institute / Organisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                </div>

                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtBegDate2" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender24" runat="server" TargetControlID="txtBegDate2" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:TextBox ID="txtEndDate2" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender25" runat="server" TargetControlID="txtEndDate2" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                </div>
                                <div class="form-group col-md-2">
                                    <asp:Button ID="btnAddRex2" runat="server" class="btn btn-sm btn-primary" Style="font-size: smaller" Text=" New Entry " OnClick="btnAddRex_ClickTrain" />
                                </div>
                            </div>--%>

                            <div class="form-row">
                                <div class="form-group col-md-4">
                                    <asp:Label ID="lblProgram" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Program Name Required"></asp:Label>
                                </div>
                                <div class="form-group col-md-4">
                                    <asp:Label ID="lblOrgName" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Institute/Organisation Required"></asp:Label>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:Label ID="lblBegDate" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Joining Date Required"></asp:Label>
                                </div>
                                <div class="form-group col-md-1">
                                    <asp:Label ID="lblEndDate" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Leaving Date Required"></asp:Label>
                                </div>
                            </div>

                            <hr />

                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <div class="card-heading text-white bg-info">
                                        <h6 class="card-title py-1 mb-3 text-left">&nbsp; Have you availed Voluntary Retirement (VRS) or benefits of a similar scheme from any of your previous employer?</h6>
                                    </div>
                                </div>
                                <div class="form-group col-md-1">
                                    <label for="inputDiscipline" class="form-label font-weight-bold">Yes/No<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlVRS" class="form-control form-control-sm text-dark font-weight-bold text-dark" runat="server">
                                        <asp:ListItem disabled Selected>Select</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblVRS" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Selection Required"></asp:Label>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <div class="card-heading text-white bg-info">
                                        <h6 class="card-title py-1 mb-3 text-left">&nbsp; Have you been interviewd by HAL any time earlier?</h6>
                                    </div>
                                </div>

                                <div class="form-group col-md-1 mt-0">
                                    <label for="inputDiscipline" class="form-label font-weight-bold">Yes/No<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlInterview" class="form-control form-control-sm text-dark font-weight-bold text-dark" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInterview_SelectedIndexChanged">
                                        <asp:ListItem disabled Selected>Select</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblIntr" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Selection Required"></asp:Label>
                                </div>
                                <div class="form-check col-md-11">
                                    <div class="form-row" runat="server" id="divInterview" visible="false">
                                        <div class="form-group col-md-5">
                                            <label for="inputDiscipline" class="form-label font-weight-bold">Post Interviewed <font color="red">*</font></label>
                                            <asp:TextBox ID="txtIntPost" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="99" autocomplete="off" placeholder="Post Interviewed" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                            <asp:Label ID="lblInstPost" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Post of Interviewed Required"></asp:Label>
                                        </div>

                                        <div class="form-group col-md-2">
                                            <label for="inputDiscipline" class="form-label font-weight-bold">Date of Interview <font color="red">*</font></label>
                                            <asp:TextBox ID="txtIntDate" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress="return isNumber(event)"></asp:TextBox>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender16" runat="server" TargetControlID="txtIntDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None"></ajaxToolkit:MaskedEditExtender>
                                            <asp:Label ID="lblIntDate" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Date of Interview Required"></asp:Label>
                                        </div>
                                        <div class="form-group col-md-5">
                                            <label for="inputDiscipline" class="form-label font-weight-bold">Venue of Interview <font color="red">*</font></label>
                                            <asp:TextBox ID="txtIntVenue" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="150" autocomplete="off" placeholder="Venue of Interviewed" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                            <asp:Label ID="lblIntVenue" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Venue of Interview Required"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <div class="card-heading text-white bg-info">
                                        <h6 class="card-title py-1 mb-3 text-left">&nbsp; Are any of your close relatives working in HAL?</h6>
                                    </div>
                                </div>
                                <div class="form-group col-md-1 mt-0">
                                    <label for="inputDiscipline" class="form-label font-weight-bold">Yes/No<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlRelative" class="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRelative_SelectedIndexChanged">
                                        <asp:ListItem disabled Selected>Select</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblRelative" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Selection Required"></asp:Label>
                                </div>
                                <div class="form-group col-md-11">
                                    <div class="form-row" runat="server" id="divRelative" visible="false">
                                        <div class="form-group col-md-3">
                                            <label for="inputDiscipline" class="form-label font-weight-bold">Name<font color="red">*</font></label>
                                            <asp:TextBox ID="txtName" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="99" autocomplete="off" placeholder="Name" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                            <asp:Label ID="lblName" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Relative Name Required"></asp:Label>
                                        </div>

                                        <div class="form-group col-md-3">
                                            <label for="inputDiscipline" class="form-label font-weight-bold">Designation<font color="red">*</font></label>
                                            <asp:TextBox ID="txtDesig" class="form-control form-control-sm" Style="font-size: smaller" autocomplete="off" runat="server" placeholder="Designation" MaxLength="99" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                            <asp:Label ID="lblDesig" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Designation Required"></asp:Label>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label for="inputDiscipline" class="form-label font-weight-bold">Division<font color="red">*</font></label>
                                            <asp:TextBox ID="txtDiv" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="99" autocomplete="off" placeholder="Division" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                            <asp:Label ID="lblDiv" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Division Required"></asp:Label>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label for="inputDiscipline" class="form-label font-weight-bold">Any other Description</label>
                                            <asp:TextBox ID="txtDesc" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="150" autocomplete="off" placeholder="Any other Description" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                            <asp:Label ID="lblDesc" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Any other Description Required"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <div class="card-heading text-white bg-info">
                                        <h6 class="card-title py-1 mb-3 text-left">&nbsp; Have you ever been a member/worker of any polictical party/organisation or participated in any political activities?*</h6>
                                    </div>
                                </div>
                                <div class="form-group col-md-1 mt-0">
                                    <label for="inputDiscipline" class="form-label font-weight-bold">Yes/No<font color="red">*</font></label>
                                    <asp:DropDownList ID="ddlPolitics" class="form-control form-control-sm text-dark font-weight-bold text-dark" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPolitics_SelectedIndexChanged">
                                        <asp:ListItem disabled Selected>Select</asp:ListItem>
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblPolitics" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Selection Required"></asp:Label>
                                </div>
                                <div class="form-group col-md-11">
                                    <div class="form-row" runat="server" id="divPolitics" visible="false">
                                        <div class="form-group col-md-5">
                                            <label for="inputDiscipline" class="form-label font-weight-bold">Name of Political Party/Organisation<font color="red">*</font></label>
                                            <asp:TextBox ID="txtParty" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="150" autocomplete="off" placeholder="Name of Political Party/Organisation" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                            <asp:Label ID="lblParty" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Blank Not Allowed"></asp:Label>
                                        </div>

                                        <div class="form-group col-md-5">
                                            <label for="inputDiscipline" class="form-label font-weight-bold">Particulars of Political Activity<font color="red">*</font></label>
                                            <asp:TextBox ID="txtParticular" class="form-control form-control-sm" Style="font-size: smaller" placeholder="Particulars of Political Activity" autocomplete="off" runat="server" MaxLength="150" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                            <asp:Label ID="lblParticular" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Blank Not Allowed"></asp:Label>
                                        </div>
                                        <div class="form-group col-md-2">
                                            <label for="inputDiscipline" class="form-label font-weight-bold">Period of Membership<font color="red">*</font></label>
                                            <asp:TextBox ID="txtMemPeriod" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="12" autocomplete="off" placeholder="YYYY to YYYY" runat="server" oncopy="return false" onpaste="return false" oncut="return false"></asp:TextBox>
                                            <asp:Label ID="lblMemPeriod" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Blank Not Allowed"></asp:Label>
                                        </div>
                                        <br />
                                        <div class="form-group col-md-6">
                                            <label for="inputDiscipline" class="form-label font-weight-bold">Nature of Participation in Political Activity<font color="red">*</font></label>
                                            <asp:TextBox ID="txtNature" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="150" autocomplete="off" placeholder="Nature of Participation in Political Activity" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                            <asp:Label ID="lblNature" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Blank Not Allowed"></asp:Label>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label for="inputDiscipline" class="form-label font-weight-bold">Office, if any, held in Political Party<font color="red">*</font></label>
                                            <asp:TextBox ID="txtOffice" class="form-control form-control-sm" Style="font-size: smaller" MaxLength="150" autocomplete="off" placeholder="Office, if any, held in Political Party" runat="server" oncopy="return false" onpaste="return false" oncut="return false" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return ValidateAlpha(event)"></asp:TextBox>
                                            <asp:Label ID="lblOffice" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="Blank Not Allowed"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--   //End Work Experience--%>

                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <div>
                                        <asp:CheckBox ID="CheckBox1" class="form-control form-control-sm text-dark font-weight-bold text-dark" runat="server" Text="<b> &nbsp;&nbsp; I hereby declare that the above information is true to the best of my knowledge.</b>" AutoPostBack="true" OnCheckedChanged="chkConfirm_CheckedChanged" />
                                    </div>
                                </div>
                            </div>

                            <asp:Label ID="lblStatus" runat="server" Font-Bold="true" Font-Size="Larger" ForeColor="Red" Text=""></asp:Label>

                            <div class="d-flex justify-content-between mb-2">
                                <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Enabled="false" Text=" Save and Next " OnClick="btnSave_Clicked" />
                                <%--  <asp:Button ID="btnPrev" runat="server" class="btn btn-outline-primary" Text="Previous" OnClick="btnPrev_Click" />--%>
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
            </div>
        </div>
    </div>
</asp:Content>

