Imports System.IO
Imports Microsoft.Win32

Public Class registr
    Dim baseRegistryKey As RegistryKey = Registry.CurrentUser
    Dim subkey As String = "ELECTROHELL"
    ' Dim clask As New publicKoneksi

    Public Function readReg(server As String, database As String, username As String, password As String) As String
        Dim rk As RegistryKey = baseRegistryKey
        Dim sk1 As RegistryKey = rk.OpenSubKey(subkey)
        If (sk1 Is Nothing) Then
            Return Nothing
        Else
            Try
                Dim x As String = "server=" & sk1.GetValue(server.ToUpper()).ToString & _
                    ";Database=" & sk1.GetValue(database.ToUpper()).ToString & ";user id=" & sk1.GetValue(username.ToUpper()).ToString & _
                ";password=" & sk1.GetValue(password.ToUpper()).ToString & ";"


                Return x
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Function Write(keyName As String, value As Object) As Boolean
        Try
            Dim rk As RegistryKey = baseRegistryKey
            Dim sk1 As RegistryKey = rk.CreateSubKey(subkey)
            sk1.SetValue(keyName.ToUpper(), value)

            Return True
        Catch ex As Exception

            Return False
        End Try
    End Function


End Class
