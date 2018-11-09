Imports System.Data.Odbc

Public Class frmkontrak

    Private Sub frmkontrak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        Me.Show()
        Application.DoEvents()
        kosong()
        tampil()
        tampilcs()
        tampilpart()


    End Sub

    Sub tampilcs()
        da = New odbcDataAdapter("select * from wbs_cs_tab order by csname", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "cs")

        cbcs.DataSource = (ds.Tables("cs"))
        cbcs.DisplayMember = "csname"
        cbcs.ValueMember = "csid"
    End Sub

    Sub tampilpart()
        da = New odbcDataAdapter("select * from wbs_part_tab where partcat in('CPO','KER','SHL') order by partname", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "part")

        cbpart.DataSource = (ds.Tables("part"))
        cbpart.DisplayMember = "partname"
        cbpart.ValueMember = "partid"
    End Sub
    Sub tampil()
        da = New odbcDataAdapter("select nokontrak,DOBesar,csid,partid,qtykontrak,endkontrak from wbs_kontrak_tab order by nokontrak", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "kon")
        dgkontrak.DataSource = (ds.Tables("kon"))
        dgkontrak.ReadOnly = True
    End Sub
    Sub kosong()
        txtkontrak.Text = ""
        txtDOBesar.Text = ""
        txtqtykontrak.Text = "0"
        dtstart.Value = System.DateTime.Today
        dtexp.Value = System.DateTime.Today
        dtactstart.Value = System.DateTime.Today
        dtactend.Value = System.DateTime.Today

    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub



    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        kosong()
        tampil()
        tampilcs()
        tampilpart()
        dtstart.Value = System.DateTime.Today
    End Sub

    Private Sub txtkontrak_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtkontrak.KeyPress
        Dim fr As String = ""
        If e.KeyChar = Chr(13) Then
            cmd = New odbcCommand("select * from wbs_kontrak_tab where nokontrak='" & txtkontrak.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                txtDOBesar.Text = rd.GetString(1)
                cbcs.SelectedValue = rd.GetString(2)
                cbpart.SelectedValue = rd.GetString(3)
                txtqtykontrak.Text = rd.GetValue(4)
                dtexp.Value = rd.GetDateTime(5)
                dtstart.Value = rd.GetDateTime(9)
                dtactstart.Value = rd.GetDateTime(10)
                dtactend.Value = rd.GetDateTime(11)
                fr = rd.GetString(6)
                If fr = "T" Then
                    cbfr.Checked = True
                Else
                    cbfr.Checked = False
                End If
                cbcs.Focus()

            Else
                baru()

            End If
            rd.Close()
        End If
    End Sub
    Sub baru()
        tampil()
        tampilcs()
        tampilpart()

        txtqtykontrak.Text = "0"
        cbfr.Checked = True
        dtstart.Value = System.DateTime.Today
        dtexp.Value = System.DateTime.Today
        dtactstart.Value = System.DateTime.Today
        dtactend.Value = System.DateTime.Today

        cbcs.Focus()


    End Sub

    Private Sub cbcs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbcs.KeyPress
        If e.KeyChar = Chr(13) Then
            cbpart.Focus()

        End If
    End Sub

    Private Sub cbpart_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbpart.KeyPress
        If e.KeyChar = Chr(13) Then
            txtqtykontrak.Focus()

        End If
    End Sub

    Private Sub txtqtykontrak_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqtykontrak.KeyPress
        If e.KeyChar = Chr(13) Then
            dtstart.Focus()

        End If
    End Sub

    Private Sub dtexp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtstart.KeyPress
        If e.KeyChar = Chr(13) Then
            dtexp.Focus()

        End If

    End Sub
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim pass As String
        pass = ConfirmationPass()
        If pass <> "Cancelled" Then
            cmd = New odbcCommand("select userid from wbs_user_tab where userid='" & frmlogin.txtid.Text & "' and password='" & Enkripsi.Encrypt(pass) & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                simpan()
                MsgBox("Update Success")
            Else
                MsgBox("Password Wrong")
            End If
        End If
    End Sub

    Private Sub btnsave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnsave.KeyPress
        simpan()
    End Sub
    Sub simpan()
        If txtkontrak.Text = "" Or txtqtykontrak.Text = "" Then
            MsgBox("Tolong diisi kolom informasi yang masih kosong !!!")
            Exit Sub

        Else
            Dim fr As String = ""
            If cbfr.Checked = True Then
                fr = "T"
            Else
                fr = "F"
            End If
            cmd = New odbcCommand("select * from wbs_kontrak_tab where nokontrak='" & txtkontrak.Text & "' and DObesar='" & txtDOBesar.Text & "'  ", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                Dim sqladd As String
                sqladd = "insert into wbs_kontrak_tab([nokontrak],[DOBesar],[csid],[partid],[qtykontrak],[endkontrak],[franco],[fcentry],[fcedit],[startkontrak],[actualstart],[actualend]) values('" & txtkontrak.Text & "','" & txtDOBesar.Text & "','" & cbcs.SelectedValue & "','" & cbpart.SelectedValue & "','" & txtqtykontrak.Text & "',#" & Date.Parse(dtexp.Text) & "#,'" & fr & "','" & frmlogin.txtusername.Text & "','" & frmlogin.txtusername.Text & "',#" & Date.Parse(dtstart.Text) & "#,#" & Date.Parse(dtactstart.Text) & "#,#" & Date.Parse(dtactend.Text) & "#)"
                cmd = New odbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()
                kosong()
            Else
                Dim sqledit As String
                sqledit = "update wbs_kontrak_tab set [DOBesar]='" & txtDOBesar.Text & "',[csid]='" & cbcs.SelectedValue & "',[partid]='" & cbpart.SelectedValue & "',[qtykontrak]='" & txtqtykontrak.Text & "',[endkontrak]=#" & Date.Parse(dtexp.Text) & "#,[fcedit]='" & frmlogin.txtusername.Text & "',[franco]='" & fr & "' ,[startkontrak]=#" & Date.Parse(dtstart.Text) & "#,[actualstart]=#" & Date.Parse(dtactstart.Text) & "#,[actualend]=#" & Date.Parse(dtactend.Text) & "#  where [nokontrak]='" & txtkontrak.Text & "' and [dobesar]='" & txtDOBesar.Text & "'"
                cmd = New odbcCommand(sqledit, Conn)
                cmd.ExecuteNonQuery()
                kosong()
            End If
            rd.Close()
            tampil()

        End If
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtkontrak.Text = "" Then
            MsgBox("Nomor Kontrak harap diisi terlebih dahulu !!!")
            Exit Sub

        Else
            If MessageBox.Show("Apakah yakin data ingin dihapus ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cmd = New odbcCommand("delete from wbs_kontrak_tab where [nokontrak]='" & txtkontrak.Text & "'", Conn)
                cmd.ExecuteNonQuery()
                kosong()


            Else
                kosong()

            End If
        End If
        tampil()
        tampilcs()
        tampilpart()

    End Sub


    Private Sub dgkontrak_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgkontrak.CellDoubleClick
        For Each cell In dgkontrak.SelectedCells
            kosong()
            txtkontrak.Text = cell.Value.ToString()
            txtkontrak.Focus()

        Next
    End Sub

    Private Sub dtexp_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtexp.KeyPress
        If e.KeyChar = Chr(13) Then
            dtactstart.Focus()

        End If
    End Sub

    Private Sub dtactstart_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtactstart.KeyPress
        If e.KeyChar = Chr(13) Then
            dtactend.Focus()
        End If
    End Sub

    Private Sub dtactend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtactend.KeyPress
        If e.KeyChar = Chr(13) Then
            btnsave.Focus()
        End If
    End Sub

   
End Class