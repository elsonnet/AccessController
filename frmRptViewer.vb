Public Class frmRptViewer

    Private Sub frmRelatorio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' dsRelAcessos.AcceptChanges()
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class