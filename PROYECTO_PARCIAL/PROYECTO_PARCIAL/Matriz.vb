Public Class Matriz
    Private ruc As String
    Private nombre As String
    Private telefono As String
    Private direccion As String
    Private email As String

    Public Property P_ruc() As String
        Get
            Return Me.ruc
        End Get
        Set(ByVal value As String)
            Me.ruc = value
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

    Public Property P_telefono() As String
        Get
            Return Me.telefono
        End Get
        Set(ByVal value As String)
            Me.telefono = value
        End Set
    End Property

    Public Property P_direccion() As String
        Get
            Return Me.direccion
        End Get
        Set(ByVal value As String)
            Me.direccion = value
        End Set
    End Property

    Public Property P_email() As String
        Get
            Return Me.email
        End Get
        Set(ByVal value As String)
            Me.email = value
        End Set
    End Property
End Class
