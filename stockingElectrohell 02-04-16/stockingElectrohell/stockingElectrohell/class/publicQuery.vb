Imports System.Data.SqlClient
Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class publicQuery
    Inherits publicKoneksi

    Dim respons As String
    Dim conn As MySqlConnection = retKon()
    Dim dr As MySqlDataReader
    Dim cmd As MySqlCommand
    Private Sub cekKon()
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

    Public Function retDatareader(queries As String) As MySqlDataReader
        Try
            cekKon()
            cmd = New MySqlCommand(queries, conn)
            dr = cmd.ExecuteReader
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return dr
    End Function
    Public Function insertQuery(queries As String) As String
        Dim respons As String = ""
        Try
            cekKon()
            cmd = New MySqlCommand(queries, conn)
            cmd.ExecuteNonQuery()
            respons = "Saved"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return respons
    End Function

    Public Function updateQuery(queries As String) As String
        Dim respons As String = ""
        Try
            cekKon()
            cmd = New MySqlCommand(queries, conn)
            cmd.ExecuteNonQuery()
            respons = "Updated"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return respons
    End Function

    Public Function deleteQuery(queries As String) As String
        Dim respons As String = ""
        Try
            cekKon()
            cmd = New MySqlCommand(queries, conn)
            cmd.ExecuteNonQuery()
            respons = "Deleted"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return respons
    End Function

End Class
