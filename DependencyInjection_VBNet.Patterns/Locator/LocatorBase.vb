Public MustInherit Class LocatorBase
    Private ReadOnly _container As ISimpleIOC

    Protected ReadOnly Property Container As ISimpleIOC
        Get
            Return _container
        End Get
    End Property

    Protected Sub New(container As ISimpleIOC)
        _container = container
    End Sub

    Protected Sub New()
        Me.New(New SimpleIOC())
    End Sub

End Class
