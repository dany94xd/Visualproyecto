Module Module1

    Sub Main()
        Console.WriteLine("PROYECTO INICIALIZADO")

        Dim sistema As Sistema = New Sistema
        sistema.Administrar(sistema.P_administrador.Menu)

        Console.ReadLine()
    End Sub

End Module
