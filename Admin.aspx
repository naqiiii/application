<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Admin.aspx.vb" Inherits="AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
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
        <h2>I am Admin i have ability to navigate to this whole platform</h2>
        <h3>click delete to delete role on violation of rules</h3>

        <h3>Students</h3>
        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID" OnRowDeleting="gvStudents_RowDeleting">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" />
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="Role" HeaderText="Role" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <h3>Tutors</h3>
        <asp:GridView ID="gvTutors" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID" OnRowDeleting="gvTutors_RowDeleting">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" />
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="Role" HeaderText="Role" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" /><br />
        <br />
        <a href="home.aspx">1.click if need to visit home page for updation</a><br /><br />
         <a href="Tutordetails.aspx">2.click if need to visit tutor page for updation</a><br /><br />
         <a href="Updateattendance.aspx">3.click if need to visit attendance session page for updation</a><br />

    </form>
</body>
</html>
