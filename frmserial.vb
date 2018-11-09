Imports System.Data.Odbc

Public Class frmserial


    Private Sub frmserial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Show()
        Application.DoEvents()
        Koneksi()
        tampil()
    End Sub


    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Close()

    End Sub
    Sub tampil()
        txtport.Focus()
        cmd = New odbcCommand("select * from wbs_serial_tab", Conn)
        rd = cmd.ExecuteReader
        rd.Read()


        If rd.HasRows Then
            txtport.Text = rd.GetString(0)
            txtbaudrate.Text = rd.GetString(1)
            txtdatabit.Text = rd.GetString(2)
            txtstopbit.Text = rd.GetString(3)
            txtparity.Text = rd.GetString(4)
            sec_load.Text = rd.GetString(5)
            interval_load.Text = rd.GetValue(6)
        Else
            txtport.Text = ""
            txtbaudrate.Text = ""
            txtdatabit.Text = ""
            txtstopbit.Text = ""
            txtparity.Text = ""
            sec_load.Text = ""
            interval_load.Text = ""
        End If
        rd.Close()

    End Sub
    Sub simpan()
        If txtport.Text = "" Or txtbaudrate.Text = "" Or txtdatabit.Text = "" Or txtstopbit.Text = "" Or txtparity.Text = "" Then
            MsgBox("Please fill the blank field !!!")
            Exit Sub

        Else
            cmd = New odbcCommand("select * from wbs_serial_tab ", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                Dim sqladd As String
                sqladd = "insert into wbs_serial_tab([rs_port],[rs_baudrate],[rs_databit],[rs_stopbit],[rs_parity],[sec_load],[interval_load]) values('" & txtport.Text & "','" & txtbaudrate.Text & "','" & txtdatabit.Text & "','" & txtstopbit.Text & "','" & txtparity.Text & "','" & sec_load.Text & "','" & interval_load.Text & "')"
                cmd = New odbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()
                'tampil()

            Else
                Dim sqledit As String
                sqledit = "update wbs_serial_tab set [rs_port]='" & txtport.Text & "',[rs_baudrate]='" & txtbaudrate.Text & "',[rs_databit]='" & txtdatabit.Text & "',[rs_stopbit]='" & txtstopbit.Text & "',[rs_parity]='" & txtparity.Text & "',[sec_load]='" & sec_load.Text & "',[interval_load]='" & interval_load.Text & "' "
                cmd = New odbcCommand(sqledit, Conn)
                cmd.ExecuteNonQuery()
                'tampil()

            End If
            rd.Close()
            Me.Close()

        End If
    End Sub

    Private Sub txtport_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtport.KeyPress
        If e.KeyChar = Chr(13) Then
            txtbaudrate.Focus()

        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub

    Private Sub txtbaudrate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbaudrate.KeyPress
        If e.KeyChar = Chr(13) Then
            txtdatabit.Focus()

        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub

    Private Sub txtdatabit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdatabit.KeyPress
        If e.KeyChar = Chr(13) Then
            txtstopbit.Focus()

        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub

    Private Sub txtstopbit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstopbit.KeyPress
        If e.KeyChar = Chr(13) Then
            txtparity.Focus()

        End If
        'If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub

    Private Sub txtparity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtparity.KeyPress
        If e.KeyChar = Chr(13) Then
            btnsave.Focus()

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


        'Dim intnum As String
        'Dim pass As Double = CDbl(System.DateTime.Now.ToString(("yyyy"))) * CDbl(System.DateTime.Now.ToString(("MM"))) * CDbl(System.DateTime.Now.ToString(("dd")))
        'intnum = InputBox("Please insert password to change", "Serial")
        'If intnum = Convert.ToString(pass) Then
        '    simpan()
        '    MsgBox("Update Success")
        'Else
        '    MsgBox("Password wrong")
        'End If

    End Sub

    Private Sub btnsave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnsave.KeyPress
        Dim intnum As String
        Dim pass As Double = CDbl(System.DateTime.Now.ToString(("yyyy"))) * CDbl(System.DateTime.Now.ToString(("MM"))) * CDbl(System.DateTime.Now.ToString(("dd")))
        intnum = InputBox("Please insert password to change", "Serial")
        If intnum = Convert.ToString(pass) Then
            simpan()
            MsgBox("Update Success")
        Else
            MsgBox("Password wrong")
        End If

    End Sub
End Class