Imports MediatR

Public Class CreatePostRequest
    Implements IRequest(Of CreatePostResponse)

    Public Property Tittle As String
    Public Property Content As String
    Public Property UserId As Integer

End Class
