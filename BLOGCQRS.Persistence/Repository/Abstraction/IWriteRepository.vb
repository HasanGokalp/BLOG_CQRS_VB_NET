Public Interface IWriteRepository(Of T As Class)
    Sub Add(ByVal entity As T)
    Sub Update(ByVal entity As T)
    Sub Delete(ByVal entity As T)
    Sub Delete(ByVal id As Object)
End Interface
