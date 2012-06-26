Imports System.Windows.Forms

Public Class frmMain

    Public _produtor As Produtor
    Public _portaria As Portaria
    Private _isRemoteConnection As Boolean = False
    Private _frmValidacao As frmValidacao
    Private _frmRelatorio As frmRelatorio
    Private _frmConfiguracao As frmCadClientes
    Private _frmLimpaDados As frmLimpaDados

    'Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
    '    ' Create a new instance of the child form.
    '    'Dim ChildForm As New System.Windows.Forms.Form
    '    '' Make it a child of this MDI form before showing it.
    '    'ChildForm.MdiParent = Me

    '    'm_ChildFormNumber += 1
    '    'ChildForm.Text = "Window " & m_ChildFormNumber

    '    'ChildForm.Show()
    'End Sub

    'Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim OpenFileDialog As New OpenFileDialog
    '    OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    '    OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
    '    If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
    '        Dim FileName As String = OpenFileDialog.FileName
    '        ' TODO: Add code here to open the file.
    '    End If
    'End Sub

    'Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim SaveFileDialog As New SaveFileDialog
    '    SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    '    SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

    '    If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
    '        Dim FileName As String = SaveFileDialog.FileName
    '        ' TODO: Add code here to save the current contents of the form to a file.
    '    End If
    'End Sub

    'Private Sub openForm(ByVal form As Form)
    '    Dim isIn As Boolean = False
    '    For Each ChildForm As Form In Me.MdiChildren
    '        isIn = GetType(ChildForm) Is GetType(Form)
    '    Next

    'End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    'Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    'End Sub

    'Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    'End Sub

    'Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    'End Sub

    'Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    'End Sub

    'Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    'End Sub

    'Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.LayoutMdi(MdiLayout.Cascade)
    'End Sub

    'Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.LayoutMdi(MdiLayout.TileVertical)
    'End Sub

    'Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.LayoutMdi(MdiLayout.TileHorizontal)
    'End Sub

    'Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.LayoutMdi(MdiLayout.ArrangeIcons)
    'End Sub

    'Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    ' Close all child forms of the parent.
    '    For Each ChildForm As Form In Me.MdiChildren
    '        ChildForm.Close()
    '    Next
    'End Sub

    Private m_ChildFormNumber As Integer

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim frmPai As frmSplashScreen = DirectCast(Me.Owner, frmSplashScreen)
        Me._produtor = frmPai.produtor
        Me._portaria = frmPai.portaria
        Me._isRemoteConnection = frmPai._isRemoteConnection

        If Me._produtor Is Nothing Then
            ToolStrip.Items.Remove(Me.btnRelatorio)
            ToolStrip.Items.Remove(Me.btnConfig)
            ToolStrip.Items.Remove(Me.btnLimparDB)
        Else
            If Me._isRemoteConnection Then
                ToolStrip.Items.Remove(Me.btnValidacao)
                ToolStrip.Items.Remove(Me.btnRelatorio)
            Else
                ToolStrip.Items.Remove(Me.btnValidacao)
                ToolStrip.Items.Remove(Me.btnConfig)
                ToolStrip.Items.Remove(Me.btnLimparDB)
            End If
        End If
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me._produtor Is Nothing Then
            Me.lblWelcome.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss} | Bem-vindo " + Me._portaria.Descricao, Now)
        Else
            Me.lblWelcome.Text = String.Format("{0:dd/MM/yyyy HH:mm:ss} | Bem-vindo " + Me._produtor.NomeProdutor, Now)
        End If
    End Sub

    Private Sub btnValidacao_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidacao.Click
        If Me._frmValidacao Is Nothing Then
            Me._frmValidacao = New frmValidacao()
            Me._frmValidacao.Show(Me)
        ElseIf Me._frmValidacao.IsDisposed Then
            Me._frmValidacao = New frmValidacao()
            Me._frmValidacao.Show(Me)
        Else
            Me._frmValidacao.WindowState = FormWindowState.Maximized
            Me._frmValidacao.BringToFront()
        End If
    End Sub

    Private Sub btnRelatorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelatorio.Click
        If Me._frmRelatorio Is Nothing Then
            Me._frmRelatorio = New frmRelatorio()
            Me._frmRelatorio.MdiParent = Me
            Me._frmRelatorio.Show()
        ElseIf Me._frmRelatorio.IsDisposed Then
            Me._frmRelatorio = New frmRelatorio()
            Me._frmRelatorio.MdiParent = Me
            Me._frmRelatorio.Show()
        Else
            Me._frmRelatorio.WindowState = FormWindowState.Normal
            Me._frmRelatorio.BringToFront()
        End If
    End Sub

    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.Click
        If Me._frmConfiguracao Is Nothing Then
            Me._frmConfiguracao = New frmCadClientes()
            Me._frmConfiguracao.MdiParent = Me
            Me._frmConfiguracao.Show()
        ElseIf Me._frmConfiguracao.IsDisposed Then
            Me._frmConfiguracao = New frmCadClientes()
            Me._frmConfiguracao.MdiParent = Me
            Me._frmConfiguracao.Show()
        Else
            Me._frmConfiguracao.WindowState = FormWindowState.Normal
            Me._frmConfiguracao.BringToFront()
        End If
    End Sub

    Private Sub btnLimparDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimparDB.Click
        'If Me._frmLimpaDados Is Nothing Then
        '    Me._frmLimpaDados = New frmLimpaDados()
        '    Me._frmLimpaDados.MdiParent = Me
        '    Me._frmLimpaDados.Show()
        'ElseIf Me._frmLimpaDados.IsDisposed Then
        '    Me._frmLimpaDados = New frmLimpaDados()
        '    Me._frmLimpaDados.MdiParent = Me
        '    Me._frmLimpaDados.Show()
        'Else
        '    Me._frmLimpaDados.WindowState = FormWindowState.Normal
        '    Me._frmLimpaDados.BringToFront()
        'End If

        If MsgBox("Todos os dados armazenados no serão perdidos, tem certeza de que deseja continuar?", MsgBoxStyle.YesNoCancel, "Atenção!!!") = MsgBoxResult.Yes Then

            'Produtores
            Try
                Dim cmd As New OleDb.OleDbCommand()
                dbHelper.doInsertOrUpdate("DELETE FROM SGIProdutores", cmd)
            Catch 
            End Try

            Application.DoEvents()

            'Portarias
            Try
                Dim cmd As New OleDb.OleDbCommand()
                dbHelper.doInsertOrUpdate("DELETE FROM SGIPortarias", cmd)
            Catch
            End Try

            Application.DoEvents()

            'Eventos
            Try
                Dim cmd As New OleDb.OleDbCommand()
                dbHelper.doInsertOrUpdate("DELETE FROM SGIEventos", cmd)
            Catch 
            End Try

            Application.DoEvents()

            'Atracoes
            Try
                Dim cmd As New OleDb.OleDbCommand()
                dbHelper.doInsertOrUpdate("DELETE FROM SGIAtracoes", cmd)
            Catch 
            End Try

            Application.DoEvents()

            'Lotes
            Try
                Dim cmd As New OleDb.OleDbCommand()
                dbHelper.doInsertOrUpdate("DELETE FROM SGILotes", cmd)
            Catch 
            End Try

            Application.DoEvents()

            'Cancelados
            Try
                Dim cmd As New OleDb.OleDbCommand()
                dbHelper.doInsertOrUpdate("DELETE FROM CANCELADOS", cmd)
            Catch
            End Try

            Application.DoEvents()

            'Acessos
            Try
                Dim cmd As New OleDb.OleDbCommand()
                dbHelper.doInsertOrUpdate("DELETE FROM ACESSOS", cmd)
            Catch
            End Try

            Application.DoEvents()

            MsgBox("Operação de limpeza realizada com sucesso!")
        End If
    End Sub
End Class
