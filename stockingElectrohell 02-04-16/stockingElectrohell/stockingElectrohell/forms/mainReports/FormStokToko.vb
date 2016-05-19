Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class FormStokToko

    Dim clasq As New publicQuery
    Dim clasg As New gridQueries
    Dim clasgrid As New setDefaultGrid
    Dim clasc As New autoComplete
    Dim dt As DataTable
    Dim dr As MySqlDataReader
    Dim disc As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dGridAll.Rows.Clear()


        loadSize()
        dr = clasq.retDatareader("select disc from tb_stores where namatoko='" & txtresi.Text & "'")
        If dr.Read Then
            disc = dr(0).ToString
        End If
        loadGrid()
    End Sub

    Private Sub loadSize()
        dt = clasgrid.setSize()
        dGridSize.DataSource = dt
        dGridSize.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dGridSize.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub
    Private Sub loadGrid()
        Dim tempdt1, tempdt2, tempdt3, tempdt4, tempdt5 As DataTable

        If DateTimePicker1.Value.Date = DateTime.Now.Date Then
            tempdt1 = clasg.loadFilteredDataTable("select a.kodeItem as ItemCode, b.nama,b.color, b.kodeSize as Kode ,a.qty as qtyTotal, b.hargaPokok, b.hargaJual, b.status" & _
                                              " from tb_produk b, tb_stoktokodetail a where a.kodeitem=b.kodeitem and " & _
                                              "a.kodeitem=b.kodeitem and a.namatoko='" & txtresi.Text & "' group by a.kodeitem")
            tempdt5 = clasg.loadFilteredDataTable("select kodeitem,value,sum(qty) as qty from tb_stoktokodetail  where namatoko='" & txtresi.Text & _
                                                  "' group by kodeitem,value")

        Else
            Dim tanggal As DateTime = DateTimePicker1.Value.Date.AddDays(1).ToMySql
            tempdt1 = clasg.loadFilteredDataTable("select a.kodeItem as ItemCode, b.nama,b.color, b.kodeSize as Kode ,a.qty as qtyTotal, b.hargaPokok, b.hargaJual, b.status" & _
                                              " from tb_produk b, tb_stoktokodetail a where a.kodeitem=b.kodeitem and " & _
                                              "a.kodeitem=b.kodeitem and a.namatoko='" & txtresi.Text & "' group by a.kodeitem")
            tempdt5 = clasg.loadFilteredDataTable("select kodeitem,value,sum(qty) as qty from tb_stoktokodetail  where namatoko='" & txtresi.Text & _
                                                 "' group by kodeitem,value")
            tempdt2 = clasg.loadFilteredDataTable("SELECT kodeitem,value,sum(qty) as qty from tb_pengirimandetail " & _
                                                  "inner join tb_pengiriman on tb_pengirimandetail.kode = tb_pengiriman.kode where tb_pengirimandetail.kode = tb_pengiriman.kode and tb_pengiriman.namatoko='" & _
                                                  txtresi.Text & "' and tb_pengiriman.tgl between '" & _
                                                  tanggal.ToMySql & "' and '" & DateTime.Now.ToMySql & "' group by tb_pengirimandetail.kodeitem,tb_pengirimandetail.value")
            tempdt3 = clasg.loadFilteredDataTable("SELECT kodeitem,value,qty from tb_penjualandetail " & _
                                                  "inner join tb_penjualan on tb_penjualandetail.kode = tb_penjualan.kode where tb_penjualandetail.kode = tb_penjualan.kode and tb_penjualan.nama='" & _
                                                  txtresi.Text & "' and tb_penjualan.tgl between '" & _
                                                  tanggal.ToMySql & "' and '" & DateTime.Now.ToMySql & "' group by tb_penjualandetail.kodeitem,tb_penjualandetail.value")
            tempdt4 = clasg.loadFilteredDataTable("SELECT kodeitem,value,qty from tb_returndetail " & _
                                                  "inner join tb_return on tb_returndetail.kode = tb_return.kode where tb_returndetail.kode = tb_return.kode and tb_return.nama='" & _
                                                  txtresi.Text & "' and tb_return.tgl between '" & _
                                                  tanggal.ToMySql & "' and '" & DateTime.Now.ToMySql & "' group by tb_returndetail.kodeitem,tb_returndetail.value")

            For a As Integer = 0 To tempdt5.Rows.Count - 1
                Dim tabrow1(), tabrow2(), tabrow3() As DataRow
                Dim intstok, intkirim, intjual, intreturn As Integer
                tabrow1 = tempdt2.Select("KodeItem='" & tempdt5.Rows(a)(0) & "' and value='" & tempdt5.Rows(a)(1) & "'")
                tabrow2 = tempdt3.Select("KodeItem='" & tempdt5.Rows(a)(0) & "' and value='" & tempdt5.Rows(a)(1) & "'")
                tabrow3 = tempdt4.Select("KodeItem='" & tempdt5.Rows(a)(0) & "' and value='" & tempdt5.Rows(a)(1) & "'")
                intstok = Integer.Parse(tempdt5.Rows(a)(2))
                If tabrow1.Count >= 1 Then
                    intkirim = Integer.Parse(tabrow1(0)(2))
                Else
                    intkirim = 0
                End If
                If tabrow2.Count >= 1 Then
                    intjual = Integer.Parse(tabrow2(0)(2))
                Else
                    intjual = 0
                End If
                If tabrow3.Count >= 1 Then
                    intreturn = Integer.Parse(tabrow3(0)(2))
                Else
                    intreturn = 0
                End If
                tempdt5.Rows(a)(2) = ((intstok + intjual + intreturn) - intkirim).ToString
                'MsgBox(intstok & " - " & intjual & " - " & intreturn & " - " & intkirim)
            Next
        End If
        dt = clasgrid.loadFilterData(tempdt1, tempdt5, "Kode", "")

        'MsgBox(dt(0)(0))
        For a As Integer = 0 To dt.Rows.Count - 1
            Dim cek As Boolean = False
            If dGridAll.Rows.Count = 0 Then
                initGrid(dt(a))
                rowTotalUpdate(dt(a), "0")
            Else
                For x As Integer = 0 To dGridAll.Rows.Count - 1
                    If dGridAll.Rows(x).Cells(0).Value = dt(a)(0).ToString Then

                        rowTotalUpdate(dt(a), x)
                        cek = True
                    End If
                Next
                If cek = False Then
                    initGrid(dt(a))
                    rowTotalUpdate(dt(a), dGridAll.Rows.Count - 1)
                End If
            End If
        Next

    End Sub
    Private Sub initGrid(dr As DataRow)
        Dim rows As String() = {dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString, _
                                    "0", "0", "0", "0", "0", "0", "0", "0", "0", dr(14).ToString, "0", "0"}
        dGridAll.Rows.Add(rows)
    End Sub
    Private Sub rowTotalUpdate(value As DataRow, row As String)
        Dim subtotal As Integer = 0

        For x As Integer = 4 To 11
            'MsgBox(value(x))
            dGridAll.Rows(row).Cells(x).Value = (Integer.Parse(dGridAll.Rows(row).Cells(x).Value) + Integer.Parse(value(x))).ToString
            '(Integer.Parse(dGridAll.Rows(row).Cells(3 + b).Value) + Integer.Parse(value(0)(b + 3))).ToString
            subtotal += Integer.Parse(dGridAll.Rows(row).Cells(x).Value)
        Next
        dGridAll.Rows(row).Cells(12).Value = subtotal.ToString
        dGridAll.Rows(row).Cells(14).Value = disc
        dGridAll.Rows(row).Cells(15).Value = (subtotal * (Integer.Parse(dGridAll.Rows(row).Cells(13).Value) - _
                (Integer.Parse(dGridAll.Rows(row).Cells(13).Value) * (Integer.Parse(dGridAll.Rows(row).Cells(14).Value) / 100))))
        updateGrand()
    End Sub
    Private Sub updateGrand()
        'MsgBox(DataGridView1.Rows(0).Cells(1).Value)
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Insert(0, "", "0", "0", "0", "0", "0", "0", "0", "0")
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        For b As Integer = 1 To 8
            Dim gt1 As Double = 0
            Dim gt2 As Double = 0
            Dim gt3 As Double = 0
            For a As Integer = 0 To dGridAll.Rows.Count - 1
                gt1 += Double.Parse(dGridAll.Rows(a).Cells(b + 3).Value)
                gt2 += Double.Parse(dGridAll.Rows(a).Cells(12).Value)
                gt3 += Double.Parse(dGridAll.Rows(a).Cells(15).Value)
            Next
            DataGridView1.Rows(0).Cells(b).Value = gt1.ToString
            txtotQty.Text = gt2.ToString
            '   If Label2.Text = "Penjualan Toko" Or Label2.Text = "Pengiriman" Then
            txGrandtotal2.Text = gt3.ToString
            'Else
            'txGrandtotal1.Text = gt3.ToString
            'End If
        Next
    End Sub

    Private Sub FormStokToko_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtresi.AutoCompleteCustomSource = clasc.retComplete("select namatoko from tb_stores")
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Print()
    End Sub
    Private Sub print()
        Dim tgl As String = Now.ToShortDateString
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim rpt As New rpttrans
        Dim rpt1 As New rptkirim
        Dim rpt2 As New rptukuran
        Dim kategori As String = Me.Text
        With dt
            .Columns.Add("tanggal")
            .Columns.Add("bill")
            .Columns.Add("nama") 'nama garmen / toko
            .Columns.Add("kategori")
            .Columns.Add("statretur")
            .Columns.Add("kode")
            .Columns.Add("produk")
            .Columns.Add("warna")
            .Columns.Add("size")
            .Columns.Add("s1")
            .Columns.Add("s2")
            .Columns.Add("s3")
            .Columns.Add("s4")
            .Columns.Add("s5")
            .Columns.Add("s6")
            .Columns.Add("s7")
            .Columns.Add("s8")
            .Columns.Add("ttlqty")
            .Columns.Add("hrg")
            .Columns.Add("cons")
            .Columns.Add("total")
            .Columns.Add("tot1")
            .Columns.Add("tot2")
            .Columns.Add("tot3")
            .Columns.Add("tot4")
            .Columns.Add("tot5")
            .Columns.Add("tot6")
            .Columns.Add("tot7")
            .Columns.Add("tot8")
            .Columns.Add("totqty")
            .Columns.Add("grand")
        End With

        With dt2
            .Columns.Add("s1")
            .Columns.Add("s2")
            .Columns.Add("s3")
            .Columns.Add("s4")
            .Columns.Add("s5")
            .Columns.Add("s6")
            .Columns.Add("s7")
            .Columns.Add("s8")
        End With

        For Each dr As DataGridViewRow In Me.dGridAll.Rows
            dt.Rows.Add(tgl, DateTimePicker1.Text, DateTimePicker1.Text, kategori, DateTimePicker1.Text, dr.Cells(0).Value, dr.Cells(1).Value, dr.Cells(2).Value, _
                        dr.Cells(3).Value, dr.Cells(4).Value, dr.Cells(5).Value, dr.Cells(6).Value, dr.Cells(7).Value, dr.Cells(8).Value, dr.Cells(9).Value, _
                        dr.Cells(10).Value, dr.Cells(11).Value, dr.Cells(12).Value, dr.Cells(13).Value, dr.Cells(14).Value, dr.Cells(15).Value, _
                        DataGridView1.Rows(0).Cells(1).Value, DataGridView1.Rows(0).Cells(2).Value, DataGridView1.Rows(0).Cells(3).Value, _
                        DataGridView1.Rows(0).Cells(4).Value, DataGridView1.Rows(0).Cells(5).Value, DataGridView1.Rows(0).Cells(6).Value, _
                        DataGridView1.Rows(0).Cells(7).Value, DataGridView1.Rows(0).Cells(8).Value, txtotQty.Text, txGrandtotal1.Text)
        Next
        For Each dr2 As DataGridViewRow In Me.dGridSize.Rows
            dt2.Rows.Add(dr2.Cells(1).Value, dr2.Cells(2).Value, dr2.Cells(3).Value, dr2.Cells(4).Value, dr2.Cells(5).Value, _
            dr2.Cells(6).Value, dr2.Cells(7).Value, dr2.Cells(8).Value)
        Next

        rpt.SetDataSource(dt)
        'rpt2.SetDataSource(dt2)
        rpt.Subreports("rptukuran.rpt").SetDataSource(dt2)
        viewreport.CrystalReportViewer1.ReportSource = rpt

        viewreport.ShowDialog()

    End Sub
End Class