Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.Text
Imports System
Imports System.Linq

Partial Class Register
    Inherits System.Web.UI.Page

    Dim connString As String = ConfigurationManager.ConnectionStrings("iaddatabase").ConnectionString
    Public Shared Function ComputeSHA256Hash(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function
    Private Function IsStrongPassword(password As String) As Boolean
        Dim hasMinimumLength As Boolean = password.Length >= 8
        Dim hasUpperCase As Boolean = password.Any(AddressOf Char.IsUpper)
        Dim hasLowerCase As Boolean = password.Any(AddressOf Char.IsLower)
        Dim hasDigit As Boolean = password.Any(AddressOf Char.IsDigit)
        Dim hasSpecialChar As Boolean = password.Any(Function(c) Not Char.IsLetterOrDigit(c))

        Return hasMinimumLength AndAlso hasUpperCase AndAlso hasLowerCase AndAlso hasDigit AndAlso hasSpecialChar
    End Function

    Protected Sub btnRegister_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRegister.Click
        Try
            If String.IsNullOrEmpty(txtFirstName.Text.Trim()) OrElse
               String.IsNullOrEmpty(txtEmail.Text.Trim()) OrElse
               String.IsNullOrEmpty(txtPassword.Text.Trim()) OrElse
               String.IsNullOrEmpty(txtAddress.Text.Trim()) OrElse
               String.IsNullOrEmpty(txtProfileDesc.Text.Trim()) Then
                lblError.Text = "Please fill all required fields (*)"
                lblError.Visible = True
                Return
            End If

            Dim studentName As String = txtFirstName.Text.Trim()
            Dim email As String = txtEmail.Text.Trim()
            Dim password As String = txtPassword.Text.Trim()
            Dim address As String = txtAddress.Text.Trim()
            Dim profileDesc As String = txtProfileDesc.Text.Trim()

            If Not IsStrongPassword(password) Then
                lblError.Text = "Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character."
                lblError.Visible = True
                Return
            End If

            Dim passwordHash As String = ComputeSHA256Hash(password)


            Using checkConn As New SqlConnection(connString)
                Dim checkQuery As String = "SELECT COUNT(*) FROM STUDENT4 WHERE email = @Email"
                Using checkCmd As New SqlCommand(checkQuery, checkConn)
                    checkCmd.Parameters.AddWithValue("@Email", email)
                    checkConn.Open()
                    Dim emailExists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If emailExists > 0 Then
                        lblError.Text = "Email already registered. Please use a different email."
                        lblError.Visible = True
                        Return
                    End If
                End Using
            End Using

            Using conn As New SqlConnection(connString)
                Dim query As String = "INSERT INTO STUDENT4 (student_name, email, Password, address, profile_description) " &
                                      "VALUES (@StudentName, @Email, @Password, @Address, @ProfileDesc)"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@StudentName", studentName)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Password", passwordHash)
                    cmd.Parameters.AddWithValue("@Address", address)
                    cmd.Parameters.AddWithValue("@ProfileDesc", profileDesc)

                    conn.Open()
                    cmd.ExecuteNonQuery()

                    Response.Redirect("Login.aspx?registered=true")
                End Using
            End Using

        Catch ex As SqlException When ex.Number = 2627
            lblError.Text = "Email already registered. Please use a different email."
            lblError.Visible = True
        Catch ex As Exception
            lblError.Text = "Registration error: " & ex.Message
            lblError.Visible = True
        End Try
    End Sub
End Class
