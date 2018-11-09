Imports System.Data.Odbc
Public Class frmmanual

    Private Sub frmmanual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        Me.Show()
        Application.DoEvents()
        tampil()
    End Sub

    Sub tampil()
        cmd = New odbcCommand("select status from wbs_flag_tab where flagid='urgent'", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            If rd.GetString(0) = "T" Then
                cbmanual.Checked = True
            Else
                cbmanual.Checked = False
            End If
        Else

        End If
        rd.Close()

    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Close()

    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim intnum As String
        Dim pass As Double = CDbl(System.DateTime.Now.ToString(("yyyy"))) * CDbl(System.DateTime.Now.ToString(("MM"))) * CDbl(System.DateTime.Now.ToString(("dd")))
        intnum = InputBox("Please insert password to change", "Upload Timer")
        If intnum = Convert.ToString(pass) Then
            simpan()
            MsgBox("Update Success")
        Else
            MsgBox("Password wrong")
        End If
    End Sub

    Sub simpan()

        Dim status As String
        If cbmanual.Checked = True Then
            status = "T"
        Else
            status = "F"
        End If
        cmd = New odbcCommand("update wbs_flag_tab set [status]='" & status & "' where [flagid]='urgent'", Conn)
        cmd.ExecuteNonQuery()

        Me.Close()



    End Sub
End Class