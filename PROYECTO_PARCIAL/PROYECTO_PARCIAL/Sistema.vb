Imports System.Xml

Public Class Sistema
    Private administrador As Administrador
    Private categorias As ArrayList
    Dim categ As Categoria 'auxiliar de categorias

    Public Property P_administrador() As Administrador
        Get
            Return Me.administrador
        End Get
        Set(ByVal value As Administrador)
            Me.administrador = value
        End Set
    End Property

    Public Property P_categorias() As ArrayList
        Get
            Return Me.categorias
        End Get
        Set(ByVal value As ArrayList)
            Me.categorias = value
        End Set
    End Property

    'Public Sub New()
    '    Me.administrador = New Administrador
    '    Me.Administrar(administrador.Menu)
    'End Sub

    Public Sub Administrar(opc As Byte)

        Select Case opc
            Case 1
                Dim index As Byte = 1
                Dim i As Byte = 1
                Me.Cargar_Categorias()
                Console.WriteLine("ESCRIBA EL INDICE DE LA CATEGORIA")
                For Each categoria As Categoria In P_categorias
                    Console.WriteLine(i & ".- " & categoria.P_nombre)
                    i = i + 1
                Next
                index = Console.ReadLine()
                Me.Cargar_Articulos_Categoria(index - 1)
                Me.categ = Me.P_categorias.Item(index - 1)
                Me.categ.Listar_Articulos()
        End Select

    End Sub

    Public Sub Cargar_Categorias()
        Dim patch As String = "XML\ARTICULOS\Categorias.xml"
        'CARGA DESDE CATEGORIAS.XML
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(patch)
        Dim lista_categorias As XmlNodeList = xmlDoc.GetElementsByTagName("categoria")
        For Each categoria As XmlNode In lista_categorias
            Dim categ As Categoria = New Categoria
            categ.P_nombre = categoria.Attributes(0).Value
            For Each detalleCategoria As XmlNode In categoria
                Select Case detalleCategoria.Name
                    Case "descripcion"
                        categ.P_descripcion = CStr(detalleCategoria.InnerText)
                End Select
            Next
            Me.P_categorias.Add(categ)
        Next
    End Sub

    Public Sub Cargar_Articulos_Categoria(index As Byte)
        categ = Me.P_categorias.Item(index)
        Dim patch As String = "XML\ARTICULOS\" + categ.P_nombre + ".xml"
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
            Me.categ.P_articulos.Add(artic)
        Next
        'categ.Listar_Articulos()
        Me.P_categorias.Item(index) = categ
    End Sub

    Public Sub New()
        Me.P_administrador = New Administrador
        Me.P_categorias = New ArrayList
    End Sub
End Class
