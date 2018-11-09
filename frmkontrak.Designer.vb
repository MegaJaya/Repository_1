<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmkontrak
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
        Me.btndelete = New System.Windows.Forms.Button
        Me.btnclose = New System.Windows.Forms.Button
        Me.btncancel = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDOBesar = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtactend = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtactstart = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtexp = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbpart = New System.Windows.Forms.ComboBox
        Me.cbcs = New System.Windows.Forms.ComboBox
        Me.cbfr = New System.Windows.Forms.CheckBox
        Me.txtqtykontrak = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtstart = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtkontrak = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgkontrak = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgkontrak, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(261, 326)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(75, 23)
        Me.btndelete.TabIndex = 25
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(342, 326)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(75, 23)
        Me.btnclose.TabIndex = 26
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btncancel
        '
        Me.btncancel.Location = New System.Drawing.Point(180, 326)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(75, 23)
        Me.btncancel.TabIndex = 24
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(99, 326)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 23
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDOBesar)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.dtactend)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtactstart)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.dtexp)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbpart)
        Me.GroupBox1.Controls.Add(Me.cbcs)
        Me.GroupBox1.Controls.Add(Me.cbfr)
        Me.GroupBox1.Controls.Add(Me.txtqtykontrak)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtstart)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtkontrak)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(405, 298)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'txtDOBesar
        '
        Me.txtDOBesar.Location = New System.Drawing.Point(103, 58)
        Me.txtDOBesar.Name = "txtDOBesar"
        Me.txtDOBesar.Size = New System.Drawing.Size(158, 20)
        Me.txtDOBesar.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "DO Besar"
        '
        'dtactend
        '
        Me.dtactend.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtactend.Location = New System.Drawing.Point(292, 242)
        Me.dtactend.Name = "dtactend"
        Me.dtactend.Size = New System.Drawing.Size(98, 20)
        Me.dtactend.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(207, 244)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Actual End"
        '
        'dtactstart
        '
        Me.dtactstart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtactstart.Location = New System.Drawing.Point(293, 207)
        Me.dtactstart.Name = "dtactstart"
        Me.dtactstart.Size = New System.Drawing.Size(98, 20)
        Me.dtactstart.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(208, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Actual Start"
        '
        'dtexp
        '
        Me.dtexp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtexp.Location = New System.Drawing.Point(101, 242)
        Me.dtexp.Name = "dtexp"
        Me.dtexp.Size = New System.Drawing.Size(98, 20)
        Me.dtexp.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 244)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "End Kontrak"
        '
        'cbpart
        '
        Me.cbpart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbpart.FormattingEnabled = True
        Me.cbpart.Location = New System.Drawing.Point(101, 135)
        Me.cbpart.Name = "cbpart"
        Me.cbpart.Size = New System.Drawing.Size(168, 21)
        Me.cbpart.TabIndex = 12
        '
        'cbcs
        '
        Me.cbcs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbcs.FormattingEnabled = True
        Me.cbcs.Location = New System.Drawing.Point(102, 97)
        Me.cbcs.Name = "cbcs"
        Me.cbcs.Size = New System.Drawing.Size(233, 21)
        Me.cbcs.TabIndex = 11
        '
        'cbfr
        '
        Me.cbfr.AutoSize = True
        Me.cbfr.Checked = True
        Me.cbfr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbfr.Location = New System.Drawing.Point(330, 22)
        Me.cbfr.Name = "cbfr"
        Me.cbfr.Size = New System.Drawing.Size(59, 17)
        Me.cbfr.TabIndex = 10
        Me.cbfr.Text = "Franco"
        Me.cbfr.UseVisualStyleBackColor = True
        '
        'txtqtykontrak
        '
        Me.txtqtykontrak.Location = New System.Drawing.Point(102, 171)
        Me.txtqtykontrak.Name = "txtqtykontrak"
        Me.txtqtykontrak.Size = New System.Drawing.Size(119, 20)
        Me.txtqtykontrak.TabIndex = 9
        Me.txtqtykontrak.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Qty Kontrak"
        '
        'dtstart
        '
        Me.dtstart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtstart.Location = New System.Drawing.Point(102, 207)
        Me.dtstart.Name = "dtstart"
        Me.dtstart.Size = New System.Drawing.Size(98, 20)
        Me.dtstart.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 209)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Start"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Product Name"
        '
        'txtkontrak
        '
        Me.txtkontrak.Location = New System.Drawing.Point(101, 22)
        Me.txtkontrak.Name = "txtkontrak"
        Me.txtkontrak.Size = New System.Drawing.Size(158, 20)
        Me.txtkontrak.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Customer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No Kontrak"
        '
        'dgkontrak
        '
        Me.dgkontrak.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgkontrak.Location = New System.Drawing.Point(432, 12)
        Me.dgkontrak.MinimumSize = New System.Drawing.Size(405, 139)
        Me.dgkontrak.Name = "dgkontrak"
        Me.dgkontrak.Size = New System.Drawing.Size(613, 343)
        Me.dgkontrak.TabIndex = 27
        '
        'frmkontrak
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 365)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgkontrak)
        Me.Name = "frmkontrak"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery Kontrak"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgkontrak, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtkontrak As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgkontrak As System.Windows.Forms.DataGridView
    Public WithEvents dtstart As System.Windows.Forms.DateTimePicker
    Public WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtqtykontrak As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbcs As System.Windows.Forms.ComboBox
    Friend WithEvents cbfr As System.Windows.Forms.CheckBox
    Friend WithEvents cbpart As System.Windows.Forms.ComboBox
    Public WithEvents dtexp As System.Windows.Forms.DateTimePicker
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents dtactend As System.Windows.Forms.DateTimePicker
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents dtactstart As System.Windows.Forms.DateTimePicker
    Public WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDOBesar As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
