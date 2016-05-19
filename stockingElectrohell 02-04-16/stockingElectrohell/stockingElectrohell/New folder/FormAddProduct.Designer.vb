<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddProduct
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txthrgpokok = New System.Windows.Forms.TextBox()
        Me.cmbukuran = New System.Windows.Forms.ComboBox()
        Me.cbaktif = New System.Windows.Forms.CheckBox()
        Me.txtkategori = New System.Windows.Forms.TextBox()
        Me.txtproduk = New System.Windows.Forms.TextBox()
        Me.txtkode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtWarna = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txthrgjual = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 127)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Harga Pokok"
        '
        'txthrgpokok
        '
        Me.txthrgpokok.Location = New System.Drawing.Point(122, 124)
        Me.txthrgpokok.Name = "txthrgpokok"
        Me.txthrgpokok.Size = New System.Drawing.Size(110, 20)
        Me.txthrgpokok.TabIndex = 9
        Me.txthrgpokok.Text = "0"
        '
        'cmbukuran
        '
        Me.cmbukuran.FormattingEnabled = True
        Me.cmbukuran.Location = New System.Drawing.Point(122, 150)
        Me.cmbukuran.Name = "cmbukuran"
        Me.cmbukuran.Size = New System.Drawing.Size(51, 21)
        Me.cmbukuran.TabIndex = 10
        '
        'cbaktif
        '
        Me.cbaktif.AutoSize = True
        Me.cbaktif.Location = New System.Drawing.Point(122, 177)
        Me.cbaktif.Name = "cbaktif"
        Me.cbaktif.Size = New System.Drawing.Size(15, 14)
        Me.cbaktif.TabIndex = 11
        Me.cbaktif.UseVisualStyleBackColor = True
        '
        'txtkategori
        '
        Me.txtkategori.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtkategori.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtkategori.Location = New System.Drawing.Point(122, 72)
        Me.txtkategori.Name = "txtkategori"
        Me.txtkategori.Size = New System.Drawing.Size(177, 20)
        Me.txtkategori.TabIndex = 7
        '
        'txtproduk
        '
        Me.txtproduk.Location = New System.Drawing.Point(122, 46)
        Me.txtproduk.Name = "txtproduk"
        Me.txtproduk.Size = New System.Drawing.Size(215, 20)
        Me.txtproduk.TabIndex = 6
        '
        'txtkode
        '
        Me.txtkode.Location = New System.Drawing.Point(122, 18)
        Me.txtkode.Name = "txtkode"
        Me.txtkode.Size = New System.Drawing.Size(215, 20)
        Me.txtkode.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Status Aktif"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Size"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Kategori"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Produk"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Kode Produk"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtWarna)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txthrgjual)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txthrgpokok)
        Me.GroupBox1.Controls.Add(Me.cmbukuran)
        Me.GroupBox1.Controls.Add(Me.cbaktif)
        Me.GroupBox1.Controls.Add(Me.txtkategori)
        Me.GroupBox1.Controls.Add(Me.txtproduk)
        Me.GroupBox1.Controls.Add(Me.txtkode)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(469, 233)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(183, 149)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(49, 20)
        Me.Button3.TabIndex = 34
        Me.Button3.Text = "Add"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(262, 98)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 20)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtWarna
        '
        Me.txtWarna.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtWarna.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtWarna.Location = New System.Drawing.Point(122, 98)
        Me.txtWarna.Name = "txtWarna"
        Me.txtWarna.Size = New System.Drawing.Size(134, 20)
        Me.txtWarna.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Warna"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(246, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Harga Jual"
        '
        'txthrgjual
        '
        Me.txthrgjual.Location = New System.Drawing.Point(310, 124)
        Me.txthrgjual.Name = "txthrgjual"
        Me.txthrgjual.Size = New System.Drawing.Size(117, 20)
        Me.txthrgjual.TabIndex = 29
        Me.txthrgjual.Text = "0"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(305, 72)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(49, 20)
        Me.Button2.TabIndex = 28
        Me.Button2.Text = "Add"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(499, 24)
        Me.MenuStrip1.TabIndex = 24
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.SaveToolStripMenuItem.Text = "&Simpan"
        '
        'FormAddProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(499, 272)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAddProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Products"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txthrgpokok As System.Windows.Forms.TextBox
    Friend WithEvents cmbukuran As System.Windows.Forms.ComboBox
    Friend WithEvents cbaktif As System.Windows.Forms.CheckBox
    Friend WithEvents txtkategori As System.Windows.Forms.TextBox
    Friend WithEvents txtproduk As System.Windows.Forms.TextBox
    Friend WithEvents txtkode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txthrgjual As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtWarna As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
