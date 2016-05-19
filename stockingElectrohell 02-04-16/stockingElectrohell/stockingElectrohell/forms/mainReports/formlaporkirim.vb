Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class formlaporkirim
    Dim clasq As New publicQuery
    Dim clasg As New gridQueries
    Dim clasgrid As New setDefaultGrid
    Dim clasc As New autoComplete
    Dim dt As DataTable
    Dim dr As MySqlDataReader
    Dim disc As String = "0"
    Dim param As String = ""
    Dim param1 As String = ""

    Private Sub formlaporjualtoko_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadcom()
        loadSize()
        'loadGrid()
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
        tempdt1 = clasg.loadFilteredDataTable("select a.kodeItem as ItemCode, b.nama,b.color, b.kodeSize as Kode ,a.qty as qtyTotal,b.hargaJual" & _
                                               " from tb_produk b, tb_pengirimandetail a,tb_pengiriman c where a.kodeitem=b.kodeitem and b.status <> '' " & _
                                               " and a.kode=c.kode " & param1 & "group by a.kode")
        tempdt2 = clasg.loadFilteredDataTable("SELECT kodeitem,value,sum(qty) as qty from tb_pengirimandetail inner join tb_pengiriman" & _
                                              " on tb_pengirimandetail.kode = tb_pengiriman.kode " & param & _
                                              " group by kodeitem,value ")
        dt = clasgrid.loadFilterData(tempdt1, tempdt2, "Kode", "")

        If dt(0)(6).ToString = "" Then
            Return
        End If
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
                                    "0", "0", "0", "0", "0", "0", "0", "0", "0", dr(13).ToString, disc, "0"}
        dGridAll.Rows.Add(rows)
    End Sub
    Private Sub rowTotalUpdate(value As DataRow, row As String)
        Dim subtotal As Integer = 0
        Dim consformat As Integer
        Dim totalformat As Integer

        For x As Integer = 4 To 11
            dGridAll.Rows(row).Cells(x).Value = (Integer.Parse(dGridAll.Rows(row).Cells(x).Value) + Integer.Parse(value(x))).ToString
            subtotal += Integer.Parse(dGridAll.Rows(row).Cells(x).Value)
        Next
        dGridAll.Rows(row).Cells(12).Value = Format(subtotal, "#,#0.00")
        consformat = ((subtotal * Integer.Parse(dGridAll.Rows(row).Cells(13).Value)) * (Int(disc) / 100))
        dGridAll.Rows(row).Cells(14).Value = Format(consformat, "#,#0.00")
        totalformat = ((subtotal * Integer.Parse(dGridAll.Rows(row).Cells(13).Value)) - consformat)
        dGridAll.Rows(row).Cells(15).Value = Format(totalformat, "#,#0.00")

        updateGrand()
    End Sub
    Private Sub updateGrand()
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
                gt3 += Double.Parse(dGridAll.Rows(a).Cells(14).Value)
            Next
            DataGridView1.Rows(0).Cells(b).Value = gt1.ToString
            txtotQty.Text = Format(gt2, "#,#0.00")
            txGrandtotal2.Text = Format(gt3, "#,#0.00")
        Next
    End Sub

    Private Sub txnama_TextChanged(sender As Object, e As EventArgs) Handles txnama.TextChanged
        dr = clasq.retDatareader("select disc from tb_stores where namatoko='" & txnama.Text & "'")
        If dr.Read Then
            disc = dr(0).ToString

        End If
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

            param = " where namatoko = '" & txnama.Text & "' and tgl between '" & tanggal.ToMySql & "' and '" & tanggal1.Year & "-" & _
                tanggal1.Month & "-" & tanggal1.Day & " 23:59:59' "
            dGridAll.Rows.Clear()
            loadGrid()
        ElseIf cbtgl.Checked = True Then
            param1 = " and c.tgl between '" & tanggal.ToMySql & "' and '" & tanggal1.Year & "-" & _
                    tanggal1.Month & "-" & tanggal1.Day & " 23:59:59' "

            param = " tgl between '" & tanggal.ToMySql & "' and '" & tanggal1.Year & "-" & _
                tanggal1.Month & "-" & tanggal1.Day & " 23:59:59'"
            dGridAll.Rows.Clear()
            loadGrid()
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
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
            dt.Rows.Add(tgl, txfaktur.Text, txnama.Text, kategori, txnama.Text, dr.Cells(0).Value, dr.Cells(1).Value, dr.Cells(2).Value, _
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

        rpt1.SetDataSource(dt)
        'rpt2.SetDataSource(dt2)
        rpt1.Subreports("rptukuran.rpt").SetDataSource(dt2)
        viewreport.CrystalReportViewer1.ReportSource = rpt1

        viewreport.ShowDialog()

    End Sub
End Class