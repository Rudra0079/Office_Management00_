<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="Orient.Project" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="MedPart">
        <div id="page-wrapper" style="background-color:White;">
            <div class="container-fluid">

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                           <small>Project Management</small>
                        </h1>
                      <asp:Label ID="LblHeading" runat="server" Font-Size="13px" Font-Bold="true"></asp:Label>
                           

                                <div class="form-group">
                          <label for="exampleInputPassword1">Project Name</label>
        <asp:TextBox ID="txtProjectName" runat="server" class="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFV1" ValidationGroup="a" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Enter the correct project name" ControlToValidate="txtProjectName"></asp:RequiredFieldValidator>                  


</div>

         <div class="form-group">
                          <label for="exampleInputPassword1">Project Details</label>
       <asp:TextBox ID="txtProjectDetails" runat="server" TextMode="MultiLine" Height="150px" class="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFV2" ValidationGroup="a" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Enter the correct project detail" ControlToValidate="txtProjectDetails"></asp:RequiredFieldValidator>                       
</div>
                                    <div>
                                        <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary"  
                                            ValidationGroup="a" Text="Submit" onclick="btnsubmit_Click"/>

                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" 
                                            Text="Cancel" onclick="btnCancel_Click" />
                                        <br />
                                        <br />
                                        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="hfValue" runat="server" />
                                    </div>


                                    <div class="divOverflow" >
                            <div class="p1">
                              
                                        <asp:GridView ID="grdProjectDetail" runat="server" GridLines="None" CssClass="table table-bordered table-striped table-hover"
                                            AutoGenerateColumns="false" DataKeyNames="ID" 
                                            EmptyDataText="No More Record" 
                                            onpageindexchanging="grdProjectDetail_PageIndexChanging" onrowdeleting="grdProjectDetail_RowDeleting" 
                                            >
                                            <Columns>
                                                <asp:TemplateField HeaderText="Project Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProjectName" runat="server" Text='<%# bind("ProjectName") %>' CssClass="tdstyle1"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Project Details">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProjectDetail" runat="server" Text='<%# bind("ProjectDetails") %>' CssClass="tdstyle1"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:TemplateField>
                                               
                                               
                                                <asp:TemplateField HeaderText=" Action">
                                                    <ItemTemplate>
                                                        <asp:Button ID="imgbtnViewDetail" runat="server" Text="Edit"  CausesValidation="false"
                                                            CssClass=" btn btn-default" CommandArgument='<%# Eval("ID") %>' onclick="imgbtnViewDetail_Click"
                                                            ></asp:Button>
                                                        
                                                        <asp:LinkButton ID="imgbtnDeleteBrand" Text="Delete" CommandName="Delete"  CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this Record?')"  runat="server"></asp:LinkButton>

                                                    </ItemTemplate>
                                                    <ItemStyle Width="250px" Height="25px" HorizontalAlign="left"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings PageButtonCount="5" Position="Bottom" Mode="NumericFirstLast" FirstPageText="First"
                                                LastPageText="Last" />
                                            <PagerStyle CssClass="gridviewPager"></PagerStyle>
                                        </asp:GridView>
                                   
                            </div>
                        </div>


                                   
                               
                     
                     </div>
                    </div>
                </div>
                <!-- /.row -->

            </div>
        </asp:Content>

