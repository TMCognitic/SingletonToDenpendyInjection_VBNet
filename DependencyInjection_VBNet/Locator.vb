Imports DependencyInjection_VBNet.Patterns

Public Class Locator
    Inherits LocatorBase

    Private Shared _instance As Locator
    Public Shared ReadOnly Property Instance As Locator
        Get
            If (_instance Is Nothing) Then
                _instance = New Locator()
            End If
            Return _instance
        End Get
    End Property

    Private _singleton As Resource

    Public ReadOnly Property Singleton As Resource
        Get
            Return Container.GetResource(Of Resource)()
        End Get
    End Property

    Private Sub New()
        Container.Register(Of Dependency)()
        Container.Register(Of Resource)()
    End Sub
End Class
