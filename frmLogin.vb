Public Class frmLogin

    Private _isAllowed As Boolean = False
    Private _isRemoteConnection As Boolean = False
    Private _produtor As Produtor
    Private _portaria As Portaria

#Region "properties"
    Public ReadOnly Property isAllowed() As Boolean
        Get
            Return Me._isAllowed
        End Get
    End Property

    Public ReadOnly Property isRemoteConnection() As Boolean
        Get
            Return Me._isRemoteConnection
        End Get
    End Property

    Public ReadOnly Property Produtor() As Produtor
        Get
            Return Me._produtor
        End Get
    End Property

    Public ReadOnly Property Portaria() As Portaria
        Get
            Return Me._portaria
        End Get
    End Property
#End Region

#Region "functions"
    Private Sub loginLocalMode()
        Me.txtOperador.Visible = True
        Me.ddlEstabelecimento.Visible = False
        Me.UsernameLabel.Text = "Produtor"
        If My.Settings.ProdutorLogin <> "" Then
            Me.txtOperador.Text = My.Settings.ProdutorLogin
        End If
    End Sub

    Private Sub loginRemotoMode()
        Me.chkLoginPortaria.Checked = False
        Me.chkLoginPortaria.Enabled = False
        Me.txtOperador.Visible = True
        Me.ddlEstabelecimento.Visible = False
        Me.UsernameLabel.Text = "Produtor"
        If My.Settings.ProdutorLogin <> "" Then
            Me.txtOperador.Text = My.Settings.ProdutorLogin
        End If
    End Sub

    Private Sub loginPortariaMode()
        Me.chkLoginPortaria.Checked = True
        Me.chkLoginPortaria.Enabled = True
        Me.txtOperador.Visible = False
        Me.ddlEstabelecimento.Visible = True
        Me.UsernameLabel.Text = "Portaria"
    End Sub

    Private Sub loadPortarias()
        Dim dt As DataTable = Util.getDtCombo()
        Dim cmd As New OleDb.OleDbCommand()
        Try
            dt = dbHelper.doSelect("SELECT ID_PORTARIA AS id, DESCRICAO FROM SGIPortarias", cmd)
        Catch ex As Exception
            Throw ex
        End Try

        dt = Util.getDefaultComboDt(dt)

        Me.ddlEstabelecimento.ValueMember = "id"
        Me.ddlEstabelecimento.DisplayMember = "descricao"
        Me.ddlEstabelecimento.DataSource = dt
    End Sub
#End Region

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        'Login remoto
        If Me.chkLoginRemoto.Checked Then
            If Me.txtOperador.Text.Trim = "" Then
                MsgBox("Por favor, informe seu nome de usuário!")
                Exit Sub
            End If

            If Me.txtSenha.Text.Trim = "" Then
                MsgBox("Por favor, informe sua senha!")
                Exit Sub
            End If

            Dim ws As New wsChamadas.kkk()
            ws.Url = Util.getWebServiceUrl()
            Me._produtor = New Produtor()
            Me._produtor.NomeUsuario = Me.txtOperador.Text.Trim

            My.Settings.ProdutorLogin = Me.txtOperador.Text
            My.Settings.Save()
            Try
                If ws.remotoProdutor(Me.txtOperador.Text.Trim, Security.getHashOf(Me.txtSenha.Text), Me._produtor.NomeProdutor, Me._produtor.IdProdutor) Then
                    Me._isAllowed = True
                Else
                    MsgBox("Senha inválida!")
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            Me._isRemoteConnection = True
        Else
            'Login local portaria
            If Me.chkLoginPortaria.Checked Then
                If Me.ddlEstabelecimento.SelectedValue = 0 Then
                    MsgBox("Nenhuma portaria foi configurada no sistema ainda! Por favor contade o produtor do evento.")
                    Exit Sub
                End If

                If Me.txtSenha.Text.Trim = "" Then
                    MsgBox("Por favor, informe sua senha!")
                    Exit Sub
                End If

                Dim dt As DataTable
                Dim cmd As New OleDb.OleDbCommand()
                cmd.Parameters.AddWithValue("ID_PORTARIA", Me.ddlEstabelecimento.SelectedValue)
                cmd.Parameters.AddWithValue("SENHA", Me.txtSenha.Text)
                Try
                    dt = dbHelper.doSelect("SELECT * FROM SGIPortarias WHERE ID_PORTARIA=? AND SENHA=?", cmd)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try

                If dt.Rows.Count > 0 Then
                    Me._portaria = New Portaria
                    Me._portaria.IdPortaria = Me.ddlEstabelecimento.SelectedValue
                    Me._portaria.Descricao = dt.Rows(0).Item("DESCRICAO").ToString
                    Me._isAllowed = True
                Else
                    MsgBox("Senha inválida!")
                    Exit Sub
                End If
            Else
                'Login local produtor
                If Me.txtOperador.Text.Trim = "" Then
                    MsgBox("Por favor, informe seu nome de usuário!")
                    Exit Sub
                End If

                If Me.txtSenha.Text.Trim = "" Then
                    MsgBox("Por favor, informe sua senha!")
                    Exit Sub
                End If

                My.Settings.ProdutorLogin = Me.txtOperador.Text
                My.Settings.Save()

                Dim dt As DataTable
                Dim cmd As New OleDb.OleDbCommand()
                cmd.Parameters.AddWithValue("USUARIO", Me.txtOperador.Text.Trim)
                cmd.Parameters.AddWithValue("SENHA", Security.getHashOf(Me.txtSenha.Text))
                Try
                    dt = dbHelper.doSelect("SELECT * FROM SGIProdutores WHERE USUARIO=? AND SENHA=?", cmd)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try


                If dt.Rows.Count > 0 Then
                    Me._produtor = New Produtor()
                    Me._produtor.IdProdutor = dt.Rows(0).Item("ID_PRODUTOR")
                    Me._produtor.NomeProdutor = dt.Rows(0).Item("FANTASIA_PRODUTOR")
                    Me._produtor.NomeUsuario = Me.txtOperador.Text.Trim
                    Me._isAllowed = True
                Else
                    MsgBox("Senha inválida!")
                    Exit Sub
                End If
            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtOperador.Focus()

        Try
            Me.loadPortarias()
        Catch ex As Exception
            MsgBox(ex)
        End Try

        'Util.fadeIn(Me)
    End Sub

    Private Sub chkLoginRemoto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.chkLoginRemoto.Checked Then
            Me.loginRemotoMode()
        Else
            Me.loginPortariaMode()
        End If
    End Sub

    Private Sub chkLoginPortaria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.chkLoginPortaria.Checked Then
            Me.loginPortariaMode()
        Else
            Me.loginLocalMode()
        End If
    End Sub
End Class
