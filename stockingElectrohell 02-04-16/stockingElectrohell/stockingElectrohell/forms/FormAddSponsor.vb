

Public Class FormAddSponsor
    Dim clasq As New publicQuery
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If txtnama.Text = "" Or txtalamat.Text = "" Or txttlp.Text = "" Then
            MsgBox("Please fill all the data field")
            Return
        End If
        MsgBox(clasq.insertQuery("insert into tb_stores values('" & _
                       txtnama.Text & "','" & txtalamat.Text & "','" & txttlp.Text & _
                       "','100') on duplicate key update alamat='" & _
                       txtalamat.Text & "', tlp='" & txttlp.Text & "'"))
    End Sub

    Private Sub FormAddSponsor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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