Public Class Provincia
    Private nombre As String
    Private sucursal As Sucursal

    Public Property P_nombre() As String
        Get
            Return Me.nombre
        End Get
        Set(ByVal value As String)
            Me.nombre = value
        End Set
    End Property

    Public Property P_sucursal() As Sucursal
        Get
            Return Me.sucursal
        End Get
        Set(ByVal value As Sucursal)
            Me.sucursal = value
        End Set
    End Property

    Public Sub New(nombre As String, sucursal As Sucursal)
        Me.P_nombre = nombre
        Me.P_sucursal = sucursal

    End Sub
End Class
