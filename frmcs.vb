Imports System.Data.Odbc
Public Class frmcs
    'Sub autoupdate(ByVal id As Integer, ByVal colomn As String, ByVal input As String)
    '    dgads.Cursor = Cursors.WaitCursor
    '    Dim sqlupdate As String = ""
    '    If id <> "" Then
    '        sqlupdate = "update wbs_cs_dtl_tab "
    '        sqlupdate = sqlupdate + " set " & colomn & " = '" & input & "'"
    '        sqlupdate = sqlupdate + " where id = " & id & ""
    '        cmd = New odbcCommand(sqlupdate, Conn)
    '        cmd.ExecuteNonQuery()
    '        dgads.Cursor = Cursors.Hand
    '    Else
    '        If txtcsid.Text <> "" Then
    '            sqlupdate = "insert into wbs_cs_dtl_tab"
    '            sqlupdate = sqlupdate + " ([csid],[" & colomn & "])values('" & txtcsid.Text & "','" & input & "')"
    '            cmd = New odbcCommand(sqlupdate, Conn)
    '            cmd.ExecuteNonQuery()
    '            dgads.Cursor = Cursors.Hand
    '        End If
    '    End If
    'End Sub
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmcs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        Me.Show()
        Application.DoEvents()
        txtcsid.Focus()
        kosong()
        kosongdtl()
        tampil()
        tampilkons()
        tampiladdress()
        editable()
    End Sub
    Sub tampilkons()
        da = New odbcDataAdapter("select * from wbs_sortase_tab order by konsname", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "kons")
        cbkons.DataSource = (ds.Tables("kons"))
        cbkons.DisplayMember = "konsname"
        cbkons.ValueMember = "konsid"
    End Sub
    Sub savedetail()
        Dim sqlupdate As String = ""
        If txtiddtl.Text <> "" Then
            sqlupdate = "update wbs_cs_dtl_tab "
            sqlupdate = sqlupdate + " set name = '" & txtnamedtl.Text & "'"
            sqlupdate = sqlupdate + ", address = '" & txtaddressdtl.Text & "'"
            sqlupdate = sqlupdate + " where id = " & txtiddtl.Text & ""
            cmd = New odbcCommand(sqlupdate, Conn)
            cmd.ExecuteNonQuery()

        Else
            sqlupdate = "insert into wbs_cs_dtl_tab"
            sqlupdate = sqlupdate + " ([csid],[name],[address])values('" & txtcsid.Text & "','" & txtnamedtl.Text & "','" & txtaddressdtl.Text & "')"
            cmd = New odbcCommand(sqlupdate, Conn)
            cmd.ExecuteNonQuery()
        End If
        tampiladdress()
        kosongdtl()
    End Sub
    Sub editable()
        If txtiddtl.Text <> "" Then
            new_dtl.Text = "New"
            savedtl.Visible = True
        Else
            new_dtl.Text = "Add"
            savedtl.Visible = False
        End If
    End Sub
    Sub kosong()
        txtcsid.Text = ""
        'txtcsaddress.Text = ""
        txtcsname.Text = ""
        cbint.Checked = False
        Vhc_Validation.Checked = False
        txtcsid.Focus()
    End Sub
    Sub kosongdtl()
        txtnamedtl.Text = ""
        txtaddressdtl.Text = ""
        txtiddtl.Text = ""
    End Sub
    Sub tampil()
        da = New odbcDataAdapter("select csid as CUST_ID,csname as CUSTOMER_NAME,csaddress As ADDRESS,INTERNAL,SORTASE,Vehicle_Validation from wbs_cs_tab", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "cs")
        dgcs.DataSource = (ds.Tables("cs"))
        dgcs.ReadOnly = True
    End Sub
    Sub tampiladdress()
        da = New odbcDataAdapter("select id as ID,name as Name, address as Address from wbs_cs_dtl_tab where csid='" & txtcsid.Text & "'", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "csdtl")
        dgads.DataSource = (ds.Tables("csdtl"))
        dgads.ReadOnly = True
    End Sub
    Sub baru()
        txtcsname.Focus()
        txtcsname.Text = ""
        'txtcsaddress.Text = ""
        cbint.Checked = False
    End Sub
    Sub simpan()
        Dim flagin As String = ""
        Dim vhc_valid As String = ""
        Dim siteid As String
        siteid = getSite()
        If cbint.Checked = True Then
            flagin = "T"
        Else
            flagin = "F"
        End If
        If Vhc_Validation.Checked = True Then
            vhc_valid = "T"
        Else
            vhc_valid = "F"
        End If
        If txtcsid.Text = "" Or txtcsname.Text = "" Then
            MsgBox("Kolom kosong harap diisi terlebih dahulu !!!")
            Exit Sub
        Else
            cmd = New odbcCommand("select * from wbs_cs_tab where csid='" & txtcsid.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                Dim sqladd As String
                sqladd = "insert into wbs_cs_tab([csid],[csname],[siteid],[flag],[internal],[sortase],[Vehicle_validation],[create_by],[create_date],[version]) values('" & txtcsid.Text & "','" & txtcsname.Text & "','" & siteid & "','T','" & flagin & "','" & cbkons.SelectedValue & "','" & vhc_valid & "','" & frmlogin.txtusername.Text & "',#" & System.DateTime.Now & "#,'1')"
                cmd = New odbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()
            Else
                Dim sqledit As String
                sqledit = "update wbs_cs_tab set [csname]='" & txtcsname.Text & "',[flag]='T',[internal]='" & flagin & "',[sortase]='" & cbkons.SelectedValue & "',[Vehicle_validation]= '" & vhc_valid & "', [update_by] = '" & frmlogin.txtusername.Text & "', [update_date] = #" & System.DateTime.Now & "#,[version] = ([version]+1) where [csid]='" & txtcsid.Text & "'"
                cmd = New odbcCommand(sqledit, Conn)
                cmd.ExecuteNonQuery()
            End If
            rd.Close()
            setFlag("tblcs")
            Dim sqlhist As String
            sqlhist = "insert into wbs_cs_hist_tab([csid],[csname],[siteid],[flag],[internal],[sortase],[Vehicle_validation],[create_by],[create_date]) values('" & txtcsid.Text & "','" & txtcsname.Text & "','" & siteid & "','T','" & flagin & "','" & cbkons.SelectedValue & "','" & vhc_valid & "','" & frmlogin.txtusername.Text & "',#" & System.DateTime.Now & "#)"
            cmd = New odbcCommand(sqlhist, Conn)
            cmd.ExecuteNonQuery()
            kosong()
            tampil()
        End If
    End Sub
    Private Sub txtcsid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcsid.KeyPress
        Dim flagin As String = ""
        If e.KeyChar = Chr(13) Then
            cmd = New odbcCommand("select * from wbs_cs_tab where csid='" & txtcsid.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                txtcsname.Text = rd.GetString(1)
                'txtcsaddress.Text = rd.GetString(2)
                cbkons.SelectedValue = rd.GetString(6)
                flagin = rd.GetString(5)
                If flagin.ToString = "T" Then
                    cbint.Checked = True
                Else
                    cbint.Checked = False
                End If
                txtcsname.Focus()
            Else
                baru()
            End If
            rd.Close()
        End If
    End Sub
    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        kosong()
        tampil()
    End Sub
    Private Sub txtcsname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcsname.KeyPress
        If e.KeyChar = Chr(13) Then
            ' txtcsaddress.Focus()
        End If
    End Sub
    Private Sub txtcsaddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtcsid.Text = "" Then
            MsgBox("Customer ID harap diisi terlebih dahulu !!!")
            Exit Sub
        Else
            If MessageBox.Show("Apakah anda yakin data akan dihapus ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cmd = New odbcCommand("delete from wbs_cs_tab where [csid]='" & txtcsid.Text & "'", Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()
            Else
                kosong()
            End If
        End If
    End Sub
    Private Sub dgcs_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgcs.CellDoubleClick
        For Each cell In dgcs.SelectedCells
            kosong()
            txtcsid.Text = dgcs.CurrentRow.Cells(0).Value
            txtcsname.Text = dgcs.CurrentRow.Cells(1).Value
            'txtcsaddress.Text = dgcs.CurrentRow.Cells(2).Value
            If dgcs.CurrentRow.Cells(3).Value = "T" Then
                cbint.Checked = True
            Else
                cbint.Checked = False
            End If
            cbkons.Text = dgcs.CurrentRow.Cells(4).Value
            If dgcs.CurrentRow.Cells(5).Value = "T" Then
                Vhc_Validation.Checked = True
            Else
                Vhc_Validation.Checked = False
            End If
        Next
        kosongdtl()
    End Sub
    Private Sub txtcsid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcsid.TextChanged
        tampiladdress()
        kosongdtl()
    End Sub
    Private Sub dgcs_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgcs.CellContentClick
        txtcsid.Text = dgcs.CurrentRow.Cells(0).Value
        txtcsname.Text = dgcs.CurrentRow.Cells(1).Value
        If dgcs.CurrentRow.Cells(3).Value = "T" Then
            cbint.Checked = True
        Else
            cbint.Checked = False
        End If
        cbkons.Text = dgcs.CurrentRow.Cells(4).Value
        If dgcs.CurrentRow.Cells(5).Value = "T" Then
            Vhc_Validation.Checked = True
        Else
            Vhc_Validation.Checked = False
        End If
        kosongdtl()
    End Sub

    Private Sub txtiddtl_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtiddtl.TextChanged
        editable()
    End Sub
    Private Sub new_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles new_dtl.Click
        If new_dtl.Text = "New" Then
            txtiddtl.Text = ""
            txtnamedtl.Text = ""
            txtaddressdtl.Text = ""
        Else
            savedetail()
        End If
    End Sub

    'Private Sub dgads_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgads.CellContentDoubleClick
    '    For Each cell In dgads.SelectedCells
    '        txtiddtl.Text = dgads.CurrentRow.Cells(0).Value
    '        txtnamedtl.Text = dgads.CurrentRow.Cells(1).Value
    '        txtaddressdtl.Text = dgads.CurrentRow.Cells(2).Value
    '    Next
    'End Sub

    Private Sub savedtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savedtl.Click
        savedetail()
    End Sub

    Private Sub dgads_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgads.CellDoubleClick
        txtiddtl.Text = dgads.CurrentRow.Cells(0).Value
        txtnamedtl.Text = dgads.CurrentRow.Cells(1).Value
        txtaddressdtl.Text = dgads.CurrentRow.Cells(2).Value
    End Sub
End Class