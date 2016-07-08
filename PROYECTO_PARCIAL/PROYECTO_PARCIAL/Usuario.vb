Imports System.Xml

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

    Public Sub New(forma As Byte)
        Me.P_user = ""
        Me.password = ""
        Me.P_nombre = ""
        Me.P_tipo = ""
    End Sub

    Public Sub New()
        Console.WriteLine("INSERTE LOS DATOS DEL NUEVO USUARIO")
        Console.Write("NOMBRE: ")
        Me.P_nombre = Console.ReadLine
        Console.Write("USER: ")
        Me.P_user = LCase(Console.ReadLine)
        Console.Write("PASSWORD: ")
        Me.P_password = LCase(Console.ReadLine)
        Console.Write("TIPO (ADMINISTRADOR o VENDEDOR): ")
        Me.P_tipo = UCase(Console.ReadLine)
    End Sub

    Public Sub Guardar()
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load("XML\CONFIGURACION\Usuarios.xml")
        Dim nodo As XmlElement
        Dim nodo_hijo As XmlNode
        Dim escriba As XmlNode

        escriba = xmlDoc.DocumentElement

        nodo = xmlDoc.CreateElement("usuario")
        nodo.SetAttribute("user", "", Me.P_user)
        nodo.SetAttribute("pass", "", Me.P_password)
        nodo_hijo = xmlDoc.CreateElement("nombre")
        nodo_hijo.InnerText = Me.P_nombre
        nodo.AppendChild(nodo_hijo)
        nodo_hijo = xmlDoc.CreateElement("tipo")
        nodo_hijo.InnerText = Me.P_tipo
        nodo.AppendChild(nodo_hijo)

        escriba.AppendChild(nodo)
        xmlDoc.Save("XML\CONFIGURACION\Usuarios.xml")
        MsgBox("USUARIO GUARDADO")
    End Sub
End Class
