Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class autoComplete
    Inherits publicKoneksi
    Dim conn As MySqlConnection = retKon()
    Dim cmd As MySqlCommand
    Dim dr As MySqlDataReader
    Public Function retComplete(query As String) As AutoCompleteStringCollection
        Dim col As New AutoCompleteStringCollection
        cekKon()
        cmd = New MySqlCommand(query, conn)
        dr = cmd.ExecuteReader
        While dr.Read()
            col.Add(dr(0).ToString())
        End While
        Return col
    End Function
End Class
