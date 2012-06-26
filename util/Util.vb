Module Util
#Region "functions"
    'Public Sub fadeIn(ByVal form As Form)
    '    'Dim i As Double = 0

    '    'form.Opacity = 5
    '    'My.Application.DoEvents()

    '    'For i = 10 To 100
    '    '    form.Opacity = (i / 100)
    '    '    Threading.Thread.Sleep(10)
    '    '    My.Application.DoEvents()
    '    'Next
    'End Sub

    Public Function getDtCombo() As DataTable
        Dim dt As New DataTable()
        dt.Columns.AddRange(New DataColumn() {New DataColumn("id", GetType(Integer)), New DataColumn("descricao", GetType(String))})
        dt.AcceptChanges()
        Return dt
    End Function

    Public Function getDefaultComboDt(ByVal dtLoaded As DataTable) As DataTable
        'If dtLoaded.Rows.Count > 0 Then
        '    Return dtLoaded
        'End If

        dtLoaded.Rows.Add(New Object() {0, "  ----- Selecione um item -----"})
        dtLoaded.DefaultView.Sort = "descricao asc"
        dtLoaded.AcceptChanges()
        Return dtLoaded.DefaultView.Table
    End Function

    Function getConnString() As String
        Return System.Configuration.ConfigurationManager.AppSettings("AccessControllerDBConnectionString").ToString
    End Function

    Function getWebServiceUrl() As String
        Return System.Configuration.ConfigurationManager.AppSettings("ws").ToString
    End Function

#End Region
End Module
