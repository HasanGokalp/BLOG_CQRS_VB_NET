Imports System.Threading
Imports BLOGCQRS.Domain
Imports BLOGCQRS.Persistence
Imports MediatR

Public Class CreatePostHandler
    Implements IRequestHandler(Of CreatePostRequest, CreatePostResponse)

    Private ReadOnly _unitwork As IUnitWork

    Public Sub New(unitwork As IUnitWork)
        _unitwork = unitwork
    End Sub

    Public Async Function Handle(request As CreatePostRequest, cancellationToken As CancellationToken) As Task(Of CreatePostResponse) Implements IRequestHandler(Of CreatePostRequest, CreatePostResponse).Handle

        Dim entity As New Post With {
            .Content = request.Content,
            .Tittle = request.Tittle,
            .IsDelete = False,
            .UserId = request.UserId,
            .CreatedDate = DateTime.Now,
            .ModifiedDate = DateTime.Now}

        _unitwork.GetWriteRepository(Of Post).Add(entity)
        Await _unitwork.SaveAsync

        Return New CreatePostResponse With {.IsTrue = True}

    End Function
End Class
