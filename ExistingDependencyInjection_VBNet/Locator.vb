Imports ExistingDependencyInjection_VBNet.Patterns
Imports Microsoft.Extensions.DependencyInjection

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

    Public ReadOnly Property Singleton As Resource
        Get
            Return Container.GetService(Of Resource)()
        End Get
    End Property

    Protected Overrides Sub ConfigureService(serviceCollection As IServiceCollection)
        'Todo : Avec Microsoft.Extensions.DependencyInjection, Les dépendences doivent être passées par valeur obligatoirement
        serviceCollection.AddSingleton(Of Dependency)()
        serviceCollection.AddSingleton(Of Resource)()
    End Sub
End Class
