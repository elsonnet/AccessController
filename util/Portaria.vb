Public Class Portaria
    Private _idPortaria As Integer
    Private _descricao As String

    Public Property IdPortaria() As Integer
        Get
            Return Me._idPortaria
        End Get
        Set(ByVal value As Integer)
            Me._idPortaria = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return Me._descricao
        End Get
        Set(ByVal value As String)
            Me._descricao = value
        End Set
    End Property
End Class
