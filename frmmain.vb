Imports System.Data.Odbc

Public Class frmmain
    'Function open_form_val(ByVal frm As String)
    '    Dim objForm As Form
    '    Dim objFormAll As Form
    '    Dim FullTypeName As String
    '    Dim FormInstanceType As Type
    '    Dim frmCollection As New FormCollection()

    '    FullTypeName = Application.ProductName & "." & frm
    '    FormInstanceType = Type.GetType(FullTypeName)
    '    objForm = CType(Activator.CreateInstance(FormInstanceType), Form)

    '    For Each objFormAll In Me.MdiChildren
    '        If objFormAll.Name = objForm.Name Then
    '            objForm.Focus()
    '            MsgBox("Form ini Sudah dibuka ")
    '            Return
    '        End If
    '    Next
    '    With objForm
    '        .MdiParent = Me
    '        .Show()
    '    End With

    'End Function
    Private Sub ShowForm(ByVal fForm As Form)
        Dim objForms As Form
        For Each objForms In Me.MdiChildren
            If objForms.Name = fForm.Name Then
                objForms.Focus()
                MsgBox("Form ini Sudah dibuka ")
                Return
            End If
        Next
        With fForm
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub mnuname_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer1.Enabled = False
        timerup.Enabled = False
        End
    End Sub

    Private Sub Msite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Msite.Click
        Try
            ShowForm(frmsite)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Mtransporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mtransporter.Click
        Try
            ShowForm(frmTransporter)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mnuuser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuuser.Click
        Try
            ShowForm(frmuser)
        Catch ex As Exception
            'MsgBox("error")

        End Try
    End Sub

    Private Sub SupplierCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierCustomerToolStripMenuItem.Click
        Try
            ShowForm(frmcs)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub Suplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Suplier.Click
        Try
            ShowForm(frmsup)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub WBPartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WBPartToolStripMenuItem.Click
        Try
            ShowForm(frmpart)
        Catch ex As Exception
            'MsgBox("error")

        End Try
    End Sub
    Public Function GetParentname(ByVal id_parent As Integer) As String
        Dim Msql As String = ""
        Dim cmd2
        Dim rdo As OdbcDataReader
        Dim result As String = "Parent"
        'MsgBox(id_parent)
        If id_parent <> 0 Then
            Msql = "SELECT * from module where ID=" & id_parent
            cmd2 = New OdbcCommand(Msql, Conn)
            rdo = cmd2.ExecuteReader
            rdo.Read()
            If rdo.HasRows Then
                result = rdo.GetString(1)
            Else
                result = "Parent"
            End If
            rdo.Close()
        End If
        Return result
    End Function
    Public Function GetParentid(ByVal id_parent As Integer) As String
        Dim Msql As String = ""
        Dim cmd2
        Dim rdo As OdbcDataReader
        Dim result As Integer = 0
        'MsgBox(id_parent)
        If id_parent <> 0 Then
            Msql = "SELECT * from module where ID=" & id_parent
            cmd2 = New OdbcCommand(Msql, Conn)
            rdo = cmd2.ExecuteReader
            rdo.Read()
            If rdo.HasRows Then
                result = rdo.GetValue(3)
            Else
                result = 0
            End If
            rdo.Close()
        End If
        Return result
    End Function

    Private Sub frmmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmlogin.txtPassPhrase.Text = "1" Then
            RegisterToolStripMenuItem.Visible = False
        Else
            mnurootmaster.Visible = False
            WeighBridgeToolStripMenuItem.Visible = False
            ReportToolStripMenuItem.Visible = False
            mnuroottools.Visible = False

            TBSOneWayToolStripMenuItem.ShortcutKeys = Keys.None
            TBSTwoWayToolStripMenuItem.ShortcutKeys = Keys.None
            TBSMultiAfdToolStripMenuItem.ShortcutKeys = Keys.None
            CPOToolStripMenuItem.ShortcutKeys = Keys.None
            ContractWeightingOldToolStripMenuItem.ShortcutKeys = Keys.None
            TransferCPO.ShortcutKeys = Keys.None
            WBLainLainToolStripMenuItem.ShortcutKeys = Keys.None
        End If
        Me.Show()
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Koneksi()
        'db_control()
        Try
            Koneksi_upload()
        Catch ex As Exception
            MsgBox("Please check your server setting !!!")
        End Try

        cmd2 = New OdbcCommand("SELECT * from view_menu_roles where id_roles='" & frmlogin.txtm.Text & "'", Conn)
        rd = cmd2.ExecuteReader

        Do While rd.Read
            If rd.HasRows Then

                'Me.mnuutama.Items(1).Visible
                Dim menustrip As String = rd.GetString(1)
                Dim menusparent As String = GetParentname(rd.GetValue(3))

                Dim menushirarki As Integer = rd.GetValue(6)

                If menusparent = "Parent" Then
                    For Each cntrl As ToolStripMenuItem In Me.mnuutama.Items
                        If cntrl.Name = menustrip Then
                            cntrl.Visible = True
                            'cntrl.DropDownItems
                            Exit For
                        End If
                    Next

                Else

                    If menushirarki = 1 Then
                        For Each cntrl As ToolStripMenuItem In Me.mnuutama.Items
                            If cntrl.Name = menusparent Then
                                For Each subcntrl As ToolStripMenuItem In cntrl.DropDownItems
                                    If subcntrl.Name = menustrip Then
                                        subcntrl.Visible = True
                                        Exit For
                                    End If
                                Next
                                Exit For
                            End If
                        Next
                    ElseIf menushirarki = 2 Then
                        Dim menuSubsparent As Integer = GetParentid(rd.GetValue(3))
                        For Each cntrl As ToolStripMenuItem In Me.mnuutama.Items
                            'MsgBox(cntrl.Name & "," & GetParentname(menuSubsparent))
                            If cntrl.Name = GetParentname(menuSubsparent) Then
                                For Each subcntrl As ToolStripMenuItem In cntrl.DropDownItems
                                    If subcntrl.Name = menusparent Then

                                        For Each subSONcntrl As ToolStripMenuItem In subcntrl.DropDownItems
                                            If subSONcntrl.Name = menustrip Then
                                                subSONcntrl.Visible = True
                                                Exit For
                                            End If
                                        Next
                                        Exit For

                                    End If

                                Next
                                Exit For
                            End If
                        Next
                    End If
                End If
            End If
        Loop
        rd.Close()
        'MsgBox(frmlogin.txtm.Text)

        'If frmlogin.txtm.Text = "T" Then
        '    MsgBox("Anda login dengan otorisasi manager")
        '    Me.Show()
        'Else
        '    mnurootmaster.Visible = False
        '    mnuroottools.Visible = False
        '    mnusubreprint.Visible = False

        'End If

        uploaddata()
        'Timer1.Interval = 1000
        'Timer1.Enabled = True
        status3.Text = Date.Today
        Me.Cursor = Cursors.Default
        UserNameToolStripMenuItem.Text = "User Name : " & frmlogin.txtusername.Text
        tbs_jml.Text = update_status_timbang("datatbs")

        If TBSOneWayToolStripMenuItem.Visible = False Then
            TBSOneWayToolStripMenuItem.ShortcutKeys = Keys.None
        End If

        If TBSTwoWayToolStripMenuItem.Visible = False Then
            TBSTwoWayToolStripMenuItem.ShortcutKeys = Keys.None
        End If

        If TBSMultiAfdToolStripMenuItem.Visible = False Then
            TBSMultiAfdToolStripMenuItem.ShortcutKeys = Keys.None
        End If
        If CPOToolStripMenuItem.Visible = False Then
            CPOToolStripMenuItem.ShortcutKeys = Keys.None
        End If
        If ContractWeightingOldToolStripMenuItem.Visible = False Then
            ContractWeightingOldToolStripMenuItem.ShortcutKeys = Keys.None
        End If
        If TransferCPO.Visible = False Then
            TransferCPO.ShortcutKeys = Keys.None
        End If
        If WBLainLainToolStripMenuItem.Visible = False Then
            WBLainLainToolStripMenuItem.ShortcutKeys = Keys.None
        End If

        'Ceck Connaction Server
        Dim ping_result As String = ping(Serveraddress)
        Dim status As String = ""
        status = connactionflag.Text

        If ping_result <> "ERROR" Then
            If status <> "Connected" Then
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                NotifyIcon1.BalloonTipTitle = "WBS Connection"
                NotifyIcon1.BalloonTipText = "Connection is Ready"
                connactionflag.Text = "Connected"
                connactionflag.ForeColor = Color.Green
            End If
        Else
            If status <> "Not Connected" Then
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                NotifyIcon1.BalloonTipTitle = "WBS Connection"
                NotifyIcon1.BalloonTipText = "Not Ready, Please Check Your Connection"
                connactionflag.Text = "Not Connected"
                connactionflag.ForeColor = Color.Red
            End If
        End If


    End Sub

    Sub uploaddata()
        cmd = New OdbcCommand("select * from wbs_upload_tab where status='T'", Conn)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            timerup.Interval = CDbl(60000 * CDbl(rd.GetValue(1)))
            timerup.Enabled = True
        End If
        rd.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        status1.Text = TimeOfDay
    End Sub


    Private Sub SiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ShowForm(frmsite)
        Catch ex As Exception
            'MsgBox("error")
        End Try


    End Sub

    Private Sub UploadScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadScheduleToolStripMenuItem.Click
        Try

            ShowForm(frmupload)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub



    Private Sub SerialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SerialToolStripMenuItem.Click
        Try

            ShowForm(frmserial)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub DBMainServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBMainServerToolStripMenuItem.Click
        Try
            ShowForm(frmdbserver)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub WBBlockAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WBBlockAreaToolStripMenuItem.Click

        Try
            ShowForm(frmblock)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub


    Private Sub timerup_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerup.Tick
        Dim ping_result As String = ping(Serveraddress)
        Dim status As String = ""
        status = connactionflag.Text
        If ping_result <> "ERROR" Then
            If status <> "Connected" Then
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                NotifyIcon1.BalloonTipTitle = "WBS Connection"
                NotifyIcon1.BalloonTipText = "Connection is Ready"
                connactionflag.Text = "Connected"
                connactionflag.ForeColor = Color.Green
            End If
            Try

                cmd = New OdbcCommand("select * from wbs_flag_tab", Conn)
                rd = cmd.ExecuteReader

                Do While rd.Read
                    If rd.HasRows Then
                        If "tblblock" = rd.GetString(0) And "T" = rd.GetString(1) Then
                            'tblblock()
                        ElseIf "tblcs" = rd.GetString(0) And "T" = rd.GetString(1) Then
                            tblcs()
                        ElseIf "tblpart" = rd.GetString(0) And "T" = rd.GetString(1) Then
                            'tblpart()
                        ElseIf "tblsite" = rd.GetString(0) And "T" = rd.GetString(1) Then
                            'tblsite()
                        ElseIf "tblsup" = rd.GetString(0) And "T" = rd.GetString(1) Then
                            tblsup()
                        End If

                    End If

                Loop
                'ToolStripProgressBar1.Increment(1)
                rd.Close()
                productreceive()
                producttransfer()
                tbldatatbs()
                tbldatatbsmulti()
                tbldatacpo()
                tbldatacpoTransfer()
                tbldata()
                'timerup.Interval = 1000
            Catch ex As Exception
                'MsgBox("Please check your connection !!!")
                MsgBox(ex.Message)
                'Finally
                '    If Conn2.State = ConnectionState.Open Then
                '        Conn2.Close()
                '    End If
            End Try
        Else
            If status <> "Not Connected" Then
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Warning
                NotifyIcon1.BalloonTipTitle = "WBS Connection"
                NotifyIcon1.BalloonTipText = "Not Ready, Please Check Your Connection"
                connactionflag.Text = "Not Connected"
                connactionflag.ForeColor = Color.Red
            End If
        End If
    End Sub

    Sub tblblock()
        Dim st As String = ""
        Dim blockid As String = ""
        st = getSite()

        'MsgBox("tblblock")
        'cmd2 = New odbcCommand("delete from wbs_block_tab where siteid='" & st & "'", Conn2)
        'cmd2.ExecuteNonQuery()

        cmd = New OdbcCommand("select * from wbs_block_tab where flag='T' order by blockid", Conn)
        rd = cmd.ExecuteReader
        Do While rd.Read
            If rd.HasRows Then
                blockid = rd.GetString(0).ToString
                cmd2 = New OdbcCommand("insert into wbs_block_tab(blockid,blockname,blockdesc,siteid,divid,estateid) values('" & rd.GetString(0) & "','" & rd.GetString(1) & "','" & rd.GetString(2) & "','" & rd.GetString(3) & "','" & rd.GetString(5) & "','" & rd.GetString(6) & "')", Conn2)
                cmd2.ExecuteNonQuery()
            End If
            cmd2 = New OdbcCommand("update wbs_flag_tab set status='F' where flagid='tblblock'", Conn)
            cmd2.ExecuteNonQuery()
        Loop
        cmd2 = New OdbcCommand("update wbs_block_tab set flag='F' where blockid='" & blockid & "'", Conn)
        cmd2.ExecuteNonQuery()
    End Sub

    Sub tblcs()
        Dim st As String = ""
        Dim csid As String = ""
        Dim vers As String = ""
        Dim rd2
        st = getSite()

        'MsgBox(st)
        'cmd2 = New odbcCommand("delete from wbs_cs_tab where siteid='" & st & "'", Conn2)
        'cmd2.ExecuteNonQuery()

        cmd = New OdbcCommand("select csid,csname,csaddress,siteid,version from wbs_cs_tab where flag='T' order by csid", Conn)
        rd = cmd.ExecuteReader
        Do While rd.Read
            If rd.HasRows Then
                csid = rd.GetString(0).ToString
                If rd.IsDBNull(4) Then
                    vers = "1"
                Else
                    vers = rd.GetValue(4).ToString
                End If

                If vers = 1 Then
                    cmd2 = New OdbcCommand("select * from wbs_cs_tab where csid='" & rd.GetString(0) & "' and siteid ='" & rd.GetString(3) & "'", Conn2)
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        If rd2.HasRows Then
                            '---NO EXEC---
                        Else
                            cmd2 = New OdbcCommand("insert into wbs_cs_tab(csid,csname,csaddress,siteid,version) values('" & rd.GetString(0) & "','" & rd.GetString(1) & "','" & rd.GetString(2) & "','" & rd.GetString(3) & "','" & vers & "')", Conn2)
                            cmd2.ExecuteNonQuery()
                        End If
                    Loop
                Else
                    cmd2 = New OdbcCommand("update wbs_cs_tab set csname='" & rd.GetString(1) & "',version = '" & vers & "' where csid = '" & rd.GetString(0) & "' and version > " & CInt(vers) & " and siteid = '" & rd.GetString(3) & "'", Conn2)
                    cmd2.ExecuteNonQuery()
                End If
                cmd2 = New OdbcCommand("update wbs_cs_tab set flag='F',version='" & vers & "' where csid='" & csid & "'", Conn)
                cmd2.ExecuteNonQuery()
            End If
        Loop
        cmd2 = New OdbcCommand("update wbs_flag_tab set status='F' where flagid='tblcs'", Conn)
        cmd2.ExecuteNonQuery()
    End Sub

    Sub tblsup()
        Dim st As String = ""
        Dim supid As String = ""
        Dim vers As String = ""
        Dim rd2
        st = getSite()

        'MsgBox(st)
        'cmd2 = New odbcCommand("delete from wbs_sup_tab where siteid='" & st & "'", Conn2)
        'cmd2.ExecuteNonQuery()

        cmd = New OdbcCommand("select supid,supname,supaddress,siteid,FcCode,flag,version from wbs_supplier_tab where flag = 'T' order by supid", Conn)
        rd = cmd.ExecuteReader
        Do While rd.Read
            If rd.HasRows Then
                supid = rd.GetString(0).ToString
                'vers = rd.GetValue(6).ToString
                If rd.IsDBNull(6) Then
                    vers = "1"
                Else
                    vers = rd.GetValue(6).ToString
                End If
                If vers = 1 Then
                    cmd2 = New OdbcCommand("select * from wbs_sup_tab where supid='" & rd.GetString(0) & "' and siteid ='" & rd.GetString(3) & "'", Conn2)
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        If rd2.HasRows Then
                            '---NO EXEC---
                        Else
                            cmd2 = New OdbcCommand("insert into wbs_sup_tab(supid,supname,supaddress,siteid,version) values('" & rd.GetString(0) & "','" & rd.GetString(1) & "','" & rd.GetString(2) & "','" & rd.GetString(3) & "','" & vers & "')", Conn2)
                            cmd2.ExecuteNonQuery()
                        End If
                    Loop
                Else
                    cmd2 = New OdbcCommand("update wbs_sup_tab set supname='" & rd.GetString(1) & "',supaddress='" & rd.GetString(2) & "',version = '" & vers & "' where supid = '" & rd.GetString(0) & "' and siteid = '" & rd.GetString(3) & "' and version > '" & vers & "'", Conn2)
                    cmd2.ExecuteNonQuery()
                End If
                cmd2 = New OdbcCommand("update wbs_supplier_tab set flag='F',version='" & vers & "' where supid='" & supid & "'", Conn)
                cmd2.ExecuteNonQuery()
            End If
        Loop
        cmd = New OdbcCommand("update wbs_flag_tab set status='F' where flagid='tblsup'", Conn)
        cmd.ExecuteNonQuery()
    End Sub

    Sub tblpart()
        Dim st As String = ""
        Dim partid As String = ""
        Dim vers As String = ""
        st = getSite()

        'MsgBox("tblpart")
        'cmd2 = New odbcCommand("delete from wbs_part_tab where siteid='" & st & "'", Conn2)
        'cmd2.ExecuteNonQuery()


        cmd = New OdbcCommand("select * from wbs_part_tab where flag='T' order by partid", Conn)
        rd = cmd.ExecuteReader
        Do While rd.Read
            If rd.HasRows Then
                partid = rd.GetString(0).ToString
                vers = rd.GetValue(7).ToString
                If vers = 1 Then
                    cmd2 = New OdbcCommand("insert into wbs_part_tab(partid,partname,partdesc,partcat,siteid) values('" & rd.GetString(0) & "','" & rd.GetString(1) & "','" & rd.GetString(2) & "','" & rd.GetString(3) & "','" & rd.GetString(4) & "')", Conn2)
                    cmd2.ExecuteNonQuery()
                Else
                    cmd2 = New OdbcCommand("update wbs_part_tab set partname='" & rd.GetString(1) & "',partdesc='" & rd.GetString(2) & "',partcat='" & rd.GetString(3) & "',version = '" & vers & "' where partid = '" & rd.GetString(0) & "' and siteid = '" & rd.GetString(3) & "'", Conn2)
                    cmd2.ExecuteNonQuery()
                End If
                cmd2 = New OdbcCommand("update wbs_part_tab set flag='F' where partid='" & partid & "'", Conn)
                cmd2.ExecuteNonQuery()
            End If
        Loop
        cmd2 = New OdbcCommand("update wbs_flag_tab set status='F' where flagid='tblpart'", Conn)
        cmd2.ExecuteNonQuery()

    End Sub

    Sub tblsite()
        Dim st As String = ""
        st = getSite()

        'MsgBox("tblsite")
        'cmd2 = New odbcCommand("delete from wbs_site_tab where siteid='" & st & "'", Conn2)
        'cmd2.ExecuteNonQuery()

        cmd = New OdbcCommand("select * from wbs_site_tab ", Conn)
        rd = cmd.ExecuteReader
        Do While rd.Read
            If rd.HasRows Then
                cmd2 = New OdbcCommand("insert into wbs_site_tab(siteid,sitename,siteaddress) values('" & rd.GetString(0) & "','" & rd.GetString(1) & "','" & rd.GetString(2) & "')", Conn2)
                cmd2.ExecuteNonQuery()

            End If
        Loop

        cmd = New OdbcCommand("update wbs_flag_tab set status='F' where flagid='tblsite'", Conn)
        cmd.ExecuteNonQuery()
    End Sub

    Sub tbldata()
        'MsgBox("tbldata")
        Dim sqlinsert As String = ""
        Dim wbsid As String
        Dim blockid As String
        Dim driver As String = ""
        Dim partid As String = ""
        Dim refno As String = ""
        Dim selection As String = ""
        Dim wbin, wbout, netto As Integer
        Dim wb_client_1 As String = ""
        Dim wb_client_2 As String = ""
        Dim vehiclenum, supid, timein, timeout, operator_, siteid, flag, transport, divisi, estateid, ktu, remark, cetak As String
        Dim Vehicle_stnk_expdate_ As String = ""
        Dim vehicle_desc_ As String = ""
        Dim vehicle_tarra_ As Double = 0
        Dim tarra_validation_ As String = ""
        Dim vehicle_tarra_expdate_ As String = ""
        Dim cust_vehicle_validation_ As String = ""
        Dim ProgressBar As Integer = 0
        Dim rd2
        Dim jml As Integer = 0
        cmd2 = New OdbcCommand("select wbsid from wbs_data_tab where flag='T' and wbout<>0 ", Conn)
        rd2 = cmd2.ExecuteReader
        Do While rd2.Read
            If rd2.HasRows Then
                jml = jml + 1
            End If
        Loop
        If jml > 50 Then
            jml = 50
        End If
        If jml > 0 Then

            selection = "wbsid,vehiclenum,driver,partid,blockid,refno,supid,wbin,wbout,netto"
            selection = selection + ",datein,dateout,timein,timeout,operator,siteid,flag,transport,divisi,estateid,ktu,remark,cetak"
            selection = selection + " ,vehicle_stnk_expdate"
            selection = selection + ",vehicle_desc"
            selection = selection + ",vehicle_tarra"
            selection = selection + ",tarra_validation"
            selection = selection + ",vehicle_tarra_expdate"
            selection = selection + ",cust_vehicle_validation"
            selection = selection + ",wb_client_1"
            selection = selection + ",wb_client_2"

            cmd = New OdbcCommand("select " & selection & " from wbs_data_tab where flag='T' and wbout<>0 ", Conn)
            rd = cmd.ExecuteReader
            jml = rd.FieldCount
            ToolStripProgressBar1.Visible = True
            ToolStripStatusLabel2.Visible = True
            ToolStripStatusLabel2.Text = "Loading for lain-lain..."
            ToolStripProgressBar1.Minimum = 0
            ToolStripProgressBar1.Maximum = jml
            ToolStripProgressBar1.Value = 0
            ProgressBar = 0
            Do While rd.Read
                If rd.HasRows Then

                    wbsid = rd.GetString(0)
                    If rd.IsDBNull(1) Then
                        vehiclenum = ""
                    Else
                        vehiclenum = rd.GetString(1)
                    End If
                    If rd.IsDBNull(2) Then
                        driver = ""
                    Else
                        driver = rd.GetString(2)
                    End If
                    If rd.IsDBNull(3) Then
                        partid = ""
                    Else
                        partid = rd.GetString(3)
                    End If
                    If rd.IsDBNull(4) Then
                        blockid = ""
                    Else
                        blockid = rd.GetString(4)
                    End If
                    If rd.IsDBNull(5) Then
                        refno = ""
                    Else
                        refno = rd.GetString(5)
                    End If
                    If rd.IsDBNull(6) Then
                        supid = ""
                    Else
                        supid = rd.GetString(6)
                    End If
                    If rd.IsDBNull(7) Then
                        wbin = 0
                    Else
                        wbin = rd.GetValue(7)
                    End If
                    If rd.IsDBNull(8) Then
                        wbout = 0
                    Else
                        wbout = rd.GetValue(8)
                    End If
                    If rd.IsDBNull(9) Then
                        netto = 0
                    Else
                        netto = rd.GetValue(9)
                    End If
                    If rd.IsDBNull(12) Then
                        timein = ""
                    Else
                        timein = rd.GetString(12)
                    End If
                    If rd.IsDBNull(13) Then
                        timeout = ""
                    Else
                        timeout = rd.GetString(13)
                    End If
                    If rd.IsDBNull(14) Then
                        operator_ = ""
                    Else
                        operator_ = rd.GetString(14)
                    End If
                    If rd.IsDBNull(15) Then
                        siteid = ""
                    Else
                        siteid = rd.GetString(15)
                    End If
                    If rd.IsDBNull(16) Then
                        flag = ""
                    Else
                        flag = rd.GetString(16)
                    End If
                    If rd.IsDBNull(17) Then
                        transport = ""
                    Else
                        transport = rd.GetString(17)
                    End If

                    If rd.IsDBNull(18) Then
                        divisi = ""
                    Else
                        divisi = rd.GetString(18)
                    End If
                    If rd.IsDBNull(19) Then
                        estateid = ""
                    Else
                        estateid = rd.GetString(19)
                    End If
                    If rd.IsDBNull(20) Then
                        ktu = ""
                    Else
                        ktu = rd.GetString(20)
                    End If
                    If rd.IsDBNull(21) Then
                        remark = ""
                    Else
                        remark = rd.GetString(21)
                    End If
                    If rd.IsDBNull(22) Then
                        cetak = ""
                    Else
                        cetak = rd.GetString(22)
                    End If

                    If rd.IsDBNull(23) Then
                        Vehicle_stnk_expdate_ = ""
                    Else
                        Vehicle_stnk_expdate_ = Format(rd.GetDateTime(23), "yyyy-MM-dd") 'vehicle_stnk_expdate (date)
                    End If
                    If rd.IsDBNull(24) Then
                        vehicle_desc_ = ""
                    Else
                        vehicle_desc_ = rd.GetString(24)   'vehicle_desc (text)
                    End If

                    If rd.IsDBNull(25) Then
                        vehicle_tarra_ = 0
                    Else
                        vehicle_tarra_ = rd.GetValue(25)    ' vehicle_tarra  (NUmber)
                    End If

                    If rd.IsDBNull(26) Then
                        tarra_validation_ = ""
                    Else
                        tarra_validation_ = rd.GetString(26)  ' tarra_validation (text)
                    End If

                    If rd.IsDBNull(27) Then
                        vehicle_tarra_expdate_ = ""
                    Else
                        vehicle_tarra_expdate_ = Format(rd.GetDateTime(27), "yyyy-MM-dd")   ' vehicle_tarra_expdate (date)
                    End If

                    If rd.IsDBNull(28) Then
                        cust_vehicle_validation_ = ""
                    Else
                        cust_vehicle_validation_ = rd.GetString(28)  ' cust_vehicle_validation
                    End If

                    'additonal by jaya fro record hostname oc weigbridge according to audit request
                    If rd.IsDBNull(29) Then
                        wb_client_1 = ""
                    Else
                        wb_client_1 = rd.GetString(29)  ' data wb_client_1
                    End If
                    If rd.IsDBNull(30) Then
                        wb_client_2 = ""
                    Else
                        wb_client_2 = rd.GetString(30)  ' data wb_client_2
                    End If


                    Dim datein As String = Format(rd.GetDateTime(10), "yyyy-MM-dd")
                    Dim dateout As String = Format(rd.GetDateTime(11), "yyyy-MM-dd")
                    sqlinsert = "insert into wbs_data_tab(wbsid,vehiclenum,driver,partid,blockid,refno,supid,wbin,wbout,netto"
                    sqlinsert = sqlinsert + ",datein,dateout,timein,timeout,operator,siteid,flag,transport,divisi,estateid,ktu,remark,cetak,wb_client_1,wb_client_2"
                    If Vehicle_stnk_expdate_ <> "" Then
                        sqlinsert = sqlinsert + " ,vehicle_stnk_expdate"
                    End If
                    If vehicle_desc_ <> "" Then
                        sqlinsert = sqlinsert + ",vehicle_desc"
                    End If
                    If vehicle_tarra_ <> 0 Then
                        sqlinsert = sqlinsert + ",vehicle_tarra"
                    End If
                    If tarra_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",tarra_validation"
                    End If
                    If vehicle_tarra_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",vehicle_tarra_expdate"
                    End If
                    If cust_vehicle_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",cust_vehicle_validation"
                    End If
                    sqlinsert = sqlinsert + ") values ("
                    sqlinsert = sqlinsert + "'" & wbsid & "'"
                    sqlinsert = sqlinsert + ",'" & vehiclenum & "'"
                    sqlinsert = sqlinsert + ",'" & driver & "'"
                    sqlinsert = sqlinsert + ",'" & partid & "'"
                    sqlinsert = sqlinsert + ",'" & blockid & "'"
                    sqlinsert = sqlinsert + ",'" & refno & "'"
                    sqlinsert = sqlinsert + ",'" & supid & "'"
                    sqlinsert = sqlinsert + "," & CDbl(wbin) & ""
                    sqlinsert = sqlinsert + "," & CDbl(wbout) & ""
                    sqlinsert = sqlinsert + "," & CDbl(netto) & ""
                    sqlinsert = sqlinsert + ",to_date('" & datein & "','YYYY-MM-DD')"
                    sqlinsert = sqlinsert + ",to_date('" & dateout & "','YYYY-MM-DD')"
                    sqlinsert = sqlinsert + ",'" & timein & "'"
                    sqlinsert = sqlinsert + ",'" & timeout & "'"
                    sqlinsert = sqlinsert + ",'" & operator_ & "'"
                    sqlinsert = sqlinsert + ",'" & siteid & "'"
                    sqlinsert = sqlinsert + ",'" & flag & "'"
                    sqlinsert = sqlinsert + ",'" & transport & "'"
                    sqlinsert = sqlinsert + ",'" & divisi & "'"
                    sqlinsert = sqlinsert + ",'" & estateid & "'"
                    sqlinsert = sqlinsert + ",'" & ktu & "'"
                    sqlinsert = sqlinsert + ",'" & remark & "'"
                    sqlinsert = sqlinsert + ",'" & cetak & "'"
                    sqlinsert = sqlinsert + ",'" & wb_client_1 & "'"
                    sqlinsert = sqlinsert + ",'" & wb_client_2 & "'"

                    'timein,timeout,operator,siteid,flag,transport,divisi,estateid,ktu,remark,cetak

                    If Vehicle_stnk_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",to_date('" & Vehicle_stnk_expdate_ & "','YYYY-MM-DD')"
                    End If
                    If vehicle_desc_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & vehicle_desc_ & "'"
                    End If
                    If vehicle_tarra_ <> 0 Then
                        sqlinsert = sqlinsert + "," & vehicle_tarra_
                    End If
                    If tarra_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & tarra_validation_ & "'"
                    End If
                    If vehicle_tarra_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",to_date('" & vehicle_tarra_expdate_ & "','YYYY-MM-DD')"
                    End If
                    If cust_vehicle_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & cust_vehicle_validation_ & " '"
                    End If
                    sqlinsert = sqlinsert + ")"

                    'MsgBox(sqlinsert)

                    cmd2 = New OdbcCommand(sqlinsert, Conn2)
                    cmd2.ExecuteNonQuery()
                    cmd = New OdbcCommand("update wbs_data_tab set flag='F' where wbsid='" & wbsid & "'", Conn)
                    cmd.ExecuteNonQuery()

                    ProgressBar = ProgressBar + 1
                    If ProgressBar >= jml Then
                        ProgressBar = jml
                    End If
                    ToolStripProgressBar1.Value = ProgressBar
                    ToolStripStatusLabel2.Text = CInt((ProgressBar / jml) * 100) & "% data lain-lain"
                End If
            Loop
            ToolStripProgressBar1.Visible = False
            ToolStripStatusLabel2.Visible = False
        End If
    End Sub

    Sub tbldatacpo()
        Dim sqlinsert As String = ""
        Dim wbsid As String

        Dim driver As String = ""
        Dim nodo As String = ""
        Dim storage As String = ""
        Dim transport As String = ""
        Dim ktu As String = ""
        Dim detailString As String = ""
        Dim Kontrak As String = ""
        Dim vehiclenum As String = ""
        Dim partid As String = ""
        Dim wbin, wbout, netto As Integer
        Dim wb_client_1 As String = ""
        Dim wb_client_2 As String = ""
        Dim dobesar, csid, sim, segelqty, nosegel, qtykont, ffa, moisture, kotoran, pecahan, datein, dateout, timein, timeout, operator_, siteid, flag As String
        Dim estateid, remark, retur, cetak As String

        Dim tempDetail_wbsid_ As String = ""
        Dim tempDetail_nodo_ As String = ""
        Dim tempDetail_dobesar_ As String = ""
        Dim tempDetail_kontrak_ As String = ""
        Dim tempDetail_netto_detail_ As Double = 0
        Dim tempDetail_siteid_ As String = ""
        Dim tempDetail_flag_ As String = ""
        Dim tempDetail_stg_detail_ As String = ""
        Dim Sqlupdate As String = ""

        Dim Vehicle_stnk_expdate_ As String = ""
        Dim vehicle_desc_ As String = ""
        Dim vehicle_tarra_ As Double = 0
        Dim tarra_validation_ As String = ""
        Dim vehicle_tarra_expdate_ As String = ""
        Dim cust_vehicle_validation_ As String = ""
        Dim ProgressBar As Integer = 0
        'EDITED ATA (*Karena table suka bergeser)
        Dim rd2
        Dim jml As Integer = 0
        cmd2 = New OdbcCommand("select wbsid from wbs_datacpo_tab where flag='T' and wbout<>0 and retur <> 'P' and retur <> 'N' order by wbsid", Conn)
        rd2 = cmd2.ExecuteReader
        Do While rd2.Read
            If rd2.HasRows Then
                jml = jml + 1
            End If
        Loop
        If jml > 50 Then
            jml = 50
        End If

        Dim selection As String = ""
        selection = "wbsid,vehiclenum,driver,partid,"
        selection = selection + "nodo,kontrak,dobesar,"
        selection = selection + "transport,csid,sim,segelqty,nosegel,qtykont,"
        selection = selection + "wbin,wbout,netto,ffa,moisture,kotoran,pecahan,"
        selection = selection + "datein,dateout,timein,timeout,operator,siteid,flag,"
        selection = selection + "storagecode,estateid,remark,retur,cetak,vehicle_stnk_expdate,"
        selection = selection + "vehicle_desc,vehicle_tarra,tarra_validation,vehicle_tarra_expdate,cust_vehicle_validation,wb_client_1,wb_client_2"

        If jml > 0 Then
            cmd = New OdbcCommand("select " & selection & " from wbs_datacpo_tab where flag='T' and wbout<>0 and retur <> 'P' and retur <> 'N' order by wbsid", Conn)
            rd = cmd.ExecuteReader
            jml = rd.FieldCount
            ToolStripProgressBar1.Visible = True
            ToolStripStatusLabel2.Visible = True
            ToolStripStatusLabel2.Text = "Loading for CPO..."
            ToolStripProgressBar1.Minimum = 0
            ToolStripProgressBar1.Maximum = jml
            ToolStripProgressBar1.Value = 0
            ProgressBar = 0
            Do While rd.Read
                If rd.HasRows Then

                    wbsid = rd.GetString(0)

                    If rd.IsDBNull(1) Then
                        vehiclenum = ""
                    Else
                        vehiclenum = rd.GetString(1)
                    End If
                    If rd.IsDBNull(2) Then
                        driver = ""
                    Else
                        driver = rd.GetString(2)
                    End If
                    If rd.IsDBNull(3) Then
                        partid = ""
                    Else
                        partid = rd.GetString(3)
                    End If
                    If rd.IsDBNull(4) Then
                        nodo = ""
                    Else
                        nodo = rd.GetString(4)
                    End If
                    If rd.IsDBNull(5) Then
                        Kontrak = ""
                    Else
                        Kontrak = rd.GetString(5)
                    End If
                    If rd.IsDBNull(6) Then
                        dobesar = ""
                    Else
                        dobesar = rd.GetString(6)
                    End If
                    If rd.IsDBNull(7) Then
                        transport = ""
                    Else
                        transport = rd.GetString(7)
                    End If
                    If rd.IsDBNull(8) Then
                        csid = ""
                    Else
                        csid = rd.GetString(8)
                    End If
                    If rd.IsDBNull(9) Then
                        sim = ""
                    Else
                        sim = rd.GetString(9)
                    End If
                    If rd.IsDBNull(10) Then
                        segelqty = ""
                    Else
                        segelqty = rd.GetString(10)
                    End If
                    If rd.IsDBNull(11) Then
                        nosegel = ""
                    Else
                        nosegel = rd.GetString(11)
                    End If
                    If rd.IsDBNull(12) Then
                        qtykont = ""
                    Else
                        qtykont = rd.GetString(12)
                    End If

                    If rd.IsDBNull(13) Then
                        wbin = 0
                    Else
                        wbin = rd.GetValue(13)
                    End If
                    If rd.IsDBNull(14) Then
                        wbout = 0
                    Else
                        wbout = rd.GetValue(14)
                    End If
                    If rd.IsDBNull(15) Then
                        netto = 0
                    Else
                        netto = rd.GetValue(15)
                    End If

                    If rd.IsDBNull(16) Then
                        ffa = ""
                    Else
                        ffa = rd.GetString(16)
                    End If
                    If rd.IsDBNull(17) Then
                        moisture = ""
                    Else
                        moisture = rd.GetString(17)
                    End If
                    If rd.IsDBNull(18) Then
                        kotoran = ""
                    Else
                        kotoran = rd.GetString(18)
                    End If
                    If rd.IsDBNull(19) Then
                        pecahan = ""
                    Else
                        pecahan = rd.GetString(19)
                    End If
                    If rd.IsDBNull(20) Then
                        datein = ""
                    Else
                        datein = Format(rd.GetDateTime(20), "yyyy-MM-dd")
                    End If
                    If rd.IsDBNull(21) Then
                        dateout = ""
                    Else
                        dateout = Format(rd.GetDateTime(21), "yyyy-MM-dd")
                    End If
                    If rd.IsDBNull(22) Then
                        timein = ""
                    Else
                        timein = rd.GetString(22)
                    End If
                    If rd.IsDBNull(23) Then
                        timeout = ""
                    Else
                        timeout = rd.GetString(23)
                    End If
                    If rd.IsDBNull(24) Then
                        operator_ = ""
                    Else
                        operator_ = rd.GetString(24)
                    End If
                    If rd.IsDBNull(25) Then
                        siteid = ""
                    Else
                        siteid = rd.GetString(25)
                    End If
                    If rd.IsDBNull(26) Then
                        flag = ""
                    Else
                        flag = rd.GetString(26)
                    End If


                    If rd.IsDBNull(27) Then
                        storage = ""
                    Else
                        storage = rd.GetString(27)
                    End If
                    If rd.IsDBNull(28) Then
                        estateid = ""
                    Else
                        estateid = rd.GetString(28)
                    End If
                    If rd.IsDBNull(29) Then
                        remark = ""
                    Else
                        remark = rd.GetString(29)
                    End If
                    If rd.IsDBNull(30) Then
                        retur = ""
                    Else
                        retur = rd.GetString(30)
                    End If
                    If rd.IsDBNull(31) Then
                        cetak = ""
                    Else
                        cetak = rd.GetString(31)
                    End If

                    If rd.IsDBNull(32) Then
                        Vehicle_stnk_expdate_ = ""
                    Else
                        Vehicle_stnk_expdate_ = Format(rd.GetDateTime(32), "yyyy-MM-dd") 'vehicle_stnk_expdate (date)
                    End If
                    If rd.IsDBNull(33) Then
                        vehicle_desc_ = ""
                    Else
                        vehicle_desc_ = rd.GetString(33)   'vehicle_desc (text)
                    End If

                    If rd.IsDBNull(34) Then
                        vehicle_tarra_ = 0
                    Else
                        vehicle_tarra_ = rd.GetValue(34)    ' vehicle_tarra  (NUmber)
                    End If

                    If rd.IsDBNull(35) Then
                        tarra_validation_ = ""
                    Else
                        tarra_validation_ = rd.GetString(35)  ' tarra_validation (text)
                    End If

                    If rd.IsDBNull(36) Then
                        vehicle_tarra_expdate_ = ""
                    Else
                        vehicle_tarra_expdate_ = Format(rd.GetDateTime(36), "yyyy-MM-dd")   ' vehicle_tarra_expdate (date)
                    End If

                    If rd.IsDBNull(37) Then
                        cust_vehicle_validation_ = ""
                    Else
                        cust_vehicle_validation_ = rd.GetString(37)  ' cust_vehicle_validation
                    End If
                    If rd.IsDBNull(38) Then
                        wb_client_1 = ""
                    Else
                        wb_client_1 = rd.GetString(38)  ' wb_client_1
                    End If
                    If rd.IsDBNull(39) Then
                        wb_client_2 = ""
                    Else
                        wb_client_2 = rd.GetString(39)  ' wb_client_2
                    End If





                    sqlinsert = "insert into wbs_datacpo_tab(wbsid,vehiclenum,driver,partid,nodo,kontrak,dobesar,transport,csid,sim,segelqty,nosegel,qtykont,wbin,wbout,netto"
                    sqlinsert = sqlinsert + ",ffa,moisture,kotoran,pecahan,datein,dateout,timein,timeout,operator,siteid,flag,storagecode,remark,retur,cetak,wb_client_1,wb_client_2"
                    If Vehicle_stnk_expdate_ <> "" Then
                        sqlinsert = sqlinsert + " ,vehicle_stnk_expdate"
                    End If
                    If vehicle_desc_ <> "" Then
                        sqlinsert = sqlinsert + ",vehicle_desc"
                    End If
                    If vehicle_tarra_ <> 0 Then
                        sqlinsert = sqlinsert + ",vehicle_tarra"
                    End If
                    If tarra_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",tarra_validation"
                    End If
                    If vehicle_tarra_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",vehicle_tarra_expdate"
                    End If
                    If cust_vehicle_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",cust_vehicle_validation"
                    End If
                    'wbsid,vehiclenum,driver,partid,nodo,kontrak,dobesar,transport,csid,sim,segelqty,nosegel,qtykont,wbin,wbout,netto
                    'ffa,moisture,kotoran,pecahan,datein,dateout,timein,timeout,operator,siteid,flag,storagecode,remark,retur,cetak

                    sqlinsert = sqlinsert + ") values ('" & wbsid & "'"
                    sqlinsert = sqlinsert + ",'" & vehiclenum & "'"
                    sqlinsert = sqlinsert + ",'" & driver & "'"
                    sqlinsert = sqlinsert + ",'" & partid & "'"
                    sqlinsert = sqlinsert + ",'" & nodo & "'"
                    sqlinsert = sqlinsert + ",'" & Kontrak & "'"
                    sqlinsert = sqlinsert + ",'" & dobesar & "'"
                    sqlinsert = sqlinsert + ",'" & transport & "'"
                    sqlinsert = sqlinsert + ",'" & csid & "'"
                    sqlinsert = sqlinsert + ",'" & sim & "'"
                    sqlinsert = sqlinsert + ",'" & segelqty & "'"
                    sqlinsert = sqlinsert + ",'" & nosegel & "'"
                    sqlinsert = sqlinsert + ",'" & qtykont & "'"
                    sqlinsert = sqlinsert + "," & CDbl(wbin) & ""
                    sqlinsert = sqlinsert + "," & CDbl(wbout) & ""
                    sqlinsert = sqlinsert + "," & CDbl(netto) & ""
                    sqlinsert = sqlinsert + ",'" & ffa & "'"
                    sqlinsert = sqlinsert + ",'" & moisture & "'"
                    sqlinsert = sqlinsert + ",'" & kotoran & "'"
                    sqlinsert = sqlinsert + ",'" & pecahan & "'"
                    sqlinsert = sqlinsert + ",to_date('" & datein & "','YYYY-MM-DD')"
                    sqlinsert = sqlinsert + ",to_date('" & dateout & "','YYYY-MM-DD')"
                    sqlinsert = sqlinsert + ",'" & timein & "'"
                    sqlinsert = sqlinsert + ",'" & timeout & "'"
                    sqlinsert = sqlinsert + ",'" & operator_ & "'"
                    sqlinsert = sqlinsert + ",'" & siteid & "'"
                    sqlinsert = sqlinsert + ",'" & flag & "'"
                    sqlinsert = sqlinsert + ",'" & storage & "'"
                    sqlinsert = sqlinsert + ",'" & remark & "'"
                    sqlinsert = sqlinsert + ",'" & retur & "'"
                    sqlinsert = sqlinsert + ",'" & storage & "'"
                    sqlinsert = sqlinsert + ",'" & wb_client_1 & "'"
                    sqlinsert = sqlinsert + ",'" & wb_client_2 & "'"


                    If Vehicle_stnk_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",to_date('" & Vehicle_stnk_expdate_ & "','YYYY-MM-DD')"
                    End If
                    If vehicle_desc_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & vehicle_desc_ & "'"
                    End If
                    If vehicle_tarra_ <> 0 Then
                        sqlinsert = sqlinsert + "," & vehicle_tarra_
                    End If
                    If tarra_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & tarra_validation_ & "'"
                    End If
                    If vehicle_tarra_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",to_date('" & vehicle_tarra_expdate_ & "','YYYY-MM-DD')"
                    End If
                    If cust_vehicle_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & cust_vehicle_validation_ & " '"
                    End If

                    sqlinsert = sqlinsert + ")"

                    'MsgBox(wbsid)

                    cmd2 = New OdbcCommand(sqlinsert, Conn2)
                    cmd2.ExecuteNonQuery()

                    cmd = New OdbcCommand("update wbs_datacpo_tab set flag='F' where wbsid='" & wbsid & "'", Conn)
                    cmd.ExecuteNonQuery()

                    'Start to Insert Detail CPO, by NAF
                    detailString = "select wbsid, nodo, kontrak,DObesar, netto_detail,storagecode, siteid, flag from wbs_datacpo_detail_tab"
                    detailString = detailString + " where "
                    detailString = detailString + " flag='T' and wbsid = '" & wbsid & "'  and"
                    detailString = detailString + " siteid = '" & siteid & "'"

                    cmd = New OdbcCommand(detailString, Conn)
                    rd = cmd.ExecuteReader


                    Do While rd.Read
                        If rd.HasRows Then
                            If rd.IsDBNull(0) Then
                                tempDetail_wbsid_ = ""
                            Else
                                tempDetail_wbsid_ = rd.GetString(0)
                            End If

                            If rd.IsDBNull(1) Then
                                tempDetail_nodo_ = ""
                            Else
                                tempDetail_nodo_ = rd.GetString(1)
                            End If

                            If rd.IsDBNull(2) Then
                                tempDetail_kontrak_ = ""
                            Else
                                tempDetail_kontrak_ = rd.GetString(2)
                            End If
                            If rd.IsDBNull(3) Then
                                tempDetail_dobesar_ = ""
                            Else
                                tempDetail_dobesar_ = rd.GetString(3)
                            End If

                            If rd.IsDBNull(4) Then
                                tempDetail_netto_detail_ = 0
                            Else
                                tempDetail_netto_detail_ = CDbl(rd.GetValue(4))
                            End If

                            If rd.IsDBNull(5) Then
                                tempDetail_stg_detail_ = "0"
                            Else
                                tempDetail_stg_detail_ = rd.GetString(5)
                            End If
                            If rd.IsDBNull(6) Then
                                tempDetail_siteid_ = ""
                            Else
                                tempDetail_siteid_ = rd.GetString(6)
                            End If

                            If rd.IsDBNull(7) Then
                                tempDetail_flag_ = ""
                            Else
                                tempDetail_flag_ = rd.GetString(7)
                            End If


                            sqlinsert = "Insert into wbs_datacpo_detail_tab ("
                            sqlinsert = sqlinsert + "wbsid, nodo, kontrak,doBesar, netto_detail,storagecode, siteid, flag ) values ("
                            sqlinsert = sqlinsert + "'" & tempDetail_wbsid_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempDetail_nodo_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempDetail_kontrak_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempDetail_dobesar_ & "'"
                            sqlinsert = sqlinsert + "," & tempDetail_netto_detail_ & ""
                            sqlinsert = sqlinsert + ",'" & tempDetail_stg_detail_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempDetail_siteid_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempDetail_flag_ & "')"

                            cmd2 = New OdbcCommand(sqlinsert, Conn2)
                            cmd2.ExecuteNonQuery()
                            ' MsgBox(sqlinsert)



                            Sqlupdate = "update wbs_datacpo_detail_tab set flag='F' where wbsid='" & tempDetail_wbsid_ & "'"
                            Sqlupdate = Sqlupdate + " and siteid = '" & tempDetail_siteid_ & "' and kontrak = '" & tempDetail_kontrak_ & "'"


                            cmd = New OdbcCommand(Sqlupdate, Conn)
                            cmd.ExecuteNonQuery()
                        End If
                    Loop

                    ProgressBar = ProgressBar + 1
                    If ProgressBar >= jml Then
                        ProgressBar = jml
                    End If
                    ToolStripProgressBar1.Value = ProgressBar
                    ToolStripStatusLabel2.Text = CInt((ProgressBar / jml) * 100) & "% data CPO"
                End If
            Loop
            ToolStripProgressBar1.Visible = False
            ToolStripStatusLabel2.Visible = False
        End If
    End Sub

    Sub tbldatacpoTransfer()
        Dim sqlinsert As String = ""
        Dim wbsid As String
        Dim remark As String = ""

        Dim driver As String = ""
        Dim sim As String = ""
        Dim nodo As String = ""
        Dim storagefrom As String = ""
        Dim storageto As String = ""
        Dim nosegel As String = ""
        Dim transport As String = ""
        Dim ktu As String = ""
        Dim detailString As String = ""
        Dim tempSiteId As String = ""
        Dim segelqty As String = ""
        Dim wbin As Integer = 0
        Dim wbout As Integer = 0
        Dim netto As Integer = 0
        Dim ffa As String = "0"
        Dim moisture As String = "0"
        Dim kotoran As String = "0"
        Dim partid As String = ""
        Dim cetak, vehiclenum As String
        Dim wb_client_1 As String
        Dim wb_client_2 As String

        Dim Sqlupdate As String = ""

        Dim Vehicle_stnk_expdate_ As String = ""
        Dim vehicle_desc_ As String = ""
        Dim vehicle_tarra_ As Double = 0
        Dim tarra_validation_ As String = ""
        Dim vehicle_tarra_expdate_ As String = ""
        'Dim cust_vehicle_validation_ As String = ""
        Dim siteidSupplier As String = ""
        Dim ProgressBar As Integer = 0
        'Dim cmd_fccode, rd_fccode

        Dim rd2
        Dim jml As Integer = 0
        cmd2 = New OdbcCommand("select wbsid from wbs_datacpo_transfer_tab where flag='T' and wbout<>0", Conn)
        rd2 = cmd2.ExecuteReader
        Do While rd2.Read
            If rd2.HasRows Then
                jml = jml + 1
            End If
        Loop
        If jml > 50 Then
            jml = 50
        End If
        Dim selection As String = ""
        selection = "wbsid,vehiclenum,driver,partid,nodo,transport,sim,segelqty,nosegel,"
        selection = selection + "wbin,wbout,netto,ffa,moisture,kotoran,Mgr,"
        selection = selection + "datein,dateout,timein,timeout,operator,siteid,flag,"
        selection = selection + "storagecodeFrom,storagecodeTo,remark,cetak,vehicle_stnk_expdate,"
        selection = selection + "vehicle_desc,vehicle_tarra,tarra_validation,vehicle_tarra_expdate,wb_client_1,wb_client_2"
        If jml > 0 Then
            cmd = New OdbcCommand("select " & selection & " from wbs_datacpo_transfer_tab where flag='T' and wbout<>0", Conn)
            rd = cmd.ExecuteReader

            'MsgBox("select " & selection & " from wbs_datacpo_transfer_tab where flag='T' and wbout<>0")
            ToolStripProgressBar1.Visible = True
            ToolStripStatusLabel2.Visible = True
            ToolStripStatusLabel2.Text = "Loading for CPO Transfer..."
            ToolStripProgressBar1.Minimum = 0
            ToolStripProgressBar1.Maximum = jml
            ToolStripProgressBar1.Value = 0
            ProgressBar = 0
            Do While rd.Read
                If rd.HasRows Then

                    tempSiteId = rd.GetString(21)
                    wbsid = rd.GetString(0)

                    If rd.IsDBNull(1) Then
                        vehiclenum = ""
                    Else
                        vehiclenum = rd.GetString(1)
                    End If
                    If rd.IsDBNull(2) Then
                        driver = ""
                    Else
                        driver = rd.GetString(2)
                    End If

                    If rd.IsDBNull(3) Then
                        partid = ""
                    Else
                        partid = rd.GetString(3)
                    End If

                    If rd.IsDBNull(4) Then
                        nodo = ""
                    Else
                        nodo = rd.GetString(4)
                    End If
                    If rd.IsDBNull(5) Then
                        transport = ""
                    Else
                        transport = rd.GetString(5)
                    End If

                    If rd.IsDBNull(6) Then
                        sim = ""
                    Else
                        sim = rd.GetString(6)
                    End If
                    If rd.IsDBNull(7) Then
                        segelqty = "0"
                    Else
                        segelqty = rd.GetString(7)
                    End If
                    If rd.IsDBNull(8) Then
                        nosegel = "0"
                    Else
                        nosegel = rd.GetString(8)
                    End If
                    If rd.IsDBNull(9) Then
                        wbin = 0
                    Else
                        wbin = rd.GetValue(9)
                    End If
                    If rd.IsDBNull(10) Then
                        wbout = 0
                    Else
                        wbout = rd.GetValue(10)
                    End If
                    If rd.IsDBNull(11) Then
                        netto = 0
                    Else
                        netto = rd.GetValue(11)
                    End If

                    If rd.IsDBNull(12) Then
                        ffa = "0"
                    Else
                        ffa = rd.GetString(12)
                    End If
                    If rd.IsDBNull(13) Then
                        moisture = "0"
                    Else
                        moisture = rd.GetString(13)
                    End If
                    If rd.IsDBNull(14) Then
                        kotoran = "0"
                    Else
                        kotoran = rd.GetString(14)
                    End If

                    If rd.IsDBNull(15) Then
                        ktu = ""
                    Else
                        ktu = rd.GetString(15)
                    End If

                    Dim datein As String = Format(rd.GetDateTime(16), "yyyy-MM-dd")
                    Dim dateout As String = Format(rd.GetDateTime(17), "yyyy-MM-dd")


                    Dim storagecodeTo, storagecodeFrom, flag, operator_, timeout, timein
                    If rd.IsDBNull(18) Then
                        timein = ""
                    Else
                        timein = rd.GetString(18) 'vehicle_stnk_expdate (date)
                    End If
                    If rd.IsDBNull(19) Then
                        timeout = ""
                    Else
                        timeout = rd.GetString(19) 'vehicle_stnk_expdate (date)
                    End If
                    If rd.IsDBNull(20) Then
                        operator_ = ""
                    Else
                        operator_ = rd.GetString(20) 'vehicle_stnk_expdate (date)
                    End If
                    If rd.IsDBNull(22) Then
                        flag = ""
                    Else
                        flag = rd.GetString(22) 'vehicle_stnk_expdate (date)
                    End If
                    If rd.IsDBNull(23) Then
                        storagecodeFrom = ""
                    Else
                        storagecodeFrom = rd.GetString(23) 'vehicle_stnk_expdate (date)
                    End If
                    If rd.IsDBNull(24) Then
                        storagecodeTo = ""
                    Else
                        storagecodeTo = rd.GetString(24) 'vehicle_stnk_expdate (date)
                    End If
                    If rd.IsDBNull(25) Then
                        remark = ""
                    Else
                        remark = rd.GetString(25)
                    End If
                    If rd.IsDBNull(26) Then
                        cetak = ""
                    Else
                        cetak = rd.GetString(26)
                    End If

                    If rd.IsDBNull(27) Then
                        Vehicle_stnk_expdate_ = ""
                    Else
                        Vehicle_stnk_expdate_ = Format(rd.GetDateTime(27), "yyyy-MM-dd") 'vehicle_stnk_expdate (date)
                    End If

                    If rd.IsDBNull(28) Then
                        vehicle_desc_ = ""
                    Else
                        vehicle_desc_ = rd.GetString(28)   'vehicle_desc (text)
                    End If

                    If rd.IsDBNull(29) Then
                        vehicle_tarra_ = 0
                    Else
                        vehicle_tarra_ = rd.GetValue(29)    ' vehicle_tarra  (NUmber)
                    End If

                    If rd.IsDBNull(30) Then
                        tarra_validation_ = ""
                    Else
                        tarra_validation_ = rd.GetString(30)  ' tarra_validation (text)
                    End If

                    If rd.IsDBNull(31) Then
                        vehicle_tarra_expdate_ = ""
                    Else
                        vehicle_tarra_expdate_ = Format(rd.GetDateTime(31), "yyyy-MM-dd")  ' vehicle_tarra_expdate (date)
                        ' Format(rd.GetString(31), "yyyy-MM-dd")  
                    End If

                    If rd.IsDBNull(32) Then
                        wb_client_1 = ""
                    Else
                        wb_client_1 = rd.GetString(32)  ' wb_client_1
                    End If

                    If rd.IsDBNull(33) Then
                        wb_client_2 = ""
                    Else
                        wb_client_2 = rd.GetString(33)  ' wb_client_2
                    End If

                    If rd.IsDBNull(21) Then
                        siteidSupplier = ""
                    Else
                        'cmd_fccode = New odbcCommand("select fccode from wbs_supplier_tab where supid = '" & rd.GetString(21) & "'", Conn)
                        'rd_fccode = cmd_fccode.ExecuteReader
                        'rd_fccode.Read()
                        'If rd.HasRows Then

                        '    siteidSupplier = rd_fccode.GetString(0)
                        'End If
                        siteidSupplier = rd.GetString(21)
                    End If


                    sqlinsert = "insert into wbs_datacpo_transfer_tab(WBSID,VEHICLENUM,DRIVER,PARTID,NODO,TRANSPORT,SIM,SEGELQTY,NOSEGEL,WBIN,WBOUT,NETTO"
                    sqlinsert = sqlinsert + ",FFA,MOISTURE,KOTORAN,MGR,DATEIN,DATEOUT,TIMEIN,TIMEOUT,OPERATOR,SITEID,FLAG,STORAGEFROM,STORAGETO,REMARK,CETAK,WB_CLIENT_1,WB_CLIENT_2"
                    If Vehicle_stnk_expdate_ <> "" Then
                        sqlinsert = sqlinsert + " ,VEHICLE_STNK_EXPDATE"
                    End If
                    If vehicle_desc_ <> "" Then
                        sqlinsert = sqlinsert + ",VEHICLE_DESC"
                    End If
                    If vehicle_tarra_ <> 0 Then
                        sqlinsert = sqlinsert + ",VEHICLE_TARRA"
                    End If
                    If tarra_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",TARRA_VALIDATION"
                    End If
                    If vehicle_tarra_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",VEHICLE_TARRA_EXPDATE"
                    End If
                    'If cust_vehicle_validation_ <> "" Then
                    '    sqlinsert = sqlinsert + ",cust_vehicle_validation"
                    'End If

                    sqlinsert = sqlinsert + ") values ('" & wbsid & "'"
                    sqlinsert = sqlinsert + ",'" & vehiclenum & "'"
                    sqlinsert = sqlinsert + ",'" & driver & "'"
                    sqlinsert = sqlinsert + ",'" & partid & "'"
                    sqlinsert = sqlinsert + ",'" & nodo & "'"
                    sqlinsert = sqlinsert + ",'" & transport & "'"
                    sqlinsert = sqlinsert + ",'" & sim & "'"
                    sqlinsert = sqlinsert + ",'" & segelqty & "'"
                    sqlinsert = sqlinsert + ",'" & nosegel & "'"
                    sqlinsert = sqlinsert + "," & CDbl(wbin) & ""
                    sqlinsert = sqlinsert + "," & CDbl(wbout) & ""
                    sqlinsert = sqlinsert + "," & CDbl(netto) & ""
                    sqlinsert = sqlinsert + ",'" & ffa & "'"
                    sqlinsert = sqlinsert + ",'" & moisture & "'"
                    sqlinsert = sqlinsert + ",'" & kotoran & "'"
                    sqlinsert = sqlinsert + ",'" & ktu & "'"
                    sqlinsert = sqlinsert + ",to_date('" & datein & "','YYYY-MM-DD')"
                    sqlinsert = sqlinsert + ",to_date('" & dateout & "','YYYY-MM-DD')"
                    sqlinsert = sqlinsert + ",'" & timein & "'"
                    sqlinsert = sqlinsert + ",'" & timeout & "'"
                    sqlinsert = sqlinsert + ",'" & operator_ & "'"
                    sqlinsert = sqlinsert + ",'" & siteidSupplier & "'"

                    sqlinsert = sqlinsert + ",'" & flag & "'"
                    sqlinsert = sqlinsert + ",'" & storagecodeFrom & "'"
                    sqlinsert = sqlinsert + ",'" & storagecodeTo & "'"
                    sqlinsert = sqlinsert + ",'" & remark & "'"
                    sqlinsert = sqlinsert + ",'" & cetak & "'"
                    sqlinsert = sqlinsert + ",'" & wb_client_1 & "'"
                    sqlinsert = sqlinsert + ",'" & wb_client_2 & "'"
                    ' Add new Column for handling History, by NAF
                    ' Modify new Column for handling History, by AKB

                    If Vehicle_stnk_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",to_date('" & Vehicle_stnk_expdate_ & "','YYYY-MM-DD')"
                    End If
                    If vehicle_desc_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & vehicle_desc_ & "'"
                    End If
                    If vehicle_tarra_ <> 0 Then
                        sqlinsert = sqlinsert + "," & vehicle_tarra_
                    End If
                    If tarra_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & tarra_validation_ & "'"
                    End If
                    If vehicle_tarra_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",to_date('" & vehicle_tarra_expdate_ & "','YYYY-MM-DD')"
                    End If
                    'If cust_vehicle_validation_ <> "" Then
                    '    sqlinsert = sqlinsert + ",'" & cust_vehicle_validation_ & " '"
                    'End If

                    sqlinsert = sqlinsert + ")"

                    'MsgBox(wbsid)

                    cmd2 = New OdbcCommand(sqlinsert, Conn2)
                    cmd2.ExecuteNonQuery()

                    cmd = New OdbcCommand("update wbs_datacpo_transfer_tab set flag='F' where wbsid='" & wbsid & "'", Conn)
                    cmd.ExecuteNonQuery()

                    ProgressBar = ProgressBar + 1
                    If ProgressBar >= jml Then
                        ProgressBar = jml
                    End If
                    ToolStripProgressBar1.Value = ProgressBar
                    ToolStripStatusLabel2.Text = CInt((ProgressBar / jml) * 100) & "% data CPO Transfer"
                End If
            Loop
            ToolStripProgressBar1.Visible = False
            ToolStripStatusLabel2.Visible = False
        End If
    End Sub


    Sub tbldatatbs()
        'MsgBox("tbldata")
        Dim sqlinsert As String = ""
        Dim wbsid As String
        Dim blockid As String
        Dim driver As String = ""
        Dim spbs As String = ""
        Dim transport As String = ""
        Dim estateid As String = ""
        Dim divisi As String = ""
        Dim ktu As String = ""
        Dim janjang As String = ""
        Dim remark As String = ""
        Dim vehicleno As String = ""
        Dim partname As String = ""
        Dim customer As String = ""
        Dim wbin As Integer = 0
        Dim wbout As Integer = 0
        Dim timein As String = ""
        Dim timeout As String = ""
        Dim netto As Integer = 0
        Dim sortase As String = "0"
        Dim entry As String = ""
        Dim siteid As String = ""
        Dim sample As String = ""
        Dim masak As String = ""

        Dim mentah As String = ""
        Dim kecil As String = ""
        Dim dura As String = ""
        Dim tpanjang As String = ""
        Dim tkosong As String = ""
        Dim restan As String = ""
        Dim air As String = ""
        Dim sampah As String = ""
        Dim pasir As String = ""
        Dim lain As String = ""
        Dim cetak As String = ""
        Dim flag As String = ""
        Dim lewatmasak As String = ""
        Dim brondolan As Integer = 0
        Dim eatenbyrat As Integer = 0
        Dim Vehicle_stnk_expdate_ As String = ""
        Dim vehicle_desc_ As String = ""
        Dim vehicle_tarra_ As Double = 0
        Dim tarra_validation_ As String = ""
        Dim vehicle_tarra_expdate_ As String = ""
        Dim cust_vehicle_validation_ As String = ""
        Dim wb_client_1 As String
        Dim wb_client_2 As String
        Dim no_nego As String = ""
        Dim grade_tbs As String = ""
        Dim trfid As Integer = 0
        Dim jenis As String = ""
        Dim tarif As Integer = 0
        Dim uom As String = ""
        Dim total_tarif As Integer = 0
        '-----------------------------

        Dim ProgressBar As Integer = 0
        'EDITED ATA
        Dim rd2
        Dim db_selection As String = ""
        Dim jml As Integer = 0
        cmd2 = New OdbcCommand("select wbsid from wbs_datatbs_tab where flag='T' and (wbout<>0  or TypeOfWeighing ='W1' )", Conn)
        rd2 = cmd2.ExecuteReader
        Do While rd2.Read
            If rd2.HasRows Then
                jml = jml + 1
            End If
        Loop
        If jml > 50 Then
            jml = 50
        End If
        'MsgBox("error")
        If jml > 0 Then

            db_selection = db_selection + "wbsid,vehicleno,driver,spbs,transport,partname,customer,"
            db_selection = db_selection + "estate,divisi,block,janjang,ktu,remark,datein,dateout,wbin,wbout,"
            db_selection = db_selection + "timein,timeout,netto,sortase,entry,siteid,sample,masak,"
            db_selection = db_selection + "mentah,kecil,dura,tpanjang,tkosong,restan,air,sampah,pasir,lain,"
            db_selection = db_selection + "cetak,flag,lewatmasak,vehicle_stnk_expdate,vehicle_desc,vehicle_tarra,"
            db_selection = db_selection + "tarra_validation,vehicle_tarra_expdate,cust_vehicle_validation,"
            db_selection = db_selection + "TypeOfWeighing,block_janjang,wb_client_1,wb_client_2,eatenbyrat,brondolan,no_nego,grade_tbs"

            cmd = New OdbcCommand("select " & db_selection & " from wbs_datatbs_tab where flag='T' and (wbout<>0  or TypeOfWeighing ='W1' )", Conn)
            rd = cmd.ExecuteReader

            ToolStripProgressBar1.Visible = True
            ToolStripStatusLabel2.Visible = True
            ToolStripStatusLabel2.Text = "Loading for TBS..."
            ToolStripProgressBar1.Minimum = 0
            ToolStripProgressBar1.Maximum = jml
            ToolStripProgressBar1.Value = 0

            ProgressBar = 0
            Do While rd.Read
                If rd.HasRows Then

                    wbsid = rd.GetString(0)


                    If rd.IsDBNull(1) Then
                        vehicleno = ""
                    Else
                        vehicleno = rd.GetString(1)
                    End If
                    If rd.IsDBNull(2) Then
                        driver = ""
                    Else
                        driver = rd.GetString(2)
                    End If
                    'MsgBox("masuk3")
                    If rd.IsDBNull(3) Then
                        spbs = ""
                    Else
                        spbs = rd.GetString(3)
                    End If
                    'MsgBox("masuk4")
                    If rd.IsDBNull(4) Then
                        transport = ""
                    Else
                        transport = rd.GetString(4)
                    End If
                    If rd.IsDBNull(5) Then
                        partname = ""
                    Else
                        partname = rd.GetString(5)
                    End If
                    If rd.IsDBNull(6) Then
                        customer = ""
                    Else
                        customer = rd.GetString(6)
                    End If

                    If rd.IsDBNull(7) Then
                        estateid = ""
                    Else
                        estateid = rd.GetString(7)
                    End If
                    'MsgBox("masuk6")
                    If rd.IsDBNull(8) Then
                        divisi = ""
                    Else
                        divisi = rd.GetString(8)
                    End If
                    If rd.IsDBNull(9) Then
                        blockid = ""
                    Else
                        blockid = rd.GetString(9)
                    End If
                    If rd.IsDBNull(10) Then
                        janjang = ""
                    Else
                        janjang = rd.GetString(10)
                    End If
                    If rd.IsDBNull(11) Then
                        ktu = ""
                    Else
                        ktu = rd.GetString(11)
                    End If
                    'MsgBox("masuk8")
                    If rd.IsDBNull(12) Then
                        remark = ""
                    Else
                        remark = rd.GetString(12)
                    End If
                    If rd.IsDBNull(15) Then
                        wbin = 0
                    Else
                        wbin = rd.GetValue(15)
                    End If
                    If rd.IsDBNull(16) Then
                        wbout = 0
                    Else
                        wbout = rd.GetValue(16)
                    End If
                    If rd.IsDBNull(17) Then
                        timein = ""
                    Else
                        timein = rd.GetString(17)
                    End If
                    If rd.IsDBNull(18) Then
                        timeout = ""
                    Else
                        timeout = rd.GetString(18)
                    End If
                    If rd.IsDBNull(19) Then
                        netto = 0
                    Else
                        netto = rd.GetValue(19)
                    End If
                    If rd.IsDBNull(20) Then
                        sortase = "0"
                    Else
                        sortase = rd.GetString(20)
                    End If
                    If rd.IsDBNull(21) Then
                        entry = ""
                    Else
                        entry = rd.GetString(21)
                    End If
                    If rd.IsDBNull(22) Then
                        siteid = ""
                    Else
                        siteid = rd.GetString(22)
                    End If
                    If rd.IsDBNull(23) Then
                        sample = "0"
                    Else
                        sample = rd.GetString(23)
                    End If
                    If rd.IsDBNull(24) Then
                        masak = "0"
                    Else
                        masak = rd.GetValue(24)
                    End If
                    If rd.IsDBNull(25) Then
                        mentah = "0"
                    Else
                        mentah = rd.GetValue(25)
                    End If
                    If rd.IsDBNull(26) Then
                        kecil = "0"
                    Else
                        kecil = rd.GetValue(26)
                    End If
                    If rd.IsDBNull(27) Then
                        dura = "0"
                    Else
                        dura = rd.GetValue(27)
                    End If
                    If rd.IsDBNull(28) Then
                        tpanjang = "0"
                    Else
                        tpanjang = rd.GetValue(28)
                    End If
                    If rd.IsDBNull(29) Then
                        tkosong = "0"
                    Else
                        tkosong = rd.GetValue(29)
                    End If
                    If rd.IsDBNull(30) Then
                        restan = "0"
                    Else
                        restan = rd.GetValue(30)
                    End If
                    If rd.IsDBNull(31) Then
                        air = "0"
                    Else
                        air = rd.GetValue(31)
                    End If
                    If rd.IsDBNull(32) Then
                        sampah = "0"
                    Else
                        sampah = rd.GetValue(32)
                    End If
                    If rd.IsDBNull(33) Then
                        pasir = "0"
                    Else
                        pasir = rd.GetValue(33)
                    End If
                    If rd.IsDBNull(34) Then
                        lain = "0"
                    Else
                        lain = rd.GetValue(34)
                    End If
                    If rd.IsDBNull(35) Then
                        cetak = "0"
                    Else
                        cetak = rd.GetValue(35)
                    End If
                    If rd.IsDBNull(36) Then
                        flag = ""
                    Else
                        flag = rd.GetString(36)
                    End If
                    If rd.IsDBNull(37) Then
                        lewatmasak = "0"
                    Else
                        lewatmasak = rd.GetString(37)
                    End If

                    If rd.IsDBNull(38) Then
                        Vehicle_stnk_expdate_ = ""
                    Else
                        Vehicle_stnk_expdate_ = Format(rd.GetDateTime(38), "yyyy-MM-dd") 'vehicle_stnk_expdate (date)
                    End If

                    If rd.IsDBNull(39) Then
                        vehicle_desc_ = ""
                    Else
                        vehicle_desc_ = rd.GetString(39)   'vehicle_desc (text)
                    End If

                    If rd.IsDBNull(40) Then
                        vehicle_tarra_ = 0
                    Else
                        vehicle_tarra_ = rd.GetValue(40)    ' vehicle_tarra  (NUmber)
                    End If

                    If rd.IsDBNull(41) Then
                        tarra_validation_ = ""
                    Else
                        tarra_validation_ = rd.GetString(41)  ' tarra_validation (text)
                    End If

                    If rd.IsDBNull(42) Then
                        vehicle_tarra_expdate_ = ""
                    Else

                        vehicle_tarra_expdate_ = Format(rd.GetDateTime(42), "yyyy-MM-dd")   ' vehicle_tarra_expdate (date)
                    End If

                    If rd.IsDBNull(43) Then
                        cust_vehicle_validation_ = ""
                    Else
                        cust_vehicle_validation_ = rd.GetString(43)  ' cust_vehicle_validation
                    End If

                    If rd.IsDBNull(46) Then
                        wb_client_1 = ""
                    Else
                        wb_client_1 = rd.GetString(46)  ' wb_client_1
                    End If

                    If rd.IsDBNull(47) Then
                        wb_client_2 = ""
                    Else
                        wb_client_2 = rd.GetString(47)  ' wb_client_2
                    End If

                    If rd.IsDBNull(48) Then
                        eatenbyrat = 0
                    Else
                        eatenbyrat = rd.GetValue(48)
                    End If

                    If rd.IsDBNull(49) Then
                        brondolan = 0
                    Else
                        brondolan = rd.GetValue(49)
                    End If
                    If rd.IsDBNull(50) Then
                        no_nego = ""
                    Else
                        no_nego = rd.GetString(50)
                    End If
                    If rd.IsDBNull(51) Then
                        grade_tbs = ""
                    Else
                        grade_tbs = rd.GetString(51)
                    End If

                    'If rd.IsDBNull(52) Then
                    '    trfid = 0
                    'Else
                    '    trfid = rd.GetValue(52)
                    'End If
                    'If rd.IsDBNull(53) Then
                    '    jenis = ""
                    'Else
                    '    jenis = rd.GetString(53)
                    'End If
                    'If rd.IsDBNull(54) Then
                    '    tarif = 0
                    'Else
                    '    tarif = rd.GetValue(54)
                    'End If
                    'If rd.IsDBNull(55) Then
                    '    uom = ""
                    'Else
                    '    uom = rd.GetString(55)
                    'End If
                    'If rd.IsDBNull(56) Then
                    '    total_tarif = 0
                    'Else
                    '    total_tarif = rd.GetValue(56)
                    'End If

                    Dim datein As String = Format(rd.GetDateTime(13), "yyyy-MM-dd")
                    Dim dateout As String = Format(rd.GetDateTime(14), "yyyy-MM-dd")
                    sqlinsert = "insert into wbs_datatbs_tab(wbsid,vehicleno,driver,spbs,transport,partname,customer,estate,divisi,block"
                    sqlinsert = sqlinsert + ",janjang,ktu,remark,datein,dateout,wbin,wbout,timein,timeout,netto,sortase"
                    sqlinsert = sqlinsert + ",entry,siteid,sample,masak,mentah,kecil,dura,tpanjang,tkosong,restan,air,sampah,pasir,lain,cetak,flag,lewatmasak,wb_client_1,wb_client_2,eatenbyrat,brondolan"
                    'MsgBox("masuk8")
                    If Vehicle_stnk_expdate_ <> "" Then
                        sqlinsert = sqlinsert + " ,vehicle_stnk_expdate"
                    End If
                    If vehicle_desc_ <> "" Then
                        sqlinsert = sqlinsert + ",vehicle_desc"
                    End If
                    If vehicle_tarra_ <> 0 Then
                        sqlinsert = sqlinsert + ",vehicle_tarra"
                    End If
                    If tarra_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",tarra_validation"
                    End If
                    If vehicle_tarra_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",vehicle_tarra_expdate"
                    End If
                    If cust_vehicle_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",cust_vehicle_validation"
                    End If
                    sqlinsert = sqlinsert + " ) values ("
                    sqlinsert = sqlinsert + "'" & wbsid & "'"
                    sqlinsert = sqlinsert + ",'" & vehicleno & "'"
                    sqlinsert = sqlinsert + ",'" & driver & "'"
                    sqlinsert = sqlinsert + ",'" & spbs & "'"
                    sqlinsert = sqlinsert + ",'" & transport & "'"
                    sqlinsert = sqlinsert + ",'" & partname & "'"
                    sqlinsert = sqlinsert + ",'" & customer & "'"
                    sqlinsert = sqlinsert + ",'" & estateid & "'"
                    sqlinsert = sqlinsert + ",'" & divisi & "'"
                    sqlinsert = sqlinsert + ",'" & blockid & "'"
                    sqlinsert = sqlinsert + ",'" & janjang & "'"
                    sqlinsert = sqlinsert + ",'" & ktu & "'"
                    sqlinsert = sqlinsert + ",'" & remark & "'"
                    sqlinsert = sqlinsert + ",to_date('" & datein & "','YYYY-MM-DD')"
                    sqlinsert = sqlinsert + ",to_date('" & dateout & "','YYYY-MM-DD')"
                    sqlinsert = sqlinsert + "," & CDbl(wbin) & ""
                    sqlinsert = sqlinsert + "," & CDbl(wbout) & ""
                    sqlinsert = sqlinsert + ",'" & timein & "'"
                    sqlinsert = sqlinsert + ",'" & timeout & "'"
                    sqlinsert = sqlinsert + "," & CDbl(netto) & ""
                    sqlinsert = sqlinsert + ",'" & sortase & "'"
                    sqlinsert = sqlinsert + ",'" & entry & "'"
                    sqlinsert = sqlinsert + ",'" & siteid & "'"
                    sqlinsert = sqlinsert + ",'" & sample & "'"
                    sqlinsert = sqlinsert + ",'" & masak & "'"
                    sqlinsert = sqlinsert + ",'" & mentah & "'"
                    sqlinsert = sqlinsert + ",'" & kecil & "'"
                    sqlinsert = sqlinsert + ",'" & dura & "'"
                    sqlinsert = sqlinsert + ",'" & tpanjang & "'"
                    sqlinsert = sqlinsert + ",'" & tkosong & "'"
                    sqlinsert = sqlinsert + ",'" & restan & "'"
                    sqlinsert = sqlinsert + ",'" & air & "'"
                    sqlinsert = sqlinsert + ",'" & sampah & "'"
                    sqlinsert = sqlinsert + ",'" & pasir & "'"
                    sqlinsert = sqlinsert + ",'" & lain & "'"
                    sqlinsert = sqlinsert + ",'" & cetak & "'"
                    sqlinsert = sqlinsert + ",'" & flag & "'"
                    sqlinsert = sqlinsert + ",'" & lewatmasak & "'"
                    sqlinsert = sqlinsert + ",'" & wb_client_1 & "'"
                    sqlinsert = sqlinsert + ",'" & wb_client_2 & "'"
                    sqlinsert = sqlinsert + "," & CDbl(eatenbyrat) & ""
                    sqlinsert = sqlinsert + "," & CDbl(brondolan) & ""
                    'sqlinsert = sqlinsert + ",'" & jenis & "'"
                    'sqlinsert = sqlinsert + "," & CDbl(tarif) & ""
                    'sqlinsert = sqlinsert + ",'" & uom & "'"
                    'sqlinsert = sqlinsert + "," & CDbl(total_tarif) & ""
                    If Vehicle_stnk_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",to_date('" & Vehicle_stnk_expdate_ & "','YYYY-MM-DD')"
                    End If
                    If vehicle_desc_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & vehicle_desc_ & "'"
                    End If
                    If vehicle_tarra_ <> 0 Then
                        sqlinsert = sqlinsert + "," & vehicle_tarra_
                    End If
                    If tarra_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & tarra_validation_ & "'"
                    End If
                    If vehicle_tarra_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",to_date('" & vehicle_tarra_expdate_ & "','YYYY-MM-DD')"
                    End If
                    If cust_vehicle_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & cust_vehicle_validation_ & " '"
                    End If

                    sqlinsert = sqlinsert + ")"

                    'sqlinsert = sqlinsert + ",to_date('" & rd.GetString(38) & "','YYYY-MM-DD')"
                    'sqlinsert = sqlinsert + ",'" & rd.GetString(39) & "'"
                    'sqlinsert = sqlinsert + "," & rd.GetString(40) & ""
                    'sqlinsert = sqlinsert + ",'" & rd.GetString(41) & "'"
                    'sqlinsert = sqlinsert + ",to_date('" & rd.GetString(42) & "','YYYY-MM-DD'))"
                    'MsgBox("masuk10")

                    cmd2 = New OdbcCommand(sqlinsert, Conn2)
                    cmd2.ExecuteNonQuery()
                    cmd = New OdbcCommand("update wbs_datatbs_tab set flag='F' where wbsid='" & wbsid & "'", Conn)
                    cmd.ExecuteNonQuery()

                    ProgressBar = ProgressBar + 1
                    If ProgressBar >= jml Then
                        ProgressBar = jml
                    End If
                    ToolStripProgressBar1.Value = ProgressBar
                    ToolStripStatusLabel2.Text = CInt((ProgressBar / jml) * 100) & "% data TBS"
                End If

            Loop
            ToolStripProgressBar1.Visible = False
            ToolStripStatusLabel2.Visible = False
        End If
    End Sub
    Sub tbldatatbsmulti()
        'MsgBox("tbldata")
        Dim sqlinsert As String = ""
        Dim wbsid As String
        Dim blockid As String
        Dim driver As String = ""
        Dim spbs As String = ""
        Dim transport As String = ""
        Dim estateid As String = ""
        Dim divisi As String = ""
        Dim ktu As String = ""
        Dim janjang As String = ""
        Dim remark As String = ""
        Dim vehicleno As String = ""
        Dim partname As String = ""
        Dim customer As String = ""
        Dim wbin As Integer = 0
        Dim wbout As Integer = 0
        Dim timein As String = ""
        Dim timeout As String = ""
        Dim netto As Integer = 0
        Dim sortase As String = "0"
        Dim entry As String = ""
        Dim siteid As String = ""
        Dim sample As String = ""
        Dim masak As String = ""

        Dim mentah As String = ""
        Dim kecil As String = ""
        Dim dura As String = ""
        Dim tpanjang As String = ""
        Dim tkosong As String = ""
        Dim restan As String = ""
        Dim air As String = ""
        Dim sampah As String = ""
        Dim pasir As String = ""
        Dim lain As String = ""
        Dim cetak As String = ""
        Dim flag As String = ""
        Dim lewatmasak As String = ""
        Dim brondolan As Integer = 0
        Dim eatenbyrat As Integer = 0
        Dim Vehicle_stnk_expdate_ As String = ""
        Dim vehicle_desc_ As String = ""
        Dim vehicle_tarra_ As Double = 0
        Dim tarra_validation_ As String = ""
        Dim vehicle_tarra_expdate_ As String = ""
        Dim cust_vehicle_validation_ As String = ""
        Dim wb_client_1 As String
        Dim wb_client_2 As String
        'tambahan untuk SIP
        Dim grade_tbs As String = ""
        Dim no_nego As String = ""
        Dim trfid As Integer = 0
        Dim jenis As String = ""
        Dim tarif As Integer = 0
        Dim uom As String = ""
        Dim total_tarif As Integer = 0
        '-----------------------------

        Dim ProgressBar As Integer = 0
        'EDITED ATA
        Dim rd2
        Dim db_selection As String = ""
        Dim jml As Integer = 0
        cmd2 = New OdbcCommand("select wbsid from wbs_datatbs_tab where flag='T' and (wbout<>0  or TypeOfWeighing ='W1' )", Conn)
        rd2 = cmd2.ExecuteReader
        Do While rd2.Read
            If rd2.HasRows Then
                jml = jml + 1
            End If
        Loop
        If jml > 50 Then
            jml = 50
        End If
        'MsgBox("error")
        If jml > 0 Then

            db_selection = db_selection + "wbsid,vehicleno,driver,spbs,transport,partname,customer,"
            db_selection = db_selection + "estate,divisi,block,janjang,ktu,remark,datein,dateout,wbin,wbout,"
            db_selection = db_selection + "timein,timeout,netto,sortase,entry,siteid,sample,masak,"
            db_selection = db_selection + "mentah,kecil,dura,tpanjang,tkosong,restan,air,sampah,pasir,lain,"
            db_selection = db_selection + "cetak,flag,lewatmasak,vehicle_stnk_expdate,vehicle_desc,vehicle_tarra,"
            db_selection = db_selection + "tarra_validation,vehicle_tarra_expdate,cust_vehicle_validation,"
            db_selection = db_selection + "TypeOfWeighing,block_janjang,wb_client_1,wb_client_2,eatenbyrat,brondolan,no_nego,grade_tbs,trfid,jenis,tarif,uom,total_tarif"

            cmd = New OdbcCommand("select " & db_selection & " from wbs_datatbsmulti_tab where flag='T' and (wbout<>0  or TypeOfWeighing ='W1' )", Conn)
            rd = cmd.ExecuteReader

            ToolStripProgressBar1.Visible = True
            ToolStripStatusLabel2.Visible = True
            ToolStripStatusLabel2.Text = "Loading for TBS-MULTI-AFDELING..."
            ToolStripProgressBar1.Minimum = 0
            ToolStripProgressBar1.Maximum = jml
            ToolStripProgressBar1.Value = 0

            ProgressBar = 0
            Do While rd.Read
                If rd.HasRows Then

                    wbsid = rd.GetString(0)


                    If rd.IsDBNull(1) Then
                        vehicleno = ""
                    Else
                        vehicleno = rd.GetString(1)
                    End If
                    If rd.IsDBNull(2) Then
                        driver = ""
                    Else
                        driver = rd.GetString(2)
                    End If
                    'MsgBox("masuk3")
                    If rd.IsDBNull(3) Then
                        spbs = ""
                    Else
                        spbs = rd.GetString(3)
                    End If
                    'MsgBox("masuk4")
                    If rd.IsDBNull(4) Then
                        transport = ""
                    Else
                        transport = rd.GetString(4)
                    End If
                    If rd.IsDBNull(5) Then
                        partname = ""
                    Else
                        partname = rd.GetString(5)
                    End If
                    If rd.IsDBNull(6) Then
                        customer = ""
                    Else
                        customer = rd.GetString(6)
                    End If

                    If rd.IsDBNull(7) Then
                        estateid = ""
                    Else
                        estateid = rd.GetString(7)
                    End If
                    'MsgBox("masuk6")
                    If rd.IsDBNull(8) Then
                        divisi = ""
                    Else
                        divisi = rd.GetString(8)
                    End If
                    If rd.IsDBNull(9) Then
                        blockid = ""
                    Else
                        blockid = rd.GetString(9)
                    End If
                    If rd.IsDBNull(10) Then
                        janjang = ""
                    Else
                        janjang = rd.GetString(10)
                    End If
                    If rd.IsDBNull(11) Then
                        ktu = ""
                    Else
                        ktu = rd.GetString(11)
                    End If
                    'MsgBox("masuk8")
                    If rd.IsDBNull(12) Then
                        remark = ""
                    Else
                        remark = rd.GetString(12)
                    End If
                    If rd.IsDBNull(15) Then
                        wbin = 0
                    Else
                        wbin = rd.GetValue(15)
                    End If
                    If rd.IsDBNull(16) Then
                        wbout = 0
                    Else
                        wbout = rd.GetValue(16)
                    End If
                    If rd.IsDBNull(17) Then
                        timein = ""
                    Else
                        timein = rd.GetString(17)
                    End If
                    If rd.IsDBNull(18) Then
                        timeout = ""
                    Else
                        timeout = rd.GetString(18)
                    End If
                    If rd.IsDBNull(19) Then
                        netto = 0
                    Else
                        netto = rd.GetValue(19)
                    End If
                    If rd.IsDBNull(20) Then
                        sortase = "0"
                    Else
                        sortase = rd.GetString(20)
                    End If
                    If rd.IsDBNull(21) Then
                        entry = ""
                    Else
                        entry = rd.GetString(21)
                    End If
                    If rd.IsDBNull(22) Then
                        siteid = ""
                    Else
                        siteid = rd.GetString(22)
                    End If
                    If rd.IsDBNull(23) Then
                        sample = "0"
                    Else
                        sample = rd.GetString(23)
                    End If
                    If rd.IsDBNull(24) Then
                        masak = "0"
                    Else
                        masak = rd.GetValue(24)
                    End If
                    If rd.IsDBNull(25) Then
                        mentah = "0"
                    Else
                        mentah = rd.GetValue(25)
                    End If
                    If rd.IsDBNull(26) Then
                        kecil = "0"
                    Else
                        kecil = rd.GetValue(26)
                    End If
                    If rd.IsDBNull(27) Then
                        dura = "0"
                    Else
                        dura = rd.GetValue(27)
                    End If
                    If rd.IsDBNull(28) Then
                        tpanjang = "0"
                    Else
                        tpanjang = rd.GetValue(28)
                    End If
                    If rd.IsDBNull(29) Then
                        tkosong = "0"
                    Else
                        tkosong = rd.GetValue(29)
                    End If
                    If rd.IsDBNull(30) Then
                        restan = "0"
                    Else
                        restan = rd.GetValue(30)
                    End If
                    If rd.IsDBNull(31) Then
                        air = "0"
                    Else
                        air = rd.GetValue(31)
                    End If
                    If rd.IsDBNull(32) Then
                        sampah = "0"
                    Else
                        sampah = rd.GetValue(32)
                    End If
                    If rd.IsDBNull(33) Then
                        pasir = "0"
                    Else
                        pasir = rd.GetValue(33)
                    End If
                    If rd.IsDBNull(34) Then
                        lain = "0"
                    Else
                        lain = rd.GetValue(34)
                    End If
                    If rd.IsDBNull(35) Then
                        cetak = "0"
                    Else
                        cetak = rd.GetValue(35)
                    End If
                    If rd.IsDBNull(36) Then
                        flag = ""
                    Else
                        flag = rd.GetString(36)
                    End If
                    If rd.IsDBNull(37) Then
                        lewatmasak = "0"
                    Else
                        lewatmasak = rd.GetString(37)
                    End If

                    If rd.IsDBNull(38) Then
                        Vehicle_stnk_expdate_ = ""
                    Else
                        Vehicle_stnk_expdate_ = Format(rd.GetDateTime(38), "yyyy-MM-dd") 'vehicle_stnk_expdate (date)
                    End If

                    If rd.IsDBNull(39) Then
                        vehicle_desc_ = ""
                    Else
                        vehicle_desc_ = rd.GetString(39)   'vehicle_desc (text)
                    End If

                    If rd.IsDBNull(40) Then
                        vehicle_tarra_ = 0
                    Else
                        vehicle_tarra_ = rd.GetValue(40)    ' vehicle_tarra  (NUmber)
                    End If

                    If rd.IsDBNull(41) Then
                        tarra_validation_ = ""
                    Else
                        tarra_validation_ = rd.GetString(41)  ' tarra_validation (text)
                    End If

                    If rd.IsDBNull(42) Then
                        vehicle_tarra_expdate_ = ""
                    Else

                        vehicle_tarra_expdate_ = Format(rd.GetDateTime(42), "yyyy-MM-dd")   ' vehicle_tarra_expdate (date)
                    End If

                    If rd.IsDBNull(43) Then
                        cust_vehicle_validation_ = ""
                    Else
                        cust_vehicle_validation_ = rd.GetString(43)  ' cust_vehicle_validation
                    End If

                    If rd.IsDBNull(46) Then
                        wb_client_1 = ""
                    Else
                        wb_client_1 = rd.GetString(46)  ' wb_client_1
                    End If

                    If rd.IsDBNull(47) Then
                        wb_client_2 = ""
                    Else
                        wb_client_2 = rd.GetString(47)  ' wb_client_2
                    End If

                    If rd.IsDBNull(48) Then
                        eatenbyrat = 0
                    Else
                        eatenbyrat = rd.GetValue(48)
                    End If

                    If rd.IsDBNull(49) Then
                        brondolan = 0
                    Else
                        brondolan = rd.GetValue(49)
                    End If

                    If rd.IsDBNull(50) Then
                        no_nego = ""
                    Else
                        no_nego = rd.GetString(50)
                    End If
                    If rd.IsDBNull(51) Then
                        grade_tbs = ""
                    Else
                        grade_tbs = rd.GetString(51)
                    End If
                    If rd.IsDBNull(52) Then
                        trfid = 0
                    Else
                        trfid = rd.GetValue(52)
                    End If
                    If rd.IsDBNull(53) Then
                        jenis = ""
                    Else
                        jenis = rd.GetString(53)
                    End If
                    If rd.IsDBNull(54) Then
                        tarif = 0
                    Else
                        tarif = rd.GetValue(54)
                    End If
                    If rd.IsDBNull(55) Then
                        uom = ""
                    Else
                        uom = rd.GetString(55)
                    End If
                    If rd.IsDBNull(56) Then
                        total_tarif = 0
                    Else
                        total_tarif = rd.GetValue(56)
                    End If

                    Dim datein As String = Format(rd.GetDateTime(13), "yyyy-MM-dd")
                    Dim dateout As String = Format(rd.GetDateTime(14), "yyyy-MM-dd")
                    sqlinsert = "insert into wbs_datatbs_tab(wbsid,vehicleno,driver,spbs,transport,partname,customer,estate,divisi,block"
                    sqlinsert = sqlinsert + ",janjang,ktu,remark,datein,dateout,wbin,wbout,timein,timeout,netto,sortase"
                    sqlinsert = sqlinsert + ",entry,siteid,sample,masak,mentah,kecil,dura,tpanjang,tkosong,restan,air,sampah,pasir,lain,cetak,flag,lewatmasak,wb_client_1,wb_client_2,eatenbyrat,brondolan,vhtype,tarif,uom_tarif,total_tarif"
                    'MsgBox("masuk8")
                    If Vehicle_stnk_expdate_ <> "" Then
                        sqlinsert = sqlinsert + " ,vehicle_stnk_expdate"
                    End If
                    If vehicle_desc_ <> "" Then
                        sqlinsert = sqlinsert + ",vehicle_desc"
                    End If
                    If vehicle_tarra_ <> 0 Then
                        sqlinsert = sqlinsert + ",vehicle_tarra"
                    End If
                    If tarra_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",tarra_validation"
                    End If
                    If vehicle_tarra_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",vehicle_tarra_expdate"
                    End If
                    If cust_vehicle_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",cust_vehicle_validation"
                    End If
                    sqlinsert = sqlinsert + " ) values ("
                    sqlinsert = sqlinsert + "'" & wbsid & "'"
                    sqlinsert = sqlinsert + ",'" & vehicleno & "'"
                    sqlinsert = sqlinsert + ",'" & driver & "'"
                    sqlinsert = sqlinsert + ",'" & spbs & "'"
                    sqlinsert = sqlinsert + ",'" & transport & "'"
                    sqlinsert = sqlinsert + ",'" & partname & "'"
                    sqlinsert = sqlinsert + ",'" & customer & "'"
                    sqlinsert = sqlinsert + ",'" & estateid & "'"
                    sqlinsert = sqlinsert + ",'" & divisi & "'"
                    sqlinsert = sqlinsert + ",'" & blockid & "'"
                    sqlinsert = sqlinsert + ",'" & janjang & "'"
                    sqlinsert = sqlinsert + ",'" & ktu & "'"
                    sqlinsert = sqlinsert + ",'" & remark & "'"
                    sqlinsert = sqlinsert + ",to_date('" & datein & "','YYYY-MM-DD')"
                    sqlinsert = sqlinsert + ",to_date('" & dateout & "','YYYY-MM-DD')"
                    sqlinsert = sqlinsert + "," & CDbl(wbin) & ""
                    sqlinsert = sqlinsert + "," & CDbl(wbout) & ""
                    sqlinsert = sqlinsert + ",'" & timein & "'"
                    sqlinsert = sqlinsert + ",'" & timeout & "'"
                    sqlinsert = sqlinsert + "," & CDbl(netto) & ""
                    sqlinsert = sqlinsert + ",'" & sortase & "'"
                    sqlinsert = sqlinsert + ",'" & entry & "'"
                    sqlinsert = sqlinsert + ",'" & siteid & "'"
                    sqlinsert = sqlinsert + ",'" & sample & "'"
                    sqlinsert = sqlinsert + ",'" & masak & "'"
                    sqlinsert = sqlinsert + ",'" & mentah & "'"
                    sqlinsert = sqlinsert + ",'" & kecil & "'"
                    sqlinsert = sqlinsert + ",'" & dura & "'"
                    sqlinsert = sqlinsert + ",'" & tpanjang & "'"
                    sqlinsert = sqlinsert + ",'" & tkosong & "'"
                    sqlinsert = sqlinsert + ",'" & restan & "'"
                    sqlinsert = sqlinsert + ",'" & air & "'"
                    sqlinsert = sqlinsert + ",'" & sampah & "'"
                    sqlinsert = sqlinsert + ",'" & pasir & "'"
                    sqlinsert = sqlinsert + ",'" & lain & "'"
                    sqlinsert = sqlinsert + ",'" & cetak & "'"
                    sqlinsert = sqlinsert + ",'" & flag & "'"
                    sqlinsert = sqlinsert + ",'" & lewatmasak & "'"
                    sqlinsert = sqlinsert + ",'" & wb_client_1 & "'"
                    sqlinsert = sqlinsert + ",'" & wb_client_2 & "'"
                    sqlinsert = sqlinsert + "," & CDbl(eatenbyrat) & ""
                    sqlinsert = sqlinsert + "," & CDbl(brondolan) & ""
                    sqlinsert = sqlinsert + ",'" & jenis & "'"
                    sqlinsert = sqlinsert + "," & CDbl(tarif) & ""
                    sqlinsert = sqlinsert + ",'" & uom & "'"
                    sqlinsert = sqlinsert + "," & CDbl(total_tarif) & ""
                    If Vehicle_stnk_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",to_date('" & Vehicle_stnk_expdate_ & "','YYYY-MM-DD')"
                    End If
                    If vehicle_desc_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & vehicle_desc_ & "'"
                    End If
                    If vehicle_tarra_ <> 0 Then
                        sqlinsert = sqlinsert + "," & vehicle_tarra_
                    End If
                    If tarra_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & tarra_validation_ & "'"
                    End If
                    If vehicle_tarra_expdate_ <> "" Then
                        sqlinsert = sqlinsert + ",to_date('" & vehicle_tarra_expdate_ & "','YYYY-MM-DD')"
                    End If
                    If cust_vehicle_validation_ <> "" Then
                        sqlinsert = sqlinsert + ",'" & cust_vehicle_validation_ & " '"
                    End If

                    sqlinsert = sqlinsert + ")"

                    'sqlinsert = sqlinsert + ",to_date('" & rd.GetString(38) & "','YYYY-MM-DD')"
                    'sqlinsert = sqlinsert + ",'" & rd.GetString(39) & "'"
                    'sqlinsert = sqlinsert + "," & rd.GetString(40) & ""
                    'sqlinsert = sqlinsert + ",'" & rd.GetString(41) & "'"
                    'sqlinsert = sqlinsert + ",to_date('" & rd.GetString(42) & "','YYYY-MM-DD'))"
                    'MsgBox("masuk10")

                    cmd2 = New OdbcCommand(sqlinsert, Conn2)
                    cmd2.ExecuteNonQuery()
                    cmd = New OdbcCommand("update wbs_datatbs_tab set flag='F' where wbsid='" & wbsid & "'", Conn)
                    cmd.ExecuteNonQuery()

                    ProgressBar = ProgressBar + 1
                    If ProgressBar >= jml Then
                        ProgressBar = jml
                    End If
                    ToolStripProgressBar1.Value = ProgressBar
                    ToolStripStatusLabel2.Text = CInt((ProgressBar / jml) * 100) & "% data TBS"
                End If

            Loop
            ToolStripProgressBar1.Visible = False
            ToolStripStatusLabel2.Visible = False
        End If
    End Sub



    Sub productreceive()
        Dim sqlinsert As String = ""
        Dim detailString As String = ""
        Dim wbsid As String
        Dim InventoryPart As String = ""
        Dim MillSource As String = ""
        Dim TiketNoSource As String = ""
        Dim DoNumber As String = ""
        Dim StorageSource As String = ""
        Dim wbin As Double = 0
        Dim wbout As Double = 0
        Dim netto As Double = 0
        Dim NettoSource As Double = 0
        Dim StorageDestination As String = ""
        Dim vehicleno As String = ""
        Dim remark As String = ""
        Dim timein As String = ""
        Dim timeout As String = ""
        Dim ffa As String = ""
        Dim dirt As String = ""
        Dim moisture As String = ""
        Dim transporter As String = ""
        Dim drivername As String = ""
        Dim flag As String = ""
        Dim cetak As String = ""
        Dim wb_client_1 As String
        Dim wb_client_2 As String
        Dim fcba As String = ""
        Dim fcentry As String = ""
        Dim TypeOfWeighing As String = ""
        Dim TransportWbType As String = ""
        Dim SealNo As String = ""
        Dim QtySealNo As String = ""
        Dim ProgressBar As Integer = 0

        Dim tempDetail_wbsid_ As String = ""
        Dim tempTiketNoSource_ As String = ""
        Dim tempResourcefcba_ As String = ""
        Dim tempFcbaDestination_ As String = ""
        Dim tempStorageSource_ As String = ""
        Dim tempStorageDestination_ As String = ""
        Dim tempNettoSource_ As Double = 0
        Dim tempNetto_ As Double = 0
        Dim tempDifference_ As Double = 0
        Dim tempRemark_ As String = ""
        Dim tempFlag_ As String = ""
        Dim Sqlupdate As String = ""


        Dim rd2
        Dim db_selection As String = ""
        Dim jml As Integer = 0
        cmd2 = New OdbcCommand("select wbsid from wbs_product_receive_tab where flag='T' and (wbout<>0)", Conn)
        rd2 = cmd2.ExecuteReader
        Do While rd2.Read
            If rd2.HasRows Then
                jml = jml + 1
            End If
        Loop
        If jml > 50 Then
            jml = 50
        End If
        'MsgBox("error")
        If jml > 0 Then

            db_selection = db_selection + "wbsid,InventoryPart,MillSource,TiketNoSource,DoNumber,StorageSource,StorageDestination,"
            db_selection = db_selection + "wbin,wbout,netto,NettoSource,datein,dateout,remark,timein,timeout,ffa,"
            db_selection = db_selection + "dirt,moisture,transporter,drivername,vehicleno,flag,wb_client_1,wb_client_2,"
            db_selection = db_selection + "fcba,fcentry,TypeOfWeighing,TransportWbType,SealNo,QtySealno,Cetak"

            cmd = New OdbcCommand("select " & db_selection & " from wbs_product_receive_tab where flag='T' and (wbout<>0)", Conn)
            rd = cmd.ExecuteReader

            ToolStripProgressBar1.Visible = True
            ToolStripStatusLabel2.Visible = True
            ToolStripStatusLabel2.Text = "Loading for Receive Product..."
            ToolStripProgressBar1.Minimum = 0
            ToolStripProgressBar1.Maximum = jml
            ToolStripProgressBar1.Value = 0

            ProgressBar = 0
            Do While rd.Read
                If rd.HasRows Then

                    wbsid = rd.GetString(0)
                    If rd.IsDBNull(1) Then
                        InventoryPart = ""
                    Else
                        InventoryPart = rd.GetString(1)
                    End If
                    If rd.IsDBNull(2) Then
                        MillSource = ""
                    Else
                        MillSource = rd.GetString(2)
                    End If
                    'MsgBox("masuk3")
                    If rd.IsDBNull(3) Then
                        TiketNoSource = ""
                    Else
                        TiketNoSource = rd.GetString(3)
                    End If
                    'MsgBox("masuk4")
                    If rd.IsDBNull(4) Then
                        DoNumber = ""
                    Else
                        DoNumber = rd.GetString(4)
                    End If
                    If rd.IsDBNull(5) Then
                        StorageSource = ""
                    Else
                        StorageSource = rd.GetString(5)
                    End If
                    If rd.IsDBNull(6) Then
                        StorageDestination = ""
                    Else
                        StorageDestination = rd.GetString(6)
                    End If

                    If rd.IsDBNull(7) Then
                        wbin = 0
                    Else
                        wbin = rd.GetValue(7)
                    End If
                    'MsgBox("masuk6")
                    If rd.IsDBNull(8) Then
                        wbout = 0
                    Else
                        wbout = rd.GetValue(8)
                    End If
                    If rd.IsDBNull(9) Then
                        netto = 0
                    Else
                        netto = rd.GetValue(9)
                    End If
                    If rd.IsDBNull(10) Then
                        NettoSource = 0
                    Else
                        NettoSource = rd.GetValue(10)
                    End If

                    If rd.IsDBNull(13) Then
                        remark = ""
                    Else
                        remark = rd.GetString(13)
                    End If

                    If rd.IsDBNull(14) Then
                        timein = ""
                    Else
                        timein = rd.GetString(14)
                    End If

                    If rd.IsDBNull(15) Then
                        timeout = ""
                    Else
                        timeout = rd.GetString(15)
                    End If

                    If rd.IsDBNull(16) Then
                        ffa = ""
                    Else
                        ffa = rd.GetString(16)
                    End If

                    If rd.IsDBNull(17) Then
                        dirt = ""
                    Else
                        dirt = rd.GetString(17)
                    End If

                    If rd.IsDBNull(18) Then
                        moisture = ""
                    Else
                        moisture = rd.GetString(18)
                    End If

                    If rd.IsDBNull(19) Then
                        transporter = ""
                    Else
                        transporter = rd.GetString(19)
                    End If


                    If rd.IsDBNull(20) Then
                        drivername = ""
                    Else
                        drivername = rd.GetString(20)
                    End If

                    If rd.IsDBNull(21) Then
                        vehicleno = ""
                    Else
                        vehicleno = rd.GetString(21)
                    End If
                    If rd.IsDBNull(22) Then
                        flag = ""
                    Else
                        flag = rd.GetString(22)
                    End If

                    If rd.IsDBNull(23) Then
                        wb_client_1 = ""
                    Else
                        wb_client_1 = rd.GetString(23)
                    End If

                    If rd.IsDBNull(24) Then
                        wb_client_2 = ""
                    Else
                        wb_client_2 = rd.GetString(24)
                    End If

                    If rd.IsDBNull(25) Then
                        fcba = ""
                    Else
                        fcba = rd.GetString(25)
                    End If
                    If rd.IsDBNull(26) Then
                        fcentry = ""
                    Else
                        fcentry = rd.GetString(26)
                    End If
                    If rd.IsDBNull(27) Then
                        TypeOfWeighing = ""
                    Else
                        TypeOfWeighing = rd.GetString(27)
                    End If
                    If rd.IsDBNull(28) Then
                        TransportWbType = ""
                    Else
                        TransportWbType = rd.GetString(28)
                    End If
                    If rd.IsDBNull(29) Then
                        SealNo = ""
                    Else
                        SealNo = rd.GetString(29)
                    End If
                    If rd.IsDBNull(30) Then
                        QtySealNo = ""
                    Else
                        QtySealNo = rd.GetString(30)
                    End If
                    If rd.IsDBNull(31) Then
                        cetak = ""
                    Else
                        cetak = rd.GetString(31)
                    End If
                    Dim datein As String = Format(rd.GetDateTime(11), "dd-MM-yyyy")
                    Dim dateout As String = Format(rd.GetDateTime(12), "dd-MM-yyyy")

                    sqlinsert = "insert into transportwbticket(ticketno,ticketnosource,businessunit,transportwbtype,vehicleno,driver,inventorypart,weighbridgein,datein"
                    sqlinsert = sqlinsert + ",timein,weightin,weighbridgeout,dateout,timeout,weightout,netto,transporter,sealno,ffa,dirt,moisture,remarks,flag,factory_origin"
                    sqlinsert = sqlinsert + " ) values ("
                    sqlinsert = sqlinsert + "'" & wbsid & "'"
                    sqlinsert = sqlinsert + ",'" & TiketNoSource & "'"
                    sqlinsert = sqlinsert + ",'" & fcba & "'"
                    sqlinsert = sqlinsert + ",'" & TransportWbType & "'"
                    sqlinsert = sqlinsert + ",'" & vehicleno & "'"
                    sqlinsert = sqlinsert + ",'" & drivername & "'"
                    sqlinsert = sqlinsert + ",'" & InventoryPart & "'"
                    sqlinsert = sqlinsert + ",'" & wb_client_1 & "'"
                    sqlinsert = sqlinsert + ",to_date('" & datein & "','DD-MM-YYYY')"
                    sqlinsert = sqlinsert + ",'" & timein & "'"
                    sqlinsert = sqlinsert + "," & CDbl(wbin) & ""
                    sqlinsert = sqlinsert + ",'" & wb_client_2 & "'"
                    sqlinsert = sqlinsert + ",to_date('" & dateout & "','DD-MM-YYYY')"
                    sqlinsert = sqlinsert + ",'" & timeout & "'"
                    sqlinsert = sqlinsert + "," & CDbl(wbout) & ""
                    sqlinsert = sqlinsert + "," & CDbl(netto) & ""
                    sqlinsert = sqlinsert + ",'" & transporter & "'"
                    sqlinsert = sqlinsert + ",'" & SealNo & "'"
                    sqlinsert = sqlinsert + ",'" & ffa & "'"
                    sqlinsert = sqlinsert + ",'" & dirt & "'"
                    sqlinsert = sqlinsert + ",'" & moisture & "'"
                    sqlinsert = sqlinsert + ",'" & remark & "'"
                    sqlinsert = sqlinsert + ",'" & flag & "'"
                    sqlinsert = sqlinsert + ",'" & MillSource & "')"

                    'MsgBox("masuk10")

                    cmd2 = New OdbcCommand(sqlinsert, Conn2)
                    cmd2.ExecuteNonQuery()
                    cmd = New OdbcCommand("update wbs_product_receive_tab set flag='F' where wbsid='" & wbsid & "'", Conn)
                    cmd.ExecuteNonQuery()

                    'Start to Insert Detail Production receive, by Jhaya

                    detailString = "select wbsid, TiketNoSource, Resourcefcba,FcbaDestination, StorageSource,StorageDestination, NettoSource,netto,Difference,remark,flag  from wbs_product_receivedetail_tab"
                    detailString = detailString + " where flag='T' and wbsid = '" & wbsid & "'"

                    cmd = New OdbcCommand(detailString, Conn)
                    rd = cmd.ExecuteReader


                    Do While rd.Read
                        If rd.HasRows Then
                            If rd.IsDBNull(0) Then
                                tempDetail_wbsid_ = ""
                            Else
                                tempDetail_wbsid_ = rd.GetString(0)
                            End If

                            If rd.IsDBNull(1) Then
                                tempTiketNoSource_ = ""
                            Else
                                tempTiketNoSource_ = rd.GetString(1)
                            End If

                            If rd.IsDBNull(2) Then
                                tempResourcefcba_ = ""
                            Else
                                tempResourcefcba_ = rd.GetString(2)
                            End If
                            If rd.IsDBNull(3) Then
                                tempFcbaDestination_ = ""
                            Else
                                tempFcbaDestination_ = rd.GetString(3)
                            End If
                            If rd.IsDBNull(4) Then
                                tempStorageSource_ = ""
                            Else
                                tempStorageSource_ = rd.GetString(4)
                            End If
                            If rd.IsDBNull(5) Then
                                tempStorageDestination_ = ""
                            Else
                                tempStorageDestination_ = rd.GetString(5)
                            End If

                            If rd.IsDBNull(6) Then
                                tempNettoSource_ = 0
                            Else
                                tempNettoSource_ = CDbl(rd.GetValue(6))
                            End If

                            If rd.IsDBNull(7) Then
                                tempNetto_ = 0
                            Else
                                tempNetto_ = CDbl(rd.GetValue(7))
                            End If

                            If rd.IsDBNull(8) Then
                                tempDifference_ = 0
                            Else
                                tempDifference_ = CDbl(rd.GetValue(8))
                            End If
                            If rd.IsDBNull(9) Then
                                tempRemark_ = ""
                            Else
                                tempRemark_ = rd.GetString(9)
                            End If
                            If rd.IsDBNull(10) Then
                                tempFlag_ = ""
                            Else
                                tempFlag_ = rd.GetString(10)
                            End If

                            sqlinsert = "Insert into transportwbticketdet ("
                            sqlinsert = sqlinsert + "transportwbticket, TicketNoSource, businessunitfrom,businessunitto, inventorylocationfrom,inventorylocationto,quantityfrom,quantityto,Difference,remarks,flag ) values ("
                            sqlinsert = sqlinsert + "'" & tempDetail_wbsid_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempTiketNoSource_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempResourcefcba_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempFcbaDestination_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempStorageSource_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempStorageDestination_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempNettoSource_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempNetto_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempDifference_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempRemark_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempFlag_ & "')"

                            cmd2 = New OdbcCommand(sqlinsert, Conn2)
                            cmd2.ExecuteNonQuery()
                            ' MsgBox(sqlinsert)

                            Sqlupdate = "update wbs_product_receivedetail_tab set flag='F' where wbsid='" & tempDetail_wbsid_ & "'"
                            Sqlupdate = Sqlupdate + " and Resourcefcba = '" & tempResourcefcba_ & "'"


                            cmd = New OdbcCommand(Sqlupdate, Conn)
                            cmd.ExecuteNonQuery()
                        End If
                    Loop
                    ProgressBar = ProgressBar + 1
                    If ProgressBar >= jml Then
                        ProgressBar = jml
                    End If
                    ToolStripProgressBar1.Value = ProgressBar
                    ToolStripStatusLabel2.Text = CInt((ProgressBar / jml) * 100) & "% data Production Receive"
                End If
            Loop
            ToolStripProgressBar1.Visible = False
            ToolStripStatusLabel2.Visible = False
        End If
    End Sub

    Sub producttransfer()
        Dim sqlinsert As String = ""
        Dim detailString As String = ""
        Dim wbsid As String
        Dim InventoryPart As String = ""
        Dim MillSource As String = ""
        Dim TiketNoSource As String = ""
        Dim DoNumber As String = ""
        Dim StorageSource As String = ""
        Dim wbin As Double = 0
        Dim wbout As Double = 0
        Dim netto As Double = 0
        Dim NettoSource As Double = 0
        Dim StorageDestination As String = ""
        Dim vehicleno As String = ""
        Dim remark As String = ""
        Dim timein As String = ""
        Dim timeout As String = ""
        Dim ffa As String = ""
        Dim dirt As String = ""
        Dim moisture As String = ""
        Dim transporter As String = ""
        Dim drivername As String = ""
        Dim flag As String = ""
        Dim cetak As String = ""
        Dim wb_client_1 As String
        Dim wb_client_2 As String
        Dim fcba As String = ""
        Dim fcentry As String = ""
        Dim TypeOfWeighing As String = ""
        Dim TransportWbType As String = ""
        Dim SealNo As String = ""
        Dim QtySealNo As String = ""
        Dim ProgressBar As Integer = 0

        Dim tempDetail_wbsid_ As String = ""
        Dim tempTiketNoSource_ As String = ""
        Dim tempResourcefcba_ As String = ""
        Dim tempFcbaDestination_ As String = ""
        Dim tempStorageSource_ As String = ""
        Dim tempStorageDestination_ As String = ""
        Dim tempNettoSource_ As Double = 0
        Dim tempNetto_ As Double = 0
        Dim tempDifference_ As Double = 0
        Dim tempRemark_ As String = ""
        Dim tempFlag_ As String = ""
        Dim Sqlupdate As String = ""


        Dim rd2
        Dim db_selection As String = ""
        Dim jml As Integer = 0
        cmd2 = New OdbcCommand("select wbsid from wbs_product_transfer_tab where flag='T' and (wbout<>0)", Conn)
        rd2 = cmd2.ExecuteReader
        Do While rd2.Read
            If rd2.HasRows Then
                jml = jml + 1
            End If
        Loop
        If jml > 50 Then
            jml = 50
        End If
        'MsgBox("error")
        If jml > 0 Then

            db_selection = db_selection + "wbsid,InventoryPart,MillSource,TiketNoSource,DoNumber,StorageSource,StorageDestination,"
            db_selection = db_selection + "wbin,wbout,netto,NettoSource,datein,dateout,remark,timein,timeout,ffa,"
            db_selection = db_selection + "dirt,moisture,transporter,drivername,vehicleno,flag,wb_client_1,wb_client_2,"
            db_selection = db_selection + "fcba,fcentry,TypeOfWeighing,TransportWbType,SealNo,QtySealno,Cetak"

            cmd = New OdbcCommand("select " & db_selection & " from wbs_product_transfer_tab where flag='T' and (wbout<>0)", Conn)
            rd = cmd.ExecuteReader

            ToolStripProgressBar1.Visible = True
            ToolStripStatusLabel2.Visible = True
            ToolStripStatusLabel2.Text = "Loading for Transfer Product..."
            ToolStripProgressBar1.Minimum = 0
            ToolStripProgressBar1.Maximum = jml
            ToolStripProgressBar1.Value = 0

            ProgressBar = 0
            Do While rd.Read
                If rd.HasRows Then

                    wbsid = rd.GetString(0)
                    If rd.IsDBNull(1) Then
                        InventoryPart = ""
                    Else
                        InventoryPart = rd.GetString(1)
                    End If
                    If rd.IsDBNull(2) Then
                        MillSource = ""
                    Else
                        MillSource = rd.GetString(2)
                    End If
                    'MsgBox("masuk3")
                    If rd.IsDBNull(3) Then
                        TiketNoSource = ""
                    Else
                        TiketNoSource = rd.GetString(3)
                    End If
                    'MsgBox("masuk4")
                    If rd.IsDBNull(4) Then
                        DoNumber = ""
                    Else
                        DoNumber = rd.GetString(4)
                    End If
                    If rd.IsDBNull(5) Then
                        StorageSource = ""
                    Else
                        StorageSource = rd.GetString(5)
                    End If
                    If rd.IsDBNull(6) Then
                        StorageDestination = ""
                    Else
                        StorageDestination = rd.GetString(6)
                    End If

                    If rd.IsDBNull(7) Then
                        wbin = 0
                    Else
                        wbin = rd.GetValue(7)
                    End If
                    'MsgBox("masuk6")
                    If rd.IsDBNull(8) Then
                        wbout = 0
                    Else
                        wbout = rd.GetValue(8)
                    End If
                    If rd.IsDBNull(9) Then
                        netto = 0
                    Else
                        netto = rd.GetValue(9)
                    End If
                    If rd.IsDBNull(10) Then
                        NettoSource = 0
                    Else
                        NettoSource = rd.GetValue(10)
                    End If

                    If rd.IsDBNull(13) Then
                        remark = ""
                    Else
                        remark = rd.GetString(13)
                    End If

                    If rd.IsDBNull(14) Then
                        timein = ""
                    Else
                        timein = rd.GetString(14)
                    End If

                    If rd.IsDBNull(15) Then
                        timeout = ""
                    Else
                        timeout = rd.GetString(15)
                    End If

                    If rd.IsDBNull(16) Then
                        ffa = ""
                    Else
                        ffa = rd.GetString(16)
                    End If

                    If rd.IsDBNull(17) Then
                        dirt = ""
                    Else
                        dirt = rd.GetString(17)
                    End If

                    If rd.IsDBNull(18) Then
                        moisture = ""
                    Else
                        moisture = rd.GetString(18)
                    End If

                    If rd.IsDBNull(19) Then
                        transporter = ""
                    Else
                        transporter = rd.GetString(19)
                    End If


                    If rd.IsDBNull(20) Then
                        drivername = ""
                    Else
                        drivername = rd.GetString(20)
                    End If

                    If rd.IsDBNull(21) Then
                        vehicleno = ""
                    Else
                        vehicleno = rd.GetString(21)
                    End If
                    If rd.IsDBNull(22) Then
                        flag = ""
                    Else
                        flag = rd.GetString(22)
                    End If

                    If rd.IsDBNull(23) Then
                        wb_client_1 = ""
                    Else
                        wb_client_1 = rd.GetString(23)
                    End If

                    If rd.IsDBNull(24) Then
                        wb_client_2 = ""
                    Else
                        wb_client_2 = rd.GetString(24)
                    End If

                    If rd.IsDBNull(25) Then
                        fcba = ""
                    Else
                        fcba = rd.GetString(25)
                    End If
                    If rd.IsDBNull(26) Then
                        fcentry = ""
                    Else
                        fcentry = rd.GetString(26)
                    End If
                    If rd.IsDBNull(27) Then
                        TypeOfWeighing = ""
                    Else
                        TypeOfWeighing = rd.GetString(27)
                    End If
                    If rd.IsDBNull(28) Then
                        TransportWbType = ""
                    Else
                        TransportWbType = rd.GetString(28)
                    End If
                    If rd.IsDBNull(29) Then
                        SealNo = ""
                    Else
                        SealNo = rd.GetString(29)
                    End If
                    If rd.IsDBNull(30) Then
                        QtySealNo = ""
                    Else
                        QtySealNo = rd.GetString(30)
                    End If
                    If rd.IsDBNull(31) Then
                        cetak = ""
                    Else
                        cetak = rd.GetString(31)
                    End If
                    Dim datein As String = Format(rd.GetDateTime(11), "dd-MM-yyyy")
                    Dim dateout As String = Format(rd.GetDateTime(12), "dd-MM-yyyy")

                    sqlinsert = "insert into transportwbticket(ticketno,businessunit,transportwbtype,vehicleno,driver,inventorypart,weighbridgein,datein"
                    sqlinsert = sqlinsert + ",timein,weightin,weighbridgeout,dateout,timeout,weightout,netto,transporter,sealno,ffa,dirt,moisture,remarks,flag"
                    sqlinsert = sqlinsert + " ) values ("
                    sqlinsert = sqlinsert + "'" & wbsid & "'"
                    'sqlinsert = sqlinsert + ",'" & TiketNoSource & "'"
                    sqlinsert = sqlinsert + ",'" & fcba & "'"
                    sqlinsert = sqlinsert + ",'" & TransportWbType & "'"
                    sqlinsert = sqlinsert + ",'" & vehicleno & "'"
                    sqlinsert = sqlinsert + ",'" & drivername & "'"
                    sqlinsert = sqlinsert + ",'" & InventoryPart & "'"
                    sqlinsert = sqlinsert + ",'" & wb_client_1 & "'"
                    sqlinsert = sqlinsert + ",to_date('" & datein & "','DD-MM-YYYY')"
                    sqlinsert = sqlinsert + ",'" & timein & "'"
                    sqlinsert = sqlinsert + "," & CDbl(wbin) & ""
                    sqlinsert = sqlinsert + ",'" & wb_client_2 & "'"
                    sqlinsert = sqlinsert + ",to_date('" & dateout & "','DD-MM-YYYY')"
                    sqlinsert = sqlinsert + ",'" & timeout & "'"
                    sqlinsert = sqlinsert + "," & CDbl(wbout) & ""
                    sqlinsert = sqlinsert + "," & CDbl(netto) & ""
                    sqlinsert = sqlinsert + ",'" & transporter & "'"
                    sqlinsert = sqlinsert + ",'" & SealNo & "'"
                    sqlinsert = sqlinsert + ",'" & ffa & "'"
                    sqlinsert = sqlinsert + ",'" & dirt & "'"
                    sqlinsert = sqlinsert + ",'" & moisture & "'"
                    sqlinsert = sqlinsert + ",'" & remark & "'"
                    sqlinsert = sqlinsert + ",'" & flag & "')"

                    'MsgBox("masuk10")

                    cmd2 = New OdbcCommand(sqlinsert, Conn2)
                    cmd2.ExecuteNonQuery()
                    cmd = New OdbcCommand("update wbs_product_transfer_tab set flag='F' where wbsid='" & wbsid & "'", Conn)
                    cmd.ExecuteNonQuery()

                    'Start to Insert Detail Production Transfer, by Jhaya

                    detailString = "select wbsid, Resourcefcba,FcbaDestination, StorageSource,StorageDestination, NettoSource,netto,Difference,remark,flag  from wbs_product_transferdetail_tab"
                    detailString = detailString + " where flag='T' and wbsid = '" & wbsid & "'"

                    cmd = New OdbcCommand(detailString, Conn)
                    rd = cmd.ExecuteReader


                    Do While rd.Read
                        If rd.HasRows Then
                            If rd.IsDBNull(0) Then
                                tempDetail_wbsid_ = ""
                            Else
                                tempDetail_wbsid_ = rd.GetString(0)
                            End If

                            If rd.IsDBNull(1) Then
                                tempResourcefcba_ = ""
                            Else
                                tempResourcefcba_ = rd.GetString(1)
                            End If
                            If rd.IsDBNull(2) Then
                                tempFcbaDestination_ = ""
                            Else
                                tempFcbaDestination_ = rd.GetString(2)
                            End If
                            If rd.IsDBNull(3) Then
                                tempStorageSource_ = ""
                            Else
                                tempStorageSource_ = rd.GetString(3)
                            End If
                            If rd.IsDBNull(4) Then
                                tempStorageDestination_ = ""
                            Else
                                tempStorageDestination_ = rd.GetString(4)
                            End If

                            If rd.IsDBNull(5) Then
                                tempNettoSource_ = 0
                            Else
                                tempNettoSource_ = CDbl(rd.GetValue(5))
                            End If

                            If rd.IsDBNull(6) Then
                                tempNetto_ = 0
                            Else
                                tempNetto_ = CDbl(rd.GetValue(6))
                            End If

                            If rd.IsDBNull(7) Then
                                tempDifference_ = 0
                            Else
                                tempDifference_ = CDbl(rd.GetValue(7))
                            End If
                            If rd.IsDBNull(8) Then
                                tempRemark_ = ""
                            Else
                                tempRemark_ = rd.GetString(8)
                            End If
                            If rd.IsDBNull(9) Then
                                tempFlag_ = ""
                            Else
                                tempFlag_ = rd.GetString(9)
                            End If

                            sqlinsert = "Insert into transportwbticketdet ("
                            sqlinsert = sqlinsert + "transportwbticket, businessunitfrom,businessunitto, inventorylocationfrom,inventorylocationto,quantityfrom,quantityto,Difference,remarks,flag ) values ("
                            sqlinsert = sqlinsert + "'" & tempDetail_wbsid_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempResourcefcba_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempFcbaDestination_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempStorageSource_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempStorageDestination_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempNettoSource_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempNetto_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempDifference_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempRemark_ & "'"
                            sqlinsert = sqlinsert + ",'" & tempFlag_ & "')"

                            cmd2 = New OdbcCommand(sqlinsert, Conn2)
                            cmd2.ExecuteNonQuery()
                            ' MsgBox(sqlinsert)

                            Sqlupdate = "update wbs_product_transferdetail_tab set flag='F' where wbsid='" & tempDetail_wbsid_ & "'"
                            Sqlupdate = Sqlupdate + " and Resourcefcba = '" & tempResourcefcba_ & "'"


                            cmd = New OdbcCommand(Sqlupdate, Conn)
                            cmd.ExecuteNonQuery()
                        End If
                    Loop
                    ProgressBar = ProgressBar + 1
                    If ProgressBar >= jml Then
                        ProgressBar = jml
                    End If
                    ToolStripProgressBar1.Value = ProgressBar
                    ToolStripStatusLabel2.Text = CInt((ProgressBar / jml) * 100) & "% data Production Receive"
                End If
            Loop
            ToolStripProgressBar1.Visible = False
            ToolStripStatusLabel2.Visible = False
        End If
    End Sub


    Private Sub LainLainToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ShowForm(frmwb)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub



    Private Sub WBDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WBDToolStripMenuItem.Click
        Try
            ShowForm(frmdiv)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub WeighBridgeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeighBridgeToolStripMenuItem.Click

    End Sub

    Private Sub DLLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DLLToolStripMenuItem.Click
        Try

            ShowForm(frmreprint)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub LainLainToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LainLainToolStripMenuItem1.Click
        Try
            ShowForm(frmdailyrpt)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub



    Private Sub CPOToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CPOToolStripMenuItem1.Click
        Try
            ShowForm(frmreprintcpo)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub CPOToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CPOToolStripMenuItem2.Click
        Try

            ShowForm(frmdailyrptcpo)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub


    Private Sub TBSToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBSToolStripMenuItem1.Click
        Try
            ShowForm(FReprintTBS)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub TBSToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBSToolStripMenuItem2.Click
        Try

            ShowForm(FDailyRptTBS)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub WBEstateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WBEstateToolStripMenuItem.Click
        Try
            ShowForm(frmestate)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub KendaraanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KendaraanToolStripMenuItem.Click
        Try
            ShowForm(frmvehicle)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub SupirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupirToolStripMenuItem.Click
        Try
            ShowForm(frmdriver)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub KonstantaSortaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KonstantaSortaseToolStripMenuItem.Click
        Try
            ShowForm(frmsortase)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub


    Private Sub DeliveryKontrakToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeliveryKontrakToolStripMenuItem.Click
        Try
            'ShowForm(frmkontrak)
            ShowForm(frmkontrakonline)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub



    Private Sub CPOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CPOToolStripMenuItem.Click
        Try
            ShowForm(FWbCpo)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub TransferCPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferCPO.Click
        Try
            ShowForm(FWbTransferCPO)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub AdjustTimbangLuarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustTimbangLuarToolStripMenuItem.Click
        Try

            ShowForm(frmwbluar)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub ManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualToolStripMenuItem.Click
        Try
            ShowForm(frmmanual)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub TarraTeloranceMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarraTeloranceMenuItem.Click
        Try
            ShowForm(FrmTarraTolerance)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub



    Private Sub DetailKontrak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailKontrak.Click
        Try
            ShowForm(FrmDetailKontrak)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub


    Private Sub NoUploadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoUploadToolStripMenuItem.Click
        Try

            ShowForm(NotUploadedTBS)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub TBSOneWayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBSOneWayToolStripMenuItem.Click
        Try
            ShowForm(FwbTbsOneWay)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub TBSToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBSToolStripMenuItem.Click

    End Sub

    Private Sub TBSTwoWayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBSTwoWayToolStripMenuItem.Click
        Try
            ShowForm(FwbPrdRcvTwoWay)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Timer1.Enabled = False
        timerup.Enabled = False
        End
    End Sub
    Private Sub ClockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClockToolStripMenuItem.Click
        Try

            ShowForm(Form1)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub TestWBIndicatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestWBIndicatorToolStripMenuItem.Click
        Try

            ShowForm(WBIndicator)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub WBLainLainToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WBLainLainToolStripMenuItem.Click

        Try
            ShowForm(frmwb)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub WBTitipTimbunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            ShowForm(FWbTitipTimbun)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub


    Private Sub BuaatBeritaAcaraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            ShowForm(Berita_acara)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Timer1.Enabled = False
        timerup.Enabled = False
        End
    End Sub

    Private Sub EditProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditProfileToolStripMenuItem.Click
        MsgBox("Belum Tersedia")
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        UbahPass.Show()
    End Sub

    Private Sub TestWBIndicatorManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestWBIndicatorManualToolStripMenuItem.Click
        Try

            ShowForm(fwterm)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem2.Click
        Timer1.Enabled = False
        timerup.Enabled = False
        End
    End Sub
    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub frmmain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim msg = "Apakah Anda ingin Keluar dari Program ?"
        ' Define a title for the message box. 
        Dim title = "Exit"
        Dim style = MsgBoxStyle.YesNoCancel
        ' Display the message box and save the response, Yes or No. 
        Dim response = MsgBox(msg, style, title)
        ' Take some action based on the response. 
        If response = MsgBoxResult.Yes Then
            Timer1.Enabled = False
            timerup.Enabled = False
            End
        ElseIf response = MsgBoxResult.No Then
            frmlogin.Visible = True
            frmlogin.txtpassword.Text = ""
        ElseIf response = MsgBoxResult.Cancel Then
            e.Cancel = True
        End If

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        ShowForm(about)
    End Sub

    Private Sub RegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterToolStripMenuItem.Click
        Registry.ShowDialog()
    End Sub
    Private Sub VehicleHistoryCPOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VehicleHistoryCPOToolStripMenuItem.Click
        ShowForm(vehicle_history)
    End Sub

    Private Sub ReturnContractWeightingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnContractWeightingToolStripMenuItem.Click
        Try
            ShowForm(FWbReturnCpo)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub UserRolesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserRolesToolStripMenuItem.Click
        Dim pass As String
        pass = ConfirmationPass()
        If pass <> "Cancelled" Then
            cmd = New odbcCommand("select userid from wbs_user_tab where userid='" & frmlogin.txtid.Text & "' and password='" & Enkripsi.Encrypt(pass) & "'", Conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Try
                    Dim FormUserRoles As New User_roles
                    FormUserRoles.MdiParent = Me
                    FormUserRoles.Show()
                Catch ex As Exception
                End Try
            Else
                MsgBox("Password Wrong")
            End If
        End If

    End Sub

    Private Sub UserNameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserNameToolStripMenuItem.Click

    End Sub

    Private Sub ReturnContractToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnContractToolStripMenuItem.Click
        Try
           
            ShowForm(FrmApp)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub TerimaTransferToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerimaTransferToolStripMenuItem.Click
        Try
            ShowForm(FWbterimaTransfer)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub CategoryTransferToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ShowForm(frmreprint_trn)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub status_timbang_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles status_timbang.Tick

    End Sub

    Private Sub ToolStripProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripProgressBar1.Click

    End Sub

    Private Sub RequiredTBSFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RequiredTBSFormToolStripMenuItem.Click
        Try
            ShowForm(settingtbsform)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub InsertBlockTahunTanamToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertBlockTahunTanamToolStripMenuItem.Click
        
    End Sub

    Private Sub TestWBIndicator3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ShowForm(Form3)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestToolStripMenuItem.Click
        Try
            
            ShowForm(TESTERFORM)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub Insert1By1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Insert1By1ToolStripMenuItem.Click
        Try
            ShowForm(tahuntanamfrm)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub ReplaceByIPlaSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceByIPlaSToolStripMenuItem.Click
        Try
            
            ShowForm(updateblok)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub versionnumbering_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles versionnumbering.Click

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

    End Sub

    Private Sub CompraceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompraceToolStripMenuItem.Click
        Try
            ShowForm(Compress)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            ShowForm(FwbProdtransfer)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WBProductionReceiveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WBProductionReceiveToolStripMenuItem.Click
        Try
            ShowForm(FwbProdReceive)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub MillOriginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MillOriginToolStripMenuItem.Click
        Try
            ShowForm(frmmill)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub CategoryRECEIVEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryRECEIVEToolStripMenuItem.Click
        Try
            ShowForm(frmreprintreceive)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub CategoryTRANSFERToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryTRANSFERToolStripMenuItem.Click
        Try
            ShowForm(frmreprinttransfer)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

   
    Private Sub CPOTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CPOTToolStripMenuItem.Click
        Try
            ShowForm(frmdailyrptcpot)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub ContractWeightingOldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContractWeightingOldToolStripMenuItem.Click
        Try
            ShowForm(FWbCpo2)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub MillReceiveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MillReceiveToolStripMenuItem.Click
        Try
            ShowForm(frmdailyrptcpor)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub GradeTBSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GradeTBSToolStripMenuItem.Click
        Try
            ShowForm(frmgradetbs)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub TBSMultiAfdToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBSMultiAfdToolStripMenuItem.Click
        Try
            ShowForm(FwbTbsMultiAfd)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub CategoryMultiAfdTBSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryMultiAfdTBSToolStripMenuItem.Click
        Try
            ShowForm(FReprintMTBS)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub TBSMultiAfdelingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBSMultiAfdelingToolStripMenuItem.Click
        Try
            ShowForm(FDailyRptMTBS)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub

    Private Sub DeliveryKontrakOldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeliveryKontrakOldToolStripMenuItem.Click
        Try
            ShowForm(frmkontrakold)
        Catch ex As Exception
            'MsgBox("error")
        End Try
    End Sub
End Class


'    Private Sub DeliveryKontrakOldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeliveryKontrakOldToolStripMenuItem.Click
'        '    Try
'        '        ShowForm(frmkontrakold)
'        '    Catch ex As Exception
'        '        'MsgBox("error")
'        '    End Try
'        'End Sub
'End Class
