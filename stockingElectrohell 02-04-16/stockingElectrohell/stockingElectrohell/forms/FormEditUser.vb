Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class FormEditUser
    Dim dr As MySqlDataReader
    Dim clasq As New publicQuery

    Dim privilege As String
    Dim status As String = "Active"

    Private Sub txUser_TextChanged(sender As Object, e As EventArgs) Handles txUser.TextChanged
        dr = clasq.retDatareader("select * from tb_user where lower(_username)='" & txUser.Text.ToLower & "'")
        If dr.Read Then
            txNama.Text = dr(2).ToString
            cmbBagian.SelectedItem = dr(3)
            If dr(5).ToString = "Active" Then
                CheckBox1.Checked = True
            Else
                CheckBox1.Checked = False
            End If
        End If

    End Sub

    Private Sub cmbBagian_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBagian.SelectedIndexChanged
        dr = clasq.retDatareader("select privilege from tb_usercategory where section='" & cmbBagian.SelectedItem & "'")
        If dr.Read Then
            privilege = dr(0).ToString
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            status = "Active"
        Else
            status = "Inactive"
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim cek As Boolean = False
        For Each x As Control In Me.Controls
            If TypeOf x Is TextBox And x.Text = "" Then
                cek = True
            End If
        Next
        If cmbBagian.SelectedIndex = -1 Then
            cek = True
        End If
        If cek Then
            MsgBox("Please fill all the data field")
            Return
        End If

        MsgBox(clasq.updateQuery("update tb_user set _password='" & txPass.Text & "',nama='" & txNama.Text & _
                                 "',section='" & cmbBagian.SelectedItem & "', privilege='" & privilege & _
                                 "', status='" & status & "' where lower(_username)='" & txUser.Text.ToLower & "'"))

        For Each x As Control In Me.Controls
            If TypeOf x Is TextBox Then
                x.Text = ""
            End If
        Next
        cmbBagian.SelectedIndex = -1
        cmbBagian.Text = ""
        FormAllUser.Activate()
        Close()
    End Sub

    Private Sub FormEditUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub FormEditUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dr = clasq.retDatareader("select section from tb_usercategory")
        cmbBagian.Items.Clear()
        While dr.Read
            cmbBagian.Items.Add(dr(0).ToString)
        End While
    End Sub
End Class