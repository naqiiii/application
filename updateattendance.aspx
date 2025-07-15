<%@ Page Language="VB" AutoEventWireup="false" CodeFile="updateattendance.aspx.vb" Inherits="Attendance" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance Management</title>
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
            <h2>update student Session Attendance</h2>
            <h3>teacher update attendance for session</h3>
            <h4>in this teacher can update an attendance in this session of a student</h4>
            <label class="form-label">Select Tutor:</label>
            <asp:DropDownList ID="ddlTutors" runat="server" CssClass="form-control" />

            <label class="form-label">Select Course:</label>
            <asp:DropDownList ID="ddlCourses" runat="server" CssClass="form-control" />

            <label class="form-label">Session Date:</label>
            <asp:TextBox ID="txtSessionDate" runat="server" TextMode="Date" CssClass="form-control" />

            <label class="form-label">Session Time:</label>
            <asp:TextBox ID="txtSessionTime" runat="server" TextMode="Time" CssClass="form-control" />

            <label class="form-label">Duration (minutes):</label>
            <asp:TextBox ID="txtDuration" runat="server" TextMode="Number" CssClass="form-control" />

            <label class="form-label">Topic Covered:</label>
            <asp:TextBox ID="txtTopic" runat="server" CssClass="form-control" />

            <br /><br />
            <asp:Button ID="btnCreateSession" runat="server" Text="Create Session" CssClass="btn" />
        </div>

        
        <asp:Panel ID="pnlRecordAttendance" runat="server" Visible="False" CssClass="section">
            <h2>Record Attendance</h2>
            <asp:Label ID="lblSessionInfo" runat="server" CssClass="form-label"></asp:Label>
            <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" DataKeyNames="student_id" CssClass="grid">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="Student ID" Visible="false" />
                    <asp:BoundField DataField="student_name" HeaderText="Student Name" />
                    <asp:TemplateField HeaderText="Attendance Status">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Present" Value="Present" Selected="True" />
                                <asp:ListItem Text="Absent" Value="Absent" />
                                <asp:ListItem Text="Late" Value="Late" />
                                <asp:ListItem Text="Excused" Value="Excused" />
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Notes">
                        <ItemTemplate>
                            <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="2" CssClass="form-control" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div style="text-align:center; padding:20px;">
                        No students found for this course session.
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
            <br />
            <asp:Button ID="btnSaveAttendance" runat="server" Text="Save Attendance" CssClass="btn" />
        </asp:Panel>

    </form>
</body>
</html>