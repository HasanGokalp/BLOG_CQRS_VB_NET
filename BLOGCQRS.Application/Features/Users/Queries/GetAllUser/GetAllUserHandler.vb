Imports System.Threading
Imports BLOGCQRS.Domain
Imports BLOGCQRS.Persistence
Imports MediatR

Public Class GetAllUserHandler
    Implements IRequestHandler(Of GetAllUserRequest, IEnumerable(Of GetAllUserResponse))

    Private Property _unitwork As IUnitWork

    Public Sub New(unitwork As IUnitWork)
        _unitwork = unitwork
    End Sub

    Public Async Function Handle(request As GetAllUserRequest, cancellationToken As CancellationToken) As Task(Of IEnumerable(Of GetAllUserResponse)) Implements IRequestHandler(Of GetAllUserRequest, IEnumerable(Of GetAllUserResponse)).Handle

        Dim entites As IEnumerable(Of User) = Await _unitwork.GetReadRepository(Of User).GetAllAsync
        Dim mappedEntities As IEnumerable(Of GetAllUserResponse) = entites.Select(Function(u) New GetAllUserResponse With {
                                                                                  .Name = u.Name})
        Return mappedEntities

    End Function
End Class
