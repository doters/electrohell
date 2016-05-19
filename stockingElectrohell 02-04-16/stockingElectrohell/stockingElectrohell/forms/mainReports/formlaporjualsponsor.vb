Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class formlaporjualsponsor
    Dim clasq As New publicQuery
    Dim clasg As New gridQueries
    Dim clasgrid As New setDefaultGrid
    Dim clasc As New autoComplete
    Dim dt As DataTable
    Dim dr As MySqlDataReader
    Dim param As String = ""
    Dim param1 As String = ""
    Private Sub formlaporjualsponsor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadGrid()
        loadcom()
    End Sub
    Private Sub loadcom()
        For Each a As String In clasc.retComplete("select nama from tb_sponsor")
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
        tempdt1 = clasg.loadFilteredDataTable("select a.kodeItem as ItemCode, b.nama,b.color, b.kodeSize as Kode ,a.qty as qtyTotal,b.hargaJual " & _
                                              " from tb_produk b, tb_penjualandetail a,tb_penjualan c where a.kodeitem=b.kodeitem and b.status <> '' " & _
                                              " and a.kode=c.kode " & param1 & " group by a.kodeitem")

        tempdt2 = clasg.loadFilteredDataTable("SELECT kodeitem,value,sum(qty) as qty from tb_penjualandetail inner join tb_penjualan" & _
                                              " on tb_penjualandetail.kode = tb_penjualan.kode where " & param & _
                                              " group by kodeitem,value ")
        dt = clasgrid.loadFilterData(tempdt1, tempdt2, "Kode", "")

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

        ' txGrandtotal1.Visible = False
        'txGrandtotal2.Visible = True

    End Sub
    Private Sub rowTotalUpdate(value As DataRow, row As String)
        Dim subtotal As Integer = 0
        Dim moneyformat As Integer

        For x As Integer = 4 To 11
            dGridAll.Rows(row).Cells(x).Value = (Integer.Parse(dGridAll.Rows(row).Cells(x).Value) + Integer.Parse(value(x))).ToString
            '(Integer.Parse(dGridAll.Rows(row).Cells(3 + b).Value) + Integer.Parse(value(0)(b + 3))).ToString
            subtotal += Integer.Parse(dGridAll.Rows(row).Cells(x).Value)
        Next
        dGridAll.Rows(row).Cells(12).Value = Format(subtotal, "#,#0.00")
        moneyformat = (Integer.Parse(dGridAll.Rows(row).Cells(13).Value) * subtotal)
        dGridAll.Rows(row).Cells(14).Value = Format(moneyformat, "#,#0.00")

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
                gt3 += Double.Parse(dGridAll.Rows(a).Cells(14).Value)
            Next
            DataGridView1.Rows(0).Cells(b).Value = gt1.ToString
            txtotQty.Text = Format(gt2, "#,#0.00")
            '   If Label2.Text = "Penjualan Toko" Or Label2.Text = "Pengiriman" Then
            txGrandtotal1.Text = Format(gt3, "#,#0.00")
            'Else
            'txGrandtotal1.Text = gt3.ToString
            'End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tanggal As DateTime = DateTimePicker1.Value.Date
        Dim tanggal1 As DateTime = DateTimePicker2.Value.Date
        If cbfaktur.Checked = True Then
            param = "and tb_penjualandetail.kode = '" & txfaktur.Text & "'"
        ElseIf cbsponsor.Checked = True Then
            param1 = " and c.tgl between '" & tanggal.ToMySql & "' and '" & tanggal1.Year & "-" & _
                  tanggal1.Month & "-" & tanggal1.Day & " 23:59:59' and" ' c.mediajual = '" & cmbcatjual.SelectedItem & "' "

            param = " tb_penjualan.nama = '" & txnama.Text & "' and tb_penjualan.tgl between '" & tanggal.ToMySql & "' and '" & tanggal1.Year & "-" & _
                    tanggal1.Month & "-" & tanggal1.Day & " 23:59:59' "
        ElseIf cbtgl.Checked = True Then
            param = " tgl between '" & tanggal.ToMySql & "' and '" & tanggal1.Year & "-" & _
                    tanggal1.Month & "-" & tanggal1.Day & " 23:59:59' "
        End If
        dGridAll.Rows.Clear()
        loadGrid()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
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

        rpt.SetDataSource(dt)
        'rpt2.SetDataSource(dt2)
        rpt.Subreports("rptukuran.rpt").SetDataSource(dt2)
        viewreport.CrystalReportViewer1.ReportSource = rpt

        viewreport.ShowDialog()
    End Sub
End Class