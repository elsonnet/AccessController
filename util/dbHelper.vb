Public Class dbHelper

    'Public Shared Function getSqlServerToAccessDBType(ByVal dataType As System.Type) As OleDb.OleDbType
    '    If TypeOf dataType.BaseTy
    '    End If
    'End Function




    'UPDATE SGIAcessos SET ID_PORTARIA = ?, TICKETHASH  = ? , DT_ENTRADA  = ? , DT_SAIDA  = ? WHERE ID = ?

    'UPDATE  SGITransacoes SET  ID_PDV  = ?, ID_LOTE  = ?, ID_EQUIPAMENTO  = ?, ID_OPERADOR  = ?, ID_FORMAPAGAMENTO  = ?, TICKETHASH  = ?, REIMPRESSAO  = ?, TRANSACAO_NOK  = ?, CANCELADO  = ?, NSU  = ?, DTREGISTRO  = ? WHERE ID_TRANSACAO = ?

    'UPDATE SGIRelEvsAtsLts_Portarias SET  ID_PORTARIA  = ?, ID_EVENTO  = ?, ID_ATRACAO  = ?, ID_LOTE  = ?, DTINICIAL  = ?, DTFINAL  = ?, DT_REGISTRO  = ? WHERE ID = ?


    'INSERT INTO  SGITransacoes (ID_TRANSACAO, ID_PDV , ID_LOTE , ID_EQUIPAMENTO , ID_OPERADOR , ID_FORMAPAGAMENTO , TICKETHASH , REIMPRESSAO , TRANSACAO_NOK , CANCELADO , NSU , DTREGISTRO ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)

    'INSERT INTO  SGIRelEvsAtsLts_Portarias (ID, ID_PORTARIA , ID_EVENTO, ID_ATRACAO , ID_LOTE , DTINICIAL , DTFINAL , DT_REGISTRO ) VALUES ( ?, ?, ?, ?, ?, ?, ?, ?)

    'INSERT INTO  SGIAcessos (ID, ID_PORTARIA, TICKETHASH, DT_ENTRADA, DT_SAIDA ) VALUES (?, ?, ?, ?, ?)


    '#####################################################################################


    'UPDATE  SGIProdutores SET  ID_AFILIADO  = ?, ID_TPPESSOA  = ?, NOME_PRODUTOR  = ?, FANTASIA_PRODUTOR  = ?, RG_IE  = ?, CPF_CNPJ  = ?, DDD  = ?, TELEFONE  = ?, RAMAL  = ?, USUARIO  = ?, SENHA  = ?, ATIVO  = ?, SENHA_SANGRIA  = ?, DTREGISTRO  = ? WHERE ID_PRODUTOR = ?

    'UPDATE  SGIPortarias SET  ID_PRODUTOR  = ?, ID_EVENTO  = ?, DESCRICAO  = ?, SENHA  = ?, DTINICIAL  = ?, DTFINAL  = ?, DT_REGISTRO  = ? WHERE ID_PORTARIA = ?

    'UPDATE  SGILotes SET  ID_TPINGRESSO  = ?, ID_ATRACAO  = ?, QTDE  = ?, PRECO  = ?, DTINICIAL_LOTE  = ?, DTFINAL_LOTE  = ?, DESCRICAO  = ?, IS_BILHETERIA  = ?, DTREGISTRO  = ? WHERE ID_LOTE = ?

    'UPDATE  SGIAtracoes SET  ID_EVENTO  = ?, ID_TPGENERO  = ?, LOTACAO  = ?, LOCALIDADE  = ?, ENDERECO  = ?, CIDADE  = ?, UF  = ?, CLASSIFICACAO  = ?, DESCRICAO  = ?, DATAHORA  = ?, DTINICIAL_ATRACAO  = ?, DTFINAL_ATRACAO  = ?, DTREGISTRO  = ? WHERE ID_ATRACAO = ?

    'UPDATE  SGIEventos SET  ID_TPEVENTO  = ?, ID_PRODUTOR  = ?, DESCRICAO  = ?, DTINICIAL_EVENTO  = ?, DTFINAL_EVENTO  = ?, DTREGISTRO  = ? WHERE ID_EVENTO = ?

    'UPDATE  ACESSOS SET  ID_PORTARIA  = ?, DT_ENTRADA  = ?, ID_LOTE  = ?, TICKETHASH  = ?, DTREGISTRO  = ? WHERE ID_TRANSACAO=? AND ID_PORTARIA=0

    'UPDATE  CANCELADOS SET  ID_PORTARIA  = ?, ID_LOTE  =  ?, TICKETHASH  =  ?, CANCELADO  =  ?, DTREGISTRO  =  ? WHERE ID_TRANSACAO=? AND ID_PORTARIA=0



    'INSERT INTO  SGIProdutores (ID_PRODUTOR, ID_AFILIADO, ID_TPPESSOA, NOME_PRODUTOR, FANTASIA_PRODUTOR, RG_IE, CPF_CNPJ, DDD, TELEFONE, RAMAL, USUARIO, SENHA, ATIVO, SENHA_SANGRIA, DTREGISTRO ) VALUES (? , ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)

    'INSERT INTO  SGIPortarias (ID_PORTARIA, ID_PRODUTOR, ID_EVENTO, DESCRICAO, SENHA, DTINICIAL, DTFINAL, DT_REGISTRO) VALUES (? , ?, ?, ?, ?, ?, ?, ?)

    'INSERT INTO  SGILotes (ID_LOTE, ID_TPINGRESSO, ID_ATRACAO, QTDE, PRECO, DTINICIAL_LOTE, DTFINAL_LOTE, DESCRICAO, IS_BILHETERIA, DTREGISTRO ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)

    'INSERT INTO  SGIAtracoes (ID_ATRACAO, ID_EVENTO, ID_TPGENERO, LOTACAO, LOCALIDADE, ENDERECO, CIDADE, UF, CLASSIFICACAO, DESCRICAO, DATAHORA, DTINICIAL_ATRACAO, DTFINAL_ATRACAO, DTREGISTRO ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)

    'INSERT INTO  SGIEventos ( ID_EVENTO, ID_TPEVENTO, ID_PRODUTOR,DESCRICAO,DTINICIAL_EVENTO,DTFINAL_EVENTO,DTREGISTRO) VALUES (?, ?, ?, ?, ?, ?, ?)

    'INSERT INTO  CANCELADOS ( ID_TRANSACAO, ID_PORTARIA) VALUES (?,?)

    'INSERT INTO ACESSOS (ID_TRANSACAO, ID_PORTARIA) VALUES (?,?)













    Public Sub executeEventos()
        'faz chamada de webservice

        Dim dt As New DataTable()
        Dim cmd As New OleDb.OleDbCommand()

        'addParametersToCommand(cmd, dt)

        Dim i, iCount As Integer
        iCount = dt.Rows.Count
        For i = 0 To iCount - 1
            addValuesToParameters(cmd, dt, i)
            Dim ok As Integer = doInsertOrUpdate("commandTextUpDate", cmd)
            If ok <> 1 Then
                ok = doInsertOrUpdate("commandTextInsert", cmd)
            End If

            'atualizar progressbar
        Next


    End Sub

    Public Shared Sub addParametersToCommand(ByRef cmd As OleDb.OleDbCommand, ByVal dt As DataTable, ByVal pksUpdate() As String)
        Dim i, iCount As Integer
        iCount = dt.Columns.Count
        For i = 0 To iCount - 1
            cmd.Parameters.AddWithValue(dt.Columns(i).ColumnName, New Object())

            If Type.GetTypeCode(dt.Columns(i).DataType) = TypeCode.Boolean Then
                cmd.Parameters(dt.Columns(i).ColumnName).OleDbType = OleDb.OleDbType.Boolean
            ElseIf Type.GetTypeCode(dt.Columns(i).DataType) = TypeCode.DateTime Then
                cmd.Parameters(dt.Columns(i).ColumnName).OleDbType = OleDb.OleDbType.Date
            ElseIf Type.GetTypeCode(dt.Columns(i).DataType) = TypeCode.Decimal Then
                cmd.Parameters(dt.Columns(i).ColumnName).OleDbType = OleDb.OleDbType.Decimal
            ElseIf Type.GetTypeCode(dt.Columns(i).DataType) = TypeCode.Double Then
                cmd.Parameters(dt.Columns(i).ColumnName).OleDbType = OleDb.OleDbType.Double
            ElseIf Type.GetTypeCode(dt.Columns(i).DataType) = TypeCode.Int32 Then
                cmd.Parameters(dt.Columns(i).ColumnName).OleDbType = OleDb.OleDbType.Integer
            ElseIf Type.GetTypeCode(dt.Columns(i).DataType) = TypeCode.String Then
                cmd.Parameters(dt.Columns(i).ColumnName).OleDbType = OleDb.OleDbType.VarChar
            End If
        Next

        If pksUpdate.Length > 0 Then
            iCount = pksUpdate.Length
            For i = 0 To iCount - 1
                Dim param As New OleDb.OleDbParameter()
                param.ParameterName = cmd.Parameters(pksUpdate(i)).ParameterName
                param.OleDbType = cmd.Parameters(pksUpdate(i)).OleDbType
                param.Value = cmd.Parameters(pksUpdate(i)).Value

                cmd.Parameters.RemoveAt(pksUpdate(i))
                cmd.Parameters.Add(param)
            Next
        End If
    End Sub

    Public Shared Sub addValuesToParameters(ByRef cmd As OleDb.OleDbCommand, ByVal dt As DataTable, ByVal rowIndex As Integer)
        Dim i, iCount As Integer
        iCount = dt.Columns.Count
        For i = 0 To iCount - 1
            cmd.Parameters(i).Value = dt.Rows(rowIndex)(cmd.Parameters(i).ParameterName)
        Next
    End Sub

    Public Shared Function doInsertOrUpdate(ByVal commandText As String, ByVal cmd As OleDb.OleDbCommand) As Integer
        Dim result As Integer = 0
        Dim conn As New OleDb.OleDbConnection(getConnString())
        cmd.Connection = conn
        cmd.CommandText = commandText
        cmd.CommandType = CommandType.Text

        Try
            conn.Open()
            result = cmd.ExecuteNonQuery()
        Catch
            result = -1
        Finally
            conn.Close()
        End Try

        Return result
    End Function

    Public Shared Function doSelect(ByVal commandText As String, ByVal cmd As OleDb.OleDbCommand) As DataTable
        Dim dt As New DataTable
        Dim conn As New OleDb.OleDbConnection(getConnString())
        cmd.Connection = conn
        cmd.CommandText = commandText
        cmd.CommandType = CommandType.Text
        Dim da As New OleDb.OleDbDataAdapter(cmd)

        Try
            da.Fill(dt)
        Catch ex As Exception
            Throw ex
        End Try

        Return dt
    End Function
End Class
