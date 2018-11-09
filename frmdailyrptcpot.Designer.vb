<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmdailyrptcpot
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
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.btnreport = New System.Windows.Forms.Button
        Me.cbpart = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'crdr
        '
        Me.crdr.ActiveViewIndex = -1
        Me.crdr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crdr.DisplayGroupTree = False
        Me.crdr.Location = New System.Drawing.Point(12, 41)
        Me.crdr.Name = "crdr"
        Me.crdr.SelectionFormula = ""
        Me.crdr.Size = New System.Drawing.Size(860, 509)
        Me.crdr.TabIndex = 9
        Me.crdr.ViewTimeSelectionFormula = ""
        '
        'dtto
        '
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtto.Location = New System.Drawing.Point(520, 13)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(97, 20)
        Me.dtto.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(492, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "TO"
        '
        'dtfrom
        '
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtfrom.Location = New System.Drawing.Point(389, 13)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(97, 20)
        Me.dtfrom.TabIndex = 6
        '
        'btnreport
        '
        Me.btnreport.Location = New System.Drawing.Point(12, 12)
        Me.btnreport.Name = "btnreport"
        Me.btnreport.Size = New System.Drawing.Size(75, 23)
        Me.btnreport.TabIndex = 5
        Me.btnreport.Text = "Report"
        Me.btnreport.UseVisualStyleBackColor = True
        '
        'cbpart
        '
        Me.cbpart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbpart.FormattingEnabled = True
        Me.cbpart.Items.AddRange(New Object() {"CPO", "KER", "SHL"})
        Me.cbpart.Location = New System.Drawing.Point(164, 13)
        Me.cbpart.Name = "cbpart"
        Me.cbpart.Size = New System.Drawing.Size(121, 21)
        Me.cbpart.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(117, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Produk"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(345, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "FROM"
        '
        'frmdailyrptcpot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 562)
        Me.Controls.Add(Me.crdr)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbpart)
        Me.Controls.Add(Me.dtto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtfrom)
        Me.Controls.Add(Me.btnreport)
        Me.Name = "frmdailyrptcpot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Report Category CPOT Transfer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents crdr As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnreport As System.Windows.Forms.Button
    'Friend WithEvents dailyreport1 As wbs_ams.dailyreport
    Friend WithEvents cbpart As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
