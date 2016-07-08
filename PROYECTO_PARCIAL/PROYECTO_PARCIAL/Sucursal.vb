Public Class Sucursal
    Private secSRI As String
    Private direccion As String

    Public Property P_secSRI() As String
        Get
            Return Me.secSRI
        End Get
        Set(ByVal value As String)
            Me.secSRI = value
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

    Public Sub New(secSRI As String, direccion As String)
        Me.P_secSRI = secSRI
        Me.P_direccion = direccion
    End Sub
End Class
