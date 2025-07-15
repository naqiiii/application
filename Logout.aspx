<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Logout.aspx.vb" Inherits="Logout" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Logout - Online Tutoring Platform</title>
    <meta http-equiv="refresh" content="2;url=Home.aspx" /> 
    <style>
        body {
            font-family: 'Segoe UI', Arial, sans-serif;
            background-color: #f5f5f5;
            text-align: center;
            padding-top: 100px;
        }
        .logout-message {
            background-color: white;
            max-width: 500px;
            margin: 0 auto;
            padding: 30px;
            border-radius: 5px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
        }
        .loading-spinner {
            margin: 20px auto;
            width: 50px;
            height: 50px;
            border: 5px solid #f3f3f3;
            border-top: 5px solid #3498db;
            border-radius: 50%;
            animation: spin 1s linear infinite;
        }
        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="logout-message">
            <h2>Logging out...</h2>
            <div class="loading-spinner"></div>
            <p>You have been successfully logged out.</p>
            <p>Redirecting to home page...</p> 
        </div>
    </form>
</body>
</html>