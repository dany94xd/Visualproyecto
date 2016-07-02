Public Class Sucursal
    Private nombre As String
    Private telefono As String
    Private direccion As String

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

    Public Sub New(nombre As String, telefono As String, direccion As String)
        Me.P_nombre = nombre
        Me.P_telefono = telefono
        Me.P_direccion = direccion
    End Sub
End Class
