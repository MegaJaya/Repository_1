Imports System.Data.Odbc
Public Class frmsup

    Private Sub frmsup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Koneksi()
        Me.Show()
        Application.DoEvents()
        txtsupid.Focus()
        kosong()
        tampil()
        ModifikasiData.IsiCombo("Select * from wbs_estate_tab order by estateid", txtfccode, "estateid", "estateid")
        txtfccode.SelectedIndex = -1
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
    Sub kosong()
        'Dim a As String
        'Dim b As String
        'cmd = New odbcCommand("select supid from wbs_supplier_tab order by supid desc", Conn)
        'rd = cmd.ExecuteReader
        'rd.Read()

        'If rd.HasRows = True Then

        'a = rd.GetString(0).Substring(2, 3)
        'b = Convert.ToString(CInt(a) + 1)
        'If b.Length = 1 Then
        'b = "SP00" + b
        'ElseIf b.Length = 2 Then
        'b = "SP0" + b
        'Else
        'b = "SP" + b
        'End If
        'txtsupid.Text = b
        'Else

        'txtsupid.Text = "SP001"
        'End If
        'rd.Close()
        txtsupid.Text = ""
        txtsupaddress.Text = ""
        txtsupname.Text = ""
        txtfccode.Text = ""
        txtsupid.Focus()


    End Sub
    Sub tampil()
        da = New odbcDataAdapter("select supid As SUP_ID,supname as SUPLIER_NAME,supaddress as ADDRESS,fccode as FcCode from wbs_supplier_tab", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "sup")
        dgsup.DataSource = (ds.Tables("sup"))
        dgsup.ReadOnly = True
    End Sub
    Sub baru()
        txtsupname.Focus()
        txtsupname.Text = ""
        txtsupaddress.Text = ""

    End Sub

    Sub simpan()
        Dim siteid As String
        siteid = getSite()
        If txtsupid.Text = "" Or txtsupname.Text = "" Or txtsupaddress.Text = "" Or txtfccode.Text = "" Then
            MsgBox("Please fill the blank field !!!")
            Exit Sub

        Else
            cmd = New odbcCommand("select * from wbs_supplier_tab where supid='" & txtsupid.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                Dim sqladd As String
                Dim sqladd_estate As String

                sqladd = "insert into wbs_supplier_tab([supid],[supname],[supaddress],[siteid],[fccode],[flag],[version]) values('" & txtsupid.Text & "','" & txtsupname.Text & "','" & txtsupaddress.Text & "','" & siteid & "','" & txtfccode.Text.ToUpper & "','T','1')"
                cmd = New odbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()

                'sqladd_estate = "insert into wbs_estate_tab([estateid],[estatename]) values('" & txtfccode.Text.ToUpper & "','" & txtsupname.Text & "')"
                'cmd = New odbcCommand(sqladd_estate, Conn)
                'cmd.ExecuteNonQuery()

            Else
                Dim sqledit As String
                Dim sqledit_estate As String

                sqledit = "update wbs_supplier_tab set [supname]='" & txtsupname.Text & "',[supaddress]='" & txtsupaddress.Text & "',fccode = '" & txtfccode.Text & "',[flag]='T',[version] = ([version]+1) where [supid]='" & txtsupid.Text & "'"
                cmd = New odbcCommand(sqledit, Conn)
                cmd.ExecuteNonQuery()

                'sqledit_estate = "update wbs_estate_tab set [estatename]='" & txtsupname.Text & "' where [estateid]='" & txtfccode.Text.ToUpper & "'"
                'cmd = New odbcCommand(sqledit_estate, Conn)
                'cmd.ExecuteNonQuery()

            End If
            rd.Close()
            setFlag("tblsup")

            'Dim sqlhist As String
            'sqlhist = "insert into wbs_sup_hist_tab([supid],[supname],[supaddress],[siteid],[create_by],[create_date],[update_by],[update_date]) values('" & txtsupid.Text & "','" & txtsupname.Text & "','" & txtsupaddress.Text & "','" & siteid & "','" & frmlogin.txtusername.Text & "','" & System.DateTime.Now & "','" & frmlogin.txtusername.Text & "','" & System.DateTime.Now & "')"
            'cmd = New odbcCommand(sqlhist, Conn)
            'cmd.ExecuteNonQuery()
            kosong()
            tampil()

        End If
    End Sub

    Private Sub txtsupid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsupid.KeyPress
        If e.KeyChar = Chr(13) Then
            cmd = New odbcCommand("select * from wbs_supplier_tab where supid='" & txtsupid.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                txtsupname.Text = rd.GetString(1)
                txtsupaddress.Text = rd.GetString(2)
                txtsupname.Focus()
                txtfccode.Enabled = False
            Else
                baru()

            End If
            rd.Close()
        End If
    End Sub

    Private Sub txtsupname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsupname.KeyPress
        If e.KeyChar = Chr(13) Then
            txtsupaddress.Focus()

        End If
    End Sub

    Private Sub txtsupaddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsupaddress.KeyPress
        If e.KeyChar = Chr(13) Then
            btnsave.Focus()

        End If
    End Sub


    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        simpan()
    End Sub

    Private Sub btnsave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnsave.KeyPress
        simpan()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        kosong()
        tampil()

    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtsupid.Text = "" Then
            MsgBox("Fill operator ID field first !!!")
            Exit Sub

        Else
            If MessageBox.Show("Are you sure to delete the data ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cmd = New odbcCommand("delete from wbs_supplier_tab where [supid]='" & txtsupid.Text & "'", Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()

            Else
                kosong()

            End If
        End If

    End Sub


    Private Sub dgsup_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgsup.CellContentClick
        txtsupid.Text = dgsup.CurrentRow.Cells(0).Value
        If dgsup.CurrentRow.Cells(1).Value.ToString = "" Then
            txtsupname.Text = ""
        Else
            txtsupname.Text = dgsup.CurrentRow.Cells(1).Value
        End If
        If dgsup.CurrentRow.Cells(2).Value.ToString = "" Then
            txtsupaddress.Text = ""
        Else
            txtsupaddress.Text = dgsup.CurrentRow.Cells(2).Value
        End If
        If dgsup.CurrentRow.Cells(3).Value.ToString = "" Then
            txtfccode.Text = ""
        Else
            txtfccode.Text = dgsup.CurrentRow.Cells(3).Value
        End If
    End Sub

    Private Sub txtfccode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtfccode.TextChanged
        Dim frmestate As New frmestate
        If txtfccode.Text.Length > 0 Then
            Dim index As Integer = txtfccode.FindString(txtfccode.Text)
            If (index < 0) Then
                frmestate.StartPosition = FormStartPosition.CenterParent
                MessageBox.Show("Item not found, please enter your 'Estate' first column.")
                frmestate.ShowDialog()
                txtfccode.Text = String.Empty
                ModifikasiData.IsiCombo("Select * from wbs_estate_tab order by estateid", txtfccode, "estateid", "estateid")
                txtfccode.SelectedIndex = -1

            End If
        End If
    End Sub

End Class