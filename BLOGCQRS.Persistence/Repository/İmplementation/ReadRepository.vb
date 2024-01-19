Imports System.Linq.Expressions

Public Class ReadRepository(Of T As Class)
    Implements IReadRepository(Of T)

    Private ReadOnly _ctx As VBCQRSContext
    Public Sub New(ctx As VBCQRSContext)
        _ctx = ctx
    End Sub

    Public Function GetAllAsync(ParamArray includeColums() As String) As Task(Of IQueryable(Of T)) Implements IReadRepository(Of T).GetAllAsync
        Throw New NotImplementedException()
    End Function

    Public Function GetByFilterAsync(filter As Expression(Of Func(Of T, Boolean)), ParamArray includeColumns() As String) As Task(Of IQueryable(Of T)) Implements IReadRepository(Of T).GetByFilterAsync
        Throw New NotImplementedException()
    End Function

    Public Function GetSingleByFilterAsync(filter As Expression(Of Func(Of T, Boolean)), ParamArray includeColumns() As String) As Task(Of T) Implements IReadRepository(Of T).GetSingleByFilterAsync
        Throw New NotImplementedException()
    End Function

    Public Function AnyAsync(filter As Expression(Of Func(Of T, Boolean))) As Task(Of Boolean) Implements IReadRepository(Of T).AnyAsync
        Throw New NotImplementedException()
    End Function

    Public Function GetById(id As Object) As Task(Of T) Implements IReadRepository(Of T).GetById
        Throw New NotImplementedException()
    End Function
End Class
