Imports BLOGCQRS.Application
Imports MediatR
Imports Microsoft.AspNetCore.Mvc

<Route("Post")>
<ApiController>
Public Class PostController
    Inherits Controller

    Private ReadOnly _mediator As IMediator

    Public Sub New(mediator As IMediator)
        _mediator = mediator
    End Sub

    <HttpPost("Post_CreatePost")>
    Public Async Function CreatePost(request As CreatePostRequest) As Task(Of IActionResult)
        Return Ok(Await _mediator.Send(request))
    End Function

    <HttpPost("Get_GetAllPost")>
    Public Async Function GetAllPost() As Task(Of IActionResult)
        Return Ok(Await _mediator.Send(New GetAllPostRequest))
    End Function

End Class
