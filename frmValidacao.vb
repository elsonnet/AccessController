Public Class frmValidacao

    Private Delegate Sub delAtualizaProgressBar(ByVal value As Integer, ByVal resto As Integer)

#Region "functions"
    Private Function validar(ByVal ticket As String) As Integer
        Dim result As Integer = 0
        Dim cmd As New OleDb.OleDbCommand()
        cmd.Parameters.AddWithValue("DT_ENTRADA", Now)
        cmd.Parameters.AddWithValue("TICKETHASH", ticket)
        cmd.Parameters.AddWithValue("ID_PORTARIA", DirectCast(Me.Owner, frmMain)._portaria.IdPortaria)
        cmd.Parameters("TICKETHASH").OleDbType = OleDb.OleDbType.VarChar
        cmd.Parameters("DT_ENTRADA").OleDbType = OleDb.OleDbType.Date
        cmd.Parameters("ID_PORTARIA").OleDbType = OleDb.OleDbType.Integer

        Try
            result = dbHelper.doInsertOrUpdate("UPDATE  ACESSOS SET DT_ENTRADA  = ?, ENTROU=1 WHERE TICKETHASH=? AND ID_PORTARIA=? AND ENTROU=0", cmd)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'SELECT COUNT(*) FROM ACESSOS WHERE ID_PORTARIA=? AND ENTROU=0

        'SELECT COUNT(*) FROM ACESSOS WHERE ID_PORTARIA=? AND ENTROU=1

        Return result
    End Function

    Private Function getEntrou() As Integer
        Dim result As Integer = 0
        Try
            Dim cmd As New OleDb.OleDbCommand()
            cmd.Parameters.AddWithValue("ID_PORTARIA", DirectCast(Me.Owner, frmMain)._portaria.IdPortaria)
            cmd.Parameters("ID_PORTARIA").OleDbType = OleDb.OleDbType.Integer
            result = dbHelper.doSelect("SELECT COUNT(*) FROM ACESSOS WHERE ID_PORTARIA=? AND ENTROU=1", cmd).Rows(0)(0)
        Catch ex As Exception
            result = 0
        End Try

        Return result
    End Function

    Private Function getNaoEntrou() As Integer
        Dim result As Integer = 0
        Try
            Dim cmd As New OleDb.OleDbCommand()
            cmd.Parameters.AddWithValue("ID_PORTARIA", DirectCast(Me.Owner, frmMain)._portaria.IdPortaria)
            cmd.Parameters("ID_PORTARIA").OleDbType = OleDb.OleDbType.Integer
            result = dbHelper.doSelect("SELECT COUNT(*) FROM ACESSOS WHERE ID_PORTARIA=? AND ENTROU=0", cmd).Rows(0)(0)
        Catch ex As Exception
            result = 0
        End Try

        Return result
    End Function

    Private Sub okMode()
        Me.lblResult.Text = "OK!"
        Me.Panel1.BackColor = Color.Green
    End Sub

    Private Sub nokMode()
        Me.lblResult.Text = "OPS!"
        Me.Panel1.BackColor = Color.Red
    End Sub

    Private Sub clearMode()
        Me.lblResult.Text = ""
        Me.txtValidacao.Text = ""
        Me.txtValidacao.Focus()
        Me.Panel1.BackColor = Color.FromName("Control")
    End Sub

    Private Sub atualizaProgressBar(ByVal value As Integer, ByVal resto As Integer)
        Me.ProgressBar.Value = value

        If resto = 0 Then
            Me.Text = "Sistema Inteligente de Validação de Ingressos | 100%"
        End If
    End Sub

    Private Sub loadDataToProgressBar()
        Dim entrou As Integer = Me.getEntrou()
        Dim naoEntrou As Integer = Me.getNaoEntrou()
        Me.Invoke(New delAtualizaProgressBar(AddressOf atualizaProgressBar), New Object() {CInt(((entrou / naoEntrou) * 100)), naoEntrou})
    End Sub

    Private Function isValidTicketHash(ByVal ticketHash As String) As Boolean
        '//resgata primeira posição
        Dim firstNumber As Integer = CInt(Me.txtValidacao.Text.Substring(0, 1))

        '//resgata digito verificar para comparacao
        Dim dvTicketHash As String = CInt(ticketHash.Substring(16 - 1 - firstNumber, 1))
        '//faz comparação de digito verificador

        Return dvTicketHash = Me.getCalcDv(ticketHash.Remove(16 - 1 - firstNumber, 1))
    End Function

    Private Function getCalcDv(ByVal ticketHash As String) As String
        'declara as variáveis
        Dim intContador As Integer
        Dim intNumero As Integer
        Dim intTotalNumero As Integer
        Dim intMultiplicador As Integer
        Dim intResto As Integer

        'inicia o multiplicador
        intMultiplicador = 9

        'pega cada caracter do numero a partir da direita
        For intContador = Len(ticketHash) To 1 Step -1

            'extrai o caracter e multiplica prlo multiplicador
            intNumero = Val(Mid(ticketHash, intContador, 1)) * intMultiplicador

            'soma o resultado para totalização
            intTotalNumero = intTotalNumero + intNumero

            'se o multiplicador for maior que 2 decrementa-o caso contrario atribuir valor padrao original
            intMultiplicador = IIf(intMultiplicador > 2, intMultiplicador - 1, 9)

        Next

        'calcula o resto da divisao do total por 11
        intResto = intTotalNumero Mod 11

        'verifica as exceções ( 0 -> DV=0    10 -> DV=X (para o BB) e retorna o DV
        Select Case intResto
            Case 0
                Return "0"
            Case 10
                Return "0"
            Case Else
                Return intResto.ToString
        End Select
    End Function
