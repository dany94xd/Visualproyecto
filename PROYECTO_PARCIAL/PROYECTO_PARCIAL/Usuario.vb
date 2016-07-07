Public Class Usuario
    Private user As String
    Private password As String
    Private nombre As String
    Private tipo As String

    Public Property P_user() As String
        Get
            Return Me.user
        End Get
        Set(ByVal value As String)
            Me.user = value
        End Set
    End Property

    Public Property P_password() As String
        Get
            Return Me.password
        End Get
        Set(ByVal value As String)
            Me.password = value
        End Set
    End Property

    Public Property P_nombre() As String
        Get
            Return Me.nombre
        End Get
        Set(ByVal value As String)
            Me.nombre = value
        End Set
    End Property

    Public Property P_tipo() As String
        Get
            Return Me.tipo
        End Get
        Set(ByVal value As String)
            Me.tipo = value
        End Set
    End Property

    Public Sub New(user As String, password As String, nombre As String, tipo As String)
        Me.P_user = user
        Me.P_password = password
        Me.P_nombre = nombre
        Me.P_tipo = tipo
    End Sub

    Public Sub New()
        'Me.P_user = ""
        'Me.P_password = ""
        'Me.P_nombre = ""
        'Me.P_tipo = ""
    End Sub
End Class
