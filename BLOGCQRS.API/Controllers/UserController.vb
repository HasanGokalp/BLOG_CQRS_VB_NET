Imports BLOGCQRS.Application
Imports MediatR
Imports Microsoft.AspNetCore.Mvc

<Route("User")>
<ApiController>
Public Class UserController
    Inherits Controller

    Public Property _mediator As IMediator
    Public Sub New(mediator As IMediator)
        _mediator = mediator
    End Sub

    <HttpPost("Post_CreateUser")>
    Public Async Function CreateUser(request As CreateUserRequest) As Task(Of IActionResult)
        Dim result = Await _mediator.Send(request)
        Return Ok(result)
    End Function

    <HttpPost("Get_GetAllUser")>
    Public Async Function GetAllUser() As Task(Of IActionResult)
        Return Ok(Await _mediator.Send(New GetAllUserRequest))
    End Function

    <HttpPost("Get_GetByIdUser")>
    Public Async Function GetByIdUser(request As GetByIdUserRequest) As Task(Of IActionResult)
        Return Ok(Await _mediator.Send(request))
    End Function

    <HttpPost("Post_UpdateUser")>
    Public Async Function UpdateUser(request As UpdateUserRequest) As Task(Of IActionResult)
        Return Ok(Await _mediator.Send(request))
    End Function

End Class
