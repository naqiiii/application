<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login - Online Tutoring</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
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
        <header>
            <h1>Online Tutoring Platform</h1>
        </header>
        <main>
            <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false" />
            <div>
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" />
            </div>
            <div>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" />
            </div>
            <div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>

             <div class="credentials-box">
     <h3>My Login Credentials</h3>
     <h4>now enter those credentials of logon student to enter into home page of this platform if need</h4>
    
    
    <ul>
        <li><strong>    </strong>email: a@gmail.com | Password: H@$$@n*1122</li>
        
    </ul>
</div>
 
        </main>
    </form>
</body>
</html>
