<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmdailyrpt
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
        Me.btnreport = New System.Windows.Forms.Button
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.crdr = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbpart = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.typeweight = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.typereport_text = New System.Windows.Forms.Label
        Me.typereport = New System.Windows.Forms.ComboBox
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnreport
        '
        Me.btnreport.Location = New System.Drawing.Point(17, 15)
        Me.btnreport.Name = "btnreport"
        Me.btnreport.Size = New System.Drawing.Size(75, 23)
        Me.btnreport.TabIndex = 0
        Me.btnreport.Text = "Report"
        Me.btnreport.UseVisualStyleBackColor = True
        '
        'dtfrom
        '
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtfrom.Location = New System.Drawing.Point(885, 18)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(99, 20)
        Me.dtfrom.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(995, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "TO"
        '
        'dtto
        '
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtto.Location = New System.Drawing.Point(1023, 18)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(99, 20)
        Me.dtto.TabIndex = 3
        '
        'crdr
        '
        Me.crdr.ActiveViewIndex = -1
        Me.crdr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crdr.DisplayGroupTree = False
        Me.crdr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crdr.Location = New System.Drawing.Point(0, 0)
        Me.crdr.Name = "crdr"
        Me.crdr.SelectionFormula = ""
        Me.crdr.Size = New System.Drawing.Size(1140, 508)
        Me.crdr.TabIndex = 4
        Me.crdr.ViewTimeSelectionFormula = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(414, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Produk"
        '
        'cbpart
        '
        Me.cbpart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbpart.FormattingEnabled = True
        Me.cbpart.Items.AddRange(New Object() {"CPO", "KER", "SHL"})
        Me.cbpart.Location = New System.Drawing.Point(461, 17)
        Me.cbpart.Name = "cbpart"
        Me.cbpart.Size = New System.Drawing.Size(121, 21)
        Me.cbpart.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(844, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "FROM"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(119, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Type Weight"
        '
        'typeweight
        '
        Me.typeweight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.typeweight.FormattingEnabled = True
        Me.typeweight.Items.AddRange(New Object() {"Transfer", "Lain-lain"})
        Me.typeweight.Location = New System.Drawing.Point(196, 17)
        Me.typeweight.Name = "typeweight"
        Me.typeweight.Size = New System.Drawing.Size(192, 21)
        Me.typeweight.TabIndex = 15
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.typereport_text)
        Me.Panel1.Controls.Add(Me.typereport)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.typeweight)
        Me.Panel1.Controls.Add(Me.btnreport)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dtfrom)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cbpart)
        Me.Panel1.Controls.Add(Me.dtto)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1140, 48)
        Me.Panel1.TabIndex = 17
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.crdr)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 54)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1140, 508)
        Me.Panel2.TabIndex = 18
        '
        'typereport_text
        '
        Me.typereport_text.AutoSize = True
        Me.typereport_text.Location = New System.Drawing.Point(606, 21)
        Me.typereport_text.Name = "typereport_text"
        Me.typereport_text.Size = New System.Drawing.Size(66, 13)
        Me.typereport_text.TabIndex = 18
        Me.typereport_text.Text = "Type Report"
        Me.typereport_text.Visible = False
        '
        'typereport
        '
        Me.typereport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.typereport.FormattingEnabled = True
        Me.typereport.Items.AddRange(New Object() {"Daily Report", "Kirim", "Terima", "Per Supplier", "Per Transporter"})
        Me.typereport.Location = New System.Drawing.Point(678, 17)
        Me.typereport.Name = "typereport"
        Me.typereport.Size = New System.Drawing.Size(137, 21)
        Me.typereport.TabIndex = 17
        Me.typereport.Visible = False
        '
        'frmdailyrpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 562)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmdailyrpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Report"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnreport As System.Windows.Forms.Button
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents crdr As CrystalDecisions.Windows.Forms.CrystalReportViewer
    'Friend WithEvents dailyreport1 As wbs_ams.dailyreport
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbpart As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents typeweight As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents typereport_text As System.Windows.Forms.Label
    Friend WithEvents typereport As System.Windows.Forms.ComboBox
End Class
