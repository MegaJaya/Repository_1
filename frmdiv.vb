Imports System.Data.Odbc
Public Class frmdiv

    Private Sub frmdiv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        Me.Show()
        Application.DoEvents()
        txtdivid.Focus()
        kosong()
        tampilestate()
        tampil()
    End Sub

    Sub tampilestate()
        da = New odbcDataAdapter("select * from wbs_estate_tab order by estatename", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "est")

        txtestateid.DataSource = (ds.Tables("est"))
        txtestateid.DisplayMember = "estatename"
        txtestateid.ValueMember = "estateid"
    End Sub
    Sub kosong()
        'Dim a As String
        'Dim b As String
        'cmd = New odbcCommand("select divid from wbs_div_tab order by divid desc", Conn)
        'rd = cmd.ExecuteReader
        'rd.Read()

        'If rd.HasRows = True Then

        'a = rd.GetString(0).Substring(4, rd.GetString(0).Length - 4)
        'b = Convert.ToString(CInt(a) + 1)
        'txtdivid.Text = "AFD-" + b
        'txtdivid.Text = "AFD-"
        'Else

        txtdivid.Text = "AFD-"
        'End If
        rd.Close()
        txtestateid.Text = ""
        txtdivname.Text = ""
        txtdivid.Focus()


    End Sub
    Sub tampil()
        da = New odbcDataAdapter("select * from wbs_div_tab where estateid='" & txtestateid.SelectedValue & "' order by estateid,divid", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "div")
        dgdiv.DataSource = (ds.Tables("div"))
        dgdiv.ReadOnly = True


    End Sub
    Sub baru()
        txtdivname.Focus()
        txtdivname.Text = ""
        txtestateid.Text = ""

    End Sub

    Sub simpan()
        If txtdivid.Text = "" Or txtdivname.Text = "" Or txtestateid.Text = "" Then
            MsgBox("Please fill the blank field !!!")
            Exit Sub

        Else
            cmd = New odbcCommand("select * from wbs_div_tab where divid='" & txtdivid.Text & "' and estateid='" & txtestateid.SelectedValue & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                Dim sqladd As String
                Dim siteid As String
                siteid = getSite()

                sqladd = "insert into wbs_div_tab([divid],[divname],[estateid],[siteid]) values('" & txtdivid.Text & "','" & txtdivname.Text & "','" & txtestateid.SelectedValue & "','" & siteid & "')"
                cmd = New odbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()

            Else
                Dim sqledit As String
                sqledit = "update wbs_div_tab set [divname]='" & txtdivname.Text & "',[estateid]='" & txtestateid.SelectedValue & "' where [divid]='" & txtdivid.Text & "' and estateid='" & txtestateid.SelectedValue & "'"
                cmd = New odbcCommand(sqledit, Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()

            End If
            rd.Close()

        End If
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub txtdivid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdivid.KeyPress
        If e.KeyChar = Chr(13) Then
            cmd = New odbcCommand("select * from wbs_div_tab where divid='" & txtdivid.Text & "' and estateid='" & txtestateid.SelectedValue & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                txtdivname.Text = rd.GetString(1)
                txtestateid.SelectedValue = rd.GetString(2)
                txtdivname.Focus()

            Else
                baru()

            End If
            rd.Close()
        End If
    End Sub

    Private Sub txtdivname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdivname.KeyPress
        If e.KeyChar = Chr(13) Then
            txtestateid.Focus()

        End If
    End Sub

    Private Sub txtestateid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        If txtdivid.Text = "" Then
            MsgBox("Fill operator ID field first !!!")
            Exit Sub

        Else
            If MessageBox.Show("Are you sure to delete the data ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                cmd = New odbcCommand("delete from wbs_div_tab where [divid]='" & txtdivid.Text & "' and estateid='" & txtestateid.SelectedValue & "'", Conn)
                cmd.ExecuteNonQuery()
                kosong()
                tampil()

            Else
                kosong()

            End If
        End If
    End Sub

   

    Private Sub dgdiv_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdiv.CellContentDoubleClick
        For Each cell In dgdiv.SelectedCells
            kosong()
            txtdivid.Text = cell.Value.ToString()


        Next
    End Sub

   


    Private Sub txtestateid_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtestateid.KeyPress
        If e.KeyChar = Chr(13) Then
            btnsave.Focus()

        End If
    End Sub

    Private Sub txtestateid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtestateid.SelectedIndexChanged

    End Sub

    Private Sub txtestateid_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtestateid.SelectionChangeCommitted
        tampil()

    End Sub
End Class