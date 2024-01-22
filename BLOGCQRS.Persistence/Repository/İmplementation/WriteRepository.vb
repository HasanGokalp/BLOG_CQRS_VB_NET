Public Class WriteRepository(Of T As Class)
    Implements IWriteRepository(Of T)

    Private ReadOnly _ctx As VBCQRSContext
    Public Sub New(ctx As VBCQRSContext)
        _ctx = ctx
    End Sub

    Public Async Sub Add(entity As T) Implements IWriteRepository(Of T).Add
        Await _ctx.Set(Of T).AddAsync(entity)
    End Sub

    Public Async Function Update(entity As T) As Task Implements IWriteRepository(Of T).Update
        Await Task.Run(Sub() _ctx.Set(Of T).Update(entity))
    End Function

    Public Async Function Delete(entity As T) As Task Implements IWriteRepository(Of T).Delete
        Await Task.Run(Sub() _ctx.Set(Of T).Remove(entity))
    End Function

    Public Async Function Delete(id As Object) As Task Implements IWriteRepository(Of T).Delete
        Await Task.Run(Sub() _ctx.Set(Of T).Remove(id))
    End Function
End Class
