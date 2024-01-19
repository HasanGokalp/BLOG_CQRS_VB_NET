Imports BLOGCQRS.Domain
Imports MediatR

Public Class CreateUserRequest
    Implements IRequest(Of CreateUserResponse)

    Public Property Auth As Authority
    Public Property Name As String

End Class
