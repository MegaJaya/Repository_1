Imports System.Data.Odbc
Public Class frmmill
    Private Sub frmmillLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        Me.Show()
        Application.DoEvents()
        tampilest()
        Kosong()
        tampildiv()
        tampil()
        KodeOtomatis()

    End Sub
    Sub KodeOtomatis()
        cmd = New odbcCommand("select ID from wbs_storage_origin_tab order by ID desc", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then

            txtid.Text = "ID"
        Else
            txtid.Text = "" + Format(Microsoft.VisualBasic.Right(rd.Item("ID"), 2) + 1, "0")

        End If
    End Sub
    Sub tampilest()
        da = New odbcDataAdapter("select distinct siteid from wbs_storage_origin_tab", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "est")

        cbsite.DataSource = (ds.Tables("est"))
        cbsite.DisplayMember = "siteid"
        cbsite.ValueMember = "siteid"

        Call KodeOtomatis()

    End Sub
    Sub tampildiv()
        da = New odbcDataAdapter("select distinct product_productcode from wbs_storage_origin_tab order by product_productcode asc", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "div")

        cbproduct.DataSource = (ds.Tables("div"))
        cbproduct.DisplayMember = "product_productcode"
        cbproduct.ValueMember = "product_productcode"

        Call KodeOtomatis()

    End Sub
    Sub kosong()
        cmd = New odbcCommand("select * from wbs_storage_origin_tab order by id", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If Not rd.HasRows = True Then
            txtid.Text = ""
        Else
            txtid.Text = rd.GetValue(0)

        End If

        rd.Close()
        txtstorage.Text = ""
        txtdesc.Text = ""
        txtid.Focus()
        cbsite.Text = ""
        cbproduct.Text = ""

        Call KodeOtomatis()



    End Sub
    Sub tampil()
        da = New odbcDataAdapter(" select id, storagecode as StorageCode, Description, siteid as Site, product_productcode as Product from wbs_storage_origin_tab order by id asc", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "block")
        dgblock.DataSource = (ds.Tables("block"))
        dgblock.ReadOnly = True
    End Sub
    Sub baru()
        txtstorage.Focus()
        txtstorage.Text = ""
        txtdesc.Text = ""
        cbsite.Text = ""
        cbproduct.Text = ""

        Call KodeOtomatis()

    End Sub
    Sub Simpan()
        If txtid.Text = "" Or txtstorage.Text = "" Or txtdesc.Text = "" Or cbsite.Text = "" Or cbproduct.Text = "" Then
            MsgBox("Harap Isi Data Yang Masih Kosong !!!")
            Exit Sub

        Else
            'Dim siteid As String
            Dim sql123 As String
            'siteid = getSite()
            sql123 = "select * from wbs_storage_origin_tab where id =" & CInt(txtid.Text) & " "
            cmd = New odbcCommand(sql123, Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                MsgBox("Data Berhasil Ditambahkan....")
                Dim sqladd As String
                sqladd = "insert into wbs_storage_origin_tab([ID],[storagecode],[Description],[siteid],[product_productcode]) values('" & txtid.Text & "','" & txtstorage.Text & "','" & txtdesc.Text & "','" & cbsite.SelectedValue & "','" & cbproduct.SelectedValue & "')"
                cmd = New odbcCommand(sqladd, Conn)
                cmd.ExecuteNonQuery()

            Else
                If MessageBox.Show("Data Telah Terupdate....", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    Dim sqledit As String
                    sqledit = "update wbs_storage_origin_tab set storagecode='" & txtstorage.Text & "',Description='" & txtdesc.Text & "', siteid='" & cbsite.SelectedValue & "',product_productcode='" & cbproduct.SelectedValue & "' where id=" & txtid.Text & ""
                    cmd = New odbcCommand(sqledit, Conn)
                    cmd.ExecuteNonQuery()

                End If
            End If
            kosong()
            tampil()
            rd.Close()
            'setFlag("tblblock")
        End If
    End Sub
    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        kosong()
        tampil()
        'Call KodeOtomatis()


    End Sub
    Private Sub cbsite_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbsite.KeyPress
        If e.KeyChar = Chr(13) Then
            cbproduct.Focus()
            'Call KodeOtomatis()

        End If
    End Sub
    Private Sub cbsite_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbsite.SelectionChangeCommitted
        tampildiv()
        tampil()

        'Call KodeOtomatis()

    End Sub
    'Private Sub dgv_EmployeeTraining_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)

    '    If e.RowIndex < Me.dgblock.RowCount - 1 Then
    '        Dim dgvRow As DataGridViewRow = Me.dgblock.Rows(e.RowIndex)

    '        If dgvRow.Cells("tahun_tanam").Value.ToString = "" Then
    '            dgvRow.DefaultCellStyle.BackColor = Color.Red
    '        End If

    '    End If

    'End Sub

    Private Sub btncancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Call Kosong()
        Call KodeOtomatis()


    End Sub
    Private Sub btndelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If txtid.Text = "" Then
            MsgBox("Fill operator ID field first !!!")
            Exit Sub

        Else
            If MessageBox.Show("Are you sure to delete the data ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String = "delete from wbs_storage_origin_tab where id =" & CInt(txtid.Text) & ""
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

            cmd = New odbcCommand("select * from wbs_storage_origin_tab where id =" & CInt(txtid.Text) & " and Product='" & cbproduct.SelectedValue & "' and Site='" & cbsite.SelectedValue & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                txtstorage.Text = rd.GetString(1)
                txtdesc.Text = rd.GetString(2)
                cbproduct.SelectedValue = rd.GetString(5)
                cbsite.SelectedValue = rd.GetString(6)
                txtstorage.Focus()

            Else
                baru()

            End If
            rd.Close()

            Call KodeOtomatis()

        End If
    End Sub
    Private Sub cbproduct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbproduct.KeyPress
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
        'Call KodeOtomatis()

    End Sub
    Private Sub dgblock_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgblock.CellContentClick
        txtid.Text = dgblock.CurrentRow.Cells(0).Value
        txtstorage.Text = dgblock.CurrentRow.Cells(1).Value
        txtdesc.Text = dgblock.CurrentRow.Cells(2).Value
        cbsite.Text = dgblock.CurrentRow.Cells(3).Value
        cbproduct.Text = dgblock.CurrentRow.Cells(4).Value

    End Sub
    Private Sub txtdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdesc.KeyPress
        If e.KeyChar = Chr(13) Then
            btnsave.Focus()

        End If
    End Sub
    Private Sub txtstorage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstorage.KeyPress
        If e.KeyChar = Chr(13) Then
            cbsite.Focus()

        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub
End Class