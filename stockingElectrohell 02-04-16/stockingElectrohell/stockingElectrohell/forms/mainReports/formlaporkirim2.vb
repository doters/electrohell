Imports MySql.Data.MySqlClient
Public Class formlaporkirim2
    Dim clasq As New publicQuery
    Dim clasg As New gridQueries
    Dim clasc As New autoComplete
    Dim clasgrid As New setDefaultGrid
    Dim dt As DataTable
    Dim dr As MySqlDataReader
    Dim param As String = ""
    Dim param1 As String = ""
    Private Sub formlaporkirim_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadSize()
        loadcom()
    End Sub
    Private Sub loadcom()
        For Each a As String In clasc.retComplete("select namatoko from tb_stores")
            txnama.AutoCompleteCustomSource.Add(a)
        Next
    End Sub
    Private Sub loadSize()
        dt = clasgrid.setSize()
        dGridSize.DataSource = dt
        dGridSize.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dGridSize.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub
    Private Sub loadGrid()
        Dim tempdt1, tempdt2 As DataTable
        tempdt1 = clasg.loadFilteredDataTable("select a.kode as KodeTrans,a.kodeItem as ItemCode, b.nama,b.color, b.kodeSize as Kode ,a.qty as qtyTotal,b.hargaJual" & _
                                              " from tb_produk b, tb_pengirimandetail a,tb_penjualan c where a.kodeitem=b.kodeitem and b.status <> '' " & _
                                              " and a.kode=c.kode " & param1 & "group by a.kode")
        tempdt2 = clasg.loadFilteredDataTable("SELECT kodeitem,value,sum(qty) as qty from tb_pengirimandetail inner join tb_pengiriman" & _
                                              " on tb_pengirimandetail.kode = tb_pengiriman.kode " & param & _
                                              " group by kodeitem,value ")
        dt = clasgrid.loadFilterData(tempdt1, tempdt2, "Kode", "KodeTrans")

        For a As Integer = 0 To dt.Rows.Count - 1
back:
            If dGridAll.Rows.Count = 0 Then
                initGrid(dt(a))
                rowTotalUpdate(dt(a), "0")
            Else
                MsgBox(dt(a)(1).ToString)
                For x As Integer = 0 To dGridAll.Rows.Count - 1
                    If dGridAll.Rows(x).Cells(0).Value = dt(a)(1).ToString Then
                        rowTotalUpdate(dt(a), x)
                        a += 1
                        GoTo back
                    End If
                Next
                initGrid(dt(a))
                rowTotalUpdate(dt(a), dGridAll.Rows.Count - 1)
            End If
        Next

    End Sub
    Private Sub initGrid(dr As DataRow)
        Dim rows As String() = {dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, _
                                    "0", "0", "0", "0", "0", "0", "0", "0", "0", dr(14).ToString, "0", "0"}
        dGridAll.Rows.Add(rows)

        ' txGrandtotal1.Visible = False
        'txGrandtotal2.Visible = True

    End Sub
    Private Sub rowTotalUpdate(value As DataRow, row As String)
        Dim subtotal As Integer = 0

        For x As Integer = 4 To 11
            dGridAll.Rows(row).Cells(x).Value = (Integer.Parse(dGridAll.Rows(row).Cells(x).Value) + Integer.Parse(value(x + 1))).ToString
            '(Integer.Parse(dGridAll.Rows(row).Cells(3 + b).Value) + Integer.Parse(value(0)(b + 3))).ToString
            subtotal += Integer.Parse(dGridAll.Rows(row).Cells(x).Value)
        Next
        dGridAll.Rows(row).Cells(12).Value = subtotal.ToString
        dGridAll.Rows(row).Cells(14).Value = (Integer.Parse(dGridAll.Rows(row).Cells(13).Value) * (Integer.Parse(dGridAll.Rows(row).Cells(12).Value)))

        updateGrand()
    End Sub
    Private Sub updateGrand()

        For b As Integer = 1 To 8
            Dim gt1 As Integer = 0
            Dim gt2 As Integer = 0
            Dim gt3 As Integer = 0
            For a As Integer = 0 To dGridAll.Rows.Count - 1
                gt1 += Integer.Parse(dGridAll.Rows(a).Cells(b + 3).Value)
                gt2 += Integer.Parse(dGridAll.Rows(a).Cells(12).Value)
                gt3 += Integer.Parse(dGridAll.Rows(a).Cells(15).Value)
            Next
            DataGridView1.Rows(0).Cells(b).Value = gt1.ToString
            txtotQty.Text = gt2.ToString
            If Label2.Text = "Penjualan Toko" Or Label2.Text = "Pengiriman" Then
                txGrandtotal2.Text = gt3.ToString
            Else
                txGrandtotal1.Text = gt3.ToString
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tanggal As DateTime = DateTimePicker1.Value.Date
        Dim tanggal1 As DateTime = DateTimePicker2.Value.Date

        If cbfaktur.Checked = True Then
            param = "where tb_pengirimandetail.kode = '" & txfaktur.Text & "'"
            dGridAll.Rows.Clear()
            loadGrid()
        ElseIf cbtoko.Checked = True Then
            param1 = " and c.tgl between '" & tanggal.ToMySql & "' and '" & tanggal1.Year & "-" & _
                    tanggal1.Month & "-" & tanggal1.Day & " 23:59:59' "

            param = "where namatoko = '" & txnama.Text & "' and tgl between '" & tanggal.ToMySql & "' and '" & tanggal1.Year & "-" & _
                tanggal1.Month & "-" & tanggal1.Day & " 23:59:59' "
            dGridAll.Rows.Clear()
            loadGrid()
        ElseIf cbtgl.Checked = True Then
            param1 = " and c.tgl between '" & tanggal.ToMySql & "' and '" & tanggal1.Year & "-" & _
                    tanggal1.Month & "-" & tanggal1.Day & " 23:59:59' "

            param = "tgl between '" & tanggal.ToMySql & "' and '" & tanggal1.Year & "-" & _
                tanggal1.Month & "-" & tanggal1.Day & " 23:59:59'"
            dGridAll.Rows.Clear()
            loadGrid()
        End If

    End Sub

End Class