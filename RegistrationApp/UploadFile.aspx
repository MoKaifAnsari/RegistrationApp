<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="RegistrationApp.UploadFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="container">
        <div class="card o-hidden border-0 shadow-sms my-0">
            <div class="text-center">
                <h5 class="card text-white font-weight-bold bg-info p-1">Files to be Uploaded</h5>
            </div>
            <div class="card-body p-0">
            <p style="text-align:center; color:white;background-color:brown;font-size:small">Upload Document Format (JPG) Only,  File Size: Photograph and Signature between 20-100KB and others are between 100-500KB <br /> 
                Application with illegible / blurred photograph /documents and /or signature will be rejected </p>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="p-1">
                           <form runat="server">
                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="eduppa" class="text-dark font-weight-bold">Passport Size Photograph <font color="red">*</font></label>
                                        <asp:FileUpload ID="FileUploadPhoto" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="eduppb" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnPassport" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnPhoto_Upload" />
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="eduppc" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label  id="lblPhoto" runat="server" ForeColor="Red"  class="form-control" ></asp:Label>
                                    </div>
                                   <div class="form-group col-md-2">
                                        <asp:Image ID="imgPhoto" runat="server" Height = "100" Width = "100"/>                                   
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="edusiga" class="text-dark font-weight-bold">Signature <font color="red">*</font></label>
                                        <asp:FileUpload ID="FileUploadSign" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="edusigb" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnSign" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnSign_Upload"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="edusigc" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblSign"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgSign" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="educca" class="text-dark font-weight-bold">Aadhar Card<font color="red">*</font></label>
                                        <asp:FileUpload ID="FileUploadAdhar" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="educcb" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnAdhar" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnAdhar_Upload"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="educcc" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" id="lblAdhar">Status</asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgAdhar" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

