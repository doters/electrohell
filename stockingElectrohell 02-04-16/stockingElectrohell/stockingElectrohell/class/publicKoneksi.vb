Imports System.Data.SqlClient
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class publicKoneksi
    ' Shared ConnectionStr As String = "server=127.0.0.1;Database=garment;user id=root;password=;"
    ' Public ConnectionStr As String
    Dim regs As New registr
    Dim conn As New MySqlConnection(My.Settings.strConn)
    Public Sub cekKon()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            Else
                conn.Close()
                conn.Open()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function retKon() As MySqlConnection
        cekKon()
        Return conn
    End Function
End Class
