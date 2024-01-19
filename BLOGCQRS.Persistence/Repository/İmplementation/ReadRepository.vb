Imports System.Linq.Expressions
Imports Microsoft.EntityFrameworkCore

Public Class ReadRepository(Of T As Class)
    Implements IReadRepository(Of T)

    Private ReadOnly _ctx As VBCQRSContext
    Public Sub New(ctx As VBCQRSContext)
        _ctx = ctx
    End Sub

    Public Async Function GetAllAsync(ParamArray includeColums As String()) As Task(Of IEnumerable(Of T)) Implements IReadRepository(Of T).GetAllAsync
        Dim query As IQueryable(Of T) = _ctx.Set(Of T)()

        If includeColums.Any() Then
            For Each includeColumn In includeColums
                query = query.Include(includeColumn)
            Next
        End If

        Return Await Task.Run(Function() query)
    End Function

    Public Async Function GetByFilterAsync(filter As Expression(Of Func(Of T, Boolean)), ParamArray includeColumns() As String) As Task(Of IEnumerable(Of T)) Implements IReadRepository(Of T).GetByFilterAsync
        Dim query As IQueryable(Of T) = _ctx.Set(Of T)()

        If includeColumns.Any() Then
            For Each includeColumn In includeColumns
                query = query.Include(includeColumn)
            Next
        End If

        Return Await Task.Run(Function() query.Where(filter))
    End Function

    Public Async Function GetSingleByFilterAsync(filter As Expression(Of Func(Of T, Boolean)), ParamArray includeColumns() As String) As Task(Of T) Implements IReadRepository(Of T).GetSingleByFilterAsync
        Dim query As IQueryable(Of T) = _ctx.Set(Of T)()

        If includeColumns.Any() Then
            For Each includeColumn In includeColumns
                query = query.Include(includeColumn)
            Next
        End If

        Return Await Task.Run(Async Function() Await query.FirstOrDefaultAsync(filter))
    End Function

    Public Async Function AnyAsync(filter As Expression(Of Func(Of T, Boolean))) As Task(Of Boolean) Implements IReadRepository(Of T).AnyAsync
        Return Await _ctx.Set(Of T).AnyAsync
    End Function

    Public Async Function GetById(id As Object) As Task(Of T) Implements IReadRepository(Of T).GetById
        Dim entity = Await _ctx.Set(Of T).FindAsync(id)
        Return entity
    End Function
End Class
