Public Class Resource
    Private ReadOnly _dependency As Dependency

    'Todo : Avec Microsoft.Extensions.DependencyInjection, Les dépendences doivent être passées par valeur obligatoirement
    Public Sub New(dependency As Dependency)
        _dependency = dependency
    End Sub

    Public Sub DoSomething()
        _dependency.DoSomething()
    End Sub

End Class
