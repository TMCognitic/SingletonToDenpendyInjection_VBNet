Imports System.Reflection

Public Class SimpleIOC
    Implements ISimpleIOC

    Private _instances As Dictionary(Of Type, Object)
    Private _builders As Dictionary(Of Type, Func(Of Object))
    Private _mappers As Dictionary(Of Type, Type)

    Public Sub New()
        _instances = New Dictionary(Of Type, Object)
        _builders = New Dictionary(Of Type, Func(Of Object))
        _mappers = New Dictionary(Of Type, Type)
    End Sub

    Public Sub Register(Of TResource)() Implements ISimpleIOC.Register
        _instances.Add(GetType(TResource), Nothing)
    End Sub

    Public Sub Register(Of TResource)(builder As Func(Of TResource)) Implements ISimpleIOC.Register
        Register(Of TResource)()
        _builders.Add(GetType(TResource), Function() As Object
                                              Return builder()
                                          End Function)
    End Sub

    Public Sub Register(Of TResource, TInstance As TResource)() Implements ISimpleIOC.Register
        Register(Of TResource)()
        _mappers.Add(GetType(TResource), GetType(TInstance))
    End Sub

    Public Sub Register(Of TResource, TInstance As TResource)(builder As Func(Of TInstance)) Implements ISimpleIOC.Register
        Register(Of TResource)()
        _builders.Add(GetType(TResource), Function() As Object
                                              Return builder()
                                          End Function)
    End Sub

    Function GetResource(Of TResource)() As TResource Implements ISimpleIOC.GetResource
        Dim resourceType As Type = GetType(TResource)
        If (_instances(resourceType) Is Nothing) Then
            _instances(resourceType) = Resolve(resourceType)
        End If

        Return CType(_instances(resourceType), TResource)
    End Function

    Private Function Resolve(ByVal resourceType As Type) As Object
        'Récupère et exécute la fonction de création si elle existe
        If (_builders.ContainsKey(resourceType)) Then
            Return _builders(resourceType).Invoke()
        End If

        'Récupère le type réel à instancier si un super type est utilisé pour la déclaration
        If (_mappers.ContainsKey(resourceType)) Then
            resourceType = _mappers(resourceType)
        End If

        'Récupère l'unique constructeur sans paramètre et l'exécute s'il existe
        Dim constructor As ConstructorInfo = resourceType.GetConstructors().SingleOrDefault()
        If (Not (constructor Is Nothing)) Then
            If (constructor.GetParameters().Length > 0) Then
                Throw New InvalidOperationException($"Only parameter less constructor are valid at this time.")
            End If
            Return constructor.Invoke(Nothing)
        End If

        'Récupère la propriété Shared 'Instance' et récupère la valeur si elle existe
        Dim instanceProperty As PropertyInfo = resourceType.GetProperty("Instance", BindingFlags.Public Or BindingFlags.Static)
        If (Not (instanceProperty Is Nothing)) Then
            Return instanceProperty.GetMethod.Invoke(Nothing, Nothing)
        End If

        'Récupère le champs Shared 'Instance' et récupère la valeur s'il existe
        Dim instanceField As FieldInfo = resourceType.GetField("Instance", BindingFlags.Public Or BindingFlags.Static)
        If (Not (instanceField Is Nothing)) Then
            Return instanceField.GetValue(Nothing)
        End If

        'Si rien n'a fonctionné lève une exception
        Throw New InvalidOperationException($"Can't resolve '{resourceType.Name}' Type.")
    End Function
End Class
