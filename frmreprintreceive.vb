Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmreprintreceive
    Dim wbsid_ As String = ""
    Private Sub frmreprintcpo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Application.DoEvents()
        Koneksi()
        tampil()
    End Sub
    Sub tampil()
        da = New odbcDataAdapter("select * from wbs_product_receive_tab where wbout<>0 and datein >= #" & Date.Parse(dtfrom.Text) & "# and datein <= #" & Date.Parse(dtto.Text) & "#  order by wbsid desc", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "wbsdata")
        dgreprint.DataSource = (ds.Tables("wbsdata"))
        dgreprint.ReadOnly = True

    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        tampil()

    End Sub

    Private Sub btnreprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreprint.Click
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim prn As String
        Dim cell As DataGridViewCell
        Dim wbsidfield As New ParameterField
        Dim rptwbsidparam As New ParameterFields
        Dim wbsidrange As New ParameterDiscreteValue
        'Try


        prn = ""
        For Each cell In dgreprint.SelectedCells
            prn = cell.Value.ToString()
        Next
        'MsgBox(prn)
        Dim a As Integer = 0
        a = CInt(IsiInteger("select cetak from wbs_product_receive_tab where wbsid='" & wbsid_ & "'")) + 1
        rd.Close()
        cmd = New odbcCommand("update wbs_product_receive_tab set [cetak]='" & Convert.ToString(a) & "'  where [wbsid]='" & wbsid_ & "'", Conn)
        cmd.ExecuteNonQuery()
        dgreprint.Refresh()
      

        cryRpt.Load(Application.StartupPath & "\report\PrintWPR - Copy.rpt")
        cryRpt.SetDatabaseLogon("Admin", "w@b@s4ms4system2all")
        cr2.Visible = True
        cr2.ShowCloseButton = True
        cr2.SelectionFormula = "{wbs_product_receive_tab.wbsid}='" & wbsid_ & "'"
        cr2.ReportSource = cryRpt
        cr2.Refresh()
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        If cr2.Visible = False Then
            Me.Close()
        Else
            cr2.Visible = False
        End If
    End Sub


    Private Sub dgreprint_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgreprint.CellContentClick
        wbsid_ = dgreprint.CurrentRow.Cells(0).Value
    End Sub
    'Private Sub cr2_EmployeeTraining_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgreprint.RowPostPaint

    '    If e.RowIndex < Me.dgreprint.RowCount - 1 Then
    '        Dim dgvRow As DataGridViewRow = Me.dgreprint.Rows(e.RowIndex)

    '        '<== This is the header Name
    '        'If CInt(dgvRow.Cells("hirarki").Value) = 0 Then

    '        '<== But this is the name assigned to it in the properties of the control
    '        If dgvRow.Cells("retur").Value.ToString = "P" Then
    '            dgvRow.DefaultCellStyle.BackColor = Color.FromArgb(236, 236, 255)
    '        ElseIf dgvRow.Cells("retur").Value.ToString = "T" Then
    '            dgvRow.DefaultCellStyle.BackColor = Color.LightPink
    '        ElseIf dgvRow.Cells("retur").Value.ToString = "F" Then
    '            dgvRow.DefaultCellStyle.BackColor = Color.Aqua
    '        End If

    '    End If

    'End Sub
   
  
End Class