Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class FormStokGudang
    Dim clasq As New publicQuery
    Dim clasg As New gridQueries
    Dim clasgrid As New setDefaultGrid
    Dim clasc As New autoComplete
    Dim dt As DataTable
    Dim dr As MySqlDataReader
    Dim param As String = "<>''"
    Private Sub FormStok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel10.Height = SplitContainer1.Panel2.Height - 285
        cmbGudang.Items.Clear()
        For Each a As String In clasc.retComplete("select warehousename from tb_warehouse")
            cmbGudang.Items.Add(a)
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
        tempdt1 = clasg.loadFilteredDataTable("select a.kodeItem as ItemCode, b.nama, b.color, b.kodeSize as Kode, a.qty as qtyTotal, b.hargaPokok, b.hargaJual, b.status" & _
                                      " from tb_produk b, tb_stokgudang a where  a.kodeitem=b.kodeitem and b.status " & param)
        tempdt2 = clasg.loadFilteredDataTable("select *  from tb_stokgudangdetail")
        dt = clasgrid.loadFilterData(tempdt1, tempdt2, "Kode", "")

        For a As Integer = 0 To dt.Rows.Count - 1
            Dim rows As String() = {dt(a)(0).ToString, dt(a)(1).ToString, dt(a)(2).ToString, dt(a)(3).ToString, _
                                                "0", "0", "0", "0", "0", "0", "0", "0", "0", dt(a)(14).ToString, "0", "0"}
            dGridAll.Rows.Add(rows)
            For b As Integer = 0 To dGridAll.Columns.Count - 1
                dGridAll.Rows(a).Cells(b).Value = dt.Rows(a)(b)
            Next
            If dGridAll.Rows(a).Cells(14).Value = "Tidak Aktif" Then
                dGridAll.RowsDefaultCellStyle.BackColor = Drawing.Color.Aqua
            End If
        Next
    End Sub

    Private Sub loadGrid2()
        Dim tempdt1, tempdt2, tempdt3, tempdt4, tempdt5, tempdt6, tempdt7 As DataTable

        If DateTimePicker1.Value.Date = DateTime.Now.Date Then
            tempdt1 = clasg.loadFilteredDataTable("select a.kodeItem as ItemCode, b.nama, b.color, b.kodeSize as Kode, a.qty as qtyTotal, b.hargaPokok, b.hargaJual, b.status" & _
                                      " from tb_produk b, tb_stokgudang a where a.kodeitem=b.kodeitem and a.warehouse='" & _
                                      cmbGudang.SelectedIndex & "' and b.status " & param)

            tempdt2 = clasg.loadFilteredDataTable("select *  from tb_stokgudangdetail")
        Else
            Dim tanggal As DateTime = DateTimePicker1.Value.Date.AddDays(1).ToMySql
            tempdt1 = clasg.loadFilteredDataTable("select a.kodeItem as ItemCode, b.nama, b.color, b.kodeSize as Kode, a.qty as qtyTotal, b.hargaPokok, b.hargaJual, b.status" & _
                                     " from tb_produk b, tb_stokgudang a where a.kodeitem=b.kodeitem and a.warehouse='" _
                                     & cmbGudang.SelectedIndex & "' and b.status " & param)

            tempdt2 = clasg.loadFilteredDataTable("select kodeitem, value, sum(qty) as qty  from tb_stokgudangdetail group by kodeitem,value")

            tempdt3 = clasg.loadFilteredDataTable("SELECT kodeitem,value,sum(qty) as qty from tb_pengirimandetail " & _
                                                  "inner join tb_pengiriman on tb_pengirimandetail.kode = tb_pengiriman.kode " & _
                                                  "where tb_pengirimandetail.kode = tb_pengiriman.kode " & _
                                                   "and tb_pengiriman.warehouse='" & cmbGudang.SelectedIndex & _
                                                   "' and tb_pengiriman.tgl between '" & _
                                                  tanggal.ToMySql & "' and '" & DateTime.Now.ToMySql & _
                                                  "' group by tb_pengirimandetail.kodeitem,tb_pengirimandetail.value")

            tempdt4 = clasg.loadFilteredDataTable("SELECT kodeitem,value,qty from tb_penerimaandetail " & _
                                                  "inner join tb_penerimaan on tb_penerimaandetail.kode = tb_penerimaan.kode " & _
                                                  "where tb_penerimaandetail.kode = tb_penerimaan.kode" & _
                                                  " and tb_penerimaan.warehouse='" & cmbGudang.SelectedIndex & _
                                                  "' and tb_penerimaan.tgl between '" & _
                                                  tanggal.ToMySql & "' and '" & DateTime.Now.ToMySql & "' group by tb_penerimaandetail.kodeitem,tb_penerimaandetail.value")

            tempdt5 = clasg.loadFilteredDataTable("SELECT kodeitem,value,sum(qty) as qty from tb_penjualandetail " & _
                                                  "inner join tb_penjualan on tb_penjualandetail.kode = tb_penjualan.kode " & _
                                                  "where tb_penjualandetail.kode = tb_penjualan.kode " & _
                                                  "and tb_penjualan.warehouse='" & cmbGudang.SelectedIndex & _
                                                   "' and tb_penjualan.tgl between '" & tanggal.ToMySql & _
                                                   "' and '" & DateTime.Now.ToMySql & _
                                                   "' and tb_penjualan.statJual='Gudang' group by tb_penjualandetail.kodeitem,tb_penjualandetail.value")

            tempdt6 = clasg.loadFilteredDataTable("SELECT kodeitem,value,qty from tb_returndetail " & _
                                                  "inner join tb_return on tb_returndetail.kode = tb_return.kode " & _
                                                  "where tb_returndetail.kode = tb_return.kode and tb_return.status='Toko'" & _
                                                  " and tb_return.warehouse='" & cmbGudang.SelectedIndex & _
                                                  "' and tb_return.tgl between '" & _
                                                  tanggal.ToMySql & "' and '" & DateTime.Now.ToMySql & "' group by tb_returndetail.kodeitem,tb_returndetail.value")

            tempdt7 = clasg.loadFilteredDataTable("SELECT kodeitem,value,qty from tb_returndetail " & _
                                                  "inner join tb_return on tb_returndetail.kode = tb_return.kode " & _
                                                  "where tb_returndetail.kode = tb_return.kode and tb_return.status='Garmen'" & _
                                                  " and tb_return.warehouse='" & cmbGudang.SelectedIndex & _
                                                  "' and tb_return.tgl between '" & _
                                                  tanggal.ToMySql & "' and '" & DateTime.Now.ToMySql & "' group by tb_returndetail.kodeitem,tb_returndetail.value")

            For a As Integer = 0 To tempdt2.Rows.Count - 1
                Dim tabrow1(), tabrow2(), tabrow3(), tabrow4(), tabrow5() As DataRow
                Dim intstok, intterima, intkirim, intjual, intreturntoko, intreturngarmen As Integer
                tabrow1 = tempdt3.Select("KodeItem='" & tempdt2.Rows(a)(0) & "' and value='" & tempdt2.Rows(a)(1) & "'") 'kirim
                tabrow2 = tempdt4.Select("KodeItem='" & tempdt2.Rows(a)(0) & "' and value='" & tempdt2.Rows(a)(1) & "'") 'terima
                tabrow3 = tempdt5.Select("KodeItem='" & tempdt2.Rows(a)(0) & "' and value='" & tempdt2.Rows(a)(1) & "'") 'jual
                tabrow4 = tempdt6.Select("KodeItem='" & tempdt2.Rows(a)(0) & "' and value='" & tempdt2.Rows(a)(1) & "'") 'rettoko
                tabrow5 = tempdt7.Select("KodeItem='" & tempdt2.Rows(a)(0) & "' and value='" & tempdt2.Rows(a)(1) & "'") 'retgarmen
                intstok = Integer.Parse(tempdt2.Rows(a)(2))

                If tabrow1.Count >= 1 Then
                    intkirim = Integer.Parse(tabrow1(0)(2))
                Else
                    intkirim = 0
                End If
                If tabrow2.Count >= 1 Then
                    intterima = Integer.Parse(tabrow2(0)(2))
                Else
                    intterima = 0
                End If
                If tabrow3.Count >= 1 Then
                    intjual = Integer.Parse(tabrow3(0)(2))
                Else
                    intjual = 0
                End If
                If tabrow4.Count >= 1 Then
                    intreturntoko = Integer.Parse(tabrow4(0)(2))
                Else
                    intreturntoko = 0
                End If
                If tabrow5.Count >= 1 Then
                    intreturngarmen = Integer.Parse(tabrow5(0)(2))
                Else
                    intreturngarmen = 0
                End If
                tempdt2.Rows(a)(2) = ((intstok + intjual + intreturngarmen + intkirim) - (intreturntoko + intterima)).ToString
            Next
        End If
        dt = clasgrid.loadFilterData(tempdt1, tempdt2, "Kode", "")

        For a As Integer = 0 To dt.Rows.Count - 1
            Dim rows As String() = {dt(a)(0).ToString, dt(a)(1).ToString, dt(a)(2).ToString, dt(a)(3).ToString, _
                                               "0", "0", "0", "0", "0", "0", "0", "0", "0", dt(a)(14).ToString, "0", "0"}
            dGridAll.Rows.Add(rows)
            For b As Integer = 0 To dGridAll.Columns.Count - 1
                dGridAll.Rows(a).Cells(b).Value = dt.Rows(a)(b)
            Next
            If dGridAll.Rows(a).Cells(14).Value = "Tidak Aktif" Then
                dGridAll.RowsDefaultCellStyle.BackColor = Drawing.Color.Aqua
            End If
        Next

    End Sub

    Private Sub updateGrand()
        'MsgBox(DataGridView1.Rows(0).Cells(1).Value)
        txtotQty.Text = "0"
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Insert(0, "", "0", "0", "0", "0", "0", "0", "0", "0")
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        If dGridAll.Rows.Count >= 1 Then
            For b As Integer = 1 To 8
                Dim gt1 As Integer = 0
                Dim gt2 As Integer = 0
                Dim gt3 As Integer = 0
                Dim gt4 As Integer = 0

                For a As Integer = 0 To dGridAll.Rows.Count - 1
                    gt1 += Integer.Parse(dGridAll.Rows(a).Cells(b + 3).Value)
                    gt2 += Integer.Parse(dGridAll.Rows(a).Cells(12).Value) 'totqty
                    gt3 += Integer.Parse(dGridAll.Rows(a).Cells(14).Value) 'totprice
                    gt4 += Integer.Parse(dGridAll.Rows(a).Cells(13).Value) 'price
                Next
                DataGridView1.Rows(0).Cells(b).Value = gt1.ToString
                txtotQty.Text = Format(gt2, "#,#0.00")
                txGrandtotal1.Text = Format(gt3, "#,#0.00")
                txtotPrice.Text = Format(gt4, "#,#0.00")
            Next
        End If

    End Sub

    Private Sub cbAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbAll.CheckedChanged
        If cbAll.Checked = True Then
            cbAktif.Checked = False
            cbTaktif.Checked = False
            param = "<>''"
            dGridAll.Rows.Clear()
            loadGrid()
            updateGrand()
        End If
    End Sub

    Private Sub cbAktif_CheckedChanged(sender As Object, e As EventArgs) Handles cbAktif.CheckedChanged
        If cbAktif.Checked = True Then
            cbAll.Checked = False
            cbTaktif.Checked = False
            param = "='Aktif'"
            dGridAll.Rows.Clear()
            loadGrid()
            updateGrand()
        End If
    End Sub

    Private Sub cbTaktif_CheckedChanged(sender As Object, e As EventArgs) Handles cbTaktif.CheckedChanged
        If cbTaktif.Checked = True Then
            cbAktif.Checked = False
            cbAll.Checked = False
            param = "='Tidak Aktif'"
            dGridAll.Rows.Clear()
            loadGrid()
            updateGrand()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dGridAll.Rows.Clear()
        loadGrid2()
        updateGrand()
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