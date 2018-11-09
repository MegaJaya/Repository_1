Imports System.Data.Odbc
Public Class frmgradetbs
    Private Sub frmgradetbsLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        Me.Show()
        Application.DoEvents()
        Kosong()
        tampil()
        KodeOtomatis()

    End Sub
    Sub KodeOtomatis()
        cmd = New odbcCommand("select ID from wbs_grade_tbs order by ID desc", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then

            txtid.Text = "ID"
        Else
            txtid.Text = "" + Format(Microsoft.VisualBasic.Right(rd.Item("ID"), 2) + 1, "0")

        End If
    End Sub

    Sub kosong()
        cmd = New odbcCommand("select * from wbs_grade_tbs order by id", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows = True Then
            txtid.Text = ""
        Else
            txtid.Text = rd.GetValue(0)
        End If
        rd.Close()
        txtgradecode.Text = ""
        txtdesc.Text = ""
        txtid.Focus()
        txtsite.Text = SiteId_
        Call KodeOtomatis()

    End Sub
    Sub tampil()
        da = New odbcDataAdapter(" select *  from wbs_grade_tbs order by gradecode asc", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "block")
        dgblock.DataSource = (ds.Tables("block"))
        dgblock.ReadOnly = True
    End Sub
    Sub baru()
        txtgradecode.Focus()
        txtgradecode.Text = ""
        txtdesc.Text = ""
        txtsite.Text = SiteId_
        Call KodeOtomatis()
    End Sub
    Sub Simpan()
        If txtid.Text = "" Or txtdesc.Text = "" Or txtsite.Text = "" Then
            MsgBox("Harap Isi Data Yang Masih Kosong !!!")
            Exit Sub
        Else
            Dim sql123 As String
            sql123 = "select * from wbs_grade_tbs where id =" & CInt(txtid.Text) & " "
            cmd = New odbcCommand(sql123, Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                Dim sqladd As String
                sqladd = "insert into wbs_grade_tbs([ID],[gradecode],[Description],[siteid])values('" & txtid.Text & "','" & txtgradecode.Text & "','" & txtdesc.Text & "','" & txtsite.Text & "')"
                MsgBox("Data Berhasil Ditambahkan....")
                cmd = New odbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()
                kosong()
            Else
                If MessageBox.Show("Data Telah Terupdate....", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    Dim sqledit As String
                    sqledit = "update wbs_grade_tab set Description='" & txtdesc.Text & "', siteid='" & txtsite.Text & "' where id=" & txtid.Text & ""
                    cmd = New odbcCommand(sqledit, Conn)
                    cmd.ExecuteNonQuery()
                End If
            End If
            kosong()
            tampil()
            rd.Close()
        End If
    End Sub
    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        kosong()
        tampil()
    End Sub
    Private Sub btncancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Call kosong()
        Call KodeOtomatis()
    End Sub
    Private Sub btndelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtid.Text = "" Then
            MsgBox("Fill operator ID field first !!!")
            Exit Sub
        Else
            If MessageBox.Show("Are you sure to delete the data ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String = "delete from wbs_grade_tbs where id =" & CInt(txtid.Text) & ""
                cmd = New odbcCommand(hapus, Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()
                Call KodeOtomatis()
            Else
                kosong()
                Call KodeOtomatis()
            End If
        End If
    End Sub
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Simpan()
        Call KodeOtomatis()

    End Sub
    Private Sub txtid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtid.KeyPress
        txtid.MaxLength = 20
        If e.KeyChar = Chr(0) Then

            cmd = New odbcCommand("select * from wbs_grade_tab where id =" & CInt(txtid.Text) & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                txtgradecode.Text = rd.GetString(1)
                txtdesc.Text = rd.GetString(2)
                txtsite.Text = rd.GetString(3)
                txtgradecode.Focus()
            Else
                baru()
            End If
            rd.Close()
            Call KodeOtomatis()
        End If
    End Sub
    Private Sub cbproduct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            txtdesc.Focus()
        End If
    End Sub
    Private Sub txtid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid.TextChanged

        If txtid.Text = "" Then
            btndelete.Enabled = False
            btnsave.Enabled = False
        Else
            btndelete.Enabled = True
            btnsave.Enabled = True
        End If
    End Sub
    Private Sub dgblock_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgblock.CellContentClick
        txtid.Text = dgblock.CurrentRow.Cells(0).Value
        txtgradecode.Text = dgblock.CurrentRow.Cells(1).Value
        txtdesc.Text = dgblock.CurrentRow.Cells(2).Value
        txtsite.Text = dgblock.CurrentRow.Cells(3).Value
    End Sub
    Private Sub txtdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdesc.KeyPress
        If e.KeyChar = Chr(13) Then
            btnsave.Focus()
        End If
    End Sub
    Private Sub txtstorage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgradecode.KeyPress
        If e.KeyChar = Chr(13) Then
            txtsite.Focus()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class