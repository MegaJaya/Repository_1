<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetailKontrak
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbkontrak = New System.Windows.Forms.ComboBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.dtactend = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtactstart = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtexp = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbfr = New System.Windows.Forms.CheckBox
        Me.txtqtykontrak = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtstart = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtkontrak = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbkontrak)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.dtactend)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtactstart)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.dtexp)
        Me.GroupBox1.Controls.Add(Me.Label6)
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
        Me.GroupBox1.Size = New System.Drawing.Size(746, 163)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'cbkontrak
        '
        Me.cbkontrak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbkontrak.FormattingEnabled = True
        Me.cbkontrak.Location = New System.Drawing.Point(100, 21)
        Me.cbkontrak.Name = "cbkontrak"
        Me.cbkontrak.Size = New System.Drawing.Size(160, 21)
        Me.cbkontrak.TabIndex = 21
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(102, 90)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(158, 20)
        Me.TextBox2.TabIndex = 20
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(101, 56)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(158, 20)
        Me.TextBox1.TabIndex = 19
        '
        'dtactend
        '
        Me.dtactend.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtactend.Location = New System.Drawing.Point(623, 57)
        Me.dtactend.Name = "dtactend"
        Me.dtactend.Size = New System.Drawing.Size(98, 20)
        Me.dtactend.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(551, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Actual End"
        '
        'dtactstart
        '
        Me.dtactstart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtactstart.Location = New System.Drawing.Point(624, 22)
        Me.dtactstart.Name = "dtactstart"
        Me.dtactstart.Size = New System.Drawing.Size(98, 20)
        Me.dtactstart.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(548, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Actual Start"
        '
        'dtexp
        '
        Me.dtexp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtexp.Location = New System.Drawing.Point(432, 57)
        Me.dtexp.Name = "dtexp"
        Me.dtexp.Size = New System.Drawing.Size(98, 20)
        Me.dtexp.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(347, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "End Kontrak"
        '
        'cbfr
        '
        Me.cbfr.AutoSize = True
        Me.cbfr.Checked = True
        Me.cbfr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbfr.Location = New System.Drawing.Point(349, 96)
        Me.cbfr.Name = "cbfr"
        Me.cbfr.Size = New System.Drawing.Size(59, 17)
        Me.cbfr.TabIndex = 10
        Me.cbfr.Text = "Franco"
        Me.cbfr.UseVisualStyleBackColor = True
        '
        'txtqtykontrak
        '
        Me.txtqtykontrak.Location = New System.Drawing.Point(102, 126)
        Me.txtqtykontrak.Name = "txtqtykontrak"
        Me.txtqtykontrak.Size = New System.Drawing.Size(119, 20)
        Me.txtqtykontrak.TabIndex = 9
        Me.txtqtykontrak.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Qty Kontrak"
        '
        'dtstart
        '
        Me.dtstart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtstart.Location = New System.Drawing.Point(433, 22)
        Me.dtstart.Name = "dtstart"
        Me.dtstart.Size = New System.Drawing.Size(98, 20)
        Me.dtstart.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(348, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Start"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Product Name"
        '
        'txtkontrak
        '
        Me.txtkontrak.Location = New System.Drawing.Point(295, 126)
        Me.txtkontrak.Name = "txtkontrak"
        Me.txtkontrak.Size = New System.Drawing.Size(158, 20)
        Me.txtkontrak.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 59)
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
        'FrmDetailKontrak
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 441)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmDetailKontrak"
        Me.Text = "Detail Kontrak"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Public WithEvents dtactend As System.Windows.Forms.DateTimePicker
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents dtactstart As System.Windows.Forms.DateTimePicker
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents dtexp As System.Windows.Forms.DateTimePicker
    Public WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbfr As System.Windows.Forms.CheckBox
    Friend WithEvents txtqtykontrak As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents dtstart As System.Windows.Forms.DateTimePicker
    Public WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtkontrak As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbkontrak As System.Windows.Forms.ComboBox
End Class
