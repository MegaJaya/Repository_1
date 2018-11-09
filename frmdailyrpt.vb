Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmdailyrpt

    Private Sub frmdailyrpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        typeweight.SelectedIndex = 1
        cbpart.SelectedIndex = -1
        Application.DoEvents()
        Koneksi()
        tampilpart()
        printrpt()

    End Sub
    Sub tampilpart()
        da = New odbcDataAdapter("select * from wbs_part_tab where partcat='DLL' order by partname", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "part")

        cbpart.DataSource = (ds.Tables("part"))
        cbpart.DisplayMember = "partname"
        cbpart.ValueMember = "partid"
    End Sub
    Sub tampilpartcpo()
        da = New odbcDataAdapter("select * from wbs_part_tab where partcat in('CPO','TRN') order by partname", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "part")

        cbpart.DataSource = (ds.Tables("part"))
        cbpart.DisplayMember = "partname"
        cbpart.ValueMember = "partid"
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

        If typeweight.SelectedItem = "Lain-lain" Then
            cryRpt.Load(Application.StartupPath & "\report\dailyreport_dll.rpt")
        ElseIf typeweight.SelectedItem = "Transfer" Then
            If typereport.SelectedItem = "Per Supplier" Then
                cryRpt.Load(Application.StartupPath & "\report\dailyreport_cpo_transfer_supplier.rpt")
            ElseIf typereport.SelectedItem = "Per Transporter" Then
                cryRpt.Load(Application.StartupPath & "\report\SummaryTransPerTransporter.rpt")
            Else
                cryRpt.Load(Application.StartupPath & "\report\dailyreport_cpo_transfer.rpt")

            End If

        End If
        cryRpt.SetDatabaseLogon("Admin", "w@b@s4ms4system2all")
        crdr.Visible = True
        crdr.ShowCloseButton = True

        If typeweight.SelectedItem = "Lain-lain" Then
            crdr.SelectionFormula = "{wbs_data_tab.datein} in date (" & dfrom & ") to date (" & dto & ") and {wbs_data_tab.wbout} <> 0 and {wbs_data_tab.partid} ='" & cbpart.SelectedValue & "'"
        ElseIf typeweight.SelectedItem = "Transfer" Then
            'MsgBox(typereport.SelectedItem)
            If typereport.SelectedItem = "Daily Report" Or typereport.SelectedItem = "Per Supplier" Or typereport.SelectedItem = "Per Transporter" Then
                crdr.SelectionFormula = "{wbs_datacpo_transfer_tab.datein} in date (" & dfrom & ") to date (" & dto & ") and {wbs_datacpo_transfer_tab.wbout} <> 0 and {wbs_datacpo_transfer_tab.partid} ='" & cbpart.SelectedValue & "'"
            ElseIf typereport.SelectedItem = "Kirim" Then
                crdr.SelectionFormula = "{wbs_datacpo_transfer_tab.datein} in date (" & dfrom & ") to date (" & dto & ") and {wbs_datacpo_transfer_tab.wbout} <> 0 and {wbs_datacpo_transfer_tab.partid} ='" & cbpart.SelectedValue & "' and {wbs_datacpo_transfer_tab.vehicle_desc} = 'KIRIM'"
            ElseIf typereport.SelectedItem = "Kirim" Then
                crdr.SelectionFormula = "{wbs_datacpo_transfer_tab.datein} in date (" & dfrom & ") to date (" & dto & ") and {wbs_datacpo_transfer_tab.wbout} <> 0 and {wbs_datacpo_transfer_tab.partid} ='" & cbpart.SelectedValue & "' and {wbs_datacpo_transfer_tab.vehicle_desc} = 'KIRIM'"
            ElseIf typereport.SelectedItem = "Terima" Then
                crdr.SelectionFormula = "{wbs_datacpo_transfer_tab.datein} in date (" & dfrom & ") to date (" & dto & ") and {wbs_datacpo_transfer_tab.wbout} <> 0 and {wbs_datacpo_transfer_tab.partid} ='" & cbpart.SelectedValue & "' and {wbs_datacpo_transfer_tab.vehicle_desc} = 'TERIMA'"
            ElseIf typereport.SelectedItem = "Kirim" Then
                crdr.SelectionFormula = "{wbs_product_receive_tab.datein} in date (" & dfrom & ") to date (" & dto & ") and {wbs_product_receive_tab.wbout} <> 0 and {wbs_product_receive_tab.InventoryPart} ='" & cbpart.SelectedValue & "' and {wbs_product_receive_tab.vehicleno} = 'RECEIVE'"
            ElseIf typereport.SelectedItem = "Terima" Then
                crdr.SelectionFormula = "{wbs_product_transfer_tab.datein} in date (" & dfrom & ") to date (" & dto & ") and {wbs_product_transfer_tab.wbout} <> 0 and {wbs_product_transfer_tab.InventoryPart} ='" & cbpart.SelectedValue & "' and {wbs_product_transfer_tab.vehicleno} = 'TRANSFER'"
            End If
        End If
        crdr.ReportSource = cryRpt
        crdr.Refresh()
    End Sub

    Private Sub btnreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreport.Click
        printrpt()
    End Sub

  
    Private Sub crdr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crdr.Load

    End Sub

    Private Sub typeweight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles typeweight.SelectedIndexChanged

    End Sub

    Private Sub typeweight_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles typeweight.SelectionChangeCommitted
        If typeweight.SelectedItem = "Lain-lain" Then
            tampilpart()
            typereport_text.Visible = False
            typereport.Visible = False
        ElseIf typeweight.SelectedItem = "Transfer" Then
            tampilpartcpo()
            typereport_text.Visible = True
            typereport.Visible = True
        End If

    End Sub

    Private Sub dtto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtto.ValueChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub dtfrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtfrom.ValueChanged

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class