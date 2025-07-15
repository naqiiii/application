<%@ Page Language="VB" AutoEventWireup="false" CodeFile="authentication.aspx.vb" Inherits="authentication" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login for authentication</title>
    <style>
        .credentials-box {
            border: 1px solid #aaa;
            padding: 10px;
            width: 300px;
            background-color: #f9f9f9;
            margin-top: 20px;
        }
        .credentials-box h3 {
            margin: 0 0 10px 0;
            font-size: 16px;
        }
        .credentials-box ul {
            list-style-type: none;
            padding: 0;
        }
        .credentials-box li {
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login for authentication</h2>

            Username: <asp:TextBox ID="txtUsername" runat="server" /><br /><br />
            Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br /><br />

            <asp:Button ID="btnLogin" runat="server" Text="Check Credentials" OnClick="btnLogin_Click" /><br /><br />

            <asp:DropDownList ID="ddlRoles" runat="server" Visible="false" /><br /><br />

            <asp:Button ID="btnSelectRole" runat="server" Text="Login with Selected Role" Visible="false" OnClick="btnSelectRole_Click" /><br /><br />

            <asp:Label ID="lblError" runat="server" ForeColor="Red" />

          
            <div class="credentials-box">
                <h3>My role wise Login Credentials</h3>
                <h4>sir i give it same username and password for your easeness</h4>
                <ul>
                    <li><strong>Admin    </strong>username: hassan | Password: ha$$an*1052</li>
                    <li><strong>Student  </strong> username: hassan | Password: ha$$an*1052</li>
                    <li><strong>Teacher  </strong> username: hassan | Password: ha$$an*1052</li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
