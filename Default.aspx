<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Tutoring System</title>
    <style>
        body {
            font-family: Arial;
            background-color: #f0f8ff;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .welcome-box {
            text-align: center;
            background: #fff;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0px 0px 12px rgba(0,0,0,0.1);
        }
        .welcome-box h1 {
            color: #333;
            margin-bottom: 20px;
        }
        .welcome-box input[type="submit"] {
            padding: 10px 20px;
            font-size: 16px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 6px;
            cursor: pointer;
        }
        .welcome-box input[type="submit"]:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="welcome-box">
            <h1>Welcome to Tutoring Platform</h1>
<a href="authentication.aspx" class="login-link">1.authenticate yourself</a><br />
<a href="code.docx" class="login-link">2.Report</a>

        </div>
    </form>
</body>
</html>
