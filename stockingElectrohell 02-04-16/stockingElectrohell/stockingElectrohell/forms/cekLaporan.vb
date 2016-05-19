Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class cekLaporan
    Dim clasq As New gridQueries
    Dim clasg As New publicQuery

    Dim cmd As MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Select Case ComboBox1.Text
            Case "Penerimaan Barang"
                DataGridView1.Rows.Clear()
                DataGridView1.Columns.Clear()
                DataGridView1.ColumnCount = 5
                DataGridView1.Columns(0).Name = "invoice"
                DataGridView1.Columns(0).HeaderText = "Invoice"
                DataGridView1.Columns(1).Name = "Status"
                DataGridView1.Columns(1).HeaderText = "Status"
                DataGridView1.Columns(2).Name = "Seller"
                DataGridView1.Columns(2).HeaderText = "Seller"
                DataGridView1.Columns(3).Name = "Price"
                DataGridView1.Columns(3).HeaderText = "Price"
                DataGridView1.Columns(4).Name = "Grandtotal"
                DataGridView1.Columns(4).HeaderText = "Grand Total"
                Dim chk As New DataGridViewCheckBoxColumn()
                DataGridView1.Columns.Add(chk)
                chk.HeaderText = "Check Data"
                chk.Name = "chk"
                Dim dr As MySqlDataReader = clasg.retDatareader("select * from tb_report where status='penerimaan' and cekstatus=0")
                Dim x As Integer = 0
                While dr.Read()
                    Dim rows As String() = {dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString(), dr(6).ToString}
                    DataGridView1.Rows.Add(rows)
                    DataGridView1.Rows(x).Cells(5).Value = False
                    x += 1
                End While

            Case "Pengiriman Barang"
                DataGridView1.Rows.Clear()
                DataGridView1.Columns.Clear()
                DataGridView1.ColumnCount = 5
                DataGridView1.Columns(0).Name = "invoice"
                DataGridView1.Columns(0).HeaderText = "Invoice"
                DataGridView1.Columns(1).Name = "Status"
                DataGridView1.Columns(1).HeaderText = "Status"
                DataGridView1.Columns(2).Name = "Seller"
                DataGridView1.Columns(2).HeaderText = "Seller"
                DataGridView1.Columns(3).Name = "Price"
                DataGridView1.Columns(3).HeaderText = "Price"
                DataGridView1.Columns(4).Name = "Grandtotal"
                DataGridView1.Columns(4).HeaderText = "Grand Total"
                Dim chk As New DataGridViewCheckBoxColumn()
                DataGridView1.Columns.Add(chk)
                chk.HeaderText = "Check Data"
                chk.Name = "chk"
                Dim dr As MySqlDataReader = clasg.retDatareader("select * from tb_report where status='pengiriman' and cekstatus=0")
                Dim x As Integer = 0
                While dr.Read()
                    Dim rows As String() = {dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString(), dr(4).ToString(), dr(5).ToString(), dr(6).ToString}
                    DataGridView1.Rows.Add(rows)
                    DataGridView1.Rows(x).Cells(5).Value = False
                    x += 1
                End While
            Case "Return Barang"
                DataGridView1.Rows.Clear()
                DataGridView1.Columns.Clear()
                DataGridView1.ColumnCount = 5
                DataGridView1.Columns(0).Name = "invoice"
                DataGridView1.Columns(0).HeaderText = "Invoice"
                DataGridView1.Columns(1).Name = "Status"
                DataGridView1.Columns(1).HeaderText = "Status"
                DataGridView1.Columns(2).Name = "Seller"
                DataGridView1.Columns(2).HeaderText = "Seller"
                DataGridView1.Columns(3).Name = "Price"
                DataGridView1.Columns(3).HeaderText = "Price"
                DataGridView1.Columns(4).Name = "Grandtotal"
                DataGridView1.Columns(4).HeaderText = "Grand Total"
                Dim chk As New DataGridViewCheckBoxColumn()
                DataGridView1.Columns.Add(chk)
                chk.HeaderText = "Check Data"
                chk.Name = "chk"
                Dim dr As MySqlDataReader = clasg.retDatareader("select * from tb_report where status='return' and cekstatus=0")
                Dim x As Integer = 0
                While dr.Read()
                    Dim rows As String() = {dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString(), dr(6).ToString}
                    DataGridView1.Rows.Add(rows)
                    DataGridView1.Rows(x).Cells(5).Value = False
                    x += 1
                End While
            Case "Penjualan Barang"
                DataGridView1.Rows.Clear()
                DataGridView1.Columns.Clear()
                DataGridView1.ColumnCount = 7
                DataGridView1.Columns(0).Name = "invoice"
                DataGridView1.Columns(0).HeaderText = "Invoice"
                DataGridView1.Columns(1).Name = "Status"
                DataGridView1.Columns(1).HeaderText = "Status"
                DataGridView1.Columns(2).Name = "Seller"
                DataGridView1.Columns(2).HeaderText = "Seller"
                DataGridView1.Columns(3).Name = "Price"
                DataGridView1.Columns(3).HeaderText = "Price"
                DataGridView1.Columns(4).Name = "SellPrice"
                DataGridView1.Columns(4).HeaderText = "Sell Price"
                DataGridView1.Columns(5).Name = "Cons"
                DataGridView1.Columns(5).HeaderText = "Cons"
                DataGridView1.Columns(6).Name = "Grandtotal"
                DataGridView1.Columns(6).HeaderText = "Grand Total"
                Dim chk As New DataGridViewCheckBoxColumn()
                DataGridView1.Columns.Add(chk)
                chk.HeaderText = "Check Data"
                chk.Name = "chk"
                Dim dr As MySqlDataReader = clasg.retDatareader("select * from tb_report where status='penjualan' and cekstatus=0")
                Dim x As Integer = 0
                While dr.Read()
                    Dim rows As String() = {dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString(), dr(4).ToString(), dr(5).ToString(), dr(6).ToString}
                    DataGridView1.Rows.Add(rows)
                    DataGridView1.Rows(x).Cells(7).Value = False
                    x += 1
                End While

        End Select

    End Sub

    Private Sub insertRow(row As String())

    End Sub
End Class