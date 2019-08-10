<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Web_Aspnet.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 190px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfUserID" runat="server" />
            <table>
                <tr>
                    <td>

                        <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
                    </td>
                    <td class="auto-style1"> 
                        <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
                    </td>
                   


                </tr>
                <tr>
                    <td>

                        <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtLastname" runat="server"></asp:TextBox>
                   </td>
                    


                </tr>
                <tr>
                    <td>

                        <asp:Label ID="Label3" runat="server" Text="Contract"></asp:Label>
                    </td>
                    <td >  
                        
                        <asp:TextBox ID="txtContract" runat="server"></asp:TextBox>
                        
                    </td>
                  
                </tr>

                <tr>
                    <td>

                        <asp:Label ID="Label4" runat="server" Text="Gender"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="dd1Gender" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    

                </tr>

                 <tr>
                    <td>

                        <asp:Label ID="Label5" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine">
                          
                        </asp:TextBox>
                    </td>
                    

                </tr>
                <tr>
                    <td colspan="3"><hr /></td>
                    
                </tr>
                 <tr>
                    <td>

                        <asp:Label ID="Label6" runat="server" Text="Username"></asp:Label>
                        </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtUsername" runat="server">
                       
                        </asp:TextBox>
                        <asp:Label runat="server" Text="*" Forecolor="Red"></asp:Label>
                    </td>
                    

                </tr>


                 <tr>
                    <td>

                        <asp:Label ID="Label7" runat="server" Text="Password" ></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password">
                            
                        </asp:TextBox>
                         <asp:Label runat="server" Text="*" Forecolor="Red"></asp:Label>
                    </td>
                    

                </tr>

                <tr>
                    <td>

                        <asp:Label ID="Label8" runat="server" Text="ConfirmPassword"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtconfilmpass" runat="server" TextMode="Password">
                            
                        </asp:TextBox>
                         <asp:Label runat="server" Text="*" Forecolor="Red"></asp:Label>
                    </td>
                    

                </tr>
                

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnSubmit" cssClass="alert-danger" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

                    </td>

                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>  

                    </td>

                </tr>
                 <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>  

                    </td>

                </tr>

            </table>
        </div>
    </form>
        </body>

</html>
