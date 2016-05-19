<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddSize
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewAllSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtKeterangan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dGridView = New System.Windows.Forms.DataGridView()
        Me.txtkode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.ViewAllSizeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(497, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'ViewAllSizeToolStripMenuItem
        '
        Me.ViewAllSizeToolStripMenuItem.Name = "ViewAllSizeToolStripMenuItem"
        Me.ViewAllSizeToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.ViewAllSizeToolStripMenuItem.Text = "&View All Size"
        '
        'txtKeterangan
        '
        Me.txtKeterangan.Location = New System.Drawing.Point(82, 61)
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(257, 20)
        Me.txtKeterangan.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Description"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dGridView)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(470, 180)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Size"
        '
        'dGridView
        '
        Me.dGridView.AllowUserToDeleteRows = False
        Me.dGridView.AllowUserToResizeColumns = False
        Me.dGridView.ColumnHeadersHeight = 21
        Me.dGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridView.Location = New System.Drawing.Point(3, 16)
        Me.dGridView.Name = "dGridView"
        Me.dGridView.RowHeadersWidth = 4
        Me.dGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dGridView.Size = New System.Drawing.Size(464, 161)
        Me.dGridView.TabIndex = 9
        '
        'txtkode
        '
        Me.txtkode.Location = New System.Drawing.Point(82, 35)
        Me.txtkode.Name = "txtkode"
        Me.txtkode.Size = New System.Drawing.Size(61, 20)
        Me.txtkode.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Size Code"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(149, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(21, 21)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "+"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormAddSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 279)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtKeterangan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtkode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAddSize"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Size"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewAllSizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dGridView As System.Windows.Forms.DataGridView
    Friend WithEvents txtkode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
