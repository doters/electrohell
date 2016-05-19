Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class FormEditProduct
    Dim clasq As New publicQuery
    Dim clasg As New gridQueries
    Dim dr As MySqlDataReader
    Dim aktif As String = "Active"
    Private Sub txtkode_TextChanged(sender As Object, e As EventArgs) Handles txtkode.TextChanged
        dr = clasq.retDatareader("select * from tb_produk where kodeitem='" & txtkode.Text & "'")
        If dr.Read() Then
            txtproduk.Text = dr(1).ToString
            txtkategori.Text = dr(2).ToString
            txthrgpokok.Text = dr(3).ToString
            txthrgjual.Text = dr(4).ToString
            txtWarna.Text = dr(5).ToString
            txtSize.Text = dr(6).ToString
            aktif = dr(7).ToString
            If dr(7) = "Active" Then
                cbaktif.Checked = True
            Else
                cbaktif.Checked = False
            End If
        End If
        dr = clasq.retDatareader("select keterangan from tb_size where kode='" & txtSize.Text & "'")
        If dr.Read Then
            Label9.Text = dr(0).ToString
        End If
    End Sub

    Private Sub FormEditProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MainForm.txSession.Text = "Admin" Or MainForm.txSession.Text = "Accounting" Then
            txthrgjual.Enabled = True
        End If
    End Sub

    Private Sub SimpanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SimpanToolStripMenuItem.Click
        Dim x As Integer
        Dim result As Boolean = Integer.TryParse(txthrgjual.Text, x)
        If result = False Then
            MsgBox("Wrong Number")
            txthrgjual.Focus()
            Return
        End If
        MsgBox(clasq.updateQuery("update tb_produk set hargaJual='" & txthrgjual.Text & "', status='" & aktif & "' where kodeItem='" & _
                                 txtkode.Text & "' and warehouse='" & cmbGudang.SelectedIndex & "'"))
        FormProduct.ActiveForm.Controls.Find("txKode", True).First.Text = txtkode.Text
        For Each xz As Control In Me.Controls
            If TypeOf xz Is TextBox Then
                xz.Text = ""
            End If
        Next
        Me.Close()
    End Sub

    Private Sub FormEditProduct_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim kosong As Boolean = False

        For Each x As Control In GroupBox1.Controls
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

    Private Sub cbaktif_CheckedChanged(sender As Object, e As EventArgs) Handles cbaktif.CheckedChanged
        If cbaktif.Checked = True Then
            aktif = "Active"
        Else
            aktif = "Inactive"
        End If
    End Sub
End Class