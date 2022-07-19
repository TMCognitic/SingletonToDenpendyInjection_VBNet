Module Module1

    Sub Main()
        Dim s1 As Resource = Resource.Instance
        s1.DoSomething()
        Dim s2 As Resource = Resource.Instance
        s2.DoSomething()

        Console.WriteLine(ReferenceEquals(s1, s2))
        Console.ReadLine()
    End Sub

End Module
