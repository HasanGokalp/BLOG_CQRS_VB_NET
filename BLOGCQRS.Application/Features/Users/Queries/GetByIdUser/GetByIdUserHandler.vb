Imports System.Threading
Imports BLOGCQRS.Domain
Imports BLOGCQRS.Persistence
Imports MediatR

Public Class GetByIdUserHandler
    Implements IRequestHandler(Of GetByIdUserRequest, GetByIdUserResponse)

    Private ReadOnly _unitwork As IUnitWork

    Public Sub New(unitwork As IUnitWork)
        _unitwork = unitwork
    End Sub

    Public Async Function Handle(request As GetByIdUserRequest, cancellationToken As CancellationToken) As Task(Of GetByIdUserResponse) Implements IRequestHandler(Of GetByIdUserRequest, GetByIdUserResponse).Handle

        Dim findedEntity As User = Await _unitwork.GetReadRepository(Of User).GetSingleByFilterAsync(Function(c) c.Id = request.Id)
        Dim mappedEntity As GetByIdUserResponse = New GetByIdUserResponse With {
        .Name = findedEntity.Name,
        .Auth = findedEntity.Auth,
        .LoginInfos = findedEntity.LoginInfos,
        .Posts = findedEntity.Posts
        }

        Return mappedEntity

    End Function
End Class
