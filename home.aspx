<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        body {
            background-image:url(main_bg.gif);
            background-color:#FFF;
            font-family:Verdana, Arial, Helvetica, sans-serif;
            font-size:11px;
            font-weight:400;
            color:#000;
            background-repeat:repeat-x;
            
}

    </style>
</head>
<body>
    <form id="form1" runat="server" visible="True">
    <div id="success" runat="server" class="success">
    
        <h1 class="style1">
    
        Welcome to train 
        ticket reservation systems . 
        </h1>
        <br />
        You are logged in
        <br />
        Enter the source :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        Enter the destination:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
            Text="Show trains avaliable" />
        <br />
        <br />
        
        </div>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Show all trains" />
    <div id="traindiv" runat="server">
    </div>
    
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="Book tickets" />
    
     
    <div id="bookdiv" runat="server" style="visibility:hidden" >
        
        Select Train number :<asp:DropDownList ID="trainno_list" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Specify the no. of tickets::<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <div id="err" runat="server"></div>
        <br />
        <br />
        Specify the compartment type
        <asp:DropDownList ID="type" runat="server" Width="79px">
            <asp:ListItem>First class</asp:ListItem>
            <asp:ListItem>Sleeper</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Book!" onclick="Button3_Click" />
        </div>
    
        </form>
    
    
    
</body>
</html>
