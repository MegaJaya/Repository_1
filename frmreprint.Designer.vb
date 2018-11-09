<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmreprint
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
        Me.dgreprint = New System.Windows.Forms.DataGridView
        Me.btnreprint = New System.Windows.Forms.Button
        Me.btnclose = New System.Windows.Forms.Button
        Me.btnupdate = New System.Windows.Forms.Button
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cr2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        CType(Me.dgreprint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgreprint
        '
        Me.dgreprint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgreprint.Location = New System.Drawing.Point(13, 41)
        Me.dgreprint.Name = "dgreprint"
        Me.dgreprint.Size = New System.Drawing.Size(859, 470)
        Me.dgreprint.TabIndex = 0
        '
        'btnreprint
        '
        Me.btnreprint.Location = New System.Drawing.Point(716, 527)
        Me.btnreprint.Name = "btnreprint"
        Me.btnreprint.Size = New System.Drawing.Size(75, 23)
        Me.btnreprint.TabIndex = 1
        Me.btnreprint.Text = "Reprint"
        Me.btnreprint.UseVisualStyleBackColor = True
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(797, 527)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(75, 23)
        Me.btnclose.TabIndex = 2
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btnupdate
        '
        Me.btnupdate.Location = New System.Drawing.Point(13, 12)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(75, 23)
        Me.btnupdate.TabIndex = 3
        Me.btnupdate.Text = "Update"
        Me.btnupdate.UseVisualStyleBackColor = True
        '
        'dtfrom
        '
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtfrom.Location = New System.Drawing.Point(104, 15)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(110, 20)
        Me.dtfrom.TabIndex = 4
        '
        'dtto
        '
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtto.Location = New System.Drawing.Point(249, 15)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(110, 20)
        Me.dtto.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(219, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "TO"
        '
        'cr2
        '
        Me.cr2.ActiveViewIndex = -1
        Me.cr2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cr2.DisplayGroupTree = False
        Me.cr2.Location = New System.Drawing.Point(13, 41)
        Me.cr2.Name = "cr2"
        Me.cr2.SelectionFormula = ""
        Me.cr2.Size = New System.Drawing.Size(859, 470)
        Me.cr2.TabIndex = 7
        Me.cr2.ViewTimeSelectionFormula = ""
        Me.cr2.Visible = False
        '
        'frmreprint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 562)
        Me.Controls.Add(Me.cr2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtto)
        Me.Controls.Add(Me.dtfrom)
        Me.Controls.Add(Me.btnupdate)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btnreprint)
        Me.Controls.Add(Me.dgreprint)
        Me.Name = "frmreprint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reprint"
        CType(Me.dgreprint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgreprint As System.Windows.Forms.DataGridView
    Friend WithEvents btnreprint As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cr2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