<%--                                <div class="form-row" runat="server" id="divCaste">
                                    <div class="form-group col-md-4">
                                        <label for="educca" class="text-dark font-weight-bold">Caste Certificate <font color="red">*</font></label>
                                        <asp:FileUpload ID="FileUploadCaste" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="educcb" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnCaste" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnCaste_Upload"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="educcc" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblCaste"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgCaste" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

                               <div class="form-row" runat="server" id="divPH">
                                    <div class="form-group col-md-4">
                                        <label for="educca" class="text-dark font-weight-bold">PwD Certificate <font color="red">*</font></label>
                                        <asp:FileUpload ID="FileUploadPH" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="educcb" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnPH" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnPH_Click"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="educcc" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblPH"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgPH" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="edu10a" class="text-dark font-weight-bold">10th Board Certificate <font color="red">*</font></label>
                                        <asp:FileUpload ID="FileUpload10th" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="edu10b" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnTen" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnTen_Upload"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="edu10c" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblTen"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgTen" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="edu10a" class="text-dark font-weight-bold">10th Board Marksheet <font color="red">*</font></label>
                                        <asp:FileUpload ID="FileUpload10thMS" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="edu10b" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnTenMS" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnTenMS_Click"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="edu10c" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblTenMS"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgTenMS" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

                                <div class="form-row" id="div12" runat="server">
                                    <div class="form-group col-md-4">
                                        <label for="edu12a" class="text-dark font-weight-bold">12th Board Certificate <font color="red">*</font></label>
                                        <asp:FileUpload ID="FileUpload12th" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="edu12b" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnTwelve" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnTwelve_Upload"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="edu12c" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblTwelve"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgTwelve" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

                                <div class="form-row" id="div12ms" runat="server">
                                    <div class="form-group col-md-4">
                                        <label for="edu12a" class="text-dark font-weight-bold">12th Board Marksheet <font color="red">*</font></label>
                                        <asp:FileUpload ID="FileUpload12thMS" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="edu12b" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnTwelveMS" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnTwelveMS_Click"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="edu12c" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblTwelveMS"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgTwelveMS" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

                                <div class="form-row" id="divDiploma" runat="server">
                                    <div class="form-group col-md-4">
                                        <label for="edu12a" class="text-dark font-weight-bold">Diploma Certificate <font color="red">*</font></label>
                                        <asp:FileUpload ID="FileUploadDiploma" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="edu12b" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnDiploma" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnDiploma_Click"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="edu12c" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblDiploma"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgDiploma" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

                                  <div class="form-row" id="divDiplomaMS" runat="server">
                                      <div class="form-group col-md-4">
                                          <label for="edu12a" class="text-dark font-weight-bold">Diploma Marksheet <font color="red">*</font></label>
                                          <asp:FileUpload ID="FileUploadDiplomaMS" class="form-control h-auto" runat="server" accept=".jpg"/>
                                      </div>
                                      <div class="form-group col-md-2">
                                          <label for="edu12b" class="text-dark font-weight-bold">&nbsp;</label>
                                          <asp:Button ID="btnDiplomaMS" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnDiplomaMS_Click"/>
                                      </div>
                                      <div class="form-group col-md-4">
                                          <label for="edu12c" class="text-dark font-weight-bold">&nbsp;</label>
                                          <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblDiplomaMS"></asp:Label>
                                      </div>
                                      <div class="form-group col-md-2">
                                          <asp:Image ID="imgDiplomaMS" runat="server" Height = "100" Width = "100" />                                   
                                      </div>
                                  </div>

                                <div class="form-row" runat="server" id="divGrad">
                                    <div class="form-group col-md-4">
                                        <label for="edusiga" class="text-dark font-weight-bold">Graduation/Equivalent Certificate <font color="red">*</font></label>
                                        <asp:FileUpload ID="FileUploadGrad" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnGrad" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnGrad_Upload"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblGrad"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgGraduate" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

                               <div class="form-row" runat="server" id="divGradMS">
                                   <div class="form-group col-md-4">
                                       <label for="edusiga" class="text-dark font-weight-bold">Graduation/Equivalent Marksheet <font color="red">*</font></label>
                                       <asp:FileUpload ID="FileUploadGradMS" class="form-control h-auto" runat="server" accept=".jpg"/>
                                   </div>
                                   <div class="form-group col-md-2">
                                       <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                       <asp:Button ID="btnGradMS" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnGradMS_Click"/>
                                   </div>
                                   <div class="form-group col-md-4">
                                       <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                       <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblGradMS"></asp:Label>
                                   </div>
                                   <div class="form-group col-md-2">
                                       <asp:Image ID="imgGraduateMS" runat="server" Height = "100" Width = "100" />                                   
                                   </div>
                               </div>

                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="edusiga" class="text-dark font-weight-bold">Degree Certificate <font color="red">*</font></label>
                                        <asp:FileUpload ID="FileUploadDegree" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnDegree" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnDegree_Click"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblDegree"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgDegree" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label for="edusiga" class="text-dark font-weight-bold">Degree Marksheet <font color="red">*</font></label>
                                        <asp:FileUpload ID="FileUploadDegreeMS" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnDegreeMS" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnDegreeMS_Click"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblDegreeMS"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgDegreeMS" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

   
                                <div class="form-row" runat="server" id="divDISC">
                                    <div class="form-group col-md-4">
                                        <label for="edusiga" class="text-dark font-weight-bold">Diploma in Industrial Safety Certificate <font color="red">*</font></label>
                                        <asp:FileUpload ID="fuDiplomaSafety" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnDiplomaSafety" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnDiplomaSafety_Click"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblDiplomaSafety"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgDiplomaSafety" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

                                <div class="form-row" runat="server" id="divDISCMS">
                                    <div class="form-group col-md-4">
                                        <label for="edusiga" class="text-dark font-weight-bold">Diploma in Industrial Safety Marksheet <font color="red">*</font></label>
                                        <asp:FileUpload ID="fuDiplomaSafetyMS" class="form-control h-auto" runat="server" accept=".jpg"/>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Button ID="btnDiplomaSafetyMS" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnDiplomaSafetyMS_Click"/>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                        <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblDiplomaSafetyMS"></asp:Label>
                                    </div>
                                    <div class="form-group col-md-2">
                                        <asp:Image ID="imgDiplomaSafetyMS" runat="server" Height = "100" Width = "100" />                                   
                                    </div>
                                </div>

  

                               <div class="form-row">
                                   <div class="form-group col-md-4">
                                       <label for="edusiga" class="text-dark font-weight-bold">Work Experience-1 (Current)<font color="red">*</font></label>
                                       <asp:FileUpload ID="fuExp1" class="form-control h-auto" runat="server" accept=".jpg"/>
                                   </div>
                                   <div class="form-group col-md-2">
                                       <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                       <asp:Button ID="btnExp1" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnExp1_Click"/>
                                   </div>
                                   <div class="form-group col-md-4">
                                       <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                       <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblExp1"></asp:Label>
                                   </div>
                                   <div class="form-group col-md-2">
                                       <asp:Image ID="imgExp1" runat="server" Height = "100" Width = "100" />                                   
                                   </div>
                               </div>

                               <div class="form-row" id="divExp2" runat="server">
                                   <div class="form-group col-md-4">
                                       <label for="edusiga" class="text-dark font-weight-bold">Work Experience-2<font color="red">*</font></label>
                                       <asp:FileUpload ID="fuExp2" class="form-control h-auto" runat="server" accept=".jpg"/>
                                   </div>
                                   <div class="form-group col-md-2">
                                       <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                       <asp:Button ID="btnExp2" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnExp2_Click"/>
                                   </div>
                                   <div class="form-group col-md-4">
                                       <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                       <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblExp2"></asp:Label>
                                   </div>
                                   <div class="form-group col-md-2">
                                       <asp:Image ID="imgExp2" runat="server" Height = "100" Width = "100" />                                   
                                   </div>
                               </div>

                              <div class="form-row" id="divExp3" runat="server">
                                  <div class="form-group col-md-4">
                                      <label for="edusiga" class="text-dark font-weight-bold">Work Experience-3<font color="red">*</font></label>
                                      <asp:FileUpload ID="fuExp3" class="form-control h-auto" runat="server" accept=".jpg"/>
                                  </div>
                                  <div class="form-group col-md-2">
                                      <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                      <asp:Button ID="btnExp3" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnExp3_Click"/>
                                  </div>
                                  <div class="form-group col-md-4">
                                      <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                      <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblExp3"></asp:Label>
                                  </div>
                                  <div class="form-group col-md-2">
                                      <asp:Image ID="imgExp3" runat="server" Height = "100" Width = "100" />                                   
                                  </div>
                              </div>

                              <div class="form-row" id="divExp4" runat="server">
                                  <div class="form-group col-md-4">
                                      <label for="edusiga" class="text-dark font-weight-bold">Work Experience-4<font color="red">*</font></label>
                                      <asp:FileUpload ID="fuExp4" class="form-control h-auto" runat="server" accept=".jpg"/>
                                  </div>
                                  <div class="form-group col-md-2">
                                      <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                      <asp:Button ID="btnExp4" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnExp4_Click"/>
                                  </div>
                                  <div class="form-group col-md-4">
                                      <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                      <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblExp4"></asp:Label>
                                  </div>
                                  <div class="form-group col-md-2">
                                      <asp:Image ID="imgExp4" runat="server" Height = "100" Width = "100" />                                   
                                  </div>
                              </div>

                              <div class="form-row" id="divExp5" runat="server">
                                  <div class="form-group col-md-4">
                                      <label for="edusiga" class="text-dark font-weight-bold">Work Experience-5<font color="red">*</font></label>
                                      <asp:FileUpload ID="fuExp5" class="form-control h-auto" runat="server" accept=".jpg"/>
                                  </div>
                                  <div class="form-group col-md-2">
                                      <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                      <asp:Button ID="btnExp5" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnExp5_Click"/>
                                  </div>
                                  <div class="form-group col-md-4">
                                      <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                      <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblExp5"></asp:Label>
                                  </div>
                                  <div class="form-group col-md-2">
                                      <asp:Image ID="imgExp5" runat="server" Height = "100" Width = "100" />                                   
                                  </div>
                              </div>

                             <div class="form-row" id="divExp6" runat="server">
                                 <div class="form-group col-md-4">
                                     <label for="edusiga" class="text-dark font-weight-bold">Work Experience-6<font color="red">*</font></label>
                                     <asp:FileUpload ID="fuExp6" class="form-control h-auto" runat="server" accept=".jpg"/>
                                 </div>
                                 <div class="form-group col-md-2">
                                     <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                     <asp:Button ID="btnExp6" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnExp6_Click"/>
                                 </div>
                                 <div class="form-group col-md-4">
                                     <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                     <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblExp6"></asp:Label>
                                 </div>
                                 <div class="form-group col-md-2">
                                     <asp:Image ID="imgExp6" runat="server" Height = "100" Width = "100" />                                   
                                 </div>
                             </div>

                              <div class="form-row" id="divExp7" runat="server">
                                  <div class="form-group col-md-4">
                                      <label for="edusiga" class="text-dark font-weight-bold">Work Experience-7<font color="red">*</font></label>
                                      <asp:FileUpload ID="fuExp7" class="form-control h-auto" runat="server" accept=".jpg"/>
                                  </div>
                                  <div class="form-group col-md-2">
                                      <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                      <asp:Button ID="btnExp7" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnExp7_Click"/>
                                  </div>
                                  <div class="form-group col-md-4">
                                      <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                      <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblExp7"></asp:Label>
                                  </div>
                                  <div class="form-group col-md-2">
                                      <asp:Image ID="imgExp7" runat="server" Height = "100" Width = "100" />                                   
                                  </div>
                              </div>

                               <div class="form-row" id="divExp8" runat="server">
                                   <div class="form-group col-md-4">
                                       <label for="edusiga" class="text-dark font-weight-bold">Work Experience-8<font color="red">*</font></label>
                                       <asp:FileUpload ID="fuExp8" class="form-control h-auto" runat="server" accept=".jpg"/>
                                   </div>
                                   <div class="form-group col-md-2">
                                       <label for="edu15b" class="text-dark font-weight-bold">&nbsp;</label>
                                       <asp:Button ID="btnExp8" class="form-control" BackColor="Orange" ForeColor="White" runat="server" Text="Upload" onClick="btnExp8_Click"/>
                                   </div>
                                   <div class="form-group col-md-4">
                                       <label for="edu15c" class="text-dark font-weight-bold">&nbsp;</label>
                                       <asp:Label runat="server" class="form-control" ForeColor="Red" id="lblExp8"></asp:Label>
                                   </div>
                                   <div class="form-group col-md-2">
                                       <asp:Image ID="imgExp8" runat="server" Height = "100" Width = "100" />                                   
                                   </div>
                               </div>--%>

                                <div class="form-group">
                                    <div>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="chkConfirm_CheckedChanged" />
                                        <span style="font-size:smaller;text-align: justify;">It is hereby declared that the information furnished by me herein above is true to my personal knowledge and belief. I further declare that if I obtain appointment on any false or incorrect information, my appointment shall be terminated / cancelled and I shall be liable for prosecution under the Law.</span>
                                    </div>
                                </div>

                                <div style="text-align:center">
                                    <asp:Label ID="lblStatus" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Large" Text =""></asp:Label>
                                </div>

                                <div class="d-flex justify-content-between">
                                    <asp:Button ID="btnSave" runat="server" Enabled="false" class="btn btn-outline-primary" Text=" Save and Next "  OnClick="btnSave_Click"/>
                                    <%--<asp:Button ID="btnPrev" runat="server" class="btn btn-outline-primary" Text="Previous" OnClick="btnPrev_Click"/>--%>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

