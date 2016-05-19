<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddSUbProduct
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txthrgpokok = New System.Windows.Forms.TextBox()
        Me.txtkategori = New System.Windows.Forms.TextBox()
        Me.txtkode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtgridsub = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dtgridsub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSize)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txthrgpokok)
        Me.GroupBox1.Controls.Add(Me.txtkategori)
        Me.GroupBox1.Controls.Add(Me.txtkode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(315, 147)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item"
        '
        'txtSize
        '
        Me.txtSize.Enabled = False
        Me.txtSize.Location = New System.Drawing.Point(122, 74)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(50, 20)
        Me.txtSize.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Size"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(247, 22)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(52, 20)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "Browse"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Sell Price"
        '
        'txthrgpokok
        '
        Me.txthrgpokok.Enabled = False
        Me.txthrgpokok.Location = New System.Drawing.Point(122, 100)
        Me.txthrgpokok.Name = "txthrgpokok"
        Me.txthrgpokok.Size = New System.Drawing.Size(110, 20)
        Me.txthrgpokok.TabIndex = 3
        '
        'txtkategori
        '
        Me.txtkategori.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtkategori.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtkategori.Enabled = False
        Me.txtkategori.Location = New System.Drawing.Point(122, 48)
        Me.txtkategori.Name = "txtkategori"
        Me.txtkategori.Size = New System.Drawing.Size(177, 20)
        Me.txtkategori.TabIndex = 1
        '
        'txtkode
        '
        Me.txtkode.Location = New System.Drawing.Point(122, 22)
        Me.txtkode.Name = "txtkode"
        Me.txtkode.Size = New System.Drawing.Size(119, 20)
        Me.txtkode.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Category"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Code"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(490, 24)
        Me.MenuStrip1.TabIndex = 24
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'dtgridsub
        '
        Me.dtgridsub.AllowUserToAddRows = False
        Me.dtgridsub.AllowUserToDeleteRows = False
        Me.dtgridsub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgridsub.Location = New System.Drawing.Point(11, 180)
        Me.dtgridsub.Name = "dtgridsub"
        Me.dtgridsub.Size = New System.Drawing.Size(469, 225)
        Me.dtgridsub.TabIndex = 25
        '
        'FormAddSUbProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 409)
        Me.Controls.Add(Me.dtgridsub)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAddSUbProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Add Sub Product"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dtgridsub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txthrgpokok As System.Windows.Forms.TextBox
    Friend WithEvents txtkategori As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents dtgridsub As System.Windows.Forms.DataGridView
    Friend WithEvents txtSize As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents txtkode As System.Windows.Forms.TextBox
End Class
