Imports System.Threading
Imports BLOGCQRS.Domain
Imports BLOGCQRS.Persistence
Imports MediatR

Public Class DeleteUserHandler
    Implements IRequestHandler(Of DeleteUserRequest, DeleteUserResponse)

    Private ReadOnly _unitwork As IUnitWork

    Public Sub New(unitwork As IUnitWork)
        _unitwork = unitwork
    End Sub

    Public Async Function Handle(request As DeleteUserRequest, cancellationToken As CancellationToken) As Task(Of DeleteUserResponse) Implements IRequestHandler(Of DeleteUserRequest, DeleteUserResponse).Handle

        Dim findedEntity As User = Await _unitwork.GetReadRepository(Of User).GetById(request.Id)

        Await _unitwork.GetWriteRepository(Of User).Delete(findedEntity)
        Await _unitwork.SaveAsync

        Return New DeleteUserResponse With {
            .IsTrue = True}

    End Function
End Class
