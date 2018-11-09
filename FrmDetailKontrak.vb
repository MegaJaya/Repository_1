Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MSCommLib
Imports System.IO.Ports
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Public Class FrmDetailKontrak
    Private Sub FrmDetailKontrak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim m, i As Integer
        Dim dsUser As New DataSet
        Dim dtUser As New DataTable
        da = New odbcDataAdapter("select * from wbs_kontrak_tab  order by nokontrak", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(dsUser, "wbs_kontrak_tab")
        dtUser = dsUser.Tables("wbs_kontrak_tab")
        For m = 1 To 10
            For i = 0 To dtUser.Rows.Count - 1
                cbkontrak.Items.Add(dtUser.Rows(m).Item(i))
            Next
        Next
    End Sub
End Class