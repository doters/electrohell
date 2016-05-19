Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class setDefaultGrid
    Inherits publicQuery
    Dim clasq As New gridQueries
    Dim dr As MySqlDataReader
    Dim headers As String() = {"Kode", "Size 1", "Size 2", "Size 3", "Size 4", "Size 5", "Size 6", "Size 7", "Size 8"}
    Dim tempDt, dt As DataTable

    Public Function setGrid() As DataTable
        Dim table As New DataTable
        For Each s As String In headers
            table.Columns.Add(s)
        Next
        Return table
    End Function

    Public Function setSize() As DataTable
        tempDt = clasq.loadFilteredDataTable("select * from tb_size order by size,value Asc")
        dt = setGrid()
        dr = retDatareader("select * from tb_size group by kode")
        While dr.Read
            Dim drs() As DataRow = tempDt.Select("Kode = '" & dr(0).ToString & "'")
            Dim newRow As DataRow = dt.NewRow()
            newRow("Kode") = dr(0).ToString
            For x As Integer = 1 To drs.Count
                newRow("Size " & x.ToString) = drs(x - 1)("Size")
            Next
            dt.Rows.Add(newRow)
        End While
        Return dt
    End Function

    Public Function xtoy(table As DataTable) As DataRow
        Dim tbl As New DataTable
        tbl = setGrid()
        Dim newRow As DataRow = tbl.NewRow()

        For a As Integer = 1 To table.Rows.Count
            Dim drs() As DataRow = table.Select("value='" & a & "'")
            newRow("Size " & a) = drs(0)("qty").ToString()
        Next
        Return newRow
    End Function
    Public Function loadFilterData(tab1 As DataTable, tab2 As DataTable, splitFrom As String, filterRow As String) As DataTable 'isi filter row
        Dim table As New DataTable
        Dim tabrow() As DataRow
        Dim tabxy, addrow As DataRow
        Dim xyz As Integer = 0
        'convert tb2 ke horizontal, replace tab2 pake dt baru
        For s As Integer = 0 To tab1.Columns.Count - 1
            If tab1.Columns(s).ColumnName = splitFrom Then
                table.Columns.Add(tab1.Columns(s).ColumnName)
                For t As Integer = 1 To headers.Length - 1
                    table.Columns.Add(headers(t))
                Next
            Else
                table.Columns.Add(tab1.Columns(s).ColumnName)
            End If
        Next

        For x As Integer = 0 To tab1.Rows.Count - 1
            Dim newrow As DataRow = table.NewRow()
            xyz = 0
            Dim tabTemp As New DataTable
            If filterRow = "" Then
                tabrow = tab2.Select("KodeItem='" & tab1.Rows(x)(0) & "'")
            Else
                tabrow = tab2.Select(filterRow & "='" & tab1.Rows(x)(0) & "' and KodeItem='" & tab1.Rows(x)(1) & "'")
            End If
            tabTemp.Columns.Add("value")
            tabTemp.Columns.Add("qty")
            For asd As Integer = 0 To tabrow.Length - 1
                addrow = tabTemp.NewRow
                addrow("value") = tabrow(asd)("value")
                addrow("qty") = tabrow(asd)("qty")
                tabTemp.Rows.Add(addrow)
            Next
            tabxy = xtoy(tabTemp)
            For y As Integer = 0 To tab1.Columns.Count - 1
                If tab1.Columns(y).ColumnName = splitFrom Then
                    newrow(xyz) = tab1.Rows(x)(y)
                    xyz += 1
                    For z As Integer = 1 To tabrow.Length
                        newrow(xyz) = tabxy(z)
                        xyz += 1
                    Next
                Else
                    newrow(xyz) = tab1.Rows(x)(y)
                    xyz += 1
                End If
            Next
            table.Rows.Add(newrow)
        Next
        Return table
    End Function
End Class
