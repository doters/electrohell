﻿Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class FormAddUser
    Dim dr As MySqlDataReader
    Dim clasq As New publicQuery
    Dim privilege As String
    Dim status As String = "Inactive"
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

        MsgBox(clasq.insertQuery("insert into tb_user values('" & txUser.Text & "','" & txPass.Text & _
                                 "','" & txNama.Text & "','" & cmbBagian.SelectedItem & "','" & privilege & "','" & _
                                 status & "')"))

        For Each x As Control In Me.Controls
            If TypeOf x Is TextBox Then
                x.Text = ""
            End If
        Next
        cmbBagian.SelectedIndex = -1
        cmbBagian.Text = ""
    End Sub

    Private Sub FormAddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dr = clasq.retDatareader("select section from tb_usercategory")
        cmbBagian.Items.Clear()
        While dr.Read
            cmbBagian.Items.Add(dr(0).ToString)
        End While
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBagian.SelectedIndexChanged
        dr = clasq.retDatareader("select privilege from tb_usercategory where section='" & cmbBagian.SelectedItem & "'")
        If dr.Read Then
            privilege = dr(0).ToString
        End If
    End Sub

    Private Sub txUser_Leave(sender As Object, e As EventArgs) Handles txUser.Leave
        dr = clasq.retDatareader("select * from tb_user where _username='" & txUser.Text & "'")
        If dr.Read Then
            MsgBox("Username Used please use another username")
            Return
        End If
    End Sub

    Private Sub FormAddUser_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        dr = clasq.retDatareader("select section from tb_usercategory")
        cmbBagian.Items.Clear()
        While dr.Read
            cmbBagian.Items.Add(dr(0).ToString)
        End While
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each F As Form In MainForm.MdiChildren
            'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
            If TypeOf F Is FormAddBagianKerja Then
                F.BringToFront()
                Return
            End If
        Next
        Dim x As New FormAddBagianKerja
        x.MdiParent = MainForm
        x.Show()
    End Sub

    Private Sub ViewAllUserToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            status = "Active"
        Else
            status = "Inactive"
        End If
    End Sub

    Private Sub FormAddUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
