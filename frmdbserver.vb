Imports System.Data.Odbc

Public Class frmdbserver


    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Close()

    End Sub
    Sub tampil()
        txtdbname.Focus()
        cmd = New odbcCommand("select * from wbs_dbserver_tab", Conn)
        rd = cmd.ExecuteReader
        rd.Read()


        If rd.HasRows Then
            txtdbname.Text = rd.GetString(0)
            txtdbip.Text = rd.GetString(1)
            txtdbport.Text = rd.GetString(2)
            txtdbuser.Text = rd.GetString(3)
            txtdbpassword.Text = rd.GetString(4)
        Else
            txtdbname.Text = ""
            txtdbip.Text = ""
            txtdbport.Text = "1521"
            txtdbuser.Text = ""
            txtdbpassword.Text = ""

        End If
        rd.Close()

    End Sub
    Sub simpan()
        If txtdbname.Text = "" Or txtdbip.Text = "" Or txtdbport.Text = "" Or txtdbuser.Text = "" Or txtdbpassword.Text = "" Then
            MsgBox("Please fill the blank field !!!")
            Exit Sub

        Else
            cmd = New odbcCommand("select * from wbs_dbserver_tab ", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                Dim sqladd As String
                sqladd = "insert into wbs_dbserver_tab([dbname],[dbip],[dbport],[dbuser],[dbpassword]) values('" & txtdbname.Text & "','" & txtdbip.Text & "','" & txtdbport.Text & "','" & txtdbuser.Text & "','" & txtdbpassword.Text & "')"
                cmd = New odbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()
                'tampil()

            Else
                Dim sqledit As String
                sqledit = "update wbs_dbserver_tab set [dbname]='" & txtdbname.Text & "',[dbip]='" & txtdbip.Text & "',[dbport]='" & txtdbport.Text & "',[dbuser]='" & txtdbuser.Text & "',[dbpassword]='" & txtdbpassword.Text & "' "
                cmd = New odbcCommand(sqledit, Conn)
                cmd.ExecuteNonQuery()
                'tampil()

            End If
            rd.Close()
            Me.Close()

        End If
    End Sub

    Private Sub frmdbserver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        Me.Show()
        Application.DoEvents()
        tampil()

    End Sub

    Private Sub txtdbname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdbname.KeyPress
        If e.KeyChar = Chr(13) Then
            txtdbip.Focus()

        End If
    End Sub

    Private Sub txtdbip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdbip.KeyPress
        If e.KeyChar = Chr(13) Then
            txtdbport.Focus()

        End If
        'If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub

    Private Sub txtdbport_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdbport.KeyPress
        If e.KeyChar = Chr(13) Then
            txtdbuser.Focus()

        End If
    End Sub

    Private Sub txtdbuser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdbuser.KeyPress
        If e.KeyChar = Chr(13) Then
            txtdbpassword.Focus()

        End If
    End Sub

    Private Sub txtdbpassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdbpassword.KeyPress
        If e.KeyChar = Chr(13) Then
            btnsave.Focus()

        End If
    End Sub


    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim intnum As String
        Dim pass As Double = CDbl(System.DateTime.Now.ToString(("yyyy"))) * CDbl(System.DateTime.Now.ToString(("MM"))) * CDbl(System.DateTime.Now.ToString(("dd")))
        intnum = InputBox("Please insert password to change", "Database Server")
        If intnum = Convert.ToString(pass) Then
            simpan()
            MsgBox("Update Success")
        Else
            MsgBox("Password wrong")
        End If

    End Sub

    Private Sub btnsave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnsave.KeyPress
        Dim intnum As String
        Dim pass As Double = CDbl(System.DateTime.Now.ToString(("yyyy"))) * CDbl(System.DateTime.Now.ToString(("MM"))) * CDbl(System.DateTime.Now.ToString(("dd")))
        intnum = InputBox("Please insert password to change", "Database Server")
        If intnum = Convert.ToString(pass) Then
            simpan()
            MsgBox("Update Success")
        Else
            MsgBox("Password wrong")
        End If

    End Sub
End Class