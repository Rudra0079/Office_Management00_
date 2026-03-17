<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Orient.Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link href="../Admin/css/bootstrap.min.css" rel="stylesheet" />
    <!-- bootstrap theme -->
    <link href="../Admin/css/bootstrap-theme.css" rel="stylesheet" />
    <!--external css-->
    <!-- font icon -->
    <link href="../Admin/css/elegant-icons-style.css" rel="stylesheet" />
    <link href="../Admin/css/font-awesome.css" rel="stylesheet" />
    <!-- Custom styles -->
    <link href="../Admin/css/style.css" rel="stylesheet" />
    <link href="../Admin/css/style-responsive.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 -->
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
</head>
<body  class="login-img3-body">
    <form id="form1" runat="server">
    <div class="container">

      <div class="login-form">        
        <div class="login-wrap">
            <p class="login-img"><i class="icon_lock_alt"></i></p>
            <div class="input-group">
              <span class="input-group-addon"><i class="icon_profile"></i></span>
              <asp:TextBox ID="txtUserId" runat="server"  placeholder="Username" CssClass="form-control" autofocus></asp:TextBox>
        
            </div>
            <div class="input-group">
                <span class="input-group-addon"><i class="icon_key_alt"></i></span>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"  placeholder="Password" CssClass="form-control"></asp:TextBox>
               
            </div>
          <%--  <label class="checkbox">
                <input type="checkbox" value="remember-me"> Remember me
                <span class="pull-right"> <a href="#"> Forgot Password?</a></span>
            </label>--%>
              <asp:Button ID="btnLogin" runat="server" Text="LOGIN"  
                class="btn btn-primary btn-lg btn-block" onclick="btnLogin_Click" 
         />
       
            <a class="btn btn-info btn-lg btn-block" style="color:White !important;" href="Default.aspx">CANCEL</a>
        </div>
      </div>
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
