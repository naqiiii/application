<%@ Page Language="VB" AutoEventWireup="false" CodeFile="checkattendance.aspx.vb" Inherits="StudentAttendance" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Attendance</title>
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
        <div class="section">
            <h2>View My Attendance</h2>

            <label class="form-label">Enter Student ID:</label>
            <asp:TextBox ID="txtStudentID" runat="server" CssClass="form-control" />

            <asp:Button ID="btnViewAttendance" runat="server" Text="View Attendance" CssClass="btn" />

            <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="False" CssClass="grid" EmptyDataText="No attendance records found.">
                <Columns>
                    <asp:BoundField DataField="course_name" HeaderText="Course" />
                    <asp:BoundField DataField="session_date" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="session_time" HeaderText="Time" />
                    <asp:BoundField DataField="duration_minutes" HeaderText="Duration (min)" />
                    <asp:BoundField DataField="topic_covered" HeaderText="Topic" />
                    <asp:BoundField DataField="attendance_status" HeaderText="Status" />
                    <asp:BoundField DataField="notes" HeaderText="Notes" />
                </Columns>
            </asp:GridView>

        </div>
         <div class="credentials-box">
     <h3>My student id to check attendance</h3>
     <h4>sir i give here only one student id for you to check if it is working or not</h4>
             <h4>you can also check it by creating attendance session by teacher role</h4>
     <ul>
         <li><strong>Admin</strong>student id = 230</li>
         
     </ul>
 </div>
    </form>
</body>
</html>
