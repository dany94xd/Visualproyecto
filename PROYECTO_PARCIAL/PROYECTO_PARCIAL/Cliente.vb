Public Class Cliente
    Private idCliente As Integer
    Private numeroDocumento As String
    Private nombre As String
    Private telefono As String
    Private direccion As String
    Private email As String

    Public Property P_idCliente() As Integer
        Get
            Return Me.idCliente
        End Get
        Set(ByVal value As Integer)
            Me.idCliente = value
        End Set
    End Property

    Public Property P_numeroDocumento() As String
        Get
            Return Me.numeroDocumento
        End Get
        Set(ByVal value As String)
            Me.numeroDocumento = value
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

    Public Sub New()
        Me.P_idCliente = 0
        Me.P_numeroDocumento = ""
        Me.P_nombre = ""
        Me.P_telefono = ""
        Me.P_direccion = ""
        Me.P_email = ""
    End Sub
End Class
