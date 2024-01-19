Public Class WriteRepository(Of T As Class)
    Implements IWriteRepository(Of T)

    Private ReadOnly _ctx As VBCQRSContext
    Public Sub New(ctx As VBCQRSContext)
        _ctx = ctx
    End Sub

    Public Sub Add(entity As T) Implements IWriteRepository(Of T).Add
        Task.Run(Sub() _ctx.Set(Of T).Add(entity))
    End Sub

    Public Sub Update(entity As T) Implements IWriteRepository(Of T).Update
        Task.Run(Sub() _ctx.Set(Of T).Update(entity))
    End Sub

    Public Sub Delete(entity As T) Implements IWriteRepository(Of T).Delete
        Task.Run(Sub() _ctx.Set(Of T).Remove(entity))
    End Sub

    Public Sub Delete(id As Object) Implements IWriteRepository(Of T).Delete
        Task.Run(Sub() _ctx.Set(Of T).Remove(id))
    End Sub
End Class
