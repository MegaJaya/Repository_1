<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcs
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
        Me.dgcs = New System.Windows.Forms.DataGridView
        Me.btnsave = New System.Windows.Forms.Button
        Me.btncancel = New System.Windows.Forms.Button
        Me.btndelete = New System.Windows.Forms.Button
        Me.txtcsid = New System.Windows.Forms.TextBox
        Me.txtcsname = New System.Windows.Forms.TextBox
        Me.Vhc_Validation = New System.Windows.Forms.CheckBox
        Me.cbkons = New System.Windows.Forms.ComboBox
        Me.cbint = New System.Windows.Forms.CheckBox
        Me.Customer_form = New System.Windows.Forms.TabControl
        Me.customer = New System.Windows.Forms.TabPage
        Me.address = New System.Windows.Forms.TabPage
        Me.dgads = New System.Windows.Forms.DataGridView
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.savedtl = New System.Windows.Forms.Button
        Me.new_dtl = New System.Windows.Forms.Button
        Me.namelabel = New System.Windows.Forms.Label
        Me.txtiddtl = New System.Windows.Forms.TextBox
        Me.txtnamedtl = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtaddressdtl = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Konstanta = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.dgcs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Customer_form.SuspendLayout()
        Me.customer.SuspendLayout()
        Me.address.SuspendLayout()
        CType(Me.dgads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgcs
        '
        Me.dgcs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgcs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgcs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgcs.Location = New System.Drawing.Point(5, 5)
        Me.dgcs.Name = "dgcs"
        Me.dgcs.Size = New System.Drawing.Size(818, 382)
        Me.dgcs.TabIndex = 0
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(453, 111)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 1
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btncancel
        '
        Me.btncancel.Location = New System.Drawing.Point(534, 111)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(75, 23)
        Me.btncancel.TabIndex = 2
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(615, 111)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(75, 23)
        Me.btndelete.TabIndex = 3
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'txtcsid
        '
        Me.txtcsid.Location = New System.Drawing.Point(128, 28)
        Me.txtcsid.Name = "txtcsid"
        Me.txtcsid.Size = New System.Drawing.Size(298, 20)
        Me.txtcsid.TabIndex = 8
        '
        'txtcsname
        '
        Me.txtcsname.Location = New System.Drawing.Point(128, 69)
        Me.txtcsname.Name = "txtcsname"
        Me.txtcsname.Size = New System.Drawing.Size(298, 20)
        Me.txtcsname.TabIndex = 10
        '
        'Vhc_Validation
        '
        Me.Vhc_Validation.AutoSize = True
        Me.Vhc_Validation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Vhc_Validation.Location = New System.Drawing.Point(453, 71)
        Me.Vhc_Validation.Name = "Vhc_Validation"
        Me.Vhc_Validation.Size = New System.Drawing.Size(132, 17)
        Me.Vhc_Validation.TabIndex = 14
        Me.Vhc_Validation.Text = "Use Vehicle Validation"
        Me.Vhc_Validation.UseVisualStyleBackColor = True
        '
        'cbkons
        '
        Me.cbkons.FormattingEnabled = True
        Me.cbkons.Location = New System.Drawing.Point(128, 111)
        Me.cbkons.Name = "cbkons"
        Me.cbkons.Size = New System.Drawing.Size(298, 21)
        Me.cbkons.TabIndex = 13
        '
        'cbint
        '
        Me.cbint.AutoSize = True
        Me.cbint.Location = New System.Drawing.Point(453, 29)
        Me.cbint.Name = "cbint"
        Me.cbint.Size = New System.Drawing.Size(61, 17)
        Me.cbint.TabIndex = 0
        Me.cbint.Text = "Internal"
        Me.cbint.UseVisualStyleBackColor = True
        '
        'Customer_form
        '
        Me.Customer_form.Controls.Add(Me.customer)
        Me.Customer_form.Controls.Add(Me.address)
        Me.Customer_form.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Customer_form.Location = New System.Drawing.Point(5, 5)
        Me.Customer_form.Name = "Customer_form"
        Me.Customer_form.Padding = New System.Drawing.Point(10, 5)
        Me.Customer_form.SelectedIndex = 0
        Me.Customer_form.Size = New System.Drawing.Size(836, 422)
        Me.Customer_form.TabIndex = 13
        '
        'customer
        '
        Me.customer.Controls.Add(Me.dgcs)
        Me.customer.Location = New System.Drawing.Point(4, 26)
        Me.customer.Name = "customer"
        Me.customer.Padding = New System.Windows.Forms.Padding(5)
        Me.customer.Size = New System.Drawing.Size(828, 392)
        Me.customer.TabIndex = 0
        Me.customer.Text = "Customer"
        Me.customer.UseVisualStyleBackColor = True
        '
        'address
        '
        Me.address.Controls.Add(Me.dgads)
        Me.address.Controls.Add(Me.Panel3)
        Me.address.Location = New System.Drawing.Point(4, 26)
        Me.address.Name = "address"
        Me.address.Padding = New System.Windows.Forms.Padding(5)
        Me.address.Size = New System.Drawing.Size(828, 392)
        Me.address.TabIndex = 1
        Me.address.Text = "Address"
        Me.address.UseVisualStyleBackColor = True
        '
        'dgads
        '
        Me.dgads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgads.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgads.Location = New System.Drawing.Point(5, 107)
        Me.dgads.Name = "dgads"
        Me.dgads.Size = New System.Drawing.Size(818, 280)
        Me.dgads.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtiddtl)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.savedtl)
        Me.Panel3.Controls.Add(Me.new_dtl)
        Me.Panel3.Controls.Add(Me.namelabel)
        Me.Panel3.Controls.Add(Me.txtnamedtl)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtaddressdtl)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(5, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(818, 102)
        Me.Panel3.TabIndex = 4
        '
        'savedtl
        '
        Me.savedtl.Location = New System.Drawing.Point(623, 62)
        Me.savedtl.Name = "savedtl"
        Me.savedtl.Size = New System.Drawing.Size(80, 23)
        Me.savedtl.TabIndex = 22
        Me.savedtl.Text = "Save"
        Me.savedtl.UseVisualStyleBackColor = True
        '
        'new_dtl
        '
        Me.new_dtl.Location = New System.Drawing.Point(535, 62)
        Me.new_dtl.Name = "new_dtl"
        Me.new_dtl.Size = New System.Drawing.Size(82, 23)
        Me.new_dtl.TabIndex = 19
        Me.new_dtl.Text = "Add"
        Me.new_dtl.UseVisualStyleBackColor = True
        '
        'namelabel
        '
        Me.namelabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.namelabel.Location = New System.Drawing.Point(10, 15)
        Me.namelabel.Name = "namelabel"
        Me.namelabel.Size = New System.Drawing.Size(100, 23)
        Me.namelabel.TabIndex = 21
        Me.namelabel.Text = "Name"
        Me.namelabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtiddtl
        '
        Me.txtiddtl.Enabled = False
        Me.txtiddtl.Location = New System.Drawing.Point(448, 18)
        Me.txtiddtl.Name = "txtiddtl"
        Me.txtiddtl.Size = New System.Drawing.Size(66, 20)
        Me.txtiddtl.TabIndex = 20
        '
        'txtnamedtl
        '
        Me.txtnamedtl.Location = New System.Drawing.Point(114, 18)
        Me.txtnamedtl.Name = "txtnamedtl"
        Me.txtnamedtl.Size = New System.Drawing.Size(298, 20)
        Me.txtnamedtl.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.Location = New System.Drawing.Point(8, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Address"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtaddressdtl
        '
        Me.txtaddressdtl.Location = New System.Drawing.Point(114, 44)
        Me.txtaddressdtl.Multiline = True
        Me.txtaddressdtl.Name = "txtaddressdtl"
        Me.txtaddressdtl.Size = New System.Drawing.Size(400, 41)
        Me.txtaddressdtl.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.txtcsid)
        Me.Panel1.Controls.Add(Me.txtcsname)
        Me.Panel1.Controls.Add(Me.Vhc_Validation)
        Me.Panel1.Controls.Add(Me.btnsave)
        Me.Panel1.Controls.Add(Me.cbint)
        Me.Panel1.Controls.Add(Me.cbkons)
        Me.Panel1.Controls.Add(Me.btndelete)
        Me.Panel1.Controls.Add(Me.btncancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(846, 159)
        Me.Panel1.TabIndex = 14
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Controls.Add(Me.Label3)
        Me.Panel7.Controls.Add(Me.Konstanta)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(122, 159)
        Me.Panel7.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.Location = New System.Drawing.Point(19, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Customer ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.Location = New System.Drawing.Point(19, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Customer Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Konstanta
        '
        Me.Konstanta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Konstanta.Location = New System.Drawing.Point(19, 109)
        Me.Konstanta.Name = "Konstanta"
        Me.Konstanta.Size = New System.Drawing.Size(100, 23)
        Me.Konstanta.TabIndex = 17
        Me.Konstanta.Text = "Konstanta"
        Me.Konstanta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Customer_form)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 159)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(846, 432)
        Me.Panel2.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(426, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 23)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Id"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmcs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 591)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmcs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer"
        CType(Me.dgcs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Customer_form.ResumeLayout(False)
        Me.customer.ResumeLayout(False)
        Me.address.ResumeLayout(False)
        CType(Me.dgads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgcs As System.Windows.Forms.DataGridView
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents txtcsid As System.Windows.Forms.TextBox
    Friend WithEvents txtcsname As System.Windows.Forms.TextBox
    Friend WithEvents cbint As System.Windows.Forms.CheckBox
    Friend WithEvents cbkons As System.Windows.Forms.ComboBox
    Friend WithEvents Vhc_Validation As System.Windows.Forms.CheckBox
    Friend WithEvents Customer_form As System.Windows.Forms.TabControl
    Friend WithEvents customer As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Konstanta As System.Windows.Forms.Label
    Friend WithEvents address As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents namelabel As System.Windows.Forms.Label
    Friend WithEvents txtiddtl As System.Windows.Forms.TextBox
    Friend WithEvents txtnamedtl As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtaddressdtl As System.Windows.Forms.TextBox
    Friend WithEvents new_dtl As System.Windows.Forms.Button
    Friend WithEvents dgads As System.Windows.Forms.DataGridView
    Friend WithEvents savedtl As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
