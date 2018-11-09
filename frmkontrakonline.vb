Imports System.Data.Odbc
Imports System.Data.OracleClient

Public Class frmkontrakonline
    Dim Con3 As OracleConnection
    Dim Con2 As OracleConnection
    Dim od As OracleDataReader
    Dim cmd4 As OracleCommand
    Private Sub frmkontrak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        koneksi2()
        Me.Show()
        Application.DoEvents()
        kosong()
        kosong2()
        tampil()
        tampil2()
    End Sub

    Sub tampil()
        da = New odbcDataAdapter("select nokontrak,csid,partid,qtykontrak,endkontrak,fieldid from wbs_kontrak_tab order by nokontrak", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "kon")
        DGVLocal.DataSource = (ds.Tables("kon"))
        DGVLocal.ReadOnly = True
    End Sub
    Sub tampil2()
        da = New odbcDataAdapter("select Fieldid,ContractCode,DeliveryOrder,Datefrom,Quantity,RowStated from wbs_kontrakdetail_tab order by DeliveryOrder", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "kon")
        DGVLocal2.DataSource = (ds.Tables("kon"))
        DGVLocal2.ReadOnly = True
    End Sub
    
    Sub kosong()
        txtkontrak.Text = ""
        txtCustomer.Text = ""
        dtstart.Value = System.DateTime.Today
        dtexp.Value = System.DateTime.Today
        dtactstart.Value = System.DateTime.Today
        dtactend.Value = System.DateTime.Today
        txtpartcode.Text = ""
        txtqtykontrak.Text = "0"
        txtfcentry.Text = ""
        txtfcba.Text = ""
        txtfieldid.Text = ""
    End Sub
    Sub kosong2()
        txtfieldid_detail.Text = ""
        txtkontrakno_detail.Text = ""
        txtdtpker_detail.Value = System.DateTime.Today
        txtdo_detail.Text = ""
        txtqtydo_detail.Text = "0"
        txtstatus.Text = ""
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        kosong()
        tampil()
        dtstart.Value = System.DateTime.Today
    End Sub

    Private Sub txtkontrak_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtkontrak.KeyPress
        Dim fr As String = ""
        If e.KeyChar = Chr(13) Then
            cmd = New odbcCommand("select * from wbs_kontrak_tab where nokontrak='" & txtkontrak.Text & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                txtCustomer.Text = rd.GetString(1)
                txtqtykontrak.Text = rd.GetValue(4)
                dtexp.Value = rd.GetDateTime(5)
                dtstart.Value = rd.GetDateTime(9)
                dtactstart.Value = rd.GetDateTime(10)
                dtactend.Value = rd.GetDateTime(11)
                txtfieldid.Text = rd.GetString(13)
                fr = rd.GetString(6)
                If fr = "T" Then
                    'cbfr.Checked = True
                Else
                    'cbfr.Checked = False
                End If
                'cbcs.Focus()

            Else
                baru()

            End If
            rd.Close()
        End If
    End Sub
    Sub baru()
        tampil()
        'tampilcs()
        'tampilpart()
        txtqtykontrak.Text = "0"
        'cbfr.Checked = True
        dtstart.Value = System.DateTime.Today
        dtexp.Value = System.DateTime.Today
        dtactstart.Value = System.DateTime.Today
        dtactend.Value = System.DateTime.Today
        'cbcs.Focus()
    End Sub
    Private Sub cbcs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            'cbpart.Focus()
        End If
    End Sub
    Private Sub cbpart_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            txtqtykontrak.Focus()
        End If
    End Sub
    Private Sub txtqtykontrak_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqtykontrak.KeyPress
        If e.KeyChar = Chr(13) Then
            dtstart.Focus()
        End If
    End Sub
    Private Sub dtexp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtstart.KeyPress
        If e.KeyChar = Chr(13) Then
            dtexp.Focus()
        End If
    End Sub

    Private Sub dgkontrak_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgkontrak.CellDoubleClick
        With dgkontrak.CurrentRow
            txtkontrak.Text = .Cells(0).Value
            txtCustomer.Text = .Cells(1).Value
            dtstart.Text = .Cells(2).Value
            dtexp.Text = .Cells(3).Value
            dtactstart.Text = .Cells(4).Value
            dtactend.Text = .Cells(5).Value
            txtpartcode.Text = .Cells(6).Value
            txtqtykontrak.Text = .Cells(7).Value
            txtfcentry.Text = .Cells(8).Value
            txtfcba.Text = .Cells(9).Value
            txtfieldid.Text = .Cells(10).Value
        End With
    End Sub
    Private Sub DGVDetail_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVDetail.CellDoubleClick
        With DGVDetail.CurrentRow
            txtfieldid_detail.Text = .Cells(0).Value
            txttransporter.Text = .Cells(1).Value
            txtkontrakno_detail.Text = .Cells(2).Value
            txtdo_detail.Text = .Cells(3).Value
            txtdtpker_detail.Text = .Cells(4).Value
            txtqtydo_detail.Text = .Cells(5).Value
            txtstatus.Text = .Cells(6).Value
        End With
    End Sub
    Private Sub dtexp_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtexp.KeyPress
        If e.KeyChar = Chr(13) Then
            dtactstart.Focus()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oradb As String = "Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.10.10.192)(PORT=1521)))(CONNECT_DATA=(SID=iplasprod)(SERVER=DEDICATED)));User Id='iplasprod';Password='BersamaKitaBisa1973'"
        Con2 = New OracleConnection(oradb)
        dgkontrak.Rows.Clear()
        Con2.Open()
        cmd4 = New OracleCommand
        cmd4.Connection = Con2
        cmd4.CommandText = "select * from DELIVERYCONTRACT where FCBA ='" & SiteId_ & "' "
        Dim RD As OracleDataReader
        RD = cmd4.ExecuteReader
        Try
            While RD.Read
                Dim estr As String() = {RD(0).ToString, RD(1).ToString, RD(2).ToString, RD(3).ToString, RD(4).ToString, RD(5).ToString, RD(6).ToString, RD(7).ToString, RD(9).ToString, RD(12).ToString, RD(15).ToString}
                dgkontrak.Rows.Add(estr)
            End While
        Catch ex As Exception
            MsgBox(ex.Message.ToString.ToString, MsgBoxStyle.Exclamation, "Iplas Contract")
        Finally
            RD.Close()
            cmd4.Dispose()
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim oradb2 As String = "Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.10.10.192)(PORT=1521)))(CONNECT_DATA=(SID=iplasprod)(SERVER=DEDICATED)));User Id='iplasprod';Password='BersamaKitaBisa1973'"
        Con3 = New OracleConnection(oradb2)
        DGVDetail.Rows.Clear()
        Con3.Open()
        cmd4 = New OracleCommand
        cmd4.Connection = Con3
        cmd4.CommandText = "select * from iplasprod.deliverycontract_detail where deliverycontract = '" & txtfieldid.Text & "' and Rowstateid ='Approved'"
        cmd4.CommandType = CommandType.Text
        Dim DD As OracleDataReader
        DD = cmd4.ExecuteReader
        Try
            While DD.Read
                Dim dstr As String() = {DD(0).ToString, DD(1).ToString, DD(2).ToString, DD(3).ToString, DD(4).ToString, DD(5).ToString, DD(6).ToString}
                DGVDetail.Rows.Add(dstr)
            End While
        Catch ex As Exception
            MsgBox(ex.Message.ToString.ToString, MsgBoxStyle.Exclamation, "Iplas Detail Contract")
        Finally
            DD.Close()
            cmd4.Dispose()
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        cmd = New odbcCommand("select * from wbs_kontrak_tab where nokontrak='" & txtkontrak.Text & "'", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            Dim sqladd As String
            sqladd = "insert into wbs_kontrak_tab([nokontrak],[csid],[partid],[qtykontrak],[endkontrak],[fcentry],[startkontrak],[actualstart],[actualend],[fieldid]) values('" & txtkontrak.Text & "','" & txtCustomer.Text & "','" & txtpartcode.Text & "','" & txtqtykontrak.Text & "',#" & Date.Parse(dtexp.Text) & "#,'" & txtfcentry.Text & "',#" & Date.Parse(dtstart.Text) & "#,#" & Date.Parse(dtactstart.Text) & "#,#" & Date.Parse(dtactend.Text) & "#,'" & txtfieldid.Text & "')"
            cmd = New odbcCommand(sqladd, Conn)
            cmd.ExecuteNonQuery()
            kosong()
            tampil()
        Else
            MsgBox("Data dengan Nomor Kontrak Ini Sudah Pernah Di import dari Iplas, Cek lagi di list Data Local")
            rd.Close()
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        cmd = New odbcCommand("select * from wbs_kontrakdetail_tab where DeliveryOrder='" & txtdo_detail.Text & "' and ContractCode = '" & txtkontrakno_detail.Text & "'", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            Dim sqladd As String
            sqladd = "insert into wbs_kontrakdetail_tab([FieldId],[Transporter],[ContractCode],[DeliveryOrder],[Datefrom],[Quantity],[Rowstated]) values('" & txtfieldid_detail.Text & "','" & txttransporter.Text & "','" & txtkontrakno_detail.Text & "','" & txtdo_detail.Text & "',#" & Date.Parse(txtdtpker_detail.Text) & "#,'" & txtqtydo_detail.Text & "','" & txtstatus.Text & "')"
            cmd = New odbcCommand(sqladd, Conn)
            cmd.ExecuteNonQuery()
            kosong2()
            tampil2()
        Else
            MsgBox("Data Dengan Nomor DO Ini Sudah Pernah Di import dari Iplas, Cek lagi di list Data Local Detail dan Pastikan DO yang di input Tidak Sama dengan DO yang sudah pernah ada")
            rd.Close()
        End If
    End Sub

    Private Sub DGVLocal_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVLocal.CellContentClick
        tampil()
    End Sub

    Private Sub DGVLocal2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVLocal2.CellContentClick
        tampil2()
    End Sub
    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim sqldelete As String
        sqldelete = "delete from wbs_kontrakdetail_tab where FieldId ='" & DGVLocal2.SelectedRows(0).Cells(0).Value & "' and DeliveryOrder = '" & DGVLocal2.SelectedRows(0).Cells(2).Value & "'"
        cmd = New odbcCommand(sqldelete, Conn)
        cmd.ExecuteNonQuery()
        tampil2()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim sqlcek As String
        sqlcek = "select * from wbs_kontrakdetail_tab where FieldId ='" & DGVLocal.SelectedRows(0).Cells(5).Value & "'"
        cmd = New odbcCommand(sqlcek, Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            MsgBox("Nggak Bisa Dihapus karena didetailnya masih ada data dengan fieldid yang sama, Kalau Mau Hapus Detail Dulu baru header..!!")
        Else
            Dim sqldelete1 As String
            sqldelete1 = "delete from wbs_kontrak_tab where fieldid ='" & DGVLocal.SelectedRows(0).Cells(5).Value & "' and nokontrak = '" & DGVLocal.SelectedRows(0).Cells(0).Value & "'"
            cmd = New odbcCommand(sqldelete1, Conn)
            cmd.ExecuteNonQuery()
            tampil()
        End If
    End Sub

End Class