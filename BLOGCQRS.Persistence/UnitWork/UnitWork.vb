Public Class UnitWork
    Implements IUnitWork

    Private ReadOnly dbContext As VBCQRSContext

    Public Sub New(dbContext As VBCQRSContext)
        Me.dbContext = dbContext
    End Sub

    Public Function GetReadRepository(Of T As Class)() As IReadRepository(Of T) Implements IUnitWork.GetReadRepository
        Return New ReadRepository(Of T)(dbContext)
    End Function

    Public Function GetWriteRepository(Of T As Class)() As IWriteRepository(Of T) Implements IUnitWork.GetWriteRepository
        Return New WriteRepository(Of T)(dbContext)
    End Function

    Public Async Function SaveAsync() As Task(Of Integer) Implements IUnitWork.SaveAsync
        Return Await dbContext.SaveChangesAsync
    End Function

    Public Function Save() As Integer Implements IUnitWork.Save
        Return dbContext.SaveChanges
    End Function

    Public Function DisposeAsync() As ValueTask Implements IAsyncDisposable.DisposeAsync
        Return dbContext.DisposeAsync
    End Function
End Class
