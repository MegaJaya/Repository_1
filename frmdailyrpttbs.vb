Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmdailyrpttbs
        
    Private Sub frmdailyrpttbs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Application.DoEvents()
        Koneksi()
        tampilcs()
        printrpt()
    End Sub
    Sub tampilcs()
        da = New odbcDataAdapter("select * from wbs_cs_tab order by csname", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "cs")

        cbcs.DataSource = (ds.Tables("cs"))
        cbcs.DisplayMember = "csname"
        cbcs.ValueMember = "csid"
    End Sub

    Sub printrpt()
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim dfrom As String
        Dim dto As String
        Dim dtfromfield As New ParameterField
        Dim dtfromrange As New ParameterDiscreteValue
        Dim dttofield As New ParameterField
        Dim dttorange As New ParameterDiscreteValue
        Dim rptcpoparam As New ParameterFields
        Dim cust As String = ""
        Dim rmk As String = ""
        Dim afd As String = ""

        If cbcs.Text = "" Then
            cust = ""
        Else
            cust = cbcs.SelectedValue.ToString
        End If
        If cbdiv.Text = "" Then
            afd = ""

        ElseIf cbdiv.Text = "ALL" Then
            afd = ""
        Else
            afd = cbdiv.SelectedValue.ToString
        End If

        rmk = txtremark.Text


        dfrom = dtfrom.Value.ToString("yyyy,MM,dd")
        dto = dtto.Value.ToString("yyyy,MM,dd")



        dtfromfield.ParameterFieldName = "dtfrom"
        dtfromrange.Value = dtfrom.Value.ToString("yyyy-MM-dd")
        dtfromfield.CurrentValues.Add(dtfromrange)
        rptcpoparam.Add(dtfromfield)

        dttofield.ParameterFieldName = "dtto"
        dttorange.Value = dtto.Value.ToString("yyyy-MM-dd")
        dttofield.CurrentValues.Add(dttorange)
        rptcpoparam.Add(dttofield)
        crdr.ParameterFieldInfo = rptcpoparam



        dfrom = dtfrom.Value.ToString("yyyy,MM,dd")
        dto = dtto.Value.ToString("yyyy,MM,dd")


        cryRpt.Load(Application.StartupPath & "\report\dailyreport_tbs.rpt")
        cryRpt.SetDatabaseLogon("Admin", "w@b@s4ms4system2all")
        crdr.Visible = True
        crdr.ShowCloseButton = True
        'crdr.SelectionFormula = "{wbs_datatbs_tab.datein} in date (" & dfrom & ") to date (" & dto & ") and {wbs_datatbs_tab.wbout} <> 0"
        crdr.SelectionFormula = "{wbs_datatbs_tab.datein} in date (" & dfrom & ") to date (" & dto & ") and {wbs_datatbs_tab.wbout} <> 0 and {wbs_datatbs_tab.customer} like ('*" & cust & "*') and {wbs_datatbs_tab.remark} like ('*" & rmk & "*') and {wbs_datatbs_tab.divisi} like ('*" & afd & "*')"
        crdr.ReportSource = cryRpt
        crdr.Refresh()
    End Sub

    Private Sub btnreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreport.Click
        printrpt()
    End Sub

    Private Sub cbcs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcs.SelectedIndexChanged

    End Sub

    Private Sub cbcs_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbcs.SelectionChangeCommitted
        tampildivisi()
    End Sub

    Sub tampildivisi()
        Dim estate_ As String = ""
        estate_ = IsiString("select estate from wbs_datatbs_tab where customer='" & cbcs.SelectedValue & "'")

        da = New odbcDataAdapter("select * from wbs_div_tab where estateid='ALL' union select * from wbs_div_tab where estateid='" & estate_ & "' order by divname", Conn)
        'MsgBox("select * from wbs_div_tab where estateid='" & cbcs.SelectedValue & "'")
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "div")

        cbdiv.DataSource = (ds.Tables("div"))
        cbdiv.DisplayMember = "divname"
        cbdiv.ValueMember = "divid"
    End Sub
End Class