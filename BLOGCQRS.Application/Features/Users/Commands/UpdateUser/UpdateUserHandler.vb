Imports System.Threading
Imports BLOGCQRS.Domain
Imports BLOGCQRS.Persistence
Imports MediatR

Public Class UpdateUserHandler
    Implements IRequestHandler(Of UpdateUserRequest, UpdateUserResponse)

    Private ReadOnly _unitwork As IUnitWork

    Public Sub New(unitwork As IUnitWork)
        _unitwork = unitwork
    End Sub

    Public Async Function Handle(request As UpdateUserRequest, cancellationToken As CancellationToken) As Task(Of UpdateUserResponse) Implements IRequestHandler(Of UpdateUserRequest, UpdateUserResponse).Handle

        Dim updatedEntity As User = Await _unitwork.GetReadRepository(Of User).GetById(request.Id)

        updatedEntity.Name = If(request.Name, updatedEntity.Name)
        updatedEntity.Auth = request.Auth
        updatedEntity.IsDelete = False
        updatedEntity.ModifiedDate = DateTime.Now

        Await _unitwork.GetWriteRepository(Of User).Update(updatedEntity)
        Await _unitwork.SaveAsync

        Return New UpdateUserResponse With {
            .IsTrue = True}
    End Function
End Class
