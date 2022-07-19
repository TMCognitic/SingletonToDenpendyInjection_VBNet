Imports Microsoft.Extensions.DependencyInjection

Public MustInherit Class LocatorBase
    Private ReadOnly _container As IServiceProvider

    Protected ReadOnly Property Container As IServiceProvider
        Get
            Return _container
        End Get
    End Property

    Protected Sub New()
        Dim serviceCollection As IServiceCollection = New ServiceCollection()
        ConfigureService(serviceCollection)
        _container = serviceCollection.BuildServiceProvider()
    End Sub

    Protected MustOverride Sub ConfigureService(serviceCollection As IServiceCollection)
End Class
