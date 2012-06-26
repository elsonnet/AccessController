Public Class Produtor
    Private _idProdutor As Integer
    Private _nomeProdutor As String
    Private _nomeUsuario As String


    Public Property IdProdutor() As Integer
        Get
            Return Me._idProdutor
        End Get
        Set(ByVal value As Integer)
            Me._idProdutor = value
        End Set
    End Property

    Public Property NomeProdutor() As String
        Get
            Return Me._nomeProdutor
        End Get
        Set(ByVal value As String)
            Me._nomeProdutor = value
        End Set
    End Property

    Public Property NomeUsuario() As String
        Get
            Return Me._nomeUsuario
        End Get
        Set(ByVal value As String)
            Me._nomeUsuario = value
        End Set
    End Property
End Class
