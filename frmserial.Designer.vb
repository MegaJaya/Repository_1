<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmserial
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
        Me.btnsave = New System.Windows.Forms.Button
        Me.btncancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtparity = New System.Windows.Forms.TextBox
        Me.txtstopbit = New System.Windows.Forms.TextBox
        Me.txtdatabit = New System.Windows.Forms.TextBox
        Me.txtbaudrate = New System.Windows.Forms.TextBox
        Me.txtport = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.sec_load = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.interval_load = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(197, 333)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 0
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btncancel
        '
        Me.btncancel.Location = New System.Drawing.Point(278, 333)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(75, 23)
        Me.btncancel.TabIndex = 1
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtparity)
        Me.GroupBox1.Controls.Add(Me.txtstopbit)
        Me.GroupBox1.Controls.Add(Me.txtdatabit)
        Me.GroupBox1.Controls.Add(Me.txtbaudrate)
        Me.GroupBox1.Controls.Add(Me.txtport)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 214)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'txtparity
        '
        Me.txtparity.Location = New System.Drawing.Point(128, 180)
        Me.txtparity.Name = "txtparity"
        Me.txtparity.Size = New System.Drawing.Size(137, 20)
        Me.txtparity.TabIndex = 10
        '
        'txtstopbit
        '
        Me.txtstopbit.Location = New System.Drawing.Point(128, 142)
        Me.txtstopbit.Name = "txtstopbit"
        Me.txtstopbit.Size = New System.Drawing.Size(137, 20)
        Me.txtstopbit.TabIndex = 9
        '
        'txtdatabit
        '
        Me.txtdatabit.Location = New System.Drawing.Point(128, 105)
        Me.txtdatabit.Name = "txtdatabit"
        Me.txtdatabit.Size = New System.Drawing.Size(28, 20)
        Me.txtdatabit.TabIndex = 8
        '
        'txtbaudrate
        '
        Me.txtbaudrate.Location = New System.Drawing.Point(128, 68)
        Me.txtbaudrate.Name = "txtbaudrate"
        Me.txtbaudrate.Size = New System.Drawing.Size(66, 20)
        Me.txtbaudrate.TabIndex = 7
        '
        'txtport
        '
        Me.txtport.Location = New System.Drawing.Point(128, 27)
        Me.txtport.Name = "txtport"
        Me.txtport.Size = New System.Drawing.Size(66, 20)
        Me.txtport.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(17, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 23)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Baud Rate"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(17, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Data Bit"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(17, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Stop Bit"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(17, 177)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Parity"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Port"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sec_load
        '
        Me.sec_load.Location = New System.Drawing.Point(140, 237)
        Me.sec_load.Name = "sec_load"
        Me.sec_load.Size = New System.Drawing.Size(66, 20)
        Me.sec_load.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(29, 236)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 23)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Security Weigh"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'interval_load
        '
        Me.interval_load.Location = New System.Drawing.Point(140, 272)
        Me.interval_load.Name = "interval_load"
        Me.interval_load.Size = New System.Drawing.Size(66, 20)
        Me.interval_load.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(29, 270)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 23)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Interval Secure"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmserial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 370)
        Me.Controls.Add(Me.interval_load)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.sec_load)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.btnsave)
        Me.Name = "frmserial"
        Me.Text = "Serial Port"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtparity As System.Windows.Forms.TextBox
    Friend WithEvents txtstopbit As System.Windows.Forms.TextBox
    Friend WithEvents txtdatabit As System.Windows.Forms.TextBox
    Friend WithEvents txtbaudrate As System.Windows.Forms.TextBox
    Friend WithEvents txtport As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents sec_load As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents interval_load As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
