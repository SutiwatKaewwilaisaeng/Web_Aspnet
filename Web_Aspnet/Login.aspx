<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_Aspnet.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style>
        body {
                background-color:wheat;
        
        }

    </style>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="margin:auto;border:5px solid white">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    <br />
                    </td>

                </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>

                </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
                    <br />
                

                </td>
                </tr>
              <tr>
                <td></td>
                <td>
                    <br />
                <asp:Label ID="lblErrorMessage" runat="server" Text="Incorrect User Credentials" ForeColor="Red"/>

                </td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>
