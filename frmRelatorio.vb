Public Class frmRelatorio

#Region "functions"
    Private Sub loadEventos()
        Dim dt As DataTable = Util.getDtCombo()
        Dim cmd As New OleDb.OleDbCommand()
        Try
            dt = dbHelper.doSelect("SELECT ID_EVENTO AS id, DESCRICAO FROM SGIEventos", cmd)
        Catch ex As Exception
            Throw ex
        End Try

        dt = Util.getDefaultComboDt(dt)

        Me.ddlEvento.ValueMember = "id"
        Me.ddlEvento.DisplayMember = "descricao"
        Me.ddlEvento.DataSource = dt
    End Sub

    Private Sub loadAcLote()
        Dim dt As DataTable = Util.getDtCombo()
        Dim cmd As New OleDb.OleDbCommand()
        Try
            dt = dbHelper.doSelect("SELECT ID_EVENTO AS id, DESCRICAO FROM SGIEventos", cmd)
        Catch ex As Exception
            Throw ex
        End Try

        dt = Util.getDefaultComboDt(dt)

        Me.ddlEvento.ValueMember = "id"
        Me.ddlEvento.DisplayMember = "descricao"
        Me.ddlEvento.DataSource = dt
    End Sub

#End Region
    Private Sub frmRelatorio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.loadEventos()
    End Sub

    Private Sub btnAcLote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcLote.Click
        If Me.ddlEvento.SelectedValue <> 0 Then
            Dim frmRel As New frmRptViewer()

            frmRel.dsRelAcessos.Evento.AddEventoRow(Me.ddlEvento.SelectedText)
            frmRel.dsRelAcessos.Evento.AcceptChanges()

            'DISTINCT DE LOTES
            Dim dt As New DataTable()
            Dim cmd As New OleDb.OleDbCommand()
            dt = dbHelper.doSelect("SELECT DISTINCT ID_LOTE FROM ACESSOS", cmd)

            Dim i, icount As Integer
            icount = dt.Rows.Count
            For i = 0 To icount - 1
                frmRel.dsRelAcessos.Acessos.AddAcessosRow(dt.Rows(i)("ID_LOTE"), 0, 0, 0, "")
            Next
            frmRel.dsRelAcessos.Acessos.AcceptChanges()

            'DESCRICAO DE LOTES
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("ID_LOTE", 0)
            cmd.Parameters("ID_LOTE").OleDbType = OleDb.OleDbType.Integer
            icount = frmRel.dsRelAcessos.Acessos.Rows.Count
            For i = 0 To icount - 1
                cmd.Parameters("ID_LOTE").Value = frmRel.dsRelAcessos.Acessos.Rows(i).Item("CODIGO")
                Try
                    dt = dbHelper.doSelect("SELECT (A.DESCRICAO + ' / ' + L.DESCRICAO) AS DESCRICAO FROM SGILotes L, SGIAtracoes A WHERE L.ID_ATRACAO=A.ID_ATRACAO AND ID_LOTE=?", cmd)
                    frmRel.dsRelAcessos.Acessos.Rows(i).Item("DESCRICAO") = dt.Rows(0).Item(0)
                Catch
                End Try
            Next
            frmRel.dsRelAcessos.Acessos.AcceptChanges()

            'COUNT VENDIDOS POR ID_LOTE
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("ID_LOTE", 0)
            cmd.Parameters("ID_LOTE").OleDbType = OleDb.OleDbType.Integer
            icount = frmRel.dsRelAcessos.Acessos.Rows.Count
            For i = 0 To icount - 1
                cmd.Parameters("ID_LOTE").Value = frmRel.dsRelAcessos.Acessos.Rows(i).Item("CODIGO")
                Try
                    dt = dbHelper.doSelect("SELECT DISTINCT ID_TRANSACAO  FROM ACESSOS WHERE ID_LOTE=?", cmd)
                    frmRel.dsRelAcessos.Acessos.Rows(i).Item("VENDIDOS") = dt.Rows.Count
                Catch
                End Try
            Next
            frmRel.dsRelAcessos.Acessos.AcceptChanges()

            'COUNT ACESSADOS POR ID_LOTE
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("ID_LOTE", 0)
            cmd.Parameters("ID_LOTE").OleDbType = OleDb.OleDbType.Integer
            icount = frmRel.dsRelAcessos.Acessos.Rows.Count
            For i = 0 To icount - 1
                cmd.Parameters("ID_LOTE").Value = frmRel.dsRelAcessos.Acessos.Rows(i).Item("CODIGO")
                Try
                    dt = dbHelper.doSelect("SELECT DISTINCT ID_TRANSACAO FROM ACESSOS WHERE ID_LOTE=? AND ENTROU=1", cmd)
                    frmRel.dsRelAcessos.Acessos.Rows(i).Item("ACESSADOS") = dt.Rows.Count
                Catch
                End Try
            Next
            frmRel.dsRelAcessos.Acessos.AcceptChanges()

            'COUNT ACESSADOS POR ID_LOTE
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("ID_LOTE", 0)
            cmd.Parameters("ID_LOTE").OleDbType = OleDb.OleDbType.Integer
            icount = frmRel.dsRelAcessos.Acessos.Rows.Count
            For i = 0 To icount - 1
                cmd.Parameters("ID_LOTE").Value = frmRel.dsRelAcessos.Acessos.Rows(i).Item("CODIGO")
                Try
                    dt = dbHelper.doSelect("SELECT DISTINCT ID_TRANSACAO FROM CANCELADOS WHERE ID_LOTE=?", cmd)
                    frmRel.dsRelAcessos.Acessos.Rows(i).Item("CANCELADOS") = dt.Rows.Count
                Catch
                End Try
            Next
            frmRel.dsRelAcessos.Acessos.AcceptChanges()
            frmRel.dsRelAcessos.Acessos.DefaultView.Sort = "DESCRICAO ASC"

            frmRel.Show()
        Else
            MsgBox("Por favor, selecione um evento!")
        End If
    End Sub

    Private Sub btnAcPortaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.ddlEvento.SelectedValue <> 0 Then

        Else
            MsgBox("Por favor, selecione um evento!")
        End If
    End Sub

    Private Sub btnCanLote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.ddlEvento.SelectedValue <> 0 Then

        Else
            MsgBox("Por favor, selecione um evento!")
        End If
    End Sub

    Private Sub btnCanPortaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.ddlEvento.SelectedValue <> 0 Then

        Else
            MsgBox("Por favor, selecione um evento!")
        End If
    End Sub
End Class