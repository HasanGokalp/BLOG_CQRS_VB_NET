﻿Imports System.Threading
Imports BLOGCQRS.Domain
Imports BLOGCQRS.Persistence
Imports MediatR

Public Class CreateUserHandler
    Implements IRequestHandler(Of CreateUserRequest, CreateUserResponse)

    Private Property _unit As IUnitWork
    Public Sub New(unit As IUnitWork)
        _unit = unit
    End Sub

    Public Async Function Handle(request As CreateUserRequest, cancellationToken As CancellationToken) As Task(Of CreateUserResponse) Implements IRequestHandler(Of CreateUserRequest, CreateUserResponse).Handle

        Dim repo = _unit.GetWriteRepository(Of User)

        repo.Add(New User With {
        .Auth = request.Auth,
        .CreatedBy = "ADMIN",
        .CreatedDate = DateTime.Now,
        .Name = request.Name})

        Await _unit.SaveAsync

        Return New CreateUserResponse With {
        .IsCreated = True
        }

    End Function
End Class
