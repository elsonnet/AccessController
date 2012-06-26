Public Class frmCadClientes

    'Private Sub loadEventos()
    '    Dim ws As New wsChamadas.kkk()
    '    ws.Url = Util.getWebServiceUrl()
    '    Dim dt As DataTable = ws.evAtivos(DirectCast(Me.MdiParent, frmMain)._produtor.IdProdutor)

    '    Util.getDefaultComboDt(dt)

    '    Me.ddlEvento.ValueMember = "id"
    '    Me.ddlEvento.DisplayMember = "descricao"
    '    Me.ddlEvento.DataSource = dt
    'End Sub

    'Private Sub loadPortarias()
    '    If Me.ddlEvento.SelectedValue <> 0 Then
    '        Dim ws As New wsChamadas.kkk()
    '        ws.Url = Util.getWebServiceUrl()
    '        Dim dt As DataTable = ws.ptAtivos(DirectCast(Me.MdiParent, frmMain)._produtor.IdProdutor, Me.ddlEvento.SelectedValue)

    '        Me.lstPortarias.ValueMember = "id"
    '        Me.lstPortarias.DisplayMember = "descricao"
    '        If dt.Rows.Count > 0 Then
    '            Me.lstPortarias.DataSource = dt
    '        Else
    '            Me.lstPortarias.DataSource = Util.getDtCombo()
    '        End If
    '    End If
    'End Sub

    'Private Function getIdsTransaction(ByVal dt As DataTable) As String()
    '    Dim list As New List(Of String)
    '    Dim i, icount As Integer
    '    icount = dt.Rows.Count
    '    For i = 0 To icount - 1
    '        list.Add(dt.Rows(i)("ID_TRANSACAO"))
    '    Next

    '    Return list.ToArray()
    'End Function

    'Private Function getSelectedItems() As String()
    '    Dim arrayInt As New List(Of String)

    '    Dim i, iCount As Integer
    '    iCount = Me.lstPortarias.Items.Count
    '    For i = 0 To iCount - 1
    '        If Me.lstPortarias.SelectedItems.Contains(Me.lstPortarias.Items(i)) Then
    '            Dim row As DataRowView = Me.lstPortarias.Items(i)
    '            arrayInt.Add(row("id"))
    '        End If
    '    Next

    '    Return arrayInt.ToArray
    'End Function

    'Private Sub setProgressBarSuper(ByVal value As Integer)
    '    Me.lblPcSuper.Text = value.ToString + "%"
    '    Me.progressBarSuper.Value = value
    '    Application.DoEvents()
    'End Sub

    'Private Sub setProgressBarSub(ByVal value As Integer)
    '    Me.lblPcSub.Text = value.ToString + "%"
    '    Me.progressBarSub.Value = value
    '    Application.DoEvents()
    'End Sub

    'Private Sub frmConfig_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    Me.Dispose()
    'End Sub

    'Private Sub frmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Try
    '        RemoveHandler Me.ddlEvento.SelectedIndexChanged, AddressOf Me.ddlEvento_SelectedIndexChanged
    '        Me.loadEventos()
    '        AddHandler Me.ddlEvento.SelectedIndexChanged, AddressOf Me.ddlEvento_SelectedIndexChanged
    '        Me.loadPortarias()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub btnFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFechar.Click
    '    Me.Close()
    'End Sub

    'Private Sub ddlEvento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEvento.SelectedIndexChanged
    '    If Me.ddlEvento.SelectedValue = 0 Then
    '        Exit Sub
    '    End If

    '    Try
    '        Me.loadPortarias()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub lstPortarias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPortarias.SelectedIndexChanged
    '    Dim arrayInt() As String = Me.getSelectedItems()
    '    If arrayInt.Length = 1 Then
    '        Me.btnExecutar.Enabled = arrayInt(0) <> "0"
    '    ElseIf arrayInt.Length = 0 Then
    '        Me.btnExecutar.Enabled = False
    '    Else
    '        Me.btnExecutar.Enabled = True
    '    End If
    'End Sub

    'Private Sub btnExecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecutar.Click
    '    Me.btnExecutar.Text = "Por favor, aguarde ..."
    '    Me.btnExecutar.Enabled = False
    '    Dim idProdutor As Integer = DirectCast(Me.MdiParent, frmMain)._produtor.IdProdutor

    '    Dim dt As New DataTable
    '    Dim ws As New wsChamadas.kkk()
    '    ws.Url = Util.getWebServiceUrl()

    '    'Produtores
    '    dt.Clear()
    '    Try
    '        dt = ws.pdAtivos(idProdutor, 0)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    If dt.Rows.Count > 0 Then
    '        Dim cmdInsert As New OleDb.OleDbCommand()
    '        Dim cmdUpdate As New OleDb.OleDbCommand()
    '        dbHelper.addParametersToCommand(cmdInsert, dt, New String() {})
    '        dbHelper.addParametersToCommand(cmdUpdate, dt, New String() {"ID_PRODUTOR"})

    '        Dim y, yCount As Integer
    '        yCount = dt.Rows.Count
    '        For y = 0 To yCount - 1
    '            dbHelper.addValuesToParameters(cmdUpdate, dt, y)
    '            Dim ok As Integer = dbHelper.doInsertOrUpdate("UPDATE  SGIProdutores SET  ID_AFILIADO  = ?, ID_TPPESSOA  = ?, NOME_PRODUTOR  = ?, FANTASIA_PRODUTOR  = ?, RG_IE  = ?, CPF_CNPJ  = ?, DDD  = ?, TELEFONE  = ?, RAMAL  = ?, USUARIO  = ?, SENHA  = ?, ATIVO  = ?, SENHA_SANGRIA  = ?, DTREGISTRO  = ? WHERE ID_PRODUTOR = ?", cmdUpdate)
    '            If ok <> 1 Then
    '                dbHelper.addValuesToParameters(cmdInsert, dt, y)
    '                ok = dbHelper.doInsertOrUpdate("INSERT INTO  SGIProdutores (ID_PRODUTOR, ID_AFILIADO, ID_TPPESSOA, NOME_PRODUTOR, FANTASIA_PRODUTOR, RG_IE, CPF_CNPJ, DDD, TELEFONE, RAMAL, USUARIO, SENHA, ATIVO, SENHA_SANGRIA, DTREGISTRO ) VALUES (? , ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", cmdInsert)
    '            End If

    '            Me.setProgressBarSuper((y / yCount) * 100)
    '        Next
    '    End If

    '    'Portarias
    '    dt.Clear()
    '    Try
    '        dt = ws.ptAtivosAll(idProdutor, Me.ddlEvento.SelectedValue)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    If dt.Rows.Count > 0 Then
    '        Dim cmdInsert As New OleDb.OleDbCommand()
    '        Dim cmdUpdate As New OleDb.OleDbCommand()
    '        dbHelper.addParametersToCommand(cmdInsert, dt, New String() {})
    '        dbHelper.addParametersToCommand(cmdUpdate, dt, New String() {"ID_PORTARIA"})

    '        Dim y, yCount As Integer
    '        yCount = dt.Rows.Count
    '        For y = 0 To yCount - 1
    '            dbHelper.addValuesToParameters(cmdUpdate, dt, y)
    '            Dim ok As Integer = dbHelper.doInsertOrUpdate("UPDATE  SGIPortarias SET  ID_PRODUTOR  = ?, ID_EVENTO  = ?, DESCRICAO  = ?, SENHA  = ?, DTINICIAL  = ?, DTFINAL  = ?, DT_REGISTRO  = ? WHERE ID_PORTARIA = ?", cmdUpdate)
    '            If ok <> 1 Then
    '                dbHelper.addValuesToParameters(cmdInsert, dt, y)
    '                ok = dbHelper.doInsertOrUpdate("INSERT INTO  SGIPortarias (ID_PORTARIA, ID_PRODUTOR, ID_EVENTO, DESCRICAO, SENHA, DTINICIAL, DTFINAL, DT_REGISTRO) VALUES (? , ?, ?, ?, ?, ?, ?, ?)", cmdInsert)
    '            End If

    '            Me.setProgressBarSuper((y / yCount) * 100)
    '        Next
    '    End If

    '    'Eventos
    '    dt.Clear()
    '    Try
    '        dt = ws.evAtivosAll(idProdutor, Me.ddlEvento.SelectedValue)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    If dt.Rows.Count > 0 Then
    '        Dim cmdInsert As New OleDb.OleDbCommand()
    '        Dim cmdUpdate As New OleDb.OleDbCommand()
    '        dbHelper.addParametersToCommand(cmdInsert, dt, New String() {})
    '        dbHelper.addParametersToCommand(cmdUpdate, dt, New String() {"ID_EVENTO"})

    '        Dim y, yCount As Integer
    '        yCount = dt.Rows.Count
    '        For y = 0 To yCount - 1
    '            dbHelper.addValuesToParameters(cmdUpdate, dt, y)
    '            Dim ok As Integer = dbHelper.doInsertOrUpdate("UPDATE  SGIEventos SET  ID_TPEVENTO  = ?, ID_PRODUTOR  = ?, DESCRICAO  = ?, DTINICIAL_EVENTO  = ?, DTFINAL_EVENTO  = ?, DTREGISTRO  = ? WHERE ID_EVENTO = ?", cmdUpdate)
    '            If ok <> 1 Then
    '                dbHelper.addValuesToParameters(cmdInsert, dt, y)
    '                ok = dbHelper.doInsertOrUpdate("INSERT INTO  SGIEventos ( ID_EVENTO, ID_TPEVENTO, ID_PRODUTOR,DESCRICAO,DTINICIAL_EVENTO,DTFINAL_EVENTO,DTREGISTRO) VALUES (?, ?, ?, ?, ?, ?, ?)", cmdInsert)
    '            End If

    '            Me.setProgressBarSuper((y / yCount) * 100)
    '        Next
    '    End If

    '    'Atracoes
    '    dt.Clear()
    '    Try
    '        dt = ws.atAtivos(idProdutor, Me.ddlEvento.SelectedValue)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    If dt.Rows.Count > 0 Then
    '        Dim cmdInsert As New OleDb.OleDbCommand()
    '        Dim cmdUpdate As New OleDb.OleDbCommand()
    '        dbHelper.addParametersToCommand(cmdInsert, dt, New String() {})
    '        dbHelper.addParametersToCommand(cmdUpdate, dt, New String() {"ID_ATRACAO"})

    '        Dim y, yCount As Integer
    '        yCount = dt.Rows.Count
    '        For y = 0 To yCount - 1
    '            dbHelper.addValuesToParameters(cmdUpdate, dt, y)
    '            Dim ok As Integer = dbHelper.doInsertOrUpdate("UPDATE  SGIAtracoes SET  ID_EVENTO  = ?, ID_TPGENERO  = ?, LOTACAO  = ?, LOCALIDADE  = ?, ENDERECO  = ?, CIDADE  = ?, UF  = ?, CLASSIFICACAO  = ?, DESCRICAO  = ?, DATAHORA  = ?, DTINICIAL_ATRACAO  = ?, DTFINAL_ATRACAO  = ?, DTREGISTRO  = ? WHERE ID_ATRACAO = ?", cmdUpdate)
    '            If ok <> 1 Then
    '                dbHelper.addValuesToParameters(cmdInsert, dt, y)
    '                ok = dbHelper.doInsertOrUpdate("INSERT INTO  SGIAtracoes (ID_ATRACAO, ID_EVENTO, ID_TPGENERO, LOTACAO, LOCALIDADE, ENDERECO, CIDADE, UF, CLASSIFICACAO, DESCRICAO, DATAHORA, DTINICIAL_ATRACAO, DTFINAL_ATRACAO, DTREGISTRO ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", cmdInsert)
    '            End If

    '            Me.setProgressBarSuper((y / yCount) * 100)
    '        Next
    '    End If


    '    'Lotes
    '    dt.Clear()
    '    Try
    '        dt = ws.ltAtivos(idProdutor, Me.ddlEvento.SelectedValue)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    If dt.Rows.Count > 0 Then
    '        Dim cmdInsert As New OleDb.OleDbCommand()
    '        Dim cmdUpdate As New OleDb.OleDbCommand()
    '        dbHelper.addParametersToCommand(cmdInsert, dt, New String() {})
    '        dbHelper.addParametersToCommand(cmdUpdate, dt, New String() {"ID_LOTE"})

    '        Dim y, yCount As Integer
    '        yCount = dt.Rows.Count
    '        For y = 0 To yCount - 1
    '            dbHelper.addValuesToParameters(cmdUpdate, dt, y)
    '            Dim ok As Integer = dbHelper.doInsertOrUpdate("UPDATE  SGILotes SET  ID_TPINGRESSO  = ?, ID_ATRACAO  = ?, QTDE  = ?, PRECO  = ?, DTINICIAL_LOTE  = ?, DTFINAL_LOTE  = ?, DESCRICAO  = ?, IS_BILHETERIA  = ?, DTREGISTRO  = ? WHERE ID_LOTE = ?", cmdUpdate)
    '            If ok <> 1 Then
    '                dbHelper.addValuesToParameters(cmdInsert, dt, y)
    '                ok = dbHelper.doInsertOrUpdate("INSERT INTO  SGILotes (ID_LOTE, ID_TPINGRESSO, ID_ATRACAO, QTDE, PRECO, DTINICIAL_LOTE, DTFINAL_LOTE, DESCRICAO, IS_BILHETERIA, DTREGISTRO ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", cmdInsert)
    '            End If

    '            Me.setProgressBarSuper((y / yCount) * 100)
    '        Next
    '    End If


    '    Dim portarias() As String = Me.getSelectedItems()


    '    'Identificadores de ingressos cancelados
    '    Dim i, iCount As Integer
    '    iCount = portarias.Length
    '    For i = 0 To iCount - 1
    '        dt.Clear()
    '        Try
    '            dt = ws.presidio(0, portarias(i))
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '        If dt.Rows.Count > 0 Then
    '            Dim cmd As New OleDb.OleDbCommand()
    '            cmd.Parameters.AddWithValue("ID_TRANSACAO", 0)
    '            cmd.Parameters.AddWithValue("ID_PORTARIA", 0)

    '            Dim y, yCount As Integer
    '            yCount = dt.Rows.Count
    '            For y = 0 To yCount - 1
    '                cmd.Parameters("ID_TRANSACAO").Value = dt.Rows(y).Item("TR")
    '                cmd.Parameters("ID_PORTARIA").Value = dt.Rows(y).Item("PT")
    '                Dim ok As Integer = dbHelper.doInsertOrUpdate("INSERT INTO  CANCELADOS ( ID_TRANSACAO, ID_PORTARIA, ID_LOTE) VALUES (?,?,0)", cmd)

    '                Me.setProgressBarSuper((y / yCount) * 100)
    '            Next
    '        End If

    '        Me.setProgressBarSub((i / iCount) * 100)
    '    Next


    '    'Identificadores de ingressos ok
    '    iCount = portarias.Length
    '    For i = 0 To iCount - 1
    '        dt.Clear()
    '        Try
    '            dt = ws.cadeia(0, portarias(i))
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '        If dt.Rows.Count > 0 Then
    '            Dim cmd As New OleDb.OleDbCommand()
    '            cmd.Parameters.AddWithValue("ID_TRANSACAO", 0)
    '            cmd.Parameters.AddWithValue("ID_PORTARIA", 0)

    '            Dim y, yCount As Integer
    '            yCount = dt.Rows.Count
    '            For y = 0 To yCount - 1
    '                cmd.Parameters("ID_TRANSACAO").Value = dt.Rows(y).Item("TR")
    '                cmd.Parameters("ID_PORTARIA").Value = dt.Rows(y).Item("PT")
    '                Dim ok As Integer = dbHelper.doInsertOrUpdate("INSERT INTO ACESSOS (ID_TRANSACAO, ID_PORTARIA, ID_LOTE, ENTROU) VALUES (?,?,0,0)", cmd)

    '                Me.setProgressBarSuper((y / yCount) * 100)
    '            Next
    '        End If

    '        Me.setProgressBarSub((i / iCount) * 100)
    '    Next

    '    Dim defaultModQtty As Integer = 10

    '    'Restante de dados de ingressos cancelados
    '    icount = portarias.Length
    '    For i = 0 To iCount - 1
    '        Dim qtty As Integer = 0
    '        dt.Clear()
    '        Try
    '            Dim cmd As New OleDb.OleDbCommand()
    '            cmd.Parameters.AddWithValue("ID_PORTARIA", portarias(i))
    '            cmd.Parameters("ID_PORTARIA").OleDbType = OleDb.OleDbType.Integer
    '            qtty = dbHelper.doSelect("SELECT COUNT(*) FROM CANCELADOS WHERE ID_PORTARIA=? AND ID_LOTE=0", cmd).Rows(0)(0)
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try


    '        Dim y, yCount As Integer

    '        If (qtty Mod defaultModQtty) <> 0 Then
    '            qtty = (qtty \ defaultModQtty) + 1
    '        End If

    '        yCount = qtty

    '        For y = 0 To yCount - 1
    '            dt.Clear()
    '            Dim cmd As New OleDb.OleDbCommand()
    '            cmd.Parameters.AddWithValue("ID_PORTARIA", portarias(i))
    '            dt = dbHelper.doSelect("SELECT TOP " + defaultModQtty.ToString + " * FROM CANCELADOS WHERE ID_PORTARIA=? AND ID_LOTE=0", cmd)

    '            dt = ws.presidio2(0, portarias(i), Me.getIdsTransaction(dt))

    '            Dim cmdUpdate As New OleDb.OleDbCommand()
    '            dbHelper.addParametersToCommand(cmdUpdate, dt, New String() {New String("ID_TRANSACAO"), New String("ID_PORTARIA")})

    '            Dim j, jCount As Integer
    '            jCount = dt.Rows.Count
    '            For j = 0 To jCount - 1
    '                dbHelper.addValuesToParameters(cmdUpdate, dt, j)
    '                Dim ok As Integer = dbHelper.doInsertOrUpdate("UPDATE CANCELADOS SET ID_LOTE  =  ?, TICKETHASH  =  ?, DTREGISTRO  =  ? WHERE ID_TRANSACAO=? AND ID_PORTARIA=?", cmdUpdate)
    '                Me.setProgressBarSuper((j / jCount) * 100)
    '            Next

    '            Me.setProgressBarSub((y / yCount) * 100)
    '        Next
    '    Next



    '    'Restante de dados de ingressos oks

    '    iCount = portarias.Length
    '    For i = 0 To iCount - 1
    '        Dim qtty As Integer = 0
    '        dt.Clear()
    '        Try
    '            Dim cmd As New OleDb.OleDbCommand()
    '            cmd.Parameters.AddWithValue("ID_PORTARIA", portarias(i))
    '            cmd.Parameters("ID_PORTARIA").OleDbType = OleDb.OleDbType.Integer
    '            qtty = dbHelper.doSelect("SELECT COUNT(*) FROM ACESSOS WHERE ID_PORTARIA=? AND ID_LOTE=0", cmd).Rows(0)(0)
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try


    '        Dim y, yCount As Integer

    '        If (qtty Mod defaultModQtty) <> 0 Then
    '            qtty = (qtty \ defaultModQtty) + 1
    '        End If

    '        yCount = qtty

    '        For y = 0 To yCount - 1
    '            dt.Clear()
    '            Dim cmd As New OleDb.OleDbCommand()
    '            cmd.Parameters.AddWithValue("ID_PORTARIA", portarias(i))
    '            dt = dbHelper.doSelect("SELECT TOP " + defaultModQtty.ToString + " * FROM ACESSOS WHERE ID_PORTARIA=? AND ID_LOTE=0", cmd)

    '            dt = ws.cadeia2(0, portarias(i), Me.getIdsTransaction(dt))

    '            Dim cmdUpdate As New OleDb.OleDbCommand()
    '            dbHelper.addParametersToCommand(cmdUpdate, dt, New String() {New String("ID_TRANSACAO"), New String("ID_PORTARIA")})

    '            Dim j, jCount As Integer
    '            jCount = dt.Rows.Count
    '            For j = 0 To jCount - 1
    '                dbHelper.addValuesToParameters(cmdUpdate, dt, j)
    '                Dim ok As Integer = dbHelper.doInsertOrUpdate("UPDATE  ACESSOS SET  ID_LOTE  = ?, TICKETHASH  = ?, DTREGISTRO  = ? WHERE ID_TRANSACAO=? AND ID_PORTARIA=?", cmdUpdate)
    '                Me.setProgressBarSuper((j / jCount) * 100)
    '            Next

    '            Me.setProgressBarSub((y / yCount) * 100)
    '        Next
    '    Next





    '    'UPDATE  SGIProdutores SET  ID_AFILIADO  = ?, ID_TPPESSOA  = ?, NOME_PRODUTOR  = ?, FANTASIA_PRODUTOR  = ?, RG_IE  = ?, CPF_CNPJ  = ?, DDD  = ?, TELEFONE  = ?, RAMAL  = ?, USUARIO  = ?, SENHA  = ?, ATIVO  = ?, SENHA_SANGRIA  = ?, DTREGISTRO  = ? WHERE ID_PRODUTOR = ?

    '    'UPDATE  SGIPortarias SET  ID_PRODUTOR  = ?, ID_EVENTO  = ?, DESCRICAO  = ?, SENHA  = ?, DTINICIAL  = ?, DTFINAL  = ?, DT_REGISTRO  = ? WHERE ID_PORTARIA = ?

    '    'UPDATE  SGILotes SET  ID_TPINGRESSO  = ?, ID_ATRACAO  = ?, QTDE  = ?, PRECO  = ?, DTINICIAL_LOTE  = ?, DTFINAL_LOTE  = ?, DESCRICAO  = ?, IS_BILHETERIA  = ?, DTREGISTRO  = ? WHERE ID_LOTE = ?

    '    'UPDATE  SGIAtracoes SET  ID_EVENTO  = ?, ID_TPGENERO  = ?, LOTACAO  = ?, LOCALIDADE  = ?, ENDERECO  = ?, CIDADE  = ?, UF  = ?, CLASSIFICACAO  = ?, DESCRICAO  = ?, DATAHORA  = ?, DTINICIAL_ATRACAO  = ?, DTFINAL_ATRACAO  = ?, DTREGISTRO  = ? WHERE ID_ATRACAO = ?

    '    'UPDATE  SGIEventos SET  ID_TPEVENTO  = ?, ID_PRODUTOR  = ?, DESCRICAO  = ?, DTINICIAL_EVENTO  = ?, DTFINAL_EVENTO  = ?, DTREGISTRO  = ? WHERE ID_EVENTO = ?

    '    'UPDATE  ACESSOS SET  ID_PORTARIA  = ?, DT_ENTRADA  = ?, ID_LOTE  = ?, TICKETHASH  = ?, DTREGISTRO  = ? WHERE ID_TRANSACAO=? AND ID_PORTARIA=0

    '    'UPDATE  CANCELADOS SET  ID_PORTARIA  = ?, ID_LOTE  =  ?, TICKETHASH  =  ?, CANCELADO  =  ?, DTREGISTRO  =  ? WHERE ID_TRANSACAO=? AND ID_PORTARIA=0



    '    'INSERT INTO  SGIProdutores (ID_PRODUTOR, ID_AFILIADO, ID_TPPESSOA, NOME_PRODUTOR, FANTASIA_PRODUTOR, RG_IE, CPF_CNPJ, DDD, TELEFONE, RAMAL, USUARIO, SENHA, ATIVO, SENHA_SANGRIA, DTREGISTRO ) VALUES (? , ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)

    '    'INSERT INTO  SGIPortarias (ID_PORTARIA, ID_PRODUTOR, ID_EVENTO, DESCRICAO, SENHA, DTINICIAL, DTFINAL, DT_REGISTRO) VALUES (? , ?, ?, ?, ?, ?, ?, ?)

    '    'INSERT INTO  SGILotes (ID_LOTE, ID_TPINGRESSO, ID_ATRACAO, QTDE, PRECO, DTINICIAL_LOTE, DTFINAL_LOTE, DESCRICAO, IS_BILHETERIA, DTREGISTRO ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)

    '    'INSERT INTO  SGIAtracoes (ID_ATRACAO, ID_EVENTO, ID_TPGENERO, LOTACAO, LOCALIDADE, ENDERECO, CIDADE, UF, CLASSIFICACAO, DESCRICAO, DATAHORA, DTINICIAL_ATRACAO, DTFINAL_ATRACAO, DTREGISTRO ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)

    '    'INSERT INTO  SGIEventos ( ID_EVENTO, ID_TPEVENTO, ID_PRODUTOR,DESCRICAO,DTINICIAL_EVENTO,DTFINAL_EVENTO,DTREGISTRO) VALUES (?, ?, ?, ?, ?, ?, ?)

    '    'INSERT INTO  CANCELADOS ( ID_TRANSACAO, ID_PORTARIA) VALUES (?,?)

    '    'INSERT INTO ACESSOS (ID_TRANSACAO, ID_PORTARIA) VALUES (?,?)


    '    Me.btnExecutar.Text = "3 | Ok, Executar configurações ..."
    '    Me.btnExecutar.Enabled = True

    '    Me.setProgressBarSuper(0)
    '    Me.setProgressBarSub(0)
    'End Sub

    Private Sub frmCadClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    '    panel Grid
    'size: 727, 445
    'location : 0, 90

End Class