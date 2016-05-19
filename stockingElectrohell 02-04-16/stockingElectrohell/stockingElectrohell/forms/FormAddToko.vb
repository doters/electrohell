Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class FormAddToko
    Dim clasq As New publicQuery
    Dim dr As MySqlDataReader
    Dim active As String = "Active"
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            Integer.Parse(txtkonsi.Text)
        Catch ex As Exception
            MsgBox("Wrong Number")
            txtkonsi.Focus()
            Return
        End Try
        If txtnama.Text = "" Or txtalamat.Text = "" Or txtcontact.Text = "" Or cmbgrade.SelectedIndex = -1 Or txttlp.Text = "" Then
            MsgBox("Please fill all the data field")
            Return
        End If
        MsgBox(clasq.insertQuery("insert into tb_stores values('" & _
                       txtnama.Text & "','" & txtalamat.Text & "','" & txttlp.Text & _
                       "','" & txtcontact.Text & "','" & txtkonsi.Text & _
                       "','" & cmbgrade.SelectedItem.ToString & "','" & active & "') on duplicate key update alamat='" & _
                       txtalamat.Text & "', tlp='" & txttlp.Text & "', coperson='" & txtcontact.Text & _
                       "', disc='" & txtkonsi.Text & "', grade='" & cmbgrade.SelectedItem.ToString & "', status='" & active & "'"))
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
            dr = clasq.retDatareader("select * from tb_stores where namatoko='" & txtnama.Text & "'")
            If dr.Read Then
                txtalamat.Text = dr(1).ToString
                txttlp.Text = dr(2).ToString
                txtcontact.Text = dr(3).ToString
                txtkonsi.Text = dr(4).ToString
                cmbgrade.SelectedItem = dr(5).ToString
                If dr(6).ToString = "Active" Then
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
            active = "Active"
        Else
            active = "inactive"
        End If
    End Sub

    Private Sub FormAddToko_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub FormAddToko_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class