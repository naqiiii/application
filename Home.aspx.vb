Imports System.Data.SqlClient

Partial Class Home
    Inherits System.Web.UI.Page


    Dim connString As String = "iaddatabase"
    Dim currentUserEmail As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then

            If Session("Email") IsNot Nothing Then
                currentUserEmail = Session("Email").ToString()
                LoadUserData(currentUserEmail)
            Else

            End If
        End If
    End Sub


    Private Sub LoadUserData(ByVal email As String)

        Dim userType As String = GetUserType(email)

        If userType = "Student" Then
            LoadStudentCourses(email)
            LoadStudentSessions(email)
            studentContent.Visible = True
            tutorContent.Visible = False
        ElseIf userType = "Tutor" Then
            LoadTutorCourses(email)
            LoadTutorSessions(email)
            studentContent.Visible = False
            tutorContent.Visible = True
        End If
    End Sub


    Private Function GetUserType(ByVal email As String) As String

        Dim query As String = "SELECT 'Student' AS UserType FROM STUDENT4 WHERE Email = @Email " &
                            "UNION " &
                            "SELECT 'Tutor' AS UserType FROM TUTORS WHERE Email = @Email"

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Email", email)
                conn.Open()
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    Return result.ToString()
                End If
            End Using
        End Using
        Return String.Empty
    End Function


    Private Sub LoadStudentCourses(ByVal email As String)

        Dim query As String = "SELECT C.CourseName FROM COURSE9 C " &
                            "JOIN STUDENT_COURSE_LANGUAGE SC ON C.CourseID = SC.CourseID " &
                            "WHERE SC.StudentID IN (SELECT StudentID FROM STUDENT4 WHERE Email = @Email)"

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Email", email)
                conn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()

                    Dim courseName As String = reader("CourseName").ToString()
                    studentCourses.InnerHtml &= "<div class='course-item'>" & courseName & "</div>"
                End While
            End Using
        End Using
    End Sub


    Private Sub LoadStudentSessions(ByVal email As String)

        Dim query As String = "SELECT S.SessionDate, S.SessionTime FROM SCHEDULE_SESSIONS S " &
                            "JOIN STUDENT_COURSE_LANGUAGE SC ON S.CourseID = SC.CourseID " &
                            "WHERE SC.StudentID IN (SELECT StudentID FROM STUDENT4 WHERE Email = @Email) " &
                            "AND S.SessionDate > GETDATE()"

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Email", email)
                conn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()

                    Dim sessionDate As String = reader("SessionDate").ToString()
                    Dim sessionTime As String = reader("SessionTime").ToString()
                    studentSessions.InnerHtml &= "<div class='session-item'>Session on " & sessionDate & " at " & sessionTime & "</div>"
                End While
            End Using
        End Using
    End Sub


    Private Sub LoadTutorCourses(ByVal email As String)

        Dim query As String = "SELECT C.CourseName FROM COURSE9 C " &
                            "JOIN TUTOR_COURSE_LANGUAGE TC ON C.CourseID = TC.CourseID " &
                            "WHERE TC.TutorID IN (SELECT TutorID FROM TUTORS WHERE Email = @Email)"

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Email", email)
                conn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()

                    Dim courseName As String = reader("CourseName").ToString()
                    tutorCourses.InnerHtml &= "<div class='course-item'>" & courseName & "</div>"
                End While
            End Using
        End Using
    End Sub


    Private Sub LoadTutorSessions(ByVal email As String)

        Dim query As String = "SELECT S.SessionDate, S.SessionTime FROM SCHEDULE_SESSIONS S " &
                            "JOIN TUTOR_COURSE_LANGUAGE TC ON S.CourseID = TC.CourseID " &
                            "WHERE TC.TutorID IN (SELECT TutorID FROM TUTORS WHERE Email = @Email) " &
                            "AND S.SessionDate > GETDATE()"

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Email", email)
                conn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()

                    Dim sessionDate As String = reader("SessionDate").ToString()
                    Dim sessionTime As String = reader("SessionTime").ToString()
                    tutorSessions.InnerHtml &= "<div class='session-item'>Session on " & sessionDate & " at " & sessionTime & "</div>"
                End While
            End Using
        End Using
    End Sub



End Class