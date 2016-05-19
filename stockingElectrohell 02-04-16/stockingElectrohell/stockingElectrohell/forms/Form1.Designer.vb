<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.dGridAll = New System.Windows.Forms.DataGridView()
        Me.KodeItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.namaItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.size1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.size2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.size3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.size4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.size5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.size6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.size7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.size8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cons = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.dGridSize = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel10.SuspendLayout()
        CType(Me.dGridAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dGridSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.dGridAll)
        Me.Panel10.Location = New System.Drawing.Point(-313, 208)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1318, 304)
        Me.Panel10.TabIndex = 10
        '
        'dGridAll
        '
        Me.dGridAll.AllowUserToAddRows = False
        Me.dGridAll.AllowUserToDeleteRows = False
        Me.dGridAll.AllowUserToResizeColumns = False
        Me.dGridAll.AllowUserToResizeRows = False
        Me.dGridAll.ColumnHeadersHeight = 21
        Me.dGridAll.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KodeItem, Me.namaItem, Me.color, Me.SizeCode, Me.size1, Me.size2, Me.size3, Me.size4, Me.size5, Me.size6, Me.size7, Me.size8, Me.qty, Me.price, Me.cons, Me.totPrice})
        Me.dGridAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridAll.Location = New System.Drawing.Point(0, 0)
        Me.dGridAll.Name = "dGridAll"
        Me.dGridAll.ReadOnly = True
        Me.dGridAll.RowHeadersWidth = 4
        Me.dGridAll.Size = New System.Drawing.Size(1318, 304)
        Me.dGridAll.TabIndex = 4
        '
        'KodeItem
        '
        Me.KodeItem.HeaderText = "Item Code"
        Me.KodeItem.Name = "KodeItem"
        Me.KodeItem.ReadOnly = True
        Me.KodeItem.Width = 150
        '
        'namaItem
        '
        Me.namaItem.HeaderText = "Product Name"
        Me.namaItem.Name = "namaItem"
        Me.namaItem.ReadOnly = True
        Me.namaItem.Width = 167
        '
        'color
        '
        Me.color.HeaderText = "Color"
        Me.color.Name = "color"
        Me.color.ReadOnly = True
        Me.color.Width = 117
        '
        'SizeCode
        '
        Me.SizeCode.HeaderText = "Kode"
        Me.SizeCode.Name = "SizeCode"
        Me.SizeCode.ReadOnly = True
        Me.SizeCode.Width = 60
        '
        'size1
        '
        Me.size1.HeaderText = "S1"
        Me.size1.Name = "size1"
        Me.size1.ReadOnly = True
        Me.size1.Width = 50
        '
        'size2
        '
        Me.size2.HeaderText = "S2"
        Me.size2.Name = "size2"
        Me.size2.ReadOnly = True
        Me.size2.Width = 50
        '
        'size3
        '
        Me.size3.HeaderText = "S3"
        Me.size3.Name = "size3"
        Me.size3.ReadOnly = True
        Me.size3.Width = 50
        '
        'size4
        '
        Me.size4.HeaderText = "S4"
        Me.size4.Name = "size4"
        Me.size4.ReadOnly = True
        Me.size4.Width = 50
        '
        'size5
        '
        Me.size5.HeaderText = "S5"
        Me.size5.Name = "size5"
        Me.size5.ReadOnly = True
        Me.size5.Width = 50
        '
        'size6
        '
        Me.size6.HeaderText = "S6"
        Me.size6.Name = "size6"
        Me.size6.ReadOnly = True
        Me.size6.Width = 50
        '
        'size7
        '
        Me.size7.HeaderText = "S7"
        Me.size7.Name = "size7"
        Me.size7.ReadOnly = True
        Me.size7.Width = 50
        '
        'size8
        '
        Me.size8.HeaderText = "S8"
        Me.size8.Name = "size8"
        Me.size8.ReadOnly = True
        Me.size8.Width = 58
        '
        'qty
        '
        Me.qty.HeaderText = "Total Qty"
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        Me.qty.Width = 50
        '
        'price
        '
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        Me.price.Width = 117
        '
        'cons
        '
        Me.cons.HeaderText = "Cons (%)"
        Me.cons.Name = "cons"
        Me.cons.ReadOnly = True
        Me.cons.Visible = False
        Me.cons.Width = 122
        '
        'totPrice
        '
        Me.totPrice.HeaderText = "Total Price"
        Me.totPrice.Name = "totPrice"
        Me.totPrice.ReadOnly = True
        Me.totPrice.Width = 120
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.TextBox8)
        Me.Panel9.Location = New System.Drawing.Point(882, -43)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(123, 250)
        Me.Panel9.TabIndex = 19
        '
        'TextBox8
        '
        Me.TextBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox8.Enabled = False
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(0, 0)
        Me.TextBox8.Multiline = True
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(123, 250)
        Me.TextBox8.TabIndex = 7
        Me.TextBox8.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Total" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Price"
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.TextBox7)
        Me.Panel8.Location = New System.Drawing.Point(760, -43)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(121, 250)
        Me.Panel8.TabIndex = 18
        '
        'TextBox7
        '
        Me.TextBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox7.Enabled = False
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(0, 0)
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(121, 250)
        Me.TextBox7.TabIndex = 6
        Me.TextBox7.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Total" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Price"
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.TextBox6)
        Me.Panel7.Location = New System.Drawing.Point(644, -43)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(115, 250)
        Me.Panel7.TabIndex = 15
        '
        'TextBox6
        '
        Me.TextBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox6.Enabled = False
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(0, 0)
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(115, 250)
        Me.TextBox6.TabIndex = 5
        Me.TextBox6.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Price"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.TextBox5)
        Me.Panel6.Location = New System.Drawing.Point(593, -43)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(50, 250)
        Me.Panel6.TabIndex = 16
        '
        'TextBox5
        '
        Me.TextBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox5.Enabled = False
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(0, 0)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(50, 250)
        Me.TextBox5.TabIndex = 6
        Me.TextBox5.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Total" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Qty"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.dGridSize)
        Me.Panel5.Location = New System.Drawing.Point(125, 14)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(467, 193)
        Me.Panel5.TabIndex = 17
        '
        'dGridSize
        '
        Me.dGridSize.AllowUserToAddRows = False
        Me.dGridSize.AllowUserToDeleteRows = False
        Me.dGridSize.AllowUserToResizeColumns = False
        Me.dGridSize.AllowUserToResizeRows = False
        Me.dGridSize.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.dGridSize.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dGridSize.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dGridSize.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dGridSize.ColumnHeadersHeight = 20
        Me.dGridSize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dGridSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dGridSize.Location = New System.Drawing.Point(0, 0)
        Me.dGridSize.MultiSelect = False
        Me.dGridSize.Name = "dGridSize"
        Me.dGridSize.ReadOnly = True
        Me.dGridSize.RowHeadersWidth = 4
        Me.dGridSize.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dGridSize.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dGridSize.Size = New System.Drawing.Size(467, 193)
        Me.dGridSize.TabIndex = 5
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.TextBox4)
        Me.Panel4.Location = New System.Drawing.Point(125, -43)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(467, 56)
        Me.Panel4.TabIndex = 13
        '
        'TextBox4
        '
        Me.TextBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox4.Enabled = False
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(0, 0)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(467, 56)
        Me.TextBox4.TabIndex = 5
        Me.TextBox4.Text = "Size"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TextBox3)
        Me.Panel3.Location = New System.Drawing.Point(7, -43)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(117, 250)
        Me.Panel3.TabIndex = 14
        '
        'TextBox3
        '
        Me.TextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(0, 0)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(117, 250)
        Me.TextBox3.TabIndex = 4
        Me.TextBox3.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Color"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Location = New System.Drawing.Point(-159, -43)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(165, 250)
        Me.Panel2.TabIndex = 12
        '
        'TextBox2
        '
        Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(0, 0)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(165, 250)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Product" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Name"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Location = New System.Drawing.Point(-313, -43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(153, 250)
        Me.Panel1.TabIndex = 11
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(153, 250)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Kode Item"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(693, 469)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel10.ResumeLayout(False)
        CType(Me.dGridAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.dGridSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents dGridAll As System.Windows.Forms.DataGridView
    Friend WithEvents KodeItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents namaItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents color As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SizeCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents size1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents size2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents size3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents size4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents size5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents size6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents size7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents size8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cons As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents dGridSize As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
