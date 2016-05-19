Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FormGridSearch
    Dim clasg As New gridQueries
    Dim dr As MySqlDataReader
    Dim getSet As String
    Public Sub getSource(input As String)
        getSet = input
        If input = "produk" Then
            DataGridView1.DataSource = clasg.loadAllData("KodeItem as Product_Code, nama as Product_Name, Kategori, Color," & _
                                                         "kodesize as Size, Status", "tb_produk", "kodeitem")
        End If
    End Sub

    Public Sub setSource(output As String, value As String)
        If output = "produk" Then
            FormAddSUbProduct.ActiveForm.Controls.Find("txtkode", True).First().Text = value
            FormAddSUbProduct.ActiveForm.Controls.Find("txtkode", True).First().Focus()
        End If
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDoubleClick
        setSource(getSet, DataGridView1.CurrentRow.Cells(0).Value)
        Me.Close()
    End Sub
End Class