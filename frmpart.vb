Imports System.Data.Odbc

Public Class frmpart


    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()

    End Sub

    Private Sub frmpart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        Me.Show()
        Application.DoEvents()
        txtpartid.Focus()
        kosong()
        tampil()
        cbcat.Items.Add("TBS")
        cbcat.Items.Add("CPO")
        cbcat.Items.Add("DLL")
        cbcat.SelectedIndex = 0
    End Sub

    Sub kosong()
        
        txtpartid.Text = ""
        txtpartname.Text = ""
        txtpartdesc.Text = ""
        txtpartid.Focus()


    End Sub
    Sub tampil()
        da = New odbcDataAdapter("select partid,partname,partdesc,partcat from wbs_part_tab order by partcat,partname", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "part")
        dgpart.DataSource = (ds.Tables("part"))
        dgpart.ReadOnly = True


    End Sub
    Sub baru()
        txtpartname.Focus()
        txtpartname.Text = ""
        txtpartdesc.Text = ""

    End Sub

    Sub simpan()
        If txtpartid.Text = "" Or txtpartname.Text = "" Or txtpartdesc.Text = "" Then
            MsgBox("Kolom yang kosong harap diisi terlebih dahulu !!!")
            Exit Sub
        ElseIf Len(txtpartid.Text) <> 3 Then
            MsgBox("Part ID harus 3 huruf !!!")

        Else
            cmd = New odbcCommand("select * from wbs_part_tab where partid='" & txtpartid.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                Dim sqladd As String
                Dim siteid As String
                siteid = getSite()


                sqladd = "insert into wbs_part_tab([partid],[partname],[partcat],[partdesc],[siteid],[flag],[partcode],[version]) values('" & txtpartid.Text & "','" & txtpartname.Text & "','" & cbcat.SelectedItem & "','" & txtpartdesc.Text & "','" & siteid & "','T','" & txtpartid.Text & "','1')"
                cmd = New odbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()

            Else
                Dim sqledit As String
                Dim version As Integer
                version = rd.GetValue(7) + 1
                sqledit = "update wbs_part_tab set [partname]='" & txtpartname.Text & "',[partcat]='" & cbcat.SelectedItem & "',[partdesc]='" & txtpartdesc.Text & "',[flag]='T',[version]='" & version & "' where [partid]='" & txtpartid.Text & "'"
                cmd = New odbcCommand(sqledit, Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()
            End If
            rd.Close()
            setFlag("tblpart")
        End If
    End Sub

    Private Sub txtpartid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpartid.KeyPress
        If e.KeyChar = Chr(13) Then
            cmd = New odbcCommand("select * from wbs_part_tab where partid='" & txtpartid.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                txtpartname.Text = rd.GetString(1)
                txtpartdesc.Text = rd.GetString(2)
                cbcat.SelectedItem = rd.GetString(3)
                txtpartname.Focus()

            Else
                baru()

            End If
            rd.Close()
        End If
    End Sub

    Private Sub txtpartname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpartname.KeyPress
        If e.KeyChar = Chr(13) Then
            txtpartdesc.Focus()

        End If
    End Sub

    Private Sub txtpartdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpartdesc.KeyPress
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
        If txtpartid.Text = "" Then
            MsgBox("PARTID harap diisi terlebih dahulu !!!")
            Exit Sub

        Else
            If MessageBox.Show("Apakah anda yakin data akan dihapus ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cmd = New odbcCommand("delete from wbs_part_tab where [partid]='" & txtpartid.Text & "'", Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()

            Else
                kosong()

            End If
        End If
    End Sub

    Private Sub dgpart_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgpart.CellDoubleClick
        For Each cell In dgpart.SelectedCells
            kosong()
            txtpartid.Text = cell.Value.ToString()


        Next
    End Sub

    

    
    Private Sub dgpart_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgpart.CellContentClick

    End Sub

   
End Class