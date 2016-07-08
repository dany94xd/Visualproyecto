Public Class FormaPago
    Private nombre As String
    Private beneficio As Byte

    Public Property P_nombre() As String
        Get
            Return Me.nombre
        End Get
        Set(ByVal value As String)
            Me.nombre = value
        End Set
    End Property

    Public Property P_beneficio() As Byte
        Get
            Return Me.beneficio
        End Get
        Set(ByVal value As Byte)
            Me.beneficio = value
        End Set
    End Property

    Public Sub New(nombre As String, ben As Byte)
        Me.P_nombre = nombre
        Me.P_beneficio = ben
    End Sub
End Class
