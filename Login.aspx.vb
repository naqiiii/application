Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Text
Imports System

Partial Class Login
    Inherits System.Web.UI.Page

    Private ReadOnly connString As String = ConfigurationManager.ConnectionStrings("iaddatabase").ConnectionString

    Public Shared Function ComputeSHA256Hash(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
        lblError.Visible = False

        If String.IsNullOrWhiteSpace(txtEmail.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            lblError.Text = "Please enter both email and password."
            lblError.Visible = True
            Return
        End If

        Dim email As String = txtEmail.Text.Trim()
        Dim passwordHash As String = ComputeSHA256Hash(txtPassword.Text.Trim())

        Try
            Using conn As New SqlConnection(connString)
                Dim query As String = "SELECT student_id FROM STUDENT4 WHERE email = @Email AND Password = @Password"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Password", passwordHash)

                    conn.Open()

                    Dim userId As Object = cmd.ExecuteScalar()
                    If userId IsNot Nothing Then

                        Session("student_id") = userId.ToString()
                        Response.Redirect("Courses.aspx")
                    Else
                        lblError.Text = "Invalid email or password."
                        lblError.Visible = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            lblError.Text = "Login error: " & ex.Message
            lblError.Visible = True
        End Try
    End Sub
End Class
