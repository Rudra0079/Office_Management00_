<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Orient.ChangePassword" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MedPart">

   
        <div id="page-wrapper" style="background-color:White;">

            <div class="container-fluid">

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                           <small>Change Password</small>
                        </h1>
                      <asp:Label ID="LblHeading" runat="server" Font-Size="13px" Font-Bold="true"></asp:Label>
                           

                               
 <div class="form-group">
                          <label for="exampleInputPassword1">Current Password *</label>
       <asp:TextBox ID="txtCPass" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RFV1" ControlToValidate="txtCPass" runat="server" ValidationGroup="a" Display="Dynamic" ForeColor="Red" ErrorMessage="Please Enter The Valid Password"></asp:RequiredFieldValidator>                     
</div>

         <div class="form-group">
                          <label for="exampleInputPassword1">New Password *</label>
       <asp:TextBox ID="txtNPass" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFV2" ControlToValidate="txtNPass" runat="server" ValidationGroup="a" Display="Dynamic" ForeColor="Red" ErrorMessage="Please Enter The Valid New Password"></asp:RequiredFieldValidator>                     
</div>

 <div class="form-group">
                          <label for="exampleInputPassword1">Confirm New Password *</label>
       <asp:TextBox ID="txtxRePass" TextMode="Password" runat="server" class="form-control"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RFV3" ControlToValidate="txtxRePass" runat="server" ValidationGroup="a" Display="Dynamic" ForeColor="Red" ErrorMessage="Please Enter The Valid New Password"></asp:RequiredFieldValidator>
     <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtxRePass" ValidationGroup="a" ControlToCompare="txtNPass" ForeColor="Red" ErrorMessage="Confirm Password Does not Match with New Password"></asp:CompareValidator>        
</div>
                                    <div>
                                        <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary"  
                                            ValidationGroup="a" Text="Submit" onclick="btnsubmit_Click"/>

                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" 
                                            Text="Cancel" onclick="btnCancel_Click"/>
                                        <br />
                                        <br />
                                        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                                       
                                    </div>
                     </div>
                    </div>
                </div>
                <!-- /.row -->

            </div>
        </asp:Content>