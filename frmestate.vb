Imports System.Data.Odbc
Public Class frmestate

    Private Sub frmestate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        Me.Show()
        Application.DoEvents()
        kosong()
        tampil()
    End Sub
    Sub tampil()
        da = New odbcDataAdapter("select * from wbs_estate_tab order by estateid", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "estate")
        dgestate.DataSource = (ds.Tables("estate"))
        dgestate.ReadOnly = True
    End Sub
    Sub kosong()
        txtestateid.Text = ""
        txtestatename.Text = ""
        txtestateid.Focus()

    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        kosong()

    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        simpan()
    End Sub
    Sub simpan()
        If txtestateid.Text = "" Or txtestatename.Text = "" Then
            MsgBox("Please fill the blank field !!!")
            Exit Sub

        Else
            Dim siteid As String
            siteid = getSite()
            cmd = New odbcCommand("select * from wbs_estate_tab where estateid='" & txtestateid.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                Dim sqladd As String
                sqladd = "insert into wbs_estate_tab([estateid],[estatename]) values('" & txtestateid.Text & "','" & txtestatename.Text & "')"
                cmd = New odbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()
                kosong()


            Else
                Dim sqledit As String
                sqledit = "update wbs_estate_tab set [estatename]='" & txtestatename.Text & "' where [estateid]='" & txtestateid.Text & "'"
                cmd = New odbcCommand(sqledit, Conn)
                cmd.ExecuteNonQuery()
                kosong()


            End If
            rd.Close()
            tampil()

        End If
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtestateid.Text = "" Then
            MsgBox("Kode estate harap diisi terlebih dahulu !!!")
            Exit Sub

        Else
            If MessageBox.Show("Apakah yakin data ingin dihapus ? ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cmd = New odbcCommand("delete from wbs_estate_tab where [estateid]='" & txtestateid.Text & "'", Conn)
                cmd.ExecuteNonQuery()
                kosong()


            Else
                kosong()

            End If
        End If
        tampil()

    End Sub

    Private Sub dgestate_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgestate.CellContentClick


    End Sub

    Private Sub txtestateid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtestateid.KeyPress
        If e.KeyChar = Chr(13) Then
            cmd = New odbcCommand("select * from wbs_estate_tab where estateid='" & txtestateid.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                txtestatename.Text = rd.GetString(1)
                txtestatename.Focus()
            Else
                txtestatename.Focus()

            End If
            rd.Close()
        End If
    End Sub

    Private Sub txtestatename_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtestatename.KeyPress
        If e.KeyChar = Chr(13) Then
            
            btnsave.Focus()

        End If
        
    End Sub

   
   
    Private Sub btnsave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnsave.KeyPress
        simpan()

    End Sub

    Private Sub dgestate_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgestate.CellDoubleClick
        For Each cell In dgestate.SelectedCells
            kosong()
            txtestateid.Text = cell.Value.ToString()
            txtestateid.Focus()

        Next
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txtestateid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtestateid.TextChanged

    End Sub
End Class