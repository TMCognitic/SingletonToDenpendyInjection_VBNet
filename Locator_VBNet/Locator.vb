Public Class Locator
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
            If (_singleton Is Nothing) Then
                _singleton = New Resource()
            End If
            Return _singleton
        End Get
    End Property

    Private Sub New()

    End Sub
End Class
