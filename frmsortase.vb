Imports System.Data.Odbc
Public Class frmsortase



    Private Sub frmsortase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        Me.Show()
        Application.DoEvents()
        txtkonsid.Focus()
        kosong()
        tampil()
    End Sub

    Sub kosong()
        cmd = New odbcCommand("select konsid from wbs_sortase_tab order by konsid desc", Conn)
        rd = cmd.ExecuteReader
        rd.Read()

        If rd.HasRows = True Then
            txtkonsid.Text = rd.GetValue(0) + 1


        Else

            txtkonsid.Text = 1
        End If
        rd.Close()
        txtkonsname.Text = ""
        txtmentah.Text = "0"
        txtlmatang.Text = "0"
        txttankos.Text = "0"
        txtbkecil.Text = "0"
        txttpanjang.Text = "0"
        txtsampah.Text = "1"
        txtkonsid.Focus()
    End Sub
    Sub tampil()
        da = New odbcDataAdapter("select * from wbs_sortase_tab", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "kons")
        dgsortase.DataSource = (ds.Tables("kons"))
        dgsortase.ReadOnly = True

    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()

    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        kosong()
        tampil()

    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        Try


            If txtkonsid.Text = "" Then
                MsgBox("Konstanta ID harap diisi terlebih dahulu !!!")
                Exit Sub

            Else
                If MessageBox.Show("Anda yakin data ingin di hapus ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    cmd = New odbcCommand("delete from wbs_sortase_tab where [konsid]='" & txtkonsid.Text & "'", Conn)
                    cmd.ExecuteNonQuery()
                    kosong()
                    tampil()

                Else
                    kosong()

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        simpan()
    End Sub
    Sub simpan()
        If txtkonsid.Text = "" Or txtkonsname.Text = "" Or txtbkecil.Text = "" Or txtsampah.Text = "" Or txtmentah.Text = "" Or txtlmatang.Text = "" Or txttankos.Text = "" Then
            MsgBox("Harap diisi kolom yang masih kosong !!!")
            Exit Sub

        Else
            cmd = New odbcCommand("select * from wbs_sortase_tab where konsid='" & txtkonsid.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                Dim sqladd As String
                sqladd = "insert into wbs_sortase_tab ([konsid],[konsname],[mentah],[lewatmatang],[tankos],[buahkecil],[sampah],[tpanjang]) VALUES ('" & txtkonsid.Text & "','" & txtkonsname.Text & "','" & txtmentah.Text & "','" & txtlmatang.Text & "','" & txtbkecil.Text & "','" & txttankos.Text & "','" & txtsampah.Text & "','" & txttpanjang.Text & "')"
                cmd = New odbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()

            Else
                Dim sqledit As String
                sqledit = "update wbs_sortase_tab set [konsname]='" & txtkonsname.Text & "',[mentah]='" & txtmentah.Text & "',[lewatmatang]='" & txtlmatang.Text & "' ,[buahkecil]='" & txtbkecil.Text & "' ,[tankos]='" & txttankos.Text & "',[sampah]='" & txtsampah.Text & "',[tpanjang]='" & txttpanjang.Text & "' where [konsid]='" & txtkonsid.Text & "'"
                cmd = New odbcCommand(sqledit, Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()

            End If
            rd.Close()
        End If
    End Sub
    Sub baru()
        txtkonsname.Focus()
        txtbkecil.Text = "0"
        txtmentah.Text = "0"
        txtlmatang.Text = "0"
        txttankos.Text = "0"
        txttpanjang.Text = "0"
        txtsampah.Text = "1"

    End Sub

    Private Sub txtkonsid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtkonsid.KeyPress
        If e.KeyChar = Chr(13) Then
            cmd = New odbcCommand("select * from wbs_sortase_tab where konsid='" & txtkonsid.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                txtkonsname.Text = rd.GetString(1)
                txtmentah.Text = rd.GetString(2)
                txtlmatang.Text = rd.GetString(3)
                txttankos.Text = rd.GetString(4)
                txtbkecil.Text = rd.GetString(5)
                txtsampah.Text = rd.GetString(6)
                txttpanjang.Text = rd.GetString(7)
                txtkonsname.Focus()

            Else
                baru()

            End If
            rd.Close()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub



    Private Sub dgsortase_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgsortase.CellDoubleClick
        For Each cell In dgsortase.SelectedCells
            kosong()
            txtkonsid.Text = cell.Value.ToString()


        Next
    End Sub

    Private Sub txtkonsname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtkonsname.KeyPress
        If e.KeyChar = Chr(13) Then
            txtmentah.Focus()


        End If
    End Sub

 

    Private Sub txtlmatang_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlmatang.KeyPress
        If e.KeyChar = Chr(13) Then
            txttankos.Focus()


        End If
    End Sub

    Private Sub txttankos_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttankos.KeyPress
        If e.KeyChar = Chr(13) Then
            txtbkecil.Focus()


        End If
    End Sub

    Private Sub txtbkecil_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbkecil.KeyPress
        If e.KeyChar = Chr(13) Then
            txttpanjang.Focus()


        End If
    End Sub

    Private Sub txtsampah_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsampah.KeyPress
        If e.KeyChar = Chr(13) Then
            btnsave.Focus()

        End If
    End Sub
    
   
    Private Sub btnsave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnsave.KeyPress
        If e.KeyChar = Chr(13) Then
            simpan()
        End If
    End Sub



    Private Sub txttpanjang_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttpanjang.KeyPress
        If e.KeyChar = Chr(13) Then
            txtsampah.Focus()
        End If
    End Sub

    Private Sub txtmentah_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmentah.KeyPress
        If e.KeyChar = Chr(13) Then
            txtlmatang.Focus()
        End If
    End Sub

    
End Class