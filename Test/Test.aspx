<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>

<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" /></head>
<body>
    <form id="form1" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-sm-4">
										 	<!--NOTE: Update your email Id in "contact_me.php" file in order to receive emails from your contact form-->
		                 <form>
                         <h3>
                             Have Any Query.</h3>
                         <div class="control-group">
                             <div class="controls">
                                 <asp:TextBox ID="txtName" runat="server"  class="form-control" ></asp:TextBox>
                             
                                 <p class="help-block">
                                 </p>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="Please Enter Full Name" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                             </div>
                         </div>
                         <div class="control-group">
                             <div class="controls">
                                 <asp:TextBox ID="txtEmail" placeholder="Email-Id" class="form-control" runat="server"></asp:TextBox>
                                 <p class="help-block">
                                 </p>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtEmail" runat="server" ErrorMessage="Please Enter Email-Id" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Please Enter Valid EmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
		
    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Please Enter Valid EmailId" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
    --%>
                             </div>
                         </div>
                         <div class="control-group">
                             <div class="controls">
                                 <asp:TextBox ID="txtContact" placeholder="Contact Details" class="form-control" runat="server"></asp:TextBox>
                                 <p class="help-block">
                                 </p>
                             </div>
                         </div>
                         <div class="control-group">
                             <div class="controls">
                                 <div class="control-group">
                                     <div class="controls">
                                         <asp:TextBox ID="txtQuery" placeholder="Your Query" class="form-control" TextMode="MultiLine" Height="150px" runat="server"></asp:TextBox>
                                         <p class="help-block">
                                         </p>
                                     </div>
                                 </div>
                             </div>
                         </div>
                         <%--<div id="success">
                         </div>--%>
                         <!-- For success/fail messages -->
                         <asp:Button ID="btnSave1" class="btn btn-primary pull-right" runat="server" Text="Submit" onclick="btnSave1_Click" >
                         </asp:Button>
                         <asp:Label ID="lblmsg" runat="server"></asp:Label>
                         </form>
                     </div>
    
    </div>
    </div>
    </form>
</body>
</html>
