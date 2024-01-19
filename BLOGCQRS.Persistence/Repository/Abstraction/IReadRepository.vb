Imports System.Linq.Expressions

Public Interface IReadRepository(Of T As Class)
    Function GetAllAsync(ParamArray includeColums As String()) As Task(Of IEnumerable(Of T))
    Function GetByFilterAsync(ByVal filter As Expression(Of Func(Of T, Boolean)), ParamArray includeColumns As String()) As Task(Of IEnumerable(Of T))
    Function GetSingleByFilterAsync(ByVal filter As Expression(Of Func(Of T, Boolean)), ParamArray includeColumns As String()) As Task(Of T)
    Function AnyAsync(ByVal filter As Expression(Of Func(Of T, Boolean))) As Task(Of Boolean)
    Function GetById(ByVal id As Object) As Task(Of T)
End Interface
