Public Class mainMenu
    Dim forms As New keyPress

    Private Sub linkbarang_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkProduct.LinkClicked
        forms.callForm("FormProduct", "", "", vbNull).Show()
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkHome.LinkClicked
        For Each F As Form In MainForm.MdiChildren
            F.Close()
        Next
        Dim x As New LoginForm
        x.MdiParent = MainForm
        x.Show()
    End Sub

    Private Sub linkcust_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkGarment.LinkClicked
        forms.callForm("FormToko_Garment", "Label3", "Garment", vbNull).Show()
    End Sub

    Private Sub linkpelanggan_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkStore.LinkClicked
        forms.callForm("FormToko_Garment", "Label3", "Store", vbNull).Show()
    End Sub

    Private Sub mainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MainForm.txSession.Text = "Admin" Then
            PictureBox17.Visible = True
            linkAddUser.Visible = True
        Else
            For Each x As Control In SplitContainer3.Panel1.Controls
                x.Visible = False
            Next
        End If
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        forms.callForm("FormAddBagianKerja", "", "", vbNull).Show()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkWareStock.LinkClicked
        forms.callForm("FormStokGudang", "", "", DockStyle.Fill).Show()
    End Sub

    Private Sub linkRecItem_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkRecItem.LinkClicked, linkSentItem.LinkClicked, linkWareSell.LinkClicked, linkStoreSell.LinkClicked, linkRetItem.LinkClicked, linkJualSponsor.LinkClicked
        Try
            Dim txt = DirectCast(sender, LinkLabel)

            If txt.Name = "linkRecItem" Then
                forms.callForm("formTerima", "", "", DockStyle.Fill).Show()
            ElseIf txt.Name = "linkSentItem" Then
                forms.callForm("formKirim", "", "", DockStyle.Fill).Show()
            ElseIf txt.Name = "linkWareSell" Then
                forms.callForm("formTerimaKirimJual", "Label2", "Penjualan Gudang", DockStyle.Fill).Show()
            ElseIf txt.Name = "linkStoreSell" Then
                forms.callForm("formTerimaKirimJual", "Label2", "Penjualan Toko", DockStyle.Fill).Show()
            ElseIf txt.Name = "linkRetItem" Then
                forms.callForm("formReturn", "", "", DockStyle.Fill).Show()
            ElseIf txt.Name = "linkJualSponsor" Then
                forms.callForm("formTerimaKirimJual", "Label2", "Sponsor", DockStyle.Fill).Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub linkRptRec_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkRptRec.LinkClicked
        forms.callForm("formlaporterima", "", "", DockStyle.Fill).Show()
    End Sub

    Private Sub linkRptSent_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkRptSent.LinkClicked
        forms.callForm("formlaporkirim", "", "", DockStyle.Fill).Show()
    End Sub

    Private Sub linkStoreStock_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkStoreStock.LinkClicked
        forms.callForm("FormStokToko", "", "", DockStyle.Fill).Show()
    End Sub

    Private Sub LinkSponsor_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSponsor.LinkClicked
        For Each F As Form In MainForm.MdiChildren
            'IF TYPE OF FORM IS SPECIFIC FORM WE WANT TO OPEN THEN FOCUS IT AND EXIT SUB
            If TypeOf F Is FormSponsor Then
                F.BringToFront()
                Return
            End If
        Next
        Dim x As New FormSponsor
        x.MdiParent = MainForm
        x.Show()
        forms.callForm("formlaporkirim", "", "", DockStyle.Fill).Show()
    End Sub

    Private Sub linkAddUser_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkAddUser.LinkClicked
        forms.callForm("FormAllUser", "", "", vbNull).Show()
    End Sub

    Private Sub linkRptStore_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkRptStore.LinkClicked
        forms.callForm("formlaporjualtoko", "", "", DockStyle.Fill).Show()
    End Sub

    Private Sub linkRptWare_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkRptWare.LinkClicked
        forms.callForm("formlaporjualgudang", "", "", DockStyle.Fill).Show()
    End Sub

    Private Sub linkRptRet_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkRptRet.LinkClicked
        forms.callForm("formlaporretur", "", "", DockStyle.Fill).Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        forms.callForm("formlaporjualsponsor", "", "", DockStyle.Fill).Show()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        forms.callForm("cekLaporan", "", "", DockStyle.Fill).Show()
    End Sub
End Class