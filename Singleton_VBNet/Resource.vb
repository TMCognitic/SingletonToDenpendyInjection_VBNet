Public Class Resource
    Private Shared _instance As Resource
    Public Shared ReadOnly Property Instance As Resource
        Get
            If (_instance Is Nothing) Then
                _instance = New Resource()
            End If
            Return _instance
        End Get
    End Property

    Private Sub New()

    End Sub

    Public Sub DoSomething()
        Console.WriteLine("I do something...")
    End Sub

End Class
