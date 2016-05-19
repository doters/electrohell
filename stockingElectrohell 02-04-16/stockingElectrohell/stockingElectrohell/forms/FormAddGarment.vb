Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FormAddGarment
    Dim clasq As New publicQuery
    Dim dr As MySqlDataReader
    Dim active As String = "Aktive"
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If txtnama.Text = "" Or txtalamat.Text = "" Or txtcontact.Text = "" Or txttlp.Text = "" Then
            MsgBox("Please fill all the data field")
            Return
        End If
        MsgBox(clasq.insertQuery("insert into tb_garment values('" & _
                       txtnama.Text & "','" & txtalamat.Text & "','" & txttlp.Text & _
                       "','" & txtcontact.Text & _
                        "','" & active & "') on duplicate key update alamat='" & _
                       txtalamat.Text & "', tlp='" & txttlp.Text & "', coperson='" & txtcontact.Text & _
                        "',  status='" & active & "'"))
        FormToko_Garment.ActiveForm.Controls.Find("txFilter", True).First().Text = txtnama.Text
        For Each x As Control In Me.Controls
            If TypeOf x Is TextBox Then
                x.Text = ""
            End If
        Next
        If cbaktif.Checked = True Then
            cbaktif.Checked = False
        End If
    End Sub

    Private Sub txtnama_Leave(sender As Object, e As EventArgs) Handles txtnama.Leave
        Try
            dr = clasq.retDatareader("select * from tb_garment where namagarmen='" & txtnama.Text & "'")
            If dr.Read Then
                txtalamat.Text = dr(1).ToString
                txttlp.Text = dr(2).ToString
                txtcontact.Text = dr(3).ToString
                If dr(6).ToString = "Aktif" Then
                    cbaktif.Checked = True
                Else
                    cbaktif.Checked = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbaktif_CheckedChanged(sender As Object, e As EventArgs) Handles cbaktif.CheckedChanged
        If cbaktif.Checked = True Then
            active = "Aktif"
        Else
            active = "Tidak AKtif"
        End If
    End Sub

    Private Sub FormAddGarment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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