Public Class impuesto
    Private idImpuesto As Byte
    Private nombre As String
    Private porcentaje As Double

    Public Property P_idImpuesto() As Byte
        Get
            Return Me.idImpuesto
        End Get
        Set(ByVal value As Byte)
            Me.idImpuesto = value
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

    Public Property P_porcentaje() As Double
        Get
            Return Me.porcentaje
        End Get
        Set(ByVal value As Double)
            Me.porcentaje = value
        End Set
    End Property
End Class
