Imports System.Data.Odbc
Public Class frmdriver

    Private Sub frmdriver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        Me.Show()
        Application.DoEvents()
        kosong()
        tampil()
    End Sub

    Sub kosong()
        txtdriverid.Text = ""
        txtdrivername.Text = ""
        txtsimno.Text = ""
        cmd = New odbcCommand("select driverid from wbs_driver_tab order by driverid desc", Conn)
        rd = cmd.ExecuteReader
        rd.Read()

        If rd.HasRows = True Then
            txtdriverid.Text = rd.GetValue(0) + 1


        Else

            txtdriverid.Text = 1
        End If
        rd.Close()
        txtdrivername.Text = ""
        txtsimno.Text = ""
        txtdriverid.Focus()

    End Sub

    Sub tampil()
        da = New odbcDataAdapter("select driverid,drivername,simno,expdate,blacklist_flag from wbs_driver_tab order by driverid", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "drv")
        dgdriver.DataSource = (ds.Tables("drv"))
        dgdriver.ReadOnly = True
    End Sub


    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()

    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtdriverid.Text = "" Then
            MsgBox("ID Supir harap diisi terlebih dahulu !!!")
            Exit Sub

        Else
            If MessageBox.Show("Apakah yakin data ingin dihapus ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cmd = New odbcCommand("delete from wbs_driver_tab where [driverid]='" & txtdriverid.Text & "'", Conn)
                cmd.ExecuteNonQuery()
                kosong()


            Else
                kosong()

            End If
        End If
        tampil()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        kosong()

    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        simpan()
    End Sub
    Sub simpan()
        Dim bl As String

        If cb1.Checked = True Then
            bl = "T"
        Else
            bl = "F"
        End If
        If txtdriverid.Text = "" Or txtdrivername.Text = "" Then
            MsgBox("Tolong diisi kolom informasi yang masih kosong !!!")
            Exit Sub

        Else

            cmd = New odbcCommand("select * from wbs_driver_tab where driverid='" & txtdriverid.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()

            If Not rd.HasRows Then
                Dim sqladd As String
                sqladd = "insert into wbs_driver_tab([driverid],[drivername],[simno],[expdate],[blacklist_flag]) values('" & txtdriverid.Text & "','" & txtdrivername.Text & "','" & txtsimno.Text & "',#" & Date.Parse(dtexp.Text) & "#,'" & bl & "')"
                cmd = New odbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()
                kosong()


            Else
                Dim sqledit As String
                sqledit = "update wbs_driver_tab set [drivername]='" & txtdrivername.Text & "',[expdate]=#" & Date.Parse(dtexp.Text) & "#,[simno]='" & txtsimno.Text & "',[blacklist_flag]='" & bl & "' where [driverid]='" & txtdriverid.Text & "'"
                cmd = New odbcCommand(sqledit, Conn)
                cmd.ExecuteNonQuery()
                kosong()


            End If
            rd.Close()
            tampil()

        End If
    End Sub

    Private Sub txtdriverid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdriverid.KeyPress
        If e.KeyChar = Chr(13) Then
            cmd = New odbcCommand("select driverid,drivername,simno,expdate,blacklist_flag from wbs_driver_tab where driverid='" & txtdriverid.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                txtdrivername.Text = rd.GetString(1)
                dtexp.Value = rd.GetDateTime(3)
                txtsimno.Text = rd.GetString(2)

                If rd.GetString(4) = "T" Then
                    cb1.Checked = True
                Else
                    cb1.Checked = False
                End If
                txtdrivername.Focus()

            Else
                baru()

            End If
            rd.Close()
        End If
    End Sub
    Sub baru()
        txtdrivername.Text = ""
        txtsimno.Text = ""
        txtdrivername.Focus()
    End Sub

    Private Sub txtdriverid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdriverid.TextChanged

    End Sub

    Private Sub txtdrivername_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdrivername.KeyPress
        If e.KeyChar = Chr(13) Then
            txtsimno.Focus()

        End If
    End Sub

    Private Sub txtsimno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsimno.KeyPress
        If e.KeyChar = Chr(13) Then
            dtexp.Focus()

        End If
    End Sub

    Private Sub dtexp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtexp.KeyPress
        If e.KeyChar = Chr(13) Then
            btnsave.Focus()

        End If
    End Sub


    Private Sub dgdriver_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdriver.CellContentClick
        txtdriverid.Text = dgdriver.CurrentRow.Cells(0).Value
        txtdrivername.Text = dgdriver.CurrentRow.Cells(1).Value
        txtsimno.Text = dgdriver.CurrentRow.Cells(2).Value
        dtexp.Value = dgdriver.CurrentRow.Cells(3).Value
        If dgdriver.CurrentRow.Cells(4).Value = "T" Then
            cb1.Checked = True
        Else
            cb1.Checked = False
        End If
    End Sub
End Class