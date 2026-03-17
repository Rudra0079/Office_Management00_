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
                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ForeColor="red" ErrorMessage="Please Enter Full Name" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorContact" runat="server" 
                             ErrorMessage="Please Enter Contact Details" ControlToValidate="txtContact" 
                             ForeColor="Red"></asp:RequiredFieldValidator>
                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtEmail" runat="server" ForeColor="red" ErrorMessage="Please Enter Email-Id" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Please Enter Valid EmailId" ForeColor="red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
	
                         <div class="control-group" style="margin-top:-19px">
                             <div class="controls">
                                 <asp:TextBox ID="txtName" runat="server"  class="form-control" 
                                     placeholder="Enter name" ForeColor="Red" ></asp:TextBox>
                             
                                 
                                 
                             </div>
                         </div>
                         <div class="control-group" style="margin-top:6px">
                             <div class="controls">
                                 <asp:TextBox ID="txtEmail" placeholder="Email-Id" class="form-control" runat="server"></asp:TextBox>
                                 

                             </div>
                         </div>
                         <div class="control-group" style="margin-top:6px">
                             <div class="controls">
                                 <asp:TextBox ID="txtContact" placeholder="Contact Details" class="form-control" runat="server" MaxLength="10" ></asp:TextBox>
                                 
                             </div>
                         </div>
                         <div class="control-group" style="margin-top:6px">
                          
                              

                                                                      <div class="controls">
                                         <asp:TextBox ID="txtQuery" placeholder="Your Query" class="form-control" TextMode="MultiLine" Height="80px" runat="server"></asp:TextBox>
                                        
                                                                      
                             </div>
                         </div>
                       <br />
                         <asp:Button ID="btnSave1" class="btn btn-primary pull-right" runat="server" Text="Submit" onclick="btnSave1_Click" >
                         </asp:Button>
                       
                         </form>
                     </div>
    
    </div>
    </div>
    </form>
</body>
</html>