#End Region

    Private Sub frmValidacao_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmValidacao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.clearMode()
    End Sub

    Private Sub txtValidacao_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValidacao.KeyPress
        If e.KeyChar = Chr(13) Then
            If Me.validar(Me.txtValidacao.Text.Trim) = 1 Then
                Me.Timer2.Enabled = True
                Me.okMode()
            Else
                'Por qual motivo?

                'verifica se codigo bar é numerico
                If Not IsNumeric(Me.txtValidacao.Text.Trim) Then
                    Me.Timer2.Enabled = True
                    Me.nokMode()
                    MsgBox("CÓDIGO DE BARRA INVÁLIDO!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                '//define se codbar contém 16 digitos
                If Not (Me.txtValidacao.Text.Trim.Length = 16) Then
                    Me.Timer2.Enabled = True
                    Me.nokMode()
                    MsgBox("CÓDIGO DE BARRA INCOMPLETO!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                '//define se dv é válido
                If Not Me.isValidTicketHash(Me.txtValidacao.Text.Trim) Then
                    Me.Timer2.Enabled = True
                    Me.nokMode()
                    MsgBox("ESTE INGRESSO É INVÁLIDO! NÃO PASSOU NO TESTE DE SEGURANÇA ELETRÔNICA!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                '//define se ingresso foi cancelado
                Dim dt1 As DataTable
                Dim cmd1 As New OleDb.OleDbCommand()
                cmd1.Parameters.AddWithValue("ID_PORTARIA", DirectCast(Me.Owner, frmMain)._portaria.IdPortaria)
                cmd1.Parameters.AddWithValue("TICKETHASH", Me.txtValidacao.Text.Trim)
                Try
                    dt1 = dbHelper.doSelect("SELECT * FROM CANCELADOS WHERE ID_PORTARIA=? AND TICKETHASH=?", cmd1)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try

                If dt1.Rows.Count > 0 Then
                    Me.Timer2.Enabled = True
                    Me.nokMode()
                    MsgBox("ESTE INGRESSO FOI CANCELADO!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                '//define se ingresso conta no sistema
                Dim dt2 As DataTable
                Dim cmd2 As New OleDb.OleDbCommand()
                cmd2.Parameters.AddWithValue("ID_PORTARIA", DirectCast(Me.Owner, frmMain)._portaria.IdPortaria)
                cmd2.Parameters.AddWithValue("TICKETHASH", Me.txtValidacao.Text.Trim)
                Try
                    dt2 = dbHelper.doSelect("SELECT * FROM ACESSOS WHERE ID_PORTARIA=? AND TICKETHASH=? AND ENTROU=1", cmd2)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try

                If dt2.Rows.Count > 0 Then
                    Me.Timer2.Enabled = True
                    Me.nokMode()
                    MsgBox("ESTE INGRESSO JÁ OBTEVE ACESSO AO EVENTO!", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    Me.Timer2.Enabled = True
                    Me.nokMode()
                    MsgBox("ESTE INGRESSO NÃO CONSTA/EXISTE NO SISTEMA!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim t As New Threading.Thread(AddressOf loadDataToProgressBar)
        t.Start()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.clearMode()
        Me.Timer2.Enabled = False
    End Sub
End Class