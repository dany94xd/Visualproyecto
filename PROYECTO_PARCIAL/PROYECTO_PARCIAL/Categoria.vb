Imports System.Xml

Public Class Categoria
    Private nombre As String
    Private descripcion As String
    Private articulos As ArrayList

    Public Property P_nombre() As String
        Get
            Return Me.nombre
        End Get
        Set(ByVal value As String)
            Me.nombre = value
        End Set
    End Property

    Public Property P_descripcion() As String
        Get
            Return Me.descripcion
        End Get
        Set(ByVal value As String)
            Me.descripcion = value
        End Set
    End Property

    Public Property P_articulos() As ArrayList
        Get
            Return Me.articulos
        End Get
        Set(ByVal value As ArrayList)
            Me.articulos = value
        End Set
    End Property

    Public Sub New()
        Me.P_nombre = ""
        Me.P_descripcion = ""
        Me.P_articulos = New ArrayList
    End Sub

    Public Sub Cargar_Articulos(categoria As String)
        Dim patch As String = "XML\ARTICULOS\" + categoria + ".xml"
        Console.WriteLine(patch)
        'CARGA DESDE CATEGORIAS.XML
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(patch)
        Dim lista_articulo As XmlNodeList = xmlDoc.GetElementsByTagName("articulo")
        For Each articulo As XmlNode In lista_articulo
            Dim artic As Articulo = New Articulo
            For Each detalleArticulo As XmlNode In articulo
                Select Case detalleArticulo.Name
                    Case "codigo"
                        artic.P_codigo = CStr(detalleArticulo.InnerText)
                    Case "nombre"
                        artic.P_nombre = CStr(detalleArticulo.InnerText)
                    Case "precio"
                        artic.P_precio = CDbl(detalleArticulo.InnerText)
                    Case "pagoIva"
                        artic.P_pagoIva = CStr(detalleArticulo.InnerText)
                End Select
            Next
            Me.P_articulos.Add(artic)
        Next
        'categ.Listar_Articulos()
        'Me.P_categorias.Item(index) = categ
    End Sub

    Public Sub Listar_Articulos()
        Console.WriteLine(vbTab & "CODPROD" & vbTab & vbTab & "DESCRIPCION" & vbTab & vbTab & "PRECIO")
        For Each articulo As Articulo In Me.P_articulos
            articulo.Mostrar_Datos()
        Next
    End Sub

    Public Function Consultar_Articulo(codigo As String) As Articulo
        Dim articulo As Articulo = New Articulo
        'Console.WriteLine("DENTRO DE CONSULTA X CODIGO")
        For Each artic As Articulo In Me.P_articulos
            If codigo = artic.P_codigo Then
                'Console.WriteLine(artic.P_nombre)
                articulo = artic
                Return articulo
            End If
        Next
        Return articulo
    End Function
End Class
