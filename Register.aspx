<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Registration</title>
       <style>
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        background-color: #f4f6f8;
        margin: 0;
        padding: 20px;
        display: flex;
        justify-content: center;
        align-items: center;
        min-height: 100vh;
    }

    .login-container {
        background-color: #ffffff;
        padding: 30px;
        border-radius: 10px;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        width: 350px;
    }

    h2 {
        color: #2c3e50;
        text-align: center;
        margin-bottom: 25px;
    }

    .form-group {
        margin-bottom: 15px;
    }

    label {
        display: block;
        margin-bottom: 5px;
        color: #34495e;
        font-weight: bold;
    }

    .input-field {
        width: 100%;
        padding: 10px;
        border: 1px solid #bdc3c7;
        border-radius: 5px;
        box-sizing: border-box;
        font-size: 16px;
    }

    .btn-login {
        background-color: #3498db;
        color: white;
        padding: 12px 15px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        width: 100%;
        font-size: 18px;
        transition: background-color 0.3s ease;
    }

    .btn-login:hover {
        background-color: #2980b9;
    }

    .error-message {
        color: #c0392b;
        margin-top: 10px;
        text-align: center;
    }

    .link-register {
        margin-top: 20px;
        text-align: center;
        font-size: 14px;
        color: #7f8c8d;
    }

    .link-register a {
        color: #3498db;
        text-decoration: none;
    }

    .link-register a:hover {
        text-decoration: underline;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="registration-form">
            <h2>Student Registration</h2>

            <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false" />

            <div class="form-group">
                <label class="required" for="txtFirstName">First Name:</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="Enter your first name" />
            </div>

            <div class="form-group">
                <label for="txtLastName">Last Name:</label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Optional" />
            </div>

            <div class="form-group">
                <label class="required" for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" placeholder="e.g. your@email.com" />
            </div>

            <div class="form-group">
                <label class="required" for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter a strong password" />
            </div>

            <div class="form-group">
                <label class="required" for="txtAddress">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control" placeholder="Enter your address" />
            </div>

            <div class="form-group">
                <label class="required" for="txtProfileDesc">Profile Description:</label>
                <asp:TextBox ID="txtProfileDesc" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" placeholder="Tell us about yourself" />
            </div>

            <div class="form-group">
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn-register" OnClick="btnRegister_Click" />
            </div>
        </div>
    </form>
</body>
</html>
