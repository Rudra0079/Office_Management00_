<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Orient.Registration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MedPart">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="page-wrapper" style="background-color: White;">
        <div class="container-fluid">
            <!-- Page Heading -->
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        <small>User Registration</small>
                    </h1>
                    <asp:Label ID="LblHeading" runat="server" Font-Size="13px" Font-Bold="true"></asp:Label>
                    <div class="form-group">
                        <label for="exampleInputPassword1">
                            User Name</label>
                        <asp:TextBox ID="txtUserName" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV2" ValidationGroup="a" runat="server" ForeColor="Red"
                            Display="Dynamic" ErrorMessage="Enter valid user name" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                    </div>
                    <div id="pass" runat="server">
                    <div class="form-group">
                        <label for="exampleInputPassword1">
                            Password</label>
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV1" ValidationGroup="a" runat="server" ForeColor="Red"
                            Display="Dynamic" ErrorMessage="Enter the correct password" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">
                            Re-Enter Password</label>
                        <asp:TextBox ID="txtRePassword" TextMode="Password" runat="server" 
                            class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="a" runat="server"
                            ForeColor="Red" Display="Dynamic" ErrorMessage="Re-Enter the correct password"
                            ControlToValidate="txtRePassword"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CV1" runat="server" ControlToValidate="txtRePassword" ControlToCompare="txtPassword" ForeColor="Red" Display="Dynamic" ErrorMessage="password does not match"></asp:CompareValidator>
                    </div></div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">
                            Email-Id</label>
                        <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV21" ValidationGroup="a" runat="server"
                            ForeColor="Red" Display="Dynamic" ErrorMessage="Enter the correct Email-Id"
                            ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">
                            Expiry Date</label>
                        <asp:TextBox ID="txtExpiryDate" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="a" runat="server"
                            ForeColor="Red" Display="Dynamic" ErrorMessage="Enter the correct Expiry Date"
                            ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtExpiryDate">
                        </asp:CalendarExtender>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">
                            Resource</label>
                        <asp:DropDownList ID="ddlResource" class="form-control" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFV3" ValidationGroup="a" runat="server"
                            ForeColor="Red" Display="Dynamic"
                            ControlToValidate="ddlResource"></asp:RequiredFieldValidator>
                    </div>
                      <div class="form-group">
                        <label for="exampleInputPassword1">
                            User Type</label>
                        <asp:DropDownList ID="ddlUserType" class="form-control" runat="server">
                        <asp:ListItem Value="0">--Select User Type--</asp:ListItem>
                        <asp:ListItem Value="A">Admin</asp:ListItem>
                        <asp:ListItem Value="E">Employee</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFV4" ValidationGroup="a" runat="server"
                            ForeColor="Red" Display="Dynamic"
                            ControlToValidate="ddlUserType"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" ValidationGroup="a"
                            Text="Submit" onclick="btnsubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" 
                            Text="Cancel" onclick="btnCancel_Click"
                             />
                        <br />
                        <br />
                        <asp:Label ID="lblUserType" Visible="false" runat="server"></asp:Label>
                        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hfValue" runat="server" />
                    </div>

                    <div class="divOverflow">
                        <div class="p1">
                            <asp:GridView ID="grdRegistrationDetail" runat="server" GridLines="None" CssClass="table table-bordered table-striped table-hover"
                                AutoGenerateColumns="false" DataKeyNames="ID" 
                                EmptyDataText="No More Record" 
                                onpageindexchanging="grdRegistrationDetail_PageIndexChanging" 
                                onrowdeleting="grdRegistrationDetail_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="User Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUserName" runat="server" Text='<%# bind("UserName") %>' CssClass="tdstyle1"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Email-Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmailId" runat="server" Text='<%# bind("EmailId") %>' CssClass="tdstyle1"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Expiry Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpiryDate" runat="server" Text='<%# bind("ExpiryDate") %>' CssClass="tdstyle1"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Created On">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedOn" runat="server" Text='<%# bind("CreatedOn") %>' CssClass="tdstyle1"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Resource Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblResourceName" runat="server" Text='<%# bind("ResourceName") %>' CssClass="tdstyle1"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="User Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUserType" runat="server" Text='<%# bind("UserType") %>' CssClass="tdstyle1"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="imgbtnViewDetail" runat="server" Text="Edit" CausesValidation="false"
                                                CssClass=" btn btn-default" CommandArgument='<%# Eval("ID") %>' 
                                                onclick="imgbtnViewDetail_Click">
                                            </asp:Button>
                                            <asp:LinkButton ID="LinkButton1" Text="Delete" CommandName="Delete" CssClass="btn btn-danger"
                                                OnClientClick="return confirm('Are you sure you want to delete this Record?')"
                                                runat="server"></asp:LinkButton>
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