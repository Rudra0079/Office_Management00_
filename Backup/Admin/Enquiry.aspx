<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Enquiry.aspx.cs" Inherits="Orient.Enquiry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MedPart">
    <script src="Jscript/JavaScript.js"></script>
    <script src="Jscript/JavaScript2.js"></script>
    <link href="css/StyleDegin.css" rel="stylesheet" type="text/css" />
    <link href='https://fonts.googleapis.com/css?family=Merriweather+Sans' rel='stylesheet' type='text/css'>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
  
    <link href="css/Popup.css" rel="stylesheet" type="text/css" />
    
    <div id="page-wrapper">
        <div class="container-fluid">
            <!-- Page Heading -->
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        <small>Enquiry Details</small>
                    </h1>
                    <asp:HiddenField ID="hfValue" runat="server" />
            <div class="panel">
                       
                          <div class="panel-body">
               <label class="succes"> 
                   <asp:Label ID="lblmsg" runat="server"></asp:Label></label>
                    <div class="divOverflow" >
                            <div class="p1">
                                <asp:UpdatePanel ID="updatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdEnquiryDetail" runat="server" GridLines="None" CssClass="table table-bordered table-striped table-hover"
                                            AutoGenerateColumns="false" DataKeyNames="Id" 
                                            EmptyDataText="No More Record" 
                                            onpageindexchanging="grdEnquiryDetail_PageIndexChanging" onrowdeleting="grdEnquiryDetail_RowDeleting" 
                                           >
                                            <Columns>
                                                <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# bind("Name") %>' CssClass="tdstyle1"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Contact No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1f" runat="server" Text='<%# bind("Contact") %>' CssClass="tdstyle1"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Email Id">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# bind("Email") %>' CssClass="tdstyle1"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Enquiry Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label16" runat="server" Text='<%# bind("InsertedDate") %>' CssClass="tdstyle1"></asp:Label>
                                                        <asp:HiddenField ID="hfdetail"  runat="server" Value='<%# bind("Query") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Action">
                                                    <ItemTemplate>
                                                        <asp:Button ID="imgbtnViewDetail" runat="server" Text="Detail"  CausesValidation="false"
                                                            CssClass="btn btn-primary" CommandArgument='<%# Eval("Id") %>' onclick="imgbtnViewDetail_Click" 
                                                            ></asp:Button>

                                                        <asp:Button ID="imgbtnDeleteBrand" runat="server" CommandName="Delete" Text="Delete"  CssClass="btn btn-danger"
                                                            CommandArgument='<%# Eval("Id") %>' 
                                                            OnClientClick="return confirm('Are you sure you want to delete this Record?')" 
                                                            >
                                                        </asp:Button>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="250px" Height="25px" HorizontalAlign="left"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerSettings PageButtonCount="5" Position="Bottom" Mode="NumericFirstLast" FirstPageText="First"
                                                LastPageText="Last" />
                                            <PagerStyle CssClass="gridviewPager"></PagerStyle>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                    <asp:PostBackTrigger ControlID="grdEnquiryDetail" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        </div>
                        </div>
                        <div id="overlay">
                        </div>
                        <div  style="padding: 28px" class="popup">
                            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="Btnclose" ImageUrl="~/Admin/img/fancy_closebox.png" Style="float: right;
                                        margin-top: -26px; margin-right: -26px; height: 30px; cursor: pointer" runat="server"
                                        OnClientClick="ClosePopup()" />
                                    <asp:Label ID="LblHeading" runat="server" Font-Size="13px" Font-Bold="true"></asp:Label>
                                    
                                  <div id="main">

<div class="main_under">

<div class="con1">

<div class="con_under">
<div class="name">NAME :</div><!--anme ends-->
<div class="full_name">
    <asp:Label ID="lblNamePop" runat="server" ></asp:Label></div><!--full name ends-->

</div><!--con under ends-->

<div class="con_under">
<div class="name">MOBILE :</div><!--anme ends-->
<div class="full_name">  <asp:Label ID="lblMobilepop" runat="server" ></asp:Label></div><!--full name ends-->

</div><!--con under ends-->

<div class="con_under">
<div class="name">EMAIL ID :</div><!--anme ends-->
<div class="full_name">  <asp:Label ID="lblEmailpop" runat="server" ></asp:Label></div><!--full name ends-->
</div><!--con under ends-->

<div class="con_under">
<div class="name">Posted Date :</div><!--anme ends-->
<div class="full_name">  <asp:Label ID="lblQuiryDate" runat="server" ></asp:Label></div><!--full name ends-->
</div>

</div><!--con 1 ends-->
<div id="quairy">

<div class="hed1">QUERY</div><!--hed 1 ends-->

<div class="all_qu">  <asp:Label ID="lblQuerypop" runat="server" ></asp:Label></div><!--all qu ends-->

</div><!--quairy ends-->
</div><!--main under ends-->
</div>
                                    </div>
                                </ContentTemplate>
                               
                            </asp:UpdatePanel>
                            <!-- page end-->
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
        <div>
            <script type="text/javascript">
                function OpenPopup() {
                    $("#overlay").fadeIn();
                    $(".popup").fadeIn();
                }
                function ClosePopup() {
                    $("#overlay").fadeOut();
                    $(".popup").fadeOut();
                }
            </script>
        </div>
  
</asp:Content>