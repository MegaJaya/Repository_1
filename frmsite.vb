Imports System.Data.Odbc

Public Class frmsite

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Close()

    End Sub


    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

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

    Private Sub frmsite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Application.DoEvents()

        Koneksi()
        tampil()

    End Sub
    Sub tampil()
        cmd = New odbcCommand("select * from wbs_site_tab", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            txtsiteid.Text = rd.GetString(0)
            txtCompany.Text = rd.GetString(1)
            txtsitename.Text = rd.GetString(2)
            txtsiteaddress.Text = rd.GetString(3)
            txtktuname.Text = rd.GetString(4)
            txtmgrname.Text = rd.GetString(5)
            initialsite.Text = rd.GetString(6)

        Else
            txtsiteid.Text = ""
            txtCompany.Text = ""
            txtsitename.Text = ""
            txtsiteaddress.Text = ""
            txtktuname.Text = ""
            txtmgrname.Text = ""
            initialsite.Text = ""
        End If
        rd.Close()
        txtsiteid.Focus()

    End Sub

    Private Sub txtsiteid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsiteid.KeyPress
        If e.KeyChar = Chr(13) Then
            txtsitename.Focus()
        End If
    End Sub

    Private Sub txtsitename_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsitename.KeyPress
        If e.KeyChar = Chr(13) Then
            txtsiteaddress.Focus()
        End If
    End Sub

    Private Sub txtsiteaddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsiteaddress.KeyPress
        If e.KeyChar = Chr(13) Then
            btnsave.Focus()
        End If
    End Sub

    Sub simpan()
        If txtsiteid.Text = "" Or txtsitename.Text = "" Or txtsiteaddress.Text = "" Or txtCompany.Text = "" Or txtktuname.Text = "" Or txtmgrname.Text = "" Then
            MsgBox("Please fill the blank field !!!")
            Exit Sub
        Else
            cmd = New odbcCommand("select * from wbs_site_tab", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                Dim sqladd As String
                sqladd = "insert into wbs_site_tab(siteid,sitename,company,siteaddress,MGR_name,KTU_Name,initial) values('" & txtsiteid.Text & "','" & txtsitename.Text & "','" & txtCompany.Text & "','" & txtsiteaddress.Text & "','" & txtmgrname.Text & "','" & txtktuname.Text & "','" & initialsite.Text & "')"
                cmd = New OdbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()
                'tampil()
            Else
                Dim sqledit As String
                sqledit = "update wbs_site_tab set siteid='" & txtsiteid.Text & "',sitename='" & txtsitename.Text & "',company='" & txtCompany.Text & "',Mgr_name='" & txtmgrname.Text & "',ktu_name='" & txtktuname.Text & "',siteaddress='" & txtsiteaddress.Text & "',initial='" & initialsite.Text & "'"
                cmd = New OdbcCommand(sqledit, Conn)
                cmd.ExecuteNonQuery()
                'tampil()
            End If
            rd.Close()
            setFlag("tblsite")
        End If
        Me.Close()
    End Sub
   
    Private Sub btnsave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnsave.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim intnum As String
            Dim pass As Double = CDbl(System.DateTime.Now.ToString(("yyyy"))) * CDbl(System.DateTime.Now.ToString(("MM"))) * CDbl(System.DateTime.Now.ToString(("dd")))
            intnum = InputBox("Please insert password to change", "Site")
            If intnum = Convert.ToString(pass) Then
                simpan()
                MsgBox("Update Success")
            Else
                MsgBox("Password wrong")
            End If
        End If
    End Sub

End Class