Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmreprint

    Private Sub frmreprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Application.DoEvents()
        Koneksi()
        tampil()


    End Sub
    Sub tampil()
   

        da = New odbcDataAdapter("select * from wbs_data_tab where wbout<>0 and datein >= #" & Date.Parse(dtfrom.Text) & "# and datein <= #" & Date.Parse(dtto.Text) & "#  order by wbsid desc", Conn)
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
        Try

            prn = ""
            For Each cell In dgreprint.SelectedCells
                prn = cell.Value.ToString()
            Next
            Dim a As Integer = 0
            cmd = New odbcCommand("select * from wbs_data_tab where wbsid='" & prn & "'", Conn)

            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                a = CInt(rd.GetValue(22)) + 1
            End If
            rd.Close()
            cmd = New odbcCommand("update wbs_data_tab set [cetak]='" & Convert.ToString(a) & "'  where [wbsid]='" & prn & "'", Conn)
            cmd.ExecuteNonQuery()
            dgreprint.Refresh()
            cryRpt.Load(Application.StartupPath & "\report\reprint_dll.rpt")
            cryRpt.SetDatabaseLogon("Admin", "w@b@s4ms4system2all")
            cr2.Visible = True
            cr2.ShowCloseButton = True
            cr2.SelectionFormula = "{wbs_data_tab.wbsid}='" & prn & "'"
            cr2.ReportSource = cryRpt
            cr2.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        cr2.Visible = False
    End Sub

    Private Sub cr2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cr2.Load

    End Sub
End Class