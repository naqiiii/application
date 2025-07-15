Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data

Partial Class Attendance
    Inherits System.Web.UI.Page

    Private connString As String = ConfigurationManager.ConnectionStrings("iaddatabase").ConnectionString

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadDropdowns()
        End If
    End Sub

    Private Sub LoadDropdowns()
        LoadDropdown("SELECT tutor_id, tutor_name FROM TUTORS", ddlTutors, "tutor_name", "tutor_id", "-- Select Tutor --")
        LoadDropdown("SELECT course_id, course_name FROM COURSE9", ddlCourses, "course_name", "course_id", "-- Select Course --")
    End Sub

    Private Sub LoadDropdown(query As String, dropdown As DropDownList, textField As String, valueField As String, defaultText As String)
        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                dropdown.DataSource = cmd.ExecuteReader()
                dropdown.DataTextField = textField
                dropdown.DataValueField = valueField
                dropdown.DataBind()
                dropdown.Items.Insert(0, New ListItem(defaultText, "0"))
            End Using
        End Using
    End Sub

    Protected Sub btnCreateSession_Click(sender As Object, e As EventArgs) Handles btnCreateSession.Click
        If ddlTutors.SelectedValue = "0" Or ddlCourses.SelectedValue = "0" Then
            ShowAlert("Select tutor and course.")
            Return
        End If

        Dim sessionDate As Date, sessionTime As TimeSpan, duration As Integer
        If Not Date.TryParse(txtSessionDate.Text, sessionDate) Or Not TimeSpan.TryParse(txtSessionTime.Text, sessionTime) Or Not Integer.TryParse(txtDuration.Text, duration) Then
            ShowAlert("Invalid date/time/duration.")
            Return
        End If

        Dim topic = If(String.IsNullOrEmpty(txtTopic.Text), DBNull.Value, txtTopic.Text)

        Using conn As New SqlConnection(connString)
            Dim query = "INSERT INTO Attendance (tutor_id, course_id, session_date, session_time, duration_minutes, topic_covered) " &
            "VALUES (@TutorID, @CourseID, @Date, @Time, @Duration, @Topic); SELECT SCOPE_IDENTITY();"

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@TutorID", ddlTutors.SelectedValue)
                cmd.Parameters.AddWithValue("@CourseID", ddlCourses.SelectedValue)
                cmd.Parameters.AddWithValue("@Date", sessionDate)
                cmd.Parameters.AddWithValue("@Time", sessionTime)
                cmd.Parameters.AddWithValue("@Duration", duration)
                cmd.Parameters.AddWithValue("@Topic", topic)
                conn.Open()
                Dim sessionID = Convert.ToInt32(cmd.ExecuteScalar())
                ViewState("CurrentSessionID") = sessionID
            End Using
        End Using

        LoadStudents()
    End Sub

    Private Sub LoadStudents()
        Dim sessionID = Convert.ToInt32(ViewState("CurrentSessionID"))

        Using conn As New SqlConnection(connString)
            Dim query = "SELECT s.student_id, s.student_name FROM STUDENT4 s " &
                   "JOIN ENROLLED_COURSES sc ON s.student_id = sc.student_id " &
                   "WHERE sc.course_id = (SELECT course_id FROM Attendance WHERE session_id = @SessionID)"

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@SessionID", sessionID)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()

                Try
                    conn.Open()
                    adapter.Fill(dt)

                    If dt.Rows.Count > 0 Then
                        gvStudents.DataSource = dt
                        gvStudents.DataBind()
                        pnlRecordAttendance.Visible = True
                    Else
                        ShowAlert("No students found for this course.")
                        pnlRecordAttendance.Visible = False
                    End If
                Catch ex As SqlException
                    ShowAlert("Database error: " & ex.Message)
                Catch ex As Exception
                    ShowAlert("An error occurred while loading students.")
                End Try
            End Using
        End Using
    End Sub

    Protected Sub btnSaveAttendance_Click(sender As Object, e As EventArgs) Handles btnSaveAttendance.Click
        If ViewState("CurrentSessionID") Is Nothing Then
            ShowAlert("No session found.")
            Return
        End If

        Dim sessionID = Convert.ToInt32(ViewState("CurrentSessionID"))

        Using conn As New SqlConnection(connString)
            conn.Open()

            ' Delete old attendance
            Using delCmd As New SqlCommand("DELETE FROM StudentAttendance WHERE session_id=@SessionID", conn)
                delCmd.Parameters.AddWithValue("@SessionID", sessionID)
                delCmd.ExecuteNonQuery()
            End Using

            ' Insert new attendance
            For Each row As GridViewRow In gvStudents.Rows
                Dim studentID = Convert.ToInt32(gvStudents.DataKeys(row.RowIndex).Value)
                Dim status As String = CType(row.FindControl("ddlStatus"), DropDownList).SelectedValue
                Dim notes As String = CType(row.FindControl("txtNotes"), TextBox).Text

                Using insCmd As New SqlCommand("INSERT INTO StudentAttendance (session_id, student_id, attendance_status, notes) VALUES (@SID, @StuID, @Status, @Notes)", conn)
                    insCmd.Parameters.AddWithValue("@SID", sessionID)
                    insCmd.Parameters.AddWithValue("@StuID", studentID)
                    insCmd.Parameters.AddWithValue("@Status", status)
                    insCmd.Parameters.AddWithValue("@Notes", If(String.IsNullOrEmpty(notes), DBNull.Value, notes))
                    insCmd.ExecuteNonQuery()
                End Using
            Next
        End Using

        ShowAlert("Attendance saved.")
        pnlRecordAttendance.Visible = False
    End Sub

    Private Sub ShowAlert(msg As String)
        Dim safeMsg As String = msg.Replace("'", "\'")
        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('" & safeMsg & "');", True)
    End Sub
End Class