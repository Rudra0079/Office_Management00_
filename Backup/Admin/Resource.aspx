<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeBehind="Resource.aspx.cs" Inherits="Orient.Resource" %>

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
                        <small>Resource Management</small>
                    </h1>
                    <asp:Label ID="LblHeading" runat="server" Font-Size="13px" Font-Bold="true"></asp:Label>
                    <div class="form-group">
                        <label for="exampleInputPassword1">
                            Resource Name</label>
                        <asp:TextBox ID="txtResourceName" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFV1" ValidationGroup="a" runat="server" ForeColor="Red"
                            Display="Dynamic" ErrorMessage="Enter the correct resource name" ControlToValidate="txtResourceName"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" ValidationGroup="a"
                            Text="Submit" OnClick="btnsubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel"
                            OnClick="btnCancel_Click" />
                        <br />
                        <br />
                        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                        <asp:HiddenField ID="hfValue" runat="server" />
                    </div>
                    <div class="divOverflow">
                        <div class="p1">
                            <asp:GridView ID="grdResourceDetail" runat="server" GridLines="None" CssClass="table table-bordered table-striped table-hover"
                                AutoGenerateColumns="false" DataKeyNames="ID" EmptyDataText="No More Record"
                                OnPageIndexChanging="grdResourceDetail_PageIndexChanging" OnRowDeleting="grdResourceDetail_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Resource Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProject" runat="server" Text='<%# bind("ResourceName") %>' CssClass="tdstyle1"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="imgbtnViewDetail" runat="server" Text="Edit" CausesValidation="false"
                                                CssClass=" btn btn-default" CommandArgument='<%# Eval("ID") %>' OnClick="imgbtnViewDetail_Click">
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
