Public Interface IWriteRepository(Of T As Class)
    Sub Add(ByVal entity As T)
    Function Update(ByVal entity As T) As Task
    Function Delete(ByVal entity As T) As Task
    Function Delete(ByVal id As Object) As Task
End Interface
