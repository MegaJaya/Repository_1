Imports System.Data.Odbc
Public Class frmblock
    Private Sub frmblock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        Me.Show()
        Application.DoEvents()
        tampilest()
        kosong()
        tampildiv()
        tampil()
    End Sub
    Sub tampilest()
        da = New odbcDataAdapter("select * from wbs_estate_tab order by estatename", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "est")

        cbestate.DataSource = (ds.Tables("est"))
        cbestate.DisplayMember = "estatename"
        cbestate.ValueMember = "estateid"
    End Sub
    Sub tampildiv()
        da = New odbcDataAdapter("select * from wbs_div_tab where estateid='" & cbestate.SelectedValue & "' order by divname", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "div")

        cbdivisi.DataSource = (ds.Tables("div"))
        cbdivisi.DisplayMember = "divname"
        cbdivisi.ValueMember = "divid"
    End Sub
    Sub kosong()
        cmd = New odbcCommand("select * from wbs_block_tab order by blockid ", Conn)
        rd = cmd.ExecuteReader
        rd.Read()

        If Not rd.HasRows = True Then
            txtblockid.Text = "A01"
        Else
            txtblockid.Text = rd.GetString(0)

        End If
        rd.Close()
        txtblockname.Text = ""
        txtblockdesc.Text = ""
        txtblockid.Focus()


    End Sub
    Sub tampil()
        da = New odbcDataAdapter("select a.blockid,a.blockname,a.divid as afdeling,a.estateid as kebun,a.blockdesc as Description, Format(b.tt,'yyyy') as tahun_tanam from wbs_block_tab a left join tahun_tanam  b on a.estateid = b.estateid and a.divid = b.division and a.blockid = b.fccode where a.divid='" & cbdivisi.SelectedValue & "' and a.estateid='" & cbestate.SelectedValue & "' order by a.estateid,a.divid,a.blockid", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "block")
        dgblock.DataSource = (ds.Tables("block"))
        dgblock.ReadOnly = True
    End Sub
    Sub baru()
        txtblockname.Focus()
        txtblockname.Text = ""
        txtblockdesc.Text = ""

    End Sub
    Sub simpan()
        If txtblockid.Text = "" Or txtblockname.Text = "" Or txtblockdesc.Text = "" Then
            MsgBox("Please fill the blank field !!!")
            Exit Sub

        Else
            Dim siteid As String
            siteid = getSite()
            cmd = New odbcCommand("select * from wbs_block_tab where blockid='" & txtblockid.Text & "' and divid='" & cbdivisi.SelectedValue & "' and estateid='" & cbestate.SelectedValue & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                Dim sqladd As String
                sqladd = "insert into wbs_block_tab([blockid],[blockname],[blockdesc],[siteid],[FLAG],[divid],[estateid]) values('" & txtblockid.Text & "','" & txtblockname.Text & "','" & txtblockdesc.Text & "','" & siteid & "','T','" & cbdivisi.SelectedValue & "','" & cbestate.SelectedValue & "')"
                cmd = New odbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()

            Else
                Dim sqledit As String
                sqledit = "update wbs_block_tab set [blockname]='" & txtblockname.Text & "',[blockdesc]='" & txtblockdesc.Text & "',[FLAG]='T',[divid]='" & cbdivisi.SelectedValue & "',[estateid]='" & cbestate.SelectedValue & "' where [blockid]='" & txtblockid.Text & "' and divid='" & cbdivisi.SelectedValue & "' and estateid='" & cbestate.SelectedValue & "'"
                cmd = New odbcCommand(sqledit, Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()

            End If
            rd.Close()
            setFlag("tblblock")
        End If
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        kosong()
        tampil()

    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtblockid.Text = "" Then
            MsgBox("Fill operator ID field first !!!")
            Exit Sub

        Else
            If MessageBox.Show("Are you sure to delete the data ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cmd = New odbcCommand("delete from wbs_block_tab where [blockid]='" & txtblockid.Text & "' and divid='" & cbdivisi.SelectedValue & "' and estateid='" & cbestate.SelectedValue & "'", Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()

            Else
                kosong()

            End If
        End If
    End Sub

    Private Sub txtblockid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtblockid.KeyPress
        If e.KeyChar = Chr(13) Then
            cmd = New odbcCommand("select * from wbs_block_tab where blockid='" & txtblockid.Text & "' and divid='" & cbdivisi.SelectedValue & "' and estateid='" & cbestate.SelectedValue & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                txtblockname.Text = rd.GetString(1)
                txtblockdesc.Text = rd.GetString(2)
                cbdivisi.SelectedValue = rd.GetString(5)
                cbestate.SelectedValue = rd.GetString(6)
                txtblockname.Focus()

            Else
                baru()

            End If
            rd.Close()
        End If
    End Sub

    Private Sub txtblockname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtblockname.KeyPress
        If e.KeyChar = Chr(13) Then
            cbestate.Focus()

        End If
    End Sub

    Private Sub txtblockdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtblockdesc.KeyPress
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

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub dgblock_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgblock.CellContentClick
        txtblockid.Text = dgblock.CurrentRow.Cells(0).Value
        txtblockname.Text = dgblock.CurrentRow.Cells(1).Value
        cbestate.Text = dgblock.CurrentRow.Cells(2).Value
        cbdivisi.Text = dgblock.CurrentRow.Cells(3).Value
        txtblockdesc.Text = dgblock.CurrentRow.Cells(4).Value
    End Sub


    Private Sub cbestate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbestate.KeyPress
        If e.KeyChar = Chr(13) Then
            cbdivisi.Focus()

        End If
    End Sub

    Private Sub cbdivisi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbdivisi.KeyPress
        If e.KeyChar = Chr(13) Then
            txtblockdesc.Focus()

        End If
    End Sub

    Private Sub cbestate_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbestate.SelectionChangeCommitted
        tampildiv()
        tampil()
    End Sub

    Private Sub cbdivisi_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbdivisi.SelectionChangeCommitted
        tampil()
    End Sub

    Private Sub txtblockid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtblockid.TextChanged
        If txtblockid.Text = "" Then
            btndelete.Enabled = False
            btnsave.Enabled = False
        Else
            btndelete.Enabled = True
            btnsave.Enabled = True
        End If
    End Sub

    Private Sub dgv_EmployeeTraining_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgblock.RowPostPaint

        If e.RowIndex < Me.dgblock.RowCount - 1 Then
            Dim dgvRow As DataGridViewRow = Me.dgblock.Rows(e.RowIndex)

            If dgvRow.Cells("tahun_tanam").Value.ToString = "" Then
                dgvRow.DefaultCellStyle.BackColor = Color.Red
            End If

        End If

    End Sub
End Class