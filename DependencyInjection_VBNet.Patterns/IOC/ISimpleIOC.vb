Public Interface ISimpleIOC
    Sub Register(Of TResource)()
    Sub Register(Of TResource)(ByVal builder As Func(Of TResource))
    Sub Register(Of TResource, TInstance As TResource)()
    Sub Register(Of TResource, TInstance As TResource)(ByVal builder As Func(Of TInstance))
    Function GetResource(Of TResource)() As TResource
End Interface
