Public Class Resource
    Private ReadOnly _dependency As Dependency

    Public Sub New(ByVal dependency As Dependency)
        _dependency = dependency
    End Sub

    Public Sub DoSomething()
        _dependency.DoSomething()
    End Sub

End Class
