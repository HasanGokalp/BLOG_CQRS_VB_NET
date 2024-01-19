﻿Imports BLOGCQRS.Application
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

End Class