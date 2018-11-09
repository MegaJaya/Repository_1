<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmdailyrpttbs
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
        Me.crdr = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        'Me.dailyreport1 = New wbs_ams.dailyreport
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.btnreport = New System.Windows.Forms.Button
        Me.txtremark = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbcs = New System.Windows.Forms.ComboBox
        Me.cbdiv = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'crdr
        '
        Me.crdr.ActiveViewIndex = -1
        Me.crdr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crdr.DisplayGroupTree = False
        Me.crdr.Location = New System.Drawing.Point(12, 71)
        Me.crdr.Name = "crdr"
        Me.crdr.SelectionFormula = ""
        Me.crdr.Size = New System.Drawing.Size(1062, 509)
        Me.crdr.TabIndex = 14
        Me.crdr.ViewTimeSelectionFormula = ""
        '
        'dtto
        '
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtto.Location = New System.Drawing.Point(234, 15)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(97, 20)
        Me.dtto.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(206, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "TO"
        '
        'dtfrom
        '
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtfrom.Location = New System.Drawing.Point(103, 15)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(97, 20)
        Me.dtfrom.TabIndex = 11
        '
        'btnreport
        '
        Me.btnreport.Location = New System.Drawing.Point(12, 12)
        Me.btnreport.Name = "btnreport"
        Me.btnreport.Size = New System.Drawing.Size(75, 23)
        Me.btnreport.TabIndex = 10
        Me.btnreport.Text = "Report"
        Me.btnreport.UseVisualStyleBackColor = True
        '
        'txtremark
        '
        Me.txtremark.Location = New System.Drawing.Point(882, 14)
        Me.txtremark.Name = "txtremark"
        Me.txtremark.Size = New System.Drawing.Size(192, 20)
        Me.txtremark.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(832, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Remark"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(345, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Customer"
        '
        'cbcs
        '
        Me.cbcs.FormattingEnabled = True
        Me.cbcs.Location = New System.Drawing.Point(398, 14)
        Me.cbcs.Name = "cbcs"
        Me.cbcs.Size = New System.Drawing.Size(179, 21)
        Me.cbcs.TabIndex = 20
        '
        'cbdiv
        '
        Me.cbdiv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbdiv.FormattingEnabled = True
        Me.cbdiv.Location = New System.Drawing.Point(675, 14)
        Me.cbdiv.Name = "cbdiv"
        Me.cbdiv.Size = New System.Drawing.Size(141, 21)
        Me.cbdiv.TabIndex = 34
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(589, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 13)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Divisi / Afdeling"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmdailyrpttbs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1086, 562)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cbdiv)
        Me.Controls.Add(Me.txtremark)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbcs)
        Me.Controls.Add(Me.crdr)
        Me.Controls.Add(Me.dtto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtfrom)
        Me.Controls.Add(Me.btnreport)
        Me.Name = "frmdailyrpttbs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Report Category TBS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents crdr As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    'Friend WithEvents dailyreport1 As wbs_ams.dailyreport
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnreport As System.Windows.Forms.Button
    Friend WithEvents txtremark As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbcs As System.Windows.Forms.ComboBox
    Friend WithEvents cbdiv As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
