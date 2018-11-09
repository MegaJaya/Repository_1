<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsortase
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
        Me.txtkonsname = New System.Windows.Forms.TextBox
        Me.txtkonsid = New System.Windows.Forms.TextBox
        Me.btnclose = New System.Windows.Forms.Button
        Me.btndelete = New System.Windows.Forms.Button
        Me.btncancel = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.dgsortase = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtmentah = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtlmatang = New System.Windows.Forms.TextBox
        Me.txttankos = New System.Windows.Forms.TextBox
        Me.txtbkecil = New System.Windows.Forms.TextBox
        Me.txttpanjang = New System.Windows.Forms.TextBox
        Me.txtsampah = New System.Windows.Forms.TextBox
        CType(Me.dgsortase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtkonsname
        '
        Me.txtkonsname.Location = New System.Drawing.Point(129, 70)
        Me.txtkonsname.Name = "txtkonsname"
        Me.txtkonsname.Size = New System.Drawing.Size(230, 20)
        Me.txtkonsname.TabIndex = 22
        '
        'txtkonsid
        '
        Me.txtkonsid.Location = New System.Drawing.Point(129, 28)
        Me.txtkonsid.Name = "txtkonsid"
        Me.txtkonsid.Size = New System.Drawing.Size(100, 20)
        Me.txtkonsid.TabIndex = 20
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(383, 250)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(75, 23)
        Me.btnclose.TabIndex = 16
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(302, 250)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(75, 23)
        Me.btndelete.TabIndex = 15
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'btncancel
        '
        Me.btncancel.Location = New System.Drawing.Point(221, 250)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(75, 23)
        Me.btncancel.TabIndex = 14
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(140, 250)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 13
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'dgsortase
        '
        Me.dgsortase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgsortase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgsortase.Location = New System.Drawing.Point(10, 286)
        Me.dgsortase.Name = "dgsortase"
        Me.dgsortase.Size = New System.Drawing.Size(446, 193)
        Me.dgsortase.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtsampah)
        Me.GroupBox1.Controls.Add(Me.txttpanjang)
        Me.GroupBox1.Controls.Add(Me.txtbkecil)
        Me.GroupBox1.Controls.Add(Me.txttankos)
        Me.GroupBox1.Controls.Add(Me.txtlmatang)
        Me.GroupBox1.Controls.Add(Me.txtmentah)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(446, 230)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'txtmentah
        '
        Me.txtmentah.Location = New System.Drawing.Point(130, 106)
        Me.txtmentah.Name = "txtmentah"
        Me.txtmentah.Size = New System.Drawing.Size(61, 20)
        Me.txtmentah.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.Location = New System.Drawing.Point(237, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 23)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Tangkai Panjang  (%)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.Location = New System.Drawing.Point(13, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "TBSMentah (%)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.Location = New System.Drawing.Point(13, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Konstanta Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Konstanta ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.Location = New System.Drawing.Point(237, 188)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Sampah (Qty)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.Location = New System.Drawing.Point(237, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 23)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Buah Kecil (%)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.Location = New System.Drawing.Point(12, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Tandan Kosong (%)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.Location = New System.Drawing.Point(12, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 23)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "TBS Lewat matang (%)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtlmatang
        '
        Me.txtlmatang.Location = New System.Drawing.Point(130, 148)
        Me.txtlmatang.Name = "txtlmatang"
        Me.txtlmatang.Size = New System.Drawing.Size(61, 20)
        Me.txtlmatang.TabIndex = 36
        '
        'txttankos
        '
        Me.txttankos.Location = New System.Drawing.Point(130, 188)
        Me.txttankos.Name = "txttankos"
        Me.txttankos.Size = New System.Drawing.Size(61, 20)
        Me.txttankos.TabIndex = 37
        '
        'txtbkecil
        '
        Me.txtbkecil.Location = New System.Drawing.Point(358, 106)
        Me.txtbkecil.Name = "txtbkecil"
        Me.txtbkecil.Size = New System.Drawing.Size(61, 20)
        Me.txtbkecil.TabIndex = 38
        '
        'txttpanjang
        '
        Me.txttpanjang.Location = New System.Drawing.Point(358, 145)
        Me.txttpanjang.Name = "txttpanjang"
        Me.txttpanjang.Size = New System.Drawing.Size(61, 20)
        Me.txttpanjang.TabIndex = 39
        '
        'txtsampah
        '
        Me.txtsampah.Location = New System.Drawing.Point(358, 190)
        Me.txtsampah.Name = "txtsampah"
        Me.txtsampah.Size = New System.Drawing.Size(61, 20)
        Me.txtsampah.TabIndex = 40
        '
        'frmsortase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 488)
        Me.Controls.Add(Me.txtkonsname)
        Me.Controls.Add(Me.txtkonsid)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.dgsortase)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmsortase"
        Me.Text = "frmsortase"
        CType(Me.dgsortase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtkonsname As System.Windows.Forms.TextBox
    Friend WithEvents txtkonsid As System.Windows.Forms.TextBox
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents dgsortase As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtmentah As System.Windows.Forms.TextBox
    Friend WithEvents txtsampah As System.Windows.Forms.TextBox
    Friend WithEvents txttpanjang As System.Windows.Forms.TextBox
    Friend WithEvents txtbkecil As System.Windows.Forms.TextBox
    Friend WithEvents txttankos As System.Windows.Forms.TextBox
    Friend WithEvents txtlmatang As System.Windows.Forms.TextBox
End Class
