<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="Orient.Attendance" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MedPart">
  
    <div id="page-wrapper" style="background-color: White;">
        <div class="container-fluid">
            <!-- Page Heading -->
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        <small>Mark Your Attendance</small>
                    </h1>
                    <asp:Label ID="LblHeading" runat="server"></asp:Label>
                   
                    <div>
                        <asp:Button ID="btnsubmit" runat="server" 
                            style="padding: 30px 60px; margin-right:90px;" CssClass="btn btn-primary" ValidationGroup="a"
                            Text="In Time" onclick="btnsubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" style="padding: 30px 60px;" 
                            CssClass="btn btn-danger" Text="Out Time" onclick="btnCancel_Click"
                            />
                        <br />
                        <br />
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        
                    </div>
                    
                </div>
            </div>
        </div>
        <!-- /.row -->
    </div>
</asp:Content>