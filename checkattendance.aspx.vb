Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data

Partial Class StudentAttendance
    Inherits System.Web.UI.Page

    Private connString As String = ConfigurationManager.ConnectionStrings("iaddatabase").ConnectionString

    Protected Sub btnViewAttendance_Click(sender As Object, e As EventArgs) Handles btnViewAttendance.Click
        Dim studentID As Integer
        If Not Integer.TryParse(txtStudentID.Text.Trim(), studentID) Then
            ShowAlert("Please enter a valid student ID.")
            Return
        End If

        Using conn As New SqlConnection(connString)
            Dim query As String = "SELECT " &
                      "c.course_name, " &
                      "a.session_date, " &
                      "a.session_time, " &
                      "a.duration_minutes, " &
                      "a.topic_covered, " &
                      "sa.attendance_status, " &
                      "sa.notes " &
                      "FROM StudentAttendance sa " &
                      "INNER JOIN Attendance a ON sa.session_id = a.session_id " &
                      "INNER JOIN COURSE9 c ON a.course_id = c.course_id " &
                      "WHERE sa.student_id = @StudentID " &
                      "ORDER BY a.session_date DESC, a.session_time DESC"


            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@StudentID", studentID)

                Dim adapter As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                Try
                    conn.Open()
                    adapter.Fill(dt)
                    gvAttendance.DataSource = dt
                    gvAttendance.DataBind()
                Catch ex As Exception
                    ShowAlert("Error loading attendance: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub ShowAlert(msg As String)
        Dim safeMsg As String = msg.Replace("'", "\'")
        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('" & safeMsg & "');", True)
    End Sub
End Class
