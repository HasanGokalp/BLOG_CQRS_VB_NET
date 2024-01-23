Imports System.Threading
Imports BLOGCQRS.Domain
Imports BLOGCQRS.Persistence
Imports MediatR

Public Class GetAllPostHandler
    Implements IRequestHandler(Of GetAllPostRequest, IEnumerable(Of GetAllPostResponse))

    Private ReadOnly _unitwork As IUnitWork

    Public Sub New(unitwork As IUnitWork)
        _unitwork = unitwork
    End Sub

    Public Async Function Handle(request As GetAllPostRequest, cancellationToken As CancellationToken) As Task(Of IEnumerable(Of GetAllPostResponse)) Implements IRequestHandler(Of GetAllPostRequest, IEnumerable(Of GetAllPostResponse)).Handle

        Dim entities As IEnumerable(Of Post) = Await _unitwork.GetReadRepository(Of Post).GetAllAsync("Author")

        Dim mappedEntities As IEnumerable(Of GetAllPostResponse) = entities.Select(Function(e) New GetAllPostResponse With {.AuthorName = If(e.Author.Name, "Unkown"), .Content = e.Content, .Tittle = e.Tittle})

        Return mappedEntities

    End Function
End Class
