Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmdailyrptcpot

    Private Sub frmdailyrptcpot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Application.DoEvents()
        cbpart.SelectedIndex = 0
        Koneksi()
        printrpt()
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

        cryRpt.Load(Application.StartupPath & "\report\dailyreport_CPOT_transfer.rpt")
        cryRpt.SetDatabaseLogon("Admin", "w@b@s4ms4system2all")
        crdr.Visible = True
        crdr.ShowCloseButton = True
        crdr.SelectionFormula = "{wbs_product_transfer_tab.dateout} in date (" & dfrom & ") to date (" & dto & ") and {wbs_product_transfer_tab.wbout} <> 0 and {wbs_product_transfer_tab.InventoryPart}='" & cbpart.SelectedItem & "'"
        crdr.ReportSource = cryRpt
        crdr.Refresh()
    End Sub

    Private Sub btnreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreport.Click
        printrpt()

    End Sub

    
End Class