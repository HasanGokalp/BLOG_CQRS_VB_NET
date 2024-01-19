Public Class Post
    Inherits AuditableEntity

    Public Property Tittle As String
    Public Property Content As String
    Public Property UserId As Integer
    Public Property Author As User

End Class
