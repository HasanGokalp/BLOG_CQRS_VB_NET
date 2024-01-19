Imports System.Threading
Imports BLOGCQRS.Domain
Imports BLOGCQRS.Persistence
Imports MediatR

Public Class CreateUserHandler
    Implements IRequestHandler(Of CreateUserRequest, CreateUserResponse)

    Public Property _unit As IUnitWork
    Public Sub New(unit As IUnitWork)
        _unit = unit
    End Sub

    Public Async Function Handle(request As CreateUserRequest, cancellationToken As CancellationToken) As Task(Of CreateUserResponse) Implements IRequestHandler(Of CreateUserRequest, CreateUserResponse).Handle

        Dim repo = _unit.GetWriteRepository(Of User)

        repo.Add(New User With {
        .Auth = request.Auth,
        .CreatedBy = "ADMIN",
        .CreatedDate = DateTime.Now,
        .Id = 0,
        .IsDelete = 0,
        .LoginInfos = Nothing,
        .ModifiedBy = Nothing,
        .ModifiedDate = Nothing,
        .Name = request.Name,
        .Posts = Nothing
        })

        Await _unit.SaveAsync

        Return New CreateUserResponse With {
        .IsCreated = True
        }

    End Function
End Class
