Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FormAddWarehouse
    Dim clasg As New gridQueries
    Dim clasquer As New publicQuery
    Dim dt As DataTable
    Dim dr As MySqlDataReader
    Dim added As Boolean = False
    Private Sub ViewAllSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewAllSizeToolStripMenuItem.Click
        dt = clasg.loadAllData("warehouseName", "tb_warehouse", " warehouseName asc")
        dGridView.DataSource = dt
        dGridView.AutoResizeColumns()
        dGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        clasquer.insertQuery("insert into tb_warehouse values ('','" & txtKeterangan.Text & "')")

    End Sub

    Private Sub FormAddSize_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim kosong As Boolean = False

        For Each x As Control In Me.Controls
            If TypeOf x Is TextBox Then
                If x.Text <> "" Then
                    kosong = True
                End If
            End If
        Next
        If kosong Then
            Dim dr As DialogResult = MessageBox.Show("Data not saved, close anyway?", "INFO", MessageBoxButtons.OKCancel)
            If dr = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
                Return
            End If
        End If
    End Sub
End Class