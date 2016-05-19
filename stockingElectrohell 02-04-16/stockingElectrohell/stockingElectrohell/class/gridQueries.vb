Imports System.Data.SqlClient
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class gridQueries
    Inherits publicKoneksi
    Dim conn As MySqlConnection = retKon()

    Public Function loadAllData(columns As String, tbl As String, order As String) As DataTable
        Dim da As New MySqlDataAdapter("select " & columns & " from " & tbl & " order by " & order, conn)
        Dim ds As New DataSet
        da.Fill(ds)
        Return ds.Tables(0)
    End Function
    Public Function loadDataTable(columns As String, tbl As String, queries As String) As DataTable
        Dim da As New MySqlDataAdapter("select " & columns & " from " & tbl & " where " & queries, conn)
        Dim ds As New DataSet
        da.Fill(ds)
        Return ds.Tables(0)
    End Function

    Public Function loadFilteredDataTable(queries As String) As DataTable
        Dim da As New MySqlDataAdapter(queries, conn)
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            da.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        dt = ds.Tables(0)
        Return dt
    End Function

End Class
