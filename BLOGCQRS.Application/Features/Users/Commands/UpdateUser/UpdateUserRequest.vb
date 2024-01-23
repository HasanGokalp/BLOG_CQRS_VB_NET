Imports BLOGCQRS.Domain
Imports MediatR

Public Class UpdateUserRequest
    Implements IRequest(Of UpdateUserResponse)

    Public Property Id As Integer
    Public Property Auth As Authority
    Public Property Name As String



End Class
