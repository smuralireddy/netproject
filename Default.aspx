<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
         body {
background-image:url(main_bg.gif);
background-color:#FFF;
font-family:Verdana, Arial, Helvetica, sans-serif;
font-size:11px;
font-weight:400;
color:#000;
background-repeat:repeat-x;
scrollbar-darkshadow-color:#0ff;
margin:0;
padding:0
}

        .style1
        {
            width: 732px;
            height: 234px;
        }

        .style2
        {
            text-align: center;
        }

    </style>
</head>
<body bgcolor="#ffff99">
    <form id="form1" runat="server"><center>
        <img alt="" class="style1" src="main_header_big3_white23.JPG" /></center>
    <div>
    
        <h1 style="text-align: center">
            Welcome</h1>
    
    </div>
    <p style="text-align: center">
        Username :<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBox1" ErrorMessage="RequiredField"></asp:RequiredFieldValidator>
    </p>
    <p style="text-align: center">
        Password:<input type="password" ID="TextBox2" runat="server"/></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TextBox2" ErrorMessage="RequiredField"></asp:RequiredFieldValidator>
    </p>
    <p style="text-align: center">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
    </p>
    <div id="wrong" class="style2" style="visibility: hidden" runat="server">Wrong Username/Password</div>
    </form>
</body>
</html>
