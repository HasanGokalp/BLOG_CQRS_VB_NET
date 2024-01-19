Public Interface IUnitWork
    Inherits IAsyncDisposable
    Function GetReadRepository(Of T As Class)() As IReadRepository(Of T)
    Function GetWriteRepository(Of T As Class)() As IWriteRepository(Of T)
    Function SaveAsync() As Task(Of Integer)
    Function Save() As Integer


End Interface
