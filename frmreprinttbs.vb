Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmreprinttbs

    Private Sub frmreprinttbs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Application.DoEvents()
        Koneksi()
        tampil()
    End Sub
    Sub tampil()


        da = New odbcDataAdapter("select * from wbs_datatbs_tab where wbout<>0 and datein >= #" & Date.Parse(dtfrom.Text) & "# and datein <= #" & Date.Parse(dtto.Text) & "#  order by wbsid desc", Conn)
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
        Dim csfield As New ParameterField
        Dim csrange As New ParameterDiscreteValue
        Dim csname As String
        Dim rptcsparam As New ParameterFields

        Try


            prn = ""
            For Each cell In dgreprint.SelectedCells
                prn = cell.Value.ToString()
            Next

            Dim a As Integer = 0
            cmd = New odbcCommand("select * from wbs_datatbs_tab where wbsid='" & prn & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then

                a = CInt(rd.GetValue(35)) + 1
            End If
            rd.Close()
            cmd = New odbcCommand("update wbs_datatbs_tab set [cetak]='" & Convert.ToString(a) & "'  where [wbsid]='" & prn & "'", Conn)
            cmd.ExecuteNonQuery()
            dgreprint.Refresh()

            csname = getCs(prn)

            csfield.ParameterFieldName = "csgroup"
            csrange.Value = csname.ToString
            csfield.CurrentValues.Add(csrange)
            rptcsparam.Add(csfield)
            cr2.ParameterFieldInfo = rptcsparam
            cryRpt.Load(Application.StartupPath & "\report\reprint_tbs.rpt")
            cryRpt.SetDatabaseLogon("Admin", "w@b@s4ms4system2all")
            cr2.Visible = True
            cr2.ShowCloseButton = True
            cr2.SelectionFormula = "{wbs_datatbs_tab.wbsid}='" & prn & "'"
            cr2.ReportSource = cryRpt
            cr2.Refresh()
        Catch ex As Exception

        End Try
    End Sub
    Private Function getCs(ByVal prn2 As String) As String
        Dim csg As String = ""

        cmd = New odbcCommand("select b.internal from wbs_datatbs_tab a ,wbs_cs_tab b where wbsid='" & prn2 & "' and a.customer=b.csid", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then

            If rd.GetString(0) = "F" Then
                csg = "PT.Kalbar Alam Sentosa /"
            End If
        End If


        Return csg
    End Function

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        cr2.Visible = False
    End Sub

    Private Sub cr2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cr2.Load

    End Sub
End Class